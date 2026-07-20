using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.Settings
{
    partial class frmSyncData
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblLastSync;
        private DateTimePicker dtpLastSync;
        private ProgressBar progressBar1;
        private Label lblStatus;
        private Button btnStartSync;

        private void InitializeComponent()
        {
            this.lblLastSync = new System.Windows.Forms.Label();
            this.dtpLastSync = new System.Windows.Forms.DateTimePicker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStartSync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLastSync
            // 
            this.lblLastSync.AutoSize = true;
            this.lblLastSync.Location = new System.Drawing.Point(17, 17);
            this.lblLastSync.Name = "lblLastSync";
            this.lblLastSync.Size = new System.Drawing.Size(54, 13);
            this.lblLastSync.TabIndex = 0;
            this.lblLastSync.Text = "Last Sync";
            // 
            // dtpLastSync
            // 
            this.dtpLastSync.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dtpLastSync.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLastSync.Location = new System.Drawing.Point(17, 39);
            this.dtpLastSync.Name = "dtpLastSync";
            this.dtpLastSync.Size = new System.Drawing.Size(258, 20);
            this.dtpLastSync.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(17, 104);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(386, 22);
            this.progressBar1.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(17, 78);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Ready";
            // 
            // btnStartSync
            // 
            this.btnStartSync.Location = new System.Drawing.Point(154, 147);
            this.btnStartSync.Name = "btnStartSync";
            this.btnStartSync.Size = new System.Drawing.Size(103, 30);
            this.btnStartSync.TabIndex = 4;
            this.btnStartSync.Text = "Start Sync";
            this.btnStartSync.Click += new System.EventHandler(this.btnStartSync_Click);
            // 
            // frmSyncData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 199);
            this.Controls.Add(this.lblLastSync);
            this.Controls.Add(this.dtpLastSync);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnStartSync);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSyncData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Synchronization";
            this.Load += new System.EventHandler(this.frmSyncData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}