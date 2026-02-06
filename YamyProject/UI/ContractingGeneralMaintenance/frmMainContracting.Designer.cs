using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace YamyProject.UI.Manufacturing
{
    partial class frmMainContracting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainContracting));
            this.panelSidebar = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnProjectManagement = new Guna.UI2.WinForms.Guna2Button();
            this.btnMaintenance = new Guna.UI2.WinForms.Guna2Button();
            this.btnJobOrders = new Guna.UI2.WinForms.Guna2Button();
            this.btnInventory = new Guna.UI2.WinForms.Guna2Button();
            this.btnProcurement = new Guna.UI2.WinForms.Guna2Button();
            this.btnEquipment = new Guna.UI2.WinForms.Guna2Button();
            this.btnLabor = new Guna.UI2.WinForms.Guna2Button();
            this.btnHRPayroll = new Guna.UI2.WinForms.Guna2Button();
            this.btnFinance = new Guna.UI2.WinForms.Guna2Button();
            this.btnCRM = new Guna.UI2.WinForms.Guna2Button();
            this.btnKPI = new Guna.UI2.WinForms.Guna2Button();
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2CircleButton2 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.LightGray;
            this.panelSidebar.Controls.Add(this.guna2CircleButton2);
            this.panelSidebar.Controls.Add(this.guna2HtmlLabel1);
            this.panelSidebar.Controls.Add(this.btnProjectManagement);
            this.panelSidebar.Controls.Add(this.btnMaintenance);
            this.panelSidebar.Controls.Add(this.btnJobOrders);
            this.panelSidebar.Controls.Add(this.btnInventory);
            this.panelSidebar.Controls.Add(this.btnProcurement);
            this.panelSidebar.Controls.Add(this.btnEquipment);
            this.panelSidebar.Controls.Add(this.btnLabor);
            this.panelSidebar.Controls.Add(this.btnHRPayroll);
            this.panelSidebar.Controls.Add(this.btnFinance);
            this.panelSidebar.Controls.Add(this.btnCRM);
            this.panelSidebar.Controls.Add(this.btnKPI);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(41)))), ((int)(((byte)(83)))));
            this.panelSidebar.FillColor2 = System.Drawing.Color.DarkCyan;
            this.panelSidebar.Location = new System.Drawing.Point(5, 5);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(200, 690);
            this.panelSidebar.TabIndex = 1;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(10, 518);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(168, 78);
            this.guna2HtmlLabel1.TabIndex = 11;
            this.guna2HtmlLabel1.Text = "Contracting & General Maintenance ERP";
            this.guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnProjectManagement
            // 
            this.btnProjectManagement.BackColor = System.Drawing.Color.Transparent;
            this.btnProjectManagement.BorderRadius = 10;
            this.btnProjectManagement.FillColor = System.Drawing.Color.SteelBlue;
            this.btnProjectManagement.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProjectManagement.ForeColor = System.Drawing.Color.White;
            this.btnProjectManagement.Location = new System.Drawing.Point(10, 10);
            this.btnProjectManagement.Name = "btnProjectManagement";
            this.btnProjectManagement.Size = new System.Drawing.Size(180, 40);
            this.btnProjectManagement.TabIndex = 0;
            this.btnProjectManagement.Text = "Project Management";
            this.btnProjectManagement.Click += new System.EventHandler(this.ModuleButton_Click);
            // 
            // btnMaintenance
            // 
            this.btnMaintenance.BackColor = System.Drawing.Color.Transparent;
            this.btnMaintenance.BorderRadius = 10;
            this.btnMaintenance.FillColor = System.Drawing.Color.SteelBlue;
            this.btnMaintenance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaintenance.ForeColor = System.Drawing.Color.White;
            this.btnMaintenance.Location = new System.Drawing.Point(10, 55);
            this.btnMaintenance.Name = "btnMaintenance";
            this.btnMaintenance.Size = new System.Drawing.Size(180, 40);
            this.btnMaintenance.TabIndex = 1;
            this.btnMaintenance.Text = "Maintenance";
            this.btnMaintenance.Click += new System.EventHandler(this.ModuleButton_Click);
            // 
            // btnJobOrders
            // 
            this.btnJobOrders.BackColor = System.Drawing.Color.Transparent;
            this.btnJobOrders.BorderRadius = 10;
            this.btnJobOrders.FillColor = System.Drawing.Color.SteelBlue;
            this.btnJobOrders.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobOrders.ForeColor = System.Drawing.Color.White;
            this.btnJobOrders.Location = new System.Drawing.Point(10, 100);
            this.btnJobOrders.Name = "btnJobOrders";
            this.btnJobOrders.Size = new System.Drawing.Size(180, 40);
            this.btnJobOrders.TabIndex = 2;
            this.btnJobOrders.Text = "Job/Work Orders";
            this.btnJobOrders.Click += new System.EventHandler(this.ModuleButton_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.Color.Transparent;
            this.btnInventory.BorderRadius = 10;
            this.btnInventory.FillColor = System.Drawing.Color.SteelBlue;
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.ForeColor = System.Drawing.Color.White;
            this.btnInventory.Location = new System.Drawing.Point(10, 145);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(180, 40);
            this.btnInventory.TabIndex = 3;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.Click += new System.EventHandler(this.ModuleButton_Click);
            // 
            // btnProcurement
            // 
            this.btnProcurement.BackColor = System.Drawing.Color.Transparent;
            this.btnProcurement.BorderRadius = 10;
            this.btnProcurement.FillColor = System.Drawing.Color.SteelBlue;
            this.btnProcurement.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcurement.ForeColor = System.Drawing.Color.White;
            this.btnProcurement.Location = new System.Drawing.Point(10, 190);
            this.btnProcurement.Name = "btnProcurement";
            this.btnProcurement.Size = new System.Drawing.Size(180, 40);
            this.btnProcurement.TabIndex = 4;
            this.btnProcurement.Text = "Procurement";
            this.btnProcurement.Click += new System.EventHandler(this.ModuleButton_Click);
            // 
            // btnEquipment
            // 
            this.btnEquipment.BackColor = System.Drawing.Color.Transparent;
            this.btnEquipment.BorderRadius = 10;
            this.btnEquipment.FillColor = System.Drawing.Color.SteelBlue;
            this.btnEquipment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEquipment.ForeColor = System.Drawing.Color.White;
            this.btnEquipment.Location = new System.Drawing.Point(10, 235);
            this.btnEquipment.Name = "btnEquipment";
            this.btnEquipment.Size = new System.Drawing.Size(180, 40);
            this.btnEquipment.TabIndex = 5;
            this.btnEquipment.Text = "Equipment";
            this.btnEquipment.Click += new System.EventHandler(this.ModuleButton_Click);
            // 
            // btnLabor
            // 
            this.btnLabor.BackColor = System.Drawing.Color.Transparent;
            this.btnLabor.BorderRadius = 10;
            this.btnLabor.FillColor = System.Drawing.Color.SteelBlue;
            this.btnLabor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLabor.ForeColor = System.Drawing.Color.White;
            this.btnLabor.Location = new System.Drawing.Point(10, 280);
            this.btnLabor.Name = "btnLabor";
            this.btnLabor.Size = new System.Drawing.Size(180, 40);
            this.btnLabor.TabIndex = 6;
            this.btnLabor.Text = "Labor";
            this.btnLabor.Click += new System.EventHandler(this.ModuleButton_Click);
            // 
            // btnHRPayroll
            // 
            this.btnHRPayroll.BackColor = System.Drawing.Color.Transparent;
            this.btnHRPayroll.BorderRadius = 10;
            this.btnHRPayroll.FillColor = System.Drawing.Color.SteelBlue;
            this.btnHRPayroll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHRPayroll.ForeColor = System.Drawing.Color.White;
            this.btnHRPayroll.Location = new System.Drawing.Point(10, 325);
            this.btnHRPayroll.Name = "btnHRPayroll";
            this.btnHRPayroll.Size = new System.Drawing.Size(180, 40);
            this.btnHRPayroll.TabIndex = 7;
            this.btnHRPayroll.Text = "HR && Payroll";
            this.btnHRPayroll.Click += new System.EventHandler(this.ModuleButton_Click);
            // 
            // btnFinance
            // 
            this.btnFinance.BackColor = System.Drawing.Color.Transparent;
            this.btnFinance.BorderRadius = 10;
            this.btnFinance.FillColor = System.Drawing.Color.SteelBlue;
            this.btnFinance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinance.ForeColor = System.Drawing.Color.White;
            this.btnFinance.Location = new System.Drawing.Point(10, 370);
            this.btnFinance.Name = "btnFinance";
            this.btnFinance.Size = new System.Drawing.Size(180, 40);
            this.btnFinance.TabIndex = 8;
            this.btnFinance.Text = "Finance && Billing";
            this.btnFinance.Click += new System.EventHandler(this.ModuleButton_Click);
            // 
            // btnCRM
            // 
            this.btnCRM.BackColor = System.Drawing.Color.Transparent;
            this.btnCRM.BorderRadius = 10;
            this.btnCRM.FillColor = System.Drawing.Color.SteelBlue;
            this.btnCRM.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCRM.ForeColor = System.Drawing.Color.White;
            this.btnCRM.Location = new System.Drawing.Point(10, 415);
            this.btnCRM.Name = "btnCRM";
            this.btnCRM.Size = new System.Drawing.Size(180, 40);
            this.btnCRM.TabIndex = 9;
            this.btnCRM.Text = "CRM";
            this.btnCRM.Click += new System.EventHandler(this.ModuleButton_Click);
            // 
            // btnKPI
            // 
            this.btnKPI.BackColor = System.Drawing.Color.Transparent;
            this.btnKPI.BorderRadius = 10;
            this.btnKPI.FillColor = System.Drawing.Color.SteelBlue;
            this.btnKPI.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKPI.ForeColor = System.Drawing.Color.White;
            this.btnKPI.Location = new System.Drawing.Point(10, 460);
            this.btnKPI.Name = "btnKPI";
            this.btnKPI.Size = new System.Drawing.Size(180, 40);
            this.btnKPI.TabIndex = 10;
            this.btnKPI.Text = "KPI Dashboard";
            this.btnKPI.Click += new System.EventHandler(this.ModuleButton_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(205, 5);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(990, 690);
            this.panelMain.TabIndex = 0;
            // 
            // guna2CircleButton2
            // 
            this.guna2CircleButton2.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2CircleButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton2.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton2.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton2.Image = global::YamyProject.Properties.Resources.loginN;
            this.guna2CircleButton2.ImageSize = new System.Drawing.Size(25, 25);
            this.guna2CircleButton2.Location = new System.Drawing.Point(87, 602);
            this.guna2CircleButton2.Name = "guna2CircleButton2";
            this.guna2CircleButton2.PressedDepth = 0;
            this.guna2CircleButton2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton2.Size = new System.Drawing.Size(25, 25);
            this.guna2CircleButton2.TabIndex = 14;
            this.guna2CircleButton2.Tag = "Log Out";
            this.guna2CircleButton2.Click += new System.EventHandler(this.guna2CircleButton2_Click);
            // 
            // frmMainContracting
            // 
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainContracting";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contracting & General Maintenance ERP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna2GradientPanel panelSidebar;
        private Guna2Panel panelMain;
        private Guna2Button btnProjectManagement;
        private Guna2Button btnMaintenance;
        private Guna2Button btnJobOrders;
        private Guna2Button btnInventory;
        private Guna2Button btnProcurement;
        private Guna2Button btnEquipment;
        private Guna2Button btnLabor;
        private Guna2Button btnHRPayroll;
        private Guna2Button btnFinance;
        private Guna2Button btnCRM;
        private Guna2Button btnKPI;
        private Guna2HtmlLabel guna2HtmlLabel1;
        private Guna2CircleButton guna2CircleButton2;
    }
}