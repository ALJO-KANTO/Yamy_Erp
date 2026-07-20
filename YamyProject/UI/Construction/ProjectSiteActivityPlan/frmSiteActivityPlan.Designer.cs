using System.Windows.Forms;

namespace YamyProject.UI.Construction.ProjectSiteActivityPlan
{
    partial class frmSiteActivityPlan
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
        private Label lblProject;
        private Label lblDate;
        private ComboBox cmbProject;
        private DateTimePicker dtActivityDate;

        private GroupBox grpDetails;

        private Label lblZone;
        private Label lblActivity;
        private Label lblSupervisor;
        private Label lblLabor;
        private Label lblEquipment;
        private Label lblTarget;
        private Label lblUnit;
        private Label lblActual;
        private Label lblProgress;
        private Label lblWeather;
        private Label lblPriority;
        private Label lblStatus;
        private Label lblRemarks;

        private ComboBox cmbZone;
        private TextBox txtActivity;
        private TextBox txtSupervisor;
        private TextBox txtLabor;
        private TextBox txtEquipment;
        private TextBox txtTarget;
        private ComboBox cmbUnit;
        private TextBox txtActual;
        private TextBox txtProgress;
        private ComboBox cmbWeather;
        private ComboBox cmbPriority;
        private ComboBox cmbStatus;
        private TextBox txtRemarks;

        private Button btnNew;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;

