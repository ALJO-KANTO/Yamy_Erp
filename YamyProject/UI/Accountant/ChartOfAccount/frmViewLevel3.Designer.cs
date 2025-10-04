namespace YamyProject
{
    partial class frmViewLevel3
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.lblBalance = new System.Windows.Forms.Label();
            this.cmbLevel2 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtLevel3 = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbLevel1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.LbHeader = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 133);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 33);
            this.panel1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnClose.BorderRadius = 7;
            this.btnClose.BorderThickness = 1;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnClose.Location = new System.Drawing.Point(275, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(59, 27);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.BorderRadius = 7;
            this.btnSave.BorderThickness = 3;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(210, 4);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 27);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblBalance
            // 
            this.lblBalance.BackColor = System.Drawing.Color.Transparent;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.lblBalance.Location = new System.Drawing.Point(12, 61);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(47, 29);
            this.lblBalance.TabIndex = 13;
            this.lblBalance.Text = "Level 2";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbLevel2
            // 
            this.cmbLevel2.BackColor = System.Drawing.Color.Transparent;
            this.cmbLevel2.BorderRadius = 7;
            this.cmbLevel2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLevel2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevel2.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbLevel2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbLevel2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLevel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbLevel2.ItemHeight = 18;
            this.cmbLevel2.Location = new System.Drawing.Point(67, 65);
            this.cmbLevel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbLevel2.Name = "cmbLevel2";
            this.cmbLevel2.Size = new System.Drawing.Size(271, 24);
            this.cmbLevel2.TabIndex = 12;
            // 
            // txtLevel3
            // 
            this.txtLevel3.BorderRadius = 7;
            this.txtLevel3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLevel3.DefaultText = "";
            this.txtLevel3.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLevel3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLevel3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLevel3.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLevel3.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLevel3.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLevel3.ForeColor = System.Drawing.Color.Black;
            this.txtLevel3.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLevel3.Location = new System.Drawing.Point(67, 98);
            this.txtLevel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLevel3.Name = "txtLevel3";
            this.txtLevel3.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtLevel3.PlaceholderText = "Add New Level 3";
            this.txtLevel3.SelectedText = "";
            this.txtLevel3.Size = new System.Drawing.Size(271, 24);
            this.txtLevel3.TabIndex = 11;
            // 
            // cmbLevel1
            // 
            this.cmbLevel1.BackColor = System.Drawing.Color.Transparent;
            this.cmbLevel1.BorderRadius = 7;
            this.cmbLevel1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLevel1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevel1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbLevel1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbLevel1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLevel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbLevel1.ItemHeight = 18;
            this.cmbLevel1.Location = new System.Drawing.Point(67, 32);
            this.cmbLevel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbLevel1.Name = "cmbLevel1";
            this.cmbLevel1.Size = new System.Drawing.Size(271, 24);
            this.cmbLevel1.TabIndex = 12;
            this.cmbLevel1.SelectedIndexChanged += new System.EventHandler(this.cmbLevel1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(14, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "Level 1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(2, 166);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(340, 2);
            this.panel5.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(342, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 168);
            this.panel4.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 168);
            this.panel3.TabIndex = 14;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(41)))), ((int)(((byte)(83)))));
            this.panel8.Controls.Add(this.guna2Button1);
            this.panel8.Controls.Add(this.guna2Button4);
            this.panel8.Controls.Add(this.guna2ControlBox1);
            this.panel8.Controls.Add(this.LbHeader);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(2, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(340, 23);
            this.panel8.TabIndex = 146;
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 3;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = global::YamyProject.Properties.Resources.Subtract;
            this.guna2Button1.ImageSize = new System.Drawing.Size(15, 15);
            this.guna2Button1.Location = new System.Drawing.Point(278, 3);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(15, 15);
            this.guna2Button1.TabIndex = 32;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2Button4
            // 
            this.guna2Button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button4.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button4.BorderRadius = 3;
            this.guna2Button4.BorderThickness = 1;
            this.guna2Button4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button4.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button4.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.Image = global::YamyProject.Properties.Resources.Restore_Down1;
            this.guna2Button4.ImageSize = new System.Drawing.Size(15, 15);
            this.guna2Button4.Location = new System.Drawing.Point(300, 3);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.Size = new System.Drawing.Size(15, 15);
            this.guna2Button4.TabIndex = 31;
            this.guna2Button4.Click += new System.EventHandler(this.guna2Button4_Click);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(321, 4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(15, 15);
            this.guna2ControlBox1.TabIndex = 0;
            // 
            // LbHeader
            // 
            this.LbHeader.AutoSize = false;
            this.LbHeader.BackColor = System.Drawing.Color.Transparent;
            this.LbHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbHeader.ForeColor = System.Drawing.Color.White;
            this.LbHeader.Location = new System.Drawing.Point(0, 0);
            this.LbHeader.Name = "LbHeader";
            this.LbHeader.Size = new System.Drawing.Size(340, 23);
            this.LbHeader.TabIndex = 19;
            this.LbHeader.Text = null;
            this.LbHeader.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.LbHeader.Click += new System.EventHandler(this.LbHeader_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.LbHeader;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.label2.Location = new System.Drawing.Point(14, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 29);
            this.label2.TabIndex = 147;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmViewLevel3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(344, 168);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.cmbLevel1);
            this.Controls.Add(this.cmbLevel2);
            this.Controls.Add(this.txtLevel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmViewLevel3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer - Add New Category";
            this.Load += new System.EventHandler(this.frmViewLevel3_Load);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label lblBalance;
        private Guna.UI2.WinForms.Guna2ComboBox cmbLevel2;
        private Guna.UI2.WinForms.Guna2TextBox txtLevel3;
        private Guna.UI2.WinForms.Guna2ComboBox cmbLevel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel LbHeader;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.Label label2;
    }
}