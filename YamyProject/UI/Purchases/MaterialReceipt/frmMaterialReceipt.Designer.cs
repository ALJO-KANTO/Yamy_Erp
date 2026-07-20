using System.Windows.Forms;

namespace YamyProject.UI.Purchases.MaterialReceipt
{
    partial class frmMaterialReceipt
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

        private ComboBox cmbPO;
        private ComboBox cmbSupplier;
        private ComboBox cmbProject;
        private ComboBox cmbWarehouse;

        private TextBox txtInvoiceNo;
        private DateTimePicker dtInvoiceDate;

        private ComboBox cmbReceivedBy;
        private ComboBox cmbCheckedBy;

        private TextBox txtVehicle;
        private TextBox txtDriver;

        private ComboBox cmbStatus;

        private TextBox txtRemarks;

        private ComboBox cmbItem;
        private TextBox txtOrderQty;
        private TextBox txtReceiveQty;
        private TextBox txtAcceptedQty;
        private TextBox txtRejectedQty;
        private TextBox txtUom;
        private TextBox txtCost;
        private TextBox txtLineTotal;

        private Button btnAddItem;

        private DataGridView dgvItems;

        private TextBox txtSubtotal;
        private TextBox txtVAT;
        private TextBox txtNet;

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
            this.l1 = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.l2 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.l3 = new System.Windows.Forms.Label();
            this.cmbPO = new System.Windows.Forms.ComboBox();
            this.l4 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.l5 = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.l6 = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.l7 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.l8 = new System.Windows.Forms.Label();
            this.dtInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.l9 = new System.Windows.Forms.Label();
            this.cmbReceivedBy = new System.Windows.Forms.ComboBox();
            this.l10 = new System.Windows.Forms.Label();
            this.cmbCheckedBy = new System.Windows.Forms.ComboBox();
            this.l11 = new System.Windows.Forms.Label();
            this.txtVehicle = new System.Windows.Forms.TextBox();
            this.l12 = new System.Windows.Forms.Label();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.l13 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.l14 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.i1 = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.i2 = new System.Windows.Forms.Label();
            this.txtOrderQty = new System.Windows.Forms.TextBox();
            this.i3 = new System.Windows.Forms.Label();
            this.txtReceiveQty = new System.Windows.Forms.TextBox();
            this.i4 = new System.Windows.Forms.Label();
            this.txtAcceptedQty = new System.Windows.Forms.TextBox();
            this.i5 = new System.Windows.Forms.Label();
            this.txtRejectedQty = new System.Windows.Forms.TextBox();
            this.i6 = new System.Windows.Forms.Label();
            this.txtUom = new System.Windows.Forms.TextBox();
            this.i7 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.i8 = new System.Windows.Forms.Label();
            this.txtLineTotal = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.s1 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.s2 = new System.Windows.Forms.Label();
            this.txtVAT = new System.Windows.Forms.TextBox();
            this.s3 = new System.Windows.Forms.Label();
            this.txtNet = new System.Windows.Forms.TextBox();
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
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
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
            this.lblTitle.Size = new System.Drawing.Size(241, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "MATERIAL RECEIPT / GRN";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.l1);
            this.grpHeader.Controls.Add(this.txtNo);
            this.grpHeader.Controls.Add(this.l2);
            this.grpHeader.Controls.Add(this.dtDate);
            this.grpHeader.Controls.Add(this.l3);
            this.grpHeader.Controls.Add(this.cmbPO);
            this.grpHeader.Controls.Add(this.l4);
            this.grpHeader.Controls.Add(this.cmbSupplier);
            this.grpHeader.Controls.Add(this.l5);
            this.grpHeader.Controls.Add(this.cmbProject);
            this.grpHeader.Controls.Add(this.l6);
            this.grpHeader.Controls.Add(this.cmbWarehouse);
            this.grpHeader.Controls.Add(this.l7);
            this.grpHeader.Controls.Add(this.txtInvoiceNo);
            this.grpHeader.Controls.Add(this.l8);
            this.grpHeader.Controls.Add(this.dtInvoiceDate);
            this.grpHeader.Controls.Add(this.l9);
            this.grpHeader.Controls.Add(this.cmbReceivedBy);
            this.grpHeader.Controls.Add(this.l10);
            this.grpHeader.Controls.Add(this.cmbCheckedBy);
            this.grpHeader.Controls.Add(this.l11);
            this.grpHeader.Controls.Add(this.txtVehicle);
            this.grpHeader.Controls.Add(this.l12);
            this.grpHeader.Controls.Add(this.txtDriver);
            this.grpHeader.Controls.Add(this.l13);
            this.grpHeader.Controls.Add(this.cmbStatus);
            this.grpHeader.Controls.Add(this.l14);
            this.grpHeader.Controls.Add(this.txtRemarks);
            this.grpHeader.Location = new System.Drawing.Point(10, 65);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1160, 210);
            this.grpHeader.TabIndex = 1;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Receipt Header";
            // 
            // l1
            // 
            this.l1.Location = new System.Drawing.Point(15, 30);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(55, 25);
            this.l1.TabIndex = 0;
            this.l1.Text = "GRN No";
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(75, 30);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(150, 20);
            this.txtNo.TabIndex = 1;
            // 
            // l2
            // 
            this.l2.Location = new System.Drawing.Point(245, 30);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(40, 25);
            this.l2.TabIndex = 2;
            this.l2.Text = "Date";
            // 
            // dtDate
            // 
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(290, 30);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(150, 20);
            this.dtDate.TabIndex = 3;
            // 
            // l3
            // 
            this.l3.Location = new System.Drawing.Point(460, 30);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(25, 25);
            this.l3.TabIndex = 4;
            this.l3.Text = "PO";
            // 
            // cmbPO
            // 
            this.cmbPO.Location = new System.Drawing.Point(490, 30);
            this.cmbPO.Name = "cmbPO";
            this.cmbPO.Size = new System.Drawing.Size(180, 21);
            this.cmbPO.TabIndex = 5;
            // 
            // l4
            // 
            this.l4.Location = new System.Drawing.Point(690, 30);
            this.l4.Name = "l4";
            this.l4.Size = new System.Drawing.Size(55, 25);
            this.l4.TabIndex = 6;
            this.l4.Text = "Supplier";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.Location = new System.Drawing.Point(750, 30);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(250, 21);
            this.cmbSupplier.TabIndex = 7;
            // 
            // l5
            // 
            this.l5.Location = new System.Drawing.Point(15, 70);
            this.l5.Name = "l5";
            this.l5.Size = new System.Drawing.Size(50, 25);
            this.l5.TabIndex = 8;
            this.l5.Text = "Project";
            // 
            // cmbProject
            // 
            this.cmbProject.Location = new System.Drawing.Point(75, 70);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(250, 21);
            this.cmbProject.TabIndex = 9;
            // 
            // l6
            // 
            this.l6.Location = new System.Drawing.Point(345, 70);
            this.l6.Name = "l6";
            this.l6.Size = new System.Drawing.Size(75, 25);
            this.l6.TabIndex = 10;
            this.l6.Text = "Warehouse";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.Location = new System.Drawing.Point(425, 70);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(220, 21);
            this.cmbWarehouse.TabIndex = 11;
            // 
            // l7
            // 
            this.l7.Location = new System.Drawing.Point(665, 70);
            this.l7.Name = "l7";
            this.l7.Size = new System.Drawing.Size(50, 25);
            this.l7.TabIndex = 12;
            this.l7.Text = "Invoice";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(720, 70);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(130, 20);
            this.txtInvoiceNo.TabIndex = 13;
            // 
            // l8
            // 
            this.l8.Location = new System.Drawing.Point(870, 70);
            this.l8.Name = "l8";
            this.l8.Size = new System.Drawing.Size(55, 25);
            this.l8.TabIndex = 14;
            this.l8.Text = "Inv Date";
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInvoiceDate.Location = new System.Drawing.Point(930, 70);
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.Size = new System.Drawing.Size(150, 20);
            this.dtInvoiceDate.TabIndex = 15;
            // 
            // l9
            // 
            this.l9.Location = new System.Drawing.Point(15, 110);
            this.l9.Name = "l9";
            this.l9.Size = new System.Drawing.Size(60, 25);
            this.l9.TabIndex = 16;
            this.l9.Text = "Received";
            // 
            // cmbReceivedBy
            // 
            this.cmbReceivedBy.Location = new System.Drawing.Point(80, 110);
            this.cmbReceivedBy.Name = "cmbReceivedBy";
            this.cmbReceivedBy.Size = new System.Drawing.Size(220, 21);
            this.cmbReceivedBy.TabIndex = 17;
            // 
            // l10
            // 
            this.l10.Location = new System.Drawing.Point(320, 110);
            this.l10.Name = "l10";
            this.l10.Size = new System.Drawing.Size(60, 25);
            this.l10.TabIndex = 18;
            this.l10.Text = "Checked";
            // 
            // cmbCheckedBy
            // 
            this.cmbCheckedBy.Location = new System.Drawing.Point(385, 110);
            this.cmbCheckedBy.Name = "cmbCheckedBy";
            this.cmbCheckedBy.Size = new System.Drawing.Size(220, 21);
            this.cmbCheckedBy.TabIndex = 19;
            // 
            // l11
            // 
            this.l11.Location = new System.Drawing.Point(625, 110);
            this.l11.Name = "l11";
            this.l11.Size = new System.Drawing.Size(50, 25);
            this.l11.TabIndex = 20;
            this.l11.Text = "Vehicle";
            // 
            // txtVehicle
            // 
            this.txtVehicle.Location = new System.Drawing.Point(680, 110);
            this.txtVehicle.Name = "txtVehicle";
            this.txtVehicle.Size = new System.Drawing.Size(130, 20);
            this.txtVehicle.TabIndex = 21;
            // 
            // l12
            // 
            this.l12.Location = new System.Drawing.Point(830, 110);
            this.l12.Name = "l12";
            this.l12.Size = new System.Drawing.Size(45, 25);
            this.l12.TabIndex = 22;
            this.l12.Text = "Driver";
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(880, 110);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(200, 20);
            this.txtDriver.TabIndex = 23;
            // 
            // l13
            // 
            this.l13.Location = new System.Drawing.Point(15, 150);
            this.l13.Name = "l13";
            this.l13.Size = new System.Drawing.Size(45, 25);
            this.l13.TabIndex = 24;
            this.l13.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(65, 150);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 21);
            this.cmbStatus.TabIndex = 25;
            // 
            // l14
            // 
            this.l14.Location = new System.Drawing.Point(235, 150);
            this.l14.Name = "l14";
            this.l14.Size = new System.Drawing.Size(60, 25);
            this.l14.TabIndex = 26;
            this.l14.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(300, 150);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(780, 20);
            this.txtRemarks.TabIndex = 27;
            // 
            // grpItems
            // 
            this.grpItems.Controls.Add(this.i1);
            this.grpItems.Controls.Add(this.cmbItem);
            this.grpItems.Controls.Add(this.i2);
            this.grpItems.Controls.Add(this.txtOrderQty);
            this.grpItems.Controls.Add(this.i3);
            this.grpItems.Controls.Add(this.txtReceiveQty);
            this.grpItems.Controls.Add(this.i4);
            this.grpItems.Controls.Add(this.txtAcceptedQty);
            this.grpItems.Controls.Add(this.i5);
            this.grpItems.Controls.Add(this.txtRejectedQty);
            this.grpItems.Controls.Add(this.i6);
            this.grpItems.Controls.Add(this.txtUom);
            this.grpItems.Controls.Add(this.i7);
            this.grpItems.Controls.Add(this.txtCost);
            this.grpItems.Controls.Add(this.i8);
            this.grpItems.Controls.Add(this.txtLineTotal);
            this.grpItems.Controls.Add(this.btnAddItem);
            this.grpItems.Controls.Add(this.dgvItems);
            this.grpItems.Location = new System.Drawing.Point(10, 280);
            this.grpItems.Name = "grpItems";
            this.grpItems.Size = new System.Drawing.Size(1160, 260);
            this.grpItems.TabIndex = 2;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "Receipt Items";
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
            this.cmbItem.Size = new System.Drawing.Size(240, 21);
            this.cmbItem.TabIndex = 1;
            // 
            // i2
            // 
            this.i2.Location = new System.Drawing.Point(315, 30);
            this.i2.Name = "i2";
            this.i2.Size = new System.Drawing.Size(30, 25);
            this.i2.TabIndex = 2;
            this.i2.Text = "Ord";
            // 
            // txtOrderQty
            // 
            this.txtOrderQty.Location = new System.Drawing.Point(350, 25);
            this.txtOrderQty.Name = "txtOrderQty";
            this.txtOrderQty.Size = new System.Drawing.Size(60, 20);
            this.txtOrderQty.TabIndex = 3;
            // 
            // i3
            // 
            this.i3.Location = new System.Drawing.Point(425, 30);
            this.i3.Name = "i3";
            this.i3.Size = new System.Drawing.Size(35, 25);
            this.i3.TabIndex = 4;
            this.i3.Text = "Recv";
            // 
            // txtReceiveQty
            // 
            this.txtReceiveQty.Location = new System.Drawing.Point(465, 25);
            this.txtReceiveQty.Name = "txtReceiveQty";
            this.txtReceiveQty.Size = new System.Drawing.Size(60, 20);
            this.txtReceiveQty.TabIndex = 5;
            // 
            // i4
            // 
            this.i4.Location = new System.Drawing.Point(540, 30);
            this.i4.Name = "i4";
            this.i4.Size = new System.Drawing.Size(30, 25);
            this.i4.TabIndex = 6;
            this.i4.Text = "Acc";
            // 
            // txtAcceptedQty
            // 
            this.txtAcceptedQty.Location = new System.Drawing.Point(575, 25);
            this.txtAcceptedQty.Name = "txtAcceptedQty";
            this.txtAcceptedQty.Size = new System.Drawing.Size(60, 20);
            this.txtAcceptedQty.TabIndex = 7;
            // 
            // i5
            // 
            this.i5.Location = new System.Drawing.Point(650, 30);
            this.i5.Name = "i5";
            this.i5.Size = new System.Drawing.Size(30, 25);
            this.i5.TabIndex = 8;
            this.i5.Text = "Rej";
            // 
            // txtRejectedQty
            // 
            this.txtRejectedQty.Location = new System.Drawing.Point(685, 25);
            this.txtRejectedQty.Name = "txtRejectedQty";
            this.txtRejectedQty.Size = new System.Drawing.Size(60, 20);
            this.txtRejectedQty.TabIndex = 9;
            // 
            // i6
            // 
            this.i6.Location = new System.Drawing.Point(760, 30);
            this.i6.Name = "i6";
            this.i6.Size = new System.Drawing.Size(35, 25);
            this.i6.TabIndex = 10;
            this.i6.Text = "UOM";
            // 
            // txtUom
            // 
            this.txtUom.Location = new System.Drawing.Point(800, 25);
            this.txtUom.Name = "txtUom";
            this.txtUom.Size = new System.Drawing.Size(60, 20);
            this.txtUom.TabIndex = 11;
            // 
            // i7
            // 
            this.i7.Location = new System.Drawing.Point(875, 30);
            this.i7.Name = "i7";
            this.i7.Size = new System.Drawing.Size(35, 25);
            this.i7.TabIndex = 12;
            this.i7.Text = "Cost";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(915, 25);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(70, 20);
            this.txtCost.TabIndex = 13;
            // 
            // i8
            // 
            this.i8.Location = new System.Drawing.Point(1000, 30);
            this.i8.Name = "i8";
            this.i8.Size = new System.Drawing.Size(35, 25);
            this.i8.TabIndex = 14;
            this.i8.Text = "Total";
            // 
            // txtLineTotal
            // 
            this.txtLineTotal.Location = new System.Drawing.Point(1040, 25);
            this.txtLineTotal.Name = "txtLineTotal";
            this.txtLineTotal.Size = new System.Drawing.Size(80, 20);
            this.txtLineTotal.TabIndex = 15;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(1040, 55);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(80, 28);
            this.btnAddItem.TabIndex = 16;
            this.btnAddItem.Text = "Add";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.Location = new System.Drawing.Point(15, 90);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.Size = new System.Drawing.Size(1125, 155);
            this.dgvItems.TabIndex = 17;
            // 
            // grpSummary
            // 
            this.grpSummary.Controls.Add(this.s1);
            this.grpSummary.Controls.Add(this.txtSubtotal);
            this.grpSummary.Controls.Add(this.s2);
            this.grpSummary.Controls.Add(this.txtVAT);
            this.grpSummary.Controls.Add(this.s3);
            this.grpSummary.Controls.Add(this.txtNet);
            this.grpSummary.Location = new System.Drawing.Point(820, 545);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(350, 80);
            this.grpSummary.TabIndex = 3;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "Summary";
            // 
            // s1
            // 
            this.s1.Location = new System.Drawing.Point(15, 25);
            this.s1.Name = "s1";
            this.s1.Size = new System.Drawing.Size(60, 25);
            this.s1.TabIndex = 0;
            this.s1.Text = "Subtotal";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(85, 20);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(100, 20);
            this.txtSubtotal.TabIndex = 1;
            // 
            // s2
            // 
            this.s2.Location = new System.Drawing.Point(15, 50);
            this.s2.Name = "s2";
            this.s2.Size = new System.Drawing.Size(60, 25);
            this.s2.TabIndex = 2;
            this.s2.Text = "VAT";
            // 
            // txtVAT
            // 
            this.txtVAT.Location = new System.Drawing.Point(85, 45);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(100, 20);
            this.txtVAT.TabIndex = 3;
            // 
            // s3
            // 
            this.s3.Location = new System.Drawing.Point(195, 25);
            this.s3.Name = "s3";
            this.s3.Size = new System.Drawing.Size(40, 25);
            this.s3.TabIndex = 4;
            this.s3.Text = "Net";
            // 
            // txtNet
            // 
            this.txtNet.Location = new System.Drawing.Point(240, 20);
            this.txtNet.Name = "txtNet";
            this.txtNet.Size = new System.Drawing.Size(100, 20);
            this.txtNet.TabIndex = 5;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNew.Location = new System.Drawing.Point(95, 575);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(110, 35);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.Location = new System.Drawing.Point(215, 575);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnUpdate.Location = new System.Drawing.Point(335, 575);
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
            this.btnDelete.Location = new System.Drawing.Point(455, 575);
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
            this.btnApprove.Location = new System.Drawing.Point(575, 575);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(110, 35);
            this.btnApprove.TabIndex = 8;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClear.Location = new System.Drawing.Point(695, 575);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 35);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // frmMaterialReceipt
            // 
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.grpItems);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnClear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMaterialReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Material Receipt";
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
        private Label l13;
        private Label l14;
        private Label i1;
        private Label i2;
        private Label i3;
        private Label i4;
        private Label i5;
        private Label i6;
        private Label i7;
        private Label i8;
        private Label s1;
        private Label s2;
        private Label s3;
    }
}