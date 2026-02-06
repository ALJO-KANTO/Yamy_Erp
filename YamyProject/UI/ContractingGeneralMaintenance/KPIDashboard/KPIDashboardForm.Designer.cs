using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.KPIDashboard
{
    partial class KPIDashboardForm
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
            this.lblProject = new System.Windows.Forms.Label();
            this.lblFinance = new System.Windows.Forms.Label();
            this.lblMaintenance = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtProjectPerformance = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtFinancialPerformance = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMaintenancePerformance = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.txtHRPerformance = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProject
            // 
            this.lblProject.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblProject.Location = new System.Drawing.Point(20, 63);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(175, 23);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "Project Performance: ";
            this.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFinance
            // 
            this.lblFinance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFinance.Location = new System.Drawing.Point(20, 111);
            this.lblFinance.Name = "lblFinance";
            this.lblFinance.Size = new System.Drawing.Size(175, 23);
            this.lblFinance.TabIndex = 1;
            this.lblFinance.Text = "Financial Performance: ";
            this.lblFinance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMaintenance
            // 
            this.lblMaintenance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaintenance.Location = new System.Drawing.Point(20, 163);
            this.lblMaintenance.Name = "lblMaintenance";
            this.lblMaintenance.Size = new System.Drawing.Size(175, 23);
            this.lblMaintenance.TabIndex = 2;
            this.lblMaintenance.Text = "Maintenance Efficiency: ";
            this.lblMaintenance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.guna2ControlBox1);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 26);
            this.panel1.TabIndex = 15;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(449, 20);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Management KPI Dashboard";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 278);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(445, 2);
            this.panel3.TabIndex = 30;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(447, 26);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 254);
            this.panel4.TabIndex = 29;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 26);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 254);
            this.panel5.TabIndex = 28;
            // 
            // txtProjectPerformance
            // 
            this.txtProjectPerformance.BorderRadius = 5;
            this.txtProjectPerformance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProjectPerformance.DefaultText = "";
            this.txtProjectPerformance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProjectPerformance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProjectPerformance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProjectPerformance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProjectPerformance.Enabled = false;
            this.txtProjectPerformance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProjectPerformance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectPerformance.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProjectPerformance.Location = new System.Drawing.Point(214, 55);
            this.txtProjectPerformance.Name = "txtProjectPerformance";
            this.txtProjectPerformance.PlaceholderText = "";
            this.txtProjectPerformance.SelectedText = "";
            this.txtProjectPerformance.Size = new System.Drawing.Size(200, 36);
            this.txtProjectPerformance.TabIndex = 31;
            // 
            // txtFinancialPerformance
            // 
            this.txtFinancialPerformance.BorderRadius = 5;
            this.txtFinancialPerformance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFinancialPerformance.DefaultText = "";
            this.txtFinancialPerformance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFinancialPerformance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFinancialPerformance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFinancialPerformance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFinancialPerformance.Enabled = false;
            this.txtFinancialPerformance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFinancialPerformance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtFinancialPerformance.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFinancialPerformance.Location = new System.Drawing.Point(214, 106);
            this.txtFinancialPerformance.Name = "txtFinancialPerformance";
            this.txtFinancialPerformance.PlaceholderText = "";
            this.txtFinancialPerformance.SelectedText = "";
            this.txtFinancialPerformance.Size = new System.Drawing.Size(200, 36);
            this.txtFinancialPerformance.TabIndex = 32;
            // 
            // txtMaintenancePerformance
            // 
            this.txtMaintenancePerformance.BorderRadius = 5;
            this.txtMaintenancePerformance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaintenancePerformance.DefaultText = "";
            this.txtMaintenancePerformance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaintenancePerformance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaintenancePerformance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaintenancePerformance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaintenancePerformance.Enabled = false;
            this.txtMaintenancePerformance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaintenancePerformance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtMaintenancePerformance.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaintenancePerformance.Location = new System.Drawing.Point(214, 159);
            this.txtMaintenancePerformance.Name = "txtMaintenancePerformance";
            this.txtMaintenancePerformance.PlaceholderText = "";
            this.txtMaintenancePerformance.SelectedText = "";
            this.txtMaintenancePerformance.Size = new System.Drawing.Size(200, 36);
            this.txtMaintenancePerformance.TabIndex = 33;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(428, 2);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(19, 21);
            this.guna2ControlBox1.TabIndex = 1;
            // 
            // txtHRPerformance
            // 
            this.txtHRPerformance.BorderRadius = 5;
            this.txtHRPerformance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHRPerformance.DefaultText = "";
            this.txtHRPerformance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtHRPerformance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtHRPerformance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHRPerformance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHRPerformance.Enabled = false;
            this.txtHRPerformance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHRPerformance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtHRPerformance.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHRPerformance.Location = new System.Drawing.Point(214, 211);
            this.txtHRPerformance.Name = "txtHRPerformance";
            this.txtHRPerformance.PlaceholderText = "";
            this.txtHRPerformance.SelectedText = "";
            this.txtHRPerformance.Size = new System.Drawing.Size(200, 36);
            this.txtHRPerformance.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 23);
            this.label1.TabIndex = 34;
            this.label1.Text = "HR Performance: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // KPIDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 280);
            this.Controls.Add(this.txtHRPerformance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaintenancePerformance);
            this.Controls.Add(this.txtFinancialPerformance);
            this.Controls.Add(this.txtProjectPerformance);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.lblFinance);
            this.Controls.Add(this.lblMaintenance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KPIDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Management KPI Dashboard";
            this.Load += new System.EventHandler(this.KPIDashboardForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        Label lblProject, lblFinance, lblMaintenance;
        private Panel panel1;
        private Label lblHeader;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Guna.UI2.WinForms.Guna2TextBox txtProjectPerformance;
        private Guna.UI2.WinForms.Guna2TextBox txtFinancialPerformance;
        private Guna.UI2.WinForms.Guna2TextBox txtMaintenancePerformance;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtHRPerformance;
        private Label label1;
    }
}