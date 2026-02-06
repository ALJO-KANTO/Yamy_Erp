using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.Timesheet_Resources
{
    partial class frmEngTimesheetApproval
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblProject;
        private Guna2ComboBox cmbProject;
        private Label lblPhase;
        private Guna2ComboBox cmbPhase;
        private Label lblMilestone;
        private Guna2ComboBox cmbMilestone;
        private Guna2Button btnLoad;

        private Guna2DataGridView dgvTimesheets;
        private Guna2Button btnApprove;
        private Guna2Button btnReject;
        private Guna2Button btnRefresh;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblProject = new System.Windows.Forms.Label();
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPhase = new System.Windows.Forms.Label();
            this.cmbPhase = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblMilestone = new System.Windows.Forms.Label();
            this.cmbMilestone = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnLoad = new Guna.UI2.WinForms.Guna2Button();
            this.dgvTimesheets = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnApprove = new Guna.UI2.WinForms.Guna2Button();
            this.btnReject = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormName = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimesheets)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(20, 49);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(54, 23);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "Project:";
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
            this.cmbProject.Location = new System.Drawing.Point(80, 45);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(250, 28);
            this.cmbProject.TabIndex = 1;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // lblPhase
            // 
            this.lblPhase.Location = new System.Drawing.Point(350, 49);
            this.lblPhase.Name = "lblPhase";
            this.lblPhase.Size = new System.Drawing.Size(44, 23);
            this.lblPhase.TabIndex = 2;
            this.lblPhase.Text = "Phase:";
            // 
            // cmbPhase
            // 
            this.cmbPhase.BackColor = System.Drawing.Color.Transparent;
            this.cmbPhase.BorderRadius = 5;
            this.cmbPhase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPhase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhase.FocusedColor = System.Drawing.Color.Empty;
            this.cmbPhase.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPhase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbPhase.ItemHeight = 22;
            this.cmbPhase.Location = new System.Drawing.Point(400, 45);
            this.cmbPhase.Name = "cmbPhase";
            this.cmbPhase.Size = new System.Drawing.Size(200, 28);
            this.cmbPhase.TabIndex = 3;
            this.cmbPhase.SelectedIndexChanged += new System.EventHandler(this.cmbPhase_SelectedIndexChanged);
            // 
            // lblMilestone
            // 
            this.lblMilestone.Location = new System.Drawing.Point(620, 49);
            this.lblMilestone.Name = "lblMilestone";
            this.lblMilestone.Size = new System.Drawing.Size(57, 23);
            this.lblMilestone.TabIndex = 4;
            this.lblMilestone.Text = "Milestone:";
            // 
            // cmbMilestone
            // 
            this.cmbMilestone.BackColor = System.Drawing.Color.Transparent;
            this.cmbMilestone.BorderRadius = 5;
            this.cmbMilestone.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMilestone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMilestone.FocusedColor = System.Drawing.Color.Empty;
            this.cmbMilestone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMilestone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbMilestone.ItemHeight = 22;
            this.cmbMilestone.Location = new System.Drawing.Point(710, 45);
            this.cmbMilestone.Name = "cmbMilestone";
            this.cmbMilestone.Size = new System.Drawing.Size(200, 28);
            this.cmbMilestone.TabIndex = 5;
            this.cmbMilestone.SelectedIndexChanged += new System.EventHandler(this.cmbMilestone_SelectedIndexChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.BorderRadius = 5;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(940, 45);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(80, 25);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dgvTimesheets
            // 
            this.dgvTimesheets.AllowUserToAddRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            this.dgvTimesheets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTimesheets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTimesheets.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvTimesheets.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTimesheets.Location = new System.Drawing.Point(20, 89);
            this.dgvTimesheets.Name = "dgvTimesheets";
            this.dgvTimesheets.ReadOnly = true;
            this.dgvTimesheets.RowHeadersVisible = false;
            this.dgvTimesheets.Size = new System.Drawing.Size(1140, 420);
            this.dgvTimesheets.TabIndex = 7;
            this.dgvTimesheets.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTimesheets.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTimesheets.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTimesheets.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTimesheets.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTimesheets.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTimesheets.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTimesheets.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTimesheets.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTimesheets.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTimesheets.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTimesheets.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTimesheets.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvTimesheets.ThemeStyle.ReadOnly = true;
            this.dgvTimesheets.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTimesheets.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTimesheets.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTimesheets.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTimesheets.ThemeStyle.RowsStyle.Height = 22;
            this.dgvTimesheets.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTimesheets.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnApprove
            // 
            this.btnApprove.BorderRadius = 5;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(20, 525);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(100, 30);
            this.btnApprove.TabIndex = 8;
            this.btnApprove.Text = "Approve";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.BorderRadius = 5;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(140, 525);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(100, 30);
            this.btnReject.TabIndex = 9;
            this.btnReject.Text = "Reject";
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 5;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(260, 525);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 10;
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
            this.panel1.Size = new System.Drawing.Size(1184, 29);
            this.panel1.TabIndex = 16;
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
            this.lblFormName.Size = new System.Drawing.Size(1184, 29);
            this.lblFormName.TabIndex = 4;
            this.lblFormName.Text = "Timesheet Approval";
            // 
            // frmTimesheetApproval
            // 
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.lblPhase);
            this.Controls.Add(this.cmbPhase);
            this.Controls.Add(this.lblMilestone);
            this.Controls.Add(this.cmbMilestone);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dgvTimesheets);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnRefresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmTimesheetApproval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Timesheet Approval";
            this.Load += new System.EventHandler(this.frmTimesheetApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimesheets)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Guna2Button lblFormName;
    }
}