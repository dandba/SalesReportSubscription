namespace SalesReportSubscription
{
    partial class frmSearch
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
            txtSearchString = new TextBox();
            cboAttrib = new ComboBox();
            lblField = new Label();
            lblValue = new Label();
            BtnSearch = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtSearchString
            // 
            txtSearchString.Location = new Point(144, 59);
            txtSearchString.Margin = new Padding(3, 4, 3, 4);
            txtSearchString.Name = "txtSearchString";
            txtSearchString.Size = new Size(146, 27);
            txtSearchString.TabIndex = 0;
            // 
            // cboAttrib
            // 
            cboAttrib.FormattingEnabled = true;
            cboAttrib.Location = new Point(12, 57);
            cboAttrib.Margin = new Padding(3, 4, 3, 4);
            cboAttrib.Name = "cboAttrib";
            cboAttrib.Size = new Size(117, 28);
            cboAttrib.TabIndex = 1;
            // 
            // lblField
            // 
            lblField.AutoSize = true;
            lblField.Location = new Point(12, 27);
            lblField.Name = "lblField";
            lblField.Size = new Size(89, 20);
            lblField.TabIndex = 2;
            lblField.Text = "Search Field";
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Location = new Point(144, 29);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(45, 20);
            lblValue.TabIndex = 3;
            lblValue.Text = "Value";
            // 
            // BtnSearch
            // 
            BtnSearch.Location = new Point(307, 57);
            BtnSearch.Margin = new Padding(3, 4, 3, 4);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(86, 31);
            BtnSearch.TabIndex = 4;
            BtnSearch.Text = "&Search";
            BtnSearch.UseVisualStyleBackColor = true;
            BtnSearch.Click += BtnSearch_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(55, 216);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(168, 77);
            dataGridView1.TabIndex = 7;
            dataGridView1.Visible = false;
            dataGridView1.CellContentDoubleClick += dataGridView1_CellContentDoubleClick;
            dataGridView1.CellToolTipTextNeeded += dataGridView1_CellToolTipTextNeeded;
            // 
            // frmSearch
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 324);
            Controls.Add(dataGridView1);
            Controls.Add(BtnSearch);
            Controls.Add(lblValue);
            Controls.Add(lblField);
            Controls.Add(cboAttrib);
            Controls.Add(txtSearchString);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmSearch";
            Text = "Subscription Search";
            Load += frmSearch_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearchString;
        private ComboBox cboAttrib;
        private Label lblField;
        private Label lblValue;
        private Button BtnSearch;
        private DataGridView dataGridView1;
    }
}