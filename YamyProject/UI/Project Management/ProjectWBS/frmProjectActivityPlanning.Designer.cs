namespace YamyProject.UI.Project_Management.ProjectWBS
{
    partial class frmProjectActivityPlanning
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
            this.headerUC1 = new YamyProject.HeaderUC();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnLoad = new Guna.UI2.WinForms.Guna2Button();
            this.cmbSiteSetup = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpWbsTree = new System.Windows.Forms.GroupBox();
            this.tvWBS = new System.Windows.Forms.TreeView();
            this.panelRight = new System.Windows.Forms.Panel();
            this.dgvActivities = new Guna.UI2.WinForms.Guna2DataGridView();
            this.grpActivity = new System.Windows.Forms.GroupBox();
            this.btnNewActivity = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveActivity = new Guna.UI2.WinForms.Guna2Button();
            this.txtRemarks = new Guna.UI2.WinForms.Guna2TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbResponsible = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbDependency = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUnit = new Guna.UI2.WinForms.Guna2TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPlannedQty = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbBOQ = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtActivityName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtActivityCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.grpWBS = new System.Windows.Forms.GroupBox();
            this.btnNewWBS = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveWBS = new Guna.UI2.WinForms.Guna2Button();
            this.txtWbsDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbParentWBS = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWbsName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWbsCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpWbsTree.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivities)).BeginInit();
            this.grpActivity.SuspendLayout();
            this.grpWBS.SuspendLayout();
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
            this.headerUC1.Size = new System.Drawing.Size(1400, 30);
            this.headerUC1.TabIndex = 4;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTop.Controls.Add(this.btnLoad);
            this.panelTop.Controls.Add(this.cmbSiteSetup);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.cmbProject);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 30);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1400, 60);
            this.panelTop.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.BorderRadius = 5;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(760, 14);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 28);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cmbSiteSetup
            // 
            this.cmbSiteSetup.BackColor = System.Drawing.Color.Transparent;
            this.cmbSiteSetup.BorderRadius = 5;
            this.cmbSiteSetup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSiteSetup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSiteSetup.FocusedColor = System.Drawing.Color.Empty;
            this.cmbSiteSetup.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSiteSetup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbSiteSetup.FormattingEnabled = true;
            this.cmbSiteSetup.ItemHeight = 18;
            this.cmbSiteSetup.Location = new System.Drawing.Point(420, 16);
            this.cmbSiteSetup.Name = "cmbSiteSetup";
            this.cmbSiteSetup.Size = new System.Drawing.Size(320, 24);
            this.cmbSiteSetup.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Site Setup";
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
            this.cmbProject.ItemHeight = 18;
            this.cmbProject.Location = new System.Drawing.Point(70, 16);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(250, 24);
            this.cmbProject.TabIndex = 1;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 90);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpWbsTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelRight);
            this.splitContainer1.Size = new System.Drawing.Size(1400, 710);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 1;
            // 
            // grpWbsTree
            // 
            this.grpWbsTree.Controls.Add(this.tvWBS);
            this.grpWbsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpWbsTree.Location = new System.Drawing.Point(0, 0);
            this.grpWbsTree.Name = "grpWbsTree";
            this.grpWbsTree.Size = new System.Drawing.Size(350, 710);
            this.grpWbsTree.TabIndex = 0;
            this.grpWbsTree.TabStop = false;
            this.grpWbsTree.Text = "WBS Tree";
            // 
            // tvWBS
            // 
            this.tvWBS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvWBS.Location = new System.Drawing.Point(3, 16);
            this.tvWBS.Name = "tvWBS";
            this.tvWBS.Size = new System.Drawing.Size(344, 691);
            this.tvWBS.TabIndex = 0;
            this.tvWBS.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvWBS_AfterSelect);
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.dgvActivities);
            this.panelRight.Controls.Add(this.grpActivity);
            this.panelRight.Controls.Add(this.grpWBS);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(1046, 710);
            this.panelRight.TabIndex = 0;
            // 
            // dgvActivities
            // 
            this.dgvActivities.AllowUserToAddRows = false;
            this.dgvActivities.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvActivities.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvActivities.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvActivities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvActivities.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvActivities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActivities.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvActivities.Location = new System.Drawing.Point(0, 440);
            this.dgvActivities.Name = "dgvActivities";
            this.dgvActivities.ReadOnly = true;
            this.dgvActivities.RowHeadersVisible = false;
            this.dgvActivities.RowTemplate.Height = 24;
            this.dgvActivities.Size = new System.Drawing.Size(1046, 270);
            this.dgvActivities.TabIndex = 2;
            this.dgvActivities.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvActivities.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvActivities.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvActivities.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvActivities.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvActivities.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvActivities.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvActivities.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvActivities.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvActivities.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvActivities.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvActivities.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActivities.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvActivities.ThemeStyle.ReadOnly = true;
            this.dgvActivities.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvActivities.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvActivities.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvActivities.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvActivities.ThemeStyle.RowsStyle.Height = 24;
            this.dgvActivities.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvActivities.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvActivities.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActivities_CellDoubleClick);
            // 
            // grpActivity
            // 
            this.grpActivity.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpActivity.Controls.Add(this.btnNewActivity);
            this.grpActivity.Controls.Add(this.btnSaveActivity);
            this.grpActivity.Controls.Add(this.txtRemarks);
            this.grpActivity.Controls.Add(this.label15);
            this.grpActivity.Controls.Add(this.cmbResponsible);
            this.grpActivity.Controls.Add(this.label14);
            this.grpActivity.Controls.Add(this.cmbDependency);
            this.grpActivity.Controls.Add(this.label13);
            this.grpActivity.Controls.Add(this.dtpEnd);
            this.grpActivity.Controls.Add(this.label12);
            this.grpActivity.Controls.Add(this.dtpStart);
            this.grpActivity.Controls.Add(this.label11);
            this.grpActivity.Controls.Add(this.txtUnit);
            this.grpActivity.Controls.Add(this.label10);
            this.grpActivity.Controls.Add(this.txtPlannedQty);
            this.grpActivity.Controls.Add(this.label9);
            this.grpActivity.Controls.Add(this.cmbBOQ);
            this.grpActivity.Controls.Add(this.label8);
            this.grpActivity.Controls.Add(this.txtActivityName);
            this.grpActivity.Controls.Add(this.label7);
            this.grpActivity.Controls.Add(this.txtActivityCode);
            this.grpActivity.Controls.Add(this.label16);
            this.grpActivity.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpActivity.Location = new System.Drawing.Point(0, 180);
            this.grpActivity.Name = "grpActivity";
            this.grpActivity.Size = new System.Drawing.Size(1046, 260);
            this.grpActivity.TabIndex = 1;
            this.grpActivity.TabStop = false;
            this.grpActivity.Text = "Activity Entry";
            // 
            // btnNewActivity
            // 
            this.btnNewActivity.BorderRadius = 5;
            this.btnNewActivity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNewActivity.ForeColor = System.Drawing.Color.White;
            this.btnNewActivity.Location = new System.Drawing.Point(840, 95);
            this.btnNewActivity.Name = "btnNewActivity";
            this.btnNewActivity.Size = new System.Drawing.Size(140, 30);
            this.btnNewActivity.TabIndex = 0;
            this.btnNewActivity.Text = "New Activity";
            this.btnNewActivity.Click += new System.EventHandler(this.btnNewActivity_Click);
            // 
            // btnSaveActivity
            // 
            this.btnSaveActivity.BorderRadius = 5;
            this.btnSaveActivity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSaveActivity.ForeColor = System.Drawing.Color.White;
            this.btnSaveActivity.Location = new System.Drawing.Point(840, 40);
            this.btnSaveActivity.Name = "btnSaveActivity";
            this.btnSaveActivity.Size = new System.Drawing.Size(140, 30);
            this.btnSaveActivity.TabIndex = 1;
            this.btnSaveActivity.Text = "Save Activity";
            this.btnSaveActivity.Click += new System.EventHandler(this.btnSaveActivity_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderRadius = 5;
            this.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRemarks.DefaultText = "";
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRemarks.Location = new System.Drawing.Point(120, 192);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.PlaceholderText = "";
            this.txtRemarks.SelectedText = "";
            this.txtRemarks.Size = new System.Drawing.Size(680, 32);
            this.txtRemarks.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 195);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Remarks";
            // 
            // cmbResponsible
            // 
            this.cmbResponsible.BackColor = System.Drawing.Color.Transparent;
            this.cmbResponsible.BorderRadius = 5;
            this.cmbResponsible.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbResponsible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsible.FocusedColor = System.Drawing.Color.Empty;
            this.cmbResponsible.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbResponsible.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbResponsible.ItemHeight = 18;
            this.cmbResponsible.Location = new System.Drawing.Point(510, 152);
            this.cmbResponsible.Name = "cmbResponsible";
            this.cmbResponsible.Size = new System.Drawing.Size(290, 24);
            this.cmbResponsible.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(420, 155);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Responsible";
            // 
            // cmbDependency
            // 
            this.cmbDependency.BackColor = System.Drawing.Color.Transparent;
            this.cmbDependency.BorderRadius = 5;
            this.cmbDependency.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDependency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDependency.FocusedColor = System.Drawing.Color.Empty;
            this.cmbDependency.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDependency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbDependency.ItemHeight = 18;
            this.cmbDependency.Location = new System.Drawing.Point(120, 152);
            this.cmbDependency.Name = "cmbDependency";
            this.cmbDependency.Size = new System.Drawing.Size(280, 24);
            this.cmbDependency.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 155);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Dependency";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(690, 112);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(110, 20);
            this.dtpEnd.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(620, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "End Date";
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(490, 112);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(110, 20);
            this.dtpStart.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(420, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Start Date";
            // 
            // txtUnit
            // 
            this.txtUnit.BorderRadius = 5;
            this.txtUnit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUnit.DefaultText = "";
            this.txtUnit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUnit.Location = new System.Drawing.Point(300, 112);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.PlaceholderText = "";
            this.txtUnit.SelectedText = "";
            this.txtUnit.Size = new System.Drawing.Size(100, 20);
            this.txtUnit.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(260, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Unit";
            // 
            // txtPlannedQty
            // 
            this.txtPlannedQty.BorderRadius = 5;
            this.txtPlannedQty.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPlannedQty.DefaultText = "";
            this.txtPlannedQty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPlannedQty.Location = new System.Drawing.Point(120, 112);
            this.txtPlannedQty.Name = "txtPlannedQty";
            this.txtPlannedQty.PlaceholderText = "";
            this.txtPlannedQty.SelectedText = "";
            this.txtPlannedQty.Size = new System.Drawing.Size(120, 20);
            this.txtPlannedQty.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Planned Qty";
            // 
            // cmbBOQ
            // 
            this.cmbBOQ.BackColor = System.Drawing.Color.Transparent;
            this.cmbBOQ.BorderRadius = 5;
            this.cmbBOQ.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBOQ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBOQ.FocusedColor = System.Drawing.Color.Empty;
            this.cmbBOQ.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbBOQ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbBOQ.ItemHeight = 18;
            this.cmbBOQ.Location = new System.Drawing.Point(120, 72);
            this.cmbBOQ.Name = "cmbBOQ";
            this.cmbBOQ.Size = new System.Drawing.Size(600, 24);
            this.cmbBOQ.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "BOQ Item";
            // 
            // txtActivityName
            // 
            this.txtActivityName.BorderRadius = 5;
            this.txtActivityName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtActivityName.DefaultText = "";
            this.txtActivityName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtActivityName.Location = new System.Drawing.Point(420, 32);
            this.txtActivityName.Name = "txtActivityName";
            this.txtActivityName.PlaceholderText = "";
            this.txtActivityName.SelectedText = "";
            this.txtActivityName.Size = new System.Drawing.Size(300, 20);
            this.txtActivityName.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Activity Name";
            // 
            // txtActivityCode
            // 
            this.txtActivityCode.BorderRadius = 5;
            this.txtActivityCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtActivityCode.DefaultText = "";
            this.txtActivityCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtActivityCode.Location = new System.Drawing.Point(120, 32);
            this.txtActivityCode.Name = "txtActivityCode";
            this.txtActivityCode.PlaceholderText = "";
            this.txtActivityCode.SelectedText = "";
            this.txtActivityCode.Size = new System.Drawing.Size(180, 20);
            this.txtActivityCode.TabIndex = 20;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "Act. Code";
            // 
            // grpWBS
            // 
            this.grpWBS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpWBS.Controls.Add(this.btnNewWBS);
            this.grpWBS.Controls.Add(this.btnSaveWBS);
            this.grpWBS.Controls.Add(this.txtWbsDescription);
            this.grpWBS.Controls.Add(this.label6);
            this.grpWBS.Controls.Add(this.cmbParentWBS);
            this.grpWBS.Controls.Add(this.label5);
            this.grpWBS.Controls.Add(this.txtWbsName);
            this.grpWBS.Controls.Add(this.label4);
            this.grpWBS.Controls.Add(this.txtWbsCode);
            this.grpWBS.Controls.Add(this.label3);
            this.grpWBS.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpWBS.Location = new System.Drawing.Point(0, 0);
            this.grpWBS.Name = "grpWBS";
            this.grpWBS.Size = new System.Drawing.Size(1046, 180);
            this.grpWBS.TabIndex = 0;
            this.grpWBS.TabStop = false;
            this.grpWBS.Text = "WBS Entry";
            // 
            // btnNewWBS
            // 
            this.btnNewWBS.BorderRadius = 5;
            this.btnNewWBS.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNewWBS.ForeColor = System.Drawing.Color.White;
            this.btnNewWBS.Location = new System.Drawing.Point(740, 80);
            this.btnNewWBS.Name = "btnNewWBS";
            this.btnNewWBS.Size = new System.Drawing.Size(120, 30);
            this.btnNewWBS.TabIndex = 0;
            this.btnNewWBS.Text = "New WBS";
            this.btnNewWBS.Click += new System.EventHandler(this.btnNewWBS_Click);
            // 
            // btnSaveWBS
            // 
            this.btnSaveWBS.BorderRadius = 5;
            this.btnSaveWBS.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSaveWBS.ForeColor = System.Drawing.Color.White;
            this.btnSaveWBS.Location = new System.Drawing.Point(740, 32);
            this.btnSaveWBS.Name = "btnSaveWBS";
            this.btnSaveWBS.Size = new System.Drawing.Size(120, 30);
            this.btnSaveWBS.TabIndex = 1;
            this.btnSaveWBS.Text = "Save WBS";
            this.btnSaveWBS.Click += new System.EventHandler(this.btnSaveWBS_Click);
            // 
            // txtWbsDescription
            // 
            this.txtWbsDescription.BorderRadius = 5;
            this.txtWbsDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWbsDescription.DefaultText = "";
            this.txtWbsDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtWbsDescription.Location = new System.Drawing.Point(120, 112);
            this.txtWbsDescription.Multiline = true;
            this.txtWbsDescription.Name = "txtWbsDescription";
            this.txtWbsDescription.PlaceholderText = "";
            this.txtWbsDescription.SelectedText = "";
            this.txtWbsDescription.Size = new System.Drawing.Size(590, 50);
            this.txtWbsDescription.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Description";
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
            this.cmbParentWBS.ItemHeight = 18;
            this.cmbParentWBS.Location = new System.Drawing.Point(120, 72);
            this.cmbParentWBS.Name = "cmbParentWBS";
            this.cmbParentWBS.Size = new System.Drawing.Size(300, 24);
            this.cmbParentWBS.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Parent WBS";
            // 
            // txtWbsName
            // 
            this.txtWbsName.BorderRadius = 5;
            this.txtWbsName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWbsName.DefaultText = "";
            this.txtWbsName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtWbsName.Location = new System.Drawing.Point(410, 32);
            this.txtWbsName.Name = "txtWbsName";
            this.txtWbsName.PlaceholderText = "";
            this.txtWbsName.SelectedText = "";
            this.txtWbsName.Size = new System.Drawing.Size(300, 20);
            this.txtWbsName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(320, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "WBS Name";
            // 
            // txtWbsCode
            // 
            this.txtWbsCode.BorderRadius = 5;
            this.txtWbsCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWbsCode.DefaultText = "";
            this.txtWbsCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtWbsCode.Location = new System.Drawing.Point(120, 32);
            this.txtWbsCode.Name = "txtWbsCode";
            this.txtWbsCode.PlaceholderText = "";
            this.txtWbsCode.SelectedText = "";
            this.txtWbsCode.Size = new System.Drawing.Size(180, 20);
            this.txtWbsCode.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "WBS Code";
            // 
            // frmProjectActivityPlanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.headerUC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProjectActivityPlanning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Activity Planning (WBS + BOQ)";
            this.Load += new System.EventHandler(this.frmProjectActivityPlanning_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpWbsTree.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivities)).EndInit();
            this.grpActivity.ResumeLayout(false);
            this.grpActivity.PerformLayout();
            this.grpWBS.ResumeLayout(false);
            this.grpWBS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private HeaderUC headerUC1;
        private System.Windows.Forms.Panel panelTop;
        private Guna.UI2.WinForms.Guna2Button btnLoad;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSiteSetup;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpWbsTree;
        private System.Windows.Forms.TreeView tvWBS;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.GroupBox grpWBS;
        private Guna.UI2.WinForms.Guna2Button btnNewWBS;
        private Guna.UI2.WinForms.Guna2Button btnSaveWBS;
        private Guna.UI2.WinForms.Guna2TextBox txtWbsDescription;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cmbParentWBS;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtWbsName;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtWbsCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpActivity;
        private Guna.UI2.WinForms.Guna2Button btnNewActivity;
        private Guna.UI2.WinForms.Guna2Button btnSaveActivity;
        private Guna.UI2.WinForms.Guna2TextBox txtRemarks;
        private System.Windows.Forms.Label label15;
        private Guna.UI2.WinForms.Guna2ComboBox cmbResponsible;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2ComboBox cmbDependency;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2TextBox txtUnit;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox txtPlannedQty;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2ComboBox cmbBOQ;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox txtActivityName;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txtActivityCode;
        private System.Windows.Forms.Label label16;
        private Guna.UI2.WinForms.Guna2DataGridView dgvActivities;

    }
}