using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.Design_Management.Docs
{
    partial class frmEngDocumentUpload
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblDocumentName;
        private Guna2TextBox txtDocumentName;
        private Label lblType;
        private Guna2ComboBox cmbType;
        private Label lblVersion;
        private Guna2TextBox txtVersion;
        private Label lblFile;
        private Guna2TextBox txtFilePath;
        private Guna2Button btnBrowse;
        private Guna2Button btnUpload;
        private Guna2Button btnCancel;

        // Hidden fields
        public int ProjectId { get; set; }
        public int PhaseId { get; set; }

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
            this.lblDocumentName = new System.Windows.Forms.Label();
            this.txtDocumentName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtVersion = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.txtFilePath = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnBrowse = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpload = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormName = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDocumentName
            // 
            this.lblDocumentName.Location = new System.Drawing.Point(20, 42);
            this.lblDocumentName.Name = "lblDocumentName";
            this.lblDocumentName.Size = new System.Drawing.Size(100, 23);
            this.lblDocumentName.TabIndex = 0;
            this.lblDocumentName.Text = "Document Name:";
            // 
            // txtDocumentName
            // 
            this.txtDocumentName.BorderRadius = 5;
            this.txtDocumentName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDocumentName.DefaultText = "";
            this.txtDocumentName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDocumentName.Location = new System.Drawing.Point(150, 38);
            this.txtDocumentName.Name = "txtDocumentName";
            this.txtDocumentName.PlaceholderText = "";
            this.txtDocumentName.SelectedText = "";
            this.txtDocumentName.Size = new System.Drawing.Size(300, 24);
            this.txtDocumentName.TabIndex = 1;
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(20, 82);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(100, 23);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type:";
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
            this.cmbType.Items.AddRange(new object[] {
            "Drawing",
            "Specification",
            "Report",
            "Other"});
            this.cmbType.Location = new System.Drawing.Point(150, 78);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(200, 28);
            this.cmbType.TabIndex = 3;
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(20, 122);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(100, 23);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "Version:";
            // 
            // txtVersion
            // 
            this.txtVersion.BorderRadius = 5;
            this.txtVersion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVersion.DefaultText = "1.0";
            this.txtVersion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtVersion.Location = new System.Drawing.Point(150, 118);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.PlaceholderText = "";
            this.txtVersion.SelectedText = "";
            this.txtVersion.Size = new System.Drawing.Size(100, 24);
            this.txtVersion.TabIndex = 5;
            // 
            // lblFile
            // 
            this.lblFile.Location = new System.Drawing.Point(20, 162);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(100, 23);
            this.lblFile.TabIndex = 6;
            this.lblFile.Text = "Select File:";
            // 
            // txtFilePath
            // 
            this.txtFilePath.BorderRadius = 5;
            this.txtFilePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilePath.DefaultText = "";
            this.txtFilePath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFilePath.Location = new System.Drawing.Point(150, 158);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.PlaceholderText = "";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.SelectedText = "";
            this.txtFilePath.Size = new System.Drawing.Size(200, 24);
            this.txtFilePath.TabIndex = 7;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BorderRadius = 5;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(360, 158);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 24);
            this.btnBrowse.TabIndex = 8;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.BorderRadius = 5;
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.Location = new System.Drawing.Point(150, 222);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(100, 30);
            this.btnUpload.TabIndex = 9;
            this.btnUpload.Text = "Upload";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(270, 222);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 10;
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
            this.panel1.TabIndex = 25;
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
            this.lblFormName.Text = "Upload Document";
            // 
            // frmEngDocumentUpload
            // 
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDocumentName);
            this.Controls.Add(this.txtDocumentName);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmEngDocumentUpload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Upload Document";
            this.Load += new System.EventHandler(this.frmDocumentUpload_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Guna2Button lblFormName;
    }
}