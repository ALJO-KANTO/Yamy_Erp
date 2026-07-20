using System.Windows.Forms;

namespace YamyProject.UI.Project_Management.DailySiteExcecution
{
    partial class frmEquipmentUsage
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

        private TextBox txtUsageNo;

        private DateTimePicker dtDate;

        private ComboBox cmbProject;
        private ComboBox cmbSite;
        private ComboBox cmbZone;

        private ComboBox cmbOperator;

        private ComboBox cmbShift;
        private ComboBox cmbWeather;

        private ComboBox cmbStatus;

        private TextBox txtRemarks;

        private TabControl tabMain;

        private TabPage tabUsage;
        private TabPage tabBreakdown;
        private TabPage tabFuel;

        private DataGridView dgvUsage;
        private DataGridView dgvBreakdown;
        private DataGridView dgvFuel;

        private GroupBox grpSummary;

        private TextBox txtTotalHours;
        private TextBox txtTotalFuel;
        private TextBox txtTotalCost;

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
            this.txtUsageNo = new System.Windows.Forms.TextBox();
            this.l2 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.l3 = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.l4 = new System.Windows.Forms.Label();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.l5 = new System.Windows.Forms.Label();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.l6 = new System.Windows.Forms.Label();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.l7 = new System.Windows.Forms.Label();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.l8 = new System.Windows.Forms.Label();
            this.cmbWeather = new System.Windows.Forms.ComboBox();
            this.l9 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.l10 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabUsage = new System.Windows.Forms.TabPage();
            this.dgvUsage = new System.Windows.Forms.DataGridView();
            this.tabBreakdown = new System.Windows.Forms.TabPage();
            this.dgvBreakdown = new System.Windows.Forms.DataGridView();
            this.tabFuel = new System.Windows.Forms.TabPage();
            this.dgvFuel = new System.Windows.Forms.DataGridView();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.s1 = new System.Windows.Forms.Label();
            this.txtTotalHours = new System.Windows.Forms.TextBox();
            this.s2 = new System.Windows.Forms.Label();
            this.txtTotalFuel = new System.Windows.Forms.TextBox();
            this.s3 = new System.Windows.Forms.Label();
            this.txtTotalCost = new System.Windows.Forms.TextBox();
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
            this.tabUsage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsage)).BeginInit();
            this.tabBreakdown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBreakdown)).BeginInit();
            this.tabFuel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuel)).BeginInit();
            this.grpSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
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
            this.lblTitle.Size = new System.Drawing.Size(334, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "EQUIPMENT USAGE";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.l1);
            this.grpHeader.Controls.Add(this.txtUsageNo);
            this.grpHeader.Controls.Add(this.l2);
            this.grpHeader.Controls.Add(this.dtDate);
            this.grpHeader.Controls.Add(this.l3);
            this.grpHeader.Controls.Add(this.cmbProject);
            this.grpHeader.Controls.Add(this.l4);
            this.grpHeader.Controls.Add(this.cmbSite);
            this.grpHeader.Controls.Add(this.l5);
            this.grpHeader.Controls.Add(this.cmbZone);
            this.grpHeader.Controls.Add(this.l6);
            this.grpHeader.Controls.Add(this.cmbOperator);
            this.grpHeader.Controls.Add(this.l7);
            this.grpHeader.Controls.Add(this.cmbShift);
            this.grpHeader.Controls.Add(this.l8);
            this.grpHeader.Controls.Add(this.cmbWeather);
            this.grpHeader.Controls.Add(this.l9);
            this.grpHeader.Controls.Add(this.cmbStatus);
            this.grpHeader.Controls.Add(this.l10);
            this.grpHeader.Controls.Add(this.txtRemarks);
            this.grpHeader.Location = new System.Drawing.Point(10, 65);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1160, 180);
            this.grpHeader.TabIndex = 1;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Equipment Usage Information";
            // 
            // l1
            // 
            this.l1.Location = new System.Drawing.Point(15, 30);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(70, 25);
            this.l1.TabIndex = 0;
            this.l1.Text = "Usage No";
            // 
            // txtUsageNo
            // 
            this.txtUsageNo.Location = new System.Drawing.Point(90, 30);
            this.txtUsageNo.Name = "txtUsageNo";
            this.txtUsageNo.Size = new System.Drawing.Size(160, 20);
            this.txtUsageNo.TabIndex = 1;
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
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
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
            this.l6.Size = new System.Drawing.Size(70, 25);
            this.l6.TabIndex = 10;
            this.l6.Text = "Operator";
            // 
            // cmbOperator
            // 
            this.cmbOperator.Location = new System.Drawing.Point(90, 70);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(220, 21);
            this.cmbOperator.TabIndex = 11;
            // 
            // l7
            // 
            this.l7.Location = new System.Drawing.Point(340, 70);
            this.l7.Name = "l7";
            this.l7.Size = new System.Drawing.Size(40, 25);
            this.l7.TabIndex = 12;
            this.l7.Text = "Shift";
            // 
            // cmbShift
            // 
            this.cmbShift.Location = new System.Drawing.Point(385, 70);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(120, 21);
            this.cmbShift.TabIndex = 13;
            // 
            // l8
            // 
            this.l8.Location = new System.Drawing.Point(530, 70);
            this.l8.Name = "l8";
            this.l8.Size = new System.Drawing.Size(60, 25);
            this.l8.TabIndex = 14;
            this.l8.Text = "Weather";
            // 
            // cmbWeather
            // 
            this.cmbWeather.Location = new System.Drawing.Point(595, 70);
            this.cmbWeather.Name = "cmbWeather";
            this.cmbWeather.Size = new System.Drawing.Size(150, 21);
            this.cmbWeather.TabIndex = 15;
            // 
            // l9
            // 
            this.l9.Location = new System.Drawing.Point(770, 70);
            this.l9.Name = "l9";
            this.l9.Size = new System.Drawing.Size(50, 25);
            this.l9.TabIndex = 16;
            this.l9.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(825, 70);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(120, 21);
            this.cmbStatus.TabIndex = 17;
            // 
            // l10
            // 
            this.l10.Location = new System.Drawing.Point(970, 70);
            this.l10.Name = "l10";
            this.l10.Size = new System.Drawing.Size(60, 25);
            this.l10.TabIndex = 18;
            this.l10.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(1035, 70);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(110, 20);
            this.txtRemarks.TabIndex = 19;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabUsage);
            this.tabMain.Controls.Add(this.tabBreakdown);
            this.tabMain.Controls.Add(this.tabFuel);
            this.tabMain.Location = new System.Drawing.Point(10, 250);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1160, 300);
            this.tabMain.TabIndex = 2;
            // 
            // tabUsage
            // 
            this.tabUsage.Controls.Add(this.dgvUsage);
            this.tabUsage.Location = new System.Drawing.Point(4, 22);
            this.tabUsage.Name = "tabUsage";
            this.tabUsage.Size = new System.Drawing.Size(1152, 274);
            this.tabUsage.TabIndex = 0;
            this.tabUsage.Text = "Equipment Usage";
            // 
            // dgvUsage
            // 
            this.dgvUsage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsage.Location = new System.Drawing.Point(0, 0);
            this.dgvUsage.Name = "dgvUsage";
            this.dgvUsage.RowHeadersVisible = false;
            this.dgvUsage.Size = new System.Drawing.Size(1152, 274);
            this.dgvUsage.TabIndex = 0;
            // 
            // tabBreakdown
            // 
            this.tabBreakdown.Controls.Add(this.dgvBreakdown);
            this.tabBreakdown.Location = new System.Drawing.Point(4, 22);
            this.tabBreakdown.Name = "tabBreakdown";
            this.tabBreakdown.Size = new System.Drawing.Size(1152, 274);
            this.tabBreakdown.TabIndex = 1;
            this.tabBreakdown.Text = "Breakdown";
            // 
            // dgvBreakdown
            // 
            this.dgvBreakdown.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBreakdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBreakdown.Location = new System.Drawing.Point(0, 0);
            this.dgvBreakdown.Name = "dgvBreakdown";
            this.dgvBreakdown.RowHeadersVisible = false;
            this.dgvBreakdown.Size = new System.Drawing.Size(1152, 274);
            this.dgvBreakdown.TabIndex = 0;
            // 
            // tabFuel
            // 
            this.tabFuel.Controls.Add(this.dgvFuel);
            this.tabFuel.Location = new System.Drawing.Point(4, 22);
            this.tabFuel.Name = "tabFuel";
            this.tabFuel.Size = new System.Drawing.Size(1152, 274);
            this.tabFuel.TabIndex = 2;
            this.tabFuel.Text = "Fuel Log";
            // 
            // dgvFuel
            // 
            this.dgvFuel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFuel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFuel.Location = new System.Drawing.Point(0, 0);
            this.dgvFuel.Name = "dgvFuel";
            this.dgvFuel.RowHeadersVisible = false;
            this.dgvFuel.Size = new System.Drawing.Size(1152, 274);
            this.dgvFuel.TabIndex = 0;
            // 
            // grpSummary
            // 
            this.grpSummary.Controls.Add(this.s1);
            this.grpSummary.Controls.Add(this.txtTotalHours);
            this.grpSummary.Controls.Add(this.s2);
            this.grpSummary.Controls.Add(this.txtTotalFuel);
            this.grpSummary.Controls.Add(this.s3);
            this.grpSummary.Controls.Add(this.txtTotalCost);
            this.grpSummary.Location = new System.Drawing.Point(740, 560);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(430, 70);
            this.grpSummary.TabIndex = 3;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "Summary";
            // 
            // s1
            // 
            this.s1.Location = new System.Drawing.Point(15, 30);
            this.s1.Name = "s1";
            this.s1.Size = new System.Drawing.Size(50, 25);
            this.s1.TabIndex = 0;
            this.s1.Text = "Hours";
            // 
            // txtTotalHours
            // 
            this.txtTotalHours.Location = new System.Drawing.Point(70, 25);
            this.txtTotalHours.Name = "txtTotalHours";
            this.txtTotalHours.Size = new System.Drawing.Size(90, 20);
            this.txtTotalHours.TabIndex = 1;
            // 
            // s2
            // 
            this.s2.Location = new System.Drawing.Point(180, 30);
            this.s2.Name = "s2";
            this.s2.Size = new System.Drawing.Size(40, 25);
            this.s2.TabIndex = 2;
            this.s2.Text = "Fuel";
            // 
            // txtTotalFuel
            // 
            this.txtTotalFuel.Location = new System.Drawing.Point(225, 25);
            this.txtTotalFuel.Name = "txtTotalFuel";
            this.txtTotalFuel.Size = new System.Drawing.Size(80, 20);
            this.txtTotalFuel.TabIndex = 3;
            // 
            // s3
            // 
            this.s3.Location = new System.Drawing.Point(320, 30);
            this.s3.Name = "s3";
            this.s3.Size = new System.Drawing.Size(40, 25);
            this.s3.TabIndex = 4;
            this.s3.Text = "Cost";
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Location = new System.Drawing.Point(365, 25);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.Size = new System.Drawing.Size(60, 20);
            this.txtTotalCost.TabIndex = 5;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(10, 575);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(100, 35);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(118, 575);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(71, 35);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(194, 575);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(304, 575);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 35);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(414, 575);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(524, 575);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(100, 35);
            this.btnApprove.TabIndex = 9;
            this.btnApprove.Text = "Approve";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(634, 575);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 35);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmEquipmentUsage
            // 
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEquipmentUsage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Equipment Usage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEquipmentUsage_Load);
            this.pnlTop.ResumeLayout(false);
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabUsage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsage)).EndInit();
            this.tabBreakdown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBreakdown)).EndInit();
            this.tabFuel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuel)).EndInit();
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