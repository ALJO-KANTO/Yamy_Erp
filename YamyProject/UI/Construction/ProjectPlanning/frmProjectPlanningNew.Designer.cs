using System.Windows.Forms;

namespace YamyProject.UI.Construction.ProjectPlanning
{
    partial class frmProjectPlanningNew
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
        private Label lblPlanNo;
        private Label lblPlanDate;
        private ComboBox cmbProject;
        private TextBox txtPlanNo;
        private DateTimePicker dtPlanDate;

        private GroupBox grpDetails;
        private Label lblStart;
        private Label lblEnd;
        private Label lblDays;
        private Label lblEngineer;
        private Label lblHours;
        private Label lblWeeklyOff;
        private Label lblPriority;
        private Label lblProgress;
        private Label lblStatus;
        private Label lblMilestone;
        private Label lblNotes;

        private DateTimePicker dtStart;
        private DateTimePicker dtEnd;
        private TextBox txtDays;
        private TextBox txtEngineer;
        private TextBox txtHours;
        private ComboBox cmbWeeklyOff;
        private ComboBox cmbPriority;
        private TextBox txtProgress;
        private ComboBox cmbStatus;
        private TextBox txtMilestone;
        private TextBox txtNotes;

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
            this.lblPlanNo = new System.Windows.Forms.Label();
            this.txtPlanNo = new System.Windows.Forms.TextBox();
            this.lblPlanDate = new System.Windows.Forms.Label();
            this.dtPlanDate = new System.Windows.Forms.DateTimePicker();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.lblDays = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.lblEngineer = new System.Windows.Forms.Label();
            this.txtEngineer = new System.Windows.Forms.TextBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.lblWeeklyOff = new System.Windows.Forms.Label();
            this.cmbWeeklyOff = new System.Windows.Forms.ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblMilestone = new System.Windows.Forms.Label();
            this.txtMilestone = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
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
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(196, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "PROJECT PLANNING";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.lblProject);
            this.grpHeader.Controls.Add(this.cmbProject);
            this.grpHeader.Controls.Add(this.lblPlanNo);
            this.grpHeader.Controls.Add(this.txtPlanNo);
            this.grpHeader.Controls.Add(this.lblPlanDate);
            this.grpHeader.Controls.Add(this.dtPlanDate);
            this.grpHeader.Location = new System.Drawing.Point(10, 65);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1160, 80);
            this.grpHeader.TabIndex = 1;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Planning Header";
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(15, 30);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(49, 23);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "Project";
            // 
            // cmbProject
            // 
            this.cmbProject.Location = new System.Drawing.Point(70, 25);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(280, 21);
            this.cmbProject.TabIndex = 1;
            // 
            // lblPlanNo
            // 
            this.lblPlanNo.Location = new System.Drawing.Point(380, 30);
            this.lblPlanNo.Name = "lblPlanNo";
            this.lblPlanNo.Size = new System.Drawing.Size(54, 23);
            this.lblPlanNo.TabIndex = 2;
            this.lblPlanNo.Text = "Plan No";
            // 
            // txtPlanNo
            // 
            this.txtPlanNo.Location = new System.Drawing.Point(440, 25);
            this.txtPlanNo.Name = "txtPlanNo";
            this.txtPlanNo.Size = new System.Drawing.Size(140, 20);
            this.txtPlanNo.TabIndex = 3;
            // 
            // lblPlanDate
            // 
            this.lblPlanDate.Location = new System.Drawing.Point(620, 30);
            this.lblPlanDate.Name = "lblPlanDate";
            this.lblPlanDate.Size = new System.Drawing.Size(34, 23);
            this.lblPlanDate.TabIndex = 4;
            this.lblPlanDate.Text = "Date";
            // 
            // dtPlanDate
            // 
            this.dtPlanDate.Location = new System.Drawing.Point(660, 25);
            this.dtPlanDate.Name = "dtPlanDate";
            this.dtPlanDate.Size = new System.Drawing.Size(180, 20);
            this.dtPlanDate.TabIndex = 5;
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.lblStart);
            this.grpDetails.Controls.Add(this.dtStart);
            this.grpDetails.Controls.Add(this.lblEnd);
            this.grpDetails.Controls.Add(this.dtEnd);
            this.grpDetails.Controls.Add(this.lblDays);
            this.grpDetails.Controls.Add(this.txtDays);
            this.grpDetails.Controls.Add(this.lblEngineer);
            this.grpDetails.Controls.Add(this.txtEngineer);
            this.grpDetails.Controls.Add(this.lblHours);
            this.grpDetails.Controls.Add(this.txtHours);
            this.grpDetails.Controls.Add(this.lblWeeklyOff);
            this.grpDetails.Controls.Add(this.cmbWeeklyOff);
            this.grpDetails.Controls.Add(this.lblPriority);
            this.grpDetails.Controls.Add(this.cmbPriority);
            this.grpDetails.Controls.Add(this.lblProgress);
            this.grpDetails.Controls.Add(this.txtProgress);
            this.grpDetails.Controls.Add(this.lblStatus);
            this.grpDetails.Controls.Add(this.cmbStatus);
            this.grpDetails.Controls.Add(this.lblMilestone);
            this.grpDetails.Controls.Add(this.txtMilestone);
            this.grpDetails.Controls.Add(this.lblNotes);
            this.grpDetails.Controls.Add(this.txtNotes);
            this.grpDetails.Controls.Add(this.btnNew);
            this.grpDetails.Controls.Add(this.btnSave);
            this.grpDetails.Controls.Add(this.btnUpdate);
            this.grpDetails.Controls.Add(this.btnDelete);
            this.grpDetails.Controls.Add(this.btnClear);
            this.grpDetails.Location = new System.Drawing.Point(10, 150);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(1160, 250);
            this.grpDetails.TabIndex = 2;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Planning Details";
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(15, 30);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(79, 23);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "Start Date";
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(100, 25);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(160, 20);
            this.dtStart.TabIndex = 1;
            // 
            // lblEnd
            // 
            this.lblEnd.Location = new System.Drawing.Point(300, 30);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(74, 23);
            this.lblEnd.TabIndex = 2;
            this.lblEnd.Text = "End Date";
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(380, 25);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(160, 20);
            this.dtEnd.TabIndex = 3;
            // 
            // lblDays
            // 
            this.lblDays.Location = new System.Drawing.Point(580, 30);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(74, 23);
            this.lblDays.TabIndex = 4;
            this.lblDays.Text = "Total Days";
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(660, 25);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(100, 20);
            this.txtDays.TabIndex = 5;
            // 
            // lblEngineer
            // 
            this.lblEngineer.Location = new System.Drawing.Point(15, 70);
            this.lblEngineer.Name = "lblEngineer";
            this.lblEngineer.Size = new System.Drawing.Size(79, 23);
            this.lblEngineer.TabIndex = 6;
            this.lblEngineer.Text = "Engineer";
            // 
            // txtEngineer
            // 
            this.txtEngineer.Location = new System.Drawing.Point(100, 65);
            this.txtEngineer.Name = "txtEngineer";
            this.txtEngineer.Size = new System.Drawing.Size(220, 20);
            this.txtEngineer.TabIndex = 7;
            // 
            // lblHours
            // 
            this.lblHours.Location = new System.Drawing.Point(350, 70);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(84, 23);
            this.lblHours.TabIndex = 8;
            this.lblHours.Text = "Work Hours";
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(440, 65);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(100, 20);
            this.txtHours.TabIndex = 9;
            // 
            // lblWeeklyOff
            // 
            this.lblWeeklyOff.Location = new System.Drawing.Point(580, 70);
            this.lblWeeklyOff.Name = "lblWeeklyOff";
            this.lblWeeklyOff.Size = new System.Drawing.Size(74, 23);
            this.lblWeeklyOff.TabIndex = 10;
            this.lblWeeklyOff.Text = "Weekly Off";
            // 
            // cmbWeeklyOff
            // 
            this.cmbWeeklyOff.Location = new System.Drawing.Point(660, 65);
            this.cmbWeeklyOff.Name = "cmbWeeklyOff";
            this.cmbWeeklyOff.Size = new System.Drawing.Size(120, 21);
            this.cmbWeeklyOff.TabIndex = 11;
            // 
            // lblPriority
            // 
            this.lblPriority.Location = new System.Drawing.Point(15, 110);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(79, 23);
            this.lblPriority.TabIndex = 12;
            this.lblPriority.Text = "Priority";
            // 
            // cmbPriority
            // 
            this.cmbPriority.Location = new System.Drawing.Point(100, 105);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(150, 21);
            this.cmbPriority.TabIndex = 13;
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(300, 110);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(74, 23);
            this.lblProgress.TabIndex = 14;
            this.lblProgress.Text = "Progress %";
            // 
            // txtProgress
            // 
            this.txtProgress.Location = new System.Drawing.Point(380, 105);
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.Size = new System.Drawing.Size(100, 20);
            this.txtProgress.TabIndex = 15;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(520, 110);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(54, 23);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(580, 105);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 21);
            this.cmbStatus.TabIndex = 17;
            // 
            // lblMilestone
            // 
            this.lblMilestone.Location = new System.Drawing.Point(15, 150);
            this.lblMilestone.Name = "lblMilestone";
            this.lblMilestone.Size = new System.Drawing.Size(79, 23);
            this.lblMilestone.TabIndex = 18;
            this.lblMilestone.Text = "Milestone";
            // 
            // txtMilestone
            // 
            this.txtMilestone.Location = new System.Drawing.Point(100, 145);
            this.txtMilestone.Name = "txtMilestone";
            this.txtMilestone.Size = new System.Drawing.Size(680, 20);
            this.txtMilestone.TabIndex = 19;
            // 
            // lblNotes
            // 
            this.lblNotes.Location = new System.Drawing.Point(15, 190);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(79, 23);
            this.lblNotes.TabIndex = 20;
            this.lblNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(100, 185);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(680, 45);
            this.txtNotes.TabIndex = 21;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(860, 35);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(120, 35);
            this.btnNew.TabIndex = 22;
            this.btnNew.Text = "New";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1000, 35);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(860, 85);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 35);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "Update";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1000, 85);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 35);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "Delete";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(930, 135);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 35);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "Clear";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.Location = new System.Drawing.Point(10, 410);
            this.dgv.Name = "dgv";
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1160, 260);
            this.dgv.TabIndex = 3;
            // 
            // frmProjectPlanningNew
            // 
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProjectPlanningNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Planning";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }
    }
}