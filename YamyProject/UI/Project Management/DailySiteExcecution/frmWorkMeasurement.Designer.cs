using System.Windows.Forms;

namespace YamyProject.UI.Project_Management.DailySiteExcecution
{
    partial class frmWorkMeasurement
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

        private TextBox txtMeasurementNo;

        private DateTimePicker dtDate;

        private ComboBox cmbProject;
        private ComboBox cmbSite;
        private ComboBox cmbZone;

        private ComboBox cmbContractor;
        private ComboBox cmbEngineer;
        private ComboBox cmbConsultant;

        private ComboBox cmbReferenceType;

        private TextBox txtReferenceNo;

        private ComboBox cmbStatus;

        private TextBox txtRemarks;

        private TabControl tabMain;

        private TabPage tabMeasurement;
        private TabPage tabAttachment;
        private TabPage tabApproval;

        private DataGridView dgvMeasurement;
        private DataGridView dgvAttachment;
        private DataGridView dgvApproval;

        private GroupBox grpSummary;

        private TextBox txtTotalQty;
        private TextBox txtTotalAmount;

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
            this.txtMeasurementNo = new System.Windows.Forms.TextBox();
            this.l2 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.l3 = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.l4 = new System.Windows.Forms.Label();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.l5 = new System.Windows.Forms.Label();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.l6 = new System.Windows.Forms.Label();
            this.cmbContractor = new System.Windows.Forms.ComboBox();
            this.l7 = new System.Windows.Forms.Label();
            this.cmbEngineer = new System.Windows.Forms.ComboBox();
            this.l8 = new System.Windows.Forms.Label();
            this.cmbConsultant = new System.Windows.Forms.ComboBox();
            this.l9 = new System.Windows.Forms.Label();
            this.cmbReferenceType = new System.Windows.Forms.ComboBox();
            this.l10 = new System.Windows.Forms.Label();
            this.txtReferenceNo = new System.Windows.Forms.TextBox();
            this.l11 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.l12 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabMeasurement = new System.Windows.Forms.TabPage();
            this.dgvMeasurement = new System.Windows.Forms.DataGridView();
            this.tabAttachment = new System.Windows.Forms.TabPage();
            this.dgvAttachment = new System.Windows.Forms.DataGridView();
            this.tabApproval = new System.Windows.Forms.TabPage();
            this.dgvApproval = new System.Windows.Forms.DataGridView();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.s1 = new System.Windows.Forms.Label();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.s2 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
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
            this.tabMeasurement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasurement)).BeginInit();
            this.tabAttachment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachment)).BeginInit();
            this.tabApproval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproval)).BeginInit();
            this.grpSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
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
            this.lblTitle.Size = new System.Drawing.Size(271, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "WORK DONE / WORK MEASUREMENT";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.l1);
            this.grpHeader.Controls.Add(this.txtMeasurementNo);
            this.grpHeader.Controls.Add(this.l2);
            this.grpHeader.Controls.Add(this.dtDate);
            this.grpHeader.Controls.Add(this.l3);
            this.grpHeader.Controls.Add(this.cmbProject);
            this.grpHeader.Controls.Add(this.l4);
            this.grpHeader.Controls.Add(this.cmbSite);
            this.grpHeader.Controls.Add(this.l5);
            this.grpHeader.Controls.Add(this.cmbZone);
            this.grpHeader.Controls.Add(this.l6);
            this.grpHeader.Controls.Add(this.cmbContractor);
            this.grpHeader.Controls.Add(this.l7);
            this.grpHeader.Controls.Add(this.cmbEngineer);
            this.grpHeader.Controls.Add(this.l8);
            this.grpHeader.Controls.Add(this.cmbConsultant);
            this.grpHeader.Controls.Add(this.l9);
            this.grpHeader.Controls.Add(this.cmbReferenceType);
            this.grpHeader.Controls.Add(this.l10);
            this.grpHeader.Controls.Add(this.txtReferenceNo);
            this.grpHeader.Controls.Add(this.l11);
            this.grpHeader.Controls.Add(this.cmbStatus);
            this.grpHeader.Controls.Add(this.l12);
            this.grpHeader.Controls.Add(this.txtRemarks);
            this.grpHeader.Location = new System.Drawing.Point(10, 65);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1160, 180);
            this.grpHeader.TabIndex = 1;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Measurement Information";
            // 
            // l1
            // 
            this.l1.Location = new System.Drawing.Point(15, 30);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(110, 25);
            this.l1.TabIndex = 0;
            this.l1.Text = "Measurement No";
            // 
            // txtMeasurementNo
            // 
            this.txtMeasurementNo.Location = new System.Drawing.Point(130, 30);
            this.txtMeasurementNo.Name = "txtMeasurementNo";
            this.txtMeasurementNo.Size = new System.Drawing.Size(160, 20);
            this.txtMeasurementNo.TabIndex = 1;
            // 
            // l2
            // 
            this.l2.Location = new System.Drawing.Point(310, 30);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(40, 25);
            this.l2.TabIndex = 2;
            this.l2.Text = "Date";
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(355, 30);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(150, 20);
            this.dtDate.TabIndex = 3;
            // 
            // l3
            // 
            this.l3.Location = new System.Drawing.Point(530, 30);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(50, 25);
            this.l3.TabIndex = 4;
            this.l3.Text = "Project";
            // 
            // cmbProject
            // 
            this.cmbProject.Location = new System.Drawing.Point(585, 30);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(220, 21);
            this.cmbProject.TabIndex = 5;
            // 
            // l4
            // 
            this.l4.Location = new System.Drawing.Point(830, 30);
            this.l4.Name = "l4";
            this.l4.Size = new System.Drawing.Size(35, 25);
            this.l4.TabIndex = 6;
            this.l4.Text = "Site";
            // 
            // cmbSite
            // 
            this.cmbSite.Location = new System.Drawing.Point(870, 30);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(120, 21);
            this.cmbSite.TabIndex = 7;
            // 
            // l5
            // 
            this.l5.Location = new System.Drawing.Point(1010, 30);
            this.l5.Name = "l5";
            this.l5.Size = new System.Drawing.Size(40, 25);
            this.l5.TabIndex = 8;
            this.l5.Text = "Zone";
            // 
            // cmbZone
            // 
            this.cmbZone.Location = new System.Drawing.Point(1055, 30);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(90, 21);
            this.cmbZone.TabIndex = 9;
            // 
            // l6
            // 
            this.l6.Location = new System.Drawing.Point(15, 70);
            this.l6.Name = "l6";
            this.l6.Size = new System.Drawing.Size(80, 25);
            this.l6.TabIndex = 10;
            this.l6.Text = "Contractor";
            // 
            // cmbContractor
            // 
            this.cmbContractor.Location = new System.Drawing.Point(100, 70);
            this.cmbContractor.Name = "cmbContractor";
            this.cmbContractor.Size = new System.Drawing.Size(220, 21);
            this.cmbContractor.TabIndex = 11;
            // 
            // l7
            // 
            this.l7.Location = new System.Drawing.Point(340, 70);
            this.l7.Name = "l7";
            this.l7.Size = new System.Drawing.Size(65, 25);
            this.l7.TabIndex = 12;
            this.l7.Text = "Engineer";
            // 
            // cmbEngineer
            // 
            this.cmbEngineer.Location = new System.Drawing.Point(410, 70);
            this.cmbEngineer.Name = "cmbEngineer";
            this.cmbEngineer.Size = new System.Drawing.Size(220, 21);
            this.cmbEngineer.TabIndex = 13;
            // 
            // l8
            // 
            this.l8.Location = new System.Drawing.Point(650, 70);
            this.l8.Name = "l8";
            this.l8.Size = new System.Drawing.Size(70, 25);
            this.l8.TabIndex = 14;
            this.l8.Text = "Consultant";
            // 
            // cmbConsultant
            // 
            this.cmbConsultant.Location = new System.Drawing.Point(725, 70);
            this.cmbConsultant.Name = "cmbConsultant";
            this.cmbConsultant.Size = new System.Drawing.Size(220, 21);
            this.cmbConsultant.TabIndex = 15;
            // 
            // l9
            // 
            this.l9.Location = new System.Drawing.Point(970, 70);
            this.l9.Name = "l9";
            this.l9.Size = new System.Drawing.Size(70, 25);
            this.l9.TabIndex = 16;
            this.l9.Text = "Reference";
            // 
            // cmbReferenceType
            // 
            this.cmbReferenceType.Location = new System.Drawing.Point(1045, 70);
            this.cmbReferenceType.Name = "cmbReferenceType";
            this.cmbReferenceType.Size = new System.Drawing.Size(100, 21);
            this.cmbReferenceType.TabIndex = 17;
            // 
            // l10
            // 
            this.l10.Location = new System.Drawing.Point(15, 110);
            this.l10.Name = "l10";
            this.l10.Size = new System.Drawing.Size(90, 25);
            this.l10.TabIndex = 18;
            this.l10.Text = "Reference No";
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.Location = new System.Drawing.Point(110, 110);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(180, 20);
            this.txtReferenceNo.TabIndex = 19;
            // 
            // l11
            // 
            this.l11.Location = new System.Drawing.Point(320, 110);
            this.l11.Name = "l11";
            this.l11.Size = new System.Drawing.Size(50, 25);
            this.l11.TabIndex = 20;
            this.l11.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(375, 110);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 21);
            this.cmbStatus.TabIndex = 21;
            // 
            // l12
            // 
            this.l12.Location = new System.Drawing.Point(550, 110);
            this.l12.Name = "l12";
            this.l12.Size = new System.Drawing.Size(60, 25);
            this.l12.TabIndex = 22;
            this.l12.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(615, 110);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(530, 20);
            this.txtRemarks.TabIndex = 23;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabMeasurement);
            this.tabMain.Controls.Add(this.tabAttachment);
            this.tabMain.Controls.Add(this.tabApproval);
            this.tabMain.Location = new System.Drawing.Point(10, 250);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1160, 300);
            this.tabMain.TabIndex = 2;
            // 
            // tabMeasurement
            // 
            this.tabMeasurement.Controls.Add(this.dgvMeasurement);
            this.tabMeasurement.Location = new System.Drawing.Point(4, 22);
            this.tabMeasurement.Name = "tabMeasurement";
            this.tabMeasurement.Size = new System.Drawing.Size(1152, 274);
            this.tabMeasurement.TabIndex = 0;
            this.tabMeasurement.Text = "Measurement";
            // 
            // dgvMeasurement
            // 
            this.dgvMeasurement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMeasurement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMeasurement.Location = new System.Drawing.Point(0, 0);
            this.dgvMeasurement.Name = "dgvMeasurement";
            this.dgvMeasurement.Size = new System.Drawing.Size(1152, 274);
            this.dgvMeasurement.TabIndex = 0;
            // 
            // tabAttachment
            // 
            this.tabAttachment.Controls.Add(this.dgvAttachment);
            this.tabAttachment.Location = new System.Drawing.Point(4, 22);
            this.tabAttachment.Name = "tabAttachment";
            this.tabAttachment.Size = new System.Drawing.Size(1152, 274);
            this.tabAttachment.TabIndex = 1;
            this.tabAttachment.Text = "Attachments";
            // 
            // dgvAttachment
            // 
            this.dgvAttachment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAttachment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttachment.Location = new System.Drawing.Point(0, 0);
            this.dgvAttachment.Name = "dgvAttachment";
            this.dgvAttachment.Size = new System.Drawing.Size(1152, 274);
            this.dgvAttachment.TabIndex = 0;
            // 
            // tabApproval
            // 
            this.tabApproval.Controls.Add(this.dgvApproval);
            this.tabApproval.Location = new System.Drawing.Point(4, 22);
            this.tabApproval.Name = "tabApproval";
            this.tabApproval.Size = new System.Drawing.Size(1152, 274);
            this.tabApproval.TabIndex = 2;
            this.tabApproval.Text = "Approvals";
            // 
            // dgvApproval
            // 
            this.dgvApproval.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApproval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvApproval.Location = new System.Drawing.Point(0, 0);
            this.dgvApproval.Name = "dgvApproval";
            this.dgvApproval.Size = new System.Drawing.Size(1152, 274);
            this.dgvApproval.TabIndex = 0;
            // 
            // grpSummary
            // 
            this.grpSummary.Controls.Add(this.s1);
            this.grpSummary.Controls.Add(this.txtTotalQty);
            this.grpSummary.Controls.Add(this.s2);
            this.grpSummary.Controls.Add(this.txtTotalAmount);
            this.grpSummary.Location = new System.Drawing.Point(700, 560);
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
            this.s1.Size = new System.Drawing.Size(60, 25);
            this.s1.TabIndex = 0;
            this.s1.Text = "Total Qty";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Location = new System.Drawing.Point(80, 25);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(120, 20);
            this.txtTotalQty.TabIndex = 1;
            // 
            // s2
            // 
            this.s2.Location = new System.Drawing.Point(220, 30);
            this.s2.Name = "s2";
            this.s2.Size = new System.Drawing.Size(90, 25);
            this.s2.TabIndex = 2;
            this.s2.Text = "Total Amount";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(315, 25);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(130, 20);
            this.txtTotalAmount.TabIndex = 3;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(20, 575);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(120, 35);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "Calculate";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(160, 575);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 35);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "New";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(270, 575);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(380, 575);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 35);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(490, 575);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(600, 575);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(100, 35);
            this.btnApprove.TabIndex = 9;
            this.btnApprove.Text = "Approve";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(710, 575);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 35);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Print";
            // 
            // frmWorkMeasurement
            // 
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmWorkMeasurement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Work Measurement";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTop.ResumeLayout(false);
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabMeasurement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasurement)).EndInit();
            this.tabAttachment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachment)).EndInit();
            this.tabApproval.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproval)).EndInit();
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
        private Label l11;
        private Label l12;
        private Label s1;
        private Label s2;
    }
}