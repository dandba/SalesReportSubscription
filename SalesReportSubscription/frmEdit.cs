using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SalesReportSubscription
{
    public partial class frmEdit : Form
    {
        public frmEdit()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string s = lblId.Text;
            if (int.TryParse(s, out int i))
            {
                GetData(i);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string s = lblId.Text;
            if (int.TryParse(s, out int i)) //id must be an int
            {
                Delete_Subscription(i);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            string s = lblId.Text;
            if (int.TryParse(s, out int i))
            {
                GetData(i);
            }
            //Disable fields not yet editable
            txtTerritory.Enabled = false;
            txtSchedule.Enabled = false;
            txtPassword.Enabled = false;
            //txtFilename.Enabled = false;
        }

        private void GetData(int iRecId)
        {
            Cursor.Current = Cursors.WaitCursor;
            SqlDataReader rdr;
            SqlConnection con = new SqlConnection(SalesReportSubscription.Properties.Settings.Default.ConString);


            SqlCommand cmd = new SqlCommand("SELECT [paramstring],[emailto],[emailcc] FROM [ReportPrint].[dbo].[SubscriptionList] WHERE recid = @recid;", con);
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@recid", iRecId);

            cmd.Parameters.Add(param[0]);
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    txtParamStr.Text = rdr.GetString(0);
                    txtEmail.Text = rdr.GetString(1);
                    txtCcEmail.Text = rdr.GetString(2);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con?.Close();
                Cursor.Current = Cursors.Default;
            }
        }

        private void lnkLblUpdEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string s = lblId.Text;
            if (int.TryParse(s, out int i)) //id must be an int
            {
                if (!string.IsNullOrEmpty(txtEmail.Text)) //email cannot be null
                {
                    Update_Email(i);
                }
            }
        }

        private void lnkLblUpdEmailcc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string s = lblId.Text;
            if (int.TryParse(s, out int i)) //id must be an int
            {
                if (!string.IsNullOrEmpty(txtCcEmail.Text)) //email cannot be null
                {
                    Update_Emailcc(i);
                }
                else//We are removing all cc recipients
                {
                    txtCcEmail.Text = "";
                    Update_Emailcc(i);
                }
            }
        }

        private void lnkLblUpdFilename_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Todo validate input.
            string s = lblId.Text;
            if (int.TryParse(s, out int i)) //id must be an int
            {
                Update_Subscription_Filename(i);
            }
        }

        private void lnkUpdateTerritory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sParam = txtParamStr.Text;
            string o = txtTerritory.Text;
            string n = txtNewTerritory.Text;
            string sNewParam;


            //Find the position of the old territory
            int i = sParam.IndexOf(o);

            if (i == -1)//Old territory not found in the param string so review and edit as necessary.
            {
                MessageBox.Show("Old Territory not found in Parameter string.", "Territory not Found");
            }
            else
            {
                sNewParam = sParam.Substring(0, 64) + n + sParam.Substring(64 + o.Length);//Update the param string.

                if (sNewParam == txtParamStr.Text)
                {
                    MessageBox.Show("The updated territory will not change the parameter string", "Report Peameters");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Do you want to update the parameters?", "Confirmation", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show("Review/Edit the new parameters and click update.", "Report Peameters");
                        txtParamStr.Text = sNewParam;//Post change for review and update accordingly.
                    }
                }
            }

            if (o != n)
            {
                string s = lblId.Text;
                if (int.TryParse(s, out int j)) //id must be an int
                {
                    if (!string.IsNullOrEmpty(txtNewTerritory.Text)) //Territory cannot be null.
                    {
                        Update_Territory(j);
                    }
                }
            }
        }
        private void lnkUpdateParams_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string s = lblId.Text;
            if (int.TryParse(s, out int i)) //id must be an int
            {
                if (!string.IsNullOrEmpty(txtParamStr.Text)) //email cannot be null
                {
                    Update_Parameters(i);
                }
            }
        }
        private void Update_Email(int iRecId)
        {
            SqlConnection con = new SqlConnection(SalesReportSubscription.Properties.Settings.Default.ConString);
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE [ReportPrint].[dbo].[SubscriptionList] SET [emailto] = @email WHERE recid = @recid;", con);
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@recid", iRecId);
                    cmd.Parameters.Add(param[0]);

                    param[1] = new SqlParameter("@email", txtEmail.Text);
                    cmd.Parameters.Add(param[1]);

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Success", "Update Email");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Email");
            }
            finally
            {
                con?.Close();
                Cursor.Current = Cursors.Default;
            }
        }

        private void Update_Emailcc(int iRecId)
        {
            SqlConnection con = new SqlConnection(SalesReportSubscription.Properties.Settings.Default.ConString);
            string sEmail = txtCcEmail.Text;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE [ReportPrint].[dbo].[SubscriptionList] SET [emailcc] = @email WHERE recid = @recid;", con);
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@recid", iRecId);
                    cmd.Parameters.Add(param[0]);

                    param[1] = new SqlParameter("@email", txtCcEmail.Text);
                    cmd.Parameters.Add(param[1]);

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Success", "Update Email cc");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update EmailCC");
            }
            finally
            {
                con?.Close();
                Cursor.Current = Cursors.Default;
            }
        }

        private void Update_Parameters(int iRecId)
        {
            SqlConnection con = new SqlConnection(SalesReportSubscription.Properties.Settings.Default.ConString);
            string sParams = txtParamStr.Text;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE [ReportPrint].[dbo].[SubscriptionList] SET [paramstring] = @param WHERE recid = @recid;", con);
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@recid", iRecId);
                    cmd.Parameters.Add(param[0]);

                    param[1] = new SqlParameter("@param", txtParamStr.Text);
                    cmd.Parameters.Add(param[1]);

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Parameters");
            }
            finally
            {
                con?.Close();
                Cursor.Current = Cursors.Default;
            }
        }    
        private void Update_Territory(int iRecId)
        {
            SqlConnection con = new SqlConnection(SalesReportSubscription.Properties.Settings.Default.ConString);
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE [ReportPrint].[dbo].[SubscriptionList] SET [Territory] = @param WHERE recid = @recid;", con);
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@recid", iRecId);
                    cmd.Parameters.Add(param[0]);

                    param[1] = new SqlParameter("@param", txtNewTerritory.Text);
                    cmd.Parameters.Add(param[1]);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Territory Update Successful", "Update Territory");
                txtTerritory.Text = txtNewTerritory.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Territory");
            }
            finally
            {
                con?.Close();
                Cursor.Current = Cursors.Default;
            }
        }

        private void Update_Subscription_Filename(int iRecId)
        {
            SqlConnection con = new SqlConnection(SalesReportSubscription.Properties.Settings.Default.ConString);

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[uspUpdateSubscriptionFilename]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@recId", iRecId));
                    cmd.Parameters.Add(new SqlParameter("@filename", txtFilename.Text));
                    cmd.Parameters.Add(new SqlParameter("@fileprefix", txtFilePrefix.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Subscription Update", "Update Filename");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Filename");
            }
            finally
            {
                con?.Close();
                Cursor.Current = Cursors.Default;
            }
        }

        private static void Delete_Subscription(int iRecId)
        {
            SqlConnection con = new SqlConnection(SalesReportSubscription.Properties.Settings.Default.ConString);

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[uspRemoveSubscription]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@recId", iRecId));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Subscription Delete", "Delete Subscription");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Subscription");
            }
            finally
            {
                con?.Close();
                Cursor.Current = Cursors.Default;
            }
        }    
        
    }
}
