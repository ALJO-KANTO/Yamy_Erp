using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.ProjectManagement
{
    partial class ProjectForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.lblBudget = new System.Windows.Forms.Label();
            this.txtBudget = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtActualCost = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(20, 38);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Project Name";
            // 
            // txtName
            // 
            this.txtName.BorderRadius = 5;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.Location = new System.Drawing.Point(20, 55);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(300, 22);
            this.txtName.TabIndex = 1;
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(20, 92);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(100, 13);
            this.lblStart.TabIndex = 2;
            this.lblStart.Text = "Start Date";
            // 
            // dtStart
            // 
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStart.Location = new System.Drawing.Point(20, 108);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(119, 20);
            this.dtStart.TabIndex = 3;
            // 
            // lblEnd
            // 
            this.lblEnd.Location = new System.Drawing.Point(20, 142);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(100, 12);
            this.lblEnd.TabIndex = 4;
            this.lblEnd.Text = "End Date";
            // 
            // dtEnd
            // 
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEnd.Location = new System.Drawing.Point(20, 156);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(119, 20);
            this.dtEnd.TabIndex = 5;
            // 
            // lblBudget
            // 
            this.lblBudget.Location = new System.Drawing.Point(20, 188);
            this.lblBudget.Name = "lblBudget";
            this.lblBudget.Size = new System.Drawing.Size(100, 14);
            this.lblBudget.TabIndex = 6;
            this.lblBudget.Text = "Budget";
            // 
            // txtBudget
            // 
            this.txtBudget.BorderRadius = 5;
            this.txtBudget.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBudget.DefaultText = "";
            this.txtBudget.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBudget.Location = new System.Drawing.Point(20, 205);
            this.txtBudget.Name = "txtBudget";
            this.txtBudget.PlaceholderText = "";
            this.txtBudget.SelectedText = "";
            this.txtBudget.Size = new System.Drawing.Size(100, 22);
            this.txtBudget.TabIndex = 7;
            this.txtBudget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // lblCost
            // 
            this.lblCost.Location = new System.Drawing.Point(20, 236);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(100, 16);
            this.lblCost.TabIndex = 8;
            this.lblCost.Text = "Actual Cost";
            // 
            // txtActualCost
            // 
            this.txtActualCost.BorderRadius = 5;
            this.txtActualCost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtActualCost.DefaultText = "";
            this.txtActualCost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtActualCost.Location = new System.Drawing.Point(20, 255);
            this.txtActualCost.Name = "txtActualCost";
            this.txtActualCost.PlaceholderText = "";
            this.txtActualCost.SelectedText = "";
            this.txtActualCost.Size = new System.Drawing.Size(100, 22);
            this.txtActualCost.TabIndex = 9;
            this.txtActualCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(157, 276);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 26);
            this.panel1.TabIndex = 15;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(384, 20);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Project Details";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 5;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(297, 276);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(382, 26);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 285);
            this.panel4.TabIndex = 22;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 309);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(382, 2);
            this.panel3.TabIndex = 23;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 26);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 283);
            this.panel5.TabIndex = 24;
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 311);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.lblBudget);
            this.Controls.Add(this.txtBudget);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.txtActualCost);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Details";
            this.Load += new System.EventHandler(this.ProjectForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        Guna2TextBox txtName, txtBudget, txtActualCost;
        DateTimePicker dtStart, dtEnd;
        Guna2Button btnSave;
        private Label lblName;
        private Label lblStart;
        private Label lblEnd;
        private Label lblBudget;
        private Label lblCost;
        private Panel panel1;
        private Label lblHeader;
        private Guna2Button btnClose;
        private Panel panel4;
        private Panel panel3;
        private Panel panel5;
    }
}