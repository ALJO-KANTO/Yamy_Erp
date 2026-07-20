using System.Windows.Forms;

namespace YamyProject.UI.Project_Management.DailySiteExcecution
{
    partial class frmResourceDeployment
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

        private TextBox txtDeploymentNo;

        private DateTimePicker dtDate;

        private ComboBox cmbProject;
        private ComboBox cmbSite;
        private ComboBox cmbZone;

        private ComboBox cmbDeploymentType;

        private ComboBox cmbRequestedBy;
        private ComboBox cmbApprovedBy;

        private DateTimePicker dtStartDate;
        private DateTimePicker dtEndDate;

        private ComboBox cmbStatus;

        private TextBox txtRemarks;

        private TabControl tabMain;

        private TabPage tabResources;
        private TabPage tabMovement;
        private TabPage tabAttachment;

        private DataGridView dgvResources;
        private DataGridView dgvMovement;
        private DataGridView dgvAttachment;

        private GroupBox grpSummary;

        private TextBox txtTotalResources;
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
            this.txtDeploymentNo = new System.Windows.Forms.TextBox();
            this.l2 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.l3 = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.l4 = new System.Windows.Forms.Label();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.l5 = new System.Windows.Forms.Label();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.l6 = new System.Windows.Forms.Label();
            this.cmbDeploymentType = new System.Windows.Forms.ComboBox();
            this.l7 = new System.Windows.Forms.Label();
            this.cmbRequestedBy = new System.Windows.Forms.ComboBox();
            this.l8 = new System.Windows.Forms.Label();
            this.cmbApprovedBy = new System.Windows.Forms.ComboBox();
            this.l9 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.l10 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.l11 = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.l12 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabResources = new System.Windows.Forms.TabPage();
            this.dgvResources = new System.Windows.Forms.DataGridView();
            this.tabMovement = new System.Windows.Forms.TabPage();
            this.dgvMovement = new System.Windows.Forms.DataGridView();
            this.tabAttachment = new System.Windows.Forms.TabPage();
            this.dgvAttachment = new System.Windows.Forms.DataGridView();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.s1 = new System.Windows.Forms.Label();
            this.txtTotalResources = new System.Windows.Forms.TextBox();
            this.s2 = new System.Windows.Forms.Label();
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
            this.tabResources.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResources)).BeginInit();
            this.tabMovement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovement)).BeginInit();
            this.tabAttachment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachment)).BeginInit();
            this.grpSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
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
            this.lblTitle.Size = new System.Drawing.Size(531, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "RESOURCE DEPLOYMENT";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.l1);
            this.grpHeader.Controls.Add(this.txtDeploymentNo);
            this.grpHeader.Controls.Add(this.l2);
            this.grpHeader.Controls.Add(this.dtDate);
            this.grpHeader.Controls.Add(this.l3);
            this.grpHeader.Controls.Add(this.cmbProject);
            this.grpHeader.Controls.Add(this.l4);
            this.grpHeader.Controls.Add(this.cmbSite);
            this.grpHeader.Controls.Add(this.l5);
            this.grpHeader.Controls.Add(this.cmbZone);
            this.grpHeader.Controls.Add(this.l6);
            this.grpHeader.Controls.Add(this.cmbDeploymentType);
            this.grpHeader.Controls.Add(this.l7);
            this.grpHeader.Controls.Add(this.cmbRequestedBy);
            this.grpHeader.Controls.Add(this.l8);
            this.grpHeader.Controls.Add(this.cmbApprovedBy);
            this.grpHeader.Controls.Add(this.l9);
            this.grpHeader.Controls.Add(this.cmbStatus);
            this.grpHeader.Controls.Add(this.l10);
            this.grpHeader.Controls.Add(this.dtStartDate);
            this.grpHeader.Controls.Add(this.l11);
            this.grpHeader.Controls.Add(this.dtEndDate);
            this.grpHeader.Controls.Add(this.l12);
            this.grpHeader.Controls.Add(this.txtRemarks);
            this.grpHeader.Location = new System.Drawing.Point(10, 65);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1160, 190);
            this.grpHeader.TabIndex = 1;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Deployment Information";
            // 
            // l1
            // 
            this.l1.Location = new System.Drawing.Point(15, 30);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(110, 25);
            this.l1.TabIndex = 0;
            this.l1.Text = "Deployment No";
            // 
            // txtDeploymentNo
            // 
            this.txtDeploymentNo.Location = new System.Drawing.Point(130, 30);
            this.txtDeploymentNo.Name = "txtDeploymentNo";
            this.txtDeploymentNo.Size = new System.Drawing.Size(160, 20);
            this.txtDeploymentNo.TabIndex = 1;
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
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
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
            this.l6.Size = new System.Drawing.Size(110, 25);
            this.l6.TabIndex = 10;
            this.l6.Text = "Deployment Type";
            // 
            // cmbDeploymentType
            // 
            this.cmbDeploymentType.Location = new System.Drawing.Point(130, 70);
            this.cmbDeploymentType.Name = "cmbDeploymentType";
            this.cmbDeploymentType.Size = new System.Drawing.Size(180, 21);
            this.cmbDeploymentType.TabIndex = 11;
            // 
            // l7
            // 
            this.l7.Location = new System.Drawing.Point(340, 70);
            this.l7.Name = "l7";
            this.l7.Size = new System.Drawing.Size(90, 25);
            this.l7.TabIndex = 12;
            this.l7.Text = "Requested By";
            // 
            // cmbRequestedBy
            // 
            this.cmbRequestedBy.Location = new System.Drawing.Point(435, 70);
            this.cmbRequestedBy.Name = "cmbRequestedBy";
            this.cmbRequestedBy.Size = new System.Drawing.Size(220, 21);
            this.cmbRequestedBy.TabIndex = 13;
            // 
            // l8
            // 
            this.l8.Location = new System.Drawing.Point(680, 70);
            this.l8.Name = "l8";
            this.l8.Size = new System.Drawing.Size(90, 25);
            this.l8.TabIndex = 14;
            this.l8.Text = "Approved By";
            // 
            // cmbApprovedBy
            // 
            this.cmbApprovedBy.Location = new System.Drawing.Point(775, 70);
            this.cmbApprovedBy.Name = "cmbApprovedBy";
            this.cmbApprovedBy.Size = new System.Drawing.Size(220, 21);
            this.cmbApprovedBy.TabIndex = 15;
            // 
            // l9
            // 
            this.l9.Location = new System.Drawing.Point(1020, 70);
            this.l9.Name = "l9";
            this.l9.Size = new System.Drawing.Size(50, 25);
            this.l9.TabIndex = 16;
            this.l9.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(1075, 70);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(70, 21);
            this.cmbStatus.TabIndex = 17;
            // 
            // l10
            // 
            this.l10.Location = new System.Drawing.Point(15, 110);
            this.l10.Name = "l10";
            this.l10.Size = new System.Drawing.Size(70, 25);
            this.l10.TabIndex = 18;
            this.l10.Text = "Start Date";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(90, 110);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(150, 20);
            this.dtStartDate.TabIndex = 19;
            // 
            // l11
            // 
            this.l11.Location = new System.Drawing.Point(260, 110);
            this.l11.Name = "l11";
            this.l11.Size = new System.Drawing.Size(70, 25);
            this.l11.TabIndex = 20;
            this.l11.Text = "End Date";
            // 
            // dtEndDate
            // 
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDate.Location = new System.Drawing.Point(330, 110);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(150, 20);
            this.dtEndDate.TabIndex = 21;
            // 
            // l12
            // 
            this.l12.Location = new System.Drawing.Point(500, 110);
            this.l12.Name = "l12";
            this.l12.Size = new System.Drawing.Size(60, 25);
            this.l12.TabIndex = 22;
            this.l12.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(565, 110);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(580, 20);
            this.txtRemarks.TabIndex = 23;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabResources);
            this.tabMain.Controls.Add(this.tabMovement);
            this.tabMain.Controls.Add(this.tabAttachment);
            this.tabMain.Location = new System.Drawing.Point(10, 260);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1160, 290);
            this.tabMain.TabIndex = 2;
            // 
            // tabResources
            // 
            this.tabResources.Controls.Add(this.dgvResources);
            this.tabResources.Location = new System.Drawing.Point(4, 22);
            this.tabResources.Name = "tabResources";
            this.tabResources.Size = new System.Drawing.Size(1152, 264);
            this.tabResources.TabIndex = 0;
            this.tabResources.Text = "Resources";
            // 
            // dgvResources
            // 
            this.dgvResources.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResources.Location = new System.Drawing.Point(0, 0);
            this.dgvResources.Name = "dgvResources";
            this.dgvResources.RowHeadersVisible = false;
            this.dgvResources.Size = new System.Drawing.Size(1152, 264);
            this.dgvResources.TabIndex = 0;
            // 
            // tabMovement
            // 
            this.tabMovement.Controls.Add(this.dgvMovement);
            this.tabMovement.Location = new System.Drawing.Point(4, 22);
            this.tabMovement.Name = "tabMovement";
            this.tabMovement.Size = new System.Drawing.Size(1152, 264);
            this.tabMovement.TabIndex = 1;
            this.tabMovement.Text = "Movement History";
            // 
            // dgvMovement
            // 
            this.dgvMovement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovement.Location = new System.Drawing.Point(0, 0);
            this.dgvMovement.Name = "dgvMovement";
            this.dgvMovement.RowHeadersVisible = false;
            this.dgvMovement.Size = new System.Drawing.Size(1152, 264);
            this.dgvMovement.TabIndex = 0;
            // 
            // tabAttachment
            // 
            this.tabAttachment.Controls.Add(this.dgvAttachment);
            this.tabAttachment.Location = new System.Drawing.Point(4, 22);
            this.tabAttachment.Name = "tabAttachment";
            this.tabAttachment.Size = new System.Drawing.Size(1152, 264);
            this.tabAttachment.TabIndex = 2;
            this.tabAttachment.Text = "Attachments";
            // 
            // dgvAttachment
            // 
            this.dgvAttachment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAttachment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttachment.Location = new System.Drawing.Point(0, 0);
            this.dgvAttachment.Name = "dgvAttachment";
            this.dgvAttachment.RowHeadersVisible = false;
            this.dgvAttachment.Size = new System.Drawing.Size(1152, 264);
            this.dgvAttachment.TabIndex = 0;
            // 
            // grpSummary
            // 
            this.grpSummary.Controls.Add(this.s1);
            this.grpSummary.Controls.Add(this.txtTotalResources);
            this.grpSummary.Controls.Add(this.s2);
            this.grpSummary.Controls.Add(this.txtTotalCost);
            this.grpSummary.Location = new System.Drawing.Point(775, 556);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(397, 70);
            this.grpSummary.TabIndex = 3;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "Summary";
            // 
            // s1
            // 
            this.s1.Location = new System.Drawing.Point(8, 30);
            this.s1.Name = "s1";
            this.s1.Size = new System.Drawing.Size(100, 25);
            this.s1.TabIndex = 0;
            this.s1.Text = "Total Resources";
            // 
            // txtTotalResources
            // 
            this.txtTotalResources.Location = new System.Drawing.Point(113, 25);
            this.txtTotalResources.Name = "txtTotalResources";
            this.txtTotalResources.Size = new System.Drawing.Size(100, 20);
            this.txtTotalResources.TabIndex = 1;
            // 
            // s2
            // 
            this.s2.Location = new System.Drawing.Point(233, 30);
            this.s2.Name = "s2";
            this.s2.Size = new System.Drawing.Size(70, 25);
            this.s2.TabIndex = 2;
            this.s2.Text = "Total Cost";
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Location = new System.Drawing.Point(308, 25);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.Size = new System.Drawing.Size(80, 20);
            this.txtTotalCost.TabIndex = 3;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(6, 575);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(102, 35);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(117, 575);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 35);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(227, 575);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(337, 575);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 35);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(447, 575);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(557, 575);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(100, 35);
            this.btnApprove.TabIndex = 9;
            this.btnApprove.Text = "Approve";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(667, 575);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 35);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmResourceDeployment
            // 
            this.ClientSize = new System.Drawing.Size(1184, 631);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.grpHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmResourceDeployment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resource Deployment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmResourceDeployment_Load);
            this.pnlTop.ResumeLayout(false);
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabResources.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResources)).EndInit();
            this.tabMovement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovement)).EndInit();
            this.tabAttachment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachment)).EndInit();
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