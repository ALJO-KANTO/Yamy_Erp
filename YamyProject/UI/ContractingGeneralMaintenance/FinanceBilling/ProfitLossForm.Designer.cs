using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.FinanceBilling
{
    partial class ProfitLossForm
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
            this.lblRev = new System.Windows.Forms.Label();
            this.txtRevenue = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtCost = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblProfit = new System.Windows.Forms.Label();
            this.txtProfit = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCalc = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblProj = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRev
            // 
            this.lblRev.Location = new System.Drawing.Point(20, 81);
            this.lblRev.Name = "lblRev";
            this.lblRev.Size = new System.Drawing.Size(100, 23);
            this.lblRev.TabIndex = 0;
            this.lblRev.Text = "Total Revenue";
            // 
            // txtRevenue
            // 
            this.txtRevenue.BorderRadius = 5;
            this.txtRevenue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRevenue.DefaultText = "";
            this.txtRevenue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRevenue.Location = new System.Drawing.Point(20, 96);
            this.txtRevenue.Name = "txtRevenue";
            this.txtRevenue.PlaceholderText = "";
            this.txtRevenue.SelectedText = "";
            this.txtRevenue.Size = new System.Drawing.Size(200, 30);
            this.txtRevenue.TabIndex = 1;
            // 
            // lblCost
            // 
            this.lblCost.Location = new System.Drawing.Point(20, 136);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(100, 23);
            this.lblCost.TabIndex = 2;
            this.lblCost.Text = "Total Cost";
            // 
            // txtCost
            // 
            this.txtCost.BorderRadius = 5;
            this.txtCost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCost.DefaultText = "";
            this.txtCost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCost.Location = new System.Drawing.Point(20, 151);
            this.txtCost.Name = "txtCost";
            this.txtCost.PlaceholderText = "";
            this.txtCost.SelectedText = "";
            this.txtCost.Size = new System.Drawing.Size(200, 30);
            this.txtCost.TabIndex = 3;
            // 
            // lblProfit
            // 
            this.lblProfit.Location = new System.Drawing.Point(20, 190);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.Size = new System.Drawing.Size(100, 23);
            this.lblProfit.TabIndex = 4;
            this.lblProfit.Text = "Net Profit";
            // 
            // txtProfit
            // 
            this.txtProfit.BorderRadius = 5;
            this.txtProfit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProfit.DefaultText = "";
            this.txtProfit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProfit.Location = new System.Drawing.Point(20, 204);
            this.txtProfit.Name = "txtProfit";
            this.txtProfit.PlaceholderText = "";
            this.txtProfit.ReadOnly = true;
            this.txtProfit.SelectedText = "";
            this.txtProfit.Size = new System.Drawing.Size(200, 30);
            this.txtProfit.TabIndex = 5;
            // 
            // btnCalc
            // 
            this.btnCalc.BorderRadius = 5;
            this.btnCalc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCalc.ForeColor = System.Drawing.Color.White;
            this.btnCalc.Location = new System.Drawing.Point(20, 248);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(81, 23);
            this.btnCalc.TabIndex = 6;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(215, 248);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(82, 23);
            this.guna2Button1.TabIndex = 7;
            this.guna2Button1.Text = "Close";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 26);
            this.panel1.TabIndex = 17;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(309, 20);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Project Profit && Loss";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 275);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(305, 2);
            this.panel3.TabIndex = 30;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(307, 26);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 251);
            this.panel4.TabIndex = 29;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 26);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 251);
            this.panel5.TabIndex = 28;
            // 
            // cmbProject
            // 
            this.cmbProject.BackColor = System.Drawing.Color.Transparent;
            this.cmbProject.BorderRadius = 5;
            this.cmbProject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FocusedColor = System.Drawing.Color.Empty;
            this.cmbProject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbProject.ItemHeight = 22;
            this.cmbProject.Location = new System.Drawing.Point(20, 47);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(282, 28);
            this.cmbProject.TabIndex = 32;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // lblProj
            // 
            this.lblProj.Location = new System.Drawing.Point(20, 31);
            this.lblProj.Name = "lblProj";
            this.lblProj.Size = new System.Drawing.Size(100, 23);
            this.lblProj.TabIndex = 31;
            this.lblProj.Text = "Project";
            // 
            // ProfitLossForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 277);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.lblProj);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.txtRevenue);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtProfit);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.lblRev);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblProfit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProfitLossForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Profit & Loss";
            this.Load += new System.EventHandler(this.ProfitLossForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        Guna2TextBox txtRevenue, txtCost, txtProfit;
        private Label lblRev;
        private Label lblCost;
        private Label lblProfit;
        private Guna2Button btnCalc;
        private Guna2Button guna2Button1;
        private Panel panel1;
        private Label lblHeader;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Guna2ComboBox cmbProject;
        private Label lblProj;
    }
}