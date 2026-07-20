using System.Windows.Forms;

namespace YamyProject.UI.Purchases
{
    partial class frmMaterialReservation
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

        private Label lblNo;
        private Label lblDate;
        private Label lblMR;
        private Label lblProject;
        private Label lblWarehouse;
        private Label lblStatus;

        private TextBox txtNo;
        private DateTimePicker dtDate;
        private ComboBox cmbMR;
        private ComboBox cmbProject;
        private ComboBox cmbWarehouse;
        private ComboBox cmbStatus;

        private Label lblRemarks;
        private TextBox txtRemarks;

        private GroupBox grpItems;

        private ComboBox cmbItem;
        private TextBox txtReqQty;
        private TextBox txtAvailQty;
        private TextBox txtReserveQty;
        private TextBox txtUom;
        private Button btnAddItem;

        private Label lblItem;
        private Label lblReq;
        private Label lblAvail;
        private Label lblRes;
        private Label lblUom;

        private DataGridView dgvItems;

        private Button btnNew;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnApprove;
        private Button btnClear;

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
            this.lblProject = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.lblReq = new System.Windows.Forms.Label();
            this.txtReqQty = new System.Windows.Forms.TextBox();
            this.lblAvail = new System.Windows.Forms.Label();
            this.txtAvailQty = new System.Windows.Forms.TextBox();
            this.lblRes = new System.Windows.Forms.Label();
            this.txtReserveQty = new System.Windows.Forms.TextBox();
            this.lblUom = new System.Windows.Forms.Label();
            this.txtUom = new System.Windows.Forms.TextBox();
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
            this.lblTitle.Size = new System.Drawing.Size(234, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "MATERIAL RESERVATION";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.lblNo);
            this.grpHeader.Controls.Add(this.txtNo);
            this.grpHeader.Controls.Add(this.lblDate);
            this.grpHeader.Controls.Add(this.dtDate);
            this.grpHeader.Controls.Add(this.lblMR);
            this.grpHeader.Controls.Add(this.cmbMR);
            this.grpHeader.Controls.Add(this.lblProject);
            this.grpHeader.Controls.Add(this.cmbProject);
            this.grpHeader.Controls.Add(this.lblWarehouse);
            this.grpHeader.Controls.Add(this.cmbWarehouse);
            this.grpHeader.Controls.Add(this.lblStatus);
            this.grpHeader.Controls.Add(this.cmbStatus);
            this.grpHeader.Controls.Add(this.lblRemarks);
            this.grpHeader.Controls.Add(this.txtRemarks);
            this.grpHeader.Location = new System.Drawing.Point(10, 65);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1160, 150);
            this.grpHeader.TabIndex = 1;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Reservation Header";
            // 
            // lblNo
            // 
            this.lblNo.Location = new System.Drawing.Point(15, 30);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(40, 25);
            this.lblNo.TabIndex = 0;
            this.lblNo.Text = "No";
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(60, 25);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(150, 20);
            this.txtNo.TabIndex = 1;
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(240, 30);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(40, 25);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date";
            // 
            // dtDate
            // 
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(285, 25);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(150, 20);
            this.dtDate.TabIndex = 3;
            // 
            // lblMR
            // 
            this.lblMR.Location = new System.Drawing.Point(460, 30);
            this.lblMR.Name = "lblMR";
            this.lblMR.Size = new System.Drawing.Size(30, 25);
            this.lblMR.TabIndex = 4;
            this.lblMR.Text = "MR";
            // 
            // cmbMR
            // 
            this.cmbMR.Location = new System.Drawing.Point(495, 25);
            this.cmbMR.Name = "cmbMR";
            this.cmbMR.Size = new System.Drawing.Size(220, 21);
            this.cmbMR.TabIndex = 5;
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(15, 70);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(40, 25);
            this.lblProject.TabIndex = 6;
            this.lblProject.Text = "Project";
            // 
            // cmbProject
            // 
            this.cmbProject.Location = new System.Drawing.Point(60, 65);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(250, 21);
            this.cmbProject.TabIndex = 7;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.Location = new System.Drawing.Point(340, 70);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(80, 25);
            this.lblWarehouse.TabIndex = 8;
            this.lblWarehouse.Text = "Warehouse";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.Location = new System.Drawing.Point(425, 65);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(220, 21);
            this.cmbWarehouse.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(680, 70);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 25);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(735, 65);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 21);
            this.cmbStatus.TabIndex = 11;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Location = new System.Drawing.Point(15, 110);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(60, 25);
            this.lblRemarks.TabIndex = 12;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(80, 105);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(800, 20);
            this.txtRemarks.TabIndex = 13;
            // 
            // grpItems
            // 
            this.grpItems.Controls.Add(this.lblItem);
            this.grpItems.Controls.Add(this.cmbItem);
            this.grpItems.Controls.Add(this.lblReq);
            this.grpItems.Controls.Add(this.txtReqQty);
            this.grpItems.Controls.Add(this.lblAvail);
            this.grpItems.Controls.Add(this.txtAvailQty);
            this.grpItems.Controls.Add(this.lblRes);
            this.grpItems.Controls.Add(this.txtReserveQty);
            this.grpItems.Controls.Add(this.lblUom);
            this.grpItems.Controls.Add(this.txtUom);
            this.grpItems.Controls.Add(this.btnAddItem);
            this.grpItems.Controls.Add(this.dgvItems);
            this.grpItems.Location = new System.Drawing.Point(10, 220);
            this.grpItems.Name = "grpItems";
            this.grpItems.Size = new System.Drawing.Size(1160, 330);
            this.grpItems.TabIndex = 2;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "Items";
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
            // lblReq
            // 
            this.lblReq.Location = new System.Drawing.Point(360, 30);
            this.lblReq.Name = "lblReq";
            this.lblReq.Size = new System.Drawing.Size(35, 25);
            this.lblReq.TabIndex = 2;
            this.lblReq.Text = "Req";
            // 
            // txtReqQty
            // 
            this.txtReqQty.Location = new System.Drawing.Point(395, 25);
            this.txtReqQty.Name = "txtReqQty";
            this.txtReqQty.Size = new System.Drawing.Size(90, 20);
            this.txtReqQty.TabIndex = 3;
            // 
            // lblAvail
            // 
            this.lblAvail.Location = new System.Drawing.Point(500, 30);
            this.lblAvail.Name = "lblAvail";
            this.lblAvail.Size = new System.Drawing.Size(40, 25);
            this.lblAvail.TabIndex = 4;
            this.lblAvail.Text = "Avail";
            // 
            // txtAvailQty
            // 
            this.txtAvailQty.Location = new System.Drawing.Point(545, 25);
            this.txtAvailQty.Name = "txtAvailQty";
            this.txtAvailQty.Size = new System.Drawing.Size(90, 20);
            this.txtAvailQty.TabIndex = 5;
            // 
            // lblRes
            // 
            this.lblRes.Location = new System.Drawing.Point(650, 30);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(60, 25);
            this.lblRes.TabIndex = 6;
            this.lblRes.Text = "Reserve";
            // 
            // txtReserveQty
            // 
            this.txtReserveQty.Location = new System.Drawing.Point(715, 25);
            this.txtReserveQty.Name = "txtReserveQty";
            this.txtReserveQty.Size = new System.Drawing.Size(90, 20);
            this.txtReserveQty.TabIndex = 7;
            // 
            // lblUom
            // 
            this.lblUom.Location = new System.Drawing.Point(820, 30);
            this.lblUom.Name = "lblUom";
            this.lblUom.Size = new System.Drawing.Size(40, 25);
            this.lblUom.TabIndex = 8;
            this.lblUom.Text = "UOM";
            // 
            // txtUom
            // 
            this.txtUom.Location = new System.Drawing.Point(865, 25);
            this.txtUom.Name = "txtUom";
            this.txtUom.Size = new System.Drawing.Size(70, 20);
            this.txtUom.TabIndex = 9;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(960, 25);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(100, 28);
            this.btnAddItem.TabIndex = 10;
            this.btnAddItem.Text = "Add";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.Location = new System.Drawing.Point(15, 65);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.Size = new System.Drawing.Size(1125, 245);
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
            // frmMaterialReservation
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
            this.Name = "frmMaterialReservation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Material Reservation";
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
    }
}