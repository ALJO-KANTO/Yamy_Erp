using Guna.UI2.WinForms;

namespace YamyProject.UI.Settings.Company
{
    partial class frmDocCenter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocCenter));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.btnRemove = new Guna.UI2.WinForms.Guna2Button();
            this.btnOpen = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddDocument = new Guna.UI2.WinForms.Guna2Button();
            this.BtnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grpInfo = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblFileType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtKeywords = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtComments = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblKeywords = new System.Windows.Forms.Label();
            this.lblComments = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvDocuments = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvVouchers = new Guna.UI2.WinForms.Guna2DataGridView();
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
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.file_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.file_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uploaded_on = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vVoucherType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vrefId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vFileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vAdded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headerUC1 = new YamyProject.HeaderUC();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVouchers)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1190, 564);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvVouchers);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1182, 538);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vouchers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1182, 538);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Company Documents";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 532);
            this.panel1.TabIndex = 3;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.LightGray;
            this.pnlTop.Controls.Add(this.BtnUpdate);
            this.pnlTop.Controls.Add(this.btnAddDocument);
            this.pnlTop.Controls.Add(this.btnOpen);
            this.pnlTop.Controls.Add(this.btnRemove);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1176, 50);
            this.pnlTop.TabIndex = 2;
            // 
            // btnRemove
            // 
            this.btnRemove.BorderRadius = 5;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(230, 10);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(80, 30);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            // 
            // btnOpen
            // 
            this.btnOpen.BorderRadius = 5;
            this.btnOpen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Location = new System.Drawing.Point(140, 10);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(80, 30);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            // 
            // btnAddDocument
            // 
            this.btnAddDocument.BorderRadius = 5;
            this.btnAddDocument.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddDocument.ForeColor = System.Drawing.Color.White;
            this.btnAddDocument.Location = new System.Drawing.Point(10, 10);
            this.btnAddDocument.Name = "btnAddDocument";
            this.btnAddDocument.Size = new System.Drawing.Size(120, 30);
            this.btnAddDocument.TabIndex = 0;
            this.btnAddDocument.Text = "Add Document";
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BorderRadius = 5;
            this.BtnUpdate.Enabled = false;
            this.BtnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnUpdate.Location = new System.Drawing.Point(320, 10);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(80, 30);
            this.BtnUpdate.TabIndex = 3;
            this.BtnUpdate.Text = "Update";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grpInfo);
            this.panel3.Controls.Add(this.pnlTop);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1176, 261);
            this.panel3.TabIndex = 11;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lblFileType);
            this.grpInfo.Controls.Add(this.label1);
            this.grpInfo.Controls.Add(this.txtTitle);
            this.grpInfo.Controls.Add(this.txtDescription);
            this.grpInfo.Controls.Add(this.txtKeywords);
            this.grpInfo.Controls.Add(this.txtComments);
            this.grpInfo.Controls.Add(this.lblTitle);
            this.grpInfo.Controls.Add(this.lblDescription);
            this.grpInfo.Controls.Add(this.lblKeywords);
            this.grpInfo.Controls.Add(this.lblComments);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grpInfo.Location = new System.Drawing.Point(0, 50);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(1176, 211);
            this.grpInfo.TabIndex = 3;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Document Information";
            // 
            // lblFileType
            // 
            this.lblFileType.Location = new System.Drawing.Point(570, 48);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(508, 23);
            this.lblFileType.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(506, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "File Name:";
            // 
            // txtTitle
            // 
            this.txtTitle.BorderRadius = 5;
            this.txtTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTitle.DefaultText = "";
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTitle.Location = new System.Drawing.Point(100, 48);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.PlaceholderText = "";
            this.txtTitle.SelectedText = "";
            this.txtTitle.Size = new System.Drawing.Size(400, 26);
            this.txtTitle.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderRadius = 5;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescription.Location = new System.Drawing.Point(100, 78);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "";
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(400, 40);
            this.txtDescription.TabIndex = 3;
            // 
            // txtKeywords
            // 
            this.txtKeywords.BorderRadius = 5;
            this.txtKeywords.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKeywords.DefaultText = "";
            this.txtKeywords.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtKeywords.Location = new System.Drawing.Point(100, 123);
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.PlaceholderText = "";
            this.txtKeywords.SelectedText = "";
            this.txtKeywords.Size = new System.Drawing.Size(400, 26);
            this.txtKeywords.TabIndex = 5;
            // 
            // txtComments
            // 
            this.txtComments.BorderRadius = 5;
            this.txtComments.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtComments.DefaultText = "";
            this.txtComments.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtComments.Location = new System.Drawing.Point(100, 153);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.PlaceholderText = "";
            this.txtComments.SelectedText = "";
            this.txtComments.Size = new System.Drawing.Size(400, 40);
            this.txtComments.TabIndex = 7;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(10, 51);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(10, 81);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 23);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            // 
            // lblKeywords
            // 
            this.lblKeywords.Location = new System.Drawing.Point(10, 126);
            this.lblKeywords.Name = "lblKeywords";
            this.lblKeywords.Size = new System.Drawing.Size(100, 23);
            this.lblKeywords.TabIndex = 4;
            this.lblKeywords.Text = "Keywords:";
            // 
            // lblComments
            // 
            this.lblComments.Location = new System.Drawing.Point(10, 156);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(100, 23);
            this.lblComments.TabIndex = 6;
            this.lblComments.Text = "Comments:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvDocuments);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 261);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1176, 271);
            this.panel4.TabIndex = 12;
            // 
            // dgvDocuments
            // 
            this.dgvDocuments.AllowUserToAddRows = false;
            this.dgvDocuments.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDocuments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocuments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDocuments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.file_name,
            this.title,
            this.description,
            this.file_type,
            this.uploaded_on,
            this.comments});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocuments.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocuments.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDocuments.Location = new System.Drawing.Point(0, 0);
            this.dgvDocuments.MultiSelect = false;
            this.dgvDocuments.Name = "dgvDocuments";
            this.dgvDocuments.ReadOnly = true;
            this.dgvDocuments.RowHeadersVisible = false;
            this.dgvDocuments.Size = new System.Drawing.Size(1176, 271);
            this.dgvDocuments.TabIndex = 2;
            this.dgvDocuments.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDocuments.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDocuments.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDocuments.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDocuments.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDocuments.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDocuments.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDocuments.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDocuments.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDocuments.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDocuments.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDocuments.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDocuments.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvDocuments.ThemeStyle.ReadOnly = true;
            this.dgvDocuments.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDocuments.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDocuments.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDocuments.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDocuments.ThemeStyle.RowsStyle.Height = 22;
            this.dgvDocuments.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDocuments.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dgvVouchers
            // 
            this.dgvVouchers.AllowUserToAddRows = false;
            this.dgvVouchers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvVouchers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVouchers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvVouchers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vId,
            this.vVoucherType,
            this.vrefId,
            this.vFileName,
            this.vFileType,
            this.vAdded});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVouchers.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvVouchers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVouchers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvVouchers.Location = new System.Drawing.Point(3, 3);
            this.dgvVouchers.MultiSelect = false;
            this.dgvVouchers.Name = "dgvVouchers";
            this.dgvVouchers.ReadOnly = true;
            this.dgvVouchers.RowHeadersVisible = false;
            this.dgvVouchers.Size = new System.Drawing.Size(1176, 532);
            this.dgvVouchers.TabIndex = 3;
            this.dgvVouchers.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvVouchers.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvVouchers.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvVouchers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvVouchers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvVouchers.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvVouchers.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvVouchers.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvVouchers.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVouchers.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvVouchers.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvVouchers.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVouchers.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvVouchers.ThemeStyle.ReadOnly = true;
            this.dgvVouchers.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvVouchers.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvVouchers.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvVouchers.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvVouchers.ThemeStyle.RowsStyle.Height = 22;
            this.dgvVouchers.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvVouchers.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvVouchers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 118.7817F;
            this.dataGridViewTextBoxColumn2.HeaderText = "NAME";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 471;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 81.21828F;
            this.dataGridViewTextBoxColumn3.HeaderText = "TYPE";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 322;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "ADDED";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 397;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.FillWeight = 81.21828F;
            this.dataGridViewTextBoxColumn5.HeaderText = "TYPE";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 193;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "ADDED";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 238;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "comments";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "id";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.FillWeight = 81.21828F;
            this.dataGridViewTextBoxColumn9.HeaderText = "Voucher Name";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 191;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.FillWeight = 118.7817F;
            this.dataGridViewTextBoxColumn10.HeaderText = "Ref Id";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 279;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "File Name";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 236;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "FileType";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 235;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Added";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 235;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // file_name
            // 
            this.file_name.FillWeight = 118.7817F;
            this.file_name.HeaderText = "Name";
            this.file_name.Name = "file_name";
            this.file_name.ReadOnly = true;
            // 
            // title
            // 
            this.title.HeaderText = "Title";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // description
            // 
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // file_type
            // 
            this.file_type.FillWeight = 81.21828F;
            this.file_type.HeaderText = "Type";
            this.file_type.Name = "file_type";
            this.file_type.ReadOnly = true;
            // 
            // uploaded_on
            // 
            this.uploaded_on.HeaderText = "Added";
            this.uploaded_on.Name = "uploaded_on";
            this.uploaded_on.ReadOnly = true;
            // 
            // comments
            // 
            this.comments.HeaderText = "comments";
            this.comments.Name = "comments";
            this.comments.ReadOnly = true;
            this.comments.Visible = false;
            // 
            // vId
            // 
            this.vId.HeaderText = "id";
            this.vId.Name = "vId";
            this.vId.ReadOnly = true;
            this.vId.Visible = false;
            // 
            // vVoucherType
            // 
            this.vVoucherType.FillWeight = 81.21828F;
            this.vVoucherType.HeaderText = "Voucher Name";
            this.vVoucherType.Name = "vVoucherType";
            this.vVoucherType.ReadOnly = true;
            // 
            // vrefId
            // 
            this.vrefId.FillWeight = 118.7817F;
            this.vrefId.HeaderText = "Ref Id";
            this.vrefId.Name = "vrefId";
            this.vrefId.ReadOnly = true;
            // 
            // vFileName
            // 
            this.vFileName.HeaderText = "File Name";
            this.vFileName.Name = "vFileName";
            this.vFileName.ReadOnly = true;
            // 
            // vFileType
            // 
            this.vFileType.HeaderText = "FileType";
            this.vFileType.Name = "vFileType";
            this.vFileType.ReadOnly = true;
            // 
            // vAdded
            // 
            this.vAdded.HeaderText = "Added";
            this.vAdded.Name = "vAdded";
            this.vAdded.ReadOnly = true;
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
            this.headerUC1.Size = new System.Drawing.Size(1190, 30);
            this.headerUC1.TabIndex = 239;
            // 
            // frmDocCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1190, 594);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.headerUC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDocCenter";
            this.Text = "Doc Center";
            this.Load += new System.EventHandler(this.frmDocCenter_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVouchers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private HeaderUC headerUC1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private Guna2DataGridView dgvDocuments;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn uploaded_on;
        private System.Windows.Forms.DataGridViewTextBoxColumn comments;
        private System.Windows.Forms.Panel panel3;
        private Guna2GroupBox grpInfo;
        private System.Windows.Forms.Label lblFileType;
        private System.Windows.Forms.Label label1;
        private Guna2TextBox txtTitle;
        private Guna2TextBox txtDescription;
        private Guna2TextBox txtKeywords;
        private Guna2TextBox txtComments;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblKeywords;
        private System.Windows.Forms.Label lblComments;
        private Guna2Panel pnlTop;
        private Guna2Button BtnUpdate;
        private Guna2Button btnAddDocument;
        private Guna2Button btnOpen;
        private Guna2Button btnRemove;
        private Guna2DataGridView dgvVouchers;
        private System.Windows.Forms.DataGridViewTextBoxColumn vId;
        private System.Windows.Forms.DataGridViewTextBoxColumn vVoucherType;
        private System.Windows.Forms.DataGridViewTextBoxColumn vrefId;
        private System.Windows.Forms.DataGridViewTextBoxColumn vFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn vFileType;
        private System.Windows.Forms.DataGridViewTextBoxColumn vAdded;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
    }
}
