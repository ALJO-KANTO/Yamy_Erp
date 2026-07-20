using System.Windows.Forms;

namespace YamyProject.UI.Project_Management.DailySiteExcecution
{
    partial class frmDailyProgressUpdate
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

        private TextBox txtProgressNo;

        private DateTimePicker dtDate;

        private ComboBox cmbProject;
        private ComboBox cmbSite;
        private ComboBox cmbZone;

        private ComboBox cmbPreparedBy;
        private ComboBox cmbApprovedBy;

        private TextBox txtPlanned;
        private TextBox txtActual;
        private TextBox txtVariance;

        private ComboBox cmbStatus;

        private TextBox txtRemarks;

        private TabControl tabMain;

        private TabPage tabActivities;
        private TabPage tabDelays;
        private TabPage tabPhotos;

        private DataGridView dgvActivities;
        private DataGridView dgvDelays;
        private DataGridView dgvPhotos;

        private Button btnBrowsePhoto;

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
            this.txtProgressNo = new System.Windows.Forms.TextBox();
            this.l2 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.l3 = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.l4 = new System.Windows.Forms.Label();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.l5 = new System.Windows.Forms.Label();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.l6 = new System.Windows.Forms.Label();
            this.cmbPreparedBy = new System.Windows.Forms.ComboBox();
            this.l7 = new System.Windows.Forms.Label();
            this.cmbApprovedBy = new System.Windows.Forms.ComboBox();
            this.l8 = new System.Windows.Forms.Label();
            this.txtPlanned = new System.Windows.Forms.TextBox();
            this.l9 = new System.Windows.Forms.Label();
            this.txtActual = new System.Windows.Forms.TextBox();
            this.l10 = new System.Windows.Forms.Label();
            this.txtVariance = new System.Windows.Forms.TextBox();
            this.l11 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.l12 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabActivities = new System.Windows.Forms.TabPage();
            this.dgvActivities = new System.Windows.Forms.DataGridView();
            this.tabDelays = new System.Windows.Forms.TabPage();
            this.dgvDelays = new System.Windows.Forms.DataGridView();
            this.tabPhotos = new System.Windows.Forms.TabPage();
            this.dgvPhotos = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.grpHeader.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabActivities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivities)).BeginInit();
            this.tabDelays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelays)).BeginInit();
            this.tabPhotos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhotos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(78)))), ((int)(((byte)(99)))));
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
            this.lblTitle.Size = new System.Drawing.Size(346, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DAILY PROGRESS UPDATE";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.l1);
            this.grpHeader.Controls.Add(this.txtProgressNo);
            this.grpHeader.Controls.Add(this.l2);
            this.grpHeader.Controls.Add(this.dtDate);
            this.grpHeader.Controls.Add(this.l3);
            this.grpHeader.Controls.Add(this.cmbProject);
            this.grpHeader.Controls.Add(this.l4);
            this.grpHeader.Controls.Add(this.cmbSite);
            this.grpHeader.Controls.Add(this.l5);
            this.grpHeader.Controls.Add(this.cmbZone);
            this.grpHeader.Controls.Add(this.l6);
            this.grpHeader.Controls.Add(this.cmbPreparedBy);
            this.grpHeader.Controls.Add(this.l7);
            this.grpHeader.Controls.Add(this.cmbApprovedBy);
            this.grpHeader.Controls.Add(this.l8);
            this.grpHeader.Controls.Add(this.txtPlanned);
            this.grpHeader.Controls.Add(this.l9);
            this.grpHeader.Controls.Add(this.txtActual);
            this.grpHeader.Controls.Add(this.l10);
            this.grpHeader.Controls.Add(this.txtVariance);
            this.grpHeader.Controls.Add(this.l11);
            this.grpHeader.Controls.Add(this.cmbStatus);
            this.grpHeader.Controls.Add(this.l12);
            this.grpHeader.Controls.Add(this.txtRemarks);
            this.grpHeader.Location = new System.Drawing.Point(10, 65);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1160, 180);
            this.grpHeader.TabIndex = 1;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Progress Information";
            // 
            // l1
            // 
            this.l1.Location = new System.Drawing.Point(15, 30);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(80, 25);
            this.l1.TabIndex = 0;
            this.l1.Text = "Progress No";
            // 
            // txtProgressNo
            // 
            this.txtProgressNo.Location = new System.Drawing.Point(100, 30);
            this.txtProgressNo.Name = "txtProgressNo";
            this.txtProgressNo.Size = new System.Drawing.Size(160, 20);
            this.txtProgressNo.TabIndex = 1;
            // 
            // l2
            // 
            this.l2.Location = new System.Drawing.Point(280, 30);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(40, 25);
            this.l2.TabIndex = 2;
            this.l2.Text = "Date";
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(325, 30);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(150, 20);
            this.dtDate.TabIndex = 3;
            // 
            // l3
            // 
            this.l3.Location = new System.Drawing.Point(500, 30);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(50, 25);
            this.l3.TabIndex = 4;
            this.l3.Text = "Project";
            // 
            // cmbProject
            // 
            this.cmbProject.Location = new System.Drawing.Point(555, 30);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(220, 21);
            this.cmbProject.TabIndex = 5;
            // 
            // l4
            // 
            this.l4.Location = new System.Drawing.Point(800, 30);
            this.l4.Name = "l4";
            this.l4.Size = new System.Drawing.Size(35, 25);
            this.l4.TabIndex = 6;
            this.l4.Text = "Site";
            // 
            // cmbSite
            // 
            this.cmbSite.Location = new System.Drawing.Point(840, 30);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(150, 21);
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
            this.l6.Text = "Prepared By";
            // 
            // cmbPreparedBy
            // 
            this.cmbPreparedBy.Location = new System.Drawing.Point(100, 70);
            this.cmbPreparedBy.Name = "cmbPreparedBy";
            this.cmbPreparedBy.Size = new System.Drawing.Size(220, 21);
            this.cmbPreparedBy.TabIndex = 11;
            // 
            // l7
            // 
            this.l7.Location = new System.Drawing.Point(340, 70);
            this.l7.Name = "l7";
            this.l7.Size = new System.Drawing.Size(85, 25);
            this.l7.TabIndex = 12;
            this.l7.Text = "Approved By";
            // 
            // cmbApprovedBy
            // 
            this.cmbApprovedBy.Location = new System.Drawing.Point(430, 70);
            this.cmbApprovedBy.Name = "cmbApprovedBy";
            this.cmbApprovedBy.Size = new System.Drawing.Size(220, 21);
            this.cmbApprovedBy.TabIndex = 13;
            // 
            // l8
            // 
            this.l8.Location = new System.Drawing.Point(680, 70);
            this.l8.Name = "l8";
            this.l8.Size = new System.Drawing.Size(70, 25);
            this.l8.TabIndex = 14;
            this.l8.Text = "Planned %";
            // 
            // txtPlanned
            // 
            this.txtPlanned.Location = new System.Drawing.Point(755, 70);
            this.txtPlanned.Name = "txtPlanned";
            this.txtPlanned.Size = new System.Drawing.Size(80, 20);
            this.txtPlanned.TabIndex = 15;
            // 
            // l9
            // 
            this.l9.Location = new System.Drawing.Point(850, 70);
            this.l9.Name = "l9";
            this.l9.Size = new System.Drawing.Size(70, 25);
            this.l9.TabIndex = 16;
            this.l9.Text = "Actual %";
            // 
            // txtActual
            // 
            this.txtActual.Location = new System.Drawing.Point(920, 70);
            this.txtActual.Name = "txtActual";
            this.txtActual.Size = new System.Drawing.Size(80, 20);
            this.txtActual.TabIndex = 17;
            // 
            // l10
            // 
            this.l10.Location = new System.Drawing.Point(1015, 70);
            this.l10.Name = "l10";
            this.l10.Size = new System.Drawing.Size(60, 25);
            this.l10.TabIndex = 18;
            this.l10.Text = "Variance";
            // 
            // txtVariance
            // 
            this.txtVariance.Location = new System.Drawing.Point(1080, 70);
            this.txtVariance.Name = "txtVariance";
            this.txtVariance.Size = new System.Drawing.Size(65, 20);
            this.txtVariance.TabIndex = 19;
            // 
            // l11
            // 
            this.l11.Location = new System.Drawing.Point(15, 110);
            this.l11.Name = "l11";
            this.l11.Size = new System.Drawing.Size(50, 25);
            this.l11.TabIndex = 20;
            this.l11.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(70, 110);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 21);
            this.cmbStatus.TabIndex = 21;
            // 
            // l12
            // 
            this.l12.Location = new System.Drawing.Point(240, 110);
            this.l12.Name = "l12";
            this.l12.Size = new System.Drawing.Size(60, 25);
            this.l12.TabIndex = 22;
            this.l12.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(305, 110);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(840, 20);
            this.txtRemarks.TabIndex = 23;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabActivities);
            this.tabMain.Controls.Add(this.tabDelays);
            this.tabMain.Controls.Add(this.tabPhotos);
            this.tabMain.Location = new System.Drawing.Point(10, 250);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1160, 310);
            this.tabMain.TabIndex = 2;
            // 
            // tabActivities
            // 
            this.tabActivities.Controls.Add(this.dgvActivities);
            this.tabActivities.Location = new System.Drawing.Point(4, 22);
            this.tabActivities.Name = "tabActivities";
            this.tabActivities.Size = new System.Drawing.Size(1152, 284);
            this.tabActivities.TabIndex = 0;
            this.tabActivities.Text = "Activities";
            // 
            // dgvActivities
            // 
            this.dgvActivities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActivities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActivities.Location = new System.Drawing.Point(0, 0);
            this.dgvActivities.Name = "dgvActivities";
            this.dgvActivities.RowHeadersVisible = false;
            this.dgvActivities.Size = new System.Drawing.Size(1152, 284);
            this.dgvActivities.TabIndex = 0;
            // 
            // tabDelays
            // 
            this.tabDelays.Controls.Add(this.dgvDelays);
            this.tabDelays.Location = new System.Drawing.Point(4, 22);
            this.tabDelays.Name = "tabDelays";
            this.tabDelays.Size = new System.Drawing.Size(1152, 284);
            this.tabDelays.TabIndex = 1;
            this.tabDelays.Text = "Delays";
            // 
            // dgvDelays
            // 
            this.dgvDelays.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDelays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDelays.Location = new System.Drawing.Point(0, 0);
            this.dgvDelays.Name = "dgvDelays";
            this.dgvDelays.Size = new System.Drawing.Size(1152, 284);
            this.dgvDelays.TabIndex = 0;
            // 
            // tabPhotos
            // 
            this.tabPhotos.Controls.Add(this.dgvPhotos);
            this.tabPhotos.Location = new System.Drawing.Point(4, 22);
            this.tabPhotos.Name = "tabPhotos";
            this.tabPhotos.Size = new System.Drawing.Size(1152, 284);
            this.tabPhotos.TabIndex = 2;
            this.tabPhotos.Text = "Photos";
            // 
            // dgvPhotos
            // 
            this.dgvPhotos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhotos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhotos.Location = new System.Drawing.Point(0, 0);
            this.dgvPhotos.Name = "dgvPhotos";
            this.dgvPhotos.Size = new System.Drawing.Size(1152, 284);
            this.dgvPhotos.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(220, 580);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(110, 35);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(340, 580);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(460, 580);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 35);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(580, 580);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 35);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(700, 580);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(110, 35);
            this.btnApprove.TabIndex = 7;
            this.btnApprove.Text = "Approve";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(820, 580);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(110, 35);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print";
            // 
            // frmDailyProgressUpdate
            // 
            this.ClientSize = new System.Drawing.Size(1184, 661);
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
            this.Name = "frmDailyProgressUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily Progress Update";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTop.ResumeLayout(false);
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabActivities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivities)).EndInit();
            this.tabDelays.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelays)).EndInit();
            this.tabPhotos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhotos)).EndInit();
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
    }
}