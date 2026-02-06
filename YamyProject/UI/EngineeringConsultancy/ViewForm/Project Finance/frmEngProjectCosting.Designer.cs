using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.Project_Finance
{
    partial class frmEngProjectCosting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Guna2ComboBox cmbProject;
        private Guna2ComboBox cmbPhase;
        private Label lblProject;
        private Label lblPhase;

        private Guna2ComboBox cmbCostType;
        private Guna2TextBox txtDescription;
        private Guna2TextBox txtPlannedCost;
        private Guna2TextBox txtActualCost;
        private Guna2Button btnSave;

        private Guna2DataGridView dgvCosting;

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
            this.lblProject = new System.Windows.Forms.Label();
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPhase = new System.Windows.Forms.Label();
            this.cmbPhase = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbCostType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPlannedCost = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtActualCost = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.dgvCosting = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormName = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCosting)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(20, 54);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(54, 23);
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
            this.cmbProject.Location = new System.Drawing.Point(67, 50);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(250, 28);
            this.cmbProject.TabIndex = 1;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // lblPhase
            // 
            this.lblPhase.Location = new System.Drawing.Point(350, 54);
            this.lblPhase.Name = "lblPhase";
            this.lblPhase.Size = new System.Drawing.Size(44, 23);
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
            this.cmbPhase.Location = new System.Drawing.Point(392, 50);
            this.cmbPhase.Name = "cmbPhase";
            this.cmbPhase.Size = new System.Drawing.Size(237, 28);
            this.cmbPhase.TabIndex = 3;
            this.cmbPhase.SelectedIndexChanged += new System.EventHandler(this.cmbPhase_SelectedIndexChanged);
            // 
            // cmbCostType
            // 
            this.cmbCostType.BackColor = System.Drawing.Color.Transparent;
            this.cmbCostType.BorderRadius = 5;
            this.cmbCostType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCostType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCostType.FocusedColor = System.Drawing.Color.Empty;
            this.cmbCostType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCostType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbCostType.ItemHeight = 22;
            this.cmbCostType.Items.AddRange(new object[] {
            "Labor",
            "Expense",
            "Overhead"});
            this.cmbCostType.Location = new System.Drawing.Point(749, 50);
            this.cmbCostType.Name = "cmbCostType";
            this.cmbCostType.Size = new System.Drawing.Size(175, 28);
            this.cmbCostType.TabIndex = 4;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderRadius = 5;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescription.Location = new System.Drawing.Point(84, 94);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "";
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(300, 24);
            this.txtDescription.TabIndex = 5;
            // 
            // txtPlannedCost
            // 
            this.txtPlannedCost.BorderRadius = 5;
            this.txtPlannedCost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPlannedCost.DefaultText = "";
            this.txtPlannedCost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPlannedCost.Location = new System.Drawing.Point(510, 94);
            this.txtPlannedCost.Name = "txtPlannedCost";
            this.txtPlannedCost.PlaceholderText = "";
            this.txtPlannedCost.SelectedText = "";
            this.txtPlannedCost.Size = new System.Drawing.Size(120, 24);
            this.txtPlannedCost.TabIndex = 6;
            // 
            // txtActualCost
            // 
            this.txtActualCost.BorderRadius = 5;
            this.txtActualCost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtActualCost.DefaultText = "";
            this.txtActualCost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtActualCost.Location = new System.Drawing.Point(742, 94);
            this.txtActualCost.Name = "txtActualCost";
            this.txtActualCost.PlaceholderText = "";
            this.txtActualCost.SelectedText = "";
            this.txtActualCost.Size = new System.Drawing.Size(120, 24);
            this.txtActualCost.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(918, 90);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 26);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvCosting
            // 
            this.dgvCosting.AllowUserToAddRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            this.dgvCosting.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCosting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCosting.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvCosting.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCosting.Location = new System.Drawing.Point(20, 130);
            this.dgvCosting.Name = "dgvCosting";
            this.dgvCosting.ReadOnly = true;
            this.dgvCosting.RowHeadersVisible = false;
            this.dgvCosting.Size = new System.Drawing.Size(1140, 420);
            this.dgvCosting.TabIndex = 9;
            this.dgvCosting.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCosting.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCosting.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCosting.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCosting.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCosting.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCosting.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCosting.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCosting.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCosting.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCosting.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCosting.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCosting.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvCosting.ThemeStyle.ReadOnly = true;
            this.dgvCosting.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCosting.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCosting.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCosting.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCosting.ThemeStyle.RowsStyle.Height = 22;
            this.dgvCosting.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCosting.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.lblFormName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 29);
            this.panel1.TabIndex = 20;
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
            this.lblFormName.Size = new System.Drawing.Size(1184, 29);
            this.lblFormName.TabIndex = 4;
            this.lblFormName.Text = "Project Costing";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(1051, 92);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(109, 26);
            this.guna2Button1.TabIndex = 21;
            this.guna2Button1.Text = "Close";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(687, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "Cost Type:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Desrciption:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(442, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 23);
            this.label3.TabIndex = 24;
            this.label3.Text = "Planed Cost:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(677, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 23);
            this.label4.TabIndex = 25;
            this.label4.Text = "Actual Cost:";
            // 
            // frmEngProjectCosting
            // 
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.lblPhase);
            this.Controls.Add(this.cmbPhase);
            this.Controls.Add(this.cmbCostType);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtPlannedCost);
            this.Controls.Add(this.txtActualCost);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvCosting);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEngProjectCosting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Costing";
            this.Load += new System.EventHandler(this.frmProjectCosting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCosting)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Guna2Button lblFormName;
        private Guna2Button guna2Button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}