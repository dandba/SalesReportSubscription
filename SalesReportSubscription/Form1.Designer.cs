namespace SalesReportSubscription
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cboReportName = new ComboBox();
            lblReport = new Label();
            btnAdd = new Button();
            dataGridView1 = new DataGridView();
            btnRefresh = new Button();
            tsslbl1 = new ToolStripStatusLabel();
            statusStrip1 = new StatusStrip();
            tsslbl2 = new ToolStripStatusLabel();
            btnExit = new Button();
            AddSubscription_ToolTip = new ToolTip(components);
            RefreshSubscription_ToolTip = new ToolTip(components);
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // cboReportName
            // 
            cboReportName.FormattingEnabled = true;
            cboReportName.Location = new Point(30, 58);
            cboReportName.Name = "cboReportName";
            cboReportName.Size = new Size(242, 23);
            cboReportName.TabIndex = 0;
            cboReportName.SelectedIndexChanged += cboReportName_SelectedIndexChanged;
            // 
            // lblReport
            // 
            lblReport.AutoSize = true;
            lblReport.Location = new Point(31, 40);
            lblReport.Name = "lblReport";
            lblReport.Size = new Size(71, 15);
            lblReport.TabIndex = 1;
            lblReport.Text = "Report Filter";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(276, 58);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(102, 22);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "&Add Subscription";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(30, 126);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(645, 300);
            dataGridView1.TabIndex = 10;
            dataGridView1.TabStop = false;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(389, 58);
            btnRefresh.Margin = new Padding(3, 2, 3, 2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(102, 22);
            btnRefresh.TabIndex = 12;
            btnRefresh.Text = "&Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // tsslbl1
            // 
            tsslbl1.Name = "tsslbl1";
            tsslbl1.Size = new Size(0, 17);
            // 
            // statusStrip1
            // 
            statusStrip1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            statusStrip1.Dock = DockStyle.None;
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsslbl1, tsslbl2 });
            statusStrip1.Location = new Point(8, 430);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(135, 22);
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsslbl2
            // 
            tsslbl2.Name = "tsslbl2";
            tsslbl2.Size = new Size(118, 17);
            tsslbl2.Text = "toolStripStatusLabel1";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(503, 58);
            btnExit.Margin = new Padding(3, 2, 3, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(102, 22);
            btnExit.TabIndex = 13;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(415, 95);
            label1.Name = "label1";
            label1.Size = new Size(123, 15);
            label1.TabIndex = 14;
            label1.Text = "Add Salesperson Filter";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, searchToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(702, 24);
            menuStrip1.TabIndex = 15;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(54, 20);
            searchToolStripMenuItem.Text = "&Search";
            searchToolStripMenuItem.Click += searchToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 458);
            Controls.Add(label1);
            Controls.Add(btnExit);
            Controls.Add(btnRefresh);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(dataGridView1);
            Controls.Add(btnAdd);
            Controls.Add(lblReport);
            Controls.Add(cboReportName);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MaximumSize = new Size(726, 497);
            Name = "Form1";
            Text = "Sales Reports Subscriptions";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboReportName;
        private Label lblReport;
        private Button btnAdd;
        private DataGridView dataGridView1;
        private Button btnRefresh;
        private ToolStripStatusLabel tsslbl1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslbl2;
        private Button btnExit;
        private ToolTip AddSubscription_ToolTip;
        private ToolTip RefreshSubscription_ToolTip;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
    }
}
