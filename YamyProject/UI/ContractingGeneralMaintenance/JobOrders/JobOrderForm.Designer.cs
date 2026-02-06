using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.JobOrders
{
    partial class JobOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobOrderForm));
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblAssign = new System.Windows.Forms.Label();
            this.cmbAssigned = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.txtEstimatedHours = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtActualHours = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtActualCost = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEstimatedCost = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(20, 26);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(100, 23);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Job Type";
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
            "Work Order",
            "Maintenance Job",
            "Emergency Job"});
            this.cmbType.Location = new System.Drawing.Point(20, 40);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(300, 28);
            this.cmbType.TabIndex = 1;
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(20, 80);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(100, 17);
            this.lblProject.TabIndex = 2;
            this.lblProject.Text = "Project / Asset";
            // 
            // cmbProject
            // 
            this.cmbProject.BackColor = System.Drawing.Color.Transparent;
            this.cmbProject.BorderRadius = 5;
            this.cmbProject.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cmbProject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FocusedColor = System.Drawing.Color.Empty;
            this.cmbProject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbProject.ItemHeight = 30;
            this.cmbProject.Location = new System.Drawing.Point(20, 93);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(300, 36);
            this.cmbProject.TabIndex = 3;
            // 
            // lblAssign
            // 
            this.lblAssign.Location = new System.Drawing.Point(20, 140);
            this.lblAssign.Name = "lblAssign";
            this.lblAssign.Size = new System.Drawing.Size(100, 23);
            this.lblAssign.TabIndex = 4;
            this.lblAssign.Text = "Assign To";
            // 
            // cmbAssigned
            // 
            this.cmbAssigned.BackColor = System.Drawing.Color.Transparent;
            this.cmbAssigned.BorderRadius = 5;
            this.cmbAssigned.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAssigned.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssigned.FocusedColor = System.Drawing.Color.Empty;
            this.cmbAssigned.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAssigned.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbAssigned.ItemHeight = 22;
            this.cmbAssigned.Location = new System.Drawing.Point(20, 154);
            this.cmbAssigned.Name = "cmbAssigned";
            this.cmbAssigned.Size = new System.Drawing.Size(300, 28);
            this.cmbAssigned.TabIndex = 5;
            // 
            // lblHours
            // 
            this.lblHours.Location = new System.Drawing.Point(20, 197);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(100, 23);
            this.lblHours.TabIndex = 6;
            this.lblHours.Text = "Estimated Hours";
            // 
            // txtEstimatedHours
            // 
            this.txtEstimatedHours.BorderRadius = 5;
            this.txtEstimatedHours.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEstimatedHours.DefaultText = "";
            this.txtEstimatedHours.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEstimatedHours.Location = new System.Drawing.Point(20, 212);
            this.txtEstimatedHours.Name = "txtEstimatedHours";
            this.txtEstimatedHours.PlaceholderText = "";
            this.txtEstimatedHours.SelectedText = "";
            this.txtEstimatedHours.Size = new System.Drawing.Size(125, 27);
            this.txtEstimatedHours.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(134, 300);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 30);
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
            this.lblHeader.Text = "Job / Work Order";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 5;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(294, 300);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 30);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 335);
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
            this.panel4.Size = new System.Drawing.Size(2, 311);
            this.panel4.TabIndex = 29;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 26);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 311);
            this.panel5.TabIndex = 28;
            // 
            // txtActualHours
            // 
            this.txtActualHours.BorderRadius = 5;
            this.txtActualHours.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtActualHours.DefaultText = "";
            this.txtActualHours.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtActualHours.Location = new System.Drawing.Point(195, 212);
            this.txtActualHours.Name = "txtActualHours";
            this.txtActualHours.PlaceholderText = "";
            this.txtActualHours.SelectedText = "";
            this.txtActualHours.Size = new System.Drawing.Size(125, 27);
            this.txtActualHours.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(195, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 31;
            this.label1.Text = "Actual Hours";
            // 
            // txtActualCost
            // 
            this.txtActualCost.BorderRadius = 5;
            this.txtActualCost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtActualCost.DefaultText = "";
            this.txtActualCost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtActualCost.Location = new System.Drawing.Point(195, 267);
            this.txtActualCost.Name = "txtActualCost";
            this.txtActualCost.PlaceholderText = "";
            this.txtActualCost.SelectedText = "";
            this.txtActualCost.Size = new System.Drawing.Size(125, 27);
            this.txtActualCost.TabIndex = 36;
            this.txtActualCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(195, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 35;
            this.label2.Text = "Actual Cost";
            // 
            // txtEstimatedCost
            // 
            this.txtEstimatedCost.BorderRadius = 5;
            this.txtEstimatedCost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEstimatedCost.DefaultText = "";
            this.txtEstimatedCost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEstimatedCost.Location = new System.Drawing.Point(20, 267);
            this.txtEstimatedCost.Name = "txtEstimatedCost";
            this.txtEstimatedCost.PlaceholderText = "";
            this.txtEstimatedCost.SelectedText = "";
            this.txtEstimatedCost.Size = new System.Drawing.Size(125, 27);
            this.txtEstimatedCost.TabIndex = 34;
            this.txtEstimatedCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 33;
            this.label3.Text = "Estimated Cost";
            // 
            // JobOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 337);
            this.Controls.Add(this.txtActualCost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEstimatedCost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtActualHours);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.cmbAssigned);
            this.Controls.Add(this.txtEstimatedHours);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.lblAssign);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.lblType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JobOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Job / Work Order";
            this.Load += new System.EventHandler(this.JobOrderForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna2ComboBox cmbType;
        private Guna2ComboBox cmbAssigned;
        private Guna2ComboBox cmbProject;
        private Guna2TextBox txtEstimatedHours;
        private Guna2Button btnSave;
        private Label lblType;
        private Label lblProject;
        private Label lblAssign;
        private Label lblHours;
        private Panel panel1;
        private Label lblHeader;
        private Guna2Button btnClose;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Guna2TextBox txtActualHours;
        private Label label1;
        private Guna2TextBox txtActualCost;
        private Label label2;
        private Guna2TextBox txtEstimatedCost;
        private Label label3;
    }
}