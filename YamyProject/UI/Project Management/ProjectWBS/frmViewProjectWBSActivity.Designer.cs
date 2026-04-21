namespace YamyProject.UI.Project_Management.ProjectWBS
{
    partial class frmViewProjectWBSActivity
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
            this.headerUC1 = new YamyProject.HeaderUC();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelEntry = new System.Windows.Forms.Panel();
            this.txtWBSLevel = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnNew = new Guna.UI2.WinForms.Guna2Button();
            this.txtID = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.cmbParentWBS = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblParentWBS = new System.Windows.Forms.Label();
            this.txtWBSName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblWBSName = new System.Windows.Forms.Label();
            this.txtWBSCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblWBSCode = new System.Windows.Forms.Label();
            this.lblEntryTitle = new System.Windows.Forms.Label();
            this.txtEngineer = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvWBS = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParentWBSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelEntry.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWBS)).BeginInit();
            this.SuspendLayout();
            // 
            // headerUC1
            // 
            this.headerUC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.headerUC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerUC1.FormText = "";
            this.headerUC1.HeaderText = "";
            this.headerUC1.Location = new System.Drawing.Point(0, 0);
            this.headerUC1.Margin = new System.Windows.Forms.Padding(2);
            this.headerUC1.Name = "headerUC1";
            this.headerUC1.Size = new System.Drawing.Size(1281, 30);
            this.headerUC1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1281, 570);
            this.panel1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvWBS);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(422, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(859, 570);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelEntry);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(422, 570);
            this.panel2.TabIndex = 0;
            // 
            // panelEntry
            // 
            this.panelEntry.BackColor = System.Drawing.Color.White;
            this.panelEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEntry.Controls.Add(this.label3);
            this.panelEntry.Controls.Add(this.txtDescription);
            this.panelEntry.Controls.Add(this.label2);
            this.panelEntry.Controls.Add(this.label1);
            this.panelEntry.Controls.Add(this.dtpFrom);
            this.panelEntry.Controls.Add(this.dtpTo);
            this.panelEntry.Controls.Add(this.txtEngineer);
            this.panelEntry.Controls.Add(this.txtWBSLevel);
            this.panelEntry.Controls.Add(this.panelButtons);
            this.panelEntry.Controls.Add(this.txtID);
            this.panelEntry.Controls.Add(this.chkIsActive);
            this.panelEntry.Controls.Add(this.lblDescription);
            this.panelEntry.Controls.Add(this.lblLevel);
            this.panelEntry.Controls.Add(this.cmbParentWBS);
            this.panelEntry.Controls.Add(this.lblParentWBS);
            this.panelEntry.Controls.Add(this.txtWBSName);
            this.panelEntry.Controls.Add(this.lblWBSName);
            this.panelEntry.Controls.Add(this.txtWBSCode);
            this.panelEntry.Controls.Add(this.lblWBSCode);
            this.panelEntry.Controls.Add(this.lblEntryTitle);
            this.panelEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEntry.Location = new System.Drawing.Point(0, 0);
            this.panelEntry.Name = "panelEntry";
            this.panelEntry.Padding = new System.Windows.Forms.Padding(10);
            this.panelEntry.Size = new System.Drawing.Size(422, 570);
            this.panelEntry.TabIndex = 1;
            // 
            // txtWBSLevel
            // 
            this.txtWBSLevel.BorderRadius = 5;
            this.txtWBSLevel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWBSLevel.DefaultText = "";
            this.txtWBSLevel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtWBSLevel.Location = new System.Drawing.Point(116, 171);
            this.txtWBSLevel.Name = "txtWBSLevel";
            this.txtWBSLevel.PlaceholderText = "";
            this.txtWBSLevel.SelectedText = "";
            this.txtWBSLevel.Size = new System.Drawing.Size(266, 25);
            this.txtWBSLevel.TabIndex = 14;
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.Controls.Add(this.btnClear);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnUpdate);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnNew);
            this.panelButtons.Location = new System.Drawing.Point(13, 486);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(394, 67);
            this.panelButtons.TabIndex = 12;
            // 
            // btnClear
            // 
            this.btnClear.BorderRadius = 5;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(307, 17);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(68, 34);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BorderRadius = 5;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(231, 17);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(68, 34);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BorderRadius = 5;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(155, 17);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(68, 34);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(79, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 34);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.BorderRadius = 5;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(3, 17);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(68, 34);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtID
            // 
            this.txtID.BorderRadius = 5;
            this.txtID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtID.DefaultText = "";
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtID.Location = new System.Drawing.Point(332, 15);
            this.txtID.Name = "txtID";
            this.txtID.PlaceholderText = "";
            this.txtID.ReadOnly = true;
            this.txtID.SelectedText = "";
            this.txtID.Size = new System.Drawing.Size(50, 20);
            this.txtID.TabIndex = 13;
            this.txtID.Visible = false;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Location = new System.Drawing.Point(116, 413);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(74, 21);
            this.chkIsActive.TabIndex = 11;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(13, 215);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(62, 15);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "Start From";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.Location = new System.Drawing.Point(13, 171);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(34, 15);
            this.lblLevel.TabIndex = 7;
            this.lblLevel.Text = "Level";
            // 
            // cmbParentWBS
            // 
            this.cmbParentWBS.BackColor = System.Drawing.Color.Transparent;
            this.cmbParentWBS.BorderRadius = 5;
            this.cmbParentWBS.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbParentWBS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentWBS.FocusedColor = System.Drawing.Color.Empty;
            this.cmbParentWBS.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbParentWBS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbParentWBS.FormattingEnabled = true;
            this.cmbParentWBS.ItemHeight = 22;
            this.cmbParentWBS.Location = new System.Drawing.Point(116, 126);
            this.cmbParentWBS.Name = "cmbParentWBS";
            this.cmbParentWBS.Size = new System.Drawing.Size(266, 28);
            this.cmbParentWBS.TabIndex = 6;
            // 
            // lblParentWBS
            // 
            this.lblParentWBS.AutoSize = true;
            this.lblParentWBS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParentWBS.Location = new System.Drawing.Point(13, 129);
            this.lblParentWBS.Name = "lblParentWBS";
            this.lblParentWBS.Size = new System.Drawing.Size(68, 15);
            this.lblParentWBS.TabIndex = 5;
            this.lblParentWBS.Text = "Parent WBS";
            // 
            // txtWBSName
            // 
            this.txtWBSName.BorderRadius = 5;
            this.txtWBSName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWBSName.DefaultText = "";
            this.txtWBSName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtWBSName.Location = new System.Drawing.Point(116, 84);
            this.txtWBSName.Name = "txtWBSName";
            this.txtWBSName.PlaceholderText = "";
            this.txtWBSName.SelectedText = "";
            this.txtWBSName.Size = new System.Drawing.Size(266, 25);
            this.txtWBSName.TabIndex = 4;
            // 
            // lblWBSName
            // 
            this.lblWBSName.AutoSize = true;
            this.lblWBSName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWBSName.Location = new System.Drawing.Point(13, 87);
            this.lblWBSName.Name = "lblWBSName";
            this.lblWBSName.Size = new System.Drawing.Size(66, 15);
            this.lblWBSName.TabIndex = 3;
            this.lblWBSName.Text = "WBS Name";
            // 
            // txtWBSCode
            // 
            this.txtWBSCode.BorderRadius = 5;
            this.txtWBSCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWBSCode.DefaultText = "";
            this.txtWBSCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtWBSCode.Location = new System.Drawing.Point(116, 42);
            this.txtWBSCode.Name = "txtWBSCode";
            this.txtWBSCode.PlaceholderText = "";
            this.txtWBSCode.SelectedText = "";
            this.txtWBSCode.Size = new System.Drawing.Size(266, 25);
            this.txtWBSCode.TabIndex = 2;
            // 
            // lblWBSCode
            // 
            this.lblWBSCode.AutoSize = true;
            this.lblWBSCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWBSCode.Location = new System.Drawing.Point(13, 45);
            this.lblWBSCode.Name = "lblWBSCode";
            this.lblWBSCode.Size = new System.Drawing.Size(62, 15);
            this.lblWBSCode.TabIndex = 1;
            this.lblWBSCode.Text = "WBS Code";
            // 
            // lblEntryTitle
            // 
            this.lblEntryTitle.AutoSize = true;
            this.lblEntryTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntryTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblEntryTitle.Location = new System.Drawing.Point(13, 12);
            this.lblEntryTitle.Name = "lblEntryTitle";
            this.lblEntryTitle.Size = new System.Drawing.Size(67, 17);
            this.lblEntryTitle.TabIndex = 0;
            this.lblEntryTitle.Text = "WBS Entry";
            // 
            // txtEngineer
            // 
            this.txtEngineer.BorderRadius = 5;
            this.txtEngineer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEngineer.DefaultText = "";
            this.txtEngineer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEngineer.Location = new System.Drawing.Point(116, 250);
            this.txtEngineer.Name = "txtEngineer";
            this.txtEngineer.PlaceholderText = "";
            this.txtEngineer.SelectedText = "";
            this.txtEngineer.Size = new System.Drawing.Size(266, 25);
            this.txtEngineer.TabIndex = 15;
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtpTo.Enabled = false;
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(274, 209);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(2);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(108, 23);
            this.dtpTo.TabIndex = 67;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtpFrom.Enabled = false;
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(116, 209);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(108, 23);
            this.dtpFrom.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(240, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 69;
            this.label1.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 70;
            this.label2.Text = "Engineer";
            // 
            // txtDescription
            // 
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.Location = new System.Drawing.Point(116, 290);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(266, 97);
            this.txtDescription.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 72;
            this.label3.Text = "Description";
            // 
            // dgvWBS
            // 
            this.dgvWBS.AllowUserToAddRows = false;
            this.dgvWBS.AllowUserToDeleteRows = false;
            this.dgvWBS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWBS.BackgroundColor = System.Drawing.Color.White;
            this.dgvWBS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvWBS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWBS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colProjectID,
            this.colParentWBSID,
            this.colCode,
            this.colName,
            this.colParentName,
            this.colLevel,
            this.colStart,
            this.colEnd,
            this.colIsActive});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWBS.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWBS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWBS.Location = new System.Drawing.Point(0, 0);
            this.dgvWBS.MultiSelect = false;
            this.dgvWBS.Name = "dgvWBS";
            this.dgvWBS.ReadOnly = true;
            this.dgvWBS.RowHeadersVisible = false;
            this.dgvWBS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWBS.Size = new System.Drawing.Size(859, 570);
            this.dgvWBS.TabIndex = 1;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colProjectID
            // 
            this.colProjectID.HeaderText = "Project ID";
            this.colProjectID.Name = "colProjectID";
            this.colProjectID.ReadOnly = true;
            this.colProjectID.Visible = false;
            // 
            // colParentWBSID
            // 
            this.colParentWBSID.HeaderText = "Parent WBS ID";
            this.colParentWBSID.Name = "colParentWBSID";
            this.colParentWBSID.ReadOnly = true;
            this.colParentWBSID.Visible = false;
            // 
            // colCode
            // 
            this.colCode.FillWeight = 35.51454F;
            this.colCode.HeaderText = "WBS Code";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.FillWeight = 62.15044F;
            this.colName.HeaderText = "WBS Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colParentName
            // 
            this.colParentName.FillWeight = 53.27181F;
            this.colParentName.HeaderText = "Parent WBS";
            this.colParentName.Name = "colParentName";
            this.colParentName.ReadOnly = true;
            // 
            // colLevel
            // 
            this.colLevel.FillWeight = 22.19658F;
            this.colLevel.HeaderText = "Level";
            this.colLevel.Name = "colLevel";
            this.colLevel.ReadOnly = true;
            // 
            // colStart
            // 
            this.colStart.FillWeight = 40F;
            this.colStart.HeaderText = "Start";
            this.colStart.Name = "colStart";
            this.colStart.ReadOnly = true;
            // 
            // colEnd
            // 
            this.colEnd.FillWeight = 40F;
            this.colEnd.HeaderText = "End";
            this.colEnd.Name = "colEnd";
            this.colEnd.ReadOnly = true;
            // 
            // colIsActive
            // 
            this.colIsActive.FillWeight = 26.6359F;
            this.colIsActive.HeaderText = "Active";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.ReadOnly = true;
            // 
            // frmViewProjectWBSActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.headerUC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmViewProjectWBSActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project WBS Activity";
            this.Load += new System.EventHandler(this.frmViewProjectWBSActivity_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelEntry.ResumeLayout(false);
            this.panelEntry.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWBS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HeaderUC headerUC1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelEntry;
        private System.Windows.Forms.Panel panelButtons;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnNew;
        private Guna.UI2.WinForms.Guna2TextBox txtID;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblLevel;
        private Guna.UI2.WinForms.Guna2ComboBox cmbParentWBS;
        private System.Windows.Forms.Label lblParentWBS;
        private Guna.UI2.WinForms.Guna2TextBox txtWBSName;
        private System.Windows.Forms.Label lblWBSName;
        private Guna.UI2.WinForms.Guna2TextBox txtWBSCode;
        private System.Windows.Forms.Label lblWBSCode;
        private System.Windows.Forms.Label lblEntryTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtWBSLevel;
        private Guna.UI2.WinForms.Guna2TextBox txtEngineer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private System.Windows.Forms.DataGridView dgvWBS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParentWBSID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsActive;
    }
}