        private DataGridView dgv;

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpHeader = new System.Windows.Forms.GroupBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtActivityDate = new System.Windows.Forms.DateTimePicker();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblZone = new System.Windows.Forms.Label();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.lblActivity = new System.Windows.Forms.Label();
            this.txtActivity = new System.Windows.Forms.TextBox();
            this.lblSupervisor = new System.Windows.Forms.Label();
            this.txtSupervisor = new System.Windows.Forms.TextBox();
            this.lblLabor = new System.Windows.Forms.Label();
            this.txtLabor = new System.Windows.Forms.TextBox();
            this.lblEquipment = new System.Windows.Forms.Label();
            this.txtEquipment = new System.Windows.Forms.TextBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.lblActual = new System.Windows.Forms.Label();
            this.txtActual = new System.Windows.Forms.TextBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.lblWeather = new System.Windows.Forms.Label();
            this.cmbWeather = new System.Windows.Forms.ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.grpHeader.SuspendLayout();
            this.grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1184, 55);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(194, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SITE ACTIVITY PLAN";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.lblProject);
            this.grpHeader.Controls.Add(this.cmbProject);
            this.grpHeader.Controls.Add(this.lblDate);
            this.grpHeader.Controls.Add(this.dtActivityDate);
            this.grpHeader.Location = new System.Drawing.Point(10, 65);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1160, 80);
            this.grpHeader.TabIndex = 1;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Plan Header";
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(15, 30);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(50, 25);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "Project";
            // 
            // cmbProject
            // 
            this.cmbProject.Location = new System.Drawing.Point(70, 25);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(320, 21);
            this.cmbProject.TabIndex = 1;
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(430, 30);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(40, 25);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date";
            // 
            // dtActivityDate
            // 
            this.dtActivityDate.Location = new System.Drawing.Point(470, 25);
            this.dtActivityDate.Name = "dtActivityDate";
            this.dtActivityDate.Size = new System.Drawing.Size(180, 20);
            this.dtActivityDate.TabIndex = 3;
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.lblZone);
            this.grpDetails.Controls.Add(this.cmbZone);
            this.grpDetails.Controls.Add(this.lblActivity);
            this.grpDetails.Controls.Add(this.txtActivity);
            this.grpDetails.Controls.Add(this.lblSupervisor);
            this.grpDetails.Controls.Add(this.txtSupervisor);
            this.grpDetails.Controls.Add(this.lblLabor);
            this.grpDetails.Controls.Add(this.txtLabor);
            this.grpDetails.Controls.Add(this.lblEquipment);
            this.grpDetails.Controls.Add(this.txtEquipment);
            this.grpDetails.Controls.Add(this.lblTarget);
            this.grpDetails.Controls.Add(this.txtTarget);
            this.grpDetails.Controls.Add(this.lblUnit);
            this.grpDetails.Controls.Add(this.cmbUnit);
            this.grpDetails.Controls.Add(this.lblActual);
            this.grpDetails.Controls.Add(this.txtActual);
            this.grpDetails.Controls.Add(this.lblProgress);
            this.grpDetails.Controls.Add(this.txtProgress);
            this.grpDetails.Controls.Add(this.lblWeather);
            this.grpDetails.Controls.Add(this.cmbWeather);
            this.grpDetails.Controls.Add(this.lblPriority);
            this.grpDetails.Controls.Add(this.cmbPriority);
            this.grpDetails.Controls.Add(this.lblStatus);
            this.grpDetails.Controls.Add(this.cmbStatus);
            this.grpDetails.Controls.Add(this.lblRemarks);
            this.grpDetails.Controls.Add(this.txtRemarks);
            this.grpDetails.Controls.Add(this.btnNew);
            this.grpDetails.Controls.Add(this.btnSave);
            this.grpDetails.Controls.Add(this.btnUpdate);
            this.grpDetails.Controls.Add(this.btnDelete);
            this.grpDetails.Controls.Add(this.btnClear);
            this.grpDetails.Location = new System.Drawing.Point(10, 150);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(1160, 280);
            this.grpDetails.TabIndex = 2;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Daily Activity Details";
            // 
            // lblZone
            // 
            this.lblZone.Location = new System.Drawing.Point(15, 30);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(60, 25);
            this.lblZone.TabIndex = 0;
            this.lblZone.Text = "Zone";
            // 
            // cmbZone
            // 
            this.cmbZone.Location = new System.Drawing.Point(80, 25);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(180, 21);
            this.cmbZone.TabIndex = 1;
            // 
            // lblActivity
            // 
            this.lblActivity.Location = new System.Drawing.Point(290, 30);
            this.lblActivity.Name = "lblActivity";
            this.lblActivity.Size = new System.Drawing.Size(60, 25);
            this.lblActivity.TabIndex = 2;
            this.lblActivity.Text = "Activity";
            // 
            // txtActivity
            // 
            this.txtActivity.Location = new System.Drawing.Point(355, 25);
            this.txtActivity.Name = "txtActivity";
            this.txtActivity.Size = new System.Drawing.Size(320, 20);
            this.txtActivity.TabIndex = 3;
            // 
            // lblSupervisor
            // 
            this.lblSupervisor.Location = new System.Drawing.Point(15, 70);
            this.lblSupervisor.Name = "lblSupervisor";
            this.lblSupervisor.Size = new System.Drawing.Size(75, 25);
            this.lblSupervisor.TabIndex = 4;
            this.lblSupervisor.Text = "Supervisor";
            // 
            // txtSupervisor
            // 
            this.txtSupervisor.Location = new System.Drawing.Point(80, 65);
            this.txtSupervisor.Name = "txtSupervisor";
            this.txtSupervisor.Size = new System.Drawing.Size(180, 20);
            this.txtSupervisor.TabIndex = 5;
            // 
            // lblLabor
            // 
            this.lblLabor.Location = new System.Drawing.Point(290, 70);
            this.lblLabor.Name = "lblLabor";
            this.lblLabor.Size = new System.Drawing.Size(50, 25);
            this.lblLabor.TabIndex = 6;
            this.lblLabor.Text = "Labor";
            // 
            // txtLabor
            // 
            this.txtLabor.Location = new System.Drawing.Point(355, 65);
            this.txtLabor.Name = "txtLabor";
            this.txtLabor.Size = new System.Drawing.Size(90, 20);
            this.txtLabor.TabIndex = 7;
            // 
            // lblEquipment
            // 
            this.lblEquipment.Location = new System.Drawing.Point(470, 70);
            this.lblEquipment.Name = "lblEquipment";
            this.lblEquipment.Size = new System.Drawing.Size(75, 25);
            this.lblEquipment.TabIndex = 8;
            this.lblEquipment.Text = "Equipment";
            // 
            // txtEquipment
            // 
            this.txtEquipment.Location = new System.Drawing.Point(550, 65);
            this.txtEquipment.Name = "txtEquipment";
            this.txtEquipment.Size = new System.Drawing.Size(125, 20);
            this.txtEquipment.TabIndex = 9;
            // 
            // lblTarget
            // 
            this.lblTarget.Location = new System.Drawing.Point(15, 110);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(50, 25);
            this.lblTarget.TabIndex = 10;
            this.lblTarget.Text = "Target";
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(80, 105);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(90, 20);
            this.txtTarget.TabIndex = 11;
            // 
            // lblUnit
            // 
            this.lblUnit.Location = new System.Drawing.Point(190, 110);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(35, 25);
            this.lblUnit.TabIndex = 12;
            this.lblUnit.Text = "Unit";
            // 
            // cmbUnit
            // 
            this.cmbUnit.Location = new System.Drawing.Point(230, 105);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(90, 21);
            this.cmbUnit.TabIndex = 13;
            // 
            // lblActual
            // 
            this.lblActual.Location = new System.Drawing.Point(340, 110);
            this.lblActual.Name = "lblActual";
            this.lblActual.Size = new System.Drawing.Size(45, 25);
            this.lblActual.TabIndex = 14;
            this.lblActual.Text = "Actual";
            // 
            // txtActual
            // 
            this.txtActual.Location = new System.Drawing.Point(390, 105);
            this.txtActual.Name = "txtActual";
            this.txtActual.Size = new System.Drawing.Size(90, 20);
            this.txtActual.TabIndex = 15;
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(500, 110);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(75, 25);
            this.lblProgress.TabIndex = 16;
            this.lblProgress.Text = "Progress %";
            // 
            // txtProgress
            // 
            this.txtProgress.Location = new System.Drawing.Point(580, 105);
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.Size = new System.Drawing.Size(95, 20);
            this.txtProgress.TabIndex = 17;
            // 
            // lblWeather
            // 
            this.lblWeather.Location = new System.Drawing.Point(15, 150);
            this.lblWeather.Name = "lblWeather";
            this.lblWeather.Size = new System.Drawing.Size(65, 25);
            this.lblWeather.TabIndex = 18;
            this.lblWeather.Text = "Weather";
            // 
            // cmbWeather
            // 
            this.cmbWeather.Location = new System.Drawing.Point(80, 145);
            this.cmbWeather.Name = "cmbWeather";
            this.cmbWeather.Size = new System.Drawing.Size(140, 21);
            this.cmbWeather.TabIndex = 19;
            // 
            // lblPriority
            // 
            this.lblPriority.Location = new System.Drawing.Point(250, 150);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(55, 25);
            this.lblPriority.TabIndex = 20;
            this.lblPriority.Text = "Priority";
            // 
            // cmbPriority
            // 
            this.cmbPriority.Location = new System.Drawing.Point(310, 145);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(120, 21);
            this.cmbPriority.TabIndex = 21;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(460, 150);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 25);
            this.lblStatus.TabIndex = 22;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(515, 145);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(160, 21);
            this.cmbStatus.TabIndex = 23;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Location = new System.Drawing.Point(15, 190);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(60, 25);
            this.lblRemarks.TabIndex = 24;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(80, 185);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(595, 55);
            this.txtRemarks.TabIndex = 25;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(860, 35);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(120, 35);
            this.btnNew.TabIndex = 26;
            this.btnNew.Text = "New";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1000, 35);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(860, 85);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 35);
            this.btnUpdate.TabIndex = 28;
            this.btnUpdate.Text = "Update";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1000, 85);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 35);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "Delete";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(930, 135);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 35);
            this.btnClear.TabIndex = 30;
            this.btnClear.Text = "Clear";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.Location = new System.Drawing.Point(10, 440);
            this.dgv.Name = "dgv";
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1160, 230);
            this.dgv.TabIndex = 3;
            // 
            // frmSiteActivityPlan
            // 
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSiteActivityPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Site Activity Plan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpHeader.ResumeLayout(false);
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }
    }
}