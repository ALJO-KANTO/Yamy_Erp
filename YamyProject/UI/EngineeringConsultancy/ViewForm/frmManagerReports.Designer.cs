namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{
    partial class frmManagerReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabMain;

        private System.Windows.Forms.DataGridView dgvProjects;
        private System.Windows.Forms.DataGridView dgvPhases;
        private System.Windows.Forms.DataGridView dgvEngineers;
        private System.Windows.Forms.DataGridView dgvFiles;

        private System.Windows.Forms.Label lblSummary;

        private System.Windows.Forms.TabPage tabProjects;
        private System.Windows.Forms.TabPage tabPhases;
        private System.Windows.Forms.TabPage tabEngineers;
        private System.Windows.Forms.TabPage tabApprovals;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabProjects = new System.Windows.Forms.TabPage();
            this.dgvProjects = new System.Windows.Forms.DataGridView();
            this.tabPhases = new System.Windows.Forms.TabPage();
            this.dgvPhases = new System.Windows.Forms.DataGridView();
            this.tabEngineers = new System.Windows.Forms.TabPage();
            this.dgvEngineers = new System.Windows.Forms.DataGridView();
            this.tabApprovals = new System.Windows.Forms.TabPage();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.lblSummary = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnMaximize = new Guna.UI2.WinForms.Guna2Button();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.lblFormName = new Guna.UI2.WinForms.Guna2Button();
            this.tabMain.SuspendLayout();
            this.tabProjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).BeginInit();
            this.tabPhases.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhases)).BeginInit();
            this.tabEngineers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEngineers)).BeginInit();
            this.tabApprovals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabProjects);
            this.tabMain.Controls.Add(this.tabPhases);
            this.tabMain.Controls.Add(this.tabEngineers);
            this.tabMain.Controls.Add(this.tabApprovals);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 34);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1200, 636);
            this.tabMain.TabIndex = 0;
            // 
            // tabProjects
            // 
            this.tabProjects.Controls.Add(this.dgvProjects);
            this.tabProjects.Location = new System.Drawing.Point(4, 22);
            this.tabProjects.Name = "tabProjects";
            this.tabProjects.Size = new System.Drawing.Size(1192, 610);
            this.tabProjects.TabIndex = 0;
            this.tabProjects.Text = "Projects";
            // 
            // dgvProjects
            // 
            this.dgvProjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProjects.BackgroundColor = System.Drawing.Color.White;
            this.dgvProjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProjects.Location = new System.Drawing.Point(0, 0);
            this.dgvProjects.Name = "dgvProjects";
            this.dgvProjects.ReadOnly = true;
            this.dgvProjects.RowHeadersVisible = false;
            this.dgvProjects.Size = new System.Drawing.Size(1192, 610);
            this.dgvProjects.TabIndex = 0;
            // 
            // tabPhases
            // 
            this.tabPhases.Controls.Add(this.dgvPhases);
            this.tabPhases.Location = new System.Drawing.Point(4, 22);
            this.tabPhases.Name = "tabPhases";
            this.tabPhases.Size = new System.Drawing.Size(1192, 610);
            this.tabPhases.TabIndex = 1;
            this.tabPhases.Text = "Phases";
            // 
            // dgvPhases
            // 
            this.dgvPhases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhases.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhases.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPhases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhases.Location = new System.Drawing.Point(0, 0);
            this.dgvPhases.Name = "dgvPhases";
            this.dgvPhases.ReadOnly = true;
            this.dgvPhases.RowHeadersVisible = false;
            this.dgvPhases.Size = new System.Drawing.Size(1192, 610);
            this.dgvPhases.TabIndex = 0;
            // 
            // tabEngineers
            // 
            this.tabEngineers.Controls.Add(this.dgvEngineers);
            this.tabEngineers.Location = new System.Drawing.Point(4, 22);
            this.tabEngineers.Name = "tabEngineers";
            this.tabEngineers.Size = new System.Drawing.Size(1192, 610);
            this.tabEngineers.TabIndex = 2;
            this.tabEngineers.Text = "Engineers";
            // 
            // dgvEngineers
            // 
            this.dgvEngineers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEngineers.BackgroundColor = System.Drawing.Color.White;
            this.dgvEngineers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEngineers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEngineers.Location = new System.Drawing.Point(0, 0);
            this.dgvEngineers.Name = "dgvEngineers";
            this.dgvEngineers.ReadOnly = true;
            this.dgvEngineers.RowHeadersVisible = false;
            this.dgvEngineers.Size = new System.Drawing.Size(1192, 610);
            this.dgvEngineers.TabIndex = 0;
            // 
            // tabApprovals
            // 
            this.tabApprovals.Controls.Add(this.dgvFiles);
            this.tabApprovals.Location = new System.Drawing.Point(4, 22);
            this.tabApprovals.Name = "tabApprovals";
            this.tabApprovals.Size = new System.Drawing.Size(1192, 610);
            this.tabApprovals.TabIndex = 3;
            this.tabApprovals.Text = "Approvals";
            // 
            // dgvFiles
            // 
            this.dgvFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFiles.BackgroundColor = System.Drawing.Color.White;
            this.dgvFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFiles.Location = new System.Drawing.Point(0, 0);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.ReadOnly = true;
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.Size = new System.Drawing.Size(1192, 610);
            this.dgvFiles.TabIndex = 0;
            // 
            // lblSummary
            // 
            this.lblSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSummary.Location = new System.Drawing.Point(0, 670);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(1200, 30);
            this.lblSummary.TabIndex = 1;
            this.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(41)))), ((int)(((byte)(83)))));
            this.panel7.Controls.Add(this.btnMaximize);
            this.panel7.Controls.Add(this.btnMinimize);
            this.panel7.Controls.Add(this.btnClose);
            this.panel7.Controls.Add(this.lblFormName);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1200, 34);
            this.panel7.TabIndex = 11;
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximize.BorderColor = System.Drawing.Color.White;
            this.btnMaximize.BorderRadius = 5;
            this.btnMaximize.BorderThickness = 1;
            this.btnMaximize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMaximize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMaximize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMaximize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMaximize.FillColor = System.Drawing.Color.Transparent;
            this.btnMaximize.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaximize.ForeColor = System.Drawing.Color.White;
            this.btnMaximize.Image = global::YamyProject.Properties.Resources.maximizeN;
            this.btnMaximize.ImageSize = new System.Drawing.Size(60, 60);
            this.btnMaximize.Location = new System.Drawing.Point(1135, 4);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(27, 26);
            this.btnMaximize.TabIndex = 5;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BorderColor = System.Drawing.Color.White;
            this.btnMinimize.BorderRadius = 5;
            this.btnMinimize.BorderThickness = 1;
            this.btnMinimize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMinimize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMinimize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMinimize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Image = global::YamyProject.Properties.Resources.minimizeN;
            this.btnMinimize.ImageSize = new System.Drawing.Size(60, 60);
            this.btnMinimize.Location = new System.Drawing.Point(1100, 4);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(27, 26);
            this.btnMinimize.TabIndex = 6;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderColor = System.Drawing.Color.White;
            this.btnClose.BorderRadius = 5;
            this.btnClose.BorderThickness = 1;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::YamyProject.Properties.Resources.closeN;
            this.btnClose.ImageSize = new System.Drawing.Size(60, 60);
            this.btnClose.Location = new System.Drawing.Point(1170, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(27, 26);
            this.btnClose.TabIndex = 7;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.lblFormName.Size = new System.Drawing.Size(1200, 34);
            this.lblFormName.TabIndex = 4;
            this.lblFormName.Text = "Manager Reports";
            // 
            // frmManagerReports
            // 
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.panel7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManagerReports";
            this.Text = "Manager Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmManagerReports_Load);
            this.tabMain.ResumeLayout(false);
            this.tabProjects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).EndInit();
            this.tabPhases.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhases)).EndInit();
            this.tabEngineers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEngineers)).EndInit();
            this.tabApprovals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel7;
        private Guna.UI2.WinForms.Guna2Button btnMaximize;
        private Guna.UI2.WinForms.Guna2Button btnMinimize;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button lblFormName;
    }
}