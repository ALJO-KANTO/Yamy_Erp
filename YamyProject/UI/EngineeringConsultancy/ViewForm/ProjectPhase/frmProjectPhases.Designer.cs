using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{
    partial class frmProjectPhases
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.lblFormName = new Guna.UI2.WinForms.Guna2Button();
            this.tabMain = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabPhasesTemplates = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkPhaseActive = new System.Windows.Forms.CheckBox();
            this.txtPhaseNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSavePhase = new Guna.UI2.WinForms.Guna2Button();
            this.dgvPhaseTemplates = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtPhaseOrder = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPhaseName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPhaseTasks = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkTaskActive = new System.Windows.Forms.CheckBox();
            this.chkMandatory = new System.Windows.Forms.CheckBox();
            this.cmbPhase = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaveTask = new Guna.UI2.WinForms.Guna2Button();
            this.dgvTasks = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtTaskOrder = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTaskName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPhaseWorkflow = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvWorkflowPhases = new Guna.UI2.WinForms.Guna2DataGridView();
            this.phase_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phase_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight_percentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phase_color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phase_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.template_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.template_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.grpProject = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnAddWorkFlow = new Guna.UI2.WinForms.Guna2Button();
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPhasesTemplates.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhaseTemplates)).BeginInit();
            this.tabPhaseTasks.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.tabPhaseWorkflow.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkflowPhases)).BeginInit();
            this.panel5.SuspendLayout();
            this.grpProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.lblFormName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1427, 45);
            this.panel1.TabIndex = 8;
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
            this.btnClose.Location = new System.Drawing.Point(1397, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(27, 26);
            this.btnClose.TabIndex = 5;
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
            this.lblFormName.Size = new System.Drawing.Size(1427, 45);
            this.lblFormName.TabIndex = 4;
            this.lblFormName.Text = "Project Phases";
            // 
            // tabMain
            // 
            this.tabMain.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabMain.Controls.Add(this.tabPhasesTemplates);
            this.tabMain.Controls.Add(this.tabPhaseTasks);
            this.tabMain.Controls.Add(this.tabPhaseWorkflow);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.ItemSize = new System.Drawing.Size(180, 40);
            this.tabMain.Location = new System.Drawing.Point(0, 45);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1427, 642);
            this.tabMain.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabMain.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabMain.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabMain.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tabMain.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabMain.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabMain.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabMain.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabMain.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tabMain.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabMain.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabMain.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tabMain.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabMain.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tabMain.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tabMain.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tabMain.TabIndex = 9;
            this.tabMain.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            // 
            // tabPhasesTemplates
            // 
            this.tabPhasesTemplates.Controls.Add(this.panel2);
            this.tabPhasesTemplates.Location = new System.Drawing.Point(184, 4);
            this.tabPhasesTemplates.Name = "tabPhasesTemplates";
            this.tabPhasesTemplates.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhasesTemplates.Size = new System.Drawing.Size(1239, 634);
            this.tabPhasesTemplates.TabIndex = 0;
            this.tabPhasesTemplates.Text = "Phases Templates";
            this.tabPhasesTemplates.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkPhaseActive);
            this.panel2.Controls.Add(this.txtPhaseNo);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnSavePhase);
            this.panel2.Controls.Add(this.dgvPhaseTemplates);
            this.panel2.Controls.Add(this.txtPhaseOrder);
            this.panel2.Controls.Add(this.txtPhaseName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1233, 628);
            this.panel2.TabIndex = 241;
            // 
            // chkPhaseActive
            // 
            this.chkPhaseActive.AutoSize = true;
            this.chkPhaseActive.Checked = true;
            this.chkPhaseActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPhaseActive.Location = new System.Drawing.Point(244, 50);
            this.chkPhaseActive.Name = "chkPhaseActive";
            this.chkPhaseActive.Size = new System.Drawing.Size(56, 17);
            this.chkPhaseActive.TabIndex = 19;
            this.chkPhaseActive.Text = "Active";
            this.chkPhaseActive.UseVisualStyleBackColor = true;
            // 
            // txtPhaseNo
            // 
            this.txtPhaseNo.BorderRadius = 5;
            this.txtPhaseNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhaseNo.DefaultText = "";
            this.txtPhaseNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhaseNo.Location = new System.Drawing.Point(29, 3);
            this.txtPhaseNo.Name = "txtPhaseNo";
            this.txtPhaseNo.PlaceholderText = "Phase No";
            this.txtPhaseNo.SelectedText = "";
            this.txtPhaseNo.Size = new System.Drawing.Size(72, 26);
            this.txtPhaseNo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sort Order";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "No";
            // 
            // btnSavePhase
            // 
            this.btnSavePhase.BorderRadius = 5;
            this.btnSavePhase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSavePhase.ForeColor = System.Drawing.Color.White;
            this.btnSavePhase.Location = new System.Drawing.Point(381, 45);
            this.btnSavePhase.Name = "btnSavePhase";
            this.btnSavePhase.Size = new System.Drawing.Size(122, 26);
            this.btnSavePhase.TabIndex = 4;
            this.btnSavePhase.Text = "Save";
            this.btnSavePhase.Click += new System.EventHandler(this.btnSavePhase_Click);
            // 
            // dgvPhaseTemplates
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvPhaseTemplates.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhaseTemplates.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPhaseTemplates.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhaseTemplates.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPhaseTemplates.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhaseTemplates.Location = new System.Drawing.Point(13, 102);
            this.dgvPhaseTemplates.Name = "dgvPhaseTemplates";
            this.dgvPhaseTemplates.ReadOnly = true;
            this.dgvPhaseTemplates.RowHeadersVisible = false;
            this.dgvPhaseTemplates.Size = new System.Drawing.Size(1202, 486);
            this.dgvPhaseTemplates.TabIndex = 0;
            this.dgvPhaseTemplates.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPhaseTemplates.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvPhaseTemplates.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvPhaseTemplates.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvPhaseTemplates.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvPhaseTemplates.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvPhaseTemplates.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhaseTemplates.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvPhaseTemplates.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPhaseTemplates.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPhaseTemplates.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPhaseTemplates.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPhaseTemplates.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvPhaseTemplates.ThemeStyle.ReadOnly = true;
            this.dgvPhaseTemplates.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPhaseTemplates.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPhaseTemplates.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPhaseTemplates.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPhaseTemplates.ThemeStyle.RowsStyle.Height = 22;
            this.dgvPhaseTemplates.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhaseTemplates.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPhaseTemplates.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhaseTemplates_CellDoubleClick);
            // 
            // txtPhaseOrder
            // 
            this.txtPhaseOrder.BorderRadius = 5;
            this.txtPhaseOrder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhaseOrder.DefaultText = "";
            this.txtPhaseOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhaseOrder.Location = new System.Drawing.Point(67, 45);
            this.txtPhaseOrder.Name = "txtPhaseOrder";
            this.txtPhaseOrder.PlaceholderText = "Sort Order";
            this.txtPhaseOrder.SelectedText = "";
            this.txtPhaseOrder.Size = new System.Drawing.Size(106, 26);
            this.txtPhaseOrder.TabIndex = 3;
            // 
            // txtPhaseName
            // 
            this.txtPhaseName.BorderRadius = 5;
            this.txtPhaseName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhaseName.DefaultText = "";
            this.txtPhaseName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhaseName.Location = new System.Drawing.Point(176, 3);
            this.txtPhaseName.Name = "txtPhaseName";
            this.txtPhaseName.PlaceholderText = "Phase Name";
            this.txtPhaseName.SelectedText = "";
            this.txtPhaseName.Size = new System.Drawing.Size(548, 26);
            this.txtPhaseName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Phase Name";
            // 
            // tabPhaseTasks
            // 
            this.tabPhaseTasks.Controls.Add(this.panel3);
            this.tabPhaseTasks.Location = new System.Drawing.Point(184, 4);
            this.tabPhaseTasks.Name = "tabPhaseTasks";
            this.tabPhaseTasks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhaseTasks.Size = new System.Drawing.Size(1239, 634);
            this.tabPhaseTasks.TabIndex = 1;
            this.tabPhaseTasks.Text = "Phase Tasks";
            this.tabPhaseTasks.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkTaskActive);
            this.panel3.Controls.Add(this.chkMandatory);
            this.panel3.Controls.Add(this.cmbPhase);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.btnSaveTask);
            this.panel3.Controls.Add(this.dgvTasks);
            this.panel3.Controls.Add(this.txtTaskOrder);
            this.panel3.Controls.Add(this.txtTaskName);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1233, 628);
            this.panel3.TabIndex = 241;
            // 
            // chkTaskActive
            // 
            this.chkTaskActive.AutoSize = true;
            this.chkTaskActive.Checked = true;
            this.chkTaskActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTaskActive.Location = new System.Drawing.Point(385, 85);
            this.chkTaskActive.Name = "chkTaskActive";
            this.chkTaskActive.Size = new System.Drawing.Size(56, 17);
            this.chkTaskActive.TabIndex = 18;
            this.chkTaskActive.Text = "Active";
            this.chkTaskActive.UseVisualStyleBackColor = true;
            // 
            // chkMandatory
            // 
            this.chkMandatory.AutoSize = true;
            this.chkMandatory.Checked = true;
            this.chkMandatory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMandatory.Location = new System.Drawing.Point(224, 85);
            this.chkMandatory.Name = "chkMandatory";
            this.chkMandatory.Size = new System.Drawing.Size(76, 17);
            this.chkMandatory.TabIndex = 17;
            this.chkMandatory.Text = "Mandatory";
            this.chkMandatory.UseVisualStyleBackColor = true;
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
            this.cmbPhase.ItemHeight = 20;
            this.cmbPhase.Location = new System.Drawing.Point(103, 5);
            this.cmbPhase.Name = "cmbPhase";
            this.cmbPhase.Size = new System.Drawing.Size(502, 26);
            this.cmbPhase.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Phase Template";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Sort Order";
            // 
            // btnSaveTask
            // 
            this.btnSaveTask.BorderRadius = 5;
            this.btnSaveTask.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSaveTask.ForeColor = System.Drawing.Color.White;
            this.btnSaveTask.Location = new System.Drawing.Point(483, 78);
            this.btnSaveTask.Name = "btnSaveTask";
            this.btnSaveTask.Size = new System.Drawing.Size(122, 26);
            this.btnSaveTask.TabIndex = 4;
            this.btnSaveTask.Text = "Save";
            this.btnSaveTask.Click += new System.EventHandler(this.btnSaveTask_Click);
            // 
            // dgvTasks
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvTasks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTasks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTasks.ColumnHeadersHeight = 30;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTasks.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTasks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTasks.Location = new System.Drawing.Point(10, 160);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.ReadOnly = true;
            this.dgvTasks.RowHeadersVisible = false;
            this.dgvTasks.Size = new System.Drawing.Size(1202, 448);
            this.dgvTasks.TabIndex = 0;
            this.dgvTasks.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTasks.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTasks.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTasks.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTasks.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTasks.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTasks.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTasks.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTasks.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTasks.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTasks.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTasks.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTasks.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvTasks.ThemeStyle.ReadOnly = true;
            this.dgvTasks.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTasks.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTasks.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTasks.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTasks.ThemeStyle.RowsStyle.Height = 22;
            this.dgvTasks.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTasks.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTasks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTasks_CellDoubleClick);
            // 
            // txtTaskOrder
            // 
            this.txtTaskOrder.BorderRadius = 5;
            this.txtTaskOrder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTaskOrder.DefaultText = "";
            this.txtTaskOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTaskOrder.Location = new System.Drawing.Point(103, 78);
            this.txtTaskOrder.Name = "txtTaskOrder";
            this.txtTaskOrder.PlaceholderText = "Sort Order";
            this.txtTaskOrder.SelectedText = "";
            this.txtTaskOrder.Size = new System.Drawing.Size(106, 26);
            this.txtTaskOrder.TabIndex = 3;
            // 
            // txtTaskName
            // 
            this.txtTaskName.BorderRadius = 5;
            this.txtTaskName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTaskName.DefaultText = "";
            this.txtTaskName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTaskName.Location = new System.Drawing.Point(103, 41);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.PlaceholderText = "Task Name";
            this.txtTaskName.SelectedText = "";
            this.txtTaskName.Size = new System.Drawing.Size(705, 26);
            this.txtTaskName.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Task Name";
            // 
            // tabPhaseWorkflow
            // 
            this.tabPhaseWorkflow.Controls.Add(this.panel6);
            this.tabPhaseWorkflow.Controls.Add(this.panel5);
            this.tabPhaseWorkflow.Location = new System.Drawing.Point(184, 4);
            this.tabPhaseWorkflow.Name = "tabPhaseWorkflow";
            this.tabPhaseWorkflow.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhaseWorkflow.Size = new System.Drawing.Size(1239, 634);
            this.tabPhaseWorkflow.TabIndex = 3;
            this.tabPhaseWorkflow.Text = "Phase Workflow";
            this.tabPhaseWorkflow.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvWorkflowPhases);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 114);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1233, 517);
            this.panel6.TabIndex = 16;
            // 
            // dgvWorkflowPhases
            // 
            this.dgvWorkflowPhases.AllowUserToAddRows = false;
            this.dgvWorkflowPhases.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvWorkflowPhases.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkflowPhases.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvWorkflowPhases.ColumnHeadersHeight = 25;
            this.dgvWorkflowPhases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvWorkflowPhases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.phase_id,
            this.phase_name,
            this.start_date,
            this.end_date,
            this.weight_percentage,
            this.Status,
            this.phase_color,
            this.Phase_no,
            this.template_id,
            this.template_name});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorkflowPhases.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvWorkflowPhases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkflowPhases.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvWorkflowPhases.Location = new System.Drawing.Point(0, 0);
            this.dgvWorkflowPhases.Name = "dgvWorkflowPhases";
            this.dgvWorkflowPhases.ReadOnly = true;
            this.dgvWorkflowPhases.RowHeadersVisible = false;
            this.dgvWorkflowPhases.Size = new System.Drawing.Size(1233, 517);
            this.dgvWorkflowPhases.TabIndex = 13;
            this.dgvWorkflowPhases.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvWorkflowPhases.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvWorkflowPhases.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvWorkflowPhases.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvWorkflowPhases.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvWorkflowPhases.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvWorkflowPhases.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvWorkflowPhases.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvWorkflowPhases.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvWorkflowPhases.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvWorkflowPhases.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvWorkflowPhases.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvWorkflowPhases.ThemeStyle.HeaderStyle.Height = 25;
            this.dgvWorkflowPhases.ThemeStyle.ReadOnly = true;
            this.dgvWorkflowPhases.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvWorkflowPhases.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvWorkflowPhases.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvWorkflowPhases.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvWorkflowPhases.ThemeStyle.RowsStyle.Height = 22;
            this.dgvWorkflowPhases.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvWorkflowPhases.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
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
            this.phase_name.FillWeight = 113.7544F;
            this.phase_name.HeaderText = "Phase Name";
            this.phase_name.Name = "phase_name";
            this.phase_name.ReadOnly = true;
            // 
            // start_date
            // 
            this.start_date.FillWeight = 31.73966F;
            this.start_date.HeaderText = "Start Date";
            this.start_date.Name = "start_date";
            this.start_date.ReadOnly = true;
            // 
            // end_date
            // 
            this.end_date.FillWeight = 31.79692F;
            this.end_date.HeaderText = "End Date";
            this.end_date.Name = "end_date";
            this.end_date.ReadOnly = true;
            // 
            // weight_percentage
            // 
            this.weight_percentage.FillWeight = 30.3441F;
            this.weight_percentage.HeaderText = "Weight %";
            this.weight_percentage.Name = "weight_percentage";
            this.weight_percentage.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.FillWeight = 23.75439F;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // phase_color
            // 
            this.phase_color.FillWeight = 30.47788F;
            this.phase_color.HeaderText = "Phase Color";
            this.phase_color.Name = "phase_color";
            this.phase_color.ReadOnly = true;
            // 
            // Phase_no
            // 
            this.Phase_no.FillWeight = 28.65485F;
            this.Phase_no.HeaderText = "Phase No";
            this.Phase_no.Name = "Phase_no";
            this.Phase_no.ReadOnly = true;
            // 
            // template_id
            // 
            this.template_id.HeaderText = "template_id";
            this.template_id.Name = "template_id";
            this.template_id.ReadOnly = true;
            this.template_id.Visible = false;
            // 
            // template_name
            // 
            this.template_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.template_name.FillWeight = 79.47788F;
            this.template_name.HeaderText = "Template Name";
            this.template_name.Name = "template_name";
            this.template_name.ReadOnly = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.grpProject);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1233, 111);
            this.panel5.TabIndex = 15;
            // 
            // grpProject
            // 
            this.grpProject.BorderRadius = 5;
            this.grpProject.Controls.Add(this.btnAddWorkFlow);
            this.grpProject.Controls.Add(this.cmbProject);
            this.grpProject.Controls.Add(this.label10);
            this.grpProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grpProject.Location = new System.Drawing.Point(0, 0);
            this.grpProject.Name = "grpProject";
            this.grpProject.Size = new System.Drawing.Size(1233, 111);
            this.grpProject.TabIndex = 14;
            this.grpProject.TabStop = false;
            this.grpProject.Text = "Project and Phase";
            // 
            // btnAddWorkFlow
            // 
            this.btnAddWorkFlow.BorderRadius = 5;
            this.btnAddWorkFlow.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddWorkFlow.ForeColor = System.Drawing.Color.White;
            this.btnAddWorkFlow.Location = new System.Drawing.Point(863, 48);
            this.btnAddWorkFlow.Name = "btnAddWorkFlow";
            this.btnAddWorkFlow.Size = new System.Drawing.Size(160, 30);
            this.btnAddWorkFlow.TabIndex = 10;
            this.btnAddWorkFlow.Text = "Add Workflow";
            this.btnAddWorkFlow.Click += new System.EventHandler(this.btnAddWorkFlow_Click);
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
            this.cmbProject.Size = new System.Drawing.Size(605, 28);
            this.cmbProject.TabIndex = 1;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(42, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "Project";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.FillWeight = 113.7544F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Phase Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 31.73966F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Start Date";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 89;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 31.79692F;
            this.dataGridViewTextBoxColumn4.HeaderText = "End Date";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.FillWeight = 30.3441F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Weight %";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 85;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.FillWeight = 23.75439F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Status";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 67;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.FillWeight = 30.47788F;
            this.dataGridViewTextBoxColumn7.HeaderText = "Phase Color";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 86;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.FillWeight = 28.65485F;
            this.dataGridViewTextBoxColumn8.HeaderText = "Phase No";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 81;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "template_id";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn10.FillWeight = 79.47788F;
            this.dataGridViewTextBoxColumn10.HeaderText = "Template Name";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // frmProjectPhases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1427, 687);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProjectPhases";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Phases";
            this.Load += new System.EventHandler(this.frmProjectPhases_Load);
            this.panel1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabPhasesTemplates.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhaseTemplates)).EndInit();
            this.tabPhaseTasks.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.tabPhaseWorkflow.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkflowPhases)).EndInit();
            this.panel5.ResumeLayout(false);
            this.grpProject.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2Button lblFormName;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private Guna.UI2.WinForms.Guna2TabControl tabMain;
        private TabPage tabPhasesTemplates;
        private TabPage tabPhaseTasks;
        private Panel panel2;
        private CheckBox chkPhaseActive;
        private Guna.UI2.WinForms.Guna2TextBox txtPhaseNo;
        private Label label3;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button btnSavePhase;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPhaseTemplates;
        private Guna.UI2.WinForms.Guna2TextBox txtPhaseOrder;
        private Guna.UI2.WinForms.Guna2TextBox txtPhaseName;
        private Label label2;
        private Panel panel3;
        private CheckBox chkTaskActive;
        private CheckBox chkMandatory;
        private Guna.UI2.WinForms.Guna2ComboBox cmbPhase;
        private Label label4;
        private Label label5;
        private Guna.UI2.WinForms.Guna2Button btnSaveTask;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTasks;
        private Guna.UI2.WinForms.Guna2TextBox txtTaskOrder;
        private Guna.UI2.WinForms.Guna2TextBox txtTaskName;
        private Label label6;
        private TabPage tabPhaseWorkflow;
        private Panel panel6;
        private Guna.UI2.WinForms.Guna2DataGridView dgvWorkflowPhases;
        private DataGridViewTextBoxColumn phase_id;
        private DataGridViewTextBoxColumn phase_name;
        private DataGridViewTextBoxColumn start_date;
        private DataGridViewTextBoxColumn end_date;
        private DataGridViewTextBoxColumn weight_percentage;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn phase_color;
        private DataGridViewTextBoxColumn Phase_no;
        private DataGridViewTextBoxColumn template_id;
        private DataGridViewTextBoxColumn template_name;
        private Panel panel5;
        private Guna.UI2.WinForms.Guna2GroupBox grpProject;
        private Guna.UI2.WinForms.Guna2Button btnAddWorkFlow;
        private Guna.UI2.WinForms.Guna2ComboBox cmbProject;
        private Label label10;
    }
}