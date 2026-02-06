using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.Project_Finance
{
    partial class frmEngRevenueRecognition
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Guna2ComboBox cmbProject;
        private Guna2ComboBox cmbPhase;
        private Guna2ComboBox cmbMethod;

        private Guna2TextBox txtContractValue;
        private Guna2TextBox txtCompletion;
        private Guna2TextBox txtRecognizedAmount;

        private Guna2Button btnCalculate;
        private Guna2Button btnPost;

        private Guna2DataGridView dgvRevenue;

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
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbPhase = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbMethod = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtContractValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCompletion = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtRecognizedAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCalculate = new Guna.UI2.WinForms.Guna2Button();
            this.btnPost = new Guna.UI2.WinForms.Guna2Button();
            this.dgvRevenue = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormName = new Guna.UI2.WinForms.Guna2Button();
            this.lblProject = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenue)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.cmbProject.Location = new System.Drawing.Point(56, 36);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(250, 28);
            this.cmbProject.TabIndex = 0;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
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
            this.cmbPhase.Location = new System.Drawing.Point(414, 36);
            this.cmbPhase.Name = "cmbPhase";
            this.cmbPhase.Size = new System.Drawing.Size(200, 28);
            this.cmbPhase.TabIndex = 1;
            // 
            // cmbMethod
            // 
            this.cmbMethod.BackColor = System.Drawing.Color.Transparent;
            this.cmbMethod.BorderRadius = 5;
            this.cmbMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMethod.FocusedColor = System.Drawing.Color.Empty;
            this.cmbMethod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbMethod.ItemHeight = 22;
            this.cmbMethod.Items.AddRange(new object[] {
            "POC",
            "Milestone",
            "Manual"});
            this.cmbMethod.Location = new System.Drawing.Point(721, 36);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(180, 28);
            this.cmbMethod.TabIndex = 2;
            // 
            // txtContractValue
            // 
            this.txtContractValue.BorderRadius = 5;
            this.txtContractValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContractValue.DefaultText = "";
            this.txtContractValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtContractValue.Location = new System.Drawing.Point(95, 78);
            this.txtContractValue.Name = "txtContractValue";
            this.txtContractValue.PlaceholderText = "";
            this.txtContractValue.SelectedText = "";
            this.txtContractValue.Size = new System.Drawing.Size(150, 27);
            this.txtContractValue.TabIndex = 3;
            // 
            // txtCompletion
            // 
            this.txtCompletion.BorderRadius = 5;
            this.txtCompletion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCompletion.DefaultText = "";
            this.txtCompletion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCompletion.Location = new System.Drawing.Point(414, 78);
            this.txtCompletion.Name = "txtCompletion";
            this.txtCompletion.PlaceholderText = "";
            this.txtCompletion.SelectedText = "";
            this.txtCompletion.Size = new System.Drawing.Size(100, 27);
            this.txtCompletion.TabIndex = 4;
            // 
            // txtRecognizedAmount
            // 
            this.txtRecognizedAmount.BorderRadius = 5;
            this.txtRecognizedAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRecognizedAmount.DefaultText = "";
            this.txtRecognizedAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRecognizedAmount.Location = new System.Drawing.Point(657, 78);
            this.txtRecognizedAmount.Name = "txtRecognizedAmount";
            this.txtRecognizedAmount.PlaceholderText = "";
            this.txtRecognizedAmount.ReadOnly = true;
            this.txtRecognizedAmount.SelectedText = "";
            this.txtRecognizedAmount.Size = new System.Drawing.Size(150, 27);
            this.txtRecognizedAmount.TabIndex = 5;
            // 
            // btnCalculate
            // 
            this.btnCalculate.BorderRadius = 5;
            this.btnCalculate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.Location = new System.Drawing.Point(922, 78);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(100, 27);
            this.btnCalculate.TabIndex = 6;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnPost
            // 
            this.btnPost.BorderRadius = 5;
            this.btnPost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPost.ForeColor = System.Drawing.Color.White;
            this.btnPost.Location = new System.Drawing.Point(1040, 78);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(120, 27);
            this.btnPost.TabIndex = 7;
            this.btnPost.Text = "Post Revenue";
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // dgvRevenue
            // 
            this.dgvRevenue.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvRevenue.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRevenue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRevenue.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRevenue.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRevenue.Location = new System.Drawing.Point(20, 126);
            this.dgvRevenue.Name = "dgvRevenue";
            this.dgvRevenue.ReadOnly = true;
            this.dgvRevenue.RowHeadersVisible = false;
            this.dgvRevenue.Size = new System.Drawing.Size(1140, 440);
            this.dgvRevenue.TabIndex = 8;
            this.dgvRevenue.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRevenue.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvRevenue.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvRevenue.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvRevenue.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvRevenue.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvRevenue.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRevenue.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvRevenue.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRevenue.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRevenue.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRevenue.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRevenue.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvRevenue.ThemeStyle.ReadOnly = true;
            this.dgvRevenue.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRevenue.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRevenue.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRevenue.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvRevenue.ThemeStyle.RowsStyle.Height = 22;
            this.dgvRevenue.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRevenue.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.lblFormName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 29);
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
            this.lblFormName.Size = new System.Drawing.Size(1184, 29);
            this.lblFormName.TabIndex = 4;
            this.lblFormName.Text = "Project Revenue Recognition";
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(12, 41);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(54, 23);
            this.lblProject.TabIndex = 23;
            this.lblProject.Text = "Project:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(375, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "Phase:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(678, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 23);
            this.label2.TabIndex = 25;
            this.label2.Text = "Method:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(19, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 23);
            this.label3.TabIndex = 26;
            this.label3.Text = "ContractValue:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(353, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Completion:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(552, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "RecognizedAmount:";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(1072, 36);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(100, 28);
            this.guna2Button1.TabIndex = 29;
            this.guna2Button1.Text = "Close";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // frmEngRevenueRecognition
            // 
            this.ClientSize = new System.Drawing.Size(1184, 575);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.cmbPhase);
            this.Controls.Add(this.cmbMethod);
            this.Controls.Add(this.txtContractValue);
            this.Controls.Add(this.txtCompletion);
            this.Controls.Add(this.txtRecognizedAmount);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.dgvRevenue);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEngRevenueRecognition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Revenue Recognition";
            this.Load += new System.EventHandler(this.frmEngRevenueRecognition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenue)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Guna2Button lblFormName;
        private Label lblProject;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Guna2Button guna2Button1;
    }
}