using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.ProjectPhase
{
    partial class frmProjectPhasesNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Panel pnlTop;
        private Label lblProject;
        private TabControl tabPhases;
        private Button btnSave;

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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblProject = new System.Windows.Forms.Label();
            this.tabPhases = new System.Windows.Forms.TabControl();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblProject);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1337, 50);
            this.pnlTop.TabIndex = 1;
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProject.Location = new System.Drawing.Point(10, 15);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(120, 21);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "Project Phases";
            // 
            // tabPhases
            // 
            this.tabPhases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPhases.Location = new System.Drawing.Point(0, 50);
            this.tabPhases.Name = "tabPhases";
            this.tabPhases.SelectedIndex = 0;
            this.tabPhases.Size = new System.Drawing.Size(1337, 539);
            this.tabPhases.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSave.Location = new System.Drawing.Point(0, 589);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(1337, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmProjectPhasesNew
            // 
            this.ClientSize = new System.Drawing.Size(1337, 629);
            this.Controls.Add(this.tabPhases);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.btnSave);
            this.Name = "frmProjectPhasesNew";
            this.Text = "Project Phases";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmProjectPhasesNew_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}