using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace YamyProject
{
    partial class frmBoqImport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboSnColumn = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gunaLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnImport = new Guna.UI2.WinForms.Guna2Button();
            this.gunaLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtStartingIndex = new Guna.UI2.WinForms.Guna2TextBox();
            this.headerUC1 = new YamyProject.HeaderUC();
            this.comboNameColumn = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gunaLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gunaLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.comboQtyColumn = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gunaLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.comboRateColumn = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gunaLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.comboUnitColumn = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gunaLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.comboAmountColumn = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gunaLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtEndingIndex = new Guna.UI2.WinForms.Guna2TextBox();
            this.gunaLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gunaLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gunaGroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.comboWidthColumn = new Guna.UI2.WinForms.Guna2ComboBox();
            this.comboLengthColumn = new Guna.UI2.WinForms.Guna2ComboBox();
            this.comboThicknessColumn = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gunaLabel12 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gunaLabel11 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gunaLabel13 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.comboNoteColumn = new Guna.UI2.WinForms.Guna2ComboBox();
            this.panel1.SuspendLayout();
            this.gunaGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 464);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(975, 41);
            this.panel1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnClose.BorderRadius = 5;
            this.btnClose.BorderThickness = 1;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnClose.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnClose.Location = new System.Drawing.Point(787, 5);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(183, 33);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.BorderRadius = 5;
            this.btnSave.BorderThickness = 3;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(598, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(183, 33);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Ok";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 505);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(975, 3);
            this.panel5.TabIndex = 124;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(975, 46);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(3, 462);
            this.panel4.TabIndex = 123;
            // 
            // comboSnColumn
            // 
            this.comboSnColumn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboSnColumn.BackColor = System.Drawing.Color.Transparent;
            this.comboSnColumn.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboSnColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSnColumn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboSnColumn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboSnColumn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboSnColumn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboSnColumn.ItemHeight = 23;
            this.comboSnColumn.Location = new System.Drawing.Point(287, 132);
            this.comboSnColumn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboSnColumn.Name = "comboSnColumn";
            this.comboSnColumn.Size = new System.Drawing.Size(108, 29);
            this.comboSnColumn.TabIndex = 133;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel1.Location = new System.Drawing.Point(77, 132);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(28, 20);
            this.gunaLabel1.TabIndex = 135;
            this.gunaLabel1.Text = "SN";
            // 
            // btnImport
            // 
            this.btnImport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnImport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnImport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnImport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnImport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(667, 68);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(229, 45);
            this.btnImport.TabIndex = 137;
            this.btnImport.Text = "Import From Excel";
            this.btnImport.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel3.Location = new System.Drawing.Point(77, 83);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(130, 20);
            this.gunaLabel3.TabIndex = 138;
            this.gunaLabel3.Text = "Cell Starting Index";
            // 
            // txtStartingIndex
            // 
            this.txtStartingIndex.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStartingIndex.DefaultText = "";
            this.txtStartingIndex.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtStartingIndex.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtStartingIndex.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtStartingIndex.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtStartingIndex.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtStartingIndex.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtStartingIndex.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtStartingIndex.Location = new System.Drawing.Point(250, 75);
            this.txtStartingIndex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStartingIndex.Name = "txtStartingIndex";
            this.txtStartingIndex.PlaceholderText = "";
            this.txtStartingIndex.SelectedText = "";
            this.txtStartingIndex.Size = new System.Drawing.Size(59, 38);
            this.txtStartingIndex.TabIndex = 139;
            this.txtStartingIndex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.guna2TextBox1_KeyPress);
            // 
            // headerUC1
            // 
            this.headerUC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerUC1.FormText = "";
            this.headerUC1.Location = new System.Drawing.Point(0, 0);
            this.headerUC1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.headerUC1.Name = "headerUC1";
            this.headerUC1.Size = new System.Drawing.Size(978, 46);
            this.headerUC1.TabIndex = 0;
            // 
            // comboNameColumn
            // 
            this.comboNameColumn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboNameColumn.BackColor = System.Drawing.Color.Transparent;
            this.comboNameColumn.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboNameColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboNameColumn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboNameColumn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboNameColumn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboNameColumn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboNameColumn.ItemHeight = 23;
            this.comboNameColumn.Location = new System.Drawing.Point(287, 193);
            this.comboNameColumn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboNameColumn.Name = "comboNameColumn";
            this.comboNameColumn.Size = new System.Drawing.Size(108, 29);
            this.comboNameColumn.TabIndex = 134;
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel2.Location = new System.Drawing.Point(77, 202);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(139, 20);
            this.gunaLabel2.TabIndex = 136;
            this.gunaLabel2.Text = "Description of work";
            // 
            // gunaLabel4
            // 
            this.gunaLabel4.AutoSize = true;
            this.gunaLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel4.Location = new System.Drawing.Point(77, 266);
            this.gunaLabel4.Name = "gunaLabel4";
            this.gunaLabel4.Size = new System.Drawing.Size(32, 20);
            this.gunaLabel4.TabIndex = 141;
            this.gunaLabel4.Text = "Qty";
            // 
            // comboQtyColumn
            // 
            this.comboQtyColumn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboQtyColumn.BackColor = System.Drawing.Color.Transparent;
            this.comboQtyColumn.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboQtyColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboQtyColumn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboQtyColumn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboQtyColumn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboQtyColumn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboQtyColumn.ItemHeight = 23;
            this.comboQtyColumn.Location = new System.Drawing.Point(287, 257);
            this.comboQtyColumn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboQtyColumn.Name = "comboQtyColumn";
            this.comboQtyColumn.Size = new System.Drawing.Size(108, 29);
            this.comboQtyColumn.TabIndex = 140;
            // 
            // gunaLabel5
            // 
            this.gunaLabel5.AutoSize = true;
            this.gunaLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel5.Location = new System.Drawing.Point(77, 331);
            this.gunaLabel5.Name = "gunaLabel5";
            this.gunaLabel5.Size = new System.Drawing.Size(39, 20);
            this.gunaLabel5.TabIndex = 143;
            this.gunaLabel5.Text = "Rate";
            // 
            // comboRateColumn
            // 
            this.comboRateColumn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboRateColumn.BackColor = System.Drawing.Color.Transparent;
            this.comboRateColumn.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboRateColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRateColumn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboRateColumn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboRateColumn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboRateColumn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboRateColumn.ItemHeight = 23;
            this.comboRateColumn.Location = new System.Drawing.Point(287, 331);
            this.comboRateColumn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboRateColumn.Name = "comboRateColumn";
            this.comboRateColumn.Size = new System.Drawing.Size(108, 29);
            this.comboRateColumn.TabIndex = 142;
            // 
            // gunaLabel6
            // 
            this.gunaLabel6.AutoSize = true;
            this.gunaLabel6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel6.Location = new System.Drawing.Point(9, 79);
            this.gunaLabel6.Name = "gunaLabel6";
            this.gunaLabel6.Size = new System.Drawing.Size(36, 20);
            this.gunaLabel6.TabIndex = 145;
            this.gunaLabel6.Text = "Unit";
            // 
            // comboUnitColumn
            // 
            this.comboUnitColumn.BackColor = System.Drawing.Color.Transparent;
            this.comboUnitColumn.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboUnitColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUnitColumn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboUnitColumn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboUnitColumn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboUnitColumn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboUnitColumn.ItemHeight = 23;
            this.comboUnitColumn.Location = new System.Drawing.Point(62, 70);
            this.comboUnitColumn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboUnitColumn.Name = "comboUnitColumn";
            this.comboUnitColumn.Size = new System.Drawing.Size(120, 29);
            this.comboUnitColumn.TabIndex = 144;
            // 
            // gunaLabel7
            // 
            this.gunaLabel7.AutoSize = true;
            this.gunaLabel7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel7.Location = new System.Drawing.Point(77, 402);
            this.gunaLabel7.Name = "gunaLabel7";
            this.gunaLabel7.Size = new System.Drawing.Size(62, 20);
            this.gunaLabel7.TabIndex = 147;
            this.gunaLabel7.Text = "Amount";
            // 
            // comboAmountColumn
            // 
            this.comboAmountColumn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboAmountColumn.BackColor = System.Drawing.Color.Transparent;
            this.comboAmountColumn.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboAmountColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAmountColumn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboAmountColumn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboAmountColumn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboAmountColumn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboAmountColumn.ItemHeight = 23;
            this.comboAmountColumn.Location = new System.Drawing.Point(287, 402);
            this.comboAmountColumn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboAmountColumn.Name = "comboAmountColumn";
            this.comboAmountColumn.Size = new System.Drawing.Size(108, 29);
            this.comboAmountColumn.TabIndex = 146;
            // 
            // gunaLabel8
            // 
            this.gunaLabel8.AutoSize = true;
            this.gunaLabel8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel8.Location = new System.Drawing.Point(341, 83);
            this.gunaLabel8.Name = "gunaLabel8";
            this.gunaLabel8.Size = new System.Drawing.Size(124, 20);
            this.gunaLabel8.TabIndex = 148;
            this.gunaLabel8.Text = "Cell Ending Index";
            // 
            // txtEndingIndex
            // 
            this.txtEndingIndex.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEndingIndex.DefaultText = "";
            this.txtEndingIndex.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEndingIndex.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEndingIndex.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEndingIndex.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEndingIndex.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEndingIndex.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEndingIndex.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEndingIndex.Location = new System.Drawing.Point(522, 75);
            this.txtEndingIndex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEndingIndex.Name = "txtEndingIndex";
            this.txtEndingIndex.PlaceholderText = "";
            this.txtEndingIndex.SelectedText = "";
            this.txtEndingIndex.Size = new System.Drawing.Size(59, 38);
            this.txtEndingIndex.TabIndex = 149;
            this.txtEndingIndex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.guna2TextBox1_KeyPress);
            // 
            // gunaLabel9
            // 
            this.gunaLabel9.AutoSize = true;
            this.gunaLabel9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel9.Location = new System.Drawing.Point(9, 175);
            this.gunaLabel9.Name = "gunaLabel9";
            this.gunaLabel9.Size = new System.Drawing.Size(16, 20);
            this.gunaLabel9.TabIndex = 153;
            this.gunaLabel9.Text = "L";
            // 
            // gunaLabel10
            // 
            this.gunaLabel10.AutoSize = true;
            this.gunaLabel10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel10.Location = new System.Drawing.Point(82, 134);
            this.gunaLabel10.Name = "gunaLabel10";
            this.gunaLabel10.Size = new System.Drawing.Size(264, 20);
            this.gunaLabel10.TabIndex = 154;
            this.gunaLabel10.Text = "*********************Size*****************";
            // 
            // gunaGroupBox1
            // 
            this.gunaGroupBox1.BackColor = System.Drawing.Color.Transparent;
            //this.gunaGroupBox1.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox1.FillColor = System.Drawing.Color.White;
            this.gunaGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            //this.gunaGroupBox1.BorderSize = 1;
            this.gunaGroupBox1.BorderThickness = 1;
            this.gunaGroupBox1.Controls.Add(this.comboWidthColumn);
            this.gunaGroupBox1.Controls.Add(this.comboLengthColumn);
            this.gunaGroupBox1.Controls.Add(this.comboThicknessColumn);
            this.gunaGroupBox1.Controls.Add(this.gunaLabel12);
            this.gunaGroupBox1.Controls.Add(this.gunaLabel11);
            this.gunaGroupBox1.Controls.Add(this.gunaLabel10);
            this.gunaGroupBox1.Controls.Add(this.comboUnitColumn);
            this.gunaGroupBox1.Controls.Add(this.gunaLabel9);
            this.gunaGroupBox1.Controls.Add(this.gunaLabel6);
            //this.gunaGroupBox1.LineColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox1.Location = new System.Drawing.Point(468, 132);
            this.gunaGroupBox1.Name = "gunaGroupBox1";
            this.gunaGroupBox1.Size = new System.Drawing.Size(428, 228);
            this.gunaGroupBox1.TabIndex = 155;
            this.gunaGroupBox1.Text = "Unit and Measurements";
            //this.gunaGroupBox1.TextLocation = new System.Drawing.Point(10, 8);
            this.gunaGroupBox1.Padding = new Padding(10, 20, 10, 10);
            // 
            // comboWidthColumn
            // 
            this.comboWidthColumn.BackColor = System.Drawing.Color.Transparent;
            this.comboWidthColumn.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboWidthColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWidthColumn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboWidthColumn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboWidthColumn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboWidthColumn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboWidthColumn.ItemHeight = 23;
            this.comboWidthColumn.Location = new System.Drawing.Point(185, 173);
            this.comboWidthColumn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboWidthColumn.Name = "comboWidthColumn";
            this.comboWidthColumn.Size = new System.Drawing.Size(81, 29);
            this.comboWidthColumn.TabIndex = 161;
            // 
            // comboLengthColumn
            // 
            this.comboLengthColumn.BackColor = System.Drawing.Color.Transparent;
            this.comboLengthColumn.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboLengthColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLengthColumn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboLengthColumn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboLengthColumn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboLengthColumn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboLengthColumn.ItemHeight = 23;
            this.comboLengthColumn.Location = new System.Drawing.Point(34, 173);
            this.comboLengthColumn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboLengthColumn.Name = "comboLengthColumn";
            this.comboLengthColumn.Size = new System.Drawing.Size(81, 29);
            this.comboLengthColumn.TabIndex = 160;
            // 
            // comboThicknessColumn
            // 
            this.comboThicknessColumn.BackColor = System.Drawing.Color.Transparent;
            this.comboThicknessColumn.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboThicknessColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboThicknessColumn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboThicknessColumn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboThicknessColumn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboThicknessColumn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboThicknessColumn.ItemHeight = 23;
            this.comboThicknessColumn.Location = new System.Drawing.Point(323, 173);
            this.comboThicknessColumn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboThicknessColumn.Name = "comboThicknessColumn";
            this.comboThicknessColumn.Size = new System.Drawing.Size(81, 29);
            this.comboThicknessColumn.TabIndex = 159;
            // 
            // gunaLabel12
            // 
            this.gunaLabel12.AutoSize = true;
            this.gunaLabel12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel12.Location = new System.Drawing.Point(284, 175);
            this.gunaLabel12.Name = "gunaLabel12";
            this.gunaLabel12.Size = new System.Drawing.Size(17, 20);
            this.gunaLabel12.TabIndex = 156;
            this.gunaLabel12.Text = "T";
            // 
            // gunaLabel11
            // 
            this.gunaLabel11.AutoSize = true;
            this.gunaLabel11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel11.Location = new System.Drawing.Point(147, 175);
            this.gunaLabel11.Name = "gunaLabel11";
            this.gunaLabel11.Size = new System.Drawing.Size(23, 20);
            this.gunaLabel11.TabIndex = 155;
            this.gunaLabel11.Text = "W";
            // 
            // gunaLabel13
            // 
            this.gunaLabel13.AutoSize = true;
            this.gunaLabel13.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel13.Location = new System.Drawing.Point(463, 412);
            this.gunaLabel13.Name = "gunaLabel13";
            this.gunaLabel13.Size = new System.Drawing.Size(42, 20);
            this.gunaLabel13.TabIndex = 157;
            this.gunaLabel13.Text = "Note";
            // 
            // comboNoteColumn
            // 
            this.comboNoteColumn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboNoteColumn.BackColor = System.Drawing.Color.Transparent;
            this.comboNoteColumn.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboNoteColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboNoteColumn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboNoteColumn.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboNoteColumn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboNoteColumn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboNoteColumn.ItemHeight = 23;
            this.comboNoteColumn.Location = new System.Drawing.Point(530, 403);
            this.comboNoteColumn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboNoteColumn.Name = "comboNoteColumn";
            this.comboNoteColumn.Size = new System.Drawing.Size(108, 29);
            this.comboNoteColumn.TabIndex = 156;
            // 
            // frmBoqImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(978, 508);
            this.Controls.Add(this.gunaLabel13);
            this.Controls.Add(this.comboNoteColumn);
            this.Controls.Add(this.gunaGroupBox1);
            this.Controls.Add(this.txtEndingIndex);
            this.Controls.Add(this.gunaLabel8);
            this.Controls.Add(this.gunaLabel7);
            this.Controls.Add(this.comboAmountColumn);
            this.Controls.Add(this.gunaLabel5);
            this.Controls.Add(this.comboRateColumn);
            this.Controls.Add(this.gunaLabel4);
            this.Controls.Add(this.comboQtyColumn);
            this.Controls.Add(this.txtStartingIndex);
            this.Controls.Add(this.gunaLabel3);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.comboNameColumn);
            this.Controls.Add(this.comboSnColumn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.headerUC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmBoqImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Site";
            this.Load += new System.EventHandler(this.frmBoqImport_Load);
            this.panel1.ResumeLayout(false);
            this.gunaGroupBox1.ResumeLayout(false);
            this.gunaGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private HeaderUC headerUC1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI2.WinForms.Guna2ComboBox comboSnColumn;
        private Guna.UI2.WinForms.Guna2HtmlLabel gunaLabel1;
        private Guna.UI2.WinForms.Guna2Button btnImport;
        private Guna.UI2.WinForms.Guna2HtmlLabel gunaLabel3;
        private Guna.UI2.WinForms.Guna2TextBox txtStartingIndex;
        private Guna.UI2.WinForms.Guna2ComboBox comboNameColumn;
        private Guna.UI2.WinForms.Guna2HtmlLabel gunaLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel gunaLabel4;
        private Guna.UI2.WinForms.Guna2ComboBox comboQtyColumn;
        private Guna.UI2.WinForms.Guna2HtmlLabel gunaLabel5;
        private Guna.UI2.WinForms.Guna2ComboBox comboRateColumn;
        private Guna.UI2.WinForms.Guna2HtmlLabel gunaLabel6;
        private Guna.UI2.WinForms.Guna2ComboBox comboUnitColumn;
        private Guna.UI2.WinForms.Guna2HtmlLabel gunaLabel7;
        private Guna.UI2.WinForms.Guna2ComboBox comboAmountColumn;
        private Guna.UI2.WinForms.Guna2HtmlLabel gunaLabel8;
        private Guna.UI2.WinForms.Guna2TextBox txtEndingIndex;
        private Guna.UI2.WinForms.Guna2HtmlLabel gunaLabel9;
        private Guna.UI2.WinForms.Guna2HtmlLabel gunaLabel10;
        private Guna.UI2.WinForms.Guna2GroupBox gunaGroupBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel gunaLabel12;
        private Guna.UI2.WinForms.Guna2HtmlLabel gunaLabel11;
        private Guna.UI2.WinForms.Guna2ComboBox comboWidthColumn;
        private Guna.UI2.WinForms.Guna2ComboBox comboLengthColumn;
        private Guna.UI2.WinForms.Guna2ComboBox comboThicknessColumn;
        private Guna.UI2.WinForms.Guna2HtmlLabel gunaLabel13;
        private Guna.UI2.WinForms.Guna2ComboBox comboNoteColumn;
    }
}