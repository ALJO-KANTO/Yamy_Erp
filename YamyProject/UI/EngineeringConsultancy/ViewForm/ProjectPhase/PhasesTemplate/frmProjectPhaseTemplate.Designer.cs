using Guna.UI2.WinForms;

namespace YamyProject.UI.Project_Management
{
    partial class frmProjectPhaseTemplate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Guna2TextBox txtPhaseNo;
        private Guna2TextBox txtPhaseName;
        private Guna2TextBox txtSortOrder;
        private Guna2Button btnSave;

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
            this.txtPhaseNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPhaseName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSortOrder = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.headerUC1 = new YamyProject.HeaderUC();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ChkActive = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPhaseNo
            // 
            this.txtPhaseNo.BorderRadius = 5;
            this.txtPhaseNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhaseNo.DefaultText = "";
            this.txtPhaseNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhaseNo.Location = new System.Drawing.Point(77, 10);
            this.txtPhaseNo.Name = "txtPhaseNo";
            this.txtPhaseNo.PlaceholderText = "Phase No";
            this.txtPhaseNo.SelectedText = "";
            this.txtPhaseNo.Size = new System.Drawing.Size(72, 26);
            this.txtPhaseNo.TabIndex = 1;
            this.txtPhaseNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhaseNo_KeyPress);
            // 
            // txtPhaseName
            // 
            this.txtPhaseName.BorderRadius = 5;
            this.txtPhaseName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhaseName.DefaultText = "";
            this.txtPhaseName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhaseName.Location = new System.Drawing.Point(77, 54);
            this.txtPhaseName.Name = "txtPhaseName";
            this.txtPhaseName.PlaceholderText = "Phase Name";
            this.txtPhaseName.SelectedText = "";
            this.txtPhaseName.Size = new System.Drawing.Size(348, 26);
            this.txtPhaseName.TabIndex = 2;
            // 
            // txtSortOrder
            // 
            this.txtSortOrder.BorderRadius = 5;
            this.txtSortOrder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSortOrder.DefaultText = "";
            this.txtSortOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSortOrder.Location = new System.Drawing.Point(77, 99);
            this.txtSortOrder.Name = "txtSortOrder";
            this.txtSortOrder.PlaceholderText = "Sort Order";
            this.txtSortOrder.SelectedText = "";
            this.txtSortOrder.Size = new System.Drawing.Size(106, 26);
            this.txtSortOrder.TabIndex = 3;
            this.txtSortOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhaseNo_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(303, 153);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 26);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.headerUC1.Size = new System.Drawing.Size(455, 30);
            this.headerUC1.TabIndex = 239;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ChkActive);
            this.panel1.Controls.Add(this.txtPhaseNo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtSortOrder);
            this.panel1.Controls.Add(this.txtPhaseName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 202);
            this.panel1.TabIndex = 240;
            // 
            // ChkActive
            // 
            this.ChkActive.AutoSize = true;
            this.ChkActive.Checked = true;
            this.ChkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkActive.Location = new System.Drawing.Point(254, 104);
            this.ChkActive.Name = "ChkActive";
            this.ChkActive.Size = new System.Drawing.Size(56, 17);
            this.ChkActive.TabIndex = 19;
            this.ChkActive.Text = "Active";
            this.ChkActive.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sort Order";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Phase Name";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 202);
            this.panel3.TabIndex = 241;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(453, 30);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 202);
            this.panel4.TabIndex = 242;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(2, 230);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(451, 2);
            this.panel5.TabIndex = 243;
            // 
            // frmProjectPhaseTemplate
            // 
            this.ClientSize = new System.Drawing.Size(455, 232);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.headerUC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProjectPhaseTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project Phase Template";
            this.Load += new System.EventHandler(this.frmProjectPhaseTemplate_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private HeaderUC headerUC1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox ChkActive;
    }
}