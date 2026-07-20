using System.Windows.Forms;

namespace YamyProject.UI.Construction.LookAheadPlanning
{
    partial class frmLookAheadPlanning
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
        private Label lblWeek;
        private Label lblFrom;
        private Label lblTo;

        private ComboBox cmbProject;
        private TextBox txtWeekNo;
        private DateTimePicker dtFrom;
        private DateTimePicker dtTo;

        private GroupBox grpDetails;

        private Label lblActivity;
        private Label lblZone;
        private Label lblResponsible;
        private Label lblMaterial;
        private Label lblLabor;
        private Label lblEquipment;
        private Label lblPriority;
        private Label lblStatus;
        private Label lblRemarks;

        private TextBox txtActivity;
        private ComboBox cmbZone;
        private TextBox txtResponsible;
        private TextBox txtMaterial;
        private TextBox txtLabor;
        private TextBox txtEquipment;
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
            this.lblWeek = new System.Windows.Forms.Label();
            this.txtWeekNo = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblActivity = new System.Windows.Forms.Label();
            this.txtActivity = new System.Windows.Forms.TextBox();
            this.lblZone = new System.Windows.Forms.Label();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.lblResponsible = new System.Windows.Forms.Label();
            this.txtResponsible = new System.Windows.Forms.TextBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.lblLabor = new System.Windows.Forms.Label();
            this.txtLabor = new System.Windows.Forms.TextBox();
            this.lblEquipment = new System.Windows.Forms.Label();
            this.txtEquipment = new System.Windows.Forms.TextBox();
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
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(88)))), ((int)(((byte)(12)))));
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
            this.lblTitle.Size = new System.Drawing.Size(232, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "LOOKAHEAD PLANNING";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.lblProject);
            this.grpHeader.Controls.Add(this.cmbProject);
            this.grpHeader.Controls.Add(this.lblWeek);
            this.grpHeader.Controls.Add(this.txtWeekNo);
            this.grpHeader.Controls.Add(this.lblFrom);
            this.grpHeader.Controls.Add(this.dtFrom);
            this.grpHeader.Controls.Add(this.lblTo);
            this.grpHeader.Controls.Add(this.dtTo);
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
            this.lblProject.Size = new System.Drawing.Size(50, 25);
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
            // lblWeek
            // 
            this.lblWeek.Location = new System.Drawing.Point(380, 30);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(60, 25);
            this.lblWeek.TabIndex = 2;
            this.lblWeek.Text = "Week No";
            // 
            // txtWeekNo
            // 
            this.txtWeekNo.Location = new System.Drawing.Point(445, 25);
            this.txtWeekNo.Name = "txtWeekNo";
            this.txtWeekNo.Size = new System.Drawing.Size(80, 20);
            this.txtWeekNo.TabIndex = 3;
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(560, 30);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(40, 25);
            this.lblFrom.TabIndex = 4;
            this.lblFrom.Text = "From";
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(600, 25);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(150, 20);
            this.dtFrom.TabIndex = 5;
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(780, 30);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(25, 25);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "To";
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(810, 25);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(150, 20);
            this.dtTo.TabIndex = 7;
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.lblActivity);
            this.grpDetails.Controls.Add(this.txtActivity);
            this.grpDetails.Controls.Add(this.lblZone);
            this.grpDetails.Controls.Add(this.cmbZone);
            this.grpDetails.Controls.Add(this.lblResponsible);
            this.grpDetails.Controls.Add(this.txtResponsible);
            this.grpDetails.Controls.Add(this.lblMaterial);
            this.grpDetails.Controls.Add(this.txtMaterial);
            this.grpDetails.Controls.Add(this.lblLabor);
            this.grpDetails.Controls.Add(this.txtLabor);
            this.grpDetails.Controls.Add(this.lblEquipment);
            this.grpDetails.Controls.Add(this.txtEquipment);
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
            this.grpDetails.Size = new System.Drawing.Size(1160, 250);
            this.grpDetails.TabIndex = 2;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Activity Details";
            // 
            // lblActivity
            // 
            this.lblActivity.Location = new System.Drawing.Point(15, 30);
            this.lblActivity.Name = "lblActivity";
            this.lblActivity.Size = new System.Drawing.Size(70, 25);
            this.lblActivity.TabIndex = 0;
            this.lblActivity.Text = "Activity";
            // 
            // txtActivity
            // 
            this.txtActivity.Location = new System.Drawing.Point(90, 25);
            this.txtActivity.Name = "txtActivity";
            this.txtActivity.Size = new System.Drawing.Size(320, 20);
            this.txtActivity.TabIndex = 1;
            // 
            // lblZone
            // 
            this.lblZone.Location = new System.Drawing.Point(440, 30);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(50, 25);
            this.lblZone.TabIndex = 2;
            this.lblZone.Text = "Zone";
            // 
            // cmbZone
            // 
            this.cmbZone.Location = new System.Drawing.Point(490, 25);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(180, 21);
            this.cmbZone.TabIndex = 3;
            // 
            // lblResponsible
            // 
            this.lblResponsible.Location = new System.Drawing.Point(15, 70);
            this.lblResponsible.Name = "lblResponsible";
            this.lblResponsible.Size = new System.Drawing.Size(70, 25);
            this.lblResponsible.TabIndex = 4;
            this.lblResponsible.Text = "Responsible";
            // 
            // txtResponsible
            // 
            this.txtResponsible.Location = new System.Drawing.Point(90, 65);
            this.txtResponsible.Name = "txtResponsible";
            this.txtResponsible.Size = new System.Drawing.Size(220, 20);
            this.txtResponsible.TabIndex = 5;
            // 
            // lblMaterial
            // 
            this.lblMaterial.Location = new System.Drawing.Point(340, 70);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(60, 25);
            this.lblMaterial.TabIndex = 6;
            this.lblMaterial.Text = "Material";
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(410, 65);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(260, 20);
            this.txtMaterial.TabIndex = 7;
            // 
            // lblLabor
            // 
            this.lblLabor.Location = new System.Drawing.Point(15, 110);
            this.lblLabor.Name = "lblLabor";
            this.lblLabor.Size = new System.Drawing.Size(50, 25);
            this.lblLabor.TabIndex = 8;
            this.lblLabor.Text = "Labor";
            // 
            // txtLabor
            // 
            this.txtLabor.Location = new System.Drawing.Point(90, 105);
            this.txtLabor.Name = "txtLabor";
            this.txtLabor.Size = new System.Drawing.Size(100, 20);
            this.txtLabor.TabIndex = 9;
            // 
            // lblEquipment
            // 
            this.lblEquipment.Location = new System.Drawing.Point(250, 110);
            this.lblEquipment.Name = "lblEquipment";
            this.lblEquipment.Size = new System.Drawing.Size(60, 25);
            this.lblEquipment.TabIndex = 10;
            this.lblEquipment.Text = "Equipment";
            // 
            // txtEquipment
            // 
            this.txtEquipment.Location = new System.Drawing.Point(310, 105);
            this.txtEquipment.Name = "txtEquipment";
            this.txtEquipment.Size = new System.Drawing.Size(360, 20);
            this.txtEquipment.TabIndex = 11;
            // 
            // lblPriority
            // 
            this.lblPriority.Location = new System.Drawing.Point(15, 150);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(55, 25);
            this.lblPriority.TabIndex = 12;
            this.lblPriority.Text = "Priority";
            // 
            // cmbPriority
            // 
            this.cmbPriority.Location = new System.Drawing.Point(90, 145);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(140, 21);
            this.cmbPriority.TabIndex = 13;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(260, 150);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 25);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(320, 145);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(140, 21);
            this.cmbStatus.TabIndex = 15;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Location = new System.Drawing.Point(15, 190);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(60, 25);
            this.lblRemarks.TabIndex = 16;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(90, 185);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(580, 45);
            this.txtRemarks.TabIndex = 17;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(860, 35);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(120, 35);
            this.btnNew.TabIndex = 18;
            this.btnNew.Text = "New";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1000, 35);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(860, 85);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 35);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.Text = "Update";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1000, 85);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 35);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Delete";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(930, 135);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 35);
            this.btnClear.TabIndex = 22;
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
            // frmLookAheadPlanning
            // 
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLookAheadPlanning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LookAhead Planning";
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