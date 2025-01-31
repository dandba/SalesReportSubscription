namespace SalesReportSubscription
{
    partial class frmEdit
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
            lblId = new Label();
            txtTerritory = new TextBox();
            label1 = new Label();
            lblSchedule = new Label();
            lblFilename = new Label();
            label4 = new Label();
            txtSchedule = new TextBox();
            txtFilename = new TextBox();
            txtPassword = new TextBox();
            txtParamStr = new TextBox();
            btnRefresh = new Button();
            lblEmailCC = new Label();
            txtCcEmail = new TextBox();
            lblEmailTo = new Label();
            txtEmail = new TextBox();
            lnkLblUpdEmail = new LinkLabel();
            lnkLblUpdEmailcc = new LinkLabel();
            btnDelete = new Button();
            label2 = new Label();
            lnkUpdateParams = new LinkLabel();
            lnkLblUpdFilename = new LinkLabel();
            lblSubscription = new Label();
            txtFilePrefix = new TextBox();
            label5 = new Label();
            btnDone = new Button();
            txtNewTerritory = new TextBox();
            lnkUpdateTerritory = new LinkLabel();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(190, 29);
            lblId.Name = "lblId";
            lblId.Size = new Size(17, 15);
            lblId.TabIndex = 117;
            lblId.Text = "Id";
            // 
            // txtTerritory
            // 
            txtTerritory.Location = new Point(345, 28);
            txtTerritory.Name = "txtTerritory";
            txtTerritory.Size = new Size(121, 23);
            txtTerritory.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(286, 31);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 118;
            label1.Text = "Territory:";
            // 
            // lblSchedule
            // 
            lblSchedule.AutoSize = true;
            lblSchedule.Location = new Point(35, 73);
            lblSchedule.Name = "lblSchedule";
            lblSchedule.Size = new Size(58, 15);
            lblSchedule.TabIndex = 119;
            lblSchedule.Text = "Schedule:";
            // 
            // lblFilename
            // 
            lblFilename.AutoSize = true;
            lblFilename.Location = new Point(35, 117);
            lblFilename.Name = "lblFilename";
            lblFilename.Size = new Size(58, 15);
            lblFilename.TabIndex = 121;
            lblFilename.Text = "Filename:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(420, 73);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 120;
            label4.Text = "Password:";
            // 
            // txtSchedule
            // 
            txtSchedule.Location = new Point(107, 70);
            txtSchedule.Name = "txtSchedule";
            txtSchedule.Size = new Size(100, 23);
            txtSchedule.TabIndex = 2;
            // 
            // txtFilename
            // 
            txtFilename.Location = new Point(107, 114);
            txtFilename.Name = "txtFilename";
            txtFilename.Size = new Size(265, 23);
            txtFilename.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(486, 70);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(119, 23);
            txtPassword.TabIndex = 3;
            // 
            // txtParamStr
            // 
            txtParamStr.Location = new Point(32, 341);
            txtParamStr.Margin = new Padding(3, 2, 3, 2);
            txtParamStr.Multiline = true;
            txtParamStr.Name = "txtParamStr";
            txtParamStr.ScrollBars = ScrollBars.Horizontal;
            txtParamStr.Size = new Size(575, 60);
            txtParamStr.TabIndex = 9;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(41, 451);
            btnRefresh.Margin = new Padding(3, 2, 3, 2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(82, 22);
            btnRefresh.TabIndex = 11;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblEmailCC
            // 
            lblEmailCC.AutoSize = true;
            lblEmailCC.Location = new Point(34, 253);
            lblEmailCC.Name = "lblEmailCC";
            lblEmailCC.Size = new Size(55, 15);
            lblEmailCC.TabIndex = 123;
            lblEmailCC.Text = "Email CC";
            // 
            // txtCcEmail
            // 
            txtCcEmail.Location = new Point(32, 279);
            txtCcEmail.Margin = new Padding(3, 2, 3, 2);
            txtCcEmail.MaxLength = 75;
            txtCcEmail.Name = "txtCcEmail";
            txtCcEmail.Size = new Size(573, 23);
            txtCcEmail.TabIndex = 7;
            // 
            // lblEmailTo
            // 
            lblEmailTo.AutoSize = true;
            lblEmailTo.Location = new Point(35, 170);
            lblEmailTo.Name = "lblEmailTo";
            lblEmailTo.Size = new Size(51, 15);
            lblEmailTo.TabIndex = 122;
            lblEmailTo.Text = "Email To";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(34, 197);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.MaxLength = 250;
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(573, 40);
            txtEmail.TabIndex = 5;
            // 
            // lnkLblUpdEmail
            // 
            lnkLblUpdEmail.AutoSize = true;
            lnkLblUpdEmail.Location = new Point(130, 170);
            lnkLblUpdEmail.Name = "lnkLblUpdEmail";
            lnkLblUpdEmail.Size = new Size(77, 15);
            lnkLblUpdEmail.TabIndex = 6;
            lnkLblUpdEmail.TabStop = true;
            lnkLblUpdEmail.Text = "Update Email";
            lnkLblUpdEmail.LinkClicked += lnkLblUpdEmail_LinkClicked;
            // 
            // lnkLblUpdEmailcc
            // 
            lnkLblUpdEmailcc.AutoSize = true;
            lnkLblUpdEmailcc.Location = new Point(130, 253);
            lnkLblUpdEmailcc.Name = "lnkLblUpdEmailcc";
            lnkLblUpdEmailcc.Size = new Size(96, 15);
            lnkLblUpdEmailcc.TabIndex = 8;
            lnkLblUpdEmailcc.TabStop = true;
            lnkLblUpdEmailcc.Text = "Update Email CC";
            lnkLblUpdEmailcc.LinkClicked += lnkLblUpdEmailcc_LinkClicked;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(144, 451);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(82, 22);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 314);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 124;
            label2.Text = "Paramter String";
            // 
            // lnkUpdateParams
            // 
            lnkUpdateParams.AutoSize = true;
            lnkUpdateParams.Location = new Point(135, 314);
            lnkUpdateParams.Name = "lnkUpdateParams";
            lnkUpdateParams.Size = new Size(107, 15);
            lnkUpdateParams.TabIndex = 10;
            lnkUpdateParams.TabStop = true;
            lnkUpdateParams.Text = "Update Parameters";
            lnkUpdateParams.LinkClicked += lnkUpdateParams_LinkClicked;
            // 
            // lnkLblUpdFilename
            // 
            lnkLblUpdFilename.AutoSize = true;
            lnkLblUpdFilename.Location = new Point(621, 117);
            lnkLblUpdFilename.Name = "lnkLblUpdFilename";
            lnkLblUpdFilename.Size = new Size(96, 15);
            lnkLblUpdFilename.TabIndex = 125;
            lnkLblUpdFilename.TabStop = true;
            lnkLblUpdFilename.Text = "Update Filename";
            lnkLblUpdFilename.LinkClicked += lnkLblUpdFilename_LinkClicked;
            // 
            // lblSubscription
            // 
            lblSubscription.AutoSize = true;
            lblSubscription.Location = new Point(35, 29);
            lblSubscription.Name = "lblSubscription";
            lblSubscription.Size = new Size(76, 15);
            lblSubscription.TabIndex = 126;
            lblSubscription.Text = "Subscription:";
            // 
            // txtFilePrefix
            // 
            txtFilePrefix.Location = new Point(486, 114);
            txtFilePrefix.Name = "txtFilePrefix";
            txtFilePrefix.Size = new Size(119, 23);
            txtFilePrefix.TabIndex = 127;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(419, 117);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 128;
            label5.Text = "File Prefix:";
            // 
            // btnDone
            // 
            btnDone.Location = new Point(262, 450);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(75, 23);
            btnDone.TabIndex = 129;
            btnDone.Text = "Done";
            btnDone.UseVisualStyleBackColor = true;
            btnDone.Click += btnDone_Click;
            // 
            // txtNewTerritory
            // 
            txtNewTerritory.Location = new Point(486, 28);
            txtNewTerritory.Name = "txtNewTerritory";
            txtNewTerritory.Size = new Size(119, 23);
            txtNewTerritory.TabIndex = 130;
            // 
            // lnkUpdateTerritory
            // 
            lnkUpdateTerritory.AutoSize = true;
            lnkUpdateTerritory.Location = new Point(621, 31);
            lnkUpdateTerritory.Name = "lnkUpdateTerritory";
            lnkUpdateTerritory.Size = new Size(91, 15);
            lnkUpdateTerritory.TabIndex = 131;
            lnkUpdateTerritory.TabStop = true;
            lnkUpdateTerritory.Text = "Update Territory";
            lnkUpdateTerritory.LinkClicked += lnkUpdateTerritory_LinkClicked;
            // 
            // frmEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 504);
            Controls.Add(lnkUpdateTerritory);
            Controls.Add(txtNewTerritory);
            Controls.Add(btnDone);
            Controls.Add(label5);
            Controls.Add(txtFilePrefix);
            Controls.Add(lblSubscription);
            Controls.Add(lnkLblUpdFilename);
            Controls.Add(lnkUpdateParams);
            Controls.Add(label2);
            Controls.Add(btnDelete);
            Controls.Add(lnkLblUpdEmailcc);
            Controls.Add(lnkLblUpdEmail);
            Controls.Add(lblEmailCC);
            Controls.Add(txtCcEmail);
            Controls.Add(lblEmailTo);
            Controls.Add(txtEmail);
            Controls.Add(btnRefresh);
            Controls.Add(txtParamStr);
            Controls.Add(txtPassword);
            Controls.Add(txtFilename);
            Controls.Add(txtSchedule);
            Controls.Add(label4);
            Controls.Add(lblFilename);
            Controls.Add(lblSchedule);
            Controls.Add(label1);
            Controls.Add(txtTerritory);
            Controls.Add(lblId);
            Name = "frmEdit";
            Text = "Subscription Edit";
            Load += frmEdit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Label lblId;
        public TextBox txtTerritory;
        private Label label1;
        private Label lblSchedule;
        private Label lblFilename;
        private Label label4;
        public TextBox txtSchedule;
        public TextBox txtFilename;
        public TextBox txtPassword;
        private TextBox txtParamStr;
        private Button btnRefresh;
        private Label lblEmailCC;
        private TextBox txtCcEmail;
        private Label lblEmailTo;
        private TextBox txtEmail;
        private LinkLabel lnkLblUpdEmail;
        private LinkLabel lnkLblUpdEmailcc;
        private Button btnDelete;
        private Label label2;
        private LinkLabel lnkUpdateParams;
        private LinkLabel lnkLblUpdFilename;
        private Label lblSubscription;
        private TextBox txtFilePrefix;
        private Label label5;
        private Button btnDone;
        private TextBox txtNewTerritory;
        private LinkLabel lnkUpdateTerritory;
    }
}