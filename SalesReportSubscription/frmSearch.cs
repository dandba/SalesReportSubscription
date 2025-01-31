using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesReportSubscription
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            //Exec dbo.usp_Search and get the subscription if any.
            //use the datagrid click code and launch the edit form with the populated values.

            this.dataGridView1.Visible = false;

            cboAttrib.Items.Add("[emailto]");
            cboAttrib.Items.Add("[emailcc]");
            cboAttrib.Items.Add("[fileprefix]");
            cboAttrib.Items.Add("[Territory]");


            //frmEdit fe = new frmEdit();
            //fe.lblId.Text = "528";
            //fe.txtTerritory.Text = "";
            //fe.txtSchedule.Text = "";
            //fe.txtFilename.Text = "";
            //fe.txtPassword.Text = "";
            //fe.ShowDialog();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Search_Subscription();
        }

        private void Search_Subscription()
        {
            //Todo pass the file Prefix as the email name. Requires stored proc mod.
            //This is required in the event the territory is an '*'.
            SqlConnection con = new SqlConnection(SalesReportSubscription.Properties.Settings.Default.ConString);
            DataTable dt = new DataTable();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("dbo.usp_Search", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@filter", txtSearchString.Text));
                    cmd.Parameters.Add(new SqlParameter("@field", cboAttrib.Text));

                    cmd.Parameters.Add("@cnt", SqlDbType.Int).Direction = ParameterDirection.Output;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    int irecd_cnt = Convert.ToInt32(cmd.Parameters["@cnt"].Value);
                    if (irecd_cnt > 0)
                    {
                        //Form and grid format
                        FormatGrid(irecd_cnt);

                    }
                    else
                    {
                        MessageBox.Show("No subscriptions found. Try being less specific on the search value.", "Subscription Search");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Search Subscription");
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void FormatGrid(int irecd_cnt)
        {
            //Form Changes
            this.Width = 750;
            this.Height = 290 + (irecd_cnt * 3);
            this.MaximumSize = new Size(this.Width, this.Height);
            Application.DoEvents();

            //Datagrid Changes
            this.dataGridView1.Visible = true;
            this.dataGridView1.Left = 12;
            this.dataGridView1.Top = 120;
            this.dataGridView1.Width = 700;
            this.dataGridView1.Height = this.Height - 200;

            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Aquamarine;
            this.dataGridView1.GridColor = Color.Blue;
            this.dataGridView1.BorderStyle = BorderStyle.Fixed3D;


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

            //tsslbl2.Text = "  Record Count: " + this.dataGridView1.Rows.Count.ToString();
            //tsslbl2.ForeColor = Color.Blue;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEdit fe = new frmEdit();
            fe.lblId.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            fe.txtTerritory.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            fe.txtSchedule.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            fe.txtFilename.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            fe.txtPassword.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            fe.ShowDialog();
        }

        private void dataGridView1_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            e.ToolTipText = "Double-Click To Edit";
        }
    }
}
