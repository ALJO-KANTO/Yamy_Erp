namespace YamyProject.UI.Construction.DailySiteWork
{
    partial class frmProjectDailySiteWork
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtInv = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbProjectName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbProjectSite = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTenderName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSupervisor = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDailyWork = new Guna.UI2.WinForms.Guna2DataGridView();
            this.sr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BOQItem = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoqQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrevDoneQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TodayQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CumQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalanceQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Progress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblOverallProgress = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTodayQty = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.lbl_boq = new System.Windows.Forms.Label();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headerUC1 = new YamyProject.HeaderUC();
            this.guna2TileButton25 = new Guna.UI2.WinForms.Guna2TileButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyWork)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtInv
            // 
            this.dtInv.BackColor = System.Drawing.Color.Gainsboro;
            this.dtInv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtInv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtInv.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInv.Location = new System.Drawing.Point(13, 35);
            this.dtInv.Margin = new System.Windows.Forms.Padding(2);
            this.dtInv.Name = "dtInv";
            this.dtInv.Size = new System.Drawing.Size(110, 23);
            this.dtInv.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.label11.Location = new System.Drawing.Point(9, 15);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 16);
            this.label11.TabIndex = 7;
            this.label11.Text = "Date";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(169, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 29);
            this.label1.TabIndex = 19;
            this.label1.Text = "Project Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbProjectName
            // 
            this.cmbProjectName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbProjectName.BackColor = System.Drawing.Color.Transparent;
            this.cmbProjectName.BorderRadius = 5;
            this.cmbProjectName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProjectName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjectName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbProjectName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbProjectName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProjectName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbProjectName.ItemHeight = 18;
            this.cmbProjectName.Location = new System.Drawing.Point(172, 35);
            this.cmbProjectName.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProjectName.Name = "cmbProjectName";
            this.cmbProjectName.Size = new System.Drawing.Size(369, 24);
            this.cmbProjectName.TabIndex = 18;
            this.cmbProjectName.SelectedIndexChanged += new System.EventHandler(this.cmbProjectName_SelectedIndexChanged);
            // 
            // cmbProjectSite
            // 
            this.cmbProjectSite.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbProjectSite.BackColor = System.Drawing.Color.Transparent;
            this.cmbProjectSite.BorderRadius = 5;
            this.cmbProjectSite.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProjectSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjectSite.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbProjectSite.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbProjectSite.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProjectSite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbProjectSite.ItemHeight = 18;
            this.cmbProjectSite.Location = new System.Drawing.Point(582, 35);
            this.cmbProjectSite.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProjectSite.Name = "cmbProjectSite";
            this.cmbProjectSite.Size = new System.Drawing.Size(319, 24);
            this.cmbProjectSite.TabIndex = 149;
            this.cmbProjectSite.SelectedIndexChanged += new System.EventHandler(this.cmbProjectSite_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.label12.Location = new System.Drawing.Point(579, 9);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(135, 29);
            this.label12.TabIndex = 148;
            this.label12.Text = "Project Site";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.guna2TileButton25);
            this.panel1.Controls.Add(this.txtTenderName);
            this.panel1.Controls.Add(this.txtSupervisor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cmbProjectSite);
            this.panel1.Controls.Add(this.dtInv);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cmbProjectName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1116, 99);
            this.panel1.TabIndex = 151;
            // 
            // txtTenderName
            // 
            this.txtTenderName.BorderRadius = 5;
            this.txtTenderName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenderName.DefaultText = "";
            this.txtTenderName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenderName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenderName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenderName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenderName.Enabled = false;
            this.txtTenderName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenderName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenderName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenderName.Location = new System.Drawing.Point(172, 68);
            this.txtTenderName.Name = "txtTenderName";
            this.txtTenderName.PlaceholderText = "";
            this.txtTenderName.ReadOnly = true;
            this.txtTenderName.SelectedText = "";
            this.txtTenderName.Size = new System.Drawing.Size(369, 25);
            this.txtTenderName.TabIndex = 151;
            // 
            // txtSupervisor
            // 
            this.txtSupervisor.BorderRadius = 5;
            this.txtSupervisor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSupervisor.DefaultText = "";
            this.txtSupervisor.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSupervisor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSupervisor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSupervisor.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSupervisor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSupervisor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSupervisor.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSupervisor.Location = new System.Drawing.Point(715, 68);
            this.txtSupervisor.Name = "txtSupervisor";
            this.txtSupervisor.PlaceholderText = "";
            this.txtSupervisor.SelectedText = "";
            this.txtSupervisor.Size = new System.Drawing.Size(389, 25);
            this.txtSupervisor.TabIndex = 150;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.label2.Location = new System.Drawing.Point(129, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 152;
            this.label2.Text = "Tender";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.label3.Location = new System.Drawing.Point(652, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 153;
            this.label3.Text = "Supervisor";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvDailyWork);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1116, 432);
            this.panel2.TabIndex = 152;
            // 
            // dgvDailyWork
            // 
            this.dgvDailyWork.AllowUserToResizeColumns = false;
            this.dgvDailyWork.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dgvDailyWork.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDailyWork.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvDailyWork.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDailyWork.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvDailyWork.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDailyWork.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDailyWork.ColumnHeadersHeight = 18;
            this.dgvDailyWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDailyWork.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sr,
            this.BOQItem,
            this.unit,
            this.BoqQty,
            this.PrevDoneQty,
            this.TodayQty,
            this.CumQty,
            this.BalanceQty,
            this.Progress,
            this.Remarks});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDailyWork.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDailyWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDailyWork.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDailyWork.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDailyWork.Location = new System.Drawing.Point(0, 0);
            this.dgvDailyWork.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvDailyWork.MultiSelect = false;
            this.dgvDailyWork.Name = "dgvDailyWork";
            this.dgvDailyWork.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDailyWork.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.dgvDailyWork.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDailyWork.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDailyWork.RowTemplate.Height = 25;
            this.dgvDailyWork.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDailyWork.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDailyWork.Size = new System.Drawing.Size(1116, 432);
            this.dgvDailyWork.TabIndex = 8;
            this.dgvDailyWork.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDailyWork.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dgvDailyWork.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDailyWork.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDailyWork.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDailyWork.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDailyWork.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDailyWork.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Silver;
            this.dgvDailyWork.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDailyWork.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.dgvDailyWork.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDailyWork.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDailyWork.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvDailyWork.ThemeStyle.ReadOnly = false;
            this.dgvDailyWork.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDailyWork.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvDailyWork.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDailyWork.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDailyWork.ThemeStyle.RowsStyle.Height = 25;
            this.dgvDailyWork.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDailyWork.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDailyWork.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDailyWork_CellEndEdit);
            this.dgvDailyWork.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDailyWork_CellValueChanged);
            this.dgvDailyWork.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDailyWork_EditingControlShowing);
            // 
            // sr
            // 
            this.sr.HeaderText = "Sr";
            this.sr.Name = "sr";
            this.sr.ReadOnly = true;
            // 
            // BOQItem
            // 
            this.BOQItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BOQItem.HeaderText = "BOQ Item";
            this.BOQItem.Name = "BOQItem";
            // 
            // unit
            // 
            this.unit.HeaderText = "Unit";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BoqQty
            // 
            this.BoqQty.HeaderText = "BOQ Qty";
            this.BoqQty.Name = "BoqQty";
            this.BoqQty.ReadOnly = true;
            this.BoqQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BoqQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PrevDoneQty
            // 
            this.PrevDoneQty.HeaderText = "Prev Done Qty";
            this.PrevDoneQty.Name = "PrevDoneQty";
            this.PrevDoneQty.ReadOnly = true;
            this.PrevDoneQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PrevDoneQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TodayQty
            // 
            this.TodayQty.HeaderText = "Today Qty";
            this.TodayQty.Name = "TodayQty";
            this.TodayQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TodayQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CumQty
            // 
            this.CumQty.HeaderText = "Cum Qty";
            this.CumQty.Name = "CumQty";
            this.CumQty.ReadOnly = true;
            this.CumQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CumQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BalanceQty
            // 
            this.BalanceQty.HeaderText = "Balance Qty";
            this.BalanceQty.Name = "BalanceQty";
            this.BalanceQty.ReadOnly = true;
            this.BalanceQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BalanceQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Progress
            // 
            this.Progress.HeaderText = "Progress %";
            this.Progress.Name = "Progress";
            this.Progress.ReadOnly = true;
            this.Progress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Progress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Remarks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Remarks.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblOverallProgress);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lblTodayQty);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.lbl_boq);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 529);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1116, 33);
            this.panel3.TabIndex = 153;
            // 
            // lblOverallProgress
            // 
            this.lblOverallProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblOverallProgress.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverallProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.lblOverallProgress.Location = new System.Drawing.Point(556, 6);
            this.lblOverallProgress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOverallProgress.Name = "lblOverallProgress";
            this.lblOverallProgress.Size = new System.Drawing.Size(83, 20);
            this.lblOverallProgress.TabIndex = 136;
            this.lblOverallProgress.Text = "0";
            this.lblOverallProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.label5.Location = new System.Drawing.Point(9, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 135;
            this.label5.Text = "Total Today Qty";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.label4.Location = new System.Drawing.Point(455, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 134;
            this.label4.Text = "Overall Progress";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTodayQty
            // 
            this.lblTodayQty.BackColor = System.Drawing.Color.Transparent;
            this.lblTodayQty.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.lblTodayQty.Location = new System.Drawing.Point(96, 6);
            this.lblTodayQty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTodayQty.Name = "lblTodayQty";
            this.lblTodayQty.Size = new System.Drawing.Size(83, 20);
            this.lblTodayQty.TabIndex = 133;
            this.lblTodayQty.Text = "0";
            this.lblTodayQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.btnClose.BorderRadius = 5;
            this.btnClose.BorderThickness = 1;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.btnClose.Location = new System.Drawing.Point(976, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(137, 27);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            // 
            // lbl_boq
            // 
            this.lbl_boq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_boq.BackColor = System.Drawing.Color.Transparent;
            this.lbl_boq.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbl_boq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.lbl_boq.Location = new System.Drawing.Point(-235, 6);
            this.lbl_boq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_boq.Name = "lbl_boq";
            this.lbl_boq.Size = new System.Drawing.Size(73, 20);
            this.lbl_boq.TabIndex = 131;
            this.lbl_boq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.btnSave.BorderRadius = 5;
            this.btnSave.BorderThickness = 3;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(834, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 27);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Sr.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 45;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "unit";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "BOQ Qty";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Prev Done Qty";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Today Qty";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Cum. Qty";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Balance Qty";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Progress %";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Remarks";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // headerUC1
            // 
            this.headerUC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(41)))), ((int)(((byte)(83)))));
            this.headerUC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerUC1.FormText = "";
            this.headerUC1.HeaderText = "";
            this.headerUC1.Location = new System.Drawing.Point(0, 0);
            this.headerUC1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.headerUC1.Name = "headerUC1";
            this.headerUC1.Size = new System.Drawing.Size(1116, 31);
            this.headerUC1.TabIndex = 1;
            // 
            // guna2TileButton25
            // 
            this.guna2TileButton25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.guna2TileButton25.Location = new System.Drawing.Point(1032, 12);
            this.guna2TileButton25.Name = "guna2TileButton25";
            this.guna2TileButton25.Size = new System.Drawing.Size(72, 47);
            this.guna2TileButton25.TabIndex = 154;
            this.guna2TileButton25.Text = "Transaction History";
            this.guna2TileButton25.Click += new System.EventHandler(this.guna2TileButton25_Click);
            // 
            // frmProjectDailySiteWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 562);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.headerUC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProjectDailySiteWork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Daily Site Work";
            this.Load += new System.EventHandler(this.DailySiteWork_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyWork)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HeaderUC headerUC1;
        private System.Windows.Forms.DateTimePicker dtInv;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbProjectName;
        private Guna.UI2.WinForms.Guna2ComboBox cmbProjectSite;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label lbl_boq;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2TextBox txtTenderName;
        private Guna.UI2.WinForms.Guna2TextBox txtSupervisor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOverallProgress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTodayQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDailyWork;
        private System.Windows.Forms.DataGridViewTextBoxColumn sr;
        private System.Windows.Forms.DataGridViewComboBoxColumn BOQItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoqQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrevDoneQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TodayQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn CumQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalanceQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Progress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton25;
    }
}