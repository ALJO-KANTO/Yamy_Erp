using System.Windows.Forms;

namespace YamyProject.UI.Project_Management
{
    partial class frmDailySiteReport
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

        private Panel pnlTop;
        private Label lblTitle;

        private GroupBox grpHeader;

        private TextBox txtReportNo;

        private DateTimePicker dtDate;

        private ComboBox cmbProject;
        private ComboBox cmbSite;
        private ComboBox cmbZone;

        private ComboBox cmbEngineer;

        private ComboBox cmbWeather;

        private TextBox txtTemperature;

        private ComboBox cmbStatus;

        private TextBox txtRemarks;

        private TabControl tabMain;

        private TabPage tabActivity;
        private TabPage tabLabour;
        private TabPage tabEquipment;
        private TabPage tabMaterial;
        private TabPage tabDelay;
        private TabPage tabVisitor;

        private DataGridView dgvActivity;
        private DataGridView dgvLabour;
        private DataGridView dgvEquipment;
        private DataGridView dgvMaterial;
        private DataGridView dgvDelay;
        private DataGridView dgvVisitor;

        private GroupBox grpSummary;

        private TextBox txtManpower;
        private TextBox txtEquipmentCount;
        private TextBox txtProgress;
        private TextBox txtDelayHours;

        private Button btnCalculate;

