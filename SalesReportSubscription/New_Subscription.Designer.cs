namespace SalesReportSubscription
{
    partial class New_Subscription
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cboSite = new ComboBox();
            lblSite = new Label();
            cboTerritory = new ComboBox();
            lblTerritory = new Label();
            cboRegion = new ComboBox();
            lblRegion = new Label();
            cboSalesChannel = new ComboBox();
            lblSalesChannel = new Label();
            cboProduct = new ComboBox();
            lblProductCode = new Label();
            cboPassword = new ComboBox();
            lblPassword = new Label();
            cboFreq = new ComboBox();
            lblFreq = new Label();
            txtEmail = new TextBox();
            lblEmailTo = new Label();
            txtCcEmail = new TextBox();
            lblEmailCC = new Label();
            btnValidate = new Button();
            btnCancel = new Button();
            btnSave = new Button();
            lblEmailLen = new Label();
            lblCcLen = new Label();
            lblNewSubscription = new Label();
            txtParamStr = new TextBox();
            txtFilePrefix = new TextBox();
            lblFilePrefix = new Label();
            SuspendLayout();
            // 
            // cboSite
            // 
            cboSite.FormattingEnabled = true;
            cboSite.Location = new Point(47, 62);
            cboSite.Name = "cboSite";
            cboSite.Size = new Size(121, 23);
            cboSite.TabIndex = 0;
            cboSite.TextChanged += cboSite_TextChanged;
            // 
            // lblSite
            // 
            lblSite.AutoSize = true;
            lblSite.Location = new Point(48, 42);
            lblSite.Name = "lblSite";
            lblSite.Size = new Size(26, 15);
            lblSite.TabIndex = 101;
            lblSite.Text = "Site";
            // 
            // cboTerritory
            // 
            cboTerritory.FormattingEnabled = true;
            cboTerritory.Location = new Point(198, 62);
            cboTerritory.Name = "cboTerritory";
            cboTerritory.Size = new Size(121, 23);
            cboTerritory.Sorted = true;
            cboTerritory.TabIndex = 1;
            cboTerritory.TextChanged += cboTerritory_TextChanged;
            // 
            // lblTerritory
            // 
            lblTerritory.AutoSize = true;
            lblTerritory.Location = new Point(201, 43);
            lblTerritory.Name = "lblTerritory";
            lblTerritory.Size = new Size(50, 15);
            lblTerritory.TabIndex = 102;
            lblTerritory.Text = "Territory";
            // 
            // cboRegion
            // 
            cboRegion.FormattingEnabled = true;
            cboRegion.Location = new Point(348, 63);
            cboRegion.Name = "cboRegion";
            cboRegion.Size = new Size(121, 23);
            cboRegion.Sorted = true;
            cboRegion.TabIndex = 2;
            cboRegion.SelectedIndexChanged += cboRegion_SelectedIndexChanged;
            // 
            // lblRegion
            // 
            lblRegion.AutoSize = true;
            lblRegion.Location = new Point(350, 42);
            lblRegion.Name = "lblRegion";
            lblRegion.Size = new Size(44, 15);
            lblRegion.TabIndex = 103;
            lblRegion.Text = "Region";
            // 
            // cboSalesChannel
            // 
            cboSalesChannel.FormattingEnabled = true;
            cboSalesChannel.Location = new Point(499, 63);
            cboSalesChannel.Name = "cboSalesChannel";
            cboSalesChannel.Size = new Size(121, 23);
            cboSalesChannel.Sorted = true;
            cboSalesChannel.TabIndex = 3;
            // 
            // lblSalesChannel
            // 
            lblSalesChannel.AutoSize = true;
            lblSalesChannel.Location = new Point(501, 42);
            lblSalesChannel.Name = "lblSalesChannel";
            lblSalesChannel.Size = new Size(80, 15);
            lblSalesChannel.TabIndex = 104;
            lblSalesChannel.Text = "Sales Channel";
            // 
            // cboProduct
            // 
            cboProduct.FormattingEnabled = true;
            cboProduct.Location = new Point(47, 136);
            cboProduct.Name = "cboProduct";
            cboProduct.Size = new Size(121, 23);
            cboProduct.Sorted = true;
            cboProduct.TabIndex = 4;
            cboProduct.TextChanged += cboProduct_TextChanged;
            // 
            // lblProductCode
            // 
            lblProductCode.AutoSize = true;
            lblProductCode.Location = new Point(49, 113);
            lblProductCode.Name = "lblProductCode";
            lblProductCode.Size = new Size(80, 15);
            lblProductCode.TabIndex = 105;
            lblProductCode.Text = "Product Code";
            // 
            // cboPassword
            // 
            cboPassword.FormattingEnabled = true;
            cboPassword.Location = new Point(198, 136);
            cboPassword.Name = "cboPassword";
            cboPassword.Size = new Size(121, 23);
            cboPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(200, 114);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 106;
            lblPassword.Text = "Password";
            // 
            // cboFreq
            // 
            cboFreq.FormattingEnabled = true;
            cboFreq.Items.AddRange(new object[] { "D", "M", "W" });
            cboFreq.Location = new Point(350, 136);
            cboFreq.Name = "cboFreq";
            cboFreq.Size = new Size(121, 23);
            cboFreq.Sorted = true;
            cboFreq.TabIndex = 6;
            cboFreq.TextChanged += cboFreq_TextChanged;
            // 
            // lblFreq
            // 
            lblFreq.AutoSize = true;
            lblFreq.Location = new Point(351, 116);
            lblFreq.Name = "lblFreq";
            lblFreq.Size = new Size(62, 15);
            lblFreq.TabIndex = 107;
            lblFreq.Text = "Frequency";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(47, 196);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.MaxLength = 250;
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(573, 40);
            txtEmail.TabIndex = 8;
            // 
            // lblEmailTo
            // 
            lblEmailTo.AutoSize = true;
            lblEmailTo.Location = new Point(49, 176);
            lblEmailTo.Name = "lblEmailTo";
            lblEmailTo.Size = new Size(51, 15);
            lblEmailTo.TabIndex = 109;
            lblEmailTo.Text = "Email To";
            // 
            // txtCcEmail
            // 
            txtCcEmail.Location = new Point(47, 275);
            txtCcEmail.Margin = new Padding(3, 2, 3, 2);
            txtCcEmail.MaxLength = 75;
            txtCcEmail.Name = "txtCcEmail";
            txtCcEmail.Size = new Size(573, 23);
            txtCcEmail.TabIndex = 9;
            // 
            // lblEmailCC
            // 
            lblEmailCC.AutoSize = true;
            lblEmailCC.Location = new Point(50, 253);
            lblEmailCC.Name = "lblEmailCC";
            lblEmailCC.Size = new Size(55, 15);
            lblEmailCC.TabIndex = 110;
            lblEmailCC.Text = "Email CC";
            // 
            // btnValidate
            // 
            btnValidate.Location = new Point(249, 320);
            btnValidate.Margin = new Padding(3, 2, 3, 2);
            btnValidate.Name = "btnValidate";
            btnValidate.Size = new Size(82, 22);
            btnValidate.TabIndex = 10;
            btnValidate.Text = "Validate";
            btnValidate.UseVisualStyleBackColor = true;
            btnValidate.Click += btnValidate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(455, 320);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(82, 22);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(556, 320);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(82, 22);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblEmailLen
            // 
            lblEmailLen.AutoSize = true;
            lblEmailLen.ForeColor = Color.Blue;
            lblEmailLen.Location = new Point(547, 237);
            lblEmailLen.Name = "lblEmailLen";
            lblEmailLen.Size = new Size(44, 15);
            lblEmailLen.TabIndex = 110;
            lblEmailLen.Text = "(0/250)";
            // 
            // lblCcLen
            // 
            lblCcLen.AutoSize = true;
            lblCcLen.ForeColor = Color.Blue;
            lblCcLen.Location = new Point(547, 298);
            lblCcLen.Name = "lblCcLen";
            lblCcLen.Size = new Size(38, 15);
            lblCcLen.TabIndex = 115;
            lblCcLen.Text = "(0/75)";
            // 
            // lblNewSubscription
            // 
            lblNewSubscription.AutoSize = true;
            lblNewSubscription.Location = new Point(49, 8);
            lblNewSubscription.Name = "lblNewSubscription";
            lblNewSubscription.Size = new Size(148, 15);
            lblNewSubscription.TabIndex = 116;
            lblNewSubscription.Text = "Creating New Subscription";
            // 
            // txtParamStr
            // 
            txtParamStr.Location = new Point(50, 382);
            txtParamStr.Margin = new Padding(3, 2, 3, 2);
            txtParamStr.Multiline = true;
            txtParamStr.Name = "txtParamStr";
            txtParamStr.ScrollBars = ScrollBars.Horizontal;
            txtParamStr.Size = new Size(588, 60);
            txtParamStr.TabIndex = 117;
            txtParamStr.TabStop = false;
            // 
            // txtFilePrefix
            // 
            txtFilePrefix.Location = new Point(501, 136);
            txtFilePrefix.Name = "txtFilePrefix";
            txtFilePrefix.Size = new Size(119, 23);
            txtFilePrefix.TabIndex = 7;
            // 
            // lblFilePrefix
            // 
            lblFilePrefix.AutoSize = true;
            lblFilePrefix.Location = new Point(503, 117);
            lblFilePrefix.Name = "lblFilePrefix";
            lblFilePrefix.Size = new Size(58, 15);
            lblFilePrefix.TabIndex = 108;
            lblFilePrefix.Text = "File Prefix";
            // 
            // New_Subscription
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(675, 450);
            Controls.Add(lblFilePrefix);
            Controls.Add(txtFilePrefix);
            Controls.Add(txtParamStr);
            Controls.Add(lblNewSubscription);
            Controls.Add(lblCcLen);
            Controls.Add(lblEmailLen);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(btnValidate);
            Controls.Add(lblEmailCC);
            Controls.Add(txtCcEmail);
            Controls.Add(lblEmailTo);
            Controls.Add(txtEmail);
            Controls.Add(lblFreq);
            Controls.Add(cboFreq);
            Controls.Add(lblPassword);
            Controls.Add(cboPassword);
            Controls.Add(lblProductCode);
            Controls.Add(cboProduct);
            Controls.Add(lblSalesChannel);
            Controls.Add(cboSalesChannel);
            Controls.Add(lblRegion);
            Controls.Add(cboRegion);
            Controls.Add(lblTerritory);
            Controls.Add(cboTerritory);
            Controls.Add(lblSite);
            Controls.Add(cboSite);
            Name = "New_Subscription";
            Text = "New_Subscription";
            Load += New_Subscription_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboSite;
        private Label lblSite;
        private ComboBox cboTerritory;
        private Label lblTerritory;
        private ComboBox cboRegion;
        private Label lblRegion;
        private ComboBox cboSalesChannel;
        private Label lblSalesChannel;
        private ComboBox cboProduct;
        private Label lblProductCode;
        private ComboBox cboPassword;
        private Label lblPassword;
        private ComboBox cboFreq;
        private Label lblFreq;
        private TextBox txtEmail;
        private Label lblEmailTo;
        private TextBox txtCcEmail;
        private Label lblEmailCC;
        private Button btnValidate;
        private Button btnCancel;
        private Button btnSave;
        private Label lblEmailLen;
        private Label lblCcLen;
        private Label lblNewSubscription;
        private TextBox txtParamStr;
        private TextBox txtFilePrefix;
        private Label lblFilePrefix;
    }
}