using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.Labor
{
    partial class LaborControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaborControl));
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvLabor = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnAssign = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdateHours = new Guna.UI2.WinForms.Guna2Button();
            this.btnProductivity = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.panelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabor)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1510, 40);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Labor && Workforce Management";
            // 
            // dgvLabor
            // 
            this.dgvLabor.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvLabor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLabor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLabor.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLabor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLabor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLabor.Location = new System.Drawing.Point(0, 40);
            this.dgvLabor.Name = "dgvLabor";
            this.dgvLabor.ReadOnly = true;
            this.dgvLabor.RowHeadersVisible = false;
            this.dgvLabor.Size = new System.Drawing.Size(1510, 514);
            this.dgvLabor.TabIndex = 0;
            this.dgvLabor.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLabor.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvLabor.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvLabor.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvLabor.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvLabor.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvLabor.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLabor.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvLabor.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLabor.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLabor.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvLabor.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLabor.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvLabor.ThemeStyle.ReadOnly = true;
            this.dgvLabor.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLabor.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLabor.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLabor.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvLabor.ThemeStyle.RowsStyle.Height = 22;
            this.dgvLabor.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLabor.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvLabor.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLabor_CellContentDoubleClick);
            // 
            // btnAssign
            // 
            this.btnAssign.BorderRadius = 5;
            this.btnAssign.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAssign.ForeColor = System.Drawing.Color.White;
            this.btnAssign.Location = new System.Drawing.Point(3, 3);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(125, 23);
            this.btnAssign.TabIndex = 0;
            this.btnAssign.Text = "Assign Workforce";
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnUpdateHours
            // 
            this.btnUpdateHours.BorderRadius = 5;
            this.btnUpdateHours.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpdateHours.ForeColor = System.Drawing.Color.White;
            this.btnUpdateHours.Location = new System.Drawing.Point(134, 3);
            this.btnUpdateHours.Name = "btnUpdateHours";
            this.btnUpdateHours.Size = new System.Drawing.Size(125, 23);
            this.btnUpdateHours.TabIndex = 1;
            this.btnUpdateHours.Text = "Update Hours";
            this.btnUpdateHours.Click += new System.EventHandler(this.btnUpdateHours_Click);
            // 
            // btnProductivity
            // 
            this.btnProductivity.BorderRadius = 5;
            this.btnProductivity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnProductivity.ForeColor = System.Drawing.Color.White;
            this.btnProductivity.Location = new System.Drawing.Point(265, 3);
            this.btnProductivity.Name = "btnProductivity";
            this.btnProductivity.Size = new System.Drawing.Size(125, 23);
            this.btnProductivity.TabIndex = 2;
            this.btnProductivity.Text = "Productivity";
            this.btnProductivity.Click += new System.EventHandler(this.btnProductivity_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 5;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(396, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(125, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnAssign);
            this.panelButtons.Controls.Add(this.btnUpdateHours);
            this.panelButtons.Controls.Add(this.btnProductivity);
            this.panelButtons.Controls.Add(this.btnRefresh);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 554);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1510, 30);
            this.panelButtons.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 5;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(527, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LaborControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1510, 584);
            this.Controls.Add(this.dgvLabor);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LaborControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LaborControl";
            this.Load += new System.EventHandler(this.LaborControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabor)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private Guna2DataGridView dgvLabor;
        private Guna2Button btnAssign;
        private Guna2Button btnUpdateHours;
        private Guna2Button btnProductivity;
        private Guna2Button btnRefresh;
        private FlowLayoutPanel panelButtons;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}