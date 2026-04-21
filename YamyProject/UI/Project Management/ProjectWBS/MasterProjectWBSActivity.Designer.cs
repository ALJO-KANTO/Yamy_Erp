namespace YamyProject.UI.Project_Management.ProjectWBS
{
    partial class MasterProjectWBSActivity
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnNewZone = new System.Windows.Forms.Button();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSupervisor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTender = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSite = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSiteSetup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpWBS = new System.Windows.Forms.GroupBox();
            this.btnNewWBS = new System.Windows.Forms.Button();
            this.btnSaveWBS = new System.Windows.Forms.Button();
            this.txtWBSRemarks = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbWBSStatus = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtWBSEngineer = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpWBSEnd = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpWBSStart = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtWBSLevel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbParentWBS = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtWBSName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWBSCode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dgvWBS = new System.Windows.Forms.DataGridView();
            this.grpActivity = new System.Windows.Forms.GroupBox();
            this.btnNewActivity = new System.Windows.Forms.Button();
            this.btnSaveActivity = new System.Windows.Forms.Button();
            this.txtActivityRemarks = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cmbActivityStatus = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtPlannedQty = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtActEngineer = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.dtpActEnd = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.dtpActStart = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbDependencyActivity = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtActivityName = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtActivityCode = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbWBS = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dgvActivity = new System.Windows.Forms.DataGridView();
            this.headerUC1 = new YamyProject.HeaderUC();
            this.panelTop.SuspendLayout();
            this.grpWBS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWBS)).BeginInit();
            this.grpActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivity)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnLoad);
            this.panelTop.Controls.Add(this.btnNewZone);
            this.panelTop.Controls.Add(this.cmbZone);
            this.panelTop.Controls.Add(this.label6);
            this.panelTop.Controls.Add(this.txtSupervisor);
            this.panelTop.Controls.Add(this.label5);
            this.panelTop.Controls.Add(this.txtTender);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Controls.Add(this.txtSite);
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Controls.Add(this.txtProject);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.cmbSiteSetup);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1400, 95);
            this.panelTop.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(780, 47);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(80, 25);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnNewZone
            // 
            this.btnNewZone.Location = new System.Drawing.Point(680, 47);
            this.btnNewZone.Name = "btnNewZone";
            this.btnNewZone.Size = new System.Drawing.Size(80, 25);
            this.btnNewZone.TabIndex = 1;
            this.btnNewZone.Text = "Add Zone";
            this.btnNewZone.UseVisualStyleBackColor = true;
            this.btnNewZone.Click += new System.EventHandler(this.btnNewZone_Click);
            // 
            // cmbZone
            // 
            this.cmbZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZone.FormattingEnabled = true;
            this.cmbZone.Location = new System.Drawing.Point(450, 49);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(220, 21);
            this.cmbZone.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(400, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Zone";
            // 
            // txtSupervisor
            // 
            this.txtSupervisor.Location = new System.Drawing.Point(80, 49);
            this.txtSupervisor.Name = "txtSupervisor";
            this.txtSupervisor.ReadOnly = true;
            this.txtSupervisor.Size = new System.Drawing.Size(300, 20);
            this.txtSupervisor.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Supervisor";
            // 
            // txtTender
            // 
            this.txtTender.Location = new System.Drawing.Point(940, 12);
            this.txtTender.Name = "txtTender";
            this.txtTender.ReadOnly = true;
            this.txtTender.Size = new System.Drawing.Size(180, 20);
            this.txtTender.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(890, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tender";
            // 
            // txtSite
            // 
            this.txtSite.Location = new System.Drawing.Point(690, 12);
            this.txtSite.Name = "txtSite";
            this.txtSite.ReadOnly = true;
            this.txtSite.Size = new System.Drawing.Size(180, 20);
            this.txtSite.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(650, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Site";
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(450, 12);
            this.txtProject.Name = "txtProject";
            this.txtProject.ReadOnly = true;
            this.txtProject.Size = new System.Drawing.Size(180, 20);
            this.txtProject.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Project";
            // 
            // cmbSiteSetup
            // 
            this.cmbSiteSetup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSiteSetup.FormattingEnabled = true;
            this.cmbSiteSetup.Location = new System.Drawing.Point(80, 12);
            this.cmbSiteSetup.Name = "cmbSiteSetup";
            this.cmbSiteSetup.Size = new System.Drawing.Size(300, 21);
            this.cmbSiteSetup.TabIndex = 0;
            this.cmbSiteSetup.SelectedIndexChanged += new System.EventHandler(this.cmbSiteSetup_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Site Setup";
            // 
            // grpWBS
            // 
            this.grpWBS.Controls.Add(this.btnNewWBS);
            this.grpWBS.Controls.Add(this.btnSaveWBS);
            this.grpWBS.Controls.Add(this.txtWBSRemarks);
            this.grpWBS.Controls.Add(this.label14);
            this.grpWBS.Controls.Add(this.cmbWBSStatus);
            this.grpWBS.Controls.Add(this.label13);
            this.grpWBS.Controls.Add(this.txtWBSEngineer);
            this.grpWBS.Controls.Add(this.label12);
            this.grpWBS.Controls.Add(this.dtpWBSEnd);
            this.grpWBS.Controls.Add(this.label11);
            this.grpWBS.Controls.Add(this.dtpWBSStart);
            this.grpWBS.Controls.Add(this.label10);
            this.grpWBS.Controls.Add(this.txtWBSLevel);
            this.grpWBS.Controls.Add(this.label9);
            this.grpWBS.Controls.Add(this.cmbParentWBS);
            this.grpWBS.Controls.Add(this.label8);
            this.grpWBS.Controls.Add(this.txtWBSName);
            this.grpWBS.Controls.Add(this.label7);
            this.grpWBS.Controls.Add(this.txtWBSCode);
            this.grpWBS.Controls.Add(this.label15);
            this.grpWBS.Location = new System.Drawing.Point(12, 101);
            this.grpWBS.Name = "grpWBS";
            this.grpWBS.Size = new System.Drawing.Size(1376, 140);
            this.grpWBS.TabIndex = 1;
            this.grpWBS.TabStop = false;
            this.grpWBS.Text = "WBS Entry";
            // 
            // btnNewWBS
            // 
            this.btnNewWBS.Location = new System.Drawing.Point(820, 90);
            this.btnNewWBS.Name = "btnNewWBS";
            this.btnNewWBS.Size = new System.Drawing.Size(90, 28);
            this.btnNewWBS.TabIndex = 0;
            this.btnNewWBS.Text = "New";
            this.btnNewWBS.Click += new System.EventHandler(this.btnNewWBS_Click);
            // 
            // btnSaveWBS
            // 
            this.btnSaveWBS.Location = new System.Drawing.Point(720, 90);
            this.btnSaveWBS.Name = "btnSaveWBS";
            this.btnSaveWBS.Size = new System.Drawing.Size(90, 28);
            this.btnSaveWBS.TabIndex = 1;
            this.btnSaveWBS.Text = "Save WBS";
            this.btnSaveWBS.Click += new System.EventHandler(this.btnSaveWBS_Click);
            // 
            // txtWBSRemarks
            // 
            this.txtWBSRemarks.Location = new System.Drawing.Point(80, 92);
            this.txtWBSRemarks.Name = "txtWBSRemarks";
            this.txtWBSRemarks.Size = new System.Drawing.Size(610, 20);
            this.txtWBSRemarks.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Remarks";
            // 
            // cmbWBSStatus
            // 
            this.cmbWBSStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWBSStatus.Items.AddRange(new object[] {
            "Planned",
            "In Progress",
            "Completed",
            "Hold"});
            this.cmbWBSStatus.Location = new System.Drawing.Point(760, 57);
            this.cmbWBSStatus.Name = "cmbWBSStatus";
            this.cmbWBSStatus.Size = new System.Drawing.Size(150, 21);
            this.cmbWBSStatus.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(710, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Status";
            // 
            // txtWBSEngineer
            // 
            this.txtWBSEngineer.Location = new System.Drawing.Point(490, 57);
            this.txtWBSEngineer.Name = "txtWBSEngineer";
            this.txtWBSEngineer.Size = new System.Drawing.Size(200, 20);
            this.txtWBSEngineer.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(430, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Engineer";
            // 
            // dtpWBSEnd
            // 
            this.dtpWBSEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWBSEnd.Location = new System.Drawing.Point(290, 57);
            this.dtpWBSEnd.Name = "dtpWBSEnd";
            this.dtpWBSEnd.Size = new System.Drawing.Size(120, 20);
            this.dtpWBSEnd.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(220, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "End";
            // 
            // dtpWBSStart
            // 
            this.dtpWBSStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWBSStart.Location = new System.Drawing.Point(80, 57);
            this.dtpWBSStart.Name = "dtpWBSStart";
            this.dtpWBSStart.Size = new System.Drawing.Size(120, 20);
            this.dtpWBSStart.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Start";
            // 
            // txtWBSLevel
            // 
            this.txtWBSLevel.Location = new System.Drawing.Point(870, 22);
            this.txtWBSLevel.Name = "txtWBSLevel";
            this.txtWBSLevel.Size = new System.Drawing.Size(60, 20);
            this.txtWBSLevel.TabIndex = 12;
            this.txtWBSLevel.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(830, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Level";
            // 
            // cmbParentWBS
            // 
            this.cmbParentWBS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentWBS.Location = new System.Drawing.Point(630, 22);
            this.cmbParentWBS.Name = "cmbParentWBS";
            this.cmbParentWBS.Size = new System.Drawing.Size(180, 21);
            this.cmbParentWBS.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(560, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Parent WBS";
            // 
            // txtWBSName
            // 
            this.txtWBSName.Location = new System.Drawing.Point(290, 22);
            this.txtWBSName.Name = "txtWBSName";
            this.txtWBSName.Size = new System.Drawing.Size(250, 20);
            this.txtWBSName.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(220, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "WBS Name";
            // 
            // txtWBSCode
            // 
            this.txtWBSCode.Location = new System.Drawing.Point(80, 22);
            this.txtWBSCode.Name = "txtWBSCode";
            this.txtWBSCode.Size = new System.Drawing.Size(120, 20);
            this.txtWBSCode.TabIndex = 18;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "WBS Code";
            // 
            // dgvWBS
            // 
            this.dgvWBS.AllowUserToAddRows = false;
            this.dgvWBS.AllowUserToDeleteRows = false;
            this.dgvWBS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWBS.Location = new System.Drawing.Point(12, 247);
            this.dgvWBS.Name = "dgvWBS";
            this.dgvWBS.ReadOnly = true;
            this.dgvWBS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWBS.Size = new System.Drawing.Size(1376, 180);
            this.dgvWBS.TabIndex = 4;
            // 
            // grpActivity
            // 
            this.grpActivity.Controls.Add(this.btnNewActivity);
            this.grpActivity.Controls.Add(this.btnSaveActivity);
            this.grpActivity.Controls.Add(this.txtActivityRemarks);
            this.grpActivity.Controls.Add(this.label28);
            this.grpActivity.Controls.Add(this.cmbActivityStatus);
            this.grpActivity.Controls.Add(this.label27);
            this.grpActivity.Controls.Add(this.txtUnit);
            this.grpActivity.Controls.Add(this.label26);
            this.grpActivity.Controls.Add(this.txtPlannedQty);
            this.grpActivity.Controls.Add(this.label25);
            this.grpActivity.Controls.Add(this.txtActEngineer);
            this.grpActivity.Controls.Add(this.label24);
            this.grpActivity.Controls.Add(this.txtDuration);
            this.grpActivity.Controls.Add(this.label23);
            this.grpActivity.Controls.Add(this.dtpActEnd);
            this.grpActivity.Controls.Add(this.label22);
            this.grpActivity.Controls.Add(this.dtpActStart);
            this.grpActivity.Controls.Add(this.label21);
            this.grpActivity.Controls.Add(this.cmbDependencyActivity);
            this.grpActivity.Controls.Add(this.label20);
            this.grpActivity.Controls.Add(this.txtActivityName);
            this.grpActivity.Controls.Add(this.label19);
            this.grpActivity.Controls.Add(this.txtActivityCode);
            this.grpActivity.Controls.Add(this.label18);
            this.grpActivity.Controls.Add(this.cmbWBS);
            this.grpActivity.Controls.Add(this.label17);
            this.grpActivity.Location = new System.Drawing.Point(12, 433);
            this.grpActivity.Name = "grpActivity";
            this.grpActivity.Size = new System.Drawing.Size(1376, 160);
            this.grpActivity.TabIndex = 3;
            this.grpActivity.TabStop = false;
            this.grpActivity.Text = "Activity Entry";
            // 
            // btnNewActivity
            // 
            this.btnNewActivity.Location = new System.Drawing.Point(960, 88);
            this.btnNewActivity.Name = "btnNewActivity";
            this.btnNewActivity.Size = new System.Drawing.Size(90, 28);
            this.btnNewActivity.TabIndex = 0;
            this.btnNewActivity.Text = "New";
            this.btnNewActivity.Click += new System.EventHandler(this.btnNewActivity_Click);
            // 
            // btnSaveActivity
            // 
            this.btnSaveActivity.Location = new System.Drawing.Point(850, 88);
            this.btnSaveActivity.Name = "btnSaveActivity";
            this.btnSaveActivity.Size = new System.Drawing.Size(100, 28);
            this.btnSaveActivity.TabIndex = 1;
            this.btnSaveActivity.Text = "Save Activity";
            this.btnSaveActivity.Click += new System.EventHandler(this.btnSaveActivity_Click);
            // 
            // txtActivityRemarks
            // 
            this.txtActivityRemarks.Location = new System.Drawing.Point(310, 92);
            this.txtActivityRemarks.Name = "txtActivityRemarks";
            this.txtActivityRemarks.Size = new System.Drawing.Size(520, 20);
            this.txtActivityRemarks.TabIndex = 2;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(250, 95);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(49, 13);
            this.label28.TabIndex = 3;
            this.label28.Text = "Remarks";
            // 
            // cmbActivityStatus
            // 
            this.cmbActivityStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActivityStatus.Items.AddRange(new object[] {
            "Planned",
            "In Progress",
            "Completed",
            "Hold"});
            this.cmbActivityStatus.Location = new System.Drawing.Point(80, 92);
            this.cmbActivityStatus.Name = "cmbActivityStatus";
            this.cmbActivityStatus.Size = new System.Drawing.Size(150, 21);
            this.cmbActivityStatus.TabIndex = 4;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(10, 95);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(37, 13);
            this.label27.TabIndex = 5;
            this.label27.Text = "Status";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(1090, 57);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(90, 20);
            this.txtUnit.TabIndex = 6;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(1050, 60);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(26, 13);
            this.label26.TabIndex = 7;
            this.label26.Text = "Unit";
            // 
            // txtPlannedQty
            // 
            this.txtPlannedQty.Location = new System.Drawing.Point(930, 57);
            this.txtPlannedQty.Name = "txtPlannedQty";
            this.txtPlannedQty.Size = new System.Drawing.Size(100, 20);
            this.txtPlannedQty.TabIndex = 8;
            this.txtPlannedQty.Text = "0";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(850, 60);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 13);
            this.label25.TabIndex = 9;
            this.label25.Text = "Planned Qty";
            // 
            // txtActEngineer
            // 
            this.txtActEngineer.Location = new System.Drawing.Point(650, 57);
            this.txtActEngineer.Name = "txtActEngineer";
            this.txtActEngineer.Size = new System.Drawing.Size(180, 20);
            this.txtActEngineer.TabIndex = 10;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(590, 60);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(49, 13);
            this.label24.TabIndex = 11;
            this.label24.Text = "Engineer";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(490, 57);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(80, 20);
            this.txtDuration.TabIndex = 12;
            this.txtDuration.Text = "0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(430, 60);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 13);
            this.label23.TabIndex = 13;
            this.label23.Text = "Duration";
            // 
            // dtpActEnd
            // 
            this.dtpActEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpActEnd.Location = new System.Drawing.Point(290, 57);
            this.dtpActEnd.Name = "dtpActEnd";
            this.dtpActEnd.Size = new System.Drawing.Size(120, 20);
            this.dtpActEnd.TabIndex = 14;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(220, 60);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(26, 13);
            this.label22.TabIndex = 15;
            this.label22.Text = "End";
            // 
            // dtpActStart
            // 
            this.dtpActStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpActStart.Location = new System.Drawing.Point(80, 57);
            this.dtpActStart.Name = "dtpActStart";
            this.dtpActStart.Size = new System.Drawing.Size(120, 20);
            this.dtpActStart.TabIndex = 16;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 60);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 13);
            this.label21.TabIndex = 17;
            this.label21.Text = "Start";
            // 
            // cmbDependencyActivity
            // 
            this.cmbDependencyActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDependencyActivity.Location = new System.Drawing.Point(980, 22);
            this.cmbDependencyActivity.Name = "cmbDependencyActivity";
            this.cmbDependencyActivity.Size = new System.Drawing.Size(200, 21);
            this.cmbDependencyActivity.TabIndex = 18;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(900, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 13);
            this.label20.TabIndex = 19;
            this.label20.Text = "Dependency";
            // 
            // txtActivityName
            // 
            this.txtActivityName.Location = new System.Drawing.Point(630, 22);
            this.txtActivityName.Name = "txtActivityName";
            this.txtActivityName.Size = new System.Drawing.Size(250, 20);
            this.txtActivityName.TabIndex = 20;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(550, 25);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 13);
            this.label19.TabIndex = 21;
            this.label19.Text = "Activity Name";
            // 
            // txtActivityCode
            // 
            this.txtActivityCode.Location = new System.Drawing.Point(410, 22);
            this.txtActivityCode.Name = "txtActivityCode";
            this.txtActivityCode.Size = new System.Drawing.Size(120, 20);
            this.txtActivityCode.TabIndex = 22;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(350, 25);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 13);
            this.label18.TabIndex = 23;
            this.label18.Text = "Act Code";
            // 
            // cmbWBS
            // 
            this.cmbWBS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWBS.Location = new System.Drawing.Point(80, 22);
            this.cmbWBS.Name = "cmbWBS";
            this.cmbWBS.Size = new System.Drawing.Size(250, 21);
            this.cmbWBS.TabIndex = 24;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "WBS";
            // 
            // dgvActivity
            // 
            this.dgvActivity.AllowUserToAddRows = false;
            this.dgvActivity.AllowUserToDeleteRows = false;
            this.dgvActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActivity.Location = new System.Drawing.Point(12, 599);
            this.dgvActivity.Name = "dgvActivity";
            this.dgvActivity.ReadOnly = true;
            this.dgvActivity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActivity.Size = new System.Drawing.Size(1376, 180);
            this.dgvActivity.TabIndex = 0;
            // 
            // headerUC1
            // 
            this.headerUC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.headerUC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerUC1.FormText = "";
            this.headerUC1.HeaderText = "";
            this.headerUC1.Location = new System.Drawing.Point(0, 95);
            this.headerUC1.Margin = new System.Windows.Forms.Padding(2);
            this.headerUC1.Name = "headerUC1";
            this.headerUC1.Size = new System.Drawing.Size(1400, 30);
            this.headerUC1.TabIndex = 5;
            // 
            // MaterWBSActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 790);
            this.Controls.Add(this.dgvActivity);
            this.Controls.Add(this.grpActivity);
            this.Controls.Add(this.dgvWBS);
            this.Controls.Add(this.grpWBS);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.headerUC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MaterWBSActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project WBS & Activity Planning";
            this.Load += new System.EventHandler(this.MaterWBSActivity_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.grpWBS.ResumeLayout(false);
            this.grpWBS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWBS)).EndInit();
            this.grpActivity.ResumeLayout(false);
            this.grpActivity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnNewZone;
        private System.Windows.Forms.ComboBox cmbZone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSupervisor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSiteSetup;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.GroupBox grpWBS;
        private System.Windows.Forms.Button btnNewWBS;
        private System.Windows.Forms.Button btnSaveWBS;
        private System.Windows.Forms.TextBox txtWBSRemarks;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbWBSStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtWBSEngineer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpWBSEnd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpWBSStart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtWBSLevel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbParentWBS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtWBSName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWBSCode;
        private System.Windows.Forms.Label label15;

        private System.Windows.Forms.DataGridView dgvWBS;

        private System.Windows.Forms.GroupBox grpActivity;
        private System.Windows.Forms.Button btnNewActivity;
        private System.Windows.Forms.Button btnSaveActivity;
        private System.Windows.Forms.TextBox txtActivityRemarks;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cmbActivityStatus;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtPlannedQty;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtActEngineer;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker dtpActEnd;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtpActStart;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbDependencyActivity;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtActivityName;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtActivityCode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbWBS;
        private System.Windows.Forms.Label label17;

        private System.Windows.Forms.DataGridView dgvActivity;
        private HeaderUC headerUC1;
    }
}