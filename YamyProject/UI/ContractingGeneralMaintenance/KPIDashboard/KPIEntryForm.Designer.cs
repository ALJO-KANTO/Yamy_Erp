using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.KPIDashboard
{
    partial class KPIEntryForm
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
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCat = new System.Windows.Forms.Label();
            this.cmbCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.txtTarget = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblActual = new System.Windows.Forms.Label();
            this.txtActual = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(20, 43);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(100, 23);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "KPI Code";
            // 
            // txtCode
            // 
            this.txtCode.BorderRadius = 5;
            this.txtCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCode.DefaultText = "";
            this.txtCode.Enabled = false;
            this.txtCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCode.Location = new System.Drawing.Point(20, 57);
            this.txtCode.Name = "txtCode";
            this.txtCode.PlaceholderText = "";
            this.txtCode.SelectedText = "";
            this.txtCode.Size = new System.Drawing.Size(121, 30);
            this.txtCode.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(20, 105);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "KPI Name";
            // 
            // txtName
            // 
            this.txtName.BorderRadius = 5;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.Location = new System.Drawing.Point(20, 119);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(343, 30);
            this.txtName.TabIndex = 3;
            // 
            // lblCat
            // 
            this.lblCat.Location = new System.Drawing.Point(20, 165);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(100, 23);
            this.lblCat.TabIndex = 4;
            this.lblCat.Text = "Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.Color.Transparent;
            this.cmbCategory.BorderRadius = 5;
            this.cmbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FocusedColor = System.Drawing.Color.Empty;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbCategory.ItemHeight = 22;
            this.cmbCategory.Items.AddRange(new object[] {
            "Project",
            "Finance",
            "Maintenance",
            "HR"});
            this.cmbCategory.Location = new System.Drawing.Point(20, 180);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 28);
            this.cmbCategory.TabIndex = 5;
            // 
            // lblTarget
            // 
            this.lblTarget.Location = new System.Drawing.Point(20, 226);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(100, 23);
            this.lblTarget.TabIndex = 6;
            this.lblTarget.Text = "Target Value";
            // 
            // txtTarget
            // 
            this.txtTarget.BorderRadius = 5;
            this.txtTarget.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTarget.DefaultText = "";
            this.txtTarget.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTarget.Location = new System.Drawing.Point(20, 241);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.PlaceholderText = "";
            this.txtTarget.SelectedText = "";
            this.txtTarget.Size = new System.Drawing.Size(200, 30);
            this.txtTarget.TabIndex = 7;
            this.txtTarget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTarget_KeyPress);
            // 
            // lblActual
            // 
            this.lblActual.Location = new System.Drawing.Point(20, 286);
            this.lblActual.Name = "lblActual";
            this.lblActual.Size = new System.Drawing.Size(100, 23);
            this.lblActual.TabIndex = 8;
            this.lblActual.Text = "Actual Value";
            // 
            // txtActual
            // 
            this.txtActual.BorderRadius = 5;
            this.txtActual.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtActual.DefaultText = "";
            this.txtActual.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtActual.Location = new System.Drawing.Point(20, 300);
            this.txtActual.Name = "txtActual";
            this.txtActual.PlaceholderText = "";
            this.txtActual.SelectedText = "";
            this.txtActual.Size = new System.Drawing.Size(200, 30);
            this.txtActual.TabIndex = 9;
            this.txtActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtActual_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(19, 350);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 31);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save KPI";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 26);
            this.panel1.TabIndex = 18;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(385, 20);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "KPI Entry";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(271, 350);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(92, 31);
            this.guna2Button1.TabIndex = 19;
            this.guna2Button1.Text = "Close";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 388);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(381, 2);
            this.panel3.TabIndex = 30;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(383, 26);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 364);
            this.panel4.TabIndex = 29;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 26);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 364);
            this.panel5.TabIndex = 28;
            // 
            // KPIEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 390);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.txtActual);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCat);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.lblActual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KPIEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KPI Entry";
            this.Load += new System.EventHandler(this.KPIEntryForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        Guna2TextBox txtCode, txtName, txtTarget, txtActual;
        Guna2ComboBox cmbCategory;
        Guna2Button btnSave;
        private Label lblCode;
        private Label lblName;
        private Label lblCat;
        private Label lblTarget;
        private Label lblActual;
        private Panel panel1;
        private Label lblHeader;
        private Guna2Button guna2Button1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}