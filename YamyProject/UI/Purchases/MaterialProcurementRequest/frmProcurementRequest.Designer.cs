using System.Windows.Forms;

namespace YamyProject.UI.Purchases.MaterialProcurementRequest
{
    partial class frmProcurementRequest
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

        private Label lblNo, lblDate, lblMR, lblReservation, lblProject, lblSupplier, lblPriority, lblReqDate, lblStatus, lblRemarks;

        private TextBox txtNo, txtRemarks;
        private DateTimePicker dtDate, dtReqDate;

        private ComboBox cmbMR, cmbReservation, cmbProject, cmbSupplier, cmbPriority, cmbStatus;

        private GroupBox grpItems;

        private ComboBox cmbItem;
        private TextBox txtQty, txtUom, txtRate, txtAmount, txtItemRemarks;

        private Button btnAddItem;

        private DataGridView dgvItems;

        private Button btnNew, btnSave, btnUpdate, btnDelete, btnApprove, btnClear;

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpHeader = new System.Windows.Forms.GroupBox();
            this.lblNo = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.lblMR = new System.Windows.Forms.Label();
            this.cmbMR = new System.Windows.Forms.ComboBox();
            this.lblReservation = new System.Windows.Forms.Label();
            this.cmbReservation = new System.Windows.Forms.ComboBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.lblReqDate = new System.Windows.Forms.Label();
            this.dtReqDate = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblUom = new System.Windows.Forms.Label();
            this.txtUom = new System.Windows.Forms.TextBox();
            this.lblRate = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.lblAmt = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.grpHeader.SuspendLayout();
            this.grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
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
            this.lblTitle.Size = new System.Drawing.Size(239, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "PROCUREMENT REQUEST";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.lblNo);
            this.grpHeader.Controls.Add(this.txtNo);
            this.grpHeader.Controls.Add(this.lblDate);
            this.grpHeader.Controls.Add(this.dtDate);
            this.grpHeader.Controls.Add(this.lblMR);
            this.grpHeader.Controls.Add(this.cmbMR);
            this.grpHeader.Controls.Add(this.lblReservation);
            this.grpHeader.Controls.Add(this.cmbReservation);
            this.grpHeader.Controls.Add(this.lblProject);
            this.grpHeader.Controls.Add(this.cmbProject);
            this.grpHeader.Controls.Add(this.lblSupplier);
            this.grpHeader.Controls.Add(this.cmbSupplier);
            this.grpHeader.Controls.Add(this.lblPriority);
            this.grpHeader.Controls.Add(this.cmbPriority);
            this.grpHeader.Controls.Add(this.lblReqDate);
            this.grpHeader.Controls.Add(this.dtReqDate);
            this.grpHeader.Controls.Add(this.lblStatus);
            this.grpHeader.Controls.Add(this.cmbStatus);
            this.grpHeader.Controls.Add(this.lblRemarks);
            this.grpHeader.Controls.Add(this.txtRemarks);
            this.grpHeader.Location = new System.Drawing.Point(10, 65);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1160, 180);
            this.grpHeader.TabIndex = 1;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "PR Header";
            // 
            // lblNo
            // 
            this.lblNo.Location = new System.Drawing.Point(15, 30);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(50, 25);
            this.lblNo.TabIndex = 0;
            this.lblNo.Text = "PR No";
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(70, 25);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(150, 20);
            this.txtNo.TabIndex = 1;
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(250, 30);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(40, 25);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date";
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(295, 25);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(150, 20);
            this.dtDate.TabIndex = 3;
            // 
            // lblMR
            // 
            this.lblMR.Location = new System.Drawing.Point(470, 30);
            this.lblMR.Name = "lblMR";
            this.lblMR.Size = new System.Drawing.Size(30, 25);
            this.lblMR.TabIndex = 4;
            this.lblMR.Text = "MR";
            // 
            // cmbMR
            // 
            this.cmbMR.Location = new System.Drawing.Point(505, 25);
            this.cmbMR.Name = "cmbMR";
            this.cmbMR.Size = new System.Drawing.Size(180, 21);
            this.cmbMR.TabIndex = 5;
            // 
            // lblReservation
            // 
            this.lblReservation.Location = new System.Drawing.Point(710, 30);
            this.lblReservation.Name = "lblReservation";
            this.lblReservation.Size = new System.Drawing.Size(35, 25);
            this.lblReservation.TabIndex = 6;
            this.lblReservation.Text = "RSV";
            // 
            // cmbReservation
            // 
            this.cmbReservation.Location = new System.Drawing.Point(750, 25);
            this.cmbReservation.Name = "cmbReservation";
            this.cmbReservation.Size = new System.Drawing.Size(180, 21);
            this.cmbReservation.TabIndex = 7;
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(15, 70);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(55, 25);
            this.lblProject.TabIndex = 8;
            this.lblProject.Text = "Project";
            // 
            // cmbProject
            // 
            this.cmbProject.Location = new System.Drawing.Point(70, 65);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(250, 21);
            this.cmbProject.TabIndex = 9;
            // 
            // lblSupplier
            // 
            this.lblSupplier.Location = new System.Drawing.Point(345, 70);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(55, 25);
            this.lblSupplier.TabIndex = 10;
            this.lblSupplier.Text = "Supplier";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.Location = new System.Drawing.Point(405, 65);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(250, 21);
            this.cmbSupplier.TabIndex = 11;
            // 
            // lblPriority
            // 
            this.lblPriority.Location = new System.Drawing.Point(680, 70);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(50, 25);
            this.lblPriority.TabIndex = 12;
            this.lblPriority.Text = "Priority";
            // 
            // cmbPriority
            // 
            this.cmbPriority.Location = new System.Drawing.Point(735, 65);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(120, 21);
            this.cmbPriority.TabIndex = 13;
            // 
            // lblReqDate
            // 
            this.lblReqDate.Location = new System.Drawing.Point(15, 110);
            this.lblReqDate.Name = "lblReqDate";
            this.lblReqDate.Size = new System.Drawing.Size(60, 25);
            this.lblReqDate.TabIndex = 14;
            this.lblReqDate.Text = "Req Date";
            // 
            // dtReqDate
            // 
            this.dtReqDate.Location = new System.Drawing.Point(80, 105);
            this.dtReqDate.Name = "dtReqDate";
            this.dtReqDate.Size = new System.Drawing.Size(150, 20);
            this.dtReqDate.TabIndex = 15;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(260, 110);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 25);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(315, 105);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 21);
            this.cmbStatus.TabIndex = 17;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Location = new System.Drawing.Point(490, 110);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(60, 25);
            this.lblRemarks.TabIndex = 18;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(555, 105);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(375, 20);
            this.txtRemarks.TabIndex = 19;
            // 
            // grpItems
            // 
            this.grpItems.Controls.Add(this.lblItem);
            this.grpItems.Controls.Add(this.cmbItem);
            this.grpItems.Controls.Add(this.lblQty);
            this.grpItems.Controls.Add(this.txtQty);
            this.grpItems.Controls.Add(this.lblUom);
            this.grpItems.Controls.Add(this.txtUom);
            this.grpItems.Controls.Add(this.lblRate);
            this.grpItems.Controls.Add(this.txtRate);
            this.grpItems.Controls.Add(this.lblAmt);
            this.grpItems.Controls.Add(this.txtAmount);
            this.grpItems.Controls.Add(this.btnAddItem);
            this.grpItems.Controls.Add(this.dgvItems);
            this.grpItems.Location = new System.Drawing.Point(10, 250);
            this.grpItems.Name = "grpItems";
            this.grpItems.Size = new System.Drawing.Size(1160, 300);
            this.grpItems.TabIndex = 2;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "PR Items";
            // 
            // lblItem
            // 
            this.lblItem.Location = new System.Drawing.Point(15, 30);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(40, 25);
            this.lblItem.TabIndex = 0;
            this.lblItem.Text = "Item";
            // 
            // cmbItem
            // 
            this.cmbItem.Location = new System.Drawing.Point(60, 25);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(280, 21);
            this.cmbItem.TabIndex = 1;
            // 
            // lblQty
            // 
            this.lblQty.Location = new System.Drawing.Point(355, 30);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(30, 25);
            this.lblQty.TabIndex = 2;
            this.lblQty.Text = "Qty";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(390, 25);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(80, 20);
            this.txtQty.TabIndex = 3;
            // 
            // lblUom
            // 
            this.lblUom.Location = new System.Drawing.Point(485, 30);
            this.lblUom.Name = "lblUom";
            this.lblUom.Size = new System.Drawing.Size(40, 25);
            this.lblUom.TabIndex = 4;
            this.lblUom.Text = "UOM";
            // 
            // txtUom
            // 
            this.txtUom.Location = new System.Drawing.Point(530, 25);
            this.txtUom.Name = "txtUom";
            this.txtUom.Size = new System.Drawing.Size(70, 20);
            this.txtUom.TabIndex = 5;
            // 
            // lblRate
            // 
            this.lblRate.Location = new System.Drawing.Point(615, 30);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(35, 25);
            this.lblRate.TabIndex = 6;
            this.lblRate.Text = "Rate";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(655, 25);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(80, 20);
            this.txtRate.TabIndex = 7;
            // 
            // lblAmt
            // 
            this.lblAmt.Location = new System.Drawing.Point(750, 30);
            this.lblAmt.Name = "lblAmt";
            this.lblAmt.Size = new System.Drawing.Size(55, 25);
            this.lblAmt.TabIndex = 8;
            this.lblAmt.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(810, 25);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(90, 20);
            this.txtAmount.TabIndex = 9;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(930, 25);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(90, 28);
            this.btnAddItem.TabIndex = 10;
            this.btnAddItem.Text = "Add";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.Location = new System.Drawing.Point(15, 65);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(1125, 220);
            this.dgvItems.TabIndex = 11;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(180, 570);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(110, 35);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(300, 570);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(420, 570);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 35);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(540, 570);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 35);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(660, 570);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(110, 35);
            this.btnApprove.TabIndex = 7;
            this.btnApprove.Text = "Approve";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(780, 570);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 35);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            // 
            // frmProcurementRequest
            // 
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.grpItems);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnClear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProcurementRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procurement Request";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.grpItems.ResumeLayout(false);
            this.grpItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        private Label lblItem;
        private Label lblQty;
        private Label lblUom;
        private Label lblRate;
        private Label lblAmt;
    }
}