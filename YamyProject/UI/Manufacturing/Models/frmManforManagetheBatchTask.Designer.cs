namespace YamyProject.UI.Manufacturing.Models
{
    partial class frmManforManagetheBatchTask
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAdd = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvdescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGo = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvlinkResource = new System.Windows.Forms.DataGridViewLinkColumn();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2ControlBox1);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(41)))), ((int)(((byte)(83)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(561, 47);
            this.guna2Panel1.TabIndex = 2;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(543, 3);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(15, 15);
            this.guna2ControlBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(50, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose The Batch for Producting";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::YamyProject.Properties.Resources.Gears;
            this.pictureBox1.Location = new System.Drawing.Point(14, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAdd.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAdd.HoverState.ImageSize = new System.Drawing.Size(0, 0);
            this.btnAdd.Image = global::YamyProject.Properties.Resources.Search1;
            this.btnAdd.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnAdd.ImageRotate = 0F;
            this.btnAdd.ImageSize = new System.Drawing.Size(18, 18);
            this.btnAdd.IndicateFocus = true;
            this.btnAdd.Location = new System.Drawing.Point(207, 52);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PressedState.ImageSize = new System.Drawing.Size(5, 55);
            this.btnAdd.Size = new System.Drawing.Size(22, 24);
            this.btnAdd.TabIndex = 18;
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.BorderRadius = 5;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Location = new System.Drawing.Point(9, 51);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PlaceholderText = "Search By Batch  Name ....";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(194, 24);
            this.guna2TextBox1.TabIndex = 17;
            this.guna2TextBox1.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ImageButton1.BackColor = System.Drawing.Color.RoyalBlue;
            this.guna2ImageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(0, 0);
            this.guna2ImageButton1.Image = global::YamyProject.Properties.Resources.ASD;
            this.guna2ImageButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton1.ImageRotate = 0F;
            this.guna2ImageButton1.ImageSize = new System.Drawing.Size(18, 18);
            this.guna2ImageButton1.IndicateFocus = true;
            this.guna2ImageButton1.Location = new System.Drawing.Point(536, 54);
            this.guna2ImageButton1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(5, 55);
            this.guna2ImageButton1.Size = new System.Drawing.Size(22, 24);
            this.guna2ImageButton1.TabIndex = 23;
            this.guna2ImageButton1.Click += new System.EventHandler(this.guna2ImageButton1_Click);
            // 
            // guna2DataGridView1
            // 
            this.guna2DataGridView1.AllowUserToAddRows = false;
            this.guna2DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.guna2DataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guna2DataGridView1.ColumnHeadersHeight = 30;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvSno,
            this.dgvName,
            this.dgvdate,
            this.dgvamount,
            this.dgvdescr,
            this.dgvGo,
            this.dgvlinkResource});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(9, 82);
            this.guna2DataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.ReadOnly = true;
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidth = 51;
            this.guna2DataGridView1.RowTemplate.Height = 24;
            this.guna2DataGridView1.Size = new System.Drawing.Size(549, 336);
            this.guna2DataGridView1.TabIndex = 24;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.RoyalBlue;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 30;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = true;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 24;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellContentClick);
            // 
            // dgvSno
            // 
            this.dgvSno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvSno.FillWeight = 70F;
            this.dgvSno.HeaderText = "Sn#";
            this.dgvSno.MinimumWidth = 70;
            this.dgvSno.Name = "dgvSno";
            this.dgvSno.ReadOnly = true;
            this.dgvSno.Width = 70;
            // 
            // dgvName
            // 
            this.dgvName.HeaderText = "Batch Name";
            this.dgvName.MinimumWidth = 6;
            this.dgvName.Name = "dgvName";
            this.dgvName.ReadOnly = true;
            // 
            // dgvdate
            // 
            this.dgvdate.HeaderText = "Time";
            this.dgvdate.MinimumWidth = 6;
            this.dgvdate.Name = "dgvdate";
            this.dgvdate.ReadOnly = true;
            // 
            // dgvamount
            // 
            this.dgvamount.HeaderText = "Price";
            this.dgvamount.MinimumWidth = 6;
            this.dgvamount.Name = "dgvamount";
            this.dgvamount.ReadOnly = true;
            this.dgvamount.Visible = false;
            // 
            // dgvdescr
            // 
            this.dgvdescr.HeaderText = "Description";
            this.dgvdescr.MinimumWidth = 6;
            this.dgvdescr.Name = "dgvdescr";
            this.dgvdescr.ReadOnly = true;
            // 
            // dgvGo
            // 
            this.dgvGo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvGo.FillWeight = 50F;
            this.dgvGo.HeaderText = "";
            this.dgvGo.Image = global::YamyProject.Properties.Resources.Go;
            this.dgvGo.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvGo.MinimumWidth = 50;
            this.dgvGo.Name = "dgvGo";
            this.dgvGo.ReadOnly = true;
            this.dgvGo.Width = 50;
            // 
            // dgvlinkResource
            // 
            this.dgvlinkResource.HeaderText = "Add Resource";
            this.dgvlinkResource.Name = "dgvlinkResource";
            this.dgvlinkResource.ReadOnly = true;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // frmManforManagetheBatchTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 431);
            this.Controls.Add(this.guna2DataGridView1);
            this.Controls.Add(this.guna2ImageButton1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmManforManagetheBatchTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManforManagetheBatchTask";
            this.Load += new System.EventHandler(this.frmManforManagetheBatchTask_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        public Guna.UI2.WinForms.Guna2ImageButton btnAdd;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        public Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvdescr;
        private System.Windows.Forms.DataGridViewImageColumn dgvGo;
        private System.Windows.Forms.DataGridViewLinkColumn dgvlinkResource;
    }
}