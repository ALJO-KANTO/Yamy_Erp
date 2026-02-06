using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.Inventory
{
    partial class MaterialForm
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialForm));
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.cmbWarehouse = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtQty = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblMin = new System.Windows.Forms.Label();
            this.txtMin = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtCost = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(20, 56);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Material Name";
            // 
            // txtName
            // 
            this.txtName.BorderRadius = 5;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.Location = new System.Drawing.Point(20, 68);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(342, 28);
            this.txtName.TabIndex = 1;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.Location = new System.Drawing.Point(20, 106);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(100, 23);
            this.lblWarehouse.TabIndex = 2;
            this.lblWarehouse.Text = "Warehouse";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.BackColor = System.Drawing.Color.Transparent;
            this.cmbWarehouse.BorderRadius = 5;
            this.cmbWarehouse.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.FocusedColor = System.Drawing.Color.Empty;
            this.cmbWarehouse.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbWarehouse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbWarehouse.ItemHeight = 22;
            this.cmbWarehouse.Items.AddRange(new object[] {
            "Main Store",
            "Warehouse B"});
            this.cmbWarehouse.Location = new System.Drawing.Point(20, 120);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(235, 28);
            this.cmbWarehouse.TabIndex = 3;
            // 
            // lblQty
            // 
            this.lblQty.Location = new System.Drawing.Point(20, 163);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(100, 23);
            this.lblQty.TabIndex = 4;
            this.lblQty.Text = "Quantity";
            // 
            // txtQty
            // 
            this.txtQty.BorderRadius = 5;
            this.txtQty.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQty.DefaultText = "";
            this.txtQty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtQty.Location = new System.Drawing.Point(20, 176);
            this.txtQty.Name = "txtQty";
            this.txtQty.PlaceholderText = "";
            this.txtQty.SelectedText = "";
            this.txtQty.Size = new System.Drawing.Size(100, 25);
            this.txtQty.TabIndex = 5;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // lblMin
            // 
            this.lblMin.Location = new System.Drawing.Point(20, 212);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(100, 23);
            this.lblMin.TabIndex = 6;
            this.lblMin.Text = "Minimum Level";
            // 
            // txtMin
            // 
            this.txtMin.BorderRadius = 5;
            this.txtMin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMin.DefaultText = "";
            this.txtMin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMin.Location = new System.Drawing.Point(20, 226);
            this.txtMin.Name = "txtMin";
            this.txtMin.PlaceholderText = "";
            this.txtMin.SelectedText = "";
            this.txtMin.Size = new System.Drawing.Size(100, 25);
            this.txtMin.TabIndex = 7;
            this.txtMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // lblCost
            // 
            this.lblCost.Location = new System.Drawing.Point(20, 262);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(100, 23);
            this.lblCost.TabIndex = 8;
            this.lblCost.Text = "Unit Cost";
            // 
            // txtCost
            // 
            this.txtCost.BorderRadius = 5;
            this.txtCost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCost.DefaultText = "";
            this.txtCost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCost.Location = new System.Drawing.Point(20, 276);
            this.txtCost.Name = "txtCost";
            this.txtCost.PlaceholderText = "";
            this.txtCost.SelectedText = "";
            this.txtCost.Size = new System.Drawing.Size(100, 25);
            this.txtCost.TabIndex = 9;
            this.txtCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(159, 315);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 26);
            this.panel1.TabIndex = 11;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(400, 20);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Material Master";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 5;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(313, 315);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 348);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(396, 2);
            this.panel3.TabIndex = 30;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(398, 26);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 324);
            this.panel4.TabIndex = 29;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 26);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 324);
            this.panel5.TabIndex = 28;
            // 
            // MaterialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblWarehouse);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblCost);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MaterialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Material Master";
            this.Load += new System.EventHandler(this.MaterialForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        Guna2TextBox txtName, txtQty, txtMin, txtCost;
        Guna2ComboBox cmbWarehouse;
        Guna2Button btnSave;
        private Label lblName;
        private Label lblWarehouse;
        private Label lblQty;
        private Label lblMin;
        private Label lblCost;
        private Panel panel1;
        private Label lblHeader;
        private Guna2Button btnClose;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}