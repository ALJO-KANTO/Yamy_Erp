using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.Project_Management
{
    partial class frmSiteDiary
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
            this.lblDiaryNo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.lblSite = new System.Windows.Forms.Label();
            this.lblZone = new System.Windows.Forms.Label();
            this.lblEngineer = new System.Windows.Forms.Label();
            this.lblWeather = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtDiaryNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbSite = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbZone = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbEngineer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbWeather = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblWorkDone = new System.Windows.Forms.Label();
            this.lblVisitors = new System.Windows.Forms.Label();
            this.lblIssues = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtWorkDone = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtVisitors = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIssues = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtRemarks = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDiaryNo
            // 
            this.lblDiaryNo.AutoSize = true;
            this.lblDiaryNo.Location = new System.Drawing.Point(20, 20);
            this.lblDiaryNo.Name = "lblDiaryNo";
            this.lblDiaryNo.Size = new System.Drawing.Size(48, 13);
            this.lblDiaryNo.TabIndex = 8;
            this.lblDiaryNo.Text = "Diary No";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(450, 20);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 9;
            this.lblDate.Text = "Date";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(20, 60);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(40, 13);
            this.lblProject.TabIndex = 10;
            this.lblProject.Text = "Project";
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Location = new System.Drawing.Point(450, 60);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(25, 13);
            this.lblSite.TabIndex = 11;
            this.lblSite.Text = "Site";
            // 
            // lblZone
            // 
            this.lblZone.AutoSize = true;
            this.lblZone.Location = new System.Drawing.Point(20, 100);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(32, 13);
            this.lblZone.TabIndex = 12;
            this.lblZone.Text = "Zone";
            // 
            // lblEngineer
            // 
            this.lblEngineer.AutoSize = true;
            this.lblEngineer.Location = new System.Drawing.Point(450, 100);
            this.lblEngineer.Name = "lblEngineer";
            this.lblEngineer.Size = new System.Drawing.Size(49, 13);
            this.lblEngineer.TabIndex = 13;
            this.lblEngineer.Text = "Engineer";
            // 
            // lblWeather
            // 
            this.lblWeather.AutoSize = true;
            this.lblWeather.Location = new System.Drawing.Point(20, 140);
            this.lblWeather.Name = "lblWeather";
            this.lblWeather.Size = new System.Drawing.Size(48, 13);
            this.lblWeather.TabIndex = 14;
            this.lblWeather.Text = "Weather";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(450, 140);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "Status";
            // 
            // txtDiaryNo
            // 
            this.txtDiaryNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiaryNo.DefaultText = "";
            this.txtDiaryNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiaryNo.Location = new System.Drawing.Point(120, 18);
            this.txtDiaryNo.Name = "txtDiaryNo";
            this.txtDiaryNo.PlaceholderText = "";
            this.txtDiaryNo.SelectedText = "";
            this.txtDiaryNo.Size = new System.Drawing.Size(250, 23);
            this.txtDiaryNo.TabIndex = 16;
            // 
            // dtDate
            // 
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(540, 18);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(150, 20);
            this.dtDate.TabIndex = 17;
            // 
            // cmbProject
            // 
            this.cmbProject.BackColor = System.Drawing.Color.Transparent;
            this.cmbProject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FocusedColor = System.Drawing.Color.Empty;
            this.cmbProject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbProject.ItemHeight = 30;
            this.cmbProject.Location = new System.Drawing.Point(120, 58);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(250, 36);
            this.cmbProject.TabIndex = 18;
            // 
            // cmbSite
            // 
            this.cmbSite.BackColor = System.Drawing.Color.Transparent;
            this.cmbSite.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSite.FocusedColor = System.Drawing.Color.Empty;
            this.cmbSite.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbSite.ItemHeight = 30;
            this.cmbSite.Location = new System.Drawing.Point(540, 58);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(250, 36);
            this.cmbSite.TabIndex = 19;
            // 
            // cmbZone
            // 
            this.cmbZone.BackColor = System.Drawing.Color.Transparent;
            this.cmbZone.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZone.FocusedColor = System.Drawing.Color.Empty;
            this.cmbZone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbZone.ItemHeight = 30;
            this.cmbZone.Location = new System.Drawing.Point(120, 98);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(250, 36);
            this.cmbZone.TabIndex = 20;
            // 
            // cmbEngineer
            // 
            this.cmbEngineer.BackColor = System.Drawing.Color.Transparent;
            this.cmbEngineer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEngineer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEngineer.FocusedColor = System.Drawing.Color.Empty;
            this.cmbEngineer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEngineer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbEngineer.ItemHeight = 30;
            this.cmbEngineer.Location = new System.Drawing.Point(540, 98);
            this.cmbEngineer.Name = "cmbEngineer";
            this.cmbEngineer.Size = new System.Drawing.Size(250, 36);
            this.cmbEngineer.TabIndex = 21;
            // 
            // cmbWeather
            // 
            this.cmbWeather.BackColor = System.Drawing.Color.Transparent;
            this.cmbWeather.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbWeather.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWeather.FocusedColor = System.Drawing.Color.Empty;
            this.cmbWeather.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbWeather.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbWeather.ItemHeight = 30;
            this.cmbWeather.Location = new System.Drawing.Point(120, 138);
            this.cmbWeather.Name = "cmbWeather";
            this.cmbWeather.Size = new System.Drawing.Size(250, 36);
            this.cmbWeather.TabIndex = 22;
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FocusedColor = System.Drawing.Color.Empty;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbStatus.ItemHeight = 30;
            this.cmbStatus.Location = new System.Drawing.Point(540, 138);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 36);
            this.cmbStatus.TabIndex = 23;
            // 
            // lblWorkDone
            // 
            this.lblWorkDone.AutoSize = true;
            this.lblWorkDone.Location = new System.Drawing.Point(20, 185);
            this.lblWorkDone.Name = "lblWorkDone";
            this.lblWorkDone.Size = new System.Drawing.Size(62, 13);
            this.lblWorkDone.TabIndex = 0;
            this.lblWorkDone.Text = "Work Done";
            // 
            // lblVisitors
            // 
            this.lblVisitors.AutoSize = true;
            this.lblVisitors.Location = new System.Drawing.Point(20, 315);
            this.lblVisitors.Name = "lblVisitors";
            this.lblVisitors.Size = new System.Drawing.Size(40, 13);
            this.lblVisitors.TabIndex = 1;
            this.lblVisitors.Text = "Visitors";
            // 
            // lblIssues
            // 
            this.lblIssues.AutoSize = true;
            this.lblIssues.Location = new System.Drawing.Point(20, 415);
            this.lblIssues.Name = "lblIssues";
            this.lblIssues.Size = new System.Drawing.Size(110, 13);
            this.lblIssues.TabIndex = 2;
            this.lblIssues.Text = "Issues / Observations";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(20, 545);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(49, 13);
            this.lblRemarks.TabIndex = 3;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtWorkDone
            // 
            this.txtWorkDone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWorkDone.DefaultText = "";
            this.txtWorkDone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtWorkDone.Location = new System.Drawing.Point(20, 205);
            this.txtWorkDone.Multiline = true;
            this.txtWorkDone.Name = "txtWorkDone";
            this.txtWorkDone.PlaceholderText = "";
            this.txtWorkDone.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWorkDone.SelectedText = "";
            this.txtWorkDone.Size = new System.Drawing.Size(820, 90);
            this.txtWorkDone.TabIndex = 4;
            // 
            // txtVisitors
            // 
            this.txtVisitors.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVisitors.DefaultText = "";
            this.txtVisitors.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtVisitors.Location = new System.Drawing.Point(20, 335);
            this.txtVisitors.Multiline = true;
            this.txtVisitors.Name = "txtVisitors";
            this.txtVisitors.PlaceholderText = "";
            this.txtVisitors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtVisitors.SelectedText = "";
            this.txtVisitors.Size = new System.Drawing.Size(820, 60);
            this.txtVisitors.TabIndex = 5;
            // 
            // txtIssues
            // 
            this.txtIssues.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIssues.DefaultText = "";
            this.txtIssues.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIssues.Location = new System.Drawing.Point(20, 435);
            this.txtIssues.Multiline = true;
            this.txtIssues.Name = "txtIssues";
            this.txtIssues.PlaceholderText = "";
            this.txtIssues.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIssues.SelectedText = "";
            this.txtIssues.Size = new System.Drawing.Size(820, 90);
            this.txtIssues.TabIndex = 6;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRemarks.DefaultText = "";
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRemarks.Location = new System.Drawing.Point(20, 565);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.PlaceholderText = "";
            this.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemarks.SelectedText = "";
            this.txtRemarks.Size = new System.Drawing.Size(820, 70);
            this.txtRemarks.TabIndex = 7;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(220, 655);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 35);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(330, 655);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(440, 655);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(100, 35);
            this.btnApprove.TabIndex = 2;
            this.btnApprove.Text = "Approve";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(550, 655);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            // 
            // frmSiteDiary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 720);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblWorkDone);
            this.Controls.Add(this.lblVisitors);
            this.Controls.Add(this.lblIssues);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtWorkDone);
            this.Controls.Add(this.txtVisitors);
            this.Controls.Add(this.txtIssues);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblDiaryNo);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.lblSite);
            this.Controls.Add(this.lblZone);
            this.Controls.Add(this.lblEngineer);
            this.Controls.Add(this.lblWeather);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtDiaryNo);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.cmbSite);
            this.Controls.Add(this.cmbZone);
            this.Controls.Add(this.cmbEngineer);
            this.Controls.Add(this.cmbWeather);
            this.Controls.Add(this.cmbStatus);
            this.Name = "frmSiteDiary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Site Diary";
            this.Load += new System.EventHandler(this.frmSiteDiary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Controls

        private Label lblDiaryNo;
        private Label lblDate;
        private Label lblProject;
        private Label lblSite;
        private Label lblZone;
        private Label lblEngineer;
        private Label lblWeather;
        private Label lblStatus;

        private Guna2TextBox txtDiaryNo;

        private Guna2ComboBox cmbProject;
        private Guna2ComboBox cmbSite;
        private Guna2ComboBox cmbZone;
        private Guna2ComboBox cmbEngineer;
        private Guna2ComboBox cmbWeather;
        private Guna2ComboBox cmbStatus;

        private DateTimePicker dtDate;

        private Label lblWorkDone;
        private Label lblVisitors;
        private Label lblIssues;
        private Label lblRemarks;

        private Guna2TextBox txtWorkDone;
        private Guna2TextBox txtVisitors;
        private Guna2TextBox txtIssues;

        #endregion

        private Guna2TextBox txtRemarks;
        private Button btnNew;
        private Button btnSave;
        private Button btnApprove;
        private Button btnClose;
    }
}