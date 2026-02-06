using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.Timesheet_Resources
{
    partial class frmEngTimesheetEntry
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
        private Label lblWorkDate;
        private DateTimePicker dtWorkDate;
        private Label lblHours;
        private System.Windows.Forms.NumericUpDown numHours;
        private Guna2CheckBox chkBillable;
        private Label lblRemarks;
        private Guna2TextBox txtRemarks;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;

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
            this.lblProject = new System.Windows.Forms.Label();
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPhase = new System.Windows.Forms.Label();
            this.cmbPhase = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblMilestone = new System.Windows.Forms.Label();
            this.cmbMilestone = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblWorkDate = new System.Windows.Forms.Label();
            this.dtWorkDate = new System.Windows.Forms.DateTimePicker();
            this.lblHours = new System.Windows.Forms.Label();
            this.numHours = new System.Windows.Forms.NumericUpDown();
            this.chkBillable = new Guna.UI2.WinForms.Guna2CheckBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormName = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEmployee = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(20, 40);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(100, 23);
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
            this.cmbProject.Location = new System.Drawing.Point(120, 35);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(300, 28);
            this.cmbProject.TabIndex = 1;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // lblPhase
            // 
            this.lblPhase.Location = new System.Drawing.Point(20, 80);
            this.lblPhase.Name = "lblPhase";
            this.lblPhase.Size = new System.Drawing.Size(100, 23);
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
            this.cmbPhase.Location = new System.Drawing.Point(120, 75);
            this.cmbPhase.Name = "cmbPhase";
            this.cmbPhase.Size = new System.Drawing.Size(300, 28);
            this.cmbPhase.TabIndex = 3;
            this.cmbPhase.SelectedIndexChanged += new System.EventHandler(this.cmbPhase_SelectedIndexChanged);
            // 
            // lblMilestone
            // 
            this.lblMilestone.Location = new System.Drawing.Point(20, 120);
            this.lblMilestone.Name = "lblMilestone";
            this.lblMilestone.Size = new System.Drawing.Size(100, 23);
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
            this.cmbMilestone.Location = new System.Drawing.Point(120, 115);
            this.cmbMilestone.Name = "cmbMilestone";
            this.cmbMilestone.Size = new System.Drawing.Size(300, 28);
            this.cmbMilestone.TabIndex = 5;
            this.cmbMilestone.SelectedIndexChanged += new System.EventHandler(this.cmbMilestone_SelectedIndexChanged);
            // 
            // lblWorkDate
            // 
            this.lblWorkDate.Location = new System.Drawing.Point(20, 204);
            this.lblWorkDate.Name = "lblWorkDate";
            this.lblWorkDate.Size = new System.Drawing.Size(100, 23);
            this.lblWorkDate.TabIndex = 6;
            this.lblWorkDate.Text = "Work Date:";
            // 
            // dtWorkDate
            // 
            this.dtWorkDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtWorkDate.Location = new System.Drawing.Point(120, 199);
            this.dtWorkDate.Name = "dtWorkDate";
            this.dtWorkDate.Size = new System.Drawing.Size(155, 20);
            this.dtWorkDate.TabIndex = 7;
            // 
            // lblHours
            // 
            this.lblHours.Location = new System.Drawing.Point(20, 244);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(100, 23);
            this.lblHours.TabIndex = 8;
            this.lblHours.Text = "Hours:";
            // 
            // numHours
            //
            this.numHours.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numHours.DecimalPlaces = 2;
            this.numHours.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numHours.Location = new System.Drawing.Point(120, 239);
            this.numHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numHours.Name = "numHours";
            this.numHours.Size = new System.Drawing.Size(90, 20);
            this.numHours.TabIndex = 9;
            // 
            // chkBillable
            // 
            this.chkBillable.Checked = true;
            this.chkBillable.CheckedState.BorderRadius = 0;
            this.chkBillable.CheckedState.BorderThickness = 0;
            this.chkBillable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBillable.Location = new System.Drawing.Point(120, 274);
            this.chkBillable.Name = "chkBillable";
            this.chkBillable.Size = new System.Drawing.Size(104, 24);
            this.chkBillable.TabIndex = 10;
            this.chkBillable.Text = "Billable";
            this.chkBillable.UncheckedState.BorderRadius = 0;
            this.chkBillable.UncheckedState.BorderThickness = 0;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Location = new System.Drawing.Point(20, 314);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(100, 23);
            this.lblRemarks.TabIndex = 11;
            this.lblRemarks.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderRadius = 5;
            this.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRemarks.DefaultText = "";
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRemarks.Location = new System.Drawing.Point(120, 309);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.PlaceholderText = "";
            this.txtRemarks.SelectedText = "";
            this.txtRemarks.Size = new System.Drawing.Size(300, 60);
            this.txtRemarks.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(120, 384);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(240, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.lblFormName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 29);
            this.panel1.TabIndex = 15;
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
            this.lblFormName.Size = new System.Drawing.Size(484, 29);
            this.lblFormName.TabIndex = 4;
            this.lblFormName.Text = "Timesheet Entry";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "Employee:";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.BackColor = System.Drawing.Color.Transparent;
            this.cmbEmployee.BorderRadius = 5;
            this.cmbEmployee.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.FocusedColor = System.Drawing.Color.Empty;
            this.cmbEmployee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbEmployee.ItemHeight = 22;
            this.cmbEmployee.Location = new System.Drawing.Point(120, 156);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(300, 28);
            this.cmbEmployee.TabIndex = 17;
            // 
            // frmEngTimesheetEntry
            // 
            this.ClientSize = new System.Drawing.Size(484, 419);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.lblPhase);
            this.Controls.Add(this.cmbPhase);
            this.Controls.Add(this.lblMilestone);
            this.Controls.Add(this.cmbMilestone);
            this.Controls.Add(this.lblWorkDate);
            this.Controls.Add(this.dtWorkDate);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.numHours);
            this.Controls.Add(this.chkBillable);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmEngTimesheetEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Timesheet Entry";
            this.Load += new System.EventHandler(this.frmTimesheetEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2Button lblFormName;
        private Label label1;
        private Guna2ComboBox cmbEmployee;
    }
}