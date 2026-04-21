using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{
    partial class frmEngMilestones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2GroupBox grpProject;
        private Label lblProject;
        private Guna.UI2.WinForms.Guna2ComboBox cmbProject;
        private Label lblPhase;
        private Guna.UI2.WinForms.Guna2ComboBox cmbPhase;

        private Guna.UI2.WinForms.Guna2GroupBox grpMilestone;
        private Label lblMilestone;
        private Guna.UI2.WinForms.Guna2TextBox txtMilestone;
        private Label lblDueDate;
        private DateTimePicker dtDueDate;
        private Label lblPercent;
        private System.Windows.Forms.NumericUpDown numPercent;
        private Label lblStatus;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStatus;

        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        private Guna.UI2.WinForms.Guna2Button btnClear;

        private Guna.UI2.WinForms.Guna2DataGridView dgvMilestones;

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
            this.grpProject = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPhase = new System.Windows.Forms.Label();
            this.cmbPhase = new Guna.UI2.WinForms.Guna2ComboBox();
            this.grpMilestone = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numValuePercentage = new System.Windows.Forms.NumericUpDown();
            this.lblMilestone = new System.Windows.Forms.Label();
            this.txtMilestone = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.dtDueDate = new System.Windows.Forms.DateTimePicker();
            this.lblPercent = new System.Windows.Forms.Label();
            this.numPercent = new System.Windows.Forms.NumericUpDown();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.dgvMilestones = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormName = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContractValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.grpProject.SuspendLayout();
            this.grpMilestone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValuePercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMilestones)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProject
            // 
            this.grpProject.BorderRadius = 5;
            this.grpProject.Controls.Add(this.lblProject);
            this.grpProject.Controls.Add(this.cmbProject);
            this.grpProject.Controls.Add(this.lblPhase);
            this.grpProject.Controls.Add(this.cmbPhase);
            this.grpProject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grpProject.Location = new System.Drawing.Point(20, 55);
            this.grpProject.Name = "grpProject";
            this.grpProject.Size = new System.Drawing.Size(1040, 80);
            this.grpProject.TabIndex = 0;
            this.grpProject.TabStop = false;
            this.grpProject.Text = "Project & Phase";
            // 
            // lblProject
            // 
            this.lblProject.BackColor = System.Drawing.Color.Transparent;
            this.lblProject.ForeColor = System.Drawing.Color.Black;
            this.lblProject.Location = new System.Drawing.Point(20, 48);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(64, 23);
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
            this.cmbProject.Location = new System.Drawing.Point(90, 45);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(350, 28);
            this.cmbProject.TabIndex = 1;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // lblPhase
            // 
            this.lblPhase.BackColor = System.Drawing.Color.Transparent;
            this.lblPhase.ForeColor = System.Drawing.Color.Black;
            this.lblPhase.Location = new System.Drawing.Point(470, 48);
            this.lblPhase.Name = "lblPhase";
            this.lblPhase.Size = new System.Drawing.Size(44, 23);
            this.lblPhase.TabIndex = 2;
            this.lblPhase.Text = "Phase";
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
            this.cmbPhase.Location = new System.Drawing.Point(520, 45);
            this.cmbPhase.Name = "cmbPhase";
            this.cmbPhase.Size = new System.Drawing.Size(300, 28);
            this.cmbPhase.TabIndex = 3;
            this.cmbPhase.SelectedIndexChanged += new System.EventHandler(this.cmbPhase_SelectedIndexChanged);
            // 
            // grpMilestone
            // 
            this.grpMilestone.BorderRadius = 5;
            this.grpMilestone.Controls.Add(this.txtContractValue);
            this.grpMilestone.Controls.Add(this.label2);
            this.grpMilestone.Controls.Add(this.txtAmount);
            this.grpMilestone.Controls.Add(this.numValuePercentage);
            this.grpMilestone.Controls.Add(this.lblMilestone);
            this.grpMilestone.Controls.Add(this.txtMilestone);
            this.grpMilestone.Controls.Add(this.lblDueDate);
            this.grpMilestone.Controls.Add(this.dtDueDate);
            this.grpMilestone.Controls.Add(this.lblPercent);
            this.grpMilestone.Controls.Add(this.numPercent);
            this.grpMilestone.Controls.Add(this.lblStatus);
            this.grpMilestone.Controls.Add(this.cmbStatus);
            this.grpMilestone.Controls.Add(this.btnAdd);
            this.grpMilestone.Controls.Add(this.btnUpdate);
            this.grpMilestone.Controls.Add(this.btnClear);
            this.grpMilestone.Controls.Add(this.label1);
            this.grpMilestone.Controls.Add(this.label3);
            this.grpMilestone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpMilestone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grpMilestone.Location = new System.Drawing.Point(20, 145);
            this.grpMilestone.Name = "grpMilestone";
            this.grpMilestone.Size = new System.Drawing.Size(1040, 120);
            this.grpMilestone.TabIndex = 1;
            this.grpMilestone.TabStop = false;
            this.grpMilestone.Text = "Milestone Details";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(823, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.Transparent;
            this.txtAmount.BorderRadius = 5;
            this.txtAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmount.DefaultText = "";
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAmount.Location = new System.Drawing.Point(896, 41);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PlaceholderText = "";
            this.txtAmount.SelectedText = "";
            this.txtAmount.Size = new System.Drawing.Size(132, 24);
            this.txtAmount.TabIndex = 14;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(641, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "% Of Contract Value";
            // 
            // numValuePercentage
            // 
            this.numValuePercentage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numValuePercentage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numValuePercentage.Location = new System.Drawing.Point(754, 42);
            this.numValuePercentage.Name = "numValuePercentage";
            this.numValuePercentage.Size = new System.Drawing.Size(63, 23);
            this.numValuePercentage.TabIndex = 12;
            this.numValuePercentage.ValueChanged += new System.EventHandler(this.numValuePercentage_ValueChanged);
            // 
            // lblMilestone
            // 
            this.lblMilestone.BackColor = System.Drawing.Color.Transparent;
            this.lblMilestone.ForeColor = System.Drawing.Color.Black;
            this.lblMilestone.Location = new System.Drawing.Point(20, 45);
            this.lblMilestone.Name = "lblMilestone";
            this.lblMilestone.Size = new System.Drawing.Size(72, 23);
            this.lblMilestone.TabIndex = 0;
            this.lblMilestone.Text = "Milestone";
            // 
            // txtMilestone
            // 
            this.txtMilestone.BackColor = System.Drawing.Color.Transparent;
            this.txtMilestone.BorderRadius = 5;
            this.txtMilestone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMilestone.DefaultText = "";
            this.txtMilestone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMilestone.Location = new System.Drawing.Point(90, 43);
            this.txtMilestone.Name = "txtMilestone";
            this.txtMilestone.PlaceholderText = "";
            this.txtMilestone.SelectedText = "";
            this.txtMilestone.Size = new System.Drawing.Size(300, 24);
            this.txtMilestone.TabIndex = 1;
            // 
            // lblDueDate
            // 
            this.lblDueDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDueDate.ForeColor = System.Drawing.Color.Black;
            this.lblDueDate.Location = new System.Drawing.Point(421, 84);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(64, 23);
            this.lblDueDate.TabIndex = 2;
            this.lblDueDate.Text = "Due Date";
            // 
            // dtDueDate
            // 
            this.dtDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDueDate.Location = new System.Drawing.Point(491, 84);
            this.dtDueDate.Name = "dtDueDate";
            this.dtDueDate.Size = new System.Drawing.Size(120, 23);
            this.dtDueDate.TabIndex = 3;
            // 
            // lblPercent
            // 
            this.lblPercent.BackColor = System.Drawing.Color.Transparent;
            this.lblPercent.ForeColor = System.Drawing.Color.Black;
            this.lblPercent.Location = new System.Drawing.Point(20, 90);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(72, 23);
            this.lblPercent.TabIndex = 4;
            this.lblPercent.Text = "Progress %";
            // 
            // numPercent
            // 
            this.numPercent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numPercent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numPercent.Location = new System.Drawing.Point(98, 88);
            this.numPercent.Name = "numPercent";
            this.numPercent.Size = new System.Drawing.Size(63, 23);
            this.numPercent.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(177, 88);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(46, 23);
            this.lblStatus.TabIndex = 6;
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
            this.cmbStatus.ItemHeight = 22;
            this.cmbStatus.Location = new System.Drawing.Point(226, 81);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 28);
            this.cmbStatus.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 5;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(700, 81);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BorderRadius = 5;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(800, 81);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 30);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.BorderRadius = 5;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(900, 81);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 30);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvMilestones
            // 
            this.dgvMilestones.AllowUserToAddRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            this.dgvMilestones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMilestones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMilestones.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvMilestones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvMilestones.Location = new System.Drawing.Point(20, 271);
            this.dgvMilestones.Name = "dgvMilestones";
            this.dgvMilestones.ReadOnly = true;
            this.dgvMilestones.RowHeadersVisible = false;
            this.dgvMilestones.Size = new System.Drawing.Size(1040, 329);
            this.dgvMilestones.TabIndex = 2;
            this.dgvMilestones.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvMilestones.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvMilestones.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvMilestones.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvMilestones.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvMilestones.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvMilestones.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvMilestones.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvMilestones.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvMilestones.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMilestones.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMilestones.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMilestones.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvMilestones.ThemeStyle.ReadOnly = true;
            this.dgvMilestones.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvMilestones.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMilestones.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMilestones.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvMilestones.ThemeStyle.RowsStyle.Height = 22;
            this.dgvMilestones.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvMilestones.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvMilestones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMilestones_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.lblFormName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 45);
            this.panel1.TabIndex = 9;
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
            this.lblFormName.Size = new System.Drawing.Size(1084, 45);
            this.lblFormName.TabIndex = 4;
            this.lblFormName.Text = "Project Milestones";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(413, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 23);
            this.label3.TabIndex = 15;
            this.label3.Text = "Contract Value";
            // 
            // txtContractValue
            // 
            this.txtContractValue.BackColor = System.Drawing.Color.Transparent;
            this.txtContractValue.BorderRadius = 5;
            this.txtContractValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContractValue.DefaultText = "";
            this.txtContractValue.Enabled = false;
            this.txtContractValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtContractValue.Location = new System.Drawing.Point(497, 42);
            this.txtContractValue.Name = "txtContractValue";
            this.txtContractValue.PlaceholderText = "";
            this.txtContractValue.ReadOnly = true;
            this.txtContractValue.SelectedText = "";
            this.txtContractValue.Size = new System.Drawing.Size(132, 24);
            this.txtContractValue.TabIndex = 16;
            // 
            // frmEngMilestones
            // 
            this.ClientSize = new System.Drawing.Size(1084, 611);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpProject);
            this.Controls.Add(this.grpMilestone);
            this.Controls.Add(this.dgvMilestones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmEngMilestones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Milestones";
            this.Load += new System.EventHandler(this.frmEngMilestones_Load);
            this.grpProject.ResumeLayout(false);
            this.grpMilestone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numValuePercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMilestones)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2Button lblFormName;
        private Label label1;
        private NumericUpDown numValuePercentage;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtAmount;
        private Guna.UI2.WinForms.Guna2TextBox txtContractValue;
        private Label label3;
    }
}