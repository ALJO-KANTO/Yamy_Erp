using System.Windows.Forms;

namespace YamyProject.UI.Purchases.MaterialReturn
{
    partial class frmMaterialReturn
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

        private ComboBox cmbIssue;
        private ComboBox cmbProject;

        private ComboBox cmbFromWarehouse;
        private ComboBox cmbToWarehouse;

        private ComboBox cmbReturnedBy;
        private ComboBox cmbReceivedBy;

        private ComboBox cmbReturnType;
        private ComboBox cmbStatus;

        private TextBox txtRemarks;

        private ComboBox cmbItem;

        private TextBox txtIssuedQty;
        private TextBox txtReturnQty;
        private TextBox txtDamagedQty;
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
            this.cmbIssue = new System.Windows.Forms.ComboBox();
            this.h4 = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.h5 = new System.Windows.Forms.Label();
            this.cmbFromWarehouse = new System.Windows.Forms.ComboBox();
            this.h6 = new System.Windows.Forms.Label();
            this.cmbToWarehouse = new System.Windows.Forms.ComboBox();
            this.h7 = new System.Windows.Forms.Label();
            this.cmbReturnedBy = new System.Windows.Forms.ComboBox();
            this.h8 = new System.Windows.Forms.Label();
            this.cmbReceivedBy = new System.Windows.Forms.ComboBox();
            this.h9 = new System.Windows.Forms.Label();
            this.cmbReturnType = new System.Windows.Forms.ComboBox();
            this.h10 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.h11 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.i1 = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.i2 = new System.Windows.Forms.Label();
            this.txtIssuedQty = new System.Windows.Forms.TextBox();
            this.i3 = new System.Windows.Forms.Label();
            this.txtReturnQty = new System.Windows.Forms.TextBox();
            this.i4 = new System.Windows.Forms.Label();
            this.txtDamagedQty = new System.Windows.Forms.TextBox();
            this.i5 = new System.Windows.Forms.Label();
            this.txtUom = new System.Windows.Forms.TextBox();
            this.i6 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.i7 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
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
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(9)))));
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
            this.lblTitle.Size = new System.Drawing.Size(183, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "MATERIAL RETURN";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.h1);
            this.grpHeader.Controls.Add(this.txtNo);
            this.grpHeader.Controls.Add(this.h2);
            this.grpHeader.Controls.Add(this.dtDate);
            this.grpHeader.Controls.Add(this.h3);
            this.grpHeader.Controls.Add(this.cmbIssue);
            this.grpHeader.Controls.Add(this.h4);
            this.grpHeader.Controls.Add(this.cmbProject);
            this.grpHeader.Controls.Add(this.h5);
            this.grpHeader.Controls.Add(this.cmbFromWarehouse);
            this.grpHeader.Controls.Add(this.h6);
            this.grpHeader.Controls.Add(this.cmbToWarehouse);
            this.grpHeader.Controls.Add(this.h7);
            this.grpHeader.Controls.Add(this.cmbReturnedBy);
            this.grpHeader.Controls.Add(this.h8);
            this.grpHeader.Controls.Add(this.cmbReceivedBy);
            this.grpHeader.Controls.Add(this.h9);
            this.grpHeader.Controls.Add(this.cmbReturnType);
            this.grpHeader.Controls.Add(this.h10);
            this.grpHeader.Controls.Add(this.cmbStatus);
            this.grpHeader.Controls.Add(this.h11);
            this.grpHeader.Controls.Add(this.txtRemarks);
            this.grpHeader.Location = new System.Drawing.Point(10, 65);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1160, 190);
            this.grpHeader.TabIndex = 1;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Return Header";
            // 
            // h1
            // 
            this.h1.Location = new System.Drawing.Point(15, 30);
            this.h1.Name = "h1";
            this.h1.Size = new System.Drawing.Size(65, 25);
            this.h1.TabIndex = 0;
            this.h1.Text = "Return No";
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(85, 30);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(150, 20);
            this.txtNo.TabIndex = 1;
            // 
            // h2
            // 
            this.h2.Location = new System.Drawing.Point(255, 30);
            this.h2.Name = "h2";
            this.h2.Size = new System.Drawing.Size(40, 25);
            this.h2.TabIndex = 2;
            this.h2.Text = "Date";
            // 
            // dtDate
            // 
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(300, 30);
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
            this.h3.Text = "Issue";
            // 
            // cmbIssue
            // 
            this.cmbIssue.Location = new System.Drawing.Point(515, 30);
            this.cmbIssue.Name = "cmbIssue";
            this.cmbIssue.Size = new System.Drawing.Size(180, 21);
            this.cmbIssue.TabIndex = 5;
            // 
            // h4
            // 
            this.h4.Location = new System.Drawing.Point(715, 30);
            this.h4.Name = "h4";
            this.h4.Size = new System.Drawing.Size(50, 25);
            this.h4.TabIndex = 6;
            this.h4.Text = "Project";
            // 
            // cmbProject
            // 
            this.cmbProject.Location = new System.Drawing.Point(770, 30);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(250, 21);
            this.cmbProject.TabIndex = 7;
            // 
            // h5
            // 
            this.h5.Location = new System.Drawing.Point(15, 70);
            this.h5.Name = "h5";
            this.h5.Size = new System.Drawing.Size(60, 25);
            this.h5.TabIndex = 8;
            this.h5.Text = "From WH";
            // 
            // cmbFromWarehouse
            // 
            this.cmbFromWarehouse.Location = new System.Drawing.Point(80, 70);
            this.cmbFromWarehouse.Name = "cmbFromWarehouse";
            this.cmbFromWarehouse.Size = new System.Drawing.Size(220, 21);
            this.cmbFromWarehouse.TabIndex = 9;
            // 
            // h6
            // 
            this.h6.Location = new System.Drawing.Point(320, 70);
            this.h6.Name = "h6";
            this.h6.Size = new System.Drawing.Size(45, 25);
            this.h6.TabIndex = 10;
            this.h6.Text = "To WH";
            // 
            // cmbToWarehouse
            // 
            this.cmbToWarehouse.Location = new System.Drawing.Point(370, 70);
            this.cmbToWarehouse.Name = "cmbToWarehouse";
            this.cmbToWarehouse.Size = new System.Drawing.Size(220, 21);
            this.cmbToWarehouse.TabIndex = 11;
            // 
            // h7
            // 
            this.h7.Location = new System.Drawing.Point(610, 70);
            this.h7.Name = "h7";
            this.h7.Size = new System.Drawing.Size(60, 25);
            this.h7.TabIndex = 12;
            this.h7.Text = "Returned";
            // 
            // cmbReturnedBy
            // 
            this.cmbReturnedBy.Location = new System.Drawing.Point(675, 70);
            this.cmbReturnedBy.Name = "cmbReturnedBy";
            this.cmbReturnedBy.Size = new System.Drawing.Size(180, 21);
            this.cmbReturnedBy.TabIndex = 13;
            // 
            // h8
            // 
            this.h8.Location = new System.Drawing.Point(870, 70);
            this.h8.Name = "h8";
            this.h8.Size = new System.Drawing.Size(60, 25);
            this.h8.TabIndex = 14;
            this.h8.Text = "Received";
            // 
            // cmbReceivedBy
            // 
            this.cmbReceivedBy.Location = new System.Drawing.Point(935, 70);
            this.cmbReceivedBy.Name = "cmbReceivedBy";
            this.cmbReceivedBy.Size = new System.Drawing.Size(180, 21);
            this.cmbReceivedBy.TabIndex = 15;
            // 
            // h9
            // 
            this.h9.Location = new System.Drawing.Point(15, 110);
            this.h9.Name = "h9";
            this.h9.Size = new System.Drawing.Size(40, 25);
            this.h9.TabIndex = 16;
            this.h9.Text = "Type";
            // 
            // cmbReturnType
            // 
            this.cmbReturnType.Location = new System.Drawing.Point(60, 110);
            this.cmbReturnType.Name = "cmbReturnType";
            this.cmbReturnType.Size = new System.Drawing.Size(180, 21);
            this.cmbReturnType.TabIndex = 17;
            // 
            // h10
            // 
            this.h10.Location = new System.Drawing.Point(260, 110);
            this.h10.Name = "h10";
            this.h10.Size = new System.Drawing.Size(45, 25);
            this.h10.TabIndex = 18;
            this.h10.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(310, 110);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 21);
            this.cmbStatus.TabIndex = 19;
            // 
            // h11
            // 
            this.h11.Location = new System.Drawing.Point(480, 110);
            this.h11.Name = "h11";
            this.h11.Size = new System.Drawing.Size(60, 25);
            this.h11.TabIndex = 20;
            this.h11.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(545, 110);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(510, 20);
            this.txtRemarks.TabIndex = 21;
            // 
            // grpItems
            // 
            this.grpItems.Controls.Add(this.i1);
            this.grpItems.Controls.Add(this.cmbItem);
            this.grpItems.Controls.Add(this.i2);
            this.grpItems.Controls.Add(this.txtIssuedQty);
            this.grpItems.Controls.Add(this.i3);
            this.grpItems.Controls.Add(this.txtReturnQty);
            this.grpItems.Controls.Add(this.i4);
            this.grpItems.Controls.Add(this.txtDamagedQty);
            this.grpItems.Controls.Add(this.i5);
            this.grpItems.Controls.Add(this.txtUom);
            this.grpItems.Controls.Add(this.i6);
            this.grpItems.Controls.Add(this.txtCost);
            this.grpItems.Controls.Add(this.i7);
            this.grpItems.Controls.Add(this.txtTotal);
            this.grpItems.Controls.Add(this.btnAddItem);
            this.grpItems.Controls.Add(this.dgvItems);
            this.grpItems.Location = new System.Drawing.Point(10, 260);
            this.grpItems.Name = "grpItems";
            this.grpItems.Size = new System.Drawing.Size(1160, 280);
            this.grpItems.TabIndex = 2;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "Return Items";
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
            this.i2.Size = new System.Drawing.Size(45, 25);
            this.i2.TabIndex = 2;
            this.i2.Text = "Issued";
            // 
            // txtIssuedQty
            // 
            this.txtIssuedQty.Location = new System.Drawing.Point(375, 25);
            this.txtIssuedQty.Name = "txtIssuedQty";
            this.txtIssuedQty.Size = new System.Drawing.Size(70, 20);
            this.txtIssuedQty.TabIndex = 3;
            // 
            // i3
            // 
            this.i3.Location = new System.Drawing.Point(460, 30);
            this.i3.Name = "i3";
            this.i3.Size = new System.Drawing.Size(45, 25);
            this.i3.TabIndex = 4;
            this.i3.Text = "Return";
            // 
            // txtReturnQty
            // 
            this.txtReturnQty.Location = new System.Drawing.Point(510, 25);
            this.txtReturnQty.Name = "txtReturnQty";
            this.txtReturnQty.Size = new System.Drawing.Size(70, 20);
            this.txtReturnQty.TabIndex = 5;
            // 
            // i4
            // 
            this.i4.Location = new System.Drawing.Point(595, 30);
            this.i4.Name = "i4";
            this.i4.Size = new System.Drawing.Size(55, 25);
            this.i4.TabIndex = 6;
            this.i4.Text = "Damage";
            // 
            // txtDamagedQty
            // 
            this.txtDamagedQty.Location = new System.Drawing.Point(655, 25);
            this.txtDamagedQty.Name = "txtDamagedQty";
            this.txtDamagedQty.Size = new System.Drawing.Size(70, 20);
            this.txtDamagedQty.TabIndex = 7;
            // 
            // i5
            // 
            this.i5.Location = new System.Drawing.Point(740, 30);
            this.i5.Name = "i5";
            this.i5.Size = new System.Drawing.Size(40, 25);
            this.i5.TabIndex = 8;
            this.i5.Text = "UOM";
            // 
            // txtUom
            // 
            this.txtUom.Location = new System.Drawing.Point(785, 25);
            this.txtUom.Name = "txtUom";
            this.txtUom.Size = new System.Drawing.Size(60, 20);
            this.txtUom.TabIndex = 9;
            // 
            // i6
            // 
            this.i6.Location = new System.Drawing.Point(860, 30);
            this.i6.Name = "i6";
            this.i6.Size = new System.Drawing.Size(35, 25);
            this.i6.TabIndex = 10;
            this.i6.Text = "Cost";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(900, 25);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(70, 20);
            this.txtCost.TabIndex = 11;
            // 
            // i7
            // 
            this.i7.Location = new System.Drawing.Point(985, 30);
            this.i7.Name = "i7";
            this.i7.Size = new System.Drawing.Size(35, 25);
            this.i7.TabIndex = 12;
            this.i7.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(1025, 25);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(80, 20);
            this.txtTotal.TabIndex = 13;
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddItem.Location = new System.Drawing.Point(1025, 55);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(80, 28);
            this.btnAddItem.TabIndex = 14;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.UseVisualStyleBackColor = false;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.Location = new System.Drawing.Point(15, 90);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(1125, 170);
            this.dgvItems.TabIndex = 15;
            // 
            // grpSummary
            // 
            this.grpSummary.Controls.Add(this.s1);
            this.grpSummary.Controls.Add(this.txtGrandTotal);
            this.grpSummary.Location = new System.Drawing.Point(920, 545);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(250, 70);
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
            // frmMaterialReturn
            // 
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grpHeader);
            this.Controls.Add(this.grpItems);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnClear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMaterialReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Material Return";
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
        private Label i1;
        private Label i2;
        private Label i3;
        private Label i4;
        private Label i5;
        private Label i6;
        private Label i7;
        private Label s1;
    }
}