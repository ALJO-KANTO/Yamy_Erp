using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{
    partial class frmEngProjectDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Guna2GroupBox grpFilter;
        private Label lblProject;
        private Guna2ComboBox cmbProject;
        private Guna2Button btnRefresh;

        private Guna2GroupBox grpSummary;
        private Label lblProgress;
        private Label lblProgressValue;
        private Label lblBudget;
        private Label lblBudgetValue;
        private Label lblCost;
        private Label lblCostValue;
        private Label lblRevenue;
        private Label lblRevenueValue;

        private Guna2DataGridView dgvPhaseProgress;
        private Guna2DataGridView dgvMilestoneStatus;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpFilter = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.grpSummary = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblProgressValue = new System.Windows.Forms.Label();
            this.lblBudget = new System.Windows.Forms.Label();
            this.lblBudgetValue = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblCostValue = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.lblRevenueValue = new System.Windows.Forms.Label();
            this.dgvPhaseProgress = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvMilestoneStatus = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormName = new Guna.UI2.WinForms.Guna2Button();
            this.grpFilter.SuspendLayout();
            this.grpSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhaseProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMilestoneStatus)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFilter
            // 
            this.grpFilter.BorderRadius = 5;
            this.grpFilter.Controls.Add(this.lblProject);
            this.grpFilter.Controls.Add(this.cmbProject);
            this.grpFilter.Controls.Add(this.btnRefresh);
            this.grpFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grpFilter.Location = new System.Drawing.Point(20, 35);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(1140, 80);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Project Filter";
            // 
            // lblProject
            // 
            this.lblProject.BackColor = System.Drawing.Color.Transparent;
            this.lblProject.ForeColor = System.Drawing.Color.Black;
            this.lblProject.Location = new System.Drawing.Point(22, 46);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(54, 23);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "Project";
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
            this.cmbProject.IntegralHeight = false;
            this.cmbProject.ItemHeight = 22;
            this.cmbProject.Location = new System.Drawing.Point(80, 45);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(350, 28);
            this.cmbProject.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 5;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(460, 44);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 26);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpSummary
            // 
            this.grpSummary.BorderRadius = 5;
            this.grpSummary.Controls.Add(this.lblProgress);
            this.grpSummary.Controls.Add(this.lblProgressValue);
            this.grpSummary.Controls.Add(this.lblBudget);
            this.grpSummary.Controls.Add(this.lblBudgetValue);
            this.grpSummary.Controls.Add(this.lblCost);
            this.grpSummary.Controls.Add(this.lblCostValue);
            this.grpSummary.Controls.Add(this.lblRevenue);
            this.grpSummary.Controls.Add(this.lblRevenueValue);
            this.grpSummary.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grpSummary.Location = new System.Drawing.Point(20, 116);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(1140, 77);
            this.grpSummary.TabIndex = 1;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "Project Summary";
            // 
            // lblProgress
            // 
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.ForeColor = System.Drawing.Color.Black;
            this.lblProgress.Location = new System.Drawing.Point(20, 47);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(64, 23);
            this.lblProgress.TabIndex = 0;
            this.lblProgress.Text = "Progress:";
            // 
            // lblProgressValue
            // 
            this.lblProgressValue.BackColor = System.Drawing.Color.Transparent;
            this.lblProgressValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProgressValue.ForeColor = System.Drawing.Color.Black;
            this.lblProgressValue.Location = new System.Drawing.Point(90, 47);
            this.lblProgressValue.Name = "lblProgressValue";
            this.lblProgressValue.Size = new System.Drawing.Size(100, 23);
            this.lblProgressValue.TabIndex = 1;
            this.lblProgressValue.Text = "0 %";
            // 
            // lblBudget
            // 
            this.lblBudget.BackColor = System.Drawing.Color.Transparent;
            this.lblBudget.ForeColor = System.Drawing.Color.Black;
            this.lblBudget.Location = new System.Drawing.Point(220, 47);
            this.lblBudget.Name = "lblBudget";
            this.lblBudget.Size = new System.Drawing.Size(54, 23);
            this.lblBudget.TabIndex = 2;
            this.lblBudget.Text = "Budget:";
            // 
            // lblBudgetValue
            // 
            this.lblBudgetValue.BackColor = System.Drawing.Color.Transparent;
            this.lblBudgetValue.ForeColor = System.Drawing.Color.Black;
            this.lblBudgetValue.Location = new System.Drawing.Point(280, 47);
            this.lblBudgetValue.Name = "lblBudgetValue";
            this.lblBudgetValue.Size = new System.Drawing.Size(100, 23);
            this.lblBudgetValue.TabIndex = 3;
            this.lblBudgetValue.Text = "0.00";
            // 
            // lblCost
            // 
            this.lblCost.BackColor = System.Drawing.Color.Transparent;
            this.lblCost.ForeColor = System.Drawing.Color.Black;
            this.lblCost.Location = new System.Drawing.Point(420, 47);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(44, 23);
            this.lblCost.TabIndex = 4;
            this.lblCost.Text = "Cost:";
            // 
            // lblCostValue
            // 
            this.lblCostValue.BackColor = System.Drawing.Color.Transparent;
            this.lblCostValue.ForeColor = System.Drawing.Color.Black;
            this.lblCostValue.Location = new System.Drawing.Point(470, 47);
            this.lblCostValue.Name = "lblCostValue";
            this.lblCostValue.Size = new System.Drawing.Size(100, 23);
            this.lblCostValue.TabIndex = 5;
            this.lblCostValue.Text = "0.00";
            // 
            // lblRevenue
            // 
            this.lblRevenue.BackColor = System.Drawing.Color.Transparent;
            this.lblRevenue.ForeColor = System.Drawing.Color.Black;
            this.lblRevenue.Location = new System.Drawing.Point(620, 47);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(74, 23);
            this.lblRevenue.TabIndex = 6;
            this.lblRevenue.Text = "Revenue:";
            // 
            // lblRevenueValue
            // 
            this.lblRevenueValue.BackColor = System.Drawing.Color.Transparent;
            this.lblRevenueValue.ForeColor = System.Drawing.Color.Black;
            this.lblRevenueValue.Location = new System.Drawing.Point(700, 47);
            this.lblRevenueValue.Name = "lblRevenueValue";
            this.lblRevenueValue.Size = new System.Drawing.Size(100, 23);
            this.lblRevenueValue.TabIndex = 7;
            this.lblRevenueValue.Text = "0.00";
            // 
            // dgvPhaseProgress
            // 
            this.dgvPhaseProgress.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvPhaseProgress.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhaseProgress.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhaseProgress.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPhaseProgress.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhaseProgress.Location = new System.Drawing.Point(20, 200);
            this.dgvPhaseProgress.Name = "dgvPhaseProgress";
            this.dgvPhaseProgress.ReadOnly = true;
            this.dgvPhaseProgress.RowHeadersVisible = false;
            this.dgvPhaseProgress.Size = new System.Drawing.Size(550, 440);
            this.dgvPhaseProgress.TabIndex = 2;
            this.dgvPhaseProgress.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPhaseProgress.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvPhaseProgress.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvPhaseProgress.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvPhaseProgress.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvPhaseProgress.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvPhaseProgress.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhaseProgress.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvPhaseProgress.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPhaseProgress.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPhaseProgress.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPhaseProgress.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPhaseProgress.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvPhaseProgress.ThemeStyle.ReadOnly = true;
            this.dgvPhaseProgress.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPhaseProgress.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPhaseProgress.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPhaseProgress.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPhaseProgress.ThemeStyle.RowsStyle.Height = 22;
            this.dgvPhaseProgress.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhaseProgress.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dgvMilestoneStatus
            // 
            this.dgvMilestoneStatus.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvMilestoneStatus.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMilestoneStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMilestoneStatus.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMilestoneStatus.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvMilestoneStatus.Location = new System.Drawing.Point(610, 200);
            this.dgvMilestoneStatus.Name = "dgvMilestoneStatus";
            this.dgvMilestoneStatus.ReadOnly = true;
            this.dgvMilestoneStatus.RowHeadersVisible = false;
            this.dgvMilestoneStatus.Size = new System.Drawing.Size(550, 440);
            this.dgvMilestoneStatus.TabIndex = 3;
            this.dgvMilestoneStatus.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvMilestoneStatus.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvMilestoneStatus.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvMilestoneStatus.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvMilestoneStatus.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvMilestoneStatus.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvMilestoneStatus.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvMilestoneStatus.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvMilestoneStatus.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvMilestoneStatus.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMilestoneStatus.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMilestoneStatus.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMilestoneStatus.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvMilestoneStatus.ThemeStyle.ReadOnly = true;
            this.dgvMilestoneStatus.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvMilestoneStatus.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMilestoneStatus.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMilestoneStatus.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvMilestoneStatus.ThemeStyle.RowsStyle.Height = 22;
            this.dgvMilestoneStatus.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvMilestoneStatus.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.lblFormName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 31);
            this.panel1.TabIndex = 11;
            // 
            // lblFormName
            // 
            this.lblFormName.BackColor = System.Drawing.Color.Transparent;
            this.lblFormName.BorderColor = System.Drawing.Color.White;
            this.lblFormName.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.lblFormName.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.lblFormName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.lblFormName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.lblFormName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFormName.FillColor = System.Drawing.Color.Transparent;
            this.lblFormName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFormName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormName.ForeColor = System.Drawing.Color.White;
            this.lblFormName.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.lblFormName.Location = new System.Drawing.Point(0, 0);
            this.lblFormName.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(1184, 31);
            this.lblFormName.TabIndex = 4;
            this.lblFormName.Text = "Engineering Project Dashboard";
            // 
            // frmEngProjectDashboard
            // 
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.dgvPhaseProgress);
            this.Controls.Add(this.dgvMilestoneStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmEngProjectDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Engineering Project Dashboard";
            this.Load += new System.EventHandler(this.frmEngProjectDashboard_Load);
            this.grpFilter.ResumeLayout(false);
            this.grpSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhaseProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMilestoneStatus)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2Button lblFormName;
    }
}