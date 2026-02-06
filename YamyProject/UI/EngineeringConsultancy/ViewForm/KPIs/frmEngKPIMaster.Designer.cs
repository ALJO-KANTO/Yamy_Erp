using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.KPIs
{
    partial class frmEngKPIMaster
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormName = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCalculation = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.dgvKPIs = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.cmbType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.numTargetTxt = new System.Windows.Forms.NumericUpDown();
            this.numWeightTxt = new System.Windows.Forms.NumericUpDown();
            this.cmbEmployee = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbEvaluation = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panelAction = new System.Windows.Forms.Panel();
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
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kpi_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kpi_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kpi_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kpi_category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.target_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calculation_method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKPIs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeightTxt)).BeginInit();
            this.panelAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.lblFormName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1248, 29);
            this.panel1.TabIndex = 22;
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
            this.lblFormName.Size = new System.Drawing.Size(1248, 29);
            this.lblFormName.TabIndex = 4;
            this.lblFormName.Text = "KPI Master";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Type:";
            this.label1.Visible = false;
            // 
            // txtName
            // 
            this.txtName.BorderRadius = 5;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.Location = new System.Drawing.Point(318, 37);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(366, 23);
            this.txtName.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Target:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(478, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Weight:";
            // 
            // cmbCalculation
            // 
            this.cmbCalculation.BackColor = System.Drawing.Color.Transparent;
            this.cmbCalculation.BorderRadius = 5;
            this.cmbCalculation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCalculation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCalculation.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbCalculation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbCalculation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCalculation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbCalculation.ItemHeight = 20;
            this.cmbCalculation.Items.AddRange(new object[] {
            "PERCENTAGE",
            "RATIO",
            "SCORE",
            "AMOUNT"});
            this.cmbCalculation.Location = new System.Drawing.Point(59, 72);
            this.cmbCalculation.Name = "cmbCalculation";
            this.cmbCalculation.Size = new System.Drawing.Size(127, 26);
            this.cmbCalculation.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Calculate:";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(199, 75);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 35;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(833, 69);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 26);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BorderRadius = 5;
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(911, 69);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 26);
            this.btnDelete.TabIndex = 37;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvKPIs
            // 
            this.dgvKPIs.AllowUserToAddRows = false;
            this.dgvKPIs.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvKPIs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKPIs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKPIs.ColumnHeadersHeight = 32;
            this.dgvKPIs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvKPIs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kpi_id,
            this.kpi_code,
            this.kpi_name,
            this.kpi_category,
            this.target_value,
            this.weight,
            this.calculation_method,
            this.is_active,
            this.EmployeeId,
            this.Employee,
            this.Period});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKPIs.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKPIs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKPIs.Location = new System.Drawing.Point(12, 163);
            this.dgvKPIs.Name = "dgvKPIs";
            this.dgvKPIs.ReadOnly = true;
            this.dgvKPIs.RowHeadersVisible = false;
            this.dgvKPIs.Size = new System.Drawing.Size(1224, 353);
            this.dgvKPIs.TabIndex = 38;
            this.dgvKPIs.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvKPIs.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvKPIs.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvKPIs.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvKPIs.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvKPIs.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvKPIs.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKPIs.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvKPIs.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvKPIs.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvKPIs.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvKPIs.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvKPIs.ThemeStyle.HeaderStyle.Height = 32;
            this.dgvKPIs.ThemeStyle.ReadOnly = true;
            this.dgvKPIs.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvKPIs.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKPIs.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvKPIs.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvKPIs.ThemeStyle.RowsStyle.Height = 22;
            this.dgvKPIs.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKPIs.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvKPIs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKPIs_CellClick);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(989, 69);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(72, 26);
            this.guna2Button1.TabIndex = 39;
            this.guna2Button1.Text = "Close";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // cmbType
            // 
            this.cmbType.BackColor = System.Drawing.Color.Transparent;
            this.cmbType.BorderRadius = 5;
            this.cmbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbType.ItemHeight = 20;
            this.cmbType.Items.AddRange(new object[] {
            "ENG_BILLABLE_RATIO",
            "ENG_PRODUCTIVITY",
            "SALES_CONVERSION",
            "SALES_TARGET",
            "NEW_LEADS",
            "LEAD_CONVERSION",
            "CONTRACT_VALUE",
            "SALES_CYCLE",
            "PROPOSAL_SUCCESS",
            "CLIENT_RETENTION",
            "RECEIVABLE_RATIO"});
            this.cmbType.Location = new System.Drawing.Point(421, 108);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(222, 26);
            this.cmbType.TabIndex = 40;
            this.cmbType.Visible = false;
            // 
            // numTargetTxt
            // 
            this.numTargetTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numTargetTxt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numTargetTxt.Location = new System.Drawing.Point(379, 72);
            this.numTargetTxt.Name = "numTargetTxt";
            this.numTargetTxt.Size = new System.Drawing.Size(82, 23);
            this.numTargetTxt.TabIndex = 41;
            this.numTargetTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNum_KeyPress);
            // 
            // numWeightTxt
            // 
            this.numWeightTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numWeightTxt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numWeightTxt.Location = new System.Drawing.Point(521, 72);
            this.numWeightTxt.Name = "numWeightTxt";
            this.numWeightTxt.Size = new System.Drawing.Size(88, 23);
            this.numWeightTxt.TabIndex = 42;
            this.numWeightTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNum_KeyPress);
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.BackColor = System.Drawing.Color.Transparent;
            this.cmbEmployee.BorderRadius = 5;
            this.cmbEmployee.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbEmployee.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbEmployee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbEmployee.ItemHeight = 20;
            this.cmbEmployee.Items.AddRange(new object[] {
            "ENG_BILLABLE_RATIO",
            "ENG_PRODUCTIVITY",
            "SALES_CONVERSION",
            "SALES_TARGET",
            "NEW_LEADS",
            "LEAD_CONVERSION",
            "CONTRACT_VALUE",
            "SALES_CYCLE",
            "PROPOSAL_SUCCESS",
            "CLIENT_RETENTION",
            "RECEIVABLE_RATIO"});
            this.cmbEmployee.Location = new System.Drawing.Point(57, 37);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(222, 26);
            this.cmbEmployee.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Employee";
            // 
            // cmbEvaluation
            // 
            this.cmbEvaluation.BackColor = System.Drawing.Color.Transparent;
            this.cmbEvaluation.BorderRadius = 5;
            this.cmbEvaluation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEvaluation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEvaluation.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbEvaluation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbEvaluation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEvaluation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbEvaluation.ItemHeight = 20;
            this.cmbEvaluation.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.cmbEvaluation.Location = new System.Drawing.Point(881, 34);
            this.cmbEvaluation.Name = "cmbEvaluation";
            this.cmbEvaluation.Size = new System.Drawing.Size(180, 26);
            this.cmbEvaluation.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(787, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Evaluation Period :";
            // 
            // panelAction
            // 
            this.panelAction.Controls.Add(this.txtName);
            this.panelAction.Controls.Add(this.cmbEvaluation);
            this.panelAction.Controls.Add(this.label6);
            this.panelAction.Controls.Add(this.label8);
            this.panelAction.Controls.Add(this.label4);
            this.panelAction.Controls.Add(this.cmbEmployee);
            this.panelAction.Controls.Add(this.label7);
            this.panelAction.Controls.Add(this.label2);
            this.panelAction.Controls.Add(this.numWeightTxt);
            this.panelAction.Controls.Add(this.label5);
            this.panelAction.Controls.Add(this.numTargetTxt);
            this.panelAction.Controls.Add(this.cmbCalculation);
            this.panelAction.Controls.Add(this.cmbType);
            this.panelAction.Controls.Add(this.chkActive);
            this.panelAction.Controls.Add(this.guna2Button1);
            this.panelAction.Controls.Add(this.btnSave);
            this.panelAction.Controls.Add(this.btnDelete);
            this.panelAction.Controls.Add(this.label1);
            this.panelAction.Location = new System.Drawing.Point(12, 35);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(1224, 114);
            this.panelAction.TabIndex = 47;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Code";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 140;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 82.08121F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 163;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 82.08121F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Category";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 163;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.FillWeight = 82.08121F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Target Value";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 163;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.FillWeight = 82.08121F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Weight";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 163;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.FillWeight = 82.08121F;
            this.dataGridViewTextBoxColumn7.HeaderText = "Calculation Method";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 163;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Active";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 163;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "EmployeeId";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.FillWeight = 82.08121F;
            this.dataGridViewTextBoxColumn10.HeaderText = "Employee";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 163;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.FillWeight = 37.5127F;
            this.dataGridViewTextBoxColumn11.HeaderText = "Period";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 87;
            // 
            // kpi_id
            // 
            this.kpi_id.HeaderText = "Id";
            this.kpi_id.Name = "kpi_id";
            this.kpi_id.ReadOnly = true;
            this.kpi_id.Visible = false;
            // 
            // kpi_code
            // 
            this.kpi_code.HeaderText = "Code";
            this.kpi_code.Name = "kpi_code";
            this.kpi_code.ReadOnly = true;
            this.kpi_code.Visible = false;
            // 
            // kpi_name
            // 
            this.kpi_name.FillWeight = 82.08121F;
            this.kpi_name.HeaderText = "Name";
            this.kpi_name.Name = "kpi_name";
            this.kpi_name.ReadOnly = true;
            // 
            // kpi_category
            // 
            this.kpi_category.FillWeight = 82.08121F;
            this.kpi_category.HeaderText = "Category";
            this.kpi_category.Name = "kpi_category";
            this.kpi_category.ReadOnly = true;
            // 
            // target_value
            // 
            this.target_value.FillWeight = 82.08121F;
            this.target_value.HeaderText = "Target Value";
            this.target_value.Name = "target_value";
            this.target_value.ReadOnly = true;
            // 
            // weight
            // 
            this.weight.FillWeight = 82.08121F;
            this.weight.HeaderText = "Weight";
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            // 
            // calculation_method
            // 
            this.calculation_method.FillWeight = 82.08121F;
            this.calculation_method.HeaderText = "Calculation Method";
            this.calculation_method.Name = "calculation_method";
            this.calculation_method.ReadOnly = true;
            // 
            // is_active
            // 
            this.is_active.HeaderText = "Active";
            this.is_active.Name = "is_active";
            this.is_active.ReadOnly = true;
            this.is_active.Visible = false;
            // 
            // EmployeeId
            // 
            this.EmployeeId.HeaderText = "EmployeeId";
            this.EmployeeId.Name = "EmployeeId";
            this.EmployeeId.ReadOnly = true;
            this.EmployeeId.Visible = false;
            // 
            // Employee
            // 
            this.Employee.FillWeight = 82.08121F;
            this.Employee.HeaderText = "Employee";
            this.Employee.Name = "Employee";
            this.Employee.ReadOnly = true;
            // 
            // Period
            // 
            this.Period.FillWeight = 37.5127F;
            this.Period.HeaderText = "Period";
            this.Period.Name = "Period";
            this.Period.ReadOnly = true;
            // 
            // frmEngKPIMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 528);
            this.Controls.Add(this.panelAction);
            this.Controls.Add(this.dgvKPIs);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEngKPIMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KPI Master";
            this.Load += new System.EventHandler(this.frmEngKPIMaster_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKPIs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeightTxt)).EndInit();
            this.panelAction.ResumeLayout(false);
            this.panelAction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button lblFormName;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCalculation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkActive;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2DataGridView dgvKPIs;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbType;
        private NumericUpDown numTargetTxt;
        private NumericUpDown numWeightTxt;
        private DataGridViewTextBoxColumn code;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn category;
        private DataGridViewTextBoxColumn active;
        private Guna2ComboBox cmbEmployee;
        private Label label7;
        private Guna2ComboBox cmbEvaluation;
        private Label label8;
        private Panel panelAction;
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
        private DataGridViewTextBoxColumn kpi_id;
        private DataGridViewTextBoxColumn kpi_code;
        private DataGridViewTextBoxColumn kpi_name;
        private DataGridViewTextBoxColumn kpi_category;
        private DataGridViewTextBoxColumn target_value;
        private DataGridViewTextBoxColumn weight;
        private DataGridViewTextBoxColumn calculation_method;
        private DataGridViewTextBoxColumn is_active;
        private DataGridViewTextBoxColumn EmployeeId;
        private DataGridViewTextBoxColumn Employee;
        private DataGridViewTextBoxColumn Period;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
    }
}