using System.Windows.Forms;

namespace YamyProject.UI.Purchases.MaterialTransfer
{
    partial class frmMaterialTransfer
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
        private GroupBox grpItems;
        private GroupBox grpSummary;

        private TextBox txtNo;
        private DateTimePicker dtDate;

        private ComboBox cmbTransferType;

        private ComboBox cmbFromWarehouse;
        private ComboBox cmbToWarehouse;

        private ComboBox cmbFromProject;
        private ComboBox cmbToProject;

        private ComboBox cmbRequestedBy;
        private ComboBox cmbReceivedBy;

        private TextBox txtVehicle;
        private TextBox txtDriver;

        private ComboBox cmbStatus;

        private TextBox txtRemarks;

        private ComboBox cmbItem;

        private TextBox txtAvailableQty;
        private TextBox txtTransferQty;
        private TextBox txtUom;
        private TextBox txtCost;
        private TextBox txtTotal;

        private Button btnAddItem;

        private DataGridView dgvItems;

        private TextBox txtGrandTotal;

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
            this.h1 = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.h2 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.h3 = new System.Windows.Forms.Label();
            this.cmbTransferType = new System.Windows.Forms.ComboBox();
            this.h4 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.h5 = new System.Windows.Forms.Label();
            this.cmbFromWarehouse = new System.Windows.Forms.ComboBox();
            this.h6 = new System.Windows.Forms.Label();
            this.cmbToWarehouse = new System.Windows.Forms.ComboBox();
            this.h7 = new System.Windows.Forms.Label();
            this.cmbRequestedBy = new System.Windows.Forms.ComboBox();
            this.h8 = new System.Windows.Forms.Label();
            this.cmbReceivedBy = new System.Windows.Forms.ComboBox();
            this.h9 = new System.Windows.Forms.Label();
            this.cmbFromProject = new System.Windows.Forms.ComboBox();
            this.h10 = new System.Windows.Forms.Label();
            this.cmbToProject = new System.Windows.Forms.ComboBox();
            this.h11 = new System.Windows.Forms.Label();
            this.txtVehicle = new System.Windows.Forms.TextBox();
            this.h12 = new System.Windows.Forms.Label();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.h13 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.i1 = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.i2 = new System.Windows.Forms.Label();
            this.txtAvailableQty = new System.Windows.Forms.TextBox();
            this.i3 = new System.Windows.Forms.Label();
            this.txtTransferQty = new System.Windows.Forms.TextBox();
            this.i4 = new System.Windows.Forms.Label();
            this.txtUom = new System.Windows.Forms.TextBox();
            this.i5 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.i6 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.s1 = new System.Windows.Forms.Label();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
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
            this.grpSummary.SuspendLayout();
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
            this.lblTitle.Size = new System.Drawing.Size(203, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "MATERIAL TRANSFER";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.h1);
            this.grpHeader.Controls.Add(this.txtNo);
            this.grpHeader.Controls.Add(this.h2);
            this.grpHeader.Controls.Add(this.dtDate);
            this.grpHeader.Controls.Add(this.h3);
            this.grpHeader.Controls.Add(this.cmbTransferType);
            this.grpHeader.Controls.Add(this.h4);
            this.grpHeader.Controls.Add(this.cmbStatus);
            this.grpHeader.Controls.Add(this.h5);
            this.grpHeader.Controls.Add(this.cmbFromWarehouse);
            this.grpHeader.Controls.Add(this.h6);
            this.grpHeader.Controls.Add(this.cmbToWarehouse);
            this.grpHeader.Controls.Add(this.h7);
            this.grpHeader.Controls.Add(this.cmbRequestedBy);
            this.grpHeader.Controls.Add(this.h8);
            this.grpHeader.Controls.Add(this.cmbReceivedBy);
            this.grpHeader.Controls.Add(this.h9);
            this.grpHeader.Controls.Add(this.cmbFromProject);
            this.grpHeader.Controls.Add(this.h10);
            this.grpHeader.Controls.Add(this.cmbToProject);
            this.grpHeader.Controls.Add(this.h11);
            this.grpHeader.Controls.Add(this.txtVehicle);
            this.grpHeader.Controls.Add(this.h12);
            this.grpHeader.Controls.Add(this.txtDriver);
            this.grpHeader.Controls.Add(this.h13);
            this.grpHeader.Controls.Add(this.txtRemarks);
            this.grpHeader.Location = new System.Drawing.Point(10, 65);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1160, 200);
            this.grpHeader.TabIndex = 1;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Transfer Header";
            // 
            // h1
            // 
            this.h1.Location = new System.Drawing.Point(15, 30);
            this.h1.Name = "h1";
            this.h1.Size = new System.Drawing.Size(75, 25);
            this.h1.TabIndex = 0;
            this.h1.Text = "Transfer No";
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(95, 30);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(150, 20);
            this.txtNo.TabIndex = 1;
            // 
            // h2
            // 
            this.h2.Location = new System.Drawing.Point(260, 30);
            this.h2.Name = "h2";
            this.h2.Size = new System.Drawing.Size(40, 25);
            this.h2.TabIndex = 2;
            this.h2.Text = "Date";
            // 
            // dtDate
            // 
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(305, 30);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(150, 20);
            this.dtDate.TabIndex = 3;
            // 
            // h3
            // 
            this.h3.Location = new System.Drawing.Point(470, 30);
            this.h3.Name = "h3";
            this.h3.Size = new System.Drawing.Size(40, 25);
            this.h3.TabIndex = 4;
            this.h3.Text = "Type";
            // 
            // cmbTransferType
            // 
            this.cmbTransferType.Location = new System.Drawing.Point(515, 30);
            this.cmbTransferType.Name = "cmbTransferType";
            this.cmbTransferType.Size = new System.Drawing.Size(180, 21);
            this.cmbTransferType.TabIndex = 5;
            // 
            // h4
            // 
            this.h4.Location = new System.Drawing.Point(715, 30);
            this.h4.Name = "h4";
            this.h4.Size = new System.Drawing.Size(50, 25);
            this.h4.TabIndex = 6;
            this.h4.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(770, 30);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 21);
            this.cmbStatus.TabIndex = 7;
            // 
            // h5
            // 
            this.h5.Location = new System.Drawing.Point(15, 70);
            this.h5.Name = "h5";
            this.h5.Size = new System.Drawing.Size(65, 25);
            this.h5.TabIndex = 8;
            this.h5.Text = "From WH";
            // 
            // cmbFromWarehouse
            // 
            this.cmbFromWarehouse.Location = new System.Drawing.Point(85, 70);
            this.cmbFromWarehouse.Name = "cmbFromWarehouse";
            this.cmbFromWarehouse.Size = new System.Drawing.Size(220, 21);
            this.cmbFromWarehouse.TabIndex = 9;
            // 
            // h6
            // 
            this.h6.Location = new System.Drawing.Point(325, 70);
            this.h6.Name = "h6";
            this.h6.Size = new System.Drawing.Size(50, 25);
            this.h6.TabIndex = 10;
            this.h6.Text = "To WH";
            // 
            // cmbToWarehouse
            // 
            this.cmbToWarehouse.Location = new System.Drawing.Point(380, 70);
            this.cmbToWarehouse.Name = "cmbToWarehouse";
            this.cmbToWarehouse.Size = new System.Drawing.Size(220, 21);
            this.cmbToWarehouse.TabIndex = 11;
            // 
            // h7
            // 
            this.h7.Location = new System.Drawing.Point(620, 70);
            this.h7.Name = "h7";
            this.h7.Size = new System.Drawing.Size(65, 25);
            this.h7.TabIndex = 12;
            this.h7.Text = "Requested";
            // 
            // cmbRequestedBy
            // 
            this.cmbRequestedBy.Location = new System.Drawing.Point(690, 70);
            this.cmbRequestedBy.Name = "cmbRequestedBy";
            this.cmbRequestedBy.Size = new System.Drawing.Size(180, 21);
            this.cmbRequestedBy.TabIndex = 13;
            // 
            // h8
            // 
            this.h8.Location = new System.Drawing.Point(890, 70);
            this.h8.Name = "h8";
            this.h8.Size = new System.Drawing.Size(60, 25);
            this.h8.TabIndex = 14;
            this.h8.Text = "Received";
            // 
            // cmbReceivedBy
            // 
            this.cmbReceivedBy.Location = new System.Drawing.Point(955, 70);
            this.cmbReceivedBy.Name = "cmbReceivedBy";
            this.cmbReceivedBy.Size = new System.Drawing.Size(180, 21);
            this.cmbReceivedBy.TabIndex = 15;
            // 
            // h9
            // 
            this.h9.Location = new System.Drawing.Point(15, 110);
            this.h9.Name = "h9";
            this.h9.Size = new System.Drawing.Size(80, 25);
            this.h9.TabIndex = 16;
            this.h9.Text = "From Project";
            // 
            // cmbFromProject
            // 
            this.cmbFromProject.Location = new System.Drawing.Point(100, 110);
            this.cmbFromProject.Name = "cmbFromProject";
            this.cmbFromProject.Size = new System.Drawing.Size(250, 21);
            this.cmbFromProject.TabIndex = 17;
            // 
            // h10
            // 
            this.h10.Location = new System.Drawing.Point(370, 110);
            this.h10.Name = "h10";
            this.h10.Size = new System.Drawing.Size(70, 25);
            this.h10.TabIndex = 18;
            this.h10.Text = "To Project";
            // 
            // cmbToProject
            // 
            this.cmbToProject.Location = new System.Drawing.Point(445, 110);
            this.cmbToProject.Name = "cmbToProject";
            this.cmbToProject.Size = new System.Drawing.Size(250, 21);
            this.cmbToProject.TabIndex = 19;
            // 
            // h11
            // 
            this.h11.Location = new System.Drawing.Point(715, 110);
            this.h11.Name = "h11";
            this.h11.Size = new System.Drawing.Size(50, 25);
            this.h11.TabIndex = 20;
            this.h11.Text = "Vehicle";
            // 
            // txtVehicle
            // 
            this.txtVehicle.Location = new System.Drawing.Point(770, 110);
            this.txtVehicle.Name = "txtVehicle";
            this.txtVehicle.Size = new System.Drawing.Size(120, 20);
            this.txtVehicle.TabIndex = 21;
            // 
            // h12
            // 
            this.h12.Location = new System.Drawing.Point(905, 110);
            this.h12.Name = "h12";
            this.h12.Size = new System.Drawing.Size(45, 25);
            this.h12.TabIndex = 22;
            this.h12.Text = "Driver";
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(955, 110);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(180, 20);
            this.txtDriver.TabIndex = 23;
            // 
            // h13
            // 
            this.h13.Location = new System.Drawing.Point(15, 150);
            this.h13.Name = "h13";
            this.h13.Size = new System.Drawing.Size(60, 25);
            this.h13.TabIndex = 24;
            this.h13.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(80, 150);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(1055, 20);
            this.txtRemarks.TabIndex = 25;
            // 
            // grpItems
            // 
            this.grpItems.Controls.Add(this.btnAddItem);
            this.grpItems.Controls.Add(this.i1);
            this.grpItems.Controls.Add(this.cmbItem);
            this.grpItems.Controls.Add(this.i2);
            this.grpItems.Controls.Add(this.txtAvailableQty);
            this.grpItems.Controls.Add(this.i3);
            this.grpItems.Controls.Add(this.txtTransferQty);
            this.grpItems.Controls.Add(this.i4);
            this.grpItems.Controls.Add(this.txtUom);
            this.grpItems.Controls.Add(this.i5);
            this.grpItems.Controls.Add(this.txtCost);
            this.grpItems.Controls.Add(this.i6);
            this.grpItems.Controls.Add(this.txtTotal);
            this.grpItems.Controls.Add(this.dgvItems);
            this.grpItems.Location = new System.Drawing.Point(10, 270);
            this.grpItems.Name = "grpItems";
            this.grpItems.Size = new System.Drawing.Size(1160, 270);
            this.grpItems.TabIndex = 2;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "Transfer Items";
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddItem.Location = new System.Drawing.Point(1000, 25);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(80, 28);
            this.btnAddItem.TabIndex = 12;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.UseVisualStyleBackColor = false;
            // 
            // i1
            // 
            this.i1.Location = new System.Drawing.Point(15, 30);
            this.i1.Name = "i1";
            this.i1.Size = new System.Drawing.Size(40, 25);
            this.i1.TabIndex = 0;
            this.i1.Text = "Item";
            // 
            // cmbItem
            // 
            this.cmbItem.Location = new System.Drawing.Point(60, 25);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(250, 21);
            this.cmbItem.TabIndex = 1;
            // 
            // i2
            // 
            this.i2.Location = new System.Drawing.Point(325, 30);
            this.i2.Name = "i2";
            this.i2.Size = new System.Drawing.Size(60, 25);
            this.i2.TabIndex = 2;
            this.i2.Text = "Available";
            // 
            // txtAvailableQty
            // 
            this.txtAvailableQty.Location = new System.Drawing.Point(390, 25);
            this.txtAvailableQty.Name = "txtAvailableQty";
            this.txtAvailableQty.Size = new System.Drawing.Size(70, 20);
            this.txtAvailableQty.TabIndex = 3;
            // 
            // i3
            // 
            this.i3.Location = new System.Drawing.Point(475, 30);
            this.i3.Name = "i3";
            this.i3.Size = new System.Drawing.Size(55, 25);
            this.i3.TabIndex = 4;
            this.i3.Text = "Transfer";
            // 
            // txtTransferQty
            // 
            this.txtTransferQty.Location = new System.Drawing.Point(535, 25);
            this.txtTransferQty.Name = "txtTransferQty";
            this.txtTransferQty.Size = new System.Drawing.Size(70, 20);
            this.txtTransferQty.TabIndex = 5;
            // 
            // i4
            // 
            this.i4.Location = new System.Drawing.Point(620, 30);
            this.i4.Name = "i4";
            this.i4.Size = new System.Drawing.Size(40, 25);
            this.i4.TabIndex = 6;
            this.i4.Text = "UOM";
            // 
            // txtUom
            // 
            this.txtUom.Location = new System.Drawing.Point(665, 25);
            this.txtUom.Name = "txtUom";
            this.txtUom.Size = new System.Drawing.Size(60, 20);
            this.txtUom.TabIndex = 7;
            // 
            // i5
            // 
            this.i5.Location = new System.Drawing.Point(740, 30);
            this.i5.Name = "i5";
            this.i5.Size = new System.Drawing.Size(35, 25);
            this.i5.TabIndex = 8;
            this.i5.Text = "Cost";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(780, 25);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(70, 20);
            this.txtCost.TabIndex = 9;
            // 
            // i6
            // 
            this.i6.Location = new System.Drawing.Point(865, 30);
            this.i6.Name = "i6";
            this.i6.Size = new System.Drawing.Size(35, 25);
            this.i6.TabIndex = 10;
            this.i6.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(905, 25);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(80, 20);
            this.txtTotal.TabIndex = 11;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.Location = new System.Drawing.Point(15, 70);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(1125, 180);
            this.dgvItems.TabIndex = 13;
            // 
            // grpSummary
            // 
            this.grpSummary.Controls.Add(this.s1);
            this.grpSummary.Controls.Add(this.txtGrandTotal);
            this.grpSummary.Location = new System.Drawing.Point(930, 545);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(240, 70);
            this.grpSummary.TabIndex = 3;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "Summary";
            // 
            // s1
            // 
            this.s1.Location = new System.Drawing.Point(15, 30);
            this.s1.Name = "s1";
            this.s1.Size = new System.Drawing.Size(80, 25);
            this.s1.TabIndex = 0;
            this.s1.Text = "Grand Total";
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Location = new System.Drawing.Point(100, 25);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.Size = new System.Drawing.Size(120, 20);
            this.txtGrandTotal.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNew.Location = new System.Drawing.Point(120, 565);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(110, 35);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.Location = new System.Drawing.Point(240, 565);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnUpdate.Location = new System.Drawing.Point(360, 565);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 35);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDelete.Location = new System.Drawing.Point(480, 565);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 35);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnApprove.Location = new System.Drawing.Point(600, 565);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(110, 35);
            this.btnApprove.TabIndex = 8;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClear.Location = new System.Drawing.Point(720, 565);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 35);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // frmMaterialTransfer
            // 
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.grpItems);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnClear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMaterialTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Material Transfer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.grpItems.ResumeLayout(false);
            this.grpItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.grpSummary.ResumeLayout(false);
            this.grpSummary.PerformLayout();
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
        private Label h13;
        private Label i1;
        private Label i2;
        private Label i3;
        private Label i4;
        private Label i5;
        private Label i6;
        private Label s1;
    }
}