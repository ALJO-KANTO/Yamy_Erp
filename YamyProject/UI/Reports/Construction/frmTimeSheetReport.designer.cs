namespace YamyProject
{
    partial class frmTimeSheetReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.headerUC1 = new YamyProject.HeaderUC();
            this.dgvReport = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblCompany = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnExcel = new Guna.UI2.WinForms.Guna2TileButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelMobile = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(2, 600);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1211, 2);
            this.panel5.TabIndex = 14;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1213, 37);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(2, 565);
            this.panel6.TabIndex = 13;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 37);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(2, 565);
            this.panel7.TabIndex = 12;
            // 
            // headerUC1
            // 
            this.headerUC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.headerUC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerUC1.FormText = "";
            this.headerUC1.HeaderText = "";
            this.headerUC1.Location = new System.Drawing.Point(0, 0);
            this.headerUC1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.headerUC1.Name = "headerUC1";
            this.headerUC1.Size = new System.Drawing.Size(1215, 37);
            this.headerUC1.TabIndex = 0;
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dgvReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvReport.ColumnHeadersHeight = 30;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReport.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReport.Location = new System.Drawing.Point(0, 0);
            this.dgvReport.MultiSelect = false;
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.RowTemplate.Height = 30;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvReport.Size = new System.Drawing.Size(1211, 411);
            this.dgvReport.TabIndex = 25;
            this.dgvReport.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvReport.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvReport.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvReport.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvReport.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvReport.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvReport.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReport.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Silver;
            this.dgvReport.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvReport.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReport.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReport.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvReport.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvReport.ThemeStyle.ReadOnly = true;
            this.dgvReport.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvReport.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvReport.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.dgvReport.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvReport.ThemeStyle.RowsStyle.Height = 30;
            this.dgvReport.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReport.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // lblCompany
            // 
            this.lblCompany.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCompany.AutoSize = false;
            this.lblCompany.BackColor = System.Drawing.Color.Transparent;
            this.lblCompany.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.Black;
            this.lblCompany.Location = new System.Drawing.Point(462, 11);
            this.lblCompany.Margin = new System.Windows.Forms.Padding(2);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(183, 18);
            this.lblCompany.TabIndex = 21;
            this.lblCompany.Text = "Company Name";
            this.lblCompany.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2HtmlLabel7.AutoSize = false;
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel7.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(462, 33);
            this.guna2HtmlLabel7.Margin = new System.Windows.Forms.Padding(2);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(183, 18);
            this.guna2HtmlLabel7.TabIndex = 20;
            this.guna2HtmlLabel7.Text = "Time Sheet";
            this.guna2HtmlLabel7.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(507, 77);
            this.lblDate.Margin = new System.Windows.Forms.Padding(2);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(51, 14);
            this.lblDate.TabIndex = 24;
            this.lblDate.Text = "28/03/2025";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Black;
            this.lblTime.Location = new System.Drawing.Point(574, 77);
            this.lblTime.Margin = new System.Windows.Forms.Padding(2);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(25, 14);
            this.lblTime.TabIndex = 23;
            this.lblTime.Text = "05:00";
            // 
            // guna2HtmlLabel10
            // 
            this.guna2HtmlLabel10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2HtmlLabel10.AutoSize = false;
            this.guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel10.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel10.Location = new System.Drawing.Point(462, 56);
            this.guna2HtmlLabel10.Margin = new System.Windows.Forms.Padding(2);
            this.guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            this.guna2HtmlLabel10.Size = new System.Drawing.Size(183, 18);
            this.guna2HtmlLabel10.TabIndex = 22;
            this.guna2HtmlLabel10.Text = "All Transaction";
            this.guna2HtmlLabel10.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelMobile);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.lblCompany);
            this.panel1.Controls.Add(this.guna2HtmlLabel10);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.guna2HtmlLabel7);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1211, 152);
            this.panel1.TabIndex = 26;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BorderColor = System.Drawing.Color.Transparent;
            this.btnPrint.BorderRadius = 10;
            this.btnPrint.BorderThickness = 2;
            this.btnPrint.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnPrint.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrint.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrint.FillColor = System.Drawing.Color.Transparent;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnPrint.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.btnPrint.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnPrint.Image = global::YamyProject.Properties.Resources.printN;
            this.btnPrint.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPrint.ImageOffset = new System.Drawing.Point(-10, 10);
            this.btnPrint.Location = new System.Drawing.Point(43, 11);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(22, 23);
            this.btnPrint.TabIndex = 42;
            this.btnPrint.Text = " ";
            this.btnPrint.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPrint.TextOffset = new System.Drawing.Point(10, -12);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnExcel.BorderColor = System.Drawing.Color.Transparent;
            this.btnExcel.BorderRadius = 10;
            this.btnExcel.BorderThickness = 2;
            this.btnExcel.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExcel.FillColor = System.Drawing.Color.Transparent;
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnExcel.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.btnExcel.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnExcel.Image = global::YamyProject.Properties.Resources.excel___Copy;
            this.btnExcel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnExcel.ImageOffset = new System.Drawing.Point(-10, 10);
            this.btnExcel.Location = new System.Drawing.Point(15, 11);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(22, 23);
            this.btnExcel.TabIndex = 41;
            this.btnExcel.Text = " ";
            this.btnExcel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnExcel.TextOffset = new System.Drawing.Point(10, -12);
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvReport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 189);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1211, 411);
            this.panel2.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 107);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "         Labor Name : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "            Mobile No :";
            // 
            // labelMobile
            // 
            this.labelMobile.AutoSize = true;
            this.labelMobile.Location = new System.Drawing.Point(106, 129);
            this.labelMobile.Name = "labelMobile";
            this.labelMobile.Size = new System.Drawing.Size(35, 13);
            this.labelMobile.TabIndex = 46;
            this.labelMobile.Text = "label3";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(106, 107);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 45;
            this.labelName.Text = "label4";
            // 
            // frmTimeSheetReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1215, 602);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.headerUC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmTimeSheetReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "main";
            this.Text = "Project Resource Report";
            this.Load += new System.EventHandler(this.frmTimeSheetReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private HeaderUC headerUC1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private Guna.UI2.WinForms.Guna2DataGridView dgvReport;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCompany;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTime;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2TileButton btnPrint;
        private Guna.UI2.WinForms.Guna2TileButton btnExcel;
        private System.Windows.Forms.Label labelMobile;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}