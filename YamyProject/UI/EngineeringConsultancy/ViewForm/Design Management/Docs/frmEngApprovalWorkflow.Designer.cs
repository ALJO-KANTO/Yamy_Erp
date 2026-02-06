using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.Design_Management.Docs
{
    partial class frmEngApprovalWorkflow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblDocument;
        private Guna2TextBox txtDocumentName;
        private Label lblStatus;
        private Guna2ComboBox cmbStatus;
        private Label lblRemarks;
        private Guna2TextBox txtRemarks;
        private Guna2Button btnApprove;
        private Guna2Button btnReject;
        private Guna2Button btnClose;

        // Hidden field
        public int DocumentId { get; set; }

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
            this.lblDocument = new System.Windows.Forms.Label();
            this.txtDocumentName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnApprove = new Guna.UI2.WinForms.Guna2Button();
            this.btnReject = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormName = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDocument
            // 
            this.lblDocument.Location = new System.Drawing.Point(20, 63);
            this.lblDocument.Name = "lblDocument";
            this.lblDocument.Size = new System.Drawing.Size(100, 23);
            this.lblDocument.TabIndex = 0;
            this.lblDocument.Text = "Document:";
            // 
            // txtDocumentName
            // 
            this.txtDocumentName.BorderRadius = 5;
            this.txtDocumentName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDocumentName.DefaultText = "";
            this.txtDocumentName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDocumentName.Location = new System.Drawing.Point(120, 59);
            this.txtDocumentName.Name = "txtDocumentName";
            this.txtDocumentName.PlaceholderText = "";
            this.txtDocumentName.ReadOnly = true;
            this.txtDocumentName.SelectedText = "";
            this.txtDocumentName.Size = new System.Drawing.Size(320, 24);
            this.txtDocumentName.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(20, 103);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
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
            this.cmbStatus.Items.AddRange(new object[] {
            "Approved",
            "Rejected"});
            this.cmbStatus.Location = new System.Drawing.Point(120, 99);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 28);
            this.cmbStatus.TabIndex = 3;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Location = new System.Drawing.Point(20, 143);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(100, 23);
            this.lblRemarks.TabIndex = 4;
            this.lblRemarks.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderRadius = 5;
            this.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRemarks.DefaultText = "";
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRemarks.Location = new System.Drawing.Point(120, 139);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.PlaceholderText = "";
            this.txtRemarks.SelectedText = "";
            this.txtRemarks.Size = new System.Drawing.Size(320, 100);
            this.txtRemarks.TabIndex = 5;
            // 
            // btnApprove
            // 
            this.btnApprove.BorderRadius = 5;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(120, 263);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(100, 30);
            this.btnApprove.TabIndex = 6;
            this.btnApprove.Text = "Approve";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.BorderRadius = 5;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(240, 263);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(100, 30);
            this.btnReject.TabIndex = 7;
            this.btnReject.Text = "Reject";
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 5;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(360, 263);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.lblFormName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 29);
            this.panel1.TabIndex = 23;
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
            this.lblFormName.Text = "Approval Workflow";
            // 
            // frmEngApprovalWorkflow
            // 
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDocument);
            this.Controls.Add(this.txtDocumentName);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmEngApprovalWorkflow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Approval Workflow";
            this.Load += new System.EventHandler(this.frmEngApprovalWorkflow_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Guna2Button lblFormName;
    }
}