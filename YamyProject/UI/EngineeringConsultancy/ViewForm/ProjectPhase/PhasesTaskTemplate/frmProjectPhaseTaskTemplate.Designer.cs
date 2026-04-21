using Guna.UI2.WinForms;

namespace YamyProject.UI.Project_Management
{
    partial class frmProjectPhaseTaskTemplate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Guna2TextBox txtTaskName;
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
            this.txtTaskName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSortOrder = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.headerUC1 = new YamyProject.HeaderUC();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ChkActive = new System.Windows.Forms.CheckBox();
            this.ChkMandatory = new System.Windows.Forms.CheckBox();
            this.cmbPhaseTemplate = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTaskName
            // 
            this.txtTaskName.BorderRadius = 5;
            this.txtTaskName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTaskName.DefaultText = "";
            this.txtTaskName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTaskName.Location = new System.Drawing.Point(103, 41);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.PlaceholderText = "Task Name";
            this.txtTaskName.SelectedText = "";
            this.txtTaskName.Size = new System.Drawing.Size(449, 26);
            this.txtTaskName.TabIndex = 2;
            // 
            // txtSortOrder
            // 
            this.txtSortOrder.BorderRadius = 5;
            this.txtSortOrder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSortOrder.DefaultText = "";
            this.txtSortOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSortOrder.Location = new System.Drawing.Point(103, 78);
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
            this.btnSave.Location = new System.Drawing.Point(430, 226);
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
            this.headerUC1.Size = new System.Drawing.Size(565, 30);
            this.headerUC1.TabIndex = 239;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ChkActive);
            this.panel1.Controls.Add(this.ChkMandatory);
            this.panel1.Controls.Add(this.cmbPhaseTemplate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtSortOrder);
            this.panel1.Controls.Add(this.txtTaskName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(565, 264);
            this.panel1.TabIndex = 240;
            // 
            // ChkActive
            // 
            this.ChkActive.AutoSize = true;
            this.ChkActive.Checked = true;
            this.ChkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkActive.Location = new System.Drawing.Point(271, 138);
            this.ChkActive.Name = "ChkActive";
            this.ChkActive.Size = new System.Drawing.Size(56, 17);
            this.ChkActive.TabIndex = 18;
            this.ChkActive.Text = "Active";
            this.ChkActive.UseVisualStyleBackColor = true;
            // 
            // ChkMandatory
            // 
            this.ChkMandatory.AutoSize = true;
            this.ChkMandatory.Checked = true;
            this.ChkMandatory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkMandatory.Location = new System.Drawing.Point(103, 138);
            this.ChkMandatory.Name = "ChkMandatory";
            this.ChkMandatory.Size = new System.Drawing.Size(76, 17);
            this.ChkMandatory.TabIndex = 17;
            this.ChkMandatory.Text = "Mandatory";
            this.ChkMandatory.UseVisualStyleBackColor = true;
            // 
            // cmbPhaseTemplate
            // 
            this.cmbPhaseTemplate.BackColor = System.Drawing.Color.Transparent;
            this.cmbPhaseTemplate.BorderRadius = 5;
            this.cmbPhaseTemplate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPhaseTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhaseTemplate.FocusedColor = System.Drawing.Color.Empty;
            this.cmbPhaseTemplate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPhaseTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbPhaseTemplate.ItemHeight = 20;
            this.cmbPhaseTemplate.Location = new System.Drawing.Point(103, 5);
            this.cmbPhaseTemplate.Name = "cmbPhaseTemplate";
            this.cmbPhaseTemplate.Size = new System.Drawing.Size(273, 26);
            this.cmbPhaseTemplate.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Phase Template";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sort Order";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Task Name";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 264);
            this.panel3.TabIndex = 241;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(563, 30);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 264);
            this.panel4.TabIndex = 242;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(2, 292);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(561, 2);
            this.panel5.TabIndex = 243;
            // 
            // frmProjectPhaseTaskTemplate
            // 
            this.ClientSize = new System.Drawing.Size(565, 294);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.headerUC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProjectPhaseTaskTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project Phase Task Template";
            this.Load += new System.EventHandler(this.frmProjectPhaseTaskTemplate_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private HeaderUC headerUC1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private Guna2ComboBox cmbPhaseTemplate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ChkActive;
        private System.Windows.Forms.CheckBox ChkMandatory;
    }
}