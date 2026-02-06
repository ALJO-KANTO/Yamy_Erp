using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.Maintenance
{
    partial class MaintenanceRequestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaintenanceRequestForm));
            this.lblAsset = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cmbPriority = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblTech = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtCost = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbAsset = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbTechnician = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAsset
            // 
            this.lblAsset.Location = new System.Drawing.Point(21, 45);
            this.lblAsset.Name = "lblAsset";
            this.lblAsset.Size = new System.Drawing.Size(47, 23);
            this.lblAsset.TabIndex = 0;
            this.lblAsset.Text = "Asset";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(21, 93);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(100, 23);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Maintenance Type";
            // 
            // cmbType
            // 
            this.cmbType.BackColor = System.Drawing.Color.Transparent;
            this.cmbType.BorderRadius = 5;
            this.cmbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FocusedColor = System.Drawing.Color.Empty;
            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbType.ItemHeight = 22;
            this.cmbType.Items.AddRange(new object[] {
            "Preventive",
            "Corrective",
            "Emergency"});
            this.cmbType.Location = new System.Drawing.Point(125, 88);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(200, 28);
            this.cmbType.TabIndex = 3;
            // 
            // lblPriority
            // 
            this.lblPriority.Location = new System.Drawing.Point(21, 140);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(100, 23);
            this.lblPriority.TabIndex = 4;
            this.lblPriority.Text = "Priority";
            // 
            // cmbPriority
            // 
            this.cmbPriority.BackColor = System.Drawing.Color.Transparent;
            this.cmbPriority.BorderRadius = 5;
            this.cmbPriority.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FocusedColor = System.Drawing.Color.Empty;
            this.cmbPriority.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbPriority.ItemHeight = 22;
            this.cmbPriority.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High",
            "Critical"});
            this.cmbPriority.Location = new System.Drawing.Point(125, 135);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(200, 28);
            this.cmbPriority.TabIndex = 5;
            // 
            // lblTech
            // 
            this.lblTech.Location = new System.Drawing.Point(21, 186);
            this.lblTech.Name = "lblTech";
            this.lblTech.Size = new System.Drawing.Size(100, 23);
            this.lblTech.TabIndex = 6;
            this.lblTech.Text = "Technician";
            // 
            // lblCost
            // 
            this.lblCost.Location = new System.Drawing.Point(21, 232);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(100, 23);
            this.lblCost.TabIndex = 8;
            this.lblCost.Text = "Cost";
            // 
            // txtCost
            // 
            this.txtCost.BorderRadius = 5;
            this.txtCost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCost.DefaultText = "";
            this.txtCost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCost.Location = new System.Drawing.Point(125, 227);
            this.txtCost.Name = "txtCost";
            this.txtCost.PlaceholderText = "";
            this.txtCost.SelectedText = "";
            this.txtCost.Size = new System.Drawing.Size(118, 28);
            this.txtCost.TabIndex = 9;
            this.txtCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCost_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(169, 315);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 23);
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
            this.panel1.TabIndex = 13;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(400, 20);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Job / Work Order";
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
            // cmbAsset
            // 
            this.cmbAsset.BackColor = System.Drawing.Color.Transparent;
            this.cmbAsset.BorderRadius = 5;
            this.cmbAsset.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAsset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAsset.FocusedColor = System.Drawing.Color.Empty;
            this.cmbAsset.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAsset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbAsset.ItemHeight = 22;
            this.cmbAsset.Items.AddRange(new object[] {
            "Preventive",
            "Corrective",
            "Emergency"});
            this.cmbAsset.Location = new System.Drawing.Point(125, 32);
            this.cmbAsset.Name = "cmbAsset";
            this.cmbAsset.Size = new System.Drawing.Size(268, 28);
            this.cmbAsset.TabIndex = 31;
            // 
            // cmbTechnician
            // 
            this.cmbTechnician.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTechnician.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTechnician.FormattingEnabled = true;
            this.cmbTechnician.ItemHeight = 13;
            this.cmbTechnician.Location = new System.Drawing.Point(127, 188);
            this.cmbTechnician.Name = "cmbTechnician";
            this.cmbTechnician.Size = new System.Drawing.Size(198, 21);
            this.cmbTechnician.TabIndex = 32;
            // 
            // MaintenanceRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.cmbTechnician);
            this.Controls.Add(this.cmbAsset);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblAsset);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.lblTech);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MaintenanceRequestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Maintenance Request";
            this.Load += new System.EventHandler(this.MaintenanceRequestForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        Guna2ComboBox cmbType, cmbPriority;
        Guna2TextBox txtCost;
        Guna2Button btnSave;
        private Label lblAsset;
        private Label lblType;
        private Label lblPriority;
        private Label lblTech;
        private Label lblCost;
        private Panel panel1;
        private Label lblHeader;
        private Guna2Button btnClose;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Guna2ComboBox cmbAsset;
        private ComboBox cmbTechnician;
    }
}