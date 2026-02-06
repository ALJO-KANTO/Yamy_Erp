using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.KPIs
{
    partial class frmEngBonusSimulation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.cmbMonth = new Guna.UI2.WinForms.Guna2ComboBox();
            this.numBasePercent = new System.Windows.Forms.NumericUpDown();
            this.dgvBonusSim = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnSimulate = new Guna.UI2.WinForms.Guna2Button();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblBasePercent = new System.Windows.Forms.Label();
            this.lblResults = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormName = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasePercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusSim)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numYear
            //
            this.numYear.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numYear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numYear.Location = new System.Drawing.Point(70, 45);
            this.numYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(90, 28);
            this.numYear.TabIndex = 1;
            this.numYear.Value = new decimal(new int[] {
            2026,
            0,
            0,
            0});
            // 
            // cmbMonth
            // 
            this.cmbMonth.BackColor = System.Drawing.Color.Transparent;
            this.cmbMonth.BorderRadius = 5;
            this.cmbMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FocusedColor = System.Drawing.Color.Empty;
            this.cmbMonth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbMonth.ItemHeight = 22;
            this.cmbMonth.Location = new System.Drawing.Point(235, 45);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(140, 28);
            this.cmbMonth.TabIndex = 3;
            // 
            // numBasePercent
            // 
            this.numBasePercent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numBasePercent.DecimalPlaces = 2;
            this.numBasePercent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numBasePercent.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.numBasePercent.Location = new System.Drawing.Point(510, 45);
            this.numBasePercent.Name = "numBasePercent";
            this.numBasePercent.Size = new System.Drawing.Size(90, 23);
            this.numBasePercent.TabIndex = 5;
            this.numBasePercent.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // dgvBonusSim
            // 
            this.dgvBonusSim.AllowUserToAddRows = false;
            this.dgvBonusSim.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvBonusSim.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBonusSim.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBonusSim.ColumnHeadersHeight = 35;
            this.dgvBonusSim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBonusSim.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBonusSim.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBonusSim.Location = new System.Drawing.Point(20, 104);
            this.dgvBonusSim.Name = "dgvBonusSim";
            this.dgvBonusSim.ReadOnly = true;
            this.dgvBonusSim.RowHeadersVisible = false;
            this.dgvBonusSim.Size = new System.Drawing.Size(900, 420);
            this.dgvBonusSim.TabIndex = 9;
            this.dgvBonusSim.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBonusSim.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBonusSim.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBonusSim.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvBonusSim.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBonusSim.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBonusSim.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBonusSim.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvBonusSim.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBonusSim.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvBonusSim.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBonusSim.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvBonusSim.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvBonusSim.ThemeStyle.ReadOnly = true;
            this.dgvBonusSim.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBonusSim.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBonusSim.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvBonusSim.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBonusSim.ThemeStyle.RowsStyle.Height = 22;
            this.dgvBonusSim.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBonusSim.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnSimulate
            // 
            this.btnSimulate.BorderRadius = 5;
            this.btnSimulate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSimulate.ForeColor = System.Drawing.Color.White;
            this.btnSimulate.Location = new System.Drawing.Point(620, 44);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(95, 29);
            this.btnSimulate.TabIndex = 6;
            this.btnSimulate.Text = "Simulate";
            this.btnSimulate.Click += new System.EventHandler(this.btnSimulate_Click);
            // 
            // btnExport
            // 
            this.btnExport.BorderRadius = 5;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(725, 44);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(95, 29);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(20, 49);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 15);
            this.lblYear.TabIndex = 0;
            this.lblYear.Text = "Year";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(180, 49);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(43, 15);
            this.lblMonth.TabIndex = 2;
            this.lblMonth.Text = "Month";
            // 
            // lblBasePercent
            // 
            this.lblBasePercent.AutoSize = true;
            this.lblBasePercent.Location = new System.Drawing.Point(395, 49);
            this.lblBasePercent.Name = "lblBasePercent";
            this.lblBasePercent.Size = new System.Drawing.Size(88, 15);
            this.lblBasePercent.TabIndex = 4;
            this.lblBasePercent.Text = "Base Bonus (%)";
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResults.Location = new System.Drawing.Point(20, 84);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(132, 15);
            this.lblResults.TabIndex = 8;
            this.lblResults.Text = "Bonus Simulation Data";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.lblFormName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 29);
            this.panel1.TabIndex = 19;
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
            this.lblFormName.Size = new System.Drawing.Size(939, 29);
            this.lblFormName.TabIndex = 4;
            this.lblFormName.Text = "Engineering Bonus Simulation";
            // 
            // frmEngBonusSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 530);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.lblBasePercent);
            this.Controls.Add(this.numBasePercent);
            this.Controls.Add(this.btnSimulate);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.dgvBonusSim);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEngBonusSimulation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Engineering Bonus Simulation";
            this.Load += new System.EventHandler(this.frmEngBonusSimulation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasePercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusSim)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numYear;
        private Guna2ComboBox cmbMonth;
        private NumericUpDown numBasePercent;
        private Guna2DataGridView dgvBonusSim;
        private Guna2Button btnSimulate;
        private Guna2Button btnExport;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblBasePercent;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button lblFormName;
    }
}