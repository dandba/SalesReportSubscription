using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace SalesReportSubscription
{
    public partial class New_Subscription : Form
    {
        private readonly string _sReportSubscription;
        public New_Subscription(string sReportSubscription)
        {
            _sReportSubscription = sReportSubscription;
            InitializeComponent();
        }


        private void New_Subscription_Load(object sender, EventArgs e)
        {
            ListSites();
            ListTerritory();
            ListRegion();
            ListSalesChannel();
            cboProduct.Text = "*";
            cboProduct.Items.Add("*");
            cboFreq.Text = "W";
            lblNewSubscription.Text = "Creating New " + _sReportSubscription + " Subscription";
            BuildParamString();
        }

        private void ListSites()
        {
            Cursor.Current = Cursors.WaitCursor;
            cboSite.Items.Clear();
            cboSite.Text = "*";
            cboSite.Items.Add("*");

            SqlDataReader rdr;

            SqlConnection con = new SqlConnection(SalesReportSubscription.Properties.Settings.Default.ConString);

            SqlCommand cmd = new SqlCommand("SELECT DISTINCT [site] FROM [ERP_V9].[BI].[SRGenericOrderLine];", con);
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cboSite.Items.Add(rdr.GetString(0));
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

        private void ListTerritory()
        {
            Cursor.Current = Cursors.WaitCursor;
            cboTerritory.Items.Clear();
            cboTerritory.Text = "*";
            cboTerritory.Items.Add("*");

            SqlDataReader rdr;

            SqlConnection con = new SqlConnection(SalesReportSubscription.Properties.Settings.Default.ConString);

            SqlCommand cmd = new SqlCommand("SELECT DISTINCT [salesperson] FROM [ERP_V9].[BI].[SRGenericOrderLine] WHERE [salesperson] IS NOT NULL;", con);
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cboTerritory.Items.Add(rdr.GetString(0));
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

        private void ListRegion()
        {
            Cursor.Current = Cursors.WaitCursor;
            cboRegion.Items.Clear();
            cboRegion.Text = "*";
            cboRegion.Items.Add("*");

            SqlDataReader rdr;

            SqlConnection con = new SqlConnection(SalesReportSubscription.Properties.Settings.Default.ConString);

            SqlCommand cmd = new SqlCommand("SELECT DISTINCT [salesmanager] FROM [ERP_V9].[BI].[SRGenericOrderLine] WHERE [salesmanager] IS NOT NULL;", con);
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cboRegion.Items.Add(rdr.GetString(0));
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

        private void ListSalesChannel()
        {
            Cursor.Current = Cursors.WaitCursor;
            cboSalesChannel.Items.Clear();
            cboSalesChannel.Text = "Regional_SC";

            SqlDataReader rdr;

            SqlConnection con = new SqlConnection(SalesReportSubscription.Properties.Settings.Default.ConString);

            SqlCommand cmd = new SqlCommand("SELECT DISTINCT [saleschannel] FROM [ERP_V9].[BI].[SRGenericOrderLine] WHERE [saleschannel] IS NOT NULL;", con);
            try
            {
                con.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cboSalesChannel.Items.Add(rdr.GetString(0));
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
        private void btnValidate_Click(object sender, EventArgs e)
        {
            ValidateInput();
        }

        private bool ValidateInput()
        {
            txtFilePrefix.BackColor = Color.White;//This routine may have changed the backColor to yellow.
            bool bValid = false;
            bValid = CleanEmails();
            if (bValid)
            {
                bValid = TextBoxLength();
            }

            string fileName = txtFilePrefix.Text;

            var isValid = !string.IsNullOrEmpty(fileName) &&
              fileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;

            if (!isValid)
            {
                MessageBox.Show("The file name prefix is not valid", "Choose a valid file name");
                txtFilePrefix.BackColor = Color.Yellow;
            }

            return bValid;
        }

        /// <summary>
        /// This routine replaces commas with semicolons in the email string.
        /// It then passes the email string to a validator that checks the 
        /// email stricture.
        /// </summary>
        private bool CleanEmails()
        {
            bool bValid = true;
            string sEmail = txtEmail.Text;
            if (!string.IsNullOrEmpty(sEmail))
            {
                string sNewEmailString = RemoveWhitespace(sEmail.ToLower());
                bValid = ParseEmails(sNewEmailString);
                txtEmail.Text = sNewEmailString;
            }

            string ccEmail = txtCcEmail.Text;
            if (!string.IsNullOrEmpty(ccEmail) && bValid)
            {
                string sNewccEmailString = RemoveWhitespace(ccEmail.ToLower());
                ParseEmails(sNewccEmailString);
                txtCcEmail.Text = sNewccEmailString;
            }
            return bValid;
        }

        /// <summary>
        /// This routine checks the length of the text in the email text box to ensure
        /// that it does not exceed the length of the database field.
        /// </summary>
        private bool TextBoxLength()
        {
            bool bValid = true;

            int iemail = txtEmail.Text.Length;
            lblEmailLen.Text = "(" + iemail + "/250)";
            if (iemail > 250)
            {
                lblEmailLen.ForeColor = Color.Red;
                bValid = false;
            }
            else
            {
                lblEmailLen.ForeColor = Color.Black;
            }

            int iccemail = txtCcEmail.Text.Length;
            lblCcLen.Text = "(" + iccemail + "/75)";
            if (iccemail > 75)
            {
                lblCcLen.ForeColor = Color.Red;
                bValid = false;
            }
            else
            {
                lblCcLen.ForeColor = Color.Black;
            }

            return bValid;
        }

        /// <summary>
        /// This routine splits the emails entered into an array of strings. 
        /// Each email is then passed to the Validate Email routine which uses a
        /// class method to parse and validate the email structure using
        /// regular expressions.
        /// </summary>
        private bool ParseEmails(string sEmailString)
        {
            bool bValid = true;

            string[] emails = sEmailString.Split(';');

            foreach (var email in emails)
            {
                if (!Email_Validator.IsValidEmail(email))
                {
                    MessageBox.Show(email + " is not valid");
                    bValid = false;
                }
            }
            return bValid;
        }

        public static string RemoveWhitespace(string input)
        {
            //Replace commas with semicolons
            string sEmail = input.Replace(',', ';');

            return new string(sEmail.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

        /// <summary>
        /// This routine builds the paramstring attribute for a subscription added to
        /// the table [dbo].[SubscriptionList]. This attribute varies according to the
        /// report and the desired subscription parrameters.
        /// </summary>
        private void BuildParamString()
        {
            //TODO Displan the string under the sample for a visual check in the ui.
            string sTimeframe = (cboFreq.Text == "W") ? "CW" : cboFreq.Text;
            string sSample = "";
            string sParam = "";
            switch (_sReportSubscription)
            {
                case "SNAP-SHOT New Orders":
                    sSample = "|SalesManager|,*,|SalesChannel|,Regional_SC,|Site|,*,|Salesman|,LaPaRM,|ProductCode|,*,|TimeframeText|,CW";
                    sParam = "|SalesManager|," + cboRegion.Text + ",|SalesChannel|," + cboSalesChannel.Text + ",|Site|,";
                    sParam += cboSite.Text + ",|Salesman|," + cboTerritory.Text + ",|ProductCode|," + cboProduct.Text + ",|TimeframeText|," + sTimeframe;
                    break;
                case "SNAP-SHOT New Estimates":
                    sSample = "|SalesManager|,*,|SalesChannel|,Regional_SC,|Site|,*,|Salesman|,LaPaRM,|ProductCode|,*,|TimeframeText|,CW";
                    sParam = "|SalesManager|," + cboRegion.Text + ",|SalesChannel|," + cboSalesChannel.Text + ",|Site|,";
                    sParam += cboSite.Text + ",|Salesman|," + cboTerritory.Text + ",|ProductCode|," + cboProduct.Text + ",|TimeframeText|," + sTimeframe;
                    break;
                case "SNAP-SHOT Shipments":
                    sSample = "|SalesManager|,*,|SalesChannel|,Regional_SC,|Sites|,*,|Salesman|,LaPaRM,|ProductCode|,*,|TimeframeText|,CW";
                    sParam = "|SalesManager|," + cboRegion.Text + ",|SalesChannel|," + cboSalesChannel.Text + ",|Sites|,";
                    sParam += cboSite.Text + ",|Salesman|," + cboTerritory.Text + ",|ProductCode|," + cboProduct.Text + ",|TimeframeText|," + sTimeframe;
                    break;
                case "SNAP-SHOT Monthly Salesperson Report":
                    cboSite.Visible = false;
                    lblSite.Visible = false;
                    cboProduct.Visible = false;
                    lblProductCode.Visible = false;
                    sSample = "|Salesmgr|,*,|SalesChannel|,Regional_SC,|SalesPerson|,LaPaRM,|ProductCode|,*,|TimeframeText|,CW";
                    sParam = "|Salesmgr|," + cboRegion.Text + ",|SalesChannel|," + cboSalesChannel.Text + ",|SalesPerson|,";
                    sParam += cboTerritory.Text;
                    break;
                case "SNAP-SHOT Late Orders":
                    sSample = "|SalesManager|,*,|SalesChannel|,Regional_SC,|Site|,*,|Salesman|,LaPaRM,|ProductCode|,*,|TimeframeText|,D";
                    sParam = "|SalesManager|," + cboRegion.Text + ",|SalesChannel|," + cboSalesChannel.Text + ",|Site|,";
                    sParam += cboSite.Text + ",|Salesman|," + cboTerritory.Text + ",|ProductCode|," + cboProduct.Text + ",|TimeframeText|," + sTimeframe;
                    break;
                default:
                    break;
            }
            txtParamStr.Text = sParam;
        }


        private void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildParamString();
        }

        private void cboSite_TextChanged(object sender, EventArgs e)
        {
            BuildParamString();
        }

        private void cboTerritory_TextChanged(object sender, EventArgs e)
        {
            BuildParamString();
        }

        private void cboProduct_TextChanged(object sender, EventArgs e)
        {
            BuildParamString();
        }

        private void cboFreq_TextChanged(object sender, EventArgs e)
        {
            BuildParamString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BuildParamString();

            if (ValidateInput()) //We can try to save the new record.
            {
                switch (_sReportSubscription)
                {
                    case "SNAP-SHOT New Orders":
                        Save_Subscription("dbo.uspNewOrderReportSubscription");
                        break;
                    case "SNAP-SHOT New Estimates":
                        Save_Subscription("dbo.uspNewEstimatesSubscription");
                        break;
                    case "SNAP-SHOT Shipments":
                        Save_Subscription("dbo.uspNewShipmentsSubscription");
                        break;
                    case "SNAP-SHOT Monthly Salesperson Report":
                        Save_Subscription("dbo.uspNewMonthlySalespersonSubscription");
                        break;
                    case "SNAP-SHOT Late Orders":
                        Save_Subscription("dbo.uspLateOrderReportSubscription");
                        break;
                    default:
                        break;
                }
            }
        }

        private void Save_Subscription(string sReport)
        {
            //Todo pass the file Prefix as the email name. Requires stored proc mod.
            //This is required in the event the territory is an '*'.
            SqlConnection con = new SqlConnection(SalesReportSubscription.Properties.Settings.Default.ConString);
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sReport, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@sales_code", cboTerritory.Text));         // [Territory], | Salesman |
                    if (sReport != "dbo.uspNewMonthlySalespersonSubscription")
                    {
                        cmd.Parameters.Add(new SqlParameter("@site", cboSite.Text));//Not Monthly
                        cmd.Parameters.Add(new SqlParameter("@product_code", cboProduct.Text));//Not Monthly
                    }
                    cmd.Parameters.Add(new SqlParameter("@SalesChannel", cboSalesChannel.Text));    // eg. 'Regional_SC'
                    cmd.Parameters.Add(new SqlParameter("@Region", cboRegion.Text));                //--|SalesManager|
                    cmd.Parameters.Add(new SqlParameter("@pwd", cboPassword.Text));
                    cmd.Parameters.Add(new SqlParameter("@freq", cboFreq.Text));
                    cmd.Parameters.Add(new SqlParameter("@email", txtEmail.Text));
                    cmd.Parameters.Add(new SqlParameter("@cc", txtCcEmail.Text));
                    cmd.Parameters.Add(new SqlParameter("@fileprefix", txtFilePrefix.Text));
                    cmd.Parameters.Add("@recId", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    int subscriptionID = Convert.ToInt32(cmd.Parameters["@recId"].Value);
                    if (subscriptionID > 0)
                    {
                        lblNewSubscription.Text += " - " + subscriptionID.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Subscription");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
