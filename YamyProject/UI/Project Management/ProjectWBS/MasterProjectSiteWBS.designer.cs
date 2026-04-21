namespace YamyProject
{
    partial class MasterProjectSiteWBS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgView = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnLoad = new Guna.UI2.WinForms.Guna2Button();
            this.txtSupervisor = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTender = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSite = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProject = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbZone = new Guna.UI2.WinForms.Guna2ComboBox();
            this.chkZone = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkSiteSetup = new Guna.UI2.WinForms.Guna2CheckBox();
            this.cmbSiteSetup = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.headerUC1 = new YamyProject.HeaderUC();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.AllowUserToResizeColumns = false;
            this.dgView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgView.ColumnHeadersHeight = 30;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgView.Location = new System.Drawing.Point(0, 0);
            this.dgView.MultiSelect = false;
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            this.dgView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgView.RowHeadersVisible = false;
            this.dgView.RowTemplate.Height = 25;
            this.dgView.Size = new System.Drawing.Size(1211, 464);
            this.dgView.TabIndex = 6;
            this.dgView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgView.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Silver;
            this.dgView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.dgView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgView.ThemeStyle.HeaderStyle.Height = 30;
            this.dgView.ThemeStyle.ReadOnly = true;
            this.dgView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgView.ThemeStyle.RowsStyle.Height = 25;
            this.dgView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellDoubleClick);
            this.dgView.MouseLeave += new System.EventHandler(this.dgvCustomer_Leave);
            this.dgView.MouseHover += new System.EventHandler(this.dgvCustomer_MouseHover);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnLoad);
            this.panel2.Controls.Add(this.txtSupervisor);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtTender);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtSite);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtProject);
            this.panel2.Controls.Add(this.cmbZone);
            this.panel2.Controls.Add(this.chkZone);
            this.panel2.Controls.Add(this.chkSiteSetup);
            this.panel2.Controls.Add(this.cmbSiteSetup);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1211, 106);
            this.panel2.TabIndex = 7;
            // 
            // BtnLoad
            // 
            this.BtnLoad.BorderRadius = 5;
            this.BtnLoad.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnLoad.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnLoad.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnLoad.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnLoad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnLoad.ForeColor = System.Drawing.Color.White;
            this.BtnLoad.Location = new System.Drawing.Point(900, 5);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(106, 23);
            this.BtnLoad.TabIndex = 21;
            this.BtnLoad.Text = "Refresh";
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // txtSupervisor
            // 
            this.txtSupervisor.BorderRadius = 5;
            this.txtSupervisor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSupervisor.DefaultText = "";
            this.txtSupervisor.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSupervisor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSupervisor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSupervisor.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSupervisor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSupervisor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSupervisor.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSupervisor.Location = new System.Drawing.Point(536, 74);
            this.txtSupervisor.Name = "txtSupervisor";
            this.txtSupervisor.PlaceholderText = "";
            this.txtSupervisor.SelectedText = "";
            this.txtSupervisor.Size = new System.Drawing.Size(279, 24);
            this.txtSupervisor.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.label6.Location = new System.Drawing.Point(477, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Supervisor";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTender
            // 
            this.txtTender.BorderRadius = 5;
            this.txtTender.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTender.DefaultText = "";
            this.txtTender.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTender.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTender.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTender.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTender.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTender.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTender.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTender.Location = new System.Drawing.Point(66, 78);
            this.txtTender.Name = "txtTender";
            this.txtTender.PlaceholderText = "";
            this.txtTender.SelectedText = "";
            this.txtTender.Size = new System.Drawing.Size(279, 24);
            this.txtTender.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.label5.Location = new System.Drawing.Point(7, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Tender";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSite
            // 
            this.txtSite.BorderRadius = 5;
            this.txtSite.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSite.DefaultText = "";
            this.txtSite.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSite.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSite.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSite.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSite.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSite.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSite.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSite.Location = new System.Drawing.Point(434, 44);
            this.txtSite.Name = "txtSite";
            this.txtSite.PlaceholderText = "";
            this.txtSite.SelectedText = "";
            this.txtSite.Size = new System.Drawing.Size(279, 24);
            this.txtSite.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.label4.Location = new System.Drawing.Point(375, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Site";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProject
            // 
            this.txtProject.BorderRadius = 5;
            this.txtProject.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProject.DefaultText = "";
            this.txtProject.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProject.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProject.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProject.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProject.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProject.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProject.Location = new System.Drawing.Point(66, 44);
            this.txtProject.Name = "txtProject";
            this.txtProject.PlaceholderText = "";
            this.txtProject.SelectedText = "";
            this.txtProject.Size = new System.Drawing.Size(279, 24);
            this.txtProject.TabIndex = 13;
            // 
            // cmbZone
            // 
            this.cmbZone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbZone.BackColor = System.Drawing.Color.Transparent;
            this.cmbZone.BorderRadius = 5;
            this.cmbZone.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZone.Enabled = false;
            this.cmbZone.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbZone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbZone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbZone.ItemHeight = 18;
            this.cmbZone.Location = new System.Drawing.Point(919, 44);
            this.cmbZone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(241, 24);
            this.cmbZone.TabIndex = 12;
            this.cmbZone.Visible = false;
            this.cmbZone.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // chkZone
            // 
            this.chkZone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkZone.AutoSize = true;
            this.chkZone.BackColor = System.Drawing.Color.Transparent;
            this.chkZone.Checked = true;
            this.chkZone.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkZone.CheckedState.BorderRadius = 0;
            this.chkZone.CheckedState.BorderThickness = 0;
            this.chkZone.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkZone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkZone.ForeColor = System.Drawing.Color.Black;
            this.chkZone.Location = new System.Drawing.Point(1164, 50);
            this.chkZone.Name = "chkZone";
            this.chkZone.Size = new System.Drawing.Size(37, 17);
            this.chkZone.TabIndex = 9;
            this.chkZone.Text = "All";
            this.chkZone.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkZone.UncheckedState.BorderRadius = 0;
            this.chkZone.UncheckedState.BorderThickness = 0;
            this.chkZone.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkZone.UseVisualStyleBackColor = false;
            this.chkZone.Visible = false;
            this.chkZone.CheckedChanged += new System.EventHandler(this.chkPayment_CheckedChanged);
            // 
            // chkSiteSetup
            // 
            this.chkSiteSetup.AutoSize = true;
            this.chkSiteSetup.BackColor = System.Drawing.Color.Transparent;
            this.chkSiteSetup.Checked = true;
            this.chkSiteSetup.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkSiteSetup.CheckedState.BorderRadius = 0;
            this.chkSiteSetup.CheckedState.BorderThickness = 0;
            this.chkSiteSetup.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkSiteSetup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSiteSetup.ForeColor = System.Drawing.Color.Black;
            this.chkSiteSetup.Location = new System.Drawing.Point(567, 10);
            this.chkSiteSetup.Name = "chkSiteSetup";
            this.chkSiteSetup.Size = new System.Drawing.Size(37, 17);
            this.chkSiteSetup.TabIndex = 9;
            this.chkSiteSetup.Text = "All";
            this.chkSiteSetup.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkSiteSetup.UncheckedState.BorderRadius = 0;
            this.chkSiteSetup.UncheckedState.BorderThickness = 0;
            this.chkSiteSetup.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkSiteSetup.UseVisualStyleBackColor = false;
            this.chkSiteSetup.CheckedChanged += new System.EventHandler(this.chkCustomer_CheckedChanged);
            // 
            // cmbSiteSetup
            // 
            this.cmbSiteSetup.BackColor = System.Drawing.Color.Transparent;
            this.cmbSiteSetup.BorderRadius = 5;
            this.cmbSiteSetup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSiteSetup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSiteSetup.Enabled = false;
            this.cmbSiteSetup.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSiteSetup.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbSiteSetup.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSiteSetup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbSiteSetup.ItemHeight = 18;
            this.cmbSiteSetup.Location = new System.Drawing.Point(66, 4);
            this.cmbSiteSetup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSiteSetup.Name = "cmbSiteSetup";
            this.cmbSiteSetup.Size = new System.Drawing.Size(495, 24);
            this.cmbSiteSetup.TabIndex = 6;
            this.cmbSiteSetup.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Site Setup";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.label3.Location = new System.Drawing.Point(878, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Zone";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.label2.Location = new System.Drawing.Point(7, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Project";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(2, 136);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1211, 464);
            this.panel3.TabIndex = 8;
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
            this.panel6.Location = new System.Drawing.Point(1213, 30);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(2, 572);
            this.panel6.TabIndex = 13;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 30);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(2, 572);
            this.panel7.TabIndex = 12;
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
            this.headerUC1.Size = new System.Drawing.Size(1215, 30);
            this.headerUC1.TabIndex = 0;
            // 
            // MasterProjectSiteWBS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1215, 602);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.headerUC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MasterProjectSiteWBS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "main";
            this.Text = "Project Site Setup List";
            this.Load += new System.EventHandler(this.MasterProjectSites_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private HeaderUC headerUC1;
        private Guna.UI2.WinForms.Guna2DataGridView dgView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSiteSetup;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CheckBox chkSiteSetup;
        private Guna.UI2.WinForms.Guna2CheckBox chkZone;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cmbZone;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private Guna.UI2.WinForms.Guna2TextBox txtProject;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtSite;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtTender;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtSupervisor;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button BtnLoad;
    }
}