using System.Data;
using System.Drawing;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SalesReportSubscription
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load Interface dropdowns
            ListReports();
            LoadGrid();
            FormatGrid();

            AddSubscription_ToolTip.SetToolTip(btnAdd, "Add New Subscription");
            RefreshSubscription_ToolTip.SetToolTip(btnRefresh, "View Changes and New");

            this.dataGridView1.CellToolTipTextNeeded += dataGridView1_CellToolTipTextNeeded;


            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            tsslbl1.Text = userName;
            tsslbl1.ForeColor = Color.Blue;
        }

        private void dataGridView1_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            e.ToolTipText = "Double-Click To Edit";

        }
        /// <summary>
        /// This routine, ListReports will retrieve a list of reports and use them to populate a combo box.
        /// Associated with each report is am SSRS report id and a subscription id. The subscription id is tied to a SQL Server Agent job
        /// The end goal is to have one subscrition or job for each report. The parameter are all driven by the subscription. Each subscription
        /// should eventually land the reports in the same location. The report distribution looks in one single location (currently \\DB-SRV\Reports2).
        /// </summary>
        private void ListReports()
        {
            Cursor.Current = Cursors.WaitCursor;
            cboReportName.Items.Clear();
            cboReportName.Text = "";

            SqlDataReader rdr;

            SqlConnection con = new SqlConnection(SalesReportSubscription.Properties.Settings.Default.ConString);

            SqlCommand cmd = new SqlCommand("SELECT [reportname] FROM [ReportPrint].[dbo].[ReportList] WHERE [Active] = 1;", con);
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cboReportName.Items.Add(rdr.GetString(0));
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //rdr.Close();
                con.Close();
                Cursor.Current = Cursors.Default;
            }
        }

        private void LoadGrid()
        {
            string sQuery = "SELECT [recid],[Territory],[reporttype],[reportfilename],[excelpwd],[reportname] FROM [ReportPrint].[dbo].[SubscriptionList]";


            SqlConnection con = new SqlConnection(SalesReportSubscription.Properties.Settings.Default.ConString);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = con;
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.CommandText = sQuery;
            DataTable dtRecord = new DataTable();
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

            sqlDataAdap.Fill(dtRecord);
            dataGridView1.DataSource = dtRecord.DefaultView;

            if (!string.IsNullOrEmpty(cboReportName.Text))
            {
                dtRecord.DefaultView.RowFilter = string.Format("reportname LIKE '%{0}%'", cboReportName.Text);
            }
        }

        private void FormatGrid()
        {
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Aquamarine;
            this.dataGridView1.GridColor = Color.Blue;
            this.dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            this.dataGridView1.Width = 640;

            this.dataGridView1.Columns["reportname"].Visible = false;
            this.dataGridView1.RowHeadersVisible = false;

            this.dataGridView1.Columns["recid"].MinimumWidth = 80;
            this.dataGridView1.Columns["recid"].Width = 90;
            this.dataGridView1.Columns["recid"].HeaderText = "Subscription";

            //this.dataGridView1.Columns["Territory"].MinimumWidth = 155;
            this.dataGridView1.Columns["Territory"].HeaderText = "Territory";

            this.dataGridView1.Columns["reportType"].MinimumWidth = 60;
            this.dataGridView1.Columns["reportType"].Width = 70;
            this.dataGridView1.Columns["reportType"].HeaderText = "Schedule";

            this.dataGridView1.Columns["reportfilename"].MinimumWidth = 260;
            this.dataGridView1.Columns["reportfilename"].HeaderText = "File Name";

            this.dataGridView1.Columns["excelpwd"].MinimumWidth = 30;
            this.dataGridView1.Columns["excelpwd"].HeaderText = "Password";
            //this.dataGridView1.Columns["excelpwd"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



            Application.DoEvents();

            tsslbl2.Text = "  Record Count: " + this.dataGridView1.Rows.Count.ToString();
            tsslbl2.ForeColor = Color.Blue;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sReport = cboReportName.Text;
            if (!string.IsNullOrEmpty(sReport))
            {
                New_Subscription f2 = new New_Subscription(sReport);
                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please choose a report", "Report Selection Needed");
            }
        }


        private void cboReportName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            //this.dataGridView1.Rows.Clear();
            this.dataGridView1.DataSource = null;
            Application.DoEvents();
            LoadGrid();
            FormatGrid();
            Application.DoEvents();


        }

        /// <summary>
        /// This is used to edit a subscription after it has been created. 
        /// When necessary, we can update incorrect values. The app user needs to 
        /// select a subscription with a double click on a datagridview row.
        /// TODO: Add edits for all values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEdit fe = new frmEdit();
            fe.lblId.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            fe.txtTerritory.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            fe.txtSchedule.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            fe.txtFilename.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            fe.txtPassword.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            fe.ShowDialog();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cboReportName.Text = "";

            RefreshGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearch se = new frmSearch();
            se.ShowDialog();

        }
    }
}
