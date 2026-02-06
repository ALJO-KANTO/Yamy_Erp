using Guna.UI2.WinForms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{
    partial class frmEngDashboard
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
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFormName = new Guna.UI2.WinForms.Guna2Button();
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(10, 100, 100);
            this.panelTop.Controls.Add(this.lblFormName);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top; // <-- dock top
            this.panelTop.Height = 50; // set the height you want
            this.panelTop.Name = "panelTop";
            this.panelTop.TabIndex = 1;
            // 
            // lblFormName
            // 
            this.lblFormName.BackColor = System.Drawing.Color.Transparent;
            this.lblFormName.BorderColor = System.Drawing.Color.White;
            this.lblFormName.Dock = System.Windows.Forms.DockStyle.Fill; // fills panelTop
            this.lblFormName.FillColor = System.Drawing.Color.Transparent;
            this.lblFormName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblFormName.ForeColor = System.Drawing.Color.White;
            this.lblFormName.Text = "Engineering Consultancy Dashboard";
            this.lblFormName.TabIndex = 4;
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill; // <-- fills remaining space
            this.panelMain.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20); // padding inside for cards
            this.panelMain.Name = "panelMain";
            this.panelMain.TabIndex = 2;
            // 
            // frmEngDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 718);
            this.Controls.Add(this.panelMain); // add main panel first so top panel is above
            this.Controls.Add(this.panelTop);  // top panel
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEngDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Engineering Consultancy Dashboard";
            this.Load += new System.EventHandler(this.frmEngDashboard_Load);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Guna2Panel panelTop;
        private Guna2Button lblFormName;
        private Guna2Panel panelMain;
    }
}