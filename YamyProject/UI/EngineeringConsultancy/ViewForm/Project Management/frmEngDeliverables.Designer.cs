using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{
    partial class frmEngDeliverables
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Guna2GroupBox grpContext;
        private Label lblProject;
        private Guna2ComboBox cmbProject;
        private Label lblPhase;
        private Guna2ComboBox cmbPhase;
        private Label lblMilestone;
        private Guna2ComboBox cmbMilestone;

        private Guna2GroupBox grpDeliverable;
        private Label lblDeliverable;
        private Guna2TextBox txtDeliverable;
        private Label lblType;
        private Guna2ComboBox cmbType;
        private Label lblDueDate;
        private DateTimePicker dtDueDate;
        private Label lblStatus;
        private Guna2ComboBox cmbStatus;
        private Label lblRemarks;
        private Guna2TextBox txtRemarks;

        private Guna2Button btnAdd;
        private Guna2Button btnUpdate;
        private Guna2Button btnClear;

        private Guna2DataGridView dgvDeliverables;

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
            this.grpContext = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPhase = new System.Windows.Forms.Label();
            this.cmbPhase = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblMilestone = new System.Windows.Forms.Label();
            this.cmbMilestone = new Guna.UI2.WinForms.Guna2ComboBox();
            this.grpDeliverable = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblDeliverable = new System.Windows.Forms.Label();
            this.txtDeliverable = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.dtDueDate = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.dgvDeliverables = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormName = new Guna.UI2.WinForms.Guna2Button();
            this.grpContext.SuspendLayout();
            this.grpDeliverable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliverables)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpContext
            // 
            this.grpContext.BorderRadius = 5;
            this.grpContext.Controls.Add(this.cmbProject);
            this.grpContext.Controls.Add(this.cmbPhase);
            this.grpContext.Controls.Add(this.cmbMilestone);
            this.grpContext.Controls.Add(this.lblProject);
            this.grpContext.Controls.Add(this.lblPhase);
            this.grpContext.Controls.Add(this.lblMilestone);
            this.grpContext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpContext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grpContext.Location = new System.Drawing.Point(20, 47);
            this.grpContext.Name = "grpContext";
            this.grpContext.Size = new System.Drawing.Size(1080, 90);
            this.grpContext.TabIndex = 0;
            this.grpContext.TabStop = false;
            this.grpContext.Text = "Project Context";
            // 
            // lblProject
            // 
            this.lblProject.BackColor = System.Drawing.Color.Transparent;
            this.lblProject.ForeColor = System.Drawing.Color.Black;
            this.lblProject.Location = new System.Drawing.Point(20, 50);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(60, 23);
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
            this.cmbProject.ItemHeight = 22;
            this.cmbProject.Location = new System.Drawing.Point(80, 46);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(280, 28);
            this.cmbProject.TabIndex = 1;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // lblPhase
            // 
            this.lblPhase.BackColor = System.Drawing.Color.Transparent;
            this.lblPhase.ForeColor = System.Drawing.Color.Black;
            this.lblPhase.Location = new System.Drawing.Point(380, 50);
            this.lblPhase.Name = "lblPhase";
            this.lblPhase.Size = new System.Drawing.Size(50, 23);
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
            this.cmbPhase.Location = new System.Drawing.Point(430, 46);
            this.cmbPhase.Name = "cmbPhase";
            this.cmbPhase.Size = new System.Drawing.Size(260, 28);
            this.cmbPhase.TabIndex = 3;
            this.cmbPhase.SelectedIndexChanged += new System.EventHandler(this.cmbPhase_SelectedIndexChanged);
            // 
            // lblMilestone
            // 
            this.lblMilestone.BackColor = System.Drawing.Color.Transparent;
            this.lblMilestone.ForeColor = System.Drawing.Color.Black;
            this.lblMilestone.Location = new System.Drawing.Point(710, 50);
            this.lblMilestone.Name = "lblMilestone";
            this.lblMilestone.Size = new System.Drawing.Size(74, 23);
            this.lblMilestone.TabIndex = 4;
            this.lblMilestone.Text = "Milestone";
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
            this.cmbMilestone.Location = new System.Drawing.Point(780, 46);
            this.cmbMilestone.Name = "cmbMilestone";
            this.cmbMilestone.Size = new System.Drawing.Size(260, 28);
            this.cmbMilestone.TabIndex = 5;
            this.cmbMilestone.SelectedIndexChanged += new System.EventHandler(this.cmbMilestone_SelectedIndexChanged);
            // 
            // grpDeliverable
            // 
            this.grpDeliverable.BorderRadius = 5;
            this.grpDeliverable.Controls.Add(this.txtDeliverable);
            this.grpDeliverable.Controls.Add(this.lblType);
            this.grpDeliverable.Controls.Add(this.cmbType);
            this.grpDeliverable.Controls.Add(this.lblDueDate);
            this.grpDeliverable.Controls.Add(this.dtDueDate);
            this.grpDeliverable.Controls.Add(this.lblStatus);
            this.grpDeliverable.Controls.Add(this.cmbStatus);
            this.grpDeliverable.Controls.Add(this.lblRemarks);
            this.grpDeliverable.Controls.Add(this.txtRemarks);
            this.grpDeliverable.Controls.Add(this.btnAdd);
            this.grpDeliverable.Controls.Add(this.btnUpdate);
            this.grpDeliverable.Controls.Add(this.btnClear);
            this.grpDeliverable.Controls.Add(this.lblDeliverable);
            this.grpDeliverable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpDeliverable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grpDeliverable.Location = new System.Drawing.Point(20, 147);
            this.grpDeliverable.Name = "grpDeliverable";
            this.grpDeliverable.Size = new System.Drawing.Size(1080, 170);
            this.grpDeliverable.TabIndex = 1;
            this.grpDeliverable.TabStop = false;
            this.grpDeliverable.Text = "Deliverable Details";
            // 
            // lblDeliverable
            // 
            this.lblDeliverable.BackColor = System.Drawing.Color.Transparent;
            this.lblDeliverable.ForeColor = System.Drawing.Color.Black;
            this.lblDeliverable.Location = new System.Drawing.Point(20, 56);
            this.lblDeliverable.Name = "lblDeliverable";
            this.lblDeliverable.Size = new System.Drawing.Size(91, 23);
            this.lblDeliverable.TabIndex = 0;
            this.lblDeliverable.Text = "Deliverable";
            // 
            // txtDeliverable
            // 
            this.txtDeliverable.BackColor = System.Drawing.Color.Transparent;
            this.txtDeliverable.BorderRadius = 5;
            this.txtDeliverable.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDeliverable.DefaultText = "";
            this.txtDeliverable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDeliverable.Location = new System.Drawing.Point(110, 53);
            this.txtDeliverable.Name = "txtDeliverable";
            this.txtDeliverable.PlaceholderText = "";
            this.txtDeliverable.SelectedText = "";
            this.txtDeliverable.Size = new System.Drawing.Size(320, 26);
            this.txtDeliverable.TabIndex = 1;
            // 
            // lblType
            // 
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.ForeColor = System.Drawing.Color.Black;
            this.lblType.Location = new System.Drawing.Point(460, 56);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(32, 23);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type";
            // 
            // cmbType
            // 
            this.cmbType.BackColor = System.Drawing.Color.Transparent;
            this.cmbType.BorderRadius = 5;
            this.cmbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FocusedColor = System.Drawing.Color.Empty;
            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbType.ItemHeight = 22;
            this.cmbType.Location = new System.Drawing.Point(510, 53);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(180, 28);
            this.cmbType.TabIndex = 3;
            // 
            // lblDueDate
            // 
            this.lblDueDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDueDate.ForeColor = System.Drawing.Color.Black;
            this.lblDueDate.Location = new System.Drawing.Point(720, 56);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(64, 23);
            this.lblDueDate.TabIndex = 4;
            this.lblDueDate.Text = "Due Date";
            // 
            // dtDueDate
            // 
            this.dtDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDueDate.Location = new System.Drawing.Point(790, 53);
            this.dtDueDate.Name = "dtDueDate";
            this.dtDueDate.Size = new System.Drawing.Size(116, 23);
            this.dtDueDate.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(20, 101);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 23);
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
            this.cmbStatus.Location = new System.Drawing.Point(110, 97);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(180, 28);
            this.cmbStatus.TabIndex = 7;
            // 
            // lblRemarks
            // 
            this.lblRemarks.BackColor = System.Drawing.Color.Transparent;
            this.lblRemarks.ForeColor = System.Drawing.Color.Black;
            this.lblRemarks.Location = new System.Drawing.Point(320, 101);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(49, 23);
            this.lblRemarks.TabIndex = 8;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.Transparent;
            this.txtRemarks.BorderRadius = 5;
            this.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRemarks.DefaultText = "";
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRemarks.Location = new System.Drawing.Point(390, 97);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.PlaceholderText = "";
            this.txtRemarks.SelectedText = "";
            this.txtRemarks.Size = new System.Drawing.Size(360, 60);
            this.txtRemarks.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 5;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(780, 131);
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
            this.btnUpdate.Location = new System.Drawing.Point(880, 131);
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
            this.btnClear.Location = new System.Drawing.Point(980, 131);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 30);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvDeliverables
            // 
            this.dgvDeliverables.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDeliverables.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeliverables.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeliverables.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDeliverables.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDeliverables.Location = new System.Drawing.Point(20, 322);
            this.dgvDeliverables.Name = "dgvDeliverables";
            this.dgvDeliverables.ReadOnly = true;
            this.dgvDeliverables.RowHeadersVisible = false;
            this.dgvDeliverables.Size = new System.Drawing.Size(1080, 327);
            this.dgvDeliverables.TabIndex = 2;
            this.dgvDeliverables.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDeliverables.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDeliverables.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDeliverables.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDeliverables.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDeliverables.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDeliverables.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDeliverables.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDeliverables.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDeliverables.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDeliverables.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDeliverables.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDeliverables.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvDeliverables.ThemeStyle.ReadOnly = true;
            this.dgvDeliverables.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDeliverables.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDeliverables.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDeliverables.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDeliverables.ThemeStyle.RowsStyle.Height = 22;
            this.dgvDeliverables.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDeliverables.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDeliverables.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeliverables_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.lblFormName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1134, 45);
            this.panel1.TabIndex = 10;
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
            this.lblFormName.Size = new System.Drawing.Size(1134, 45);
            this.lblFormName.TabIndex = 4;
            this.lblFormName.Text = "Project Deliverables";
            // 
            // frmEngDeliverables
            // 
            this.ClientSize = new System.Drawing.Size(1134, 661);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpContext);
            this.Controls.Add(this.grpDeliverable);
            this.Controls.Add(this.dgvDeliverables);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmEngDeliverables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Deliverables";
            this.Load += new System.EventHandler(this.frmEngDeliverables_Load);
            this.grpContext.ResumeLayout(false);
            this.grpDeliverable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliverables)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Guna2Button lblFormName;
    }
}