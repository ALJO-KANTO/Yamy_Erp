using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.Equipment
{
    partial class EquipmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EquipmentForm));
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtCategory = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPurchase = new System.Windows.Forms.Label();
            this.dtPurchase = new System.Windows.Forms.DateTimePicker();
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
            this.lblName.Location = new System.Drawing.Point(20, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Equipment Name";
            // 
            // txtName
            // 
            this.txtName.BorderRadius = 5;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.Location = new System.Drawing.Point(20, 75);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(300, 28);
            this.txtName.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(20, 123);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(100, 23);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category";
            // 
            // txtCategory
            // 
            this.txtCategory.BorderRadius = 5;
            this.txtCategory.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCategory.DefaultText = "";
            this.txtCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCategory.Location = new System.Drawing.Point(20, 139);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.PlaceholderText = "";
            this.txtCategory.SelectedText = "";
            this.txtCategory.Size = new System.Drawing.Size(200, 28);
            this.txtCategory.TabIndex = 3;
            // 
            // lblPurchase
            // 
            this.lblPurchase.Location = new System.Drawing.Point(20, 187);
            this.lblPurchase.Name = "lblPurchase";
            this.lblPurchase.Size = new System.Drawing.Size(100, 23);
            this.lblPurchase.TabIndex = 4;
            this.lblPurchase.Text = "Purchase Date";
            // 
            // dtPurchase
            // 
            this.dtPurchase.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPurchase.Location = new System.Drawing.Point(20, 203);
            this.dtPurchase.Name = "dtPurchase";
            this.dtPurchase.Size = new System.Drawing.Size(120, 20);
            this.dtPurchase.TabIndex = 5;
            // 
            // lblCost
            // 
            this.lblCost.Location = new System.Drawing.Point(20, 238);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(100, 23);
            this.lblCost.TabIndex = 6;
            this.lblCost.Text = "Cost";
            // 
            // txtCost
            // 
            this.txtCost.BorderRadius = 5;
            this.txtCost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCost.DefaultText = "";
            this.txtCost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCost.Location = new System.Drawing.Point(20, 253);
            this.txtCost.Name = "txtCost";
            this.txtCost.PlaceholderText = "";
            this.txtCost.SelectedText = "";
            this.txtCost.Size = new System.Drawing.Size(200, 28);
            this.txtCost.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(149, 305);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 33);
            this.btnSave.TabIndex = 8;
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
            this.panel1.TabIndex = 12;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(400, 20);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Equipment / Asset Details";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 5;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(296, 305);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 33);
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
            // EquipmentForm
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
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.dtPurchase);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblPurchase);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EquipmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Equipment / Asset Details";
            this.Load += new System.EventHandler(this.EquipmentForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        Guna2TextBox txtName, txtCategory, txtCost;
        DateTimePicker dtPurchase;
        Guna2Button btnSave;
        private Label lblName;
        private Label lblCategory;
        private Label lblPurchase;
        private Label lblCost;
        private Panel panel1;
        private Label lblHeader;
        private Guna2Button btnClose;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}