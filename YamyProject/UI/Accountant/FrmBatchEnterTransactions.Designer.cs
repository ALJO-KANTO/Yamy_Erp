using Guna.UI2.WinForms;

namespace YamyProject.UI.Accountant
{
    partial class FrmBatchEnterTransactions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBatchEnterTransactions));
            this.cmbTranType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvBatch = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnSplit = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnCustomize = new Guna.UI2.WinForms.Guna2Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBank = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAccounts = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlLookup = new System.Windows.Forms.Panel();
            this.lstLookup = new System.Windows.Forms.ListBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatch)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlLookup.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTranType
            // 
            this.cmbTranType.BackColor = System.Drawing.Color.Transparent;
            this.cmbTranType.BorderRadius = 5;
            this.cmbTranType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTranType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTranType.DropDownWidth = 361;
            this.cmbTranType.FocusedColor = System.Drawing.Color.Empty;
            this.cmbTranType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTranType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbTranType.ItemHeight = 20;
            this.cmbTranType.Items.AddRange(new object[] {
            "Checks",
            "Deposits",
            "Credit Card Charges & Credits",
            "Bills & Bill Credits",
            "Invoices & Credit Memos"});
            this.cmbTranType.Location = new System.Drawing.Point(143, 35);
            this.cmbTranType.Name = "cmbTranType";
            this.cmbTranType.Size = new System.Drawing.Size(241, 26);
            this.cmbTranType.StartIndex = 0;
            this.cmbTranType.TabIndex = 0;
            this.cmbTranType.SelectedIndexChanged += new System.EventHandler(this.cmbTranType_SelectedIndexChanged);
            // 
            // dgvBatch
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvBatch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBatch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBatch.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBatch.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBatch.Location = new System.Drawing.Point(0, 0);
            this.dgvBatch.MultiSelect = false;
            this.dgvBatch.Name = "dgvBatch";
            this.dgvBatch.RowHeadersVisible = false;
            this.dgvBatch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvBatch.Size = new System.Drawing.Size(1140, 450);
            this.dgvBatch.TabIndex = 3;
            this.dgvBatch.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBatch.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBatch.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBatch.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvBatch.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBatch.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBatch.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBatch.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvBatch.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBatch.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBatch.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBatch.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBatch.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvBatch.ThemeStyle.ReadOnly = false;
            this.dgvBatch.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBatch.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBatch.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBatch.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBatch.ThemeStyle.RowsStyle.Height = 22;
            this.dgvBatch.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBatch.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBatch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBatch_CellClick);
            this.dgvBatch.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBatch_CellEndEdit);
            this.dgvBatch.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBatch_CellValueChanged);
            this.dgvBatch.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvBatch_RowPostPaint);
            this.dgvBatch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvBatch_KeyDown);
            // 
            // btnSplit
            // 
            this.btnSplit.BorderRadius = 5;
            this.btnSplit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSplit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSplit.ForeColor = System.Drawing.Color.Black;
            this.btnSplit.Location = new System.Drawing.Point(19, 14);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(80, 23);
            this.btnSplit.TabIndex = 4;
            this.btnSplit.Text = "Split";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderRadius = 5;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(793, 37);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save Transactions";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BorderRadius = 5;
            this.btnClear.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(963, 37);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 5;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(1053, 37);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCustomize
            // 
            this.btnCustomize.BorderRadius = 5;
            this.btnCustomize.FillColor = System.Drawing.Color.LightGray;
            this.btnCustomize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCustomize.ForeColor = System.Drawing.Color.Black;
            this.btnCustomize.Location = new System.Drawing.Point(968, 35);
            this.btnCustomize.Name = "btnCustomize";
            this.btnCustomize.Size = new System.Drawing.Size(160, 26);
            this.btnCustomize.TabIndex = 2;
            this.btnCustomize.Text = "Customize Columns";
            this.btnCustomize.Click += new System.EventHandler(this.btnCustomize_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(978, 3);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 23);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "TOTAL:";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.Location = new System.Drawing.Point(1028, 3);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(100, 23);
            this.lblTotalValue.TabIndex = 6;
            this.lblTotalValue.Text = "0.00";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.cmbBank);
            this.panel1.Controls.Add(this.cmbTranType);
            this.panel1.Controls.Add(this.btnCustomize);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbAccounts);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1140, 72);
            this.panel1.TabIndex = 10;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.LightBlue;
            this.panel8.Controls.Add(this.label2);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1140, 23);
            this.panel8.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1140, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Batch Enter Transactions";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbBank
            // 
            this.cmbBank.BackColor = System.Drawing.Color.Transparent;
            this.cmbBank.BorderRadius = 5;
            this.cmbBank.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbBank.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbBank.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbBank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbBank.ItemHeight = 20;
            this.cmbBank.Location = new System.Drawing.Point(552, 35);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(361, 26);
            this.cmbBank.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "TRANSACTION TYPE";
            // 
            // lbAccounts
            // 
            this.lbAccounts.AutoSize = true;
            this.lbAccounts.Location = new System.Drawing.Point(455, 44);
            this.lbAccounts.Name = "lbAccounts";
            this.lbAccounts.Size = new System.Drawing.Size(91, 13);
            this.lbAccounts.TabIndex = 5;
            this.lbAccounts.Text = "BANK ACCOUNT";
            this.lbAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btnSplit);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.lblTotalValue);
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 522);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1140, 63);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1140, 585);
            this.panel3.TabIndex = 252;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pnlLookup);
            this.panel4.Controls.Add(this.dgvBatch);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 72);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1140, 450);
            this.panel4.TabIndex = 12;
            // 
            // pnlLookup
            // 
            this.pnlLookup.BackColor = System.Drawing.Color.White;
            this.pnlLookup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLookup.Controls.Add(this.lstLookup);
            this.pnlLookup.Location = new System.Drawing.Point(438, 47);
            this.pnlLookup.Name = "pnlLookup";
            this.pnlLookup.Size = new System.Drawing.Size(245, 215);
            this.pnlLookup.TabIndex = 4;
            this.pnlLookup.Visible = false;
            // 
            // lstLookup
            // 
            this.lstLookup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLookup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLookup.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLookup.FormattingEnabled = true;
            this.lstLookup.Location = new System.Drawing.Point(0, 0);
            this.lstLookup.Name = "lstLookup";
            this.lstLookup.Size = new System.Drawing.Size(243, 213);
            this.lstLookup.TabIndex = 0;
            this.lstLookup.Click += new System.EventHandler(this.lstLookup_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(1138, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 585);
            this.panel5.TabIndex = 253;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 583);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1138, 2);
            this.panel6.TabIndex = 254;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(2, 583);
            this.panel7.TabIndex = 255;
            // 
            // FrmBatchEnterTransactions
            // 
            this.ClientSize = new System.Drawing.Size(1140, 585);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBatchEnterTransactions";
            this.Text = "Batch Enter Transactions";
            this.Load += new System.EventHandler(this.FrmBatchEnterTransactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatch)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlLookup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna2ComboBox cmbTranType;
        private Guna2DataGridView dgvBatch;
        private Guna2Button btnSplit;
        private Guna2Button btnSave;
        private Guna2Button btnClear;
        private Guna2Button btnClose;
        private Guna2Button btnCustomize;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private Guna2ComboBox cmbBank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbAccounts;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlLookup;
        private System.Windows.Forms.ListBox lstLookup;
    }
    //partial class FrmBatchEnterTransactions
    //{
    //    /// <summary>
    //    /// Required designer variable.
    //    /// </summary>
    //    private System.ComponentModel.IContainer components = null;

    //    /// <summary>
    //    /// Clean up any resources being used.
    //    /// </summary>
    //    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && (components != null))
    //        {
    //            components.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    #region Windows Form Designer generated code

    //    /// <summary>
    //    /// Required method for Designer support - do not modify
    //    /// the contents of this method with the code editor.
    //    /// </summary>
    //    private void InitializeComponent()
    //    {
    //        this.cmbTranType = new System.Windows.Forms.ComboBox();
    //        this.dtPostingDate = new System.Windows.Forms.DateTimePicker();
    //        this.dgvBatch = new System.Windows.Forms.DataGridView();
    //        this.btnSave = new System.Windows.Forms.Button();
    //        this.lblType = new System.Windows.Forms.Label();
    //        this.lblDate = new System.Windows.Forms.Label();

    //        ((System.ComponentModel.ISupportInitialize)(this.dgvBatch)).BeginInit();
    //        this.SuspendLayout();

    //        // Transaction Type
    //        this.lblType.Text = "Transaction Type";
    //        this.lblType.Location = new System.Drawing.Point(12, 15);

    //        this.cmbTranType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    //        this.cmbTranType.Items.AddRange(new object[] {
    //            "Invoice",
    //            "Credit Memo",
    //            "Bill",
    //            "Bill Credit",
    //            "Check",
    //            "Deposit",
    //            "Credit Card Charge"
    //        });
    //        this.cmbTranType.Location = new System.Drawing.Point(130, 12);
    //        this.cmbTranType.SelectedIndexChanged += new System.EventHandler(this.cmbTranType_SelectedIndexChanged);

    //        // Posting Date
    //        this.lblDate.Text = "Posting Date";
    //        this.lblDate.Location = new System.Drawing.Point(320, 15);

    //        this.dtPostingDate.Location = new System.Drawing.Point(410, 12);

    //        // DataGridView
    //        this.dgvBatch.Location = new System.Drawing.Point(12, 50);
    //        this.dgvBatch.Size = new System.Drawing.Size(960, 420);
    //        this.dgvBatch.AllowUserToAddRows = true;
    //        this.dgvBatch.AllowUserToDeleteRows = true;
    //        this.dgvBatch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

    //        // Save Button
    //        this.btnSave.Text = "Save Batch";
    //        this.btnSave.Location = new System.Drawing.Point(12, 480);
    //        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

    //        // Form
    //        this.ClientSize = new System.Drawing.Size(990, 520);
    //        this.Controls.Add(this.lblType);
    //        this.Controls.Add(this.cmbTranType);
    //        this.Controls.Add(this.lblDate);
    //        this.Controls.Add(this.dtPostingDate);
    //        this.Controls.Add(this.dgvBatch);
    //        this.Controls.Add(this.btnSave);
    //        this.Text = "Batch Enter Transactions";

    //        ((System.ComponentModel.ISupportInitialize)(this.dgvBatch)).EndInit();
    //        this.ResumeLayout(false);
    //    }

    //    #endregion

    //    private System.Windows.Forms.ComboBox cmbTranType;
    //    private System.Windows.Forms.DateTimePicker dtPostingDate;
    //    private System.Windows.Forms.DataGridView dgvBatch;
    //    private System.Windows.Forms.Button btnSave;
    //    private System.Windows.Forms.Label lblType;
    //    private System.Windows.Forms.Label lblDate;
    //}
}