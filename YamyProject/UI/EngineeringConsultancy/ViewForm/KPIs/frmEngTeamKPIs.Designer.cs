namespace YamyProject.UI.EngineeringConsultancy.ViewForm.KPIs
{
    partial class frmEngTeamKPIs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMonth = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSelectProject = new System.Windows.Forms.Label();
            this.dgvRanking = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvTeamKPIs = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtComment = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveComment = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormName = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamKPIs)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Year :";
            // 
            // numYear
            //
            this.numYear.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numYear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numYear.Location = new System.Drawing.Point(285, 44);
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(84, 25);
            this.numYear.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Month :";
            // 
            // cmbMonth
            // 
            this.cmbMonth.BackColor = System.Drawing.Color.Transparent;
            this.cmbMonth.BorderRadius = 5;
            this.cmbMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbMonth.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbMonth.ItemHeight = 20;
            this.cmbMonth.Location = new System.Drawing.Point(60, 44);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(140, 26);
            this.cmbMonth.TabIndex = 6;
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
            this.cmbProject.Location = new System.Drawing.Point(478, 44);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(300, 28);
            this.cmbProject.TabIndex = 9;
            this.cmbProject.Visible = false;
            // 
            // lblSelectProject
            // 
            this.lblSelectProject.Location = new System.Drawing.Point(403, 49);
            this.lblSelectProject.Name = "lblSelectProject";
            this.lblSelectProject.Size = new System.Drawing.Size(100, 23);
            this.lblSelectProject.TabIndex = 8;
            this.lblSelectProject.Text = "Select Project:";
            this.lblSelectProject.Visible = false;
            // 
            // dgvRanking
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvRanking.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRanking.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvRanking.ColumnHeadersHeight = 40;
            this.dgvRanking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRanking.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvRanking.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRanking.Location = new System.Drawing.Point(405, 112);
            this.dgvRanking.Name = "dgvRanking";
            this.dgvRanking.RowHeadersVisible = false;
            this.dgvRanking.Size = new System.Drawing.Size(381, 358);
            this.dgvRanking.TabIndex = 11;
            this.dgvRanking.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRanking.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvRanking.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvRanking.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvRanking.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvRanking.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvRanking.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRanking.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvRanking.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRanking.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRanking.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRanking.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvRanking.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvRanking.ThemeStyle.ReadOnly = false;
            this.dgvRanking.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRanking.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRanking.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRanking.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvRanking.ThemeStyle.RowsStyle.Height = 22;
            this.dgvRanking.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRanking.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dgvTeamKPIs
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvTeamKPIs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTeamKPIs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvTeamKPIs.ColumnHeadersHeight = 40;
            this.dgvTeamKPIs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTeamKPIs.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvTeamKPIs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTeamKPIs.Location = new System.Drawing.Point(13, 112);
            this.dgvTeamKPIs.Name = "dgvTeamKPIs";
            this.dgvTeamKPIs.RowHeadersVisible = false;
            this.dgvTeamKPIs.Size = new System.Drawing.Size(381, 358);
            this.dgvTeamKPIs.TabIndex = 10;
            this.dgvTeamKPIs.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTeamKPIs.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTeamKPIs.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTeamKPIs.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTeamKPIs.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTeamKPIs.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTeamKPIs.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTeamKPIs.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTeamKPIs.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTeamKPIs.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTeamKPIs.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTeamKPIs.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTeamKPIs.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvTeamKPIs.ThemeStyle.ReadOnly = false;
            this.dgvTeamKPIs.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTeamKPIs.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTeamKPIs.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTeamKPIs.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTeamKPIs.ThemeStyle.RowsStyle.Height = 22;
            this.dgvTeamKPIs.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTeamKPIs.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // txtComment
            // 
            this.txtComment.BorderRadius = 5;
            this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtComment.DefaultText = "";
            this.txtComment.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtComment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtComment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtComment.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtComment.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtComment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtComment.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtComment.Location = new System.Drawing.Point(72, 76);
            this.txtComment.Name = "txtComment";
            this.txtComment.PlaceholderText = "";
            this.txtComment.SelectedText = "";
            this.txtComment.Size = new System.Drawing.Size(487, 28);
            this.txtComment.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Comment :";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 5;
            this.btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(688, 78);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 25);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSaveComment
            // 
            this.btnSaveComment.BorderRadius = 5;
            this.btnSaveComment.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveComment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveComment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveComment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveComment.Enabled = false;
            this.btnSaveComment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSaveComment.ForeColor = System.Drawing.Color.White;
            this.btnSaveComment.Location = new System.Drawing.Point(584, 78);
            this.btnSaveComment.Name = "btnSaveComment";
            this.btnSaveComment.Size = new System.Drawing.Size(98, 25);
            this.btnSaveComment.TabIndex = 15;
            this.btnSaveComment.Text = "Save";
            this.btnSaveComment.Click += new System.EventHandler(this.btnSaveComment_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.lblFormName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 29);
            this.panel1.TabIndex = 25;
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
            this.lblFormName.Size = new System.Drawing.Size(800, 29);
            this.lblFormName.TabIndex = 4;
            this.lblFormName.Text = "Engineering TeamKPIs";
            // 
            // frmEngTeamKPIs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 499);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSaveComment);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.dgvRanking);
            this.Controls.Add(this.dgvTeamKPIs);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.lblSelectProject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEngTeamKPIs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Engineering TeamKPIs";
            this.Load += new System.EventHandler(this.frmEngTeamKPIs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamKPIs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbMonth;
        private Guna.UI2.WinForms.Guna2ComboBox cmbProject;
        private System.Windows.Forms.Label lblSelectProject;
        private Guna.UI2.WinForms.Guna2DataGridView dgvRanking;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTeamKPIs;
        private Guna.UI2.WinForms.Guna2TextBox txtComment;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnSaveComment;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button lblFormName;
    }
}