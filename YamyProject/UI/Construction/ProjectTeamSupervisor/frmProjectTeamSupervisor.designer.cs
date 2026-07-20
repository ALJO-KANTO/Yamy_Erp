using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace YamyProject
{
    partial class frmProjectTeamSupervisor
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

        private void InitializeComponent()
        {
            this.grpProjectInfo = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtProjectCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtClient = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLocation = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.grpTeam = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtEmpCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmpName = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbRole = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbZone = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtMobile = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpJoinDate = new System.Windows.Forms.DateTimePicker();
            this.lblEmpCode = new System.Windows.Forms.Label();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblZone = new System.Windows.Forms.Label();
            this.lblMobile = new System.Windows.Forms.Label();
            this.lblJoinDate = new System.Windows.Forms.Label();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.dgvTeam = new System.Windows.Forms.DataGridView();
            this.headerUC1 = new YamyProject.HeaderUC();
            this.grpProjectInfo.SuspendLayout();
            this.grpTeam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeam)).BeginInit();
            this.SuspendLayout();
            // 
            // grpProjectInfo
            // 
            this.grpProjectInfo.Controls.Add(this.cmbProject);
            this.grpProjectInfo.Controls.Add(this.txtProjectCode);
            this.grpProjectInfo.Controls.Add(this.txtClient);
            this.grpProjectInfo.Controls.Add(this.txtLocation);
            this.grpProjectInfo.Controls.Add(this.lblProject);
            this.grpProjectInfo.Controls.Add(this.lblCode);
            this.grpProjectInfo.Controls.Add(this.lblClient);
            this.grpProjectInfo.Controls.Add(this.lblLocation);
            this.grpProjectInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpProjectInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpProjectInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grpProjectInfo.Location = new System.Drawing.Point(0, 35);
            this.grpProjectInfo.Name = "grpProjectInfo";
            this.grpProjectInfo.Size = new System.Drawing.Size(1184, 93);
            this.grpProjectInfo.TabIndex = 2;
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
            this.cmbProject.ItemHeight = 18;
            this.cmbProject.Location = new System.Drawing.Point(70, 63);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(240, 24);
            this.cmbProject.TabIndex = 0;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // txtProjectCode
            // 
            this.txtProjectCode.BackColor = System.Drawing.Color.Transparent;
            this.txtProjectCode.BorderRadius = 5;
            this.txtProjectCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProjectCode.DefaultText = "";
            this.txtProjectCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProjectCode.Location = new System.Drawing.Point(385, 63);
            this.txtProjectCode.Name = "txtProjectCode";
            this.txtProjectCode.PlaceholderText = "";
            this.txtProjectCode.SelectedText = "";
            this.txtProjectCode.Size = new System.Drawing.Size(110, 23);
            this.txtProjectCode.TabIndex = 1;
            // 
            // txtClient
            // 
            this.txtClient.BackColor = System.Drawing.Color.Transparent;
            this.txtClient.BorderRadius = 5;
            this.txtClient.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtClient.DefaultText = "";
            this.txtClient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtClient.Location = new System.Drawing.Point(570, 63);
            this.txtClient.Name = "txtClient";
            this.txtClient.PlaceholderText = "";
            this.txtClient.SelectedText = "";
            this.txtClient.Size = new System.Drawing.Size(220, 23);
            this.txtClient.TabIndex = 2;
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.Color.Transparent;
            this.txtLocation.BorderRadius = 5;
            this.txtLocation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLocation.DefaultText = "";
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLocation.Location = new System.Drawing.Point(885, 63);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.PlaceholderText = "";
            this.txtLocation.SelectedText = "";
            this.txtLocation.Size = new System.Drawing.Size(230, 23);
            this.txtLocation.TabIndex = 3;
            // 
            // lblProject
            // 
            this.lblProject.BackColor = System.Drawing.Color.Transparent;
            this.lblProject.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProject.ForeColor = System.Drawing.Color.Black;
            this.lblProject.Location = new System.Drawing.Point(15, 66);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(49, 23);
            this.lblProject.TabIndex = 4;
            this.lblProject.Text = "Project";
            // 
            // lblCode
            // 
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.Black;
            this.lblCode.Location = new System.Drawing.Point(340, 66);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(50, 23);
            this.lblCode.TabIndex = 5;
            this.lblCode.Text = "Code";
            // 
            // lblClient
            // 
            this.lblClient.BackColor = System.Drawing.Color.Transparent;
            this.lblClient.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClient.ForeColor = System.Drawing.Color.Black;
            this.lblClient.Location = new System.Drawing.Point(520, 66);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(44, 23);
            this.lblClient.TabIndex = 6;
            this.lblClient.Text = "Client";
            // 
            // lblLocation
            // 
            this.lblLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.ForeColor = System.Drawing.Color.Black;
            this.lblLocation.Location = new System.Drawing.Point(820, 66);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(59, 23);
            this.lblLocation.TabIndex = 7;
            this.lblLocation.Text = "Location";
            // 
            // grpTeam
            // 
            this.grpTeam.Controls.Add(this.txtEmpCode);
            this.grpTeam.Controls.Add(this.txtEmpName);
            this.grpTeam.Controls.Add(this.cmbRole);
            this.grpTeam.Controls.Add(this.cmbZone);
            this.grpTeam.Controls.Add(this.txtMobile);
            this.grpTeam.Controls.Add(this.dtpJoinDate);
            this.grpTeam.Controls.Add(this.lblEmpCode);
            this.grpTeam.Controls.Add(this.lblEmpName);
            this.grpTeam.Controls.Add(this.lblRole);
            this.grpTeam.Controls.Add(this.lblZone);
            this.grpTeam.Controls.Add(this.lblMobile);
            this.grpTeam.Controls.Add(this.lblJoinDate);
            this.grpTeam.Controls.Add(this.btnAdd);
            this.grpTeam.Controls.Add(this.btnUpdate);
            this.grpTeam.Controls.Add(this.btnDelete);
            this.grpTeam.Controls.Add(this.btnClear);
            this.grpTeam.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTeam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpTeam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grpTeam.Location = new System.Drawing.Point(0, 128);
            this.grpTeam.Name = "grpTeam";
            this.grpTeam.Size = new System.Drawing.Size(1184, 155);
            this.grpTeam.TabIndex = 1;
            this.grpTeam.TabStop = false;
            this.grpTeam.Text = "Team Entry";
            // 
            // txtEmpCode
            // 
            this.txtEmpCode.BackColor = System.Drawing.Color.Transparent;
            this.txtEmpCode.BorderRadius = 5;
            this.txtEmpCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmpCode.DefaultText = "";
            this.txtEmpCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmpCode.Location = new System.Drawing.Point(15, 76);
            this.txtEmpCode.Name = "txtEmpCode";
            this.txtEmpCode.PlaceholderText = "";
            this.txtEmpCode.SelectedText = "";
            this.txtEmpCode.Size = new System.Drawing.Size(120, 23);
            this.txtEmpCode.TabIndex = 0;
            // 
            // txtEmpName
            // 
            this.txtEmpName.BackColor = System.Drawing.Color.Transparent;
            this.txtEmpName.BorderRadius = 5;
            this.txtEmpName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmpName.DefaultText = "";
            this.txtEmpName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmpName.Location = new System.Drawing.Point(160, 76);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.PlaceholderText = "";
            this.txtEmpName.SelectedText = "";
            this.txtEmpName.Size = new System.Drawing.Size(240, 23);
            this.txtEmpName.TabIndex = 1;
            // 
            // cmbRole
            // 
            this.cmbRole.BackColor = System.Drawing.Color.Transparent;
            this.cmbRole.BorderRadius = 5;
            this.cmbRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FocusedColor = System.Drawing.Color.Empty;
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbRole.ItemHeight = 18;
            this.cmbRole.Location = new System.Drawing.Point(430, 76);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(190, 24);
            this.cmbRole.TabIndex = 2;
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
            this.cmbZone.ItemHeight = 18;
            this.cmbZone.Location = new System.Drawing.Point(650, 76);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(140, 24);
            this.cmbZone.TabIndex = 3;
            // 
            // txtMobile
            // 
            this.txtMobile.BackColor = System.Drawing.Color.Transparent;
            this.txtMobile.BorderRadius = 5;
            this.txtMobile.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMobile.DefaultText = "";
            this.txtMobile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMobile.Location = new System.Drawing.Point(820, 76);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.PlaceholderText = "";
            this.txtMobile.SelectedText = "";
            this.txtMobile.Size = new System.Drawing.Size(130, 23);
            this.txtMobile.TabIndex = 4;
            // 
            // dtpJoinDate
            // 
            this.dtpJoinDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpJoinDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpJoinDate.Location = new System.Drawing.Point(980, 76);
            this.dtpJoinDate.Name = "dtpJoinDate";
            this.dtpJoinDate.Size = new System.Drawing.Size(150, 23);
            this.dtpJoinDate.TabIndex = 5;
            // 
            // lblEmpCode
            // 
            this.lblEmpCode.BackColor = System.Drawing.Color.Transparent;
            this.lblEmpCode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpCode.ForeColor = System.Drawing.Color.Black;
            this.lblEmpCode.Location = new System.Drawing.Point(15, 51);
            this.lblEmpCode.Name = "lblEmpCode";
            this.lblEmpCode.Size = new System.Drawing.Size(100, 23);
            this.lblEmpCode.TabIndex = 6;
            this.lblEmpCode.Text = "Emp Code";
            // 
            // lblEmpName
            // 
            this.lblEmpName.BackColor = System.Drawing.Color.Transparent;
            this.lblEmpName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpName.ForeColor = System.Drawing.Color.Black;
            this.lblEmpName.Location = new System.Drawing.Point(160, 51);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(100, 23);
            this.lblEmpName.TabIndex = 7;
            this.lblEmpName.Text = "Name";
            // 
            // lblRole
            // 
            this.lblRole.BackColor = System.Drawing.Color.Transparent;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.Black;
            this.lblRole.Location = new System.Drawing.Point(430, 51);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(100, 23);
            this.lblRole.TabIndex = 8;
            this.lblRole.Text = "Role";
            // 
            // lblZone
            // 
            this.lblZone.BackColor = System.Drawing.Color.Transparent;
            this.lblZone.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZone.ForeColor = System.Drawing.Color.Black;
            this.lblZone.Location = new System.Drawing.Point(650, 51);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(100, 23);
            this.lblZone.TabIndex = 9;
            this.lblZone.Text = "Zone";
            // 
            // lblMobile
            // 
            this.lblMobile.BackColor = System.Drawing.Color.Transparent;
            this.lblMobile.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobile.ForeColor = System.Drawing.Color.Black;
            this.lblMobile.Location = new System.Drawing.Point(820, 51);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(100, 23);
            this.lblMobile.TabIndex = 10;
            this.lblMobile.Text = "Mobile";
            // 
            // lblJoinDate
            // 
            this.lblJoinDate.BackColor = System.Drawing.Color.Transparent;
            this.lblJoinDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJoinDate.ForeColor = System.Drawing.Color.Black;
            this.lblJoinDate.Location = new System.Drawing.Point(980, 51);
            this.lblJoinDate.Name = "lblJoinDate";
            this.lblJoinDate.Size = new System.Drawing.Size(100, 23);
            this.lblJoinDate.TabIndex = 11;
            this.lblJoinDate.Text = "Join Date";
            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 5;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(300, 116);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BorderRadius = 5;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(400, 116);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 30);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BorderRadius = 5;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(500, 116);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BorderRadius = 5;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(600, 116);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 30);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvTeam
            // 
            this.dgvTeam.AllowUserToAddRows = false;
            this.dgvTeam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTeam.BackgroundColor = System.Drawing.Color.White;
            this.dgvTeam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTeam.Location = new System.Drawing.Point(0, 283);
            this.dgvTeam.Name = "dgvTeam";
            this.dgvTeam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeam.Size = new System.Drawing.Size(1184, 378);
            this.dgvTeam.TabIndex = 0;
            // 
            // headerUC1
            // 
            this.headerUC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(41)))), ((int)(((byte)(83)))));
            this.headerUC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerUC1.FormText = "";
            this.headerUC1.HeaderText = "";
            this.headerUC1.Location = new System.Drawing.Point(0, 0);
            this.headerUC1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.headerUC1.Name = "headerUC1";
            this.headerUC1.Size = new System.Drawing.Size(1184, 35);
            this.headerUC1.TabIndex = 239;
            // 
            // frmProjectTeamSupervisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.dgvTeam);
            this.Controls.Add(this.grpTeam);
            this.Controls.Add(this.grpProjectInfo);
            this.Controls.Add(this.headerUC1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProjectTeamSupervisor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Team / Supervisors";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmProjectTeamSupervisor_Load);
            this.grpProjectInfo.ResumeLayout(false);
            this.grpTeam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna2GroupBox grpProjectInfo;
        private Guna2ComboBox cmbProject;
        private Guna2TextBox txtProjectCode;
        private Guna2TextBox txtClient;
        private Guna2TextBox txtLocation;

        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblLocation;

        private Guna2GroupBox grpTeam;
        private Guna2TextBox txtEmpCode;
        private Guna2TextBox txtEmpName;
        private Guna2ComboBox cmbRole;
        private Guna2ComboBox cmbZone;
        private Guna2TextBox txtMobile;
        private System.Windows.Forms.DateTimePicker dtpJoinDate;

        private System.Windows.Forms.Label lblEmpCode;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblZone;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.Label lblJoinDate;

        private Guna2Button btnAdd;
        private Guna2Button btnUpdate;
        private Guna2Button btnDelete;
        private Guna2Button btnClear;

        private System.Windows.Forms.DataGridView dgvTeam;
        private HeaderUC headerUC1;
    }
}