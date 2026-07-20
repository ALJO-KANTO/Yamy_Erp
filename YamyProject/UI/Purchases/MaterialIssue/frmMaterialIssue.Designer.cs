using System.Windows.Forms;

namespace YamyProject.UI.Purchases.MaterialIssue
{
    partial class frmMaterialIssue
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

        private TextBox txtNo, txtPurpose, txtRemarks;
        private DateTimePicker dtDate;

        private ComboBox cmbProject, cmbWarehouse, cmbReservation,
                         cmbRequestedBy, cmbIssuedTo, cmbZone, cmbStatus;

        private ComboBox cmbItem;
        private TextBox txtReservedQty, txtAvailableQty, txtIssueQty,
                        txtUom, txtCost, txtTotal, txtItemRemarks;

        private DataGridView dgvItems;

        private Button btnAddItem, btnNew, btnSave, btnUpdate,
                       btnDelete, btnApprove, btnClear;

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpHeader = new System.Windows.Forms.GroupBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.lbl3 = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.lbl4 = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.lbl5 = new System.Windows.Forms.Label();
            this.cmbReservation = new System.Windows.Forms.ComboBox();
            this.lbl6 = new System.Windows.Forms.Label();
            this.cmbRequestedBy = new System.Windows.Forms.ComboBox();
            this.lbl7 = new System.Windows.Forms.Label();
            this.cmbIssuedTo = new System.Windows.Forms.ComboBox();
            this.lbl8 = new System.Windows.Forms.Label();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.lbl9 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lbl10 = new System.Windows.Forms.Label();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.lbl11 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.a1 = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.a2 = new System.Windows.Forms.Label();
            this.txtReservedQty = new System.Windows.Forms.TextBox();
            this.a3 = new System.Windows.Forms.Label();
            this.txtAvailableQty = new System.Windows.Forms.TextBox();
            this.a4 = new System.Windows.Forms.Label();
            this.txtIssueQty = new System.Windows.Forms.TextBox();
            this.a5 = new System.Windows.Forms.Label();
            this.txtUom = new System.Windows.Forms.TextBox();
            this.a6 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.a7 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
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
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
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
            this.lblTitle.Size = new System.Drawing.Size(233, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "MATERIAL ISSUE TO SITE";
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.lbl1);
            this.grpHeader.Controls.Add(this.txtNo);
            this.grpHeader.Controls.Add(this.lbl2);
            this.grpHeader.Controls.Add(this.dtDate);
            this.grpHeader.Controls.Add(this.lbl3);
            this.grpHeader.Controls.Add(this.cmbProject);
            this.grpHeader.Controls.Add(this.lbl4);
            this.grpHeader.Controls.Add(this.cmbWarehouse);
            this.grpHeader.Controls.Add(this.lbl5);
            this.grpHeader.Controls.Add(this.cmbReservation);
            this.grpHeader.Controls.Add(this.lbl6);
            this.grpHeader.Controls.Add(this.cmbRequestedBy);
            this.grpHeader.Controls.Add(this.lbl7);
            this.grpHeader.Controls.Add(this.cmbIssuedTo);
            this.grpHeader.Controls.Add(this.lbl8);
            this.grpHeader.Controls.Add(this.cmbZone);
            this.grpHeader.Controls.Add(this.lbl9);
            this.grpHeader.Controls.Add(this.cmbStatus);
            this.grpHeader.Controls.Add(this.lbl10);
            this.grpHeader.Controls.Add(this.txtPurpose);
            this.grpHeader.Controls.Add(this.lbl11);
            this.grpHeader.Controls.Add(this.txtRemarks);
            this.grpHeader.Location = new System.Drawing.Point(10, 65);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(1160, 190);
            this.grpHeader.TabIndex = 1;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Issue Header";
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(15, 30);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(60, 25);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Issue No";
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(80, 25);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(150, 20);
            this.txtNo.TabIndex = 1;
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(250, 30);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(40, 25);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "Date";
            // 
            // dtDate
            // 
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(295, 25);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(150, 20);
            this.dtDate.TabIndex = 3;
            // 
            // lbl3
            // 
            this.lbl3.Location = new System.Drawing.Point(470, 30);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(50, 25);
            this.lbl3.TabIndex = 4;
            this.lbl3.Text = "Project";
            // 
            // cmbProject
            // 
            this.cmbProject.Location = new System.Drawing.Point(525, 25);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(250, 21);
            this.cmbProject.TabIndex = 5;
            // 
            // lbl4
            // 
            this.lbl4.Location = new System.Drawing.Point(15, 70);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(75, 25);
            this.lbl4.TabIndex = 6;
            this.lbl4.Text = "Warehouse";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.Location = new System.Drawing.Point(95, 65);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(220, 21);
            this.cmbWarehouse.TabIndex = 7;
            // 
            // lbl5
            // 
            this.lbl5.Location = new System.Drawing.Point(340, 70);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(75, 25);
            this.lbl5.TabIndex = 8;
            this.lbl5.Text = "Reservation";
            // 
            // cmbReservation
            // 
            this.cmbReservation.Location = new System.Drawing.Point(420, 65);
            this.cmbReservation.Name = "cmbReservation";
            this.cmbReservation.Size = new System.Drawing.Size(180, 21);
            this.cmbReservation.TabIndex = 9;
            // 
            // lbl6
            // 
            this.lbl6.Location = new System.Drawing.Point(625, 70);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(65, 25);
            this.lbl6.TabIndex = 10;
            this.lbl6.Text = "Requested";
            // 
            // cmbRequestedBy
            // 
            this.cmbRequestedBy.Location = new System.Drawing.Point(695, 65);
            this.cmbRequestedBy.Name = "cmbRequestedBy";
            this.cmbRequestedBy.Size = new System.Drawing.Size(180, 21);
            this.cmbRequestedBy.TabIndex = 11;
            // 
            // lbl7
            // 
            this.lbl7.Location = new System.Drawing.Point(15, 110);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(60, 25);
            this.lbl7.TabIndex = 12;
            this.lbl7.Text = "Issued To";
            // 
            // cmbIssuedTo
            // 
            this.cmbIssuedTo.Location = new System.Drawing.Point(80, 105);
            this.cmbIssuedTo.Name = "cmbIssuedTo";
            this.cmbIssuedTo.Size = new System.Drawing.Size(220, 21);
            this.cmbIssuedTo.TabIndex = 13;
            // 
            // lbl8
            // 
            this.lbl8.Location = new System.Drawing.Point(320, 110);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(40, 25);
            this.lbl8.TabIndex = 14;
            this.lbl8.Text = "Zone";
            // 
            // cmbZone
            // 
            this.cmbZone.Location = new System.Drawing.Point(365, 105);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(180, 21);
            this.cmbZone.TabIndex = 15;
            // 
            // lbl9
            // 
            this.lbl9.Location = new System.Drawing.Point(565, 110);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(45, 25);
            this.lbl9.TabIndex = 16;
            this.lbl9.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(615, 105);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(140, 21);
            this.cmbStatus.TabIndex = 17;
            // 
            // lbl10
            // 
            this.lbl10.Location = new System.Drawing.Point(15, 150);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(55, 25);
            this.lbl10.TabIndex = 18;
            this.lbl10.Text = "Purpose";
            // 
            // txtPurpose
            // 
            this.txtPurpose.Location = new System.Drawing.Point(75, 145);
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(300, 20);
            this.txtPurpose.TabIndex = 19;
            // 
            // lbl11
            // 
            this.lbl11.Location = new System.Drawing.Point(395, 150);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(60, 25);
            this.lbl11.TabIndex = 20;
            this.lbl11.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(460, 145);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(420, 20);
            this.txtRemarks.TabIndex = 21;
            // 
            // grpItems
            // 
            this.grpItems.Controls.Add(this.a1);
            this.grpItems.Controls.Add(this.cmbItem);
            this.grpItems.Controls.Add(this.a2);
            this.grpItems.Controls.Add(this.txtReservedQty);
            this.grpItems.Controls.Add(this.a3);
            this.grpItems.Controls.Add(this.txtAvailableQty);
            this.grpItems.Controls.Add(this.a4);
            this.grpItems.Controls.Add(this.txtIssueQty);
            this.grpItems.Controls.Add(this.a5);
            this.grpItems.Controls.Add(this.txtUom);
            this.grpItems.Controls.Add(this.a6);
            this.grpItems.Controls.Add(this.txtCost);
            this.grpItems.Controls.Add(this.a7);
            this.grpItems.Controls.Add(this.txtTotal);
            this.grpItems.Controls.Add(this.btnAddItem);
            this.grpItems.Controls.Add(this.dgvItems);
            this.grpItems.Location = new System.Drawing.Point(10, 260);
            this.grpItems.Name = "grpItems";
            this.grpItems.Size = new System.Drawing.Size(1160, 290);
            this.grpItems.TabIndex = 2;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "Issue Items";
            // 
            // a1
            // 
            this.a1.Location = new System.Drawing.Point(15, 30);
            this.a1.Name = "a1";
            this.a1.Size = new System.Drawing.Size(40, 25);
            this.a1.TabIndex = 0;
            this.a1.Text = "Item";
            // 
            // cmbItem
            // 
            this.cmbItem.Location = new System.Drawing.Point(60, 25);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(260, 21);
            this.cmbItem.TabIndex = 1;
            // 
            // a2
            // 
            this.a2.Location = new System.Drawing.Point(335, 30);
            this.a2.Name = "a2";
            this.a2.Size = new System.Drawing.Size(30, 25);
            this.a2.TabIndex = 2;
            this.a2.Text = "Res";
            // 
            // txtReservedQty
            // 
            this.txtReservedQty.Location = new System.Drawing.Point(370, 25);
            this.txtReservedQty.Name = "txtReservedQty";
            this.txtReservedQty.Size = new System.Drawing.Size(70, 20);
            this.txtReservedQty.TabIndex = 3;
            // 
            // a3
            // 
            this.a3.Location = new System.Drawing.Point(455, 30);
            this.a3.Name = "a3";
            this.a3.Size = new System.Drawing.Size(35, 25);
            this.a3.TabIndex = 4;
            this.a3.Text = "Avail";
            // 
            // txtAvailableQty
            // 
            this.txtAvailableQty.Location = new System.Drawing.Point(495, 25);
            this.txtAvailableQty.Name = "txtAvailableQty";
            this.txtAvailableQty.Size = new System.Drawing.Size(70, 20);
            this.txtAvailableQty.TabIndex = 5;
            // 
            // a4
            // 
            this.a4.Location = new System.Drawing.Point(580, 30);
            this.a4.Name = "a4";
            this.a4.Size = new System.Drawing.Size(35, 25);
            this.a4.TabIndex = 6;
            this.a4.Text = "Issue";
            // 
            // txtIssueQty
            // 
            this.txtIssueQty.Location = new System.Drawing.Point(620, 25);
            this.txtIssueQty.Name = "txtIssueQty";
            this.txtIssueQty.Size = new System.Drawing.Size(70, 20);
            this.txtIssueQty.TabIndex = 7;
            // 
            // a5
            // 
            this.a5.Location = new System.Drawing.Point(705, 30);
            this.a5.Name = "a5";
            this.a5.Size = new System.Drawing.Size(35, 25);
            this.a5.TabIndex = 8;
            this.a5.Text = "UOM";
            // 
            // txtUom
            // 
            this.txtUom.Location = new System.Drawing.Point(745, 25);
            this.txtUom.Name = "txtUom";
            this.txtUom.Size = new System.Drawing.Size(60, 20);
            this.txtUom.TabIndex = 9;
            // 
            // a6
            // 
            this.a6.Location = new System.Drawing.Point(820, 30);
            this.a6.Name = "a6";
            this.a6.Size = new System.Drawing.Size(35, 25);
            this.a6.TabIndex = 10;
            this.a6.Text = "Cost";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(860, 25);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(70, 20);
            this.txtCost.TabIndex = 11;
            // 
            // a7
            // 
            this.a7.Location = new System.Drawing.Point(945, 30);
            this.a7.Name = "a7";
            this.a7.Size = new System.Drawing.Size(35, 25);
            this.a7.TabIndex = 12;
            this.a7.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(985, 25);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(80, 20);
            this.txtTotal.TabIndex = 13;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(1075, 25);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(65, 28);
            this.btnAddItem.TabIndex = 14;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.Location = new System.Drawing.Point(15, 65);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(1125, 210);
            this.dgvItems.TabIndex = 15;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(140, 570);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(110, 35);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(260, 570);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(380, 570);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 35);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(500, 570);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 35);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(620, 570);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(140, 35);
            this.btnApprove.TabIndex = 7;
            this.btnApprove.Text = "Approve & Issue";
            this.btnApprove.Click += new System.EventHandler(this.BtnApprove_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(775, 570);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 35);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // frmMaterialIssue
            // 
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
            this.Name = "frmMaterialIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Material Issue";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.grpItems.ResumeLayout(false);
            this.grpItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        private Label lbl1;
        private Label lbl2;
        private Label lbl3;
        private Label lbl4;
        private Label lbl5;
        private Label lbl6;
        private Label lbl7;
        private Label lbl8;
        private Label lbl9;
        private Label lbl10;
        private Label lbl11;
        private Label a1;
        private Label a2;
        private Label a3;
        private Label a4;
        private Label a5;
        private Label a6;
        private Label a7;
    }
}