using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{
    partial class frmEngProjectPhases
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private GroupBox grpProjectInfo;
        private Label lblProject;
        private Guna.UI2.WinForms.Guna2ComboBox cmbProject;

        private GroupBox grpPhaseEntry;
        private Label lblPhaseName;
        private Guna.UI2.WinForms.Guna2TextBox txtPhaseName;
        private Label lblStartDate;
        private DateTimePicker dtStartDate;
        private Label lblEndDate;
        private DateTimePicker dtEndDate;
        private Label lblWeight;
        private NumericUpDown numWeight;
        private Label lblStatus;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStatus;

        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        private Guna.UI2.WinForms.Guna2Button btnClear;
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
            this.grpProjectInfo = new System.Windows.Forms.GroupBox();
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.grpPhaseEntry = new System.Windows.Forms.GroupBox();
            this.lblPhaseName = new System.Windows.Forms.Label();
            this.txtPhaseName = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.numWeight = new System.Windows.Forms.NumericUpDown();
            this.cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormName = new Guna.UI2.WinForms.Guna2Button();
            this.dgvPhases = new Guna.UI2.WinForms.Guna2DataGridView();
            this.phase_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phase_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight_percentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpProjectInfo.SuspendLayout();
            this.grpPhaseEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhases)).BeginInit();
            this.SuspendLayout();
            // 
            // grpProjectInfo
            // 
            this.grpProjectInfo.Controls.Add(this.cmbProject);
            this.grpProjectInfo.Controls.Add(this.lblProject);
            this.grpProjectInfo.Location = new System.Drawing.Point(27, 53);
            this.grpProjectInfo.Name = "grpProjectInfo";
            this.grpProjectInfo.Size = new System.Drawing.Size(1040, 70);
            this.grpProjectInfo.TabIndex = 9;
            this.grpProjectInfo.TabStop = false;
            this.grpProjectInfo.Text = "Project Information";
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
            this.cmbProject.ItemHeight = 20;
            this.cmbProject.Location = new System.Drawing.Point(90, 26);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(350, 26);
            this.cmbProject.TabIndex = 1;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(48, 30);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(51, 23);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "Project";
            // 
            // grpPhaseEntry
            // 
            this.grpPhaseEntry.Controls.Add(this.lblPhaseName);
            this.grpPhaseEntry.Controls.Add(this.txtPhaseName);
            this.grpPhaseEntry.Controls.Add(this.dtStartDate);
            this.grpPhaseEntry.Controls.Add(this.dtEndDate);
            this.grpPhaseEntry.Controls.Add(this.numWeight);
            this.grpPhaseEntry.Controls.Add(this.cmbStatus);
            this.grpPhaseEntry.Controls.Add(this.btnAdd);
            this.grpPhaseEntry.Controls.Add(this.btnUpdate);
            this.grpPhaseEntry.Controls.Add(this.btnClear);
            this.grpPhaseEntry.Controls.Add(this.lblWeight);
            this.grpPhaseEntry.Controls.Add(this.lblStartDate);
            this.grpPhaseEntry.Controls.Add(this.lblEndDate);
            this.grpPhaseEntry.Controls.Add(this.lblStatus);
            this.grpPhaseEntry.Location = new System.Drawing.Point(27, 133);
            this.grpPhaseEntry.Name = "grpPhaseEntry";
            this.grpPhaseEntry.Size = new System.Drawing.Size(1040, 130);
            this.grpPhaseEntry.TabIndex = 10;
            this.grpPhaseEntry.TabStop = false;
            this.grpPhaseEntry.Text = "Phase Details";
            // 
            // lblPhaseName
            // 
            this.lblPhaseName.Location = new System.Drawing.Point(38, 30);
            this.lblPhaseName.Name = "lblPhaseName";
            this.lblPhaseName.Size = new System.Drawing.Size(71, 23);
            this.lblPhaseName.TabIndex = 0;
            this.lblPhaseName.Text = "Phase Name";
            // 
            // txtPhaseName
            // 
            this.txtPhaseName.BorderRadius = 5;
            this.txtPhaseName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhaseName.DefaultText = "";
            this.txtPhaseName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhaseName.Location = new System.Drawing.Point(110, 26);
            this.txtPhaseName.Name = "txtPhaseName";
            this.txtPhaseName.PlaceholderText = "";
            this.txtPhaseName.SelectedText = "";
            this.txtPhaseName.Size = new System.Drawing.Size(250, 20);
            this.txtPhaseName.TabIndex = 1;
            // 
            // dtStartDate
            // 
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(450, 26);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(126, 20);
            this.dtStartDate.TabIndex = 3;
            // 
            // dtEndDate
            // 
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDate.Location = new System.Drawing.Point(720, 26);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(116, 20);
            this.dtEndDate.TabIndex = 5;
            // 
            // numWeight
            // 
            this.numWeight.Location = new System.Drawing.Point(110, 73);
            this.numWeight.Name = "numWeight";
            this.numWeight.Size = new System.Drawing.Size(80, 20);
            this.numWeight.TabIndex = 7;
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbStatus.BorderRadius = 5;
            this.cmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FocusedColor = System.Drawing.Color.Empty;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbStatus.ItemHeight = 20;
            this.cmbStatus.Location = new System.Drawing.Point(270, 71);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 26);
            this.cmbStatus.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 5;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(720, 70);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BorderRadius = 5;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(820, 70);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 30);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.BorderRadius = 5;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(920, 70);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 30);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblWeight
            // 
            this.lblWeight.Location = new System.Drawing.Point(45, 75);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(64, 23);
            this.lblWeight.TabIndex = 6;
            this.lblWeight.Text = "Weight (%)";
            // 
            // lblStartDate
            // 
            this.lblStartDate.Location = new System.Drawing.Point(389, 28);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(68, 23);
            this.lblStartDate.TabIndex = 2;
            this.lblStartDate.Text = "Start Date";
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(662, 28);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(58, 23);
            this.lblEndDate.TabIndex = 4;
            this.lblEndDate.Text = "End Date";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(231, 75);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(44, 23);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.lblFormName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 45);
            this.panel1.TabIndex = 8;
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
            this.lblFormName.Size = new System.Drawing.Size(1100, 45);
            this.lblFormName.TabIndex = 4;
            this.lblFormName.Text = "Engineering Project Phases";
            // 
            // dgvPhases
            // 
            this.dgvPhases.AllowUserToAddRows = false;
            this.dgvPhases.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvPhases.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhases.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPhases.ColumnHeadersHeight = 25;
            this.dgvPhases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvPhases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.phase_id,
            this.phase_name,
            this.start_date,
            this.end_date,
            this.weight_percentage,
            this.Status});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhases.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPhases.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhases.Location = new System.Drawing.Point(27, 269);
            this.dgvPhases.Name = "dgvPhases";
            this.dgvPhases.ReadOnly = true;
            this.dgvPhases.RowHeadersVisible = false;
            this.dgvPhases.Size = new System.Drawing.Size(1040, 369);
            this.dgvPhases.TabIndex = 11;
            this.dgvPhases.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPhases.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvPhases.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvPhases.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvPhases.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvPhases.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvPhases.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhases.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvPhases.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPhases.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPhases.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPhases.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvPhases.ThemeStyle.HeaderStyle.Height = 25;
            this.dgvPhases.ThemeStyle.ReadOnly = true;
            this.dgvPhases.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPhases.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPhases.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPhases.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPhases.ThemeStyle.RowsStyle.Height = 22;
            this.dgvPhases.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhases.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPhases.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhases_CellClick);
            // 
            // phase_id
            // 
            this.phase_id.HeaderText = "id";
            this.phase_id.Name = "phase_id";
            this.phase_id.ReadOnly = true;
            this.phase_id.Visible = false;
            // 
            // phase_name
            // 
            this.phase_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.phase_name.FillWeight = 143.1271F;
            this.phase_name.HeaderText = "Phase Name";
            this.phase_name.Name = "phase_name";
            this.phase_name.ReadOnly = true;
            // 
            // start_date
            // 
            this.start_date.FillWeight = 102.8458F;
            this.start_date.HeaderText = "Start Date";
            this.start_date.Name = "start_date";
            this.start_date.ReadOnly = true;
            // 
            // end_date
            // 
            this.end_date.FillWeight = 60.13864F;
            this.end_date.HeaderText = "End Date";
            this.end_date.Name = "end_date";
            this.end_date.ReadOnly = true;
            // 
            // weight_percentage
            // 
            this.weight_percentage.FillWeight = 50.76142F;
            this.weight_percentage.HeaderText = "Weight %";
            this.weight_percentage.Name = "weight_percentage";
            this.weight_percentage.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.FillWeight = 143.1271F;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // frmEngProjectPhases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.dgvPhases);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpProjectInfo);
            this.Controls.Add(this.grpPhaseEntry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEngProjectPhases";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Engineering Project Phases";
            this.Load += new System.EventHandler(this.frmEngProjectPhases_Load);
            this.grpProjectInfo.ResumeLayout(false);
            this.grpPhaseEntry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhases)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2Button lblFormName;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPhases;
        private DataGridViewTextBoxColumn phase_id;
        private DataGridViewTextBoxColumn phase_name;
        private DataGridViewTextBoxColumn start_date;
        private DataGridViewTextBoxColumn end_date;
        private DataGridViewTextBoxColumn weight_percentage;
        private DataGridViewTextBoxColumn Status;
    }
}