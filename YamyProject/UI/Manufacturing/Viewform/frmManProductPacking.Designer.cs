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
            this.labelProductionDate = new System.Windows.Forms.Label();
            this.dateTimePickerProduction = new System.Windows.Forms.DateTimePicker();
            this.labelBatchNo = new System.Windows.Forms.Label();
            this.textBoxBatchNo = new System.Windows.Forms.TextBox();
            this.labelTotalQty = new System.Windows.Forms.Label();
            this.textBoxTotalQty = new System.Windows.Forms.TextBox();
            this.dataGridViewPacking = new System.Windows.Forms.DataGridView();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Variant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RackNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlheader = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.CRM = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacking)).BeginInit();
            this.pnlheader.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelProductionDate
            // 
            this.labelProductionDate.AutoSize = true;
            this.labelProductionDate.Location = new System.Drawing.Point(22, 69);
            this.labelProductionDate.Name = "labelProductionDate";
            this.labelProductionDate.Size = new System.Drawing.Size(87, 13);
            this.labelProductionDate.TabIndex = 0;
            this.labelProductionDate.Text = "Production Date:";
            // 
            // dateTimePickerProduction
            // 
            this.dateTimePickerProduction.Location = new System.Drawing.Point(132, 64);
            this.dateTimePickerProduction.Name = "dateTimePickerProduction";
            this.dateTimePickerProduction.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerProduction.TabIndex = 1;
            // 
            // labelBatchNo
            // 
            this.labelBatchNo.AutoSize = true;
            this.labelBatchNo.Location = new System.Drawing.Point(362, 69);
            this.labelBatchNo.Name = "labelBatchNo";
            this.labelBatchNo.Size = new System.Drawing.Size(55, 13);
            this.labelBatchNo.TabIndex = 2;
            this.labelBatchNo.Text = "Batch No:";
            // 
            // textBoxBatchNo
            // 
            this.textBoxBatchNo.Location = new System.Drawing.Point(432, 64);
            this.textBoxBatchNo.Name = "textBoxBatchNo";
            this.textBoxBatchNo.Size = new System.Drawing.Size(100, 20);
            this.textBoxBatchNo.TabIndex = 3;
            // 
            // labelTotalQty
            // 
            this.labelTotalQty.AutoSize = true;
            this.labelTotalQty.Location = new System.Drawing.Point(552, 69);
            this.labelTotalQty.Name = "labelTotalQty";
            this.labelTotalQty.Size = new System.Drawing.Size(53, 13);
            this.labelTotalQty.TabIndex = 4;
            this.labelTotalQty.Text = "Total Qty:";
            // 
            // textBoxTotalQty
            // 
            this.textBoxTotalQty.Location = new System.Drawing.Point(632, 64);
            this.textBoxTotalQty.Name = "textBoxTotalQty";
            this.textBoxTotalQty.Size = new System.Drawing.Size(80, 20);
            this.textBoxTotalQty.TabIndex = 5;
            // 
            // dataGridViewPacking
            // 
            this.dataGridViewPacking.AllowUserToAddRows = false;
            this.dataGridViewPacking.AllowUserToDeleteRows = false;
            this.dataGridViewPacking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPacking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.Variant,
            this.Quantity,
            this.BatchNumber,
            this.PackingDate,
            this.RackNo});
            this.dataGridViewPacking.Location = new System.Drawing.Point(22, 109);
            this.dataGridViewPacking.Name = "dataGridViewPacking";
            this.dataGridViewPacking.ReadOnly = true;
            this.dataGridViewPacking.RowHeadersWidth = 51;
            this.dataGridViewPacking.RowTemplate.Height = 24;
            this.dataGridViewPacking.Size = new System.Drawing.Size(690, 300);
            this.dataGridViewPacking.TabIndex = 6;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // Variant
            // 
            this.Variant.HeaderText = "Variant / Brand";
            this.Variant.MinimumWidth = 6;
            this.Variant.Name = "Variant";
            this.Variant.ReadOnly = true;
            this.Variant.Width = 120;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 80;
            // 
            // BatchNumber
            // 
            this.BatchNumber.HeaderText = "Batch No";
            this.BatchNumber.MinimumWidth = 6;
            this.BatchNumber.Name = "BatchNumber";
            this.BatchNumber.ReadOnly = true;
            this.BatchNumber.Width = 80;
            // 
            // PackingDate
            // 
            this.PackingDate.HeaderText = "Packing Date";
            this.PackingDate.MinimumWidth = 6;
            this.PackingDate.Name = "PackingDate";
            this.PackingDate.ReadOnly = true;
            this.PackingDate.Width = 120;
            // 
            // RackNo
            // 
            this.RackNo.HeaderText = "Rack No";
            this.RackNo.MinimumWidth = 6;
            this.RackNo.Name = "RackNo";
            this.RackNo.ReadOnly = true;
            this.RackNo.Width = 80;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(602, 429);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(110, 30);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(738, 0);
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
            this.panel1.Size = new System.Drawing.Size(736, 2);
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
            this.pnlheader.Size = new System.Drawing.Size(736, 41);
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
            this.btnMinimize.Location = new System.Drawing.Point(661, 4);
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
            this.guna2Button3.Location = new System.Drawing.Point(697, 4);
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
            // frmManProductPacking
            // 
            this.ClientSize = new System.Drawing.Size(740, 469);
            this.Controls.Add(this.pnlheader);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridViewPacking);
            this.Controls.Add(this.textBoxTotalQty);
            this.Controls.Add(this.labelTotalQty);
            this.Controls.Add(this.textBoxBatchNo);
            this.Controls.Add(this.labelBatchNo);
            this.Controls.Add(this.dateTimePickerProduction);
            this.Controls.Add(this.labelProductionDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManProductPacking";
            this.Text = "Food Production Packing Form";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacking)).EndInit();
            this.pnlheader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label labelProductionDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerProduction;
        private System.Windows.Forms.Label labelBatchNo;
        private System.Windows.Forms.TextBox textBoxBatchNo;
        private System.Windows.Forms.Label labelTotalQty;
        private System.Windows.Forms.TextBox textBoxTotalQty;
        private System.Windows.Forms.DataGridView dataGridViewPacking;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RackNo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlheader;
        private Guna.UI2.WinForms.Guna2Button btnMinimize;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2HtmlLabel CRM;
    }
}