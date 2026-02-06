using Guna.UI2.WinForms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.KPIs
{
    partial class frmEngExecutiveDashboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblAvgKPI = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblProfit = new System.Windows.Forms.Label();
            this.dgvKPITrend = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvTopEngineers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvBottomEngineers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormName = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKPITrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopEngineers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBottomEngineers)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbYear
            // 
            this.cmbYear.BackColor = System.Drawing.Color.Transparent;
            this.cmbYear.BorderRadius = 5;
            this.cmbYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FocusedColor = System.Drawing.Color.Empty;
            this.cmbYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbYear.ItemHeight = 22;
            this.cmbYear.Location = new System.Drawing.Point(20, 45);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(120, 28);
            this.cmbYear.TabIndex = 0;
            // 
            // lblAvgKPI
            // 
            this.lblAvgKPI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAvgKPI.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAvgKPI.Location = new System.Drawing.Point(20, 90);
            this.lblAvgKPI.Name = "lblAvgKPI";
            this.lblAvgKPI.Size = new System.Drawing.Size(230, 60);
            this.lblAvgKPI.TabIndex = 2;
            this.lblAvgKPI.Text = "Avg KPI\n0%";
            this.lblAvgKPI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRevenue
            // 
            this.lblRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRevenue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRevenue.Location = new System.Drawing.Point(270, 90);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(230, 60);
            this.lblRevenue.TabIndex = 3;
            this.lblRevenue.Text = "Revenue\n0.00";
            this.lblRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCost
            // 
            this.lblCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCost.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCost.Location = new System.Drawing.Point(520, 90);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(230, 60);
            this.lblCost.TabIndex = 4;
            this.lblCost.Text = "Cost\n0.00";
            this.lblCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProfit
            // 
            this.lblProfit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProfit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProfit.Location = new System.Drawing.Point(770, 90);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.Size = new System.Drawing.Size(230, 60);
            this.lblProfit.TabIndex = 5;
            this.lblProfit.Text = "Profit\n0.00";
            this.lblProfit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvKPITrend
            // 
            this.dgvKPITrend.AllowUserToAddRows = false;
            this.dgvKPITrend.AllowUserToDeleteRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            this.dgvKPITrend.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKPITrend.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvKPITrend.ColumnHeadersHeight = 35;
            this.dgvKPITrend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKPITrend.DefaultCellStyle = dataGridViewCellStyle21;
            this.dgvKPITrend.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKPITrend.Location = new System.Drawing.Point(20, 170);
            this.dgvKPITrend.Name = "dgvKPITrend";
            this.dgvKPITrend.ReadOnly = true;
            this.dgvKPITrend.RowHeadersVisible = false;
            this.dgvKPITrend.Size = new System.Drawing.Size(980, 180);
            this.dgvKPITrend.TabIndex = 6;
            this.dgvKPITrend.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvKPITrend.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvKPITrend.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvKPITrend.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvKPITrend.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvKPITrend.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvKPITrend.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKPITrend.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvKPITrend.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvKPITrend.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvKPITrend.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvKPITrend.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvKPITrend.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvKPITrend.ThemeStyle.ReadOnly = true;
            this.dgvKPITrend.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvKPITrend.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKPITrend.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvKPITrend.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvKPITrend.ThemeStyle.RowsStyle.Height = 22;
            this.dgvKPITrend.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKPITrend.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dgvTopEngineers
            // 
            this.dgvTopEngineers.AllowUserToAddRows = false;
            this.dgvTopEngineers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.White;
            this.dgvTopEngineers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTopEngineers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dgvTopEngineers.ColumnHeadersHeight = 35;
            this.dgvTopEngineers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTopEngineers.DefaultCellStyle = dataGridViewCellStyle24;
            this.dgvTopEngineers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTopEngineers.Location = new System.Drawing.Point(20, 365);
            this.dgvTopEngineers.Name = "dgvTopEngineers";
            this.dgvTopEngineers.ReadOnly = true;
            this.dgvTopEngineers.RowHeadersVisible = false;
            this.dgvTopEngineers.Size = new System.Drawing.Size(480, 200);
            this.dgvTopEngineers.TabIndex = 7;
            this.dgvTopEngineers.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTopEngineers.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTopEngineers.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTopEngineers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTopEngineers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTopEngineers.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTopEngineers.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTopEngineers.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTopEngineers.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTopEngineers.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvTopEngineers.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTopEngineers.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTopEngineers.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvTopEngineers.ThemeStyle.ReadOnly = true;
            this.dgvTopEngineers.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTopEngineers.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTopEngineers.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvTopEngineers.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTopEngineers.ThemeStyle.RowsStyle.Height = 22;
            this.dgvTopEngineers.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTopEngineers.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dgvBottomEngineers
            // 
            this.dgvBottomEngineers.AllowUserToAddRows = false;
            this.dgvBottomEngineers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.White;
            this.dgvBottomEngineers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBottomEngineers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dgvBottomEngineers.ColumnHeadersHeight = 35;
            this.dgvBottomEngineers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBottomEngineers.DefaultCellStyle = dataGridViewCellStyle27;
            this.dgvBottomEngineers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBottomEngineers.Location = new System.Drawing.Point(520, 365);
            this.dgvBottomEngineers.Name = "dgvBottomEngineers";
            this.dgvBottomEngineers.ReadOnly = true;
            this.dgvBottomEngineers.RowHeadersVisible = false;
            this.dgvBottomEngineers.Size = new System.Drawing.Size(480, 200);
            this.dgvBottomEngineers.TabIndex = 8;
            this.dgvBottomEngineers.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBottomEngineers.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBottomEngineers.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBottomEngineers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvBottomEngineers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBottomEngineers.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBottomEngineers.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBottomEngineers.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvBottomEngineers.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBottomEngineers.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvBottomEngineers.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBottomEngineers.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvBottomEngineers.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvBottomEngineers.ThemeStyle.ReadOnly = true;
            this.dgvBottomEngineers.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBottomEngineers.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBottomEngineers.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvBottomEngineers.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBottomEngineers.ThemeStyle.RowsStyle.Height = 22;
            this.dgvBottomEngineers.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBottomEngineers.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 5;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(160, 45);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 28);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.lblFormName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 29);
            this.panel1.TabIndex = 20;
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
            this.lblFormName.Size = new System.Drawing.Size(1024, 29);
            this.lblFormName.TabIndex = 4;
            this.lblFormName.Text = "Engineering Executive Dashboard";
            // 
            // frmEngExecutiveDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 570);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblAvgKPI);
            this.Controls.Add(this.lblRevenue);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblProfit);
            this.Controls.Add(this.dgvKPITrend);
            this.Controls.Add(this.dgvTopEngineers);
            this.Controls.Add(this.dgvBottomEngineers);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEngExecutiveDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Engineering Executive Dashboard";
            this.Load += new System.EventHandler(this.frmEngExecutiveDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKPITrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopEngineers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBottomEngineers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna2ComboBox cmbYear;
        private System.Windows.Forms.Label lblAvgKPI;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblProfit;

        private Guna2DataGridView dgvKPITrend;
        private Guna2DataGridView dgvTopEngineers;
        private Guna2DataGridView dgvBottomEngineers;

        private Guna2Button btnRefresh;
        private System.Windows.Forms.Panel panel1;
        private Guna2Button lblFormName;
    }
}