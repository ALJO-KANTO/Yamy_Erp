using System.Windows.Forms;

namespace YamyProject.UI.Project_Management.DailySiteExcecution
{
    partial class frmDelayHindranceLog
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

        private TextBox txtDelayNo;

        private DateTimePicker dtDate;

        private ComboBox cmbProject;
        private ComboBox cmbSite;
        private ComboBox cmbZone;

        private ComboBox cmbReportedBy;

        private ComboBox cmbCategory;
        private ComboBox cmbSeverity;

        private TextBox txtAffectedArea;
        private TextBox txtAffectedActivity;

        private DateTimePicker dtStart;
        private DateTimePicker dtEnd;

        private TextBox txtDelayHours;

        private ComboBox cmbResponsibleParty;

        private ComboBox cmbWeather;

        private TextBox txtCostImpact;
        private TextBox txtExtensionDays;

        private ComboBox cmbStatus;

        private RichTextBox txtImpact;
        private RichTextBox txtCorrective;
        private RichTextBox txtPreventive;
        private RichTextBox txtRemarks;

        private TabControl tabMain;

        private TabPage tabFollowup;
        private TabPage tabAttachment;

        private DataGridView dgvFollowup;
        private DataGridView dgvAttachment;

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
            this.txtDelayNo = new System.Windows.Forms.TextBox();
            this.l2 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.l3 = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.l4 = new System.Windows.Forms.Label();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.l5 = new System.Windows.Forms.Label();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.l6 = new System.Windows.Forms.Label();
            this.cmbReportedBy = new System.Windows.Forms.ComboBox();
            this.l7 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.l8 = new System.Windows.Forms.Label();
            this.cmbSeverity = new System.Windows.Forms.ComboBox();
            this.l9 = new System.Windows.Forms.Label();
            this.cmbResponsibleParty = new System.Windows.Forms.ComboBox();
            this.l10 = new System.Windows.Forms.Label();
            this.txtAffectedArea = new System.Windows.Forms.TextBox();
            this.l11 = new System.Windows.Forms.Label();
            this.txtAffectedActivity = new System.Windows.Forms.TextBox();
            this.l12 = new System.Windows.Forms.Label();
            this.cmbWeather = new System.Windows.Forms.ComboBox();
            this.l13 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.l14 = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.l15 = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.l16 = new System.Windows.Forms.Label();
            this.txtDelayHours = new System.Windows.Forms.TextBox();
            this.l17 = new System.Windows.Forms.Label();
            this.txtCostImpact = new System.Windows.Forms.TextBox();
            this.l18 = new System.Windows.Forms.Label();
            this.txtExtensionDays = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.l19 = new System.Windows.Forms.Label();
            this.txtImpact = new System.Windows.Forms.RichTextBox();
            this.l20 = new System.Windows.Forms.Label();
            this.txtCorrective = new System.Windows.Forms.RichTextBox();
            this.l21 = new System.Windows.Forms.Label();
            this.txtPreventive = new System.Windows.Forms.RichTextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabFollowup = new System.Windows.Forms.TabPage();
            this.dgvFollowup = new System.Windows.Forms.DataGridView();
            this.tabAttachment = new System.Windows.Forms.TabPage();
            this.dgvAttachment = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.grpHeader.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabFollowup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFollowup)).BeginInit();
            this.tabAttachment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachment)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
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
            this.lblTitle.Size = new System.Drawing.Size(355, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DELAY / HINDRANCE LOG";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.l1);
            this.grpHeader.Controls.Add(this.txtDelayNo);
            this.grpHeader.Controls.Add(this.l2);
            this.grpHeader.Controls.Add(this.dtDate);
            this.grpHeader.Controls.Add(this.l3);
            this.grpHeader.Controls.Add(this.cmbProject);
            this.grpHeader.Controls.Add(this.l4);
            this.grpHeader.Controls.Add(this.cmbSite);
            this.grpHeader.Controls.Add(this.l5);
            this.grpHeader.Controls.Add(this.cmbZone);
            this.grpHeader.Controls.Add(this.l6);
            this.grpHeader.Controls.Add(this.cmbReportedBy);
            this.grpHeader.Controls.Add(this.l7);
            this.grpHeader.Controls.Add(this.cmbCategory);
            this.grpHeader.Controls.Add(this.l8);
            this.grpHeader.Controls.Add(this.cmbSeverity);
            this.grpHeader.Controls.Add(this.l9);
            this.grpHeader.Controls.Add(this.cmbResponsibleParty);
            this.grpHeader.Controls.Add(this.l10);
            this.grpHeader.Controls.Add(this.txtAffectedArea);
            this.grpHeader.Controls.Add(this.l11);
            this.grpHeader.Controls.Add(this.txtAffectedActivity);
            this.grpHeader.Controls.Add(this.l12);
            this.grpHeader.Controls.Add(this.cmbWeather);
            this.grpHeader.Controls.Add(this.l13);
            this.grpHeader.Controls.Add(this.cmbStatus);
            this.grpHeader.Controls.Add(this.l14);
            this.grpHeader.Controls.Add(this.dtStart);
            this.grpHeader.Controls.Add(this.l15);
            this.grpHeader.Controls.Add(this.dtEnd);
            this.grpHeader.Controls.Add(this.l16);
            this.grpHeader.Controls.Add(this.txtDelayHours);
            this.grpHeader.Controls.Add(this.l17);
            this.grpHeader.Controls.Add(this.txtCostImpact);
            this.grpHeader.Controls.Add(this.l18);
            this.grpHeader.Controls.Add(this.txtExtensionDays);
            this.grpHeader.Controls.Add(this.btnCalculate);
            this.grpHeader.Controls.Add(this.l19);
            this.grpHeader.Controls.Add(this.txtImpact);
            this.grpHeader.Controls.Add(this.l20);
            this.grpHeader.Controls.Add(this.txtCorrective);
            this.grpHeader.Controls.Add(this.l21);
            this.grpHeader.Controls.Add(this.txtPreventive);
            this.grpHeader.Location = new System.Drawing.Point(10, 65);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1160, 380);
            this.grpHeader.TabIndex = 1;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Delay / Hindrance Information";
            // 
            // l1
            // 
            this.l1.Location = new System.Drawing.Point(15, 30);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(70, 25);
            this.l1.TabIndex = 0;
            this.l1.Text = "Delay No";
            // 
            // txtDelayNo
            // 
            this.txtDelayNo.Location = new System.Drawing.Point(90, 30);
            this.txtDelayNo.Name = "txtDelayNo";
            this.txtDelayNo.Size = new System.Drawing.Size(150, 20);
            this.txtDelayNo.TabIndex = 1;
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
            this.l6.Size = new System.Drawing.Size(80, 25);
            this.l6.TabIndex = 10;
            this.l6.Text = "Reported By";
            // 
            // cmbReportedBy
            // 
            this.cmbReportedBy.Location = new System.Drawing.Point(90, 70);
            this.cmbReportedBy.Name = "cmbReportedBy";
            this.cmbReportedBy.Size = new System.Drawing.Size(220, 21);
            this.cmbReportedBy.TabIndex = 11;
            // 
            // l7
            // 
            this.l7.Location = new System.Drawing.Point(340, 70);
            this.l7.Name = "l7";
            this.l7.Size = new System.Drawing.Size(60, 25);
            this.l7.TabIndex = 12;
            this.l7.Text = "Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Location = new System.Drawing.Point(405, 70);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(180, 21);
            this.cmbCategory.TabIndex = 13;
            // 
            // l8
            // 
            this.l8.Location = new System.Drawing.Point(610, 70);
            this.l8.Name = "l8";
            this.l8.Size = new System.Drawing.Size(60, 25);
            this.l8.TabIndex = 14;
            this.l8.Text = "Severity";
            // 
            // cmbSeverity
            // 
            this.cmbSeverity.Location = new System.Drawing.Point(675, 70);
            this.cmbSeverity.Name = "cmbSeverity";
            this.cmbSeverity.Size = new System.Drawing.Size(140, 21);
            this.cmbSeverity.TabIndex = 15;
            // 
            // l9
            // 
            this.l9.Location = new System.Drawing.Point(835, 70);
            this.l9.Name = "l9";
            this.l9.Size = new System.Drawing.Size(80, 25);
            this.l9.TabIndex = 16;
            this.l9.Text = "Responsible";
            // 
            // cmbResponsibleParty
            // 
            this.cmbResponsibleParty.Location = new System.Drawing.Point(920, 70);
            this.cmbResponsibleParty.Name = "cmbResponsibleParty";
            this.cmbResponsibleParty.Size = new System.Drawing.Size(220, 21);
            this.cmbResponsibleParty.TabIndex = 17;
            // 
            // l10
            // 
            this.l10.Location = new System.Drawing.Point(15, 110);
            this.l10.Name = "l10";
            this.l10.Size = new System.Drawing.Size(90, 25);
            this.l10.TabIndex = 18;
            this.l10.Text = "Affected Area";
            // 
            // txtAffectedArea
            // 
            this.txtAffectedArea.Location = new System.Drawing.Point(110, 110);
            this.txtAffectedArea.Name = "txtAffectedArea";
            this.txtAffectedArea.Size = new System.Drawing.Size(250, 20);
            this.txtAffectedArea.TabIndex = 19;
            // 
            // l11
            // 
            this.l11.Location = new System.Drawing.Point(390, 110);
            this.l11.Name = "l11";
            this.l11.Size = new System.Drawing.Size(50, 25);
            this.l11.TabIndex = 20;
            this.l11.Text = "Activity";
            // 
            // txtAffectedActivity
            // 
            this.txtAffectedActivity.Location = new System.Drawing.Point(445, 110);
            this.txtAffectedActivity.Name = "txtAffectedActivity";
            this.txtAffectedActivity.Size = new System.Drawing.Size(250, 20);
            this.txtAffectedActivity.TabIndex = 21;
            // 
            // l12
            // 
            this.l12.Location = new System.Drawing.Point(720, 110);
            this.l12.Name = "l12";
            this.l12.Size = new System.Drawing.Size(60, 25);
            this.l12.TabIndex = 22;
            this.l12.Text = "Weather";
            // 
            // cmbWeather
            // 
            this.cmbWeather.Location = new System.Drawing.Point(785, 110);
            this.cmbWeather.Name = "cmbWeather";
            this.cmbWeather.Size = new System.Drawing.Size(150, 21);
            this.cmbWeather.TabIndex = 23;
            // 
            // l13
            // 
            this.l13.Location = new System.Drawing.Point(960, 110);
            this.l13.Name = "l13";
            this.l13.Size = new System.Drawing.Size(50, 25);
            this.l13.TabIndex = 24;
            this.l13.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(1015, 100);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(120, 21);
            this.cmbStatus.TabIndex = 25;
            // 
            // l14
            // 
            this.l14.Location = new System.Drawing.Point(15, 150);
            this.l14.Name = "l14";
            this.l14.Size = new System.Drawing.Size(50, 25);
            this.l14.TabIndex = 26;
            this.l14.Text = "Start";
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(70, 150);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(180, 20);
            this.dtStart.TabIndex = 27;
            // 
            // l15
            // 
            this.l15.Location = new System.Drawing.Point(280, 150);
            this.l15.Name = "l15";
            this.l15.Size = new System.Drawing.Size(40, 25);
            this.l15.TabIndex = 28;
            this.l15.Text = "End";
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(325, 150);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(180, 20);
            this.dtEnd.TabIndex = 29;
            // 
            // l16
            // 
            this.l16.Location = new System.Drawing.Point(530, 150);
            this.l16.Name = "l16";
            this.l16.Size = new System.Drawing.Size(80, 25);
            this.l16.TabIndex = 30;
            this.l16.Text = "Delay Hours";
            // 
            // txtDelayHours
            // 
            this.txtDelayHours.Location = new System.Drawing.Point(615, 150);
            this.txtDelayHours.Name = "txtDelayHours";
            this.txtDelayHours.Size = new System.Drawing.Size(100, 20);
            this.txtDelayHours.TabIndex = 31;
            // 
            // l17
            // 
            this.l17.Location = new System.Drawing.Point(840, 150);
            this.l17.Name = "l17";
            this.l17.Size = new System.Drawing.Size(80, 25);
            this.l17.TabIndex = 32;
            this.l17.Text = "Cost Impact";
            // 
            // txtCostImpact
            // 
            this.txtCostImpact.Location = new System.Drawing.Point(925, 150);
            this.txtCostImpact.Name = "txtCostImpact";
            this.txtCostImpact.Size = new System.Drawing.Size(100, 20);
            this.txtCostImpact.TabIndex = 33;
            // 
            // l18
            // 
            this.l18.Location = new System.Drawing.Point(1030, 150);
            this.l18.Name = "l18";
            this.l18.Size = new System.Drawing.Size(70, 25);
            this.l18.TabIndex = 34;
            this.l18.Text = "EOT Days";
            // 
            // txtExtensionDays
            // 
            this.txtExtensionDays.Location = new System.Drawing.Point(1100, 150);
            this.txtExtensionDays.Name = "txtExtensionDays";
            this.txtExtensionDays.Size = new System.Drawing.Size(50, 20);
            this.txtExtensionDays.TabIndex = 35;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(725, 150);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(100, 28);
            this.btnCalculate.TabIndex = 36;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.Click += new System.EventHandler(this.BtnCalculate_Click);
            // 
            // l19
            // 
            this.l19.Location = new System.Drawing.Point(15, 195);
            this.l19.Name = "l19";
            this.l19.Size = new System.Drawing.Size(60, 25);
            this.l19.TabIndex = 37;
            this.l19.Text = "Impact";
            // 
            // txtImpact
            // 
            this.txtImpact.Location = new System.Drawing.Point(70, 195);
            this.txtImpact.Name = "txtImpact";
            this.txtImpact.Size = new System.Drawing.Size(320, 60);
            this.txtImpact.TabIndex = 38;
            this.txtImpact.Text = "";
            // 
            // l20
            // 
            this.l20.Location = new System.Drawing.Point(410, 195);
            this.l20.Name = "l20";
            this.l20.Size = new System.Drawing.Size(70, 25);
            this.l20.TabIndex = 39;
            this.l20.Text = "Corrective";
            // 
            // txtCorrective
            // 
            this.txtCorrective.Location = new System.Drawing.Point(485, 195);
            this.txtCorrective.Name = "txtCorrective";
            this.txtCorrective.Size = new System.Drawing.Size(320, 60);
            this.txtCorrective.TabIndex = 40;
            this.txtCorrective.Text = "";
            // 
            // l21
            // 
            this.l21.Location = new System.Drawing.Point(830, 195);
            this.l21.Name = "l21";
            this.l21.Size = new System.Drawing.Size(70, 25);
            this.l21.TabIndex = 41;
            this.l21.Text = "Preventive";
            // 
            // txtPreventive
            // 
            this.txtPreventive.Location = new System.Drawing.Point(905, 195);
            this.txtPreventive.Name = "txtPreventive";
            this.txtPreventive.Size = new System.Drawing.Size(240, 60);
            this.txtPreventive.TabIndex = 42;
            this.txtPreventive.Text = "";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabFollowup);
            this.tabMain.Controls.Add(this.tabAttachment);
            this.tabMain.Location = new System.Drawing.Point(10, 450);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1160, 170);
            this.tabMain.TabIndex = 2;
            // 
            // tabFollowup
            // 
            this.tabFollowup.Controls.Add(this.dgvFollowup);
            this.tabFollowup.Location = new System.Drawing.Point(4, 22);
            this.tabFollowup.Name = "tabFollowup";
            this.tabFollowup.Size = new System.Drawing.Size(1152, 144);
            this.tabFollowup.TabIndex = 0;
            this.tabFollowup.Text = "Follow-up";
            // 
            // dgvFollowup
            // 
            this.dgvFollowup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFollowup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFollowup.Location = new System.Drawing.Point(0, 0);
            this.dgvFollowup.Name = "dgvFollowup";
            this.dgvFollowup.Size = new System.Drawing.Size(1152, 144);
            this.dgvFollowup.TabIndex = 0;
            // 
            // tabAttachment
            // 
            this.tabAttachment.Controls.Add(this.dgvAttachment);
            this.tabAttachment.Location = new System.Drawing.Point(4, 22);
            this.tabAttachment.Name = "tabAttachment";
            this.tabAttachment.Size = new System.Drawing.Size(1152, 144);
            this.tabAttachment.TabIndex = 1;
            this.tabAttachment.Text = "Attachments";
            // 
            // dgvAttachment
            // 
            this.dgvAttachment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAttachment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttachment.Location = new System.Drawing.Point(0, 0);
            this.dgvAttachment.Name = "dgvAttachment";
            this.dgvAttachment.Size = new System.Drawing.Size(1152, 144);
            this.dgvAttachment.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(20, 630);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 35);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(130, 630);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(240, 630);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 35);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(350, 630);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(460, 630);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(100, 35);
            this.btnApprove.TabIndex = 7;
            this.btnApprove.Text = "Approve";
            this.btnApprove.Click += new System.EventHandler(this.BtnApprove_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(570, 630);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 35);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print";
            // 
            // frmDelayHindranceLog
            // 
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDelayHindranceLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delay / Hindrance Log";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDelayHindranceLog_Load);
            this.pnlTop.ResumeLayout(false);
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabFollowup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFollowup)).EndInit();
            this.tabAttachment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachment)).EndInit();
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
        private Label l11;
        private Label l12;
        private Label l13;
        private Label l14;
        private Label l15;
        private Label l16;
        private Label l17;
        private Label l18;
        private Label l19;
        private Label l20;
        private Label l21;
    }
}