        private Button btnNew;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnApprove;
        private Button btnPrint;

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpHeader = new System.Windows.Forms.GroupBox();
            this.l1 = new System.Windows.Forms.Label();
            this.txtReportNo = new System.Windows.Forms.TextBox();
            this.l2 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.l3 = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.l4 = new System.Windows.Forms.Label();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.l5 = new System.Windows.Forms.Label();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.l6 = new System.Windows.Forms.Label();
            this.cmbEngineer = new System.Windows.Forms.ComboBox();
            this.l7 = new System.Windows.Forms.Label();
            this.cmbWeather = new System.Windows.Forms.ComboBox();
            this.l8 = new System.Windows.Forms.Label();
            this.txtTemperature = new System.Windows.Forms.TextBox();
            this.l9 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.l10 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabActivity = new System.Windows.Forms.TabPage();
            this.dgvActivity = new System.Windows.Forms.DataGridView();
            this.tabLabour = new System.Windows.Forms.TabPage();
            this.dgvLabour = new System.Windows.Forms.DataGridView();
            this.tabEquipment = new System.Windows.Forms.TabPage();
            this.dgvEquipment = new System.Windows.Forms.DataGridView();
            this.tabMaterial = new System.Windows.Forms.TabPage();
            this.dgvMaterial = new System.Windows.Forms.DataGridView();
            this.tabDelay = new System.Windows.Forms.TabPage();
            this.dgvDelay = new System.Windows.Forms.DataGridView();
            this.tabVisitor = new System.Windows.Forms.TabPage();
            this.dgvVisitor = new System.Windows.Forms.DataGridView();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.s1 = new System.Windows.Forms.Label();
            this.txtManpower = new System.Windows.Forms.TextBox();
            this.s2 = new System.Windows.Forms.Label();
            this.txtEquipmentCount = new System.Windows.Forms.TextBox();
            this.s3 = new System.Windows.Forms.Label();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.grpHeader.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivity)).BeginInit();
            this.tabLabour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabour)).BeginInit();
            this.tabEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipment)).BeginInit();
            this.tabMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).BeginInit();
            this.tabDelay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelay)).BeginInit();
            this.tabVisitor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitor)).BeginInit();
            this.grpSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1184, 55);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(614, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DAILY SITE REPORT";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.l1);
            this.grpHeader.Controls.Add(this.txtReportNo);
            this.grpHeader.Controls.Add(this.l2);
            this.grpHeader.Controls.Add(this.dtDate);
            this.grpHeader.Controls.Add(this.l3);
            this.grpHeader.Controls.Add(this.cmbProject);
            this.grpHeader.Controls.Add(this.l4);
            this.grpHeader.Controls.Add(this.cmbSite);
            this.grpHeader.Controls.Add(this.l5);
            this.grpHeader.Controls.Add(this.cmbZone);
            this.grpHeader.Controls.Add(this.l6);
            this.grpHeader.Controls.Add(this.cmbEngineer);
            this.grpHeader.Controls.Add(this.l7);
            this.grpHeader.Controls.Add(this.cmbWeather);
            this.grpHeader.Controls.Add(this.l8);
            this.grpHeader.Controls.Add(this.txtTemperature);
            this.grpHeader.Controls.Add(this.l9);
            this.grpHeader.Controls.Add(this.cmbStatus);
            this.grpHeader.Controls.Add(this.l10);
            this.grpHeader.Controls.Add(this.txtRemarks);
            this.grpHeader.Location = new System.Drawing.Point(10, 65);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1160, 170);
            this.grpHeader.TabIndex = 1;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Daily Report Information";
            // 
            // l1
            // 
            this.l1.Location = new System.Drawing.Point(15, 30);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(70, 25);
            this.l1.TabIndex = 0;
            this.l1.Text = "Report No";
            // 
            // txtReportNo
            // 
            this.txtReportNo.Location = new System.Drawing.Point(90, 30);
            this.txtReportNo.Name = "txtReportNo";
            this.txtReportNo.Size = new System.Drawing.Size(150, 20);
            this.txtReportNo.TabIndex = 1;
            // 
            // l2
            // 
            this.l2.Location = new System.Drawing.Point(260, 30);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(40, 25);
            this.l2.TabIndex = 2;
            this.l2.Text = "Date";
            // 
            // dtDate
            // 
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(305, 30);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(150, 20);
            this.dtDate.TabIndex = 3;
            // 
            // l3
            // 
            this.l3.Location = new System.Drawing.Point(480, 30);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(50, 25);
            this.l3.TabIndex = 4;
            this.l3.Text = "Project";
            // 
            // cmbProject
            // 
            this.cmbProject.Location = new System.Drawing.Point(535, 30);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(220, 21);
            this.cmbProject.TabIndex = 5;
            // 
            // l4
            // 
            this.l4.Location = new System.Drawing.Point(780, 30);
            this.l4.Name = "l4";
            this.l4.Size = new System.Drawing.Size(40, 25);
            this.l4.TabIndex = 6;
            this.l4.Text = "Site";
            // 
            // cmbSite
            // 
            this.cmbSite.Location = new System.Drawing.Point(825, 30);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(140, 21);
            this.cmbSite.TabIndex = 7;
            // 
            // l5
            // 
            this.l5.Location = new System.Drawing.Point(985, 30);
            this.l5.Name = "l5";
            this.l5.Size = new System.Drawing.Size(40, 25);
            this.l5.TabIndex = 8;
            this.l5.Text = "Zone";
            // 
            // cmbZone
            // 
            this.cmbZone.Location = new System.Drawing.Point(1030, 30);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(110, 21);
            this.cmbZone.TabIndex = 9;
            // 
            // l6
            // 
            this.l6.Location = new System.Drawing.Point(15, 70);
            this.l6.Name = "l6";
            this.l6.Size = new System.Drawing.Size(70, 25);
            this.l6.TabIndex = 10;
            this.l6.Text = "Engineer";
            // 
            // cmbEngineer
            // 
            this.cmbEngineer.Location = new System.Drawing.Point(90, 70);
            this.cmbEngineer.Name = "cmbEngineer";
            this.cmbEngineer.Size = new System.Drawing.Size(220, 21);
            this.cmbEngineer.TabIndex = 11;
            // 
            // l7
            // 
            this.l7.Location = new System.Drawing.Point(340, 70);
            this.l7.Name = "l7";
            this.l7.Size = new System.Drawing.Size(60, 25);
            this.l7.TabIndex = 12;
            this.l7.Text = "Weather";
            // 
            // cmbWeather
            // 
            this.cmbWeather.Location = new System.Drawing.Point(405, 70);
            this.cmbWeather.Name = "cmbWeather";
            this.cmbWeather.Size = new System.Drawing.Size(150, 21);
            this.cmbWeather.TabIndex = 13;
            // 
            // l8
            // 
            this.l8.Location = new System.Drawing.Point(580, 70);
            this.l8.Name = "l8";
            this.l8.Size = new System.Drawing.Size(50, 25);
            this.l8.TabIndex = 14;
            this.l8.Text = "Temp";
            // 
            // txtTemperature
            // 
            this.txtTemperature.Location = new System.Drawing.Point(630, 70);
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.Size = new System.Drawing.Size(70, 20);
            this.txtTemperature.TabIndex = 15;
            // 
            // l9
            // 
            this.l9.Location = new System.Drawing.Point(730, 70);
            this.l9.Name = "l9";
            this.l9.Size = new System.Drawing.Size(50, 25);
            this.l9.TabIndex = 16;
            this.l9.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(785, 70);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(140, 21);
            this.cmbStatus.TabIndex = 17;
            // 
            // l10
            // 
            this.l10.Location = new System.Drawing.Point(945, 70);
            this.l10.Name = "l10";
            this.l10.Size = new System.Drawing.Size(60, 25);
            this.l10.TabIndex = 18;
            this.l10.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(1010, 70);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(130, 20);
            this.txtRemarks.TabIndex = 19;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabActivity);
            this.tabMain.Controls.Add(this.tabLabour);
            this.tabMain.Controls.Add(this.tabEquipment);
            this.tabMain.Controls.Add(this.tabMaterial);
            this.tabMain.Controls.Add(this.tabDelay);
            this.tabMain.Controls.Add(this.tabVisitor);
            this.tabMain.Location = new System.Drawing.Point(10, 240);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1160, 320);
            this.tabMain.TabIndex = 2;
            // 
            // tabActivity
            // 
            this.tabActivity.Controls.Add(this.dgvActivity);
            this.tabActivity.Location = new System.Drawing.Point(4, 22);
            this.tabActivity.Name = "tabActivity";
            this.tabActivity.Size = new System.Drawing.Size(1152, 294);
            this.tabActivity.TabIndex = 0;
            this.tabActivity.Text = "Activities";
            // 
            // dgvActivity
            // 
            this.dgvActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActivity.Location = new System.Drawing.Point(0, 0);
            this.dgvActivity.Name = "dgvActivity";
            this.dgvActivity.RowHeadersVisible = false;
            this.dgvActivity.Size = new System.Drawing.Size(1152, 294);
            this.dgvActivity.TabIndex = 0;
            // 
            // tabLabour
            // 
            this.tabLabour.Controls.Add(this.dgvLabour);
            this.tabLabour.Location = new System.Drawing.Point(4, 22);
            this.tabLabour.Name = "tabLabour";
            this.tabLabour.Size = new System.Drawing.Size(1152, 294);
            this.tabLabour.TabIndex = 1;
            this.tabLabour.Text = "Labour";
            // 
            // dgvLabour
            // 
            this.dgvLabour.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLabour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLabour.Location = new System.Drawing.Point(0, 0);
            this.dgvLabour.Name = "dgvLabour";
            this.dgvLabour.RowHeadersVisible = false;
            this.dgvLabour.Size = new System.Drawing.Size(1152, 294);
            this.dgvLabour.TabIndex = 0;
            // 
            // tabEquipment
            // 
            this.tabEquipment.Controls.Add(this.dgvEquipment);
            this.tabEquipment.Location = new System.Drawing.Point(4, 22);
            this.tabEquipment.Name = "tabEquipment";
            this.tabEquipment.Size = new System.Drawing.Size(1152, 294);
            this.tabEquipment.TabIndex = 2;
            this.tabEquipment.Text = "Equipment";
            // 
            // dgvEquipment
            // 
            this.dgvEquipment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquipment.Location = new System.Drawing.Point(0, 0);
            this.dgvEquipment.Name = "dgvEquipment";
            this.dgvEquipment.RowHeadersVisible = false;
            this.dgvEquipment.Size = new System.Drawing.Size(1152, 294);
            this.dgvEquipment.TabIndex = 0;
            // 
            // tabMaterial
            // 
            this.tabMaterial.Controls.Add(this.dgvMaterial);
            this.tabMaterial.Location = new System.Drawing.Point(4, 22);
            this.tabMaterial.Name = "tabMaterial";
            this.tabMaterial.Size = new System.Drawing.Size(1152, 294);
            this.tabMaterial.TabIndex = 3;
            this.tabMaterial.Text = "Materials";
            // 
            // dgvMaterial
            // 
            this.dgvMaterial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaterial.Location = new System.Drawing.Point(0, 0);
            this.dgvMaterial.Name = "dgvMaterial";
            this.dgvMaterial.RowHeadersVisible = false;
            this.dgvMaterial.Size = new System.Drawing.Size(1152, 294);
            this.dgvMaterial.TabIndex = 0;
            // 
            // tabDelay
            // 
            this.tabDelay.Controls.Add(this.dgvDelay);
            this.tabDelay.Location = new System.Drawing.Point(4, 22);
            this.tabDelay.Name = "tabDelay";
            this.tabDelay.Size = new System.Drawing.Size(1152, 294);
            this.tabDelay.TabIndex = 4;
            this.tabDelay.Text = "Delays";
            // 
            // dgvDelay
            // 
            this.dgvDelay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDelay.ColumnHeadersVisible = false;
            this.dgvDelay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDelay.Location = new System.Drawing.Point(0, 0);
            this.dgvDelay.Name = "dgvDelay";
            this.dgvDelay.Size = new System.Drawing.Size(1152, 294);
            this.dgvDelay.TabIndex = 0;
            // 
            // tabVisitor
            // 
            this.tabVisitor.Controls.Add(this.dgvVisitor);
            this.tabVisitor.Location = new System.Drawing.Point(4, 22);
            this.tabVisitor.Name = "tabVisitor";
            this.tabVisitor.Size = new System.Drawing.Size(1152, 294);
            this.tabVisitor.TabIndex = 5;
            this.tabVisitor.Text = "Visitors";
            // 
            // dgvVisitor
            // 
            this.dgvVisitor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVisitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVisitor.Location = new System.Drawing.Point(0, 0);
            this.dgvVisitor.Name = "dgvVisitor";
            this.dgvVisitor.RowHeadersVisible = false;
            this.dgvVisitor.Size = new System.Drawing.Size(1152, 294);
            this.dgvVisitor.TabIndex = 0;
            // 
            // grpSummary
            // 
            this.grpSummary.Controls.Add(this.s1);
            this.grpSummary.Controls.Add(this.txtManpower);
            this.grpSummary.Controls.Add(this.s2);
            this.grpSummary.Controls.Add(this.txtEquipmentCount);
            this.grpSummary.Controls.Add(this.s3);
            this.grpSummary.Controls.Add(this.txtProgress);
            this.grpSummary.Location = new System.Drawing.Point(700, 570);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(470, 70);
            this.grpSummary.TabIndex = 3;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "Summary";
            // 
            // s1
            // 
            this.s1.Location = new System.Drawing.Point(15, 30);
            this.s1.Name = "s1";
            this.s1.Size = new System.Drawing.Size(80, 25);
            this.s1.TabIndex = 0;
            this.s1.Text = "Manpower";
            // 
            // txtManpower
            // 
            this.txtManpower.Location = new System.Drawing.Point(95, 25);
            this.txtManpower.Name = "txtManpower";
            this.txtManpower.Size = new System.Drawing.Size(70, 20);
            this.txtManpower.TabIndex = 1;
            // 
            // s2
            // 
            this.s2.Location = new System.Drawing.Point(180, 30);
            this.s2.Name = "s2";
            this.s2.Size = new System.Drawing.Size(80, 25);
            this.s2.TabIndex = 2;
            this.s2.Text = "Equipment";
            // 
            // txtEquipmentCount
            // 
            this.txtEquipmentCount.Location = new System.Drawing.Point(260, 25);
            this.txtEquipmentCount.Name = "txtEquipmentCount";
            this.txtEquipmentCount.Size = new System.Drawing.Size(60, 20);
            this.txtEquipmentCount.TabIndex = 3;
            // 
            // s3
            // 
            this.s3.Location = new System.Drawing.Point(335, 30);
            this.s3.Name = "s3";
            this.s3.Size = new System.Drawing.Size(60, 25);
            this.s3.TabIndex = 4;
            this.s3.Text = "Progress";
            // 
            // txtProgress
            // 
            this.txtProgress.Location = new System.Drawing.Point(395, 25);
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.Size = new System.Drawing.Size(60, 20);
            this.txtProgress.TabIndex = 5;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(20, 585);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(120, 35);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(160, 585);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 35);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(270, 585);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(380, 585);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 35);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(490, 585);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(600, 585);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(100, 35);
            this.btnApprove.TabIndex = 9;
            this.btnApprove.Text = "Approve";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(710, 585);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 35);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Print";
            // 
            // frmDailySiteReport
            // 
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDailySiteReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily Site Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDailySiteReport_Load);
            this.pnlTop.ResumeLayout(false);
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabActivity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivity)).EndInit();
            this.tabLabour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabour)).EndInit();
            this.tabEquipment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipment)).EndInit();
            this.tabMaterial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).EndInit();
            this.tabDelay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelay)).EndInit();
            this.tabVisitor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitor)).EndInit();
            this.grpSummary.ResumeLayout(false);
            this.grpSummary.PerformLayout();
            this.ResumeLayout(false);

        }

        private Label l1;
        private Label l2;
        private Label l3;
        private Label l4;
        private Label l5;
        private Label l6;
        private Label l7;
        private Label l8;
        private Label l9;
        private Label l10;
        private Label s1;
        private Label s2;
        private Label s3;
    }
}