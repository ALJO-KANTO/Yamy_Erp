namespace YamyProject.UI.Banking.BankTransactions
{
    partial class frmBankTransaction
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBankTransaction));
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dgvJV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.account_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dated = new YamyProject.DAL.CalendarColumn();
            this.bank_ac = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.account_name = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_Import = new Guna.UI2.WinForms.Guna2Button();
            this.txtJvId = new System.Windows.Forms.TextBox();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrevious = new Guna.UI2.WinForms.Guna2Button();
            this.guna2VSeparator12 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.guna2TileButton23 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2TileButton22 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2TileButton21 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2TileButton20 = new Guna.UI2.WinForms.Guna2TileButton();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.guna2VSeparator11 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.guna2TileButton18 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2TileButton17 = new Guna.UI2.WinForms.Guna2TileButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.guna2TileButton27 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2TileButton28 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2TileButton29 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2VSeparator13 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.guna2TileButton26 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2TileButton25 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2TileButton24 = new Guna.UI2.WinForms.Guna2TileButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCreditAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDebitAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.headerUC1 = new YamyProject.HeaderUC();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbBankName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblBankName = new System.Windows.Forms.Label();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJV)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Delete";
            this.dataGridViewImageColumn1.Image = global::YamyProject.Properties.Resources.Trash;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 125;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dgvJV);
            this.panel9.Controls.Add(this.tabControl2);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(3, 37);
            this.panel9.Margin = new System.Windows.Forms.Padding(4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1137, 493);
            this.panel9.TabIndex = 249;
            // 
            // dgvJV
            // 
            this.dgvJV.AllowUserToDeleteRows = false;
            this.dgvJV.AllowUserToResizeColumns = false;
            this.dgvJV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvJV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvJV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvJV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvJV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvJV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvJV.ColumnHeadersHeight = 20;
            this.dgvJV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvJV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.account_id,
            this.no,
            this.dated,
            this.bank_ac,
            this.account_name,
            this.Debit,
            this.Credit,
            this.description,
            this.balance,
            this.delete});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvJV.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvJV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvJV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvJV.Location = new System.Drawing.Point(0, 109);
            this.dgvJV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvJV.MultiSelect = false;
            this.dgvJV.Name = "dgvJV";
            this.dgvJV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvJV.RowHeadersVisible = false;
            this.dgvJV.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.dgvJV.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvJV.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvJV.RowTemplate.Height = 25;
            this.dgvJV.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvJV.Size = new System.Drawing.Size(1137, 384);
            this.dgvJV.TabIndex = 8;
            this.dgvJV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvJV.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.dgvJV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvJV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvJV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvJV.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvJV.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvJV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Silver;
            this.dgvJV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvJV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.dgvJV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvJV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvJV.ThemeStyle.HeaderStyle.Height = 20;
            this.dgvJV.ThemeStyle.ReadOnly = false;
            this.dgvJV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvJV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvJV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.dgvJV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvJV.ThemeStyle.RowsStyle.Height = 25;
            this.dgvJV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvJV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvJV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJV_CellValueChanged);
            this.dgvJV.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvJV_RowPostPaint);
            // 
            // account_id
            // 
            this.account_id.HeaderText = "id";
            this.account_id.MinimumWidth = 6;
            this.account_id.Name = "account_id";
            this.account_id.Visible = false;
            this.account_id.Width = 125;
            // 
            // no
            // 
            this.no.HeaderText = "#";
            this.no.MinimumWidth = 6;
            this.no.Name = "no";
            this.no.ReadOnly = true;
            this.no.Width = 35;
            // 
            // dated
            // 
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            this.dated.DefaultCellStyle = dataGridViewCellStyle3;
            this.dated.HeaderText = "Date";
            this.dated.Name = "dated";
            this.dated.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // bank_ac
            // 
            this.bank_ac.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bank_ac.FillWeight = 50F;
            this.bank_ac.HeaderText = "Bank AC";
            this.bank_ac.MinimumWidth = 6;
            this.bank_ac.Name = "bank_ac";
            // 
            // account_name
            // 
            this.account_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.account_name.FillWeight = 50F;
            this.account_name.HeaderText = "Account Name";
            this.account_name.MinimumWidth = 6;
            this.account_name.Name = "account_name";
            // 
            // Debit
            // 
            this.Debit.HeaderText = "Debit";
            this.Debit.MinimumWidth = 4;
            this.Debit.Name = "Debit";
            this.Debit.Width = 90;
            // 
            // Credit
            // 
            this.Credit.HeaderText = "Credit";
            this.Credit.MinimumWidth = 4;
            this.Credit.Name = "Credit";
            this.Credit.Width = 90;
            // 
            // description
            // 
            this.description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.description.HeaderText = "Description";
            this.description.MinimumWidth = 6;
            this.description.Name = "description";
            // 
            // balance
            // 
            this.balance.HeaderText = "balance";
            this.balance.Name = "balance";
            this.balance.ReadOnly = true;
            this.balance.Visible = false;
            // 
            // delete
            // 
            this.delete.HeaderText = "DEL";
            this.delete.MinimumWidth = 3;
            this.delete.Name = "delete";
            this.delete.Width = 70;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl2.HotTrack = true;
            this.tabControl2.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.Padding = new System.Drawing.Point(20, 3);
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1137, 109);
            this.tabControl2.TabIndex = 39;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.cmbBankName);
            this.tabPage3.Controls.Add(this.lblBankName);
            this.tabPage3.Controls.Add(this.btn_Import);
            this.tabPage3.Controls.Add(this.txtJvId);
            this.tabPage3.Controls.Add(this.btnNext);
            this.tabPage3.Controls.Add(this.btnPrevious);
            this.tabPage3.Controls.Add(this.guna2VSeparator12);
            this.tabPage3.Controls.Add(this.guna2TileButton23);
            this.tabPage3.Controls.Add(this.guna2TileButton22);
            this.tabPage3.Controls.Add(this.guna2TileButton21);
            this.tabPage3.Controls.Add(this.guna2TileButton20);
            this.tabPage3.Controls.Add(this.checkBox3);
            this.tabPage3.Controls.Add(this.guna2VSeparator11);
            this.tabPage3.Controls.Add(this.checkBox4);
            this.tabPage3.Controls.Add(this.guna2TileButton18);
            this.tabPage3.Controls.Add(this.guna2TileButton17);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(1129, 83);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Main";
            // 
            // btn_Import
            // 
            this.btn_Import.BackColor = System.Drawing.Color.Transparent;
            this.btn_Import.BackgroundImage = global::YamyProject.Properties.Resources.excel___Copy;
            this.btn_Import.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Import.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Import.BorderRadius = 5;
            this.btn_Import.BorderThickness = 1;
            this.btn_Import.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btn_Import.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Import.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Import.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Import.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Import.FillColor = System.Drawing.Color.Transparent;
            this.btn_Import.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Import.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Import.Location = new System.Drawing.Point(1073, 23);
            this.btn_Import.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(33, 35);
            this.btn_Import.TabIndex = 29;
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // txtJvId
            // 
            this.txtJvId.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtJvId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtJvId.Enabled = false;
            this.txtJvId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtJvId.Location = new System.Drawing.Point(38, 27);
            this.txtJvId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtJvId.Multiline = true;
            this.txtJvId.Name = "txtJvId";
            this.txtJvId.Size = new System.Drawing.Size(77, 24);
            this.txtJvId.TabIndex = 16;
            this.txtJvId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.FillColor = System.Drawing.Color.Transparent;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Image = global::YamyProject.Properties.Resources.Arrow22;
            this.btnNext.ImageSize = new System.Drawing.Size(25, 25);
            this.btnNext.Location = new System.Drawing.Point(116, 19);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(38, 38);
            this.btnNext.TabIndex = 2;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.FillColor = System.Drawing.Color.Transparent;
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Image = global::YamyProject.Properties.Resources.Arrow_Pointing_Left;
            this.btnPrevious.Location = new System.Drawing.Point(4, 21);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(35, 36);
            this.btnPrevious.TabIndex = 3;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // guna2VSeparator12
            // 
            this.guna2VSeparator12.Location = new System.Drawing.Point(153, 7);
            this.guna2VSeparator12.Margin = new System.Windows.Forms.Padding(4);
            this.guna2VSeparator12.Name = "guna2VSeparator12";
            this.guna2VSeparator12.Size = new System.Drawing.Size(10, 61);
            this.guna2VSeparator12.TabIndex = 17;
            // 
            // guna2TileButton23
            // 
            this.guna2TileButton23.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton23.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton23.BorderRadius = 10;
            this.guna2TileButton23.BorderThickness = 2;
            this.guna2TileButton23.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton23.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton23.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton23.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton23.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton23.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton23.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton23.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton23.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton23.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton23.Image = global::YamyProject.Properties.Resources.add_fileN;
            this.guna2TileButton23.Location = new System.Drawing.Point(162, 11);
            this.guna2TileButton23.Margin = new System.Windows.Forms.Padding(4);
            this.guna2TileButton23.Name = "guna2TileButton23";
            this.guna2TileButton23.Size = new System.Drawing.Size(63, 62);
            this.guna2TileButton23.TabIndex = 19;
            this.guna2TileButton23.Text = "New";
            this.guna2TileButton23.Click += new System.EventHandler(this.guna2TileButton23_Click);
            // 
            // guna2TileButton22
            // 
            this.guna2TileButton22.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton22.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton22.BorderRadius = 10;
            this.guna2TileButton22.BorderThickness = 2;
            this.guna2TileButton22.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton22.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton22.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton22.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton22.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton22.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton22.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton22.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton22.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton22.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton22.Image = global::YamyProject.Properties.Resources.Save;
            this.guna2TileButton22.Location = new System.Drawing.Point(225, 11);
            this.guna2TileButton22.Margin = new System.Windows.Forms.Padding(4);
            this.guna2TileButton22.Name = "guna2TileButton22";
            this.guna2TileButton22.Size = new System.Drawing.Size(63, 62);
            this.guna2TileButton22.TabIndex = 20;
            this.guna2TileButton22.Text = "Save";
            this.guna2TileButton22.Click += new System.EventHandler(this.guna2TileButton22_Click);
            // 
            // guna2TileButton21
            // 
            this.guna2TileButton21.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton21.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton21.BorderRadius = 10;
            this.guna2TileButton21.BorderThickness = 2;
            this.guna2TileButton21.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton21.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton21.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton21.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton21.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton21.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton21.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton21.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton21.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton21.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton21.Image = global::YamyProject.Properties.Resources.deleteN;
            this.guna2TileButton21.Location = new System.Drawing.Point(288, 11);
            this.guna2TileButton21.Margin = new System.Windows.Forms.Padding(4);
            this.guna2TileButton21.Name = "guna2TileButton21";
            this.guna2TileButton21.Size = new System.Drawing.Size(63, 62);
            this.guna2TileButton21.TabIndex = 21;
            this.guna2TileButton21.Text = "Delete";
            this.guna2TileButton21.Click += new System.EventHandler(this.guna2TileButton21_Click);
            // 
            // guna2TileButton20
            // 
            this.guna2TileButton20.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton20.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton20.BorderRadius = 10;
            this.guna2TileButton20.BorderThickness = 2;
            this.guna2TileButton20.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton20.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton20.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton20.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton20.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton20.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton20.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton20.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton20.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton20.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton20.Image = global::YamyProject.Properties.Resources.copyN;
            this.guna2TileButton20.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2TileButton20.ImageOffset = new System.Drawing.Point(-10, 10);
            this.guna2TileButton20.Location = new System.Drawing.Point(354, 28);
            this.guna2TileButton20.Margin = new System.Windows.Forms.Padding(4);
            this.guna2TileButton20.Name = "guna2TileButton20";
            this.guna2TileButton20.Size = new System.Drawing.Size(116, 30);
            this.guna2TileButton20.TabIndex = 22;
            this.guna2TileButton20.Text = "Create a Copy";
            this.guna2TileButton20.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2TileButton20.TextOffset = new System.Drawing.Point(10, -12);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(602, 46);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(68, 16);
            this.checkBox3.TabIndex = 28;
            this.checkBox3.Text = "Email Later";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // guna2VSeparator11
            // 
            this.guna2VSeparator11.Location = new System.Drawing.Point(468, 7);
            this.guna2VSeparator11.Margin = new System.Windows.Forms.Padding(4);
            this.guna2VSeparator11.Name = "guna2VSeparator11";
            this.guna2VSeparator11.Size = new System.Drawing.Size(10, 61);
            this.guna2VSeparator11.TabIndex = 24;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox4.Location = new System.Drawing.Point(603, 18);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(64, 16);
            this.checkBox4.TabIndex = 27;
            this.checkBox4.Text = "Print Later";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // guna2TileButton18
            // 
            this.guna2TileButton18.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton18.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton18.BorderRadius = 10;
            this.guna2TileButton18.BorderThickness = 2;
            this.guna2TileButton18.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton18.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton18.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton18.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton18.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton18.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton18.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton18.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton18.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton18.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton18.Image = global::YamyProject.Properties.Resources.printN;
            this.guna2TileButton18.ImageSize = new System.Drawing.Size(30, 25);
            this.guna2TileButton18.Location = new System.Drawing.Point(477, 11);
            this.guna2TileButton18.Margin = new System.Windows.Forms.Padding(4);
            this.guna2TileButton18.Name = "guna2TileButton18";
            this.guna2TileButton18.Size = new System.Drawing.Size(54, 47);
            this.guna2TileButton18.TabIndex = 25;
            this.guna2TileButton18.Text = "Print";
            this.guna2TileButton18.Click += new System.EventHandler(this.guna2TileButton18_Click);
            // 
            // guna2TileButton17
            // 
            this.guna2TileButton17.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton17.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton17.BorderRadius = 10;
            this.guna2TileButton17.BorderThickness = 2;
            this.guna2TileButton17.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton17.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton17.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton17.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton17.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton17.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton17.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton17.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton17.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton17.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton17.Image = global::YamyProject.Properties.Resources.emailN;
            this.guna2TileButton17.ImageSize = new System.Drawing.Size(35, 30);
            this.guna2TileButton17.Location = new System.Drawing.Point(540, 11);
            this.guna2TileButton17.Margin = new System.Windows.Forms.Padding(4);
            this.guna2TileButton17.Name = "guna2TileButton17";
            this.guna2TileButton17.Size = new System.Drawing.Size(54, 47);
            this.guna2TileButton17.TabIndex = 26;
            this.guna2TileButton17.Text = "Email";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage4.Controls.Add(this.guna2TileButton27);
            this.tabPage4.Controls.Add(this.guna2TileButton28);
            this.tabPage4.Controls.Add(this.guna2TileButton29);
            this.tabPage4.Controls.Add(this.guna2VSeparator13);
            this.tabPage4.Controls.Add(this.guna2TileButton26);
            this.tabPage4.Controls.Add(this.guna2TileButton25);
            this.tabPage4.Controls.Add(this.guna2TileButton24);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(1129, 83);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Reports";
            // 
            // guna2TileButton27
            // 
            this.guna2TileButton27.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton27.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton27.BorderRadius = 10;
            this.guna2TileButton27.BorderThickness = 2;
            this.guna2TileButton27.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton27.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton27.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton27.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton27.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton27.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton27.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton27.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton27.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton27.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton27.Image = global::YamyProject.Properties.Resources._6;
            this.guna2TileButton27.Location = new System.Drawing.Point(449, 10);
            this.guna2TileButton27.Margin = new System.Windows.Forms.Padding(4);
            this.guna2TileButton27.Name = "guna2TileButton27";
            this.guna2TileButton27.Size = new System.Drawing.Size(109, 62);
            this.guna2TileButton27.TabIndex = 26;
            this.guna2TileButton27.Text = "Average Days To Pay Summary";
            // 
            // guna2TileButton28
            // 
            this.guna2TileButton28.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton28.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton28.BorderRadius = 10;
            this.guna2TileButton28.BorderThickness = 2;
            this.guna2TileButton28.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton28.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton28.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton28.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton28.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton28.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton28.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton28.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton28.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton28.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton28.Image = global::YamyProject.Properties.Resources._5;
            this.guna2TileButton28.Location = new System.Drawing.Point(340, 10);
            this.guna2TileButton28.Margin = new System.Windows.Forms.Padding(4);
            this.guna2TileButton28.Name = "guna2TileButton28";
            this.guna2TileButton28.Size = new System.Drawing.Size(108, 62);
            this.guna2TileButton28.TabIndex = 25;
            this.guna2TileButton28.Text = "Sales By Customer Details";
            // 
            // guna2TileButton29
            // 
            this.guna2TileButton29.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton29.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton29.BorderRadius = 10;
            this.guna2TileButton29.BorderThickness = 2;
            this.guna2TileButton29.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton29.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton29.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton29.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton29.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton29.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton29.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton29.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton29.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton29.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton29.Image = global::YamyProject.Properties.Resources._4;
            this.guna2TileButton29.Location = new System.Drawing.Point(259, 10);
            this.guna2TileButton29.Margin = new System.Windows.Forms.Padding(4);
            this.guna2TileButton29.Name = "guna2TileButton29";
            this.guna2TileButton29.Size = new System.Drawing.Size(81, 62);
            this.guna2TileButton29.TabIndex = 24;
            this.guna2TileButton29.Text = "View Open Invoice";
            // 
            // guna2VSeparator13
            // 
            this.guna2VSeparator13.Location = new System.Drawing.Point(249, 10);
            this.guna2VSeparator13.Margin = new System.Windows.Forms.Padding(4);
            this.guna2VSeparator13.Name = "guna2VSeparator13";
            this.guna2VSeparator13.Size = new System.Drawing.Size(10, 61);
            this.guna2VSeparator13.TabIndex = 23;
            // 
            // guna2TileButton26
            // 
            this.guna2TileButton26.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton26.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton26.BorderRadius = 10;
            this.guna2TileButton26.BorderThickness = 2;
            this.guna2TileButton26.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton26.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton26.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton26.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton26.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton26.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton26.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton26.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton26.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton26.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton26.Image = global::YamyProject.Properties.Resources._3;
            this.guna2TileButton26.Location = new System.Drawing.Point(158, 10);
            this.guna2TileButton26.Margin = new System.Windows.Forms.Padding(4);
            this.guna2TileButton26.Name = "guna2TileButton26";
            this.guna2TileButton26.Size = new System.Drawing.Size(92, 62);
            this.guna2TileButton26.TabIndex = 22;
            this.guna2TileButton26.Text = "Transaction Journal";
            // 
            // guna2TileButton25
            // 
            this.guna2TileButton25.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton25.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton25.BorderRadius = 10;
            this.guna2TileButton25.BorderThickness = 2;
            this.guna2TileButton25.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton25.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton25.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton25.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton25.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton25.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton25.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton25.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton25.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton25.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton25.Image = global::YamyProject.Properties.Resources._2;
            this.guna2TileButton25.Location = new System.Drawing.Point(74, 10);
            this.guna2TileButton25.Margin = new System.Windows.Forms.Padding(4);
            this.guna2TileButton25.Name = "guna2TileButton25";
            this.guna2TileButton25.Size = new System.Drawing.Size(84, 62);
            this.guna2TileButton25.TabIndex = 21;
            this.guna2TileButton25.Text = "Transaction History";
            // 
            // guna2TileButton24
            // 
            this.guna2TileButton24.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton24.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton24.BorderRadius = 10;
            this.guna2TileButton24.BorderThickness = 2;
            this.guna2TileButton24.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton24.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton24.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton24.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton24.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton24.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton24.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton24.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton24.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton24.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton24.Image = global::YamyProject.Properties.Resources._1;
            this.guna2TileButton24.Location = new System.Drawing.Point(4, 4);
            this.guna2TileButton24.Margin = new System.Windows.Forms.Padding(4);
            this.guna2TileButton24.Name = "guna2TileButton24";
            this.guna2TileButton24.Size = new System.Drawing.Size(70, 67);
            this.guna2TileButton24.TabIndex = 20;
            this.guna2TileButton24.Text = "Quick Report";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.txtCreditAmount);
            this.panel1.Controls.Add(this.txtDebitAmount);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 530);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1137, 44);
            this.panel1.TabIndex = 240;
            // 
            // txtCreditAmount
            // 
            this.txtCreditAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCreditAmount.BackColor = System.Drawing.Color.Transparent;
            this.txtCreditAmount.BorderRadius = 7;
            this.txtCreditAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCreditAmount.DefaultText = "";
            this.txtCreditAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCreditAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCreditAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCreditAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCreditAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCreditAmount.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditAmount.ForeColor = System.Drawing.Color.Black;
            this.txtCreditAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCreditAmount.Location = new System.Drawing.Point(656, 11);
            this.txtCreditAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCreditAmount.Name = "txtCreditAmount";
            this.txtCreditAmount.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtCreditAmount.PlaceholderText = "Cr Amount";
            this.txtCreditAmount.SelectedText = "";
            this.txtCreditAmount.ShortcutsEnabled = false;
            this.txtCreditAmount.Size = new System.Drawing.Size(123, 26);
            this.txtCreditAmount.TabIndex = 30;
            // 
            // txtDebitAmount
            // 
            this.txtDebitAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDebitAmount.BackColor = System.Drawing.Color.Transparent;
            this.txtDebitAmount.BorderRadius = 7;
            this.txtDebitAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDebitAmount.DefaultText = "";
            this.txtDebitAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDebitAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDebitAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDebitAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDebitAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDebitAmount.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebitAmount.ForeColor = System.Drawing.Color.Black;
            this.txtDebitAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDebitAmount.Location = new System.Drawing.Point(525, 11);
            this.txtDebitAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDebitAmount.Name = "txtDebitAmount";
            this.txtDebitAmount.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtDebitAmount.PlaceholderText = "Dr Amount";
            this.txtDebitAmount.SelectedText = "";
            this.txtDebitAmount.ShortcutsEnabled = false;
            this.txtDebitAmount.Size = new System.Drawing.Size(123, 26);
            this.txtDebitAmount.TabIndex = 29;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.btnClose.BorderRadius = 5;
            this.btnClose.BorderThickness = 1;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.btnClose.Location = new System.Drawing.Point(1028, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 29);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.btnSave.BorderRadius = 5;
            this.btnSave.BorderThickness = 3;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(925, 8);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 29);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderThickness = 0;
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.White;
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(3, 37);
            this.guna2GroupBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(1137, 537);
            this.guna2GroupBox1.TabIndex = 241;
            this.guna2GroupBox1.TextOffset = new System.Drawing.Point(0, -5);
            // 
            // headerUC1
            // 
            this.headerUC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(41)))), ((int)(((byte)(83)))));
            this.headerUC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerUC1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerUC1.FormText = "Bank Transaction";
            this.headerUC1.HeaderText = "Bank Transaction";
            this.headerUC1.Location = new System.Drawing.Point(0, 0);
            this.headerUC1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.headerUC1.Name = "headerUC1";
            this.headerUC1.Size = new System.Drawing.Size(1143, 30);
            this.headerUC1.TabIndex = 250;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 574);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1137, 2);
            this.panel5.TabIndex = 244;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1140, 37);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(3, 539);
            this.panel4.TabIndex = 243;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 37);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 539);
            this.panel3.TabIndex = 242;
            // 
            // cmbBankName
            // 
            this.cmbBankName.BackColor = System.Drawing.Color.Transparent;
            this.cmbBankName.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.cmbBankName.BorderRadius = 3;
            this.cmbBankName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBankName.FillColor = System.Drawing.Color.WhiteSmoke;
            this.cmbBankName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbBankName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbBankName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbBankName.ItemHeight = 18;
            this.cmbBankName.Location = new System.Drawing.Point(734, 38);
            this.cmbBankName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbBankName.Name = "cmbBankName";
            this.cmbBankName.Size = new System.Drawing.Size(245, 24);
            this.cmbBankName.TabIndex = 30;
            // 
            // lblBankName
            // 
            this.lblBankName.BackColor = System.Drawing.Color.Transparent;
            this.lblBankName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.lblBankName.Location = new System.Drawing.Point(734, 13);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(96, 26);
            this.lblBankName.TabIndex = 31;
            this.lblBankName.Text = "Bank Name";
            this.lblBankName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBankTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 576);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.headerUC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBankTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBankTransaction";
            this.Load += new System.EventHandler(this.frmBankTransaction_Load);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJV)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtJvId;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2Button btnPrevious;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator12;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton23;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton22;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton21;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton20;
        private System.Windows.Forms.CheckBox checkBox3;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator11;
        private System.Windows.Forms.CheckBox checkBox4;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton18;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton17;
        private System.Windows.Forms.TabPage tabPage4;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton27;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton28;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton29;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator13;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton26;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton25;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton24;
        private Guna.UI2.WinForms.Guna2DataGridView dgvJV;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2TextBox txtCreditAmount;
        private Guna.UI2.WinForms.Guna2TextBox txtDebitAmount;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private HeaderUC headerUC1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button btn_Import;
        private System.Windows.Forms.DataGridViewTextBoxColumn account_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private DAL.CalendarColumn dated;
        private System.Windows.Forms.DataGridViewComboBoxColumn bank_ac;
        private System.Windows.Forms.DataGridViewComboBoxColumn account_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn balance;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private Guna.UI2.WinForms.Guna2ComboBox cmbBankName;
        private System.Windows.Forms.Label lblBankName;
    }
}