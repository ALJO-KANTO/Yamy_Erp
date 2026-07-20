using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.Project_Management.DailySiteExcecution
{
    partial class frmDailyWorkPlan
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
            this.lblWorkPlanNo = new System.Windows.Forms.Label();
            this.txtWorkPlanNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPlanDate = new System.Windows.Forms.Label();
            this.dtPlanDate = new System.Windows.Forms.DateTimePicker();
            this.lblProject = new System.Windows.Forms.Label();
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSite = new System.Windows.Forms.Label();
            this.cmbSite = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblZone = new System.Windows.Forms.Label();
            this.cmbZone = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblEngineer = new System.Windows.Forms.Label();
            this.cmbEngineer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSupervisor = new System.Windows.Forms.Label();
            this.cmbSupervisor = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cmbPriority = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblWorkLocation = new System.Windows.Forms.Label();
            this.txtWorkLocation = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblWorkDescription = new System.Windows.Forms.Label();
            this.txtWorkDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblActivities = new System.Windows.Forms.Label();
            this.dgvActivity = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWorkPlanNo
            // 
            this.lblWorkPlanNo.AutoSize = true;
            this.lblWorkPlanNo.Location = new System.Drawing.Point(20, 20);
            this.lblWorkPlanNo.Name = "lblWorkPlanNo";
            this.lblWorkPlanNo.Size = new System.Drawing.Size(74, 13);
            this.lblWorkPlanNo.TabIndex = 0;
            this.lblWorkPlanNo.Text = "Work Plan No";
            // 
            // txtWorkPlanNo
            // 
            this.txtWorkPlanNo.BorderRadius = 5;
            this.txtWorkPlanNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWorkPlanNo.DefaultText = "";
            this.txtWorkPlanNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtWorkPlanNo.Location = new System.Drawing.Point(120, 18);
            this.txtWorkPlanNo.Name = "txtWorkPlanNo";
            this.txtWorkPlanNo.PlaceholderText = "";
            this.txtWorkPlanNo.SelectedText = "";
            this.txtWorkPlanNo.Size = new System.Drawing.Size(220, 23);
            this.txtWorkPlanNo.TabIndex = 1;
            // 
            // lblPlanDate
            // 
            this.lblPlanDate.AutoSize = true;
            this.lblPlanDate.Location = new System.Drawing.Point(430, 20);
            this.lblPlanDate.Name = "lblPlanDate";
            this.lblPlanDate.Size = new System.Drawing.Size(54, 13);
            this.lblPlanDate.TabIndex = 2;
            this.lblPlanDate.Text = "Plan Date";
            // 
            // dtPlanDate
            // 
            this.dtPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPlanDate.Location = new System.Drawing.Point(520, 18);
            this.dtPlanDate.Name = "dtPlanDate";
            this.dtPlanDate.Size = new System.Drawing.Size(150, 20);
            this.dtPlanDate.TabIndex = 3;
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(20, 60);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(40, 13);
            this.lblProject.TabIndex = 4;
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
            this.cmbProject.ItemHeight = 20;
            this.cmbProject.Location = new System.Drawing.Point(120, 58);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(220, 26);
            this.cmbProject.TabIndex = 5;
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Location = new System.Drawing.Point(430, 60);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(25, 13);
            this.lblSite.TabIndex = 6;
            this.lblSite.Text = "Site";
            // 
            // cmbSite
            // 
            this.cmbSite.BackColor = System.Drawing.Color.Transparent;
            this.cmbSite.BorderRadius = 5;
            this.cmbSite.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSite.FocusedColor = System.Drawing.Color.Empty;
            this.cmbSite.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbSite.ItemHeight = 20;
            this.cmbSite.Location = new System.Drawing.Point(520, 58);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(220, 26);
            this.cmbSite.TabIndex = 7;
            // 
            // lblZone
            // 
            this.lblZone.AutoSize = true;
            this.lblZone.Location = new System.Drawing.Point(20, 100);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(32, 13);
            this.lblZone.TabIndex = 8;
            this.lblZone.Text = "Zone";
            // 
            // cmbZone
            // 
            this.cmbZone.BackColor = System.Drawing.Color.Transparent;
            this.cmbZone.BorderRadius = 5;
            this.cmbZone.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZone.FocusedColor = System.Drawing.Color.Empty;
            this.cmbZone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbZone.ItemHeight = 20;
            this.cmbZone.Location = new System.Drawing.Point(120, 98);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(220, 26);
            this.cmbZone.TabIndex = 9;
            // 
            // lblEngineer
            // 
            this.lblEngineer.AutoSize = true;
            this.lblEngineer.Location = new System.Drawing.Point(430, 100);
            this.lblEngineer.Name = "lblEngineer";
            this.lblEngineer.Size = new System.Drawing.Size(49, 13);
            this.lblEngineer.TabIndex = 10;
            this.lblEngineer.Text = "Engineer";
            // 
            // cmbEngineer
            // 
            this.cmbEngineer.BackColor = System.Drawing.Color.Transparent;
            this.cmbEngineer.BorderRadius = 5;
            this.cmbEngineer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEngineer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEngineer.FocusedColor = System.Drawing.Color.Empty;
            this.cmbEngineer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEngineer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbEngineer.ItemHeight = 20;
            this.cmbEngineer.Location = new System.Drawing.Point(520, 98);
            this.cmbEngineer.Name = "cmbEngineer";
            this.cmbEngineer.Size = new System.Drawing.Size(220, 26);
            this.cmbEngineer.TabIndex = 11;
            // 
            // lblSupervisor
            // 
            this.lblSupervisor.AutoSize = true;
            this.lblSupervisor.Location = new System.Drawing.Point(20, 140);
            this.lblSupervisor.Name = "lblSupervisor";
            this.lblSupervisor.Size = new System.Drawing.Size(57, 13);
            this.lblSupervisor.TabIndex = 12;
            this.lblSupervisor.Text = "Supervisor";
            // 
            // cmbSupervisor
            // 
            this.cmbSupervisor.BackColor = System.Drawing.Color.Transparent;
            this.cmbSupervisor.BorderRadius = 5;
            this.cmbSupervisor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSupervisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupervisor.FocusedColor = System.Drawing.Color.Empty;
            this.cmbSupervisor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSupervisor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbSupervisor.ItemHeight = 20;
            this.cmbSupervisor.Location = new System.Drawing.Point(120, 138);
            this.cmbSupervisor.Name = "cmbSupervisor";
            this.cmbSupervisor.Size = new System.Drawing.Size(220, 26);
            this.cmbSupervisor.TabIndex = 13;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(430, 140);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(38, 13);
            this.lblPriority.TabIndex = 14;
            this.lblPriority.Text = "Priority";
            // 
            // cmbPriority
            // 
            this.cmbPriority.BackColor = System.Drawing.Color.Transparent;
            this.cmbPriority.BorderRadius = 5;
            this.cmbPriority.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FocusedColor = System.Drawing.Color.Empty;
            this.cmbPriority.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbPriority.ItemHeight = 20;
            this.cmbPriority.Location = new System.Drawing.Point(520, 138);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(150, 26);
            this.cmbPriority.TabIndex = 15;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(700, 140);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "Status";
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
            this.cmbStatus.Location = new System.Drawing.Point(760, 138);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 26);
            this.cmbStatus.TabIndex = 17;
            // 
            // lblWorkLocation
            // 
            this.lblWorkLocation.AutoSize = true;
            this.lblWorkLocation.Location = new System.Drawing.Point(20, 180);
            this.lblWorkLocation.Name = "lblWorkLocation";
            this.lblWorkLocation.Size = new System.Drawing.Size(77, 13);
            this.lblWorkLocation.TabIndex = 18;
            this.lblWorkLocation.Text = "Work Location";
            // 
            // txtWorkLocation
            // 
            this.txtWorkLocation.BorderRadius = 5;
            this.txtWorkLocation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWorkLocation.DefaultText = "";
            this.txtWorkLocation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtWorkLocation.Location = new System.Drawing.Point(120, 178);
            this.txtWorkLocation.Name = "txtWorkLocation";
            this.txtWorkLocation.PlaceholderText = "";
            this.txtWorkLocation.SelectedText = "";
            this.txtWorkLocation.Size = new System.Drawing.Size(790, 23);
            this.txtWorkLocation.TabIndex = 19;
            // 
            // lblWorkDescription
            // 
            this.lblWorkDescription.AutoSize = true;
            this.lblWorkDescription.Location = new System.Drawing.Point(20, 220);
            this.lblWorkDescription.Name = "lblWorkDescription";
            this.lblWorkDescription.Size = new System.Drawing.Size(89, 13);
            this.lblWorkDescription.TabIndex = 20;
            this.lblWorkDescription.Text = "Work Description";
            // 
            // txtWorkDescription
            // 
            this.txtWorkDescription.BorderRadius = 5;
            this.txtWorkDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWorkDescription.DefaultText = "";
            this.txtWorkDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtWorkDescription.Location = new System.Drawing.Point(20, 245);
            this.txtWorkDescription.Multiline = true;
            this.txtWorkDescription.Name = "txtWorkDescription";
            this.txtWorkDescription.PlaceholderText = "";
            this.txtWorkDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWorkDescription.SelectedText = "";
            this.txtWorkDescription.Size = new System.Drawing.Size(890, 80);
            this.txtWorkDescription.TabIndex = 21;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(20, 340);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(71, 13);
            this.lblStartTime.TabIndex = 22;
            this.lblStartTime.Text = "Planned Start";
            // 
            // dtStartTime
            // 
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtStartTime.Location = new System.Drawing.Point(120, 338);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.ShowUpDown = true;
            this.dtStartTime.Size = new System.Drawing.Size(120, 20);
            this.dtStartTime.TabIndex = 23;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(300, 340);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(68, 13);
            this.lblEndTime.TabIndex = 24;
            this.lblEndTime.Text = "Planned End";
            // 
            // dtEndTime
            // 
            this.dtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtEndTime.Location = new System.Drawing.Point(390, 338);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.ShowUpDown = true;
            this.dtEndTime.Size = new System.Drawing.Size(120, 20);
            this.dtEndTime.TabIndex = 25;
            // 
            // lblActivities
            // 
            this.lblActivities.AutoSize = true;
            this.lblActivities.Location = new System.Drawing.Point(20, 380);
            this.lblActivities.Name = "lblActivities";
            this.lblActivities.Size = new System.Drawing.Size(75, 13);
            this.lblActivities.TabIndex = 26;
            this.lblActivities.Text = "Daily Activities";
            // 
            // dgvActivity
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvActivity.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvActivity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvActivity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvActivity.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvActivity.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvActivity.Location = new System.Drawing.Point(20, 405);
            this.dgvActivity.Name = "dgvActivity";
            this.dgvActivity.RowHeadersVisible = false;
            this.dgvActivity.Size = new System.Drawing.Size(890, 180);
            this.dgvActivity.TabIndex = 27;
            this.dgvActivity.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvActivity.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvActivity.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvActivity.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvActivity.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvActivity.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvActivity.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvActivity.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvActivity.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvActivity.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvActivity.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvActivity.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvActivity.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvActivity.ThemeStyle.ReadOnly = false;
            this.dgvActivity.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvActivity.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvActivity.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvActivity.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvActivity.ThemeStyle.RowsStyle.Height = 22;
            this.dgvActivity.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvActivity.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Activity";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Location";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Planned Qty";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Assigned To";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Remarks";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(20, 600);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(49, 13);
            this.lblRemarks.TabIndex = 28;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderRadius = 5;
            this.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRemarks.DefaultText = "";
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRemarks.Location = new System.Drawing.Point(20, 625);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.PlaceholderText = "";
            this.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemarks.SelectedText = "";
            this.txtRemarks.Size = new System.Drawing.Size(890, 60);
            this.txtRemarks.TabIndex = 29;
            //====================================================
            // Buttons
            //====================================================

            btnNew = new Button();
            btnNew.Name = "btnNew";
            btnNew.Text = "New";
            btnNew.Size = new Size(100, 35);
            btnNew.Location = new Point(250, 700);
            btnNew.Click += BtnNew_Click;

            btnSave = new Button();
            btnSave.Name = "btnSave";
            btnSave.Text = "Save";
            btnSave.Size = new Size(100, 35);
            btnSave.Location = new Point(360, 700);
            btnSave.Click += BtnSave_Click;

            btnApprove = new Button();
            btnApprove.Name = "btnApprove";
            btnApprove.Text = "Approve";
            btnApprove.Size = new Size(100, 35);
            btnApprove.Location = new Point(470, 700);
            btnApprove.Click += BtnApprove_Click;

            btnClose = new Button();
            btnClose.Name = "btnClose";
            btnClose.Text = "Close";
            btnClose.Size = new Size(100, 35);
            btnClose.Location = new Point(580, 700);
            btnClose.Click += BtnClose_Click;
            // 
            // frmDailyWorkPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 749);
            this.Controls.Add(this.lblWorkPlanNo);
            this.Controls.Add(this.txtWorkPlanNo);
            this.Controls.Add(this.lblPlanDate);
            this.Controls.Add(this.dtPlanDate);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.lblSite);
            this.Controls.Add(this.cmbSite);
            this.Controls.Add(this.lblZone);
            this.Controls.Add(this.cmbZone);
            this.Controls.Add(this.lblEngineer);
            this.Controls.Add(this.cmbEngineer);
            this.Controls.Add(this.lblSupervisor);
            this.Controls.Add(this.cmbSupervisor);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblWorkLocation);
            this.Controls.Add(this.txtWorkLocation);
            this.Controls.Add(this.lblWorkDescription);
            this.Controls.Add(this.txtWorkDescription);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.dtStartTime);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.dtEndTime);
            this.Controls.Add(this.lblActivities);
            this.Controls.Add(this.dgvActivity);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(btnNew);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnApprove);
            this.Controls.Add(btnClose);

            this.Name = "frmDailyWorkPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Work On Site / Daily Work Plan";
            this.Load += new System.EventHandler(this.frmDailyWorkPlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Labels

        private Label lblWorkPlanNo;
        private Label lblPlanDate;
        private Label lblProject;
        private Label lblSite;
        private Label lblZone;
        private Label lblEngineer;
        private Label lblSupervisor;
        private Label lblPriority;
        private Label lblStatus;
        private Label lblWorkLocation;

        #endregion


        #region TextBox

        private Guna2TextBox txtWorkPlanNo;
        private Guna2TextBox txtWorkLocation;

        #endregion


        #region ComboBox

        private Guna2ComboBox cmbProject;
        private Guna2ComboBox cmbSite;
        private Guna2ComboBox cmbZone;
        private Guna2ComboBox cmbEngineer;
        private Guna2ComboBox cmbSupervisor;
        private Guna2ComboBox cmbPriority;
        private Guna2ComboBox cmbStatus;

        #endregion


        #region DateTimePicker

        private DateTimePicker dtPlanDate;
        private DateTimePicker dtStartTime;
        private DateTimePicker dtEndTime;

        #endregion
        #region Labels

        private Label lblWorkDescription;
        private Label lblStartTime;
        private Label lblEndTime;
        private Label lblActivities;
        private Label lblRemarks;

        #endregion


        #region TextBox

        private Guna2TextBox txtWorkDescription;
        private Guna2TextBox txtRemarks;

        #endregion


        #region DataGridView

        private Guna2DataGridView dgvActivity;

        #endregion

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

        #region Buttons

        private Button btnNew;
        private Button btnSave;
        private Button btnApprove;
        private Button btnClose;

        #endregion
    }
}