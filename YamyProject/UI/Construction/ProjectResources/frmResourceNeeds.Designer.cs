using System.Windows.Forms;

namespace YamyProject.UI.Construction.ProjectResources
{
    partial class frmResourceNeeds
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
        private Label lblType;
        private Label lblZone;

        private ComboBox cmbProject;
        private DateTimePicker dtRequestDate;
        private ComboBox cmbNeedType;
        private ComboBox cmbZone;

        private GroupBox grpDetails;

        private Label lblCategory;
        private Label lblItem;
        private Label lblUnit;
        private Label lblQty;
        private Label lblFrom;
        private Label lblTo;
        private Label lblPriority;
        private Label lblReqBy;
        private Label lblAppBy;
        private Label lblStatus;
        private Label lblRemarks;

        private TextBox txtCategory;
        private TextBox txtItem;
        private TextBox txtUnit;
        private TextBox txtQty;
        private DateTimePicker dtFrom;
        private DateTimePicker dtTo;
        private ComboBox cmbPriority;
        private TextBox txtRequestedBy;
        private TextBox txtApprovedBy;
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
            this.dtRequestDate = new System.Windows.Forms.DateTimePicker();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbNeedType = new System.Windows.Forms.ComboBox();
            this.lblZone = new System.Windows.Forms.Label();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblReqBy = new System.Windows.Forms.Label();
            this.txtRequestedBy = new System.Windows.Forms.TextBox();
            this.lblAppBy = new System.Windows.Forms.Label();
            this.txtApprovedBy = new System.Windows.Forms.TextBox();
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
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(58)))), ((int)(((byte)(237)))));
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
            this.lblTitle.Size = new System.Drawing.Size(172, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "RESOURCE NEEDS";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.lblProject);
            this.grpHeader.Controls.Add(this.cmbProject);
            this.grpHeader.Controls.Add(this.lblDate);
            this.grpHeader.Controls.Add(this.dtRequestDate);
            this.grpHeader.Controls.Add(this.lblType);
            this.grpHeader.Controls.Add(this.cmbNeedType);
            this.grpHeader.Controls.Add(this.lblZone);
            this.grpHeader.Controls.Add(this.cmbZone);
            this.grpHeader.Location = new System.Drawing.Point(10, 65);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1160, 85);
            this.grpHeader.TabIndex = 1;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Request Header";
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(15, 30);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(60, 25);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "Project";
            // 
            // cmbProject
            // 
            this.cmbProject.Location = new System.Drawing.Point(75, 25);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(280, 21);
            this.cmbProject.TabIndex = 1;
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(380, 30);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(40, 25);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date";
            // 
            // dtRequestDate
            // 
            this.dtRequestDate.Location = new System.Drawing.Point(420, 25);
            this.dtRequestDate.Name = "dtRequestDate";
            this.dtRequestDate.Size = new System.Drawing.Size(150, 20);
            this.dtRequestDate.TabIndex = 3;
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(600, 30);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(40, 25);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Type";
            // 
            // cmbNeedType
            // 
            this.cmbNeedType.Location = new System.Drawing.Point(645, 25);
            this.cmbNeedType.Name = "cmbNeedType";
            this.cmbNeedType.Size = new System.Drawing.Size(160, 21);
            this.cmbNeedType.TabIndex = 5;
            // 
            // lblZone
            // 
            this.lblZone.Location = new System.Drawing.Point(835, 30);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(40, 25);
            this.lblZone.TabIndex = 6;
            this.lblZone.Text = "Zone";
            // 
            // cmbZone
            // 
            this.cmbZone.Location = new System.Drawing.Point(880, 25);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(180, 21);
            this.cmbZone.TabIndex = 7;
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.lblCategory);
            this.grpDetails.Controls.Add(this.txtCategory);
            this.grpDetails.Controls.Add(this.lblItem);
            this.grpDetails.Controls.Add(this.txtItem);
            this.grpDetails.Controls.Add(this.lblUnit);
            this.grpDetails.Controls.Add(this.txtUnit);
            this.grpDetails.Controls.Add(this.lblQty);
            this.grpDetails.Controls.Add(this.txtQty);
            this.grpDetails.Controls.Add(this.lblFrom);
            this.grpDetails.Controls.Add(this.dtFrom);
            this.grpDetails.Controls.Add(this.lblTo);
            this.grpDetails.Controls.Add(this.dtTo);
            this.grpDetails.Controls.Add(this.lblPriority);
            this.grpDetails.Controls.Add(this.cmbPriority);
            this.grpDetails.Controls.Add(this.lblStatus);
            this.grpDetails.Controls.Add(this.cmbStatus);
            this.grpDetails.Controls.Add(this.lblReqBy);
            this.grpDetails.Controls.Add(this.txtRequestedBy);
            this.grpDetails.Controls.Add(this.lblAppBy);
            this.grpDetails.Controls.Add(this.txtApprovedBy);
            this.grpDetails.Controls.Add(this.lblRemarks);
            this.grpDetails.Controls.Add(this.txtRemarks);
            this.grpDetails.Controls.Add(this.btnNew);
            this.grpDetails.Controls.Add(this.btnSave);
            this.grpDetails.Controls.Add(this.btnUpdate);
            this.grpDetails.Controls.Add(this.btnDelete);
            this.grpDetails.Controls.Add(this.btnClear);
            this.grpDetails.Location = new System.Drawing.Point(10, 155);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(1160, 255);
            this.grpDetails.TabIndex = 2;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Need Details";
            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(15, 30);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(70, 25);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Category";
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(90, 25);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(220, 20);
            this.txtCategory.TabIndex = 1;
            // 
            // lblItem
            // 
            this.lblItem.Location = new System.Drawing.Point(340, 30);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(40, 25);
            this.lblItem.TabIndex = 2;
            this.lblItem.Text = "Item";
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(385, 25);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(260, 20);
            this.txtItem.TabIndex = 3;
            // 
            // lblUnit
            // 
            this.lblUnit.Location = new System.Drawing.Point(675, 30);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(35, 25);
            this.lblUnit.TabIndex = 4;
            this.lblUnit.Text = "Unit";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(715, 25);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(90, 20);
            this.txtUnit.TabIndex = 5;
            // 
            // lblQty
            // 
            this.lblQty.Location = new System.Drawing.Point(835, 30);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(30, 25);
            this.lblQty.TabIndex = 6;
            this.lblQty.Text = "Qty";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(870, 25);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(100, 20);
            this.txtQty.TabIndex = 7;
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(15, 70);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(45, 25);
            this.lblFrom.TabIndex = 8;
            this.lblFrom.Text = "From";
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(90, 65);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(160, 20);
            this.dtFrom.TabIndex = 9;
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(280, 70);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(25, 25);
            this.lblTo.TabIndex = 10;
            this.lblTo.Text = "To";
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(315, 65);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(160, 20);
            this.dtTo.TabIndex = 11;
            // 
            // lblPriority
            // 
            this.lblPriority.Location = new System.Drawing.Point(510, 70);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(55, 25);
            this.lblPriority.TabIndex = 12;
            this.lblPriority.Text = "Priority";
            // 
            // cmbPriority
            // 
            this.cmbPriority.Location = new System.Drawing.Point(570, 65);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(130, 21);
            this.cmbPriority.TabIndex = 13;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(730, 70);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 25);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(780, 65);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(140, 21);
            this.cmbStatus.TabIndex = 15;
            // 
            // lblReqBy
            // 
            this.lblReqBy.Location = new System.Drawing.Point(15, 110);
            this.lblReqBy.Name = "lblReqBy";
            this.lblReqBy.Size = new System.Drawing.Size(70, 25);
            this.lblReqBy.TabIndex = 16;
            this.lblReqBy.Text = "Requested";
            // 
            // txtRequestedBy
            // 
            this.txtRequestedBy.Location = new System.Drawing.Point(90, 105);
            this.txtRequestedBy.Name = "txtRequestedBy";
            this.txtRequestedBy.Size = new System.Drawing.Size(220, 20);
            this.txtRequestedBy.TabIndex = 17;
            // 
            // lblAppBy
            // 
            this.lblAppBy.Location = new System.Drawing.Point(340, 110);
            this.lblAppBy.Name = "lblAppBy";
            this.lblAppBy.Size = new System.Drawing.Size(70, 25);
            this.lblAppBy.TabIndex = 18;
            this.lblAppBy.Text = "Approved";
            // 
            // txtApprovedBy
            // 
            this.txtApprovedBy.Location = new System.Drawing.Point(415, 105);
            this.txtApprovedBy.Name = "txtApprovedBy";
            this.txtApprovedBy.Size = new System.Drawing.Size(220, 20);
            this.txtApprovedBy.TabIndex = 19;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Location = new System.Drawing.Point(15, 150);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(60, 25);
            this.lblRemarks.TabIndex = 20;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(90, 145);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(620, 55);
            this.txtRemarks.TabIndex = 21;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(871, 97);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(120, 35);
            this.btnNew.TabIndex = 22;
            this.btnNew.Text = "New";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1011, 97);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(871, 147);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 35);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "Update";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1011, 147);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 35);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "Delete";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(941, 197);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 35);
            this.btnClear.TabIndex = 26;
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
            // frmResourceNeeds
            // 
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmResourceNeeds";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resource Needs";
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