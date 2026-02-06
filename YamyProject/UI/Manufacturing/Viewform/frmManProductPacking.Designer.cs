using System;

namespace YamyProject.UI.Manufacturing.Viewform
{
    partial class frmManProductPacking
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support — do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelProductionDate = new System.Windows.Forms.Label();
            this.labelBatchNo = new System.Windows.Forms.Label();
            this.textBoxBatchNo = new System.Windows.Forms.TextBox();
            this.labelTotalQty = new System.Windows.Forms.Label();
            this.textBoxTotalQty = new System.Windows.Forms.TextBox();
            this.dataGridViewPacking = new System.Windows.Forms.DataGridView();
            this.Sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Variant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackingDate = new YamyProject.frmViewPettyCashVoucher.DataGridViewCalendarColumn();
            this.RackNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlheader = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.CRM = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtInv = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbWarehouseTo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvitem2 = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacking)).BeginInit();
            this.pnlheader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitem2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelProductionDate
            // 
            this.labelProductionDate.AutoSize = true;
            this.labelProductionDate.Location = new System.Drawing.Point(22, 64);
            this.labelProductionDate.Name = "labelProductionDate";
            this.labelProductionDate.Size = new System.Drawing.Size(87, 13);
            this.labelProductionDate.TabIndex = 0;
            this.labelProductionDate.Text = "Production Date:";
            // 
            // labelBatchNo
            // 
            this.labelBatchNo.AutoSize = true;
            this.labelBatchNo.Location = new System.Drawing.Point(236, 65);
            this.labelBatchNo.Name = "labelBatchNo";
            this.labelBatchNo.Size = new System.Drawing.Size(55, 13);
            this.labelBatchNo.TabIndex = 2;
            this.labelBatchNo.Text = "Batch No:";
            // 
            // textBoxBatchNo
            // 
            this.textBoxBatchNo.Location = new System.Drawing.Point(305, 60);
            this.textBoxBatchNo.Name = "textBoxBatchNo";
            this.textBoxBatchNo.ReadOnly = true;
            this.textBoxBatchNo.Size = new System.Drawing.Size(100, 20);
            this.textBoxBatchNo.TabIndex = 3;
            // 
            // labelTotalQty
            // 
            this.labelTotalQty.AutoSize = true;
            this.labelTotalQty.Location = new System.Drawing.Point(698, 89);
            this.labelTotalQty.Name = "labelTotalQty";
            this.labelTotalQty.Size = new System.Drawing.Size(53, 13);
            this.labelTotalQty.TabIndex = 4;
            this.labelTotalQty.Text = "Total Qty:";
            // 
            // textBoxTotalQty
            // 
            this.textBoxTotalQty.Location = new System.Drawing.Point(778, 84);
            this.textBoxTotalQty.Name = "textBoxTotalQty";
            this.textBoxTotalQty.ReadOnly = true;
            this.textBoxTotalQty.Size = new System.Drawing.Size(80, 20);
            this.textBoxTotalQty.TabIndex = 5;
            // 
            // dataGridViewPacking
            // 
            this.dataGridViewPacking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPacking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sn,
            this.dgvItemId,
            this.dgvItemCode,
            this.ItemName,
            this.Variant,
            this.Quantity,
            this.BatchNumber,
            this.PackingDate,
            this.RackNo});
            this.dataGridViewPacking.Location = new System.Drawing.Point(22, 109);
            this.dataGridViewPacking.Name = "dataGridViewPacking";
            this.dataGridViewPacking.RowHeadersVisible = false;
            this.dataGridViewPacking.RowHeadersWidth = 51;
            this.dataGridViewPacking.RowTemplate.Height = 24;
            this.dataGridViewPacking.Size = new System.Drawing.Size(839, 300);
            this.dataGridViewPacking.TabIndex = 6;
            this.dataGridViewPacking.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPacking_CellEndEdit);
            this.dataGridViewPacking.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPacking_CellValueChanged);
            this.dataGridViewPacking.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewPacking_EditingControlShowing);
            this.dataGridViewPacking.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewPacking_RowPostPaint);
            // 
            // Sn
            // 
            this.Sn.FillWeight = 2.5F;
            this.Sn.HeaderText = "Sn";
            this.Sn.Name = "Sn";
            this.Sn.ReadOnly = true;
            this.Sn.Width = 40;
            // 
            // dgvItemId
            // 
            this.dgvItemId.HeaderText = "ItemId";
            this.dgvItemId.Name = "dgvItemId";
            this.dgvItemId.ReadOnly = true;
            this.dgvItemId.Visible = false;
            // 
            // dgvItemCode
            // 
            this.dgvItemCode.HeaderText = "Code";
            this.dgvItemCode.Name = "dgvItemCode";
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            // 
            // Variant
            // 
            this.Variant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Variant.HeaderText = "Variant / Brand";
            this.Variant.MinimumWidth = 6;
            this.Variant.Name = "Variant";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Qty";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 50;
            // 
            // BatchNumber
            // 
            this.BatchNumber.HeaderText = "Batch No";
            this.BatchNumber.MinimumWidth = 6;
            this.BatchNumber.Name = "BatchNumber";
            this.BatchNumber.Width = 50;
            // 
            // PackingDate
            // 
            this.PackingDate.HeaderText = "Packing Date";
            this.PackingDate.MinimumWidth = 6;
            this.PackingDate.Name = "PackingDate";
            this.PackingDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PackingDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PackingDate.Width = 80;
            // 
            // RackNo
            // 
            this.RackNo.HeaderText = "Rack No";
            this.RackNo.MinimumWidth = 6;
            this.RackNo.Name = "RackNo";
            this.RackNo.Width = 50;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(890, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 469);
            this.panel2.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 469);
            this.panel3.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 467);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 2);
            this.panel1.TabIndex = 18;
            // 
            // pnlheader
            // 
            this.pnlheader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(41)))), ((int)(((byte)(83)))));
            this.pnlheader.Controls.Add(this.btnMinimize);
            this.pnlheader.Controls.Add(this.guna2Button3);
            this.pnlheader.Controls.Add(this.guna2Button2);
            this.pnlheader.Controls.Add(this.CRM);
            this.pnlheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlheader.Location = new System.Drawing.Point(2, 0);
            this.pnlheader.Name = "pnlheader";
            this.pnlheader.Size = new System.Drawing.Size(888, 41);
            this.pnlheader.TabIndex = 19;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BorderColor = System.Drawing.Color.White;
            this.btnMinimize.BorderRadius = 5;
            this.btnMinimize.BorderThickness = 1;
            this.btnMinimize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMinimize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMinimize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMinimize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Image = global::YamyProject.Properties.Resources.minimizeN;
            this.btnMinimize.ImageSize = new System.Drawing.Size(60, 60);
            this.btnMinimize.Location = new System.Drawing.Point(813, 4);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(34, 32);
            this.btnMinimize.TabIndex = 39;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // guna2Button3
            // 
            this.guna2Button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderColor = System.Drawing.Color.White;
            this.guna2Button3.BorderRadius = 5;
            this.guna2Button3.BorderThickness = 1;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.Image = global::YamyProject.Properties.Resources.closeN;
            this.guna2Button3.ImageSize = new System.Drawing.Size(60, 60);
            this.guna2Button3.Location = new System.Drawing.Point(849, 4);
            this.guna2Button3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(34, 32);
            this.guna2Button3.TabIndex = 40;
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Image = global::YamyProject.Properties.Resources.productN;
            this.guna2Button2.Location = new System.Drawing.Point(7, 7);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(28, 28);
            this.guna2Button2.TabIndex = 2;
            // 
            // CRM
            // 
            this.CRM.AutoSize = false;
            this.CRM.BackColor = System.Drawing.Color.Transparent;
            this.CRM.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CRM.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CRM.Location = new System.Drawing.Point(38, 13);
            this.CRM.Name = "CRM";
            this.CRM.Size = new System.Drawing.Size(190, 19);
            this.CRM.TabIndex = 34;
            this.CRM.Text = "Manage Product Packing";
            // 
            // dtInv
            // 
            this.dtInv.Enabled = false;
            this.dtInv.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInv.Location = new System.Drawing.Point(111, 61);
            this.dtInv.Name = "dtInv";
            this.dtInv.Size = new System.Drawing.Size(108, 20);
            this.dtInv.TabIndex = 75;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.btnSave.BorderRadius = 5;
            this.btnSave.BorderThickness = 3;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(784, 430);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 27);
            this.btnSave.TabIndex = 76;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.Location = new System.Drawing.Point(111, 86);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.ReadOnly = true;
            this.textBoxItemName.Size = new System.Drawing.Size(495, 20);
            this.textBoxItemName.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 77;
            this.label1.Text = "Product Name :";
            // 
            // cmbWarehouseTo
            // 
            this.cmbWarehouseTo.BackColor = System.Drawing.Color.Transparent;
            this.cmbWarehouseTo.BorderRadius = 5;
            this.cmbWarehouseTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbWarehouseTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouseTo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbWarehouseTo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbWarehouseTo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cmbWarehouseTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbWarehouseTo.ItemHeight = 18;
            this.cmbWarehouseTo.Location = new System.Drawing.Point(546, 54);
            this.cmbWarehouseTo.Name = "cmbWarehouseTo";
            this.cmbWarehouseTo.Size = new System.Drawing.Size(313, 24);
            this.cmbWarehouseTo.TabIndex = 82;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(476, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 83;
            this.label11.Text = "Warehouse";
            // 
            // dgvitem2
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvitem2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvitem2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvitem2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvitem2.ColumnHeadersHeight = 15;
            this.dgvitem2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvitem2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvitem2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvitem2.Location = new System.Drawing.Point(64, 173);
            this.dgvitem2.Name = "dgvitem2";
            this.dgvitem2.ReadOnly = true;
            this.dgvitem2.RowHeadersVisible = false;
            this.dgvitem2.RowHeadersWidth = 51;
            this.dgvitem2.Size = new System.Drawing.Size(331, 80);
            this.dgvitem2.TabIndex = 84;
            this.dgvitem2.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvitem2.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvitem2.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvitem2.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvitem2.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvitem2.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvitem2.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvitem2.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.dgvitem2.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvitem2.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvitem2.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvitem2.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvitem2.ThemeStyle.HeaderStyle.Height = 15;
            this.dgvitem2.ThemeStyle.ReadOnly = true;
            this.dgvitem2.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvitem2.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvitem2.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvitem2.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvitem2.ThemeStyle.RowsStyle.Height = 22;
            this.dgvitem2.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvitem2.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvitem2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvitem2_CellClick);
            this.dgvitem2.Leave += new System.EventHandler(this.dgvitem2_Leave);
            // 
            // frmManProductPacking
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(892, 469);
            this.Controls.Add(this.dgvitem2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbWarehouseTo);
            this.Controls.Add(this.textBoxItemName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtInv);
            this.Controls.Add(this.pnlheader);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridViewPacking);
            this.Controls.Add(this.textBoxTotalQty);
            this.Controls.Add(this.labelTotalQty);
            this.Controls.Add(this.textBoxBatchNo);
            this.Controls.Add(this.labelBatchNo);
            this.Controls.Add(this.labelProductionDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManProductPacking";
            this.Text = "Food Production Packing Form";
            this.Load += new System.EventHandler(this.frmManProductPacking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacking)).EndInit();
            this.pnlheader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvitem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label labelProductionDate;
        private System.Windows.Forms.Label labelBatchNo;
        private System.Windows.Forms.TextBox textBoxBatchNo;
        private System.Windows.Forms.Label labelTotalQty;
        private System.Windows.Forms.TextBox textBoxTotalQty;
        private System.Windows.Forms.DataGridView dataGridViewPacking;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlheader;
        private Guna.UI2.WinForms.Guna2Button btnMinimize;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2HtmlLabel CRM;
        private System.Windows.Forms.DateTimePicker dtInv;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.TextBox textBoxItemName;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbWarehouseTo;
        public System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2DataGridView dgvitem2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNumber;
        private frmViewPettyCashVoucher.DataGridViewCalendarColumn PackingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RackNo;
    }
}