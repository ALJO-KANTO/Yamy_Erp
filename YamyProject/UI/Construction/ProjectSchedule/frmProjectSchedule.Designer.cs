using System.Windows.Forms;

namespace YamyProject.UI.Construction.ProjectSchedule
{
    partial class frmProjectSchedule
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
        private ComboBox cmbProject;

        private GroupBox grpEntry;

        private Label lblCode;
        private Label lblName;
        private Label lblWBS;
        private Label lblPred;
        private Label lblDuration;
        private Label lblStart;
        private Label lblEnd;
        private Label lblProgress;
        private Label lblResp;
        private Label lblResource;
        private Label lblPriority;
        private Label lblStatus;
        private Label lblRemarks;

        private TextBox txtCode;
        private TextBox txtName;
        private TextBox txtWBS;
        private TextBox txtPred;
        private TextBox txtDuration;
        private DateTimePicker dtStart;
        private DateTimePicker dtEnd;
        private TextBox txtProgress;
        private TextBox txtResp;
        private TextBox txtResource;
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
            this.grpEntry = new System.Windows.Forms.GroupBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblWBS = new System.Windows.Forms.Label();
            this.txtWBS = new System.Windows.Forms.TextBox();
            this.lblPred = new System.Windows.Forms.Label();
            this.txtPred = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.lblProgress = new System.Windows.Forms.Label();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.lblResp = new System.Windows.Forms.Label();
            this.txtResp = new System.Windows.Forms.TextBox();
            this.lblResource = new System.Windows.Forms.Label();
            this.txtResource = new System.Windows.Forms.TextBox();
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
            this.grpEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
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
            this.lblTitle.Size = new System.Drawing.Size(192, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "PROJECT SCHEDULE";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.lblProject);
            this.grpHeader.Controls.Add(this.cmbProject);
            this.grpHeader.Location = new System.Drawing.Point(10, 65);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1160, 70);
            this.grpHeader.TabIndex = 1;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Project Selection";
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(15, 30);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(60, 23);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "Project";
            // 
            // cmbProject
            // 
            this.cmbProject.Location = new System.Drawing.Point(80, 25);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(320, 21);
            this.cmbProject.TabIndex = 1;
            // 
            // grpEntry
            // 
            this.grpEntry.Controls.Add(this.lblCode);
            this.grpEntry.Controls.Add(this.txtCode);
            this.grpEntry.Controls.Add(this.lblName);
            this.grpEntry.Controls.Add(this.txtName);
            this.grpEntry.Controls.Add(this.lblWBS);
            this.grpEntry.Controls.Add(this.txtWBS);
            this.grpEntry.Controls.Add(this.lblPred);
            this.grpEntry.Controls.Add(this.txtPred);
            this.grpEntry.Controls.Add(this.lblDuration);
            this.grpEntry.Controls.Add(this.txtDuration);
            this.grpEntry.Controls.Add(this.lblStart);
            this.grpEntry.Controls.Add(this.dtStart);
            this.grpEntry.Controls.Add(this.lblEnd);
            this.grpEntry.Controls.Add(this.dtEnd);
            this.grpEntry.Controls.Add(this.lblProgress);
            this.grpEntry.Controls.Add(this.txtProgress);
            this.grpEntry.Controls.Add(this.lblResp);
            this.grpEntry.Controls.Add(this.txtResp);
            this.grpEntry.Controls.Add(this.lblResource);
            this.grpEntry.Controls.Add(this.txtResource);
            this.grpEntry.Controls.Add(this.lblPriority);
            this.grpEntry.Controls.Add(this.cmbPriority);
            this.grpEntry.Controls.Add(this.lblStatus);
            this.grpEntry.Controls.Add(this.cmbStatus);
            this.grpEntry.Controls.Add(this.lblRemarks);
            this.grpEntry.Controls.Add(this.txtRemarks);
            this.grpEntry.Controls.Add(this.btnNew);
            this.grpEntry.Controls.Add(this.btnSave);
            this.grpEntry.Controls.Add(this.btnUpdate);
            this.grpEntry.Controls.Add(this.btnDelete);
            this.grpEntry.Controls.Add(this.btnClear);
            this.grpEntry.Location = new System.Drawing.Point(10, 140);
            this.grpEntry.Name = "grpEntry";
            this.grpEntry.Size = new System.Drawing.Size(1160, 270);
            this.grpEntry.TabIndex = 2;
            this.grpEntry.TabStop = false;
            this.grpEntry.Text = "Schedule Entry";
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(15, 30);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(70, 25);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Code";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(90, 25);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(120, 20);
            this.txtCode.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(230, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 25);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Activity";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(300, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 20);
            this.txtName.TabIndex = 3;
            // 
            // lblWBS
            // 
            this.lblWBS.Location = new System.Drawing.Point(620, 30);
            this.lblWBS.Name = "lblWBS";
            this.lblWBS.Size = new System.Drawing.Size(50, 25);
            this.lblWBS.TabIndex = 4;
            this.lblWBS.Text = "WBS";
            // 
            // txtWBS
            // 
            this.txtWBS.Location = new System.Drawing.Point(670, 25);
            this.txtWBS.Name = "txtWBS";
            this.txtWBS.Size = new System.Drawing.Size(120, 20);
            this.txtWBS.TabIndex = 5;
            // 
            // lblPred
            // 
            this.lblPred.Location = new System.Drawing.Point(810, 30);
            this.lblPred.Name = "lblPred";
            this.lblPred.Size = new System.Drawing.Size(90, 25);
            this.lblPred.TabIndex = 6;
            this.lblPred.Text = "Predecessor";
            // 
            // txtPred
            // 
            this.txtPred.Location = new System.Drawing.Point(905, 25);
            this.txtPred.Name = "txtPred";
            this.txtPred.Size = new System.Drawing.Size(120, 20);
            this.txtPred.TabIndex = 7;
            // 
            // lblDuration
            // 
            this.lblDuration.Location = new System.Drawing.Point(15, 70);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(70, 25);
            this.lblDuration.TabIndex = 8;
            this.lblDuration.Text = "Duration";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(90, 65);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(120, 20);
            this.txtDuration.TabIndex = 9;
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(230, 70);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(64, 25);
            this.lblStart.TabIndex = 10;
            this.lblStart.Text = "Start";
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(300, 65);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(150, 20);
            this.dtStart.TabIndex = 11;
            // 
            // lblEnd
            // 
            this.lblEnd.Location = new System.Drawing.Point(470, 70);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(50, 25);
            this.lblEnd.TabIndex = 12;
            this.lblEnd.Text = "End";
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(520, 65);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(150, 20);
            this.dtEnd.TabIndex = 13;
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(700, 70);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(80, 25);
            this.lblProgress.TabIndex = 14;
            this.lblProgress.Text = "Progress %";
            // 
            // txtProgress
            // 
            this.txtProgress.Location = new System.Drawing.Point(790, 65);
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.Size = new System.Drawing.Size(100, 20);
            this.txtProgress.TabIndex = 15;
            // 
            // lblResp
            // 
            this.lblResp.Location = new System.Drawing.Point(15, 110);
            this.lblResp.Name = "lblResp";
            this.lblResp.Size = new System.Drawing.Size(70, 25);
            this.lblResp.TabIndex = 16;
            this.lblResp.Text = "Responsible";
            // 
            // txtResp
            // 
            this.txtResp.Location = new System.Drawing.Point(90, 105);
            this.txtResp.Name = "txtResp";
            this.txtResp.Size = new System.Drawing.Size(220, 20);
            this.txtResp.TabIndex = 17;
            // 
            // lblResource
            // 
            this.lblResource.Location = new System.Drawing.Point(330, 110);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(75, 25);
            this.lblResource.TabIndex = 18;
            this.lblResource.Text = "Resources";
            // 
            // txtResource
            // 
            this.txtResource.Location = new System.Drawing.Point(410, 105);
            this.txtResource.Name = "txtResource";
            this.txtResource.Size = new System.Drawing.Size(300, 20);
            this.txtResource.TabIndex = 19;
            // 
            // lblPriority
            // 
            this.lblPriority.Location = new System.Drawing.Point(730, 110);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(60, 25);
            this.lblPriority.TabIndex = 20;
            this.lblPriority.Text = "Priority";
            // 
            // cmbPriority
            // 
            this.cmbPriority.Location = new System.Drawing.Point(790, 105);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(120, 21);
            this.cmbPriority.TabIndex = 21;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(15, 150);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 25);
            this.lblStatus.TabIndex = 22;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(90, 145);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 21);
            this.cmbStatus.TabIndex = 23;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Location = new System.Drawing.Point(260, 150);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(70, 25);
            this.lblRemarks.TabIndex = 24;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(330, 145);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(580, 55);
            this.txtRemarks.TabIndex = 25;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(950, 50);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(140, 32);
            this.btnNew.TabIndex = 26;
            this.btnNew.Text = "New";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(950, 90);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 32);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(950, 130);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(140, 32);
            this.btnUpdate.TabIndex = 28;
            this.btnUpdate.Text = "Update";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(950, 170);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(140, 32);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "Delete";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(950, 210);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(140, 32);
            this.btnClear.TabIndex = 30;
            this.btnClear.Text = "Clear";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.Location = new System.Drawing.Point(10, 420);
            this.dgv.Name = "dgv";
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1160, 250);
            this.dgv.TabIndex = 3;
            // 
            // frmProjectSchedule
            // 
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.grpEntry);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProjectSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Schedule";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpHeader.ResumeLayout(false);
            this.grpEntry.ResumeLayout(false);
            this.grpEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }
    }
}