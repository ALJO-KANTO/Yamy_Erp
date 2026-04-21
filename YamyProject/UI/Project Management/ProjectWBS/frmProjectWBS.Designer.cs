namespace YamyProject.UI.Project_Management.ProjectWBS
{
    partial class frmProjectWBS
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnLoad = new Guna.UI2.WinForms.Guna2Button();
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelEntry = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnNew = new Guna.UI2.WinForms.Guna2Button();
            this.txtID = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.nudLevel = new System.Windows.Forms.NumericUpDown();
            this.lblLevel = new System.Windows.Forms.Label();
            this.cmbParentWBS = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblParentWBS = new System.Windows.Forms.Label();
            this.txtWBSName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblWBSName = new System.Windows.Forms.Label();
            this.txtWBSCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblWBSCode = new System.Windows.Forms.Label();
            this.lblEntryTitle = new System.Windows.Forms.Label();
            this.panelList = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tvWBS = new System.Windows.Forms.TreeView();
            this.dgvWBS = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParentWBSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblTreeTitle = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelEntry.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).BeginInit();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.headerUC1.Size = new System.Drawing.Size(1291, 30);
            this.headerUC1.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.guna2TextBox1);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.guna2ComboBox1);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.btnSearch);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.lblSearch);
            this.panelTop.Controls.Add(this.btnLoad);
            this.panelTop.Controls.Add(this.cmbProject);
            this.panelTop.Controls.Add(this.lblProject);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 30);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1291, 132);
            this.panelTop.TabIndex = 0;
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2TextBox1.BorderRadius = 5;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2TextBox1.Location = new System.Drawing.Point(566, 56);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(357, 25);
            this.guna2TextBox1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(507, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Zone";
            // 
            // guna2ComboBox1
            // 
            this.guna2ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox1.BorderRadius = 5;
            this.guna2ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox1.FocusedColor = System.Drawing.Color.Empty;
            this.guna2ComboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBox1.FormattingEnabled = true;
            this.guna2ComboBox1.ItemHeight = 22;
            this.guna2ComboBox1.Location = new System.Drawing.Point(98, 53);
            this.guna2ComboBox1.Name = "guna2ComboBox1";
            this.guna2ComboBox1.Size = new System.Drawing.Size(359, 28);
            this.guna2ComboBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Site";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BorderRadius = 5;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1190, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(88, 30);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BorderRadius = 5;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1097, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 30);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderRadius = 5;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(831, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(260, 25);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(772, 18);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(47, 17);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "Search";
            // 
            // btnLoad
            // 
            this.btnLoad.BorderRadius = 5;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(463, 14);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(88, 30);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cmbProject
            // 
            this.cmbProject.BackColor = System.Drawing.Color.Transparent;
            this.cmbProject.BorderRadius = 5;
            this.cmbProject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FocusedColor = System.Drawing.Color.Empty;
            this.cmbProject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.ItemHeight = 22;
            this.cmbProject.Location = new System.Drawing.Point(98, 15);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(359, 28);
            this.cmbProject.TabIndex = 1;
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProject.Location = new System.Drawing.Point(18, 18);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(48, 17);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "Project";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelEntry);
            this.splitContainer1.Panel1MinSize = 380;
            this.splitContainer1.Size = new System.Drawing.Size(1291, 643);
            this.splitContainer1.SplitterDistance = 410;
            this.splitContainer1.TabIndex = 1;
            // 
            // panelEntry
            // 
            this.panelEntry.BackColor = System.Drawing.Color.White;
            this.panelEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEntry.Controls.Add(this.panelButtons);
            this.panelEntry.Controls.Add(this.txtID);
            this.panelEntry.Controls.Add(this.chkIsActive);
            this.panelEntry.Controls.Add(this.txtDescription);
            this.panelEntry.Controls.Add(this.lblDescription);
            this.panelEntry.Controls.Add(this.nudLevel);
            this.panelEntry.Controls.Add(this.lblLevel);
            this.panelEntry.Controls.Add(this.cmbParentWBS);
            this.panelEntry.Controls.Add(this.lblParentWBS);
            this.panelEntry.Controls.Add(this.txtWBSName);
            this.panelEntry.Controls.Add(this.lblWBSName);
            this.panelEntry.Controls.Add(this.txtWBSCode);
            this.panelEntry.Controls.Add(this.lblWBSCode);
            this.panelEntry.Controls.Add(this.lblEntryTitle);
            this.panelEntry.Location = new System.Drawing.Point(3, 168);
            this.panelEntry.Name = "panelEntry";
            this.panelEntry.Padding = new System.Windows.Forms.Padding(10);
            this.panelEntry.Size = new System.Drawing.Size(404, 441);
            this.panelEntry.TabIndex = 0;
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
            this.panelButtons.Location = new System.Drawing.Point(13, 357);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(376, 67);
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
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chkIsActive.Location = new System.Drawing.Point(116, 326);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(84, 23);
            this.chkIsActive.TabIndex = 11;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.Location = new System.Drawing.Point(116, 212);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(266, 97);
            this.txtDescription.TabIndex = 10;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(13, 215);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(85, 19);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "Description";
            // 
            // nudLevel
            // 
            this.nudLevel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudLevel.Location = new System.Drawing.Point(116, 169);
            this.nudLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLevel.Name = "nudLevel";
            this.nudLevel.ReadOnly = true;
            this.nudLevel.Size = new System.Drawing.Size(120, 25);
            this.nudLevel.TabIndex = 8;
            this.nudLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLevel.Location = new System.Drawing.Point(13, 171);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(44, 19);
            this.lblLevel.TabIndex = 7;
            this.lblLevel.Text = "Level";
            // 
            // cmbParentWBS
            // 
            this.cmbParentWBS.BackColor = System.Drawing.Color.Transparent;
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
            this.cmbParentWBS.SelectedIndexChanged += new System.EventHandler(this.cmbParentWBS_SelectedIndexChanged);
            // 
            // lblParentWBS
            // 
            this.lblParentWBS.AutoSize = true;
            this.lblParentWBS.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblParentWBS.Location = new System.Drawing.Point(13, 129);
            this.lblParentWBS.Name = "lblParentWBS";
            this.lblParentWBS.Size = new System.Drawing.Size(88, 19);
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
            this.lblWBSName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblWBSName.Location = new System.Drawing.Point(13, 87);
            this.lblWBSName.Name = "lblWBSName";
            this.lblWBSName.Size = new System.Drawing.Size(84, 19);
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
            this.lblWBSCode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblWBSCode.Location = new System.Drawing.Point(13, 45);
            this.lblWBSCode.Name = "lblWBSCode";
            this.lblWBSCode.Size = new System.Drawing.Size(79, 19);
            this.lblWBSCode.TabIndex = 1;
            this.lblWBSCode.Text = "WBS Code";
            // 
            // lblEntryTitle
            // 
            this.lblEntryTitle.AutoSize = true;
            this.lblEntryTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblEntryTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblEntryTitle.Location = new System.Drawing.Point(13, 12);
            this.lblEntryTitle.Name = "lblEntryTitle";
            this.lblEntryTitle.Size = new System.Drawing.Size(84, 20);
            this.lblEntryTitle.TabIndex = 0;
            this.lblEntryTitle.Text = "WBS Entry";
            // 
            // panelList
            // 
            this.panelList.BackColor = System.Drawing.Color.White;
            this.panelList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelList.Controls.Add(this.splitContainer2);
            this.panelList.Controls.Add(this.lblTreeTitle);
            this.panelList.Location = new System.Drawing.Point(498, 168);
            this.panelList.Name = "panelList";
            this.panelList.Padding = new System.Windows.Forms.Padding(10);
            this.panelList.Size = new System.Drawing.Size(793, 475);
            this.panelList.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(10, 40);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tvWBS);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvWBS);
            this.splitContainer2.Size = new System.Drawing.Size(771, 423);
            this.splitContainer2.SplitterDistance = 223;
            this.splitContainer2.TabIndex = 1;
            // 
            // tvWBS
            // 
            this.tvWBS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvWBS.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tvWBS.FullRowSelect = true;
            this.tvWBS.HideSelection = false;
            this.tvWBS.Location = new System.Drawing.Point(0, 0);
            this.tvWBS.Name = "tvWBS";
            this.tvWBS.Size = new System.Drawing.Size(771, 223);
            this.tvWBS.TabIndex = 0;
            this.tvWBS.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvWBS_AfterSelect);
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
            this.colDescription,
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
            this.dgvWBS.Size = new System.Drawing.Size(771, 196);
            this.dgvWBS.TabIndex = 0;
            this.dgvWBS.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWBS_CellClick);
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
            this.colCode.FillWeight = 80F;
            this.colCode.HeaderText = "WBS Code";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.FillWeight = 140F;
            this.colName.HeaderText = "WBS Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colParentName
            // 
            this.colParentName.FillWeight = 120F;
            this.colParentName.HeaderText = "Parent WBS";
            this.colParentName.Name = "colParentName";
            this.colParentName.ReadOnly = true;
            // 
            // colLevel
            // 
            this.colLevel.FillWeight = 50F;
            this.colLevel.HeaderText = "Level";
            this.colLevel.Name = "colLevel";
            this.colLevel.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.FillWeight = 150F;
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colIsActive
            // 
            this.colIsActive.FillWeight = 60F;
            this.colIsActive.HeaderText = "Active";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.ReadOnly = true;
            // 
            // lblTreeTitle
            // 
            this.lblTreeTitle.AutoSize = true;
            this.lblTreeTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTreeTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTreeTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTreeTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTreeTitle.Name = "lblTreeTitle";
            this.lblTreeTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lblTreeTitle.Size = new System.Drawing.Size(153, 30);
            this.lblTreeTitle.TabIndex = 0;
            this.lblTreeTitle.Text = "WBS Hierarchy / List";
            // 
            // frmProjectWBS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 643);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.headerUC1);
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProjectWBS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project WBS";
            this.Load += new System.EventHandler(this.frmProjectWBS_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelEntry.ResumeLayout(false);
            this.panelEntry.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).EndInit();
            this.panelList.ResumeLayout(false);
            this.panelList.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWBS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HeaderUC headerUC1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblProject;
        private Guna.UI2.WinForms.Guna2ComboBox cmbProject;
        private Guna.UI2.WinForms.Guna2Button btnLoad;
        private System.Windows.Forms.Label lblSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelEntry;
        private System.Windows.Forms.Label lblEntryTitle;
        private System.Windows.Forms.Label lblWBSCode;
        private Guna.UI2.WinForms.Guna2TextBox txtWBSCode;
        private System.Windows.Forms.Label lblWBSName;
        private Guna.UI2.WinForms.Guna2TextBox txtWBSName;
        private System.Windows.Forms.Label lblParentWBS;
        private Guna.UI2.WinForms.Guna2ComboBox cmbParentWBS;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.NumericUpDown nudLevel;
        private System.Windows.Forms.Label lblDescription;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Panel panelButtons;
        private Guna.UI2.WinForms.Guna2Button btnNew;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2TextBox txtID;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Label lblTreeTitle;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView tvWBS;
        private System.Windows.Forms.DataGridView dgvWBS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParentWBSID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsActive;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private System.Windows.Forms.Label label2;
    }
}