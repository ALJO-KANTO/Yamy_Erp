namespace YamyProject.UI.Default
{
    partial class frmSplashScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplashScreen));
            this.gunaProgressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2CircleProgressBar1 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.SuspendLayout();
            // 
            // gunaProgressBar
            // 
            this.gunaProgressBar.BorderRadius = 5;
            this.gunaProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gunaProgressBar.Location = new System.Drawing.Point(0, 484);
            this.gunaProgressBar.Name = "gunaProgressBar";
            this.gunaProgressBar.ProgressColor = System.Drawing.Color.LightCyan;
            this.gunaProgressBar.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(41)))), ((int)(((byte)(83)))));
            this.gunaProgressBar.Size = new System.Drawing.Size(404, 14);
            this.gunaProgressBar.TabIndex = 0;
            this.gunaProgressBar.Text = "guna2ProgressBar1";
            this.gunaProgressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblStatus.Location = new System.Drawing.Point(171, 442);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(54, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Loading...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2AnimateWindow1
            // 
            this.guna2AnimateWindow1.TargetForm = this;
            // 
            // guna2CircleProgressBar1
            // 
            this.guna2CircleProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CircleProgressBar1.Animated = true;
            this.guna2CircleProgressBar1.AnimationSpeed = 0.5F;
            this.guna2CircleProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleProgressBar1.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleProgressBar1.FillThickness = 15;
            this.guna2CircleProgressBar1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.guna2CircleProgressBar1.ForeColor = System.Drawing.Color.Transparent;
            this.guna2CircleProgressBar1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.guna2CircleProgressBar1.Location = new System.Drawing.Point(166, 368);
            this.guna2CircleProgressBar1.Minimum = 0;
            this.guna2CircleProgressBar1.Name = "guna2CircleProgressBar1";
            this.guna2CircleProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(41)))), ((int)(((byte)(83)))));
            this.guna2CircleProgressBar1.ProgressColor2 = System.Drawing.Color.LightCyan;
            this.guna2CircleProgressBar1.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.guna2CircleProgressBar1.ProgressThickness = 15;
            this.guna2CircleProgressBar1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleProgressBar1.Size = new System.Drawing.Size(71, 71);
            this.guna2CircleProgressBar1.TabIndex = 2;
            this.guna2CircleProgressBar1.Value = 90;
            // 
            // frmSplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::YamyProject.Properties.Resources.YAMY_Splash;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(404, 498);
            this.Controls.Add(this.guna2CircleProgressBar1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.gunaProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSplashScreen";
            this.Load += new System.EventHandler(this.frmSplashScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ProgressBar gunaProgressBar;
        private System.Windows.Forms.Label lblStatus;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2CircleProgressBar guna2CircleProgressBar1;
    }
}