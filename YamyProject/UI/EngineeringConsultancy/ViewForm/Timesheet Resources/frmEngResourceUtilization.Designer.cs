using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.Timesheet_Resources
{
    partial class frmEngResourceUtilization
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

        private Guna2DataGridView dgvUtilization;

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
            this.lblProject = new System.Windows.Forms.Label();
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPhase = new System.Windows.Forms.Label();
            this.cmbPhase = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblMilestone = new System.Windows.Forms.Label();
            this.cmbMilestone = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnLoad = new Guna.UI2.WinForms.Guna2Button();
            this.dgvUtilization = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormName = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUtilization)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(20, 54);
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
            this.cmbProject.Location = new System.Drawing.Point(80, 50);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(250, 28);
            this.cmbProject.TabIndex = 1;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // lblPhase
            // 
            this.lblPhase.Location = new System.Drawing.Point(350, 54);
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
            this.cmbPhase.Location = new System.Drawing.Point(400, 50);
            this.cmbPhase.Name = "cmbPhase";
            this.cmbPhase.Size = new System.Drawing.Size(200, 28);
            this.cmbPhase.TabIndex = 3;
            this.cmbPhase.SelectedIndexChanged += new System.EventHandler(this.cmbPhase_SelectedIndexChanged);
            // 
            // lblMilestone
            // 
            this.lblMilestone.Location = new System.Drawing.Point(620, 54);
            this.lblMilestone.Name = "lblMilestone";
            this.lblMilestone.Size = new System.Drawing.Size(61, 23);
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
            this.cmbMilestone.Location = new System.Drawing.Point(687, 50);
            this.cmbMilestone.Name = "cmbMilestone";
            this.cmbMilestone.Size = new System.Drawing.Size(223, 28);
            this.cmbMilestone.TabIndex = 5;
            this.cmbMilestone.SelectedIndexChanged += new System.EventHandler(this.cmbMilestone_SelectedIndexChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.BorderRadius = 5;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(940, 50);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(80, 25);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dgvUtilization
            // 
            this.dgvUtilization.AllowUserToAddRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            this.dgvUtilization.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUtilization.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUtilization.DefaultCellStyle = dataGridViewCellStyle21;
            this.dgvUtilization.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvUtilization.Location = new System.Drawing.Point(20, 89);
            this.dgvUtilization.Name = "dgvUtilization";
            this.dgvUtilization.ReadOnly = true;
            this.dgvUtilization.RowHeadersVisible = false;
            this.dgvUtilization.Size = new System.Drawing.Size(1140, 451);
            this.dgvUtilization.TabIndex = 7;
            this.dgvUtilization.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvUtilization.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvUtilization.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvUtilization.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvUtilization.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvUtilization.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvUtilization.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvUtilization.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvUtilization.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvUtilization.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUtilization.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvUtilization.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUtilization.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvUtilization.ThemeStyle.ReadOnly = true;
            this.dgvUtilization.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvUtilization.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUtilization.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUtilization.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvUtilization.ThemeStyle.RowsStyle.Height = 22;
            this.dgvUtilization.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvUtilization.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.lblFormName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 29);
            this.panel1.TabIndex = 17;
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
            this.lblFormName.Text = "Resource Utilization";
            // 
            // frmResourceUtilization
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
            this.Controls.Add(this.dgvUtilization);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmResourceUtilization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resource Utilization";
            this.Load += new System.EventHandler(this.frmResourceUtilization_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUtilization)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Guna2Button lblFormName;
    }
}