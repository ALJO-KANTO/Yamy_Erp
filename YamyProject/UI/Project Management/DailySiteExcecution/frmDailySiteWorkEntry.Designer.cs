using System.Windows.Forms;

namespace YamyProject.UI.Project_Management.DailySiteExcecution
{
    partial class frmDailySiteWorkEntry
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

        private TextBox txtEntryNo;
        private DateTimePicker dtDate;

        private ComboBox cmbProject;
        private ComboBox cmbSite;
        private ComboBox cmbZone;

        private ComboBox cmbSupervisor;
        private ComboBox cmbEngineer;

        private ComboBox cmbShift;
        private ComboBox cmbWeather;

        private ComboBox cmbStatus;

        private TextBox txtProgress;
        private TextBox txtRemarks;

        private TabControl tabMain;

        private TabPage tabActivities;
        private TabPage tabLabour;
        private TabPage tabEquipment;
        private TabPage tabMaterials;
        private TabPage tabIssues;

        private DataGridView dgvActivities;
        private DataGridView dgvLabour;
        private DataGridView dgvEquipment;
        private DataGridView dgvMaterials;
        private DataGridView dgvIssues;

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
            this.h1 = new System.Windows.Forms.Label();
            this.txtEntryNo = new System.Windows.Forms.TextBox();
            this.h2 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.h3 = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.h4 = new System.Windows.Forms.Label();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.h5 = new System.Windows.Forms.Label();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.h6 = new System.Windows.Forms.Label();
            this.cmbSupervisor = new System.Windows.Forms.ComboBox();
            this.h7 = new System.Windows.Forms.Label();
            this.cmbEngineer = new System.Windows.Forms.ComboBox();
            this.h8 = new System.Windows.Forms.Label();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.h9 = new System.Windows.Forms.Label();
            this.cmbWeather = new System.Windows.Forms.ComboBox();
            this.h10 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.h11 = new System.Windows.Forms.Label();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.h12 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabActivities = new System.Windows.Forms.TabPage();
            this.dgvActivities = new System.Windows.Forms.DataGridView();
            this.tabLabour = new System.Windows.Forms.TabPage();
            this.dgvLabour = new System.Windows.Forms.DataGridView();
            this.tabEquipment = new System.Windows.Forms.TabPage();
            this.dgvEquipment = new System.Windows.Forms.DataGridView();
            this.tabMaterials = new System.Windows.Forms.TabPage();
            this.dgvMaterials = new System.Windows.Forms.DataGridView();
            this.tabIssues = new System.Windows.Forms.TabPage();
            this.dgvIssues = new System.Windows.Forms.DataGridView();
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
            this.tabLabour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabour)).BeginInit();
            this.tabEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipment)).BeginInit();
            this.tabMaterials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).BeginInit();
            this.tabIssues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssues)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
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
            this.lblTitle.Size = new System.Drawing.Size(440, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DAILY SITE WORK ENTRY";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.h1);
            this.grpHeader.Controls.Add(this.txtEntryNo);
            this.grpHeader.Controls.Add(this.h2);
            this.grpHeader.Controls.Add(this.dtDate);
            this.grpHeader.Controls.Add(this.h3);
            this.grpHeader.Controls.Add(this.cmbProject);
            this.grpHeader.Controls.Add(this.h4);
            this.grpHeader.Controls.Add(this.cmbSite);
            this.grpHeader.Controls.Add(this.h5);
            this.grpHeader.Controls.Add(this.cmbZone);
            this.grpHeader.Controls.Add(this.h6);
            this.grpHeader.Controls.Add(this.cmbSupervisor);
            this.grpHeader.Controls.Add(this.h7);
            this.grpHeader.Controls.Add(this.cmbEngineer);
            this.grpHeader.Controls.Add(this.h8);
            this.grpHeader.Controls.Add(this.cmbShift);
            this.grpHeader.Controls.Add(this.h9);
            this.grpHeader.Controls.Add(this.cmbWeather);
            this.grpHeader.Controls.Add(this.h10);
            this.grpHeader.Controls.Add(this.cmbStatus);
            this.grpHeader.Controls.Add(this.h11);
            this.grpHeader.Controls.Add(this.txtProgress);
            this.grpHeader.Controls.Add(this.h12);
            this.grpHeader.Controls.Add(this.txtRemarks);
            this.grpHeader.Location = new System.Drawing.Point(10, 65);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1160, 170);
            this.grpHeader.TabIndex = 1;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "General Information";
            // 
            // h1
            // 
            this.h1.Location = new System.Drawing.Point(15, 30);
            this.h1.Name = "h1";
            this.h1.Size = new System.Drawing.Size(60, 25);
            this.h1.TabIndex = 0;
            this.h1.Text = "Entry No";
            // 
            // txtEntryNo
            // 
            this.txtEntryNo.Location = new System.Drawing.Point(80, 30);
            this.txtEntryNo.Name = "txtEntryNo";
            this.txtEntryNo.Size = new System.Drawing.Size(150, 20);
            this.txtEntryNo.TabIndex = 1;
            // 
            // h2
            // 
            this.h2.Location = new System.Drawing.Point(250, 30);
            this.h2.Name = "h2";
            this.h2.Size = new System.Drawing.Size(40, 25);
            this.h2.TabIndex = 2;
            this.h2.Text = "Date";
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(295, 30);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(150, 20);
            this.dtDate.TabIndex = 3;
            // 
            // h3
            // 
            this.h3.Location = new System.Drawing.Point(470, 30);
            this.h3.Name = "h3";
            this.h3.Size = new System.Drawing.Size(50, 25);
            this.h3.TabIndex = 4;
            this.h3.Text = "Project";
            // 
            // cmbProject
            // 
            this.cmbProject.Location = new System.Drawing.Point(525, 30);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(220, 21);
            this.cmbProject.TabIndex = 5;
            // 
            // h4
            // 
            this.h4.Location = new System.Drawing.Point(770, 30);
            this.h4.Name = "h4";
            this.h4.Size = new System.Drawing.Size(35, 25);
            this.h4.TabIndex = 6;
            this.h4.Text = "Site";
            // 
            // cmbSite
            // 
            this.cmbSite.Location = new System.Drawing.Point(810, 30);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(150, 21);
            this.cmbSite.TabIndex = 7;
            // 
            // h5
            // 
            this.h5.Location = new System.Drawing.Point(980, 30);
            this.h5.Name = "h5";
            this.h5.Size = new System.Drawing.Size(40, 25);
            this.h5.TabIndex = 8;
            this.h5.Text = "Zone";
            // 
            // cmbZone
            // 
            this.cmbZone.Location = new System.Drawing.Point(1025, 30);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(120, 21);
            this.cmbZone.TabIndex = 9;
            // 
            // h6
            // 
            this.h6.Location = new System.Drawing.Point(15, 70);
            this.h6.Name = "h6";
            this.h6.Size = new System.Drawing.Size(70, 25);
            this.h6.TabIndex = 10;
            this.h6.Text = "Supervisor";
            // 
            // cmbSupervisor
            // 
            this.cmbSupervisor.Location = new System.Drawing.Point(90, 70);
            this.cmbSupervisor.Name = "cmbSupervisor";
            this.cmbSupervisor.Size = new System.Drawing.Size(220, 21);
            this.cmbSupervisor.TabIndex = 11;
            // 
            // h7
            // 
            this.h7.Location = new System.Drawing.Point(330, 70);
            this.h7.Name = "h7";
            this.h7.Size = new System.Drawing.Size(60, 25);
            this.h7.TabIndex = 12;
            this.h7.Text = "Engineer";
            // 
            // cmbEngineer
            // 
            this.cmbEngineer.Location = new System.Drawing.Point(395, 70);
            this.cmbEngineer.Name = "cmbEngineer";
            this.cmbEngineer.Size = new System.Drawing.Size(220, 21);
            this.cmbEngineer.TabIndex = 13;
            // 
            // h8
            // 
            this.h8.Location = new System.Drawing.Point(640, 70);
            this.h8.Name = "h8";
            this.h8.Size = new System.Drawing.Size(40, 25);
            this.h8.TabIndex = 14;
            this.h8.Text = "Shift";
            // 
            // cmbShift
            // 
            this.cmbShift.Location = new System.Drawing.Point(685, 70);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(120, 21);
            this.cmbShift.TabIndex = 15;
            // 
            // h9
            // 
            this.h9.Location = new System.Drawing.Point(830, 70);
            this.h9.Name = "h9";
            this.h9.Size = new System.Drawing.Size(60, 25);
            this.h9.TabIndex = 16;
            this.h9.Text = "Weather";
            // 
            // cmbWeather
            // 
            this.cmbWeather.Location = new System.Drawing.Point(895, 70);
            this.cmbWeather.Name = "cmbWeather";
            this.cmbWeather.Size = new System.Drawing.Size(120, 21);
            this.cmbWeather.TabIndex = 17;
            // 
            // h10
            // 
            this.h10.Location = new System.Drawing.Point(1030, 70);
            this.h10.Name = "h10";
            this.h10.Size = new System.Drawing.Size(50, 25);
            this.h10.TabIndex = 18;
            this.h10.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(1085, 70);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(80, 21);
            this.cmbStatus.TabIndex = 19;
            // 
            // h11
            // 
            this.h11.Location = new System.Drawing.Point(15, 110);
            this.h11.Name = "h11";
            this.h11.Size = new System.Drawing.Size(70, 25);
            this.h11.TabIndex = 20;
            this.h11.Text = "Progress %";
            // 
            // txtProgress
            // 
            this.txtProgress.Location = new System.Drawing.Point(90, 110);
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.Size = new System.Drawing.Size(100, 20);
            this.txtProgress.TabIndex = 21;
            // 
            // h12
            // 
            this.h12.Location = new System.Drawing.Point(220, 110);
            this.h12.Name = "h12";
            this.h12.Size = new System.Drawing.Size(60, 25);
            this.h12.TabIndex = 22;
            this.h12.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(285, 110);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(860, 20);
            this.txtRemarks.TabIndex = 23;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabActivities);
            this.tabMain.Controls.Add(this.tabLabour);
            this.tabMain.Controls.Add(this.tabEquipment);
            this.tabMain.Controls.Add(this.tabMaterials);
            this.tabMain.Controls.Add(this.tabIssues);
            this.tabMain.Location = new System.Drawing.Point(10, 240);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1160, 330);
            this.tabMain.TabIndex = 2;
            // 
            // tabActivities
            // 
            this.tabActivities.Controls.Add(this.dgvActivities);
            this.tabActivities.Location = new System.Drawing.Point(4, 22);
            this.tabActivities.Name = "tabActivities";
            this.tabActivities.Size = new System.Drawing.Size(1152, 304);
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
            this.dgvActivities.Size = new System.Drawing.Size(1152, 304);
            this.dgvActivities.TabIndex = 0;
            // 
            // tabLabour
            // 
            this.tabLabour.Controls.Add(this.dgvLabour);
            this.tabLabour.Location = new System.Drawing.Point(4, 22);
            this.tabLabour.Name = "tabLabour";
            this.tabLabour.Size = new System.Drawing.Size(1152, 304);
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
            this.dgvLabour.Size = new System.Drawing.Size(1152, 304);
            this.dgvLabour.TabIndex = 0;
            // 
            // tabEquipment
            // 
            this.tabEquipment.Controls.Add(this.dgvEquipment);
            this.tabEquipment.Location = new System.Drawing.Point(4, 22);
            this.tabEquipment.Name = "tabEquipment";
            this.tabEquipment.Size = new System.Drawing.Size(1152, 304);
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
            this.dgvEquipment.Size = new System.Drawing.Size(1152, 304);
            this.dgvEquipment.TabIndex = 0;
            // 
            // tabMaterials
            // 
            this.tabMaterials.Controls.Add(this.dgvMaterials);
            this.tabMaterials.Location = new System.Drawing.Point(4, 22);
            this.tabMaterials.Name = "tabMaterials";
            this.tabMaterials.Size = new System.Drawing.Size(1152, 304);
            this.tabMaterials.TabIndex = 3;
            this.tabMaterials.Text = "Materials";
            // 
            // dgvMaterials
            // 
            this.dgvMaterials.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaterials.Location = new System.Drawing.Point(0, 0);
            this.dgvMaterials.Name = "dgvMaterials";
            this.dgvMaterials.RowHeadersVisible = false;
            this.dgvMaterials.Size = new System.Drawing.Size(1152, 304);
            this.dgvMaterials.TabIndex = 0;
            // 
            // tabIssues
            // 
            this.tabIssues.Controls.Add(this.dgvIssues);
            this.tabIssues.Location = new System.Drawing.Point(4, 22);
            this.tabIssues.Name = "tabIssues";
            this.tabIssues.Size = new System.Drawing.Size(1152, 304);
            this.tabIssues.TabIndex = 4;
            this.tabIssues.Text = "Issues";
            // 
            // dgvIssues
            // 
            this.dgvIssues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIssues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIssues.Location = new System.Drawing.Point(0, 0);
            this.dgvIssues.Name = "dgvIssues";
            this.dgvIssues.RowHeadersVisible = false;
            this.dgvIssues.Size = new System.Drawing.Size(1152, 304);
            this.dgvIssues.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(180, 590);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(110, 35);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(300, 590);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(420, 590);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 35);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(540, 590);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 35);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(660, 590);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(110, 35);
            this.btnApprove.TabIndex = 7;
            this.btnApprove.Text = "Approve";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(780, 590);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(110, 35);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print";
            // 
            // frmDailySiteWorkEntry
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
            this.Name = "frmDailySiteWorkEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily Site Work Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTop.ResumeLayout(false);
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabActivities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivities)).EndInit();
            this.tabLabour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabour)).EndInit();
            this.tabEquipment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipment)).EndInit();
            this.tabMaterials.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).EndInit();
            this.tabIssues.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssues)).EndInit();
            this.ResumeLayout(false);

        }

        private Label h1;
        private Label h2;
        private Label h3;
        private Label h4;
        private Label h5;
        private Label h6;
        private Label h7;
        private Label h8;
        private Label h9;
        private Label h10;
        private Label h11;
        private Label h12;
    }
}