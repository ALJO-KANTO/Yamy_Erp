using Guna.UI2.WinForms;
using System.Windows.Forms;
using YamyProject.Properties;

namespace YamyProject.UI.Banking
{
    partial class frmWriteCheque
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblName = new System.Windows.Forms.Label();
            this.txtBalance = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblBankAccount = new System.Windows.Forms.Label();
            this.cmbBankAccount = new Guna.UI2.WinForms.Guna2ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtPVCode = new System.Windows.Forms.TextBox();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrevious = new Guna.UI2.WinForms.Guna2Button();
            this.guna2VSeparator12 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.guna2TileButton1 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2TileButton15 = new Guna.UI2.WinForms.Guna2TileButton();
            this.BtnSaveNew = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2VSeparator9 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.BtnDelete = new Guna.UI2.WinForms.Guna2TileButton();
            this.BtnAttach = new Guna.UI2.WinForms.Guna2TileButton();
            this.BtnCopy = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2VSeparator10 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.guna2TileButton19 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2VSeparator11 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.BtnPrint = new Guna.UI2.WinForms.Guna2TileButton();
            this.BtnEmail = new Guna.UI2.WinForms.Guna2TileButton();
            this.txtId = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.guna2TileButton27 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2TileButton28 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2TileButton29 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2VSeparator13 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.guna2TileButton26 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2TileButton25 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2TileButton24 = new Guna.UI2.WinForms.Guna2TileButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvExpenses = new Guna.UI2.WinForms.Guna2DataGridView();
            this.expId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.account_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payee_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvItems = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Id_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_customer_job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_customer_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_billable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAmountInWord = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtOpen = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMemo = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbSubAccount = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblSubAccount = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headerUC1 = new YamyProject.HeaderUC();
            this.panel9.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(828, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(82, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Ending Balance";
            // 
            // txtBalance
            // 
            this.txtBalance.BorderRadius = 5;
            this.txtBalance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBalance.DefaultText = "";
            this.txtBalance.Enabled = false;
            this.txtBalance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Location = new System.Drawing.Point(916, 8);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.PlaceholderText = "";
            this.txtBalance.SelectedText = "";
            this.txtBalance.Size = new System.Drawing.Size(138, 23);
            this.txtBalance.TabIndex = 1;
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.AutoSize = true;
            this.lblBankAccount.Location = new System.Drawing.Point(16, 13);
            this.lblBankAccount.Name = "lblBankAccount";
            this.lblBankAccount.Size = new System.Drawing.Size(75, 13);
            this.lblBankAccount.TabIndex = 2;
            this.lblBankAccount.Text = "Bank Account";
            // 
            // cmbBankAccount
            // 
            this.cmbBankAccount.BackColor = System.Drawing.Color.Transparent;
            this.cmbBankAccount.BorderRadius = 5;
            this.cmbBankAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBankAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBankAccount.FocusedColor = System.Drawing.Color.Empty;
            this.cmbBankAccount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbBankAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbBankAccount.ItemHeight = 20;
            this.cmbBankAccount.Location = new System.Drawing.Point(104, 7);
            this.cmbBankAccount.Name = "cmbBankAccount";
            this.cmbBankAccount.Size = new System.Drawing.Size(300, 26);
            this.cmbBankAccount.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1066, 30);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 535);
            this.panel4.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 535);
            this.panel3.TabIndex = 17;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(2, 563);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1064, 2);
            this.panel5.TabIndex = 18;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.tabControl2);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(2, 30);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1064, 84);
            this.panel9.TabIndex = 42;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.HotTrack = true;
            this.tabControl2.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.Padding = new System.Drawing.Point(20, 3);
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1064, 84);
            this.tabControl2.TabIndex = 39;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.txtPVCode);
            this.tabPage3.Controls.Add(this.btnNext);
            this.tabPage3.Controls.Add(this.btnPrevious);
            this.tabPage3.Controls.Add(this.guna2VSeparator12);
            this.tabPage3.Controls.Add(this.guna2TileButton1);
            this.tabPage3.Controls.Add(this.guna2TileButton15);
            this.tabPage3.Controls.Add(this.BtnSaveNew);
            this.tabPage3.Controls.Add(this.guna2VSeparator9);
            this.tabPage3.Controls.Add(this.BtnDelete);
            this.tabPage3.Controls.Add(this.BtnAttach);
            this.tabPage3.Controls.Add(this.BtnCopy);
            this.tabPage3.Controls.Add(this.guna2VSeparator10);
            this.tabPage3.Controls.Add(this.guna2TileButton19);
            this.tabPage3.Controls.Add(this.guna2VSeparator11);
            this.tabPage3.Controls.Add(this.chkPrint);
            this.tabPage3.Controls.Add(this.BtnPrint);
            this.tabPage3.Controls.Add(this.BtnEmail);
            this.tabPage3.Controls.Add(this.txtId);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1056, 58);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Main";
            // 
            // txtPVCode
            // 
            this.txtPVCode.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtPVCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPVCode.Enabled = false;
            this.txtPVCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPVCode.Location = new System.Drawing.Point(33, 18);
            this.txtPVCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPVCode.Multiline = true;
            this.txtPVCode.Name = "txtPVCode";
            this.txtPVCode.Size = new System.Drawing.Size(66, 24);
            this.txtPVCode.TabIndex = 16;
            this.txtPVCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.FillColor = System.Drawing.Color.Transparent;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Image = global::YamyProject.Properties.Resources.Arrow22;
            this.btnNext.ImageSize = new System.Drawing.Size(25, 25);
            this.btnNext.Location = new System.Drawing.Point(99, 15);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(32, 29);
            this.btnNext.TabIndex = 2;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.FillColor = System.Drawing.Color.Transparent;
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Image = global::YamyProject.Properties.Resources.Arrow_Pointing_Left;
            this.btnPrevious.Location = new System.Drawing.Point(3, 16);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(30, 28);
            this.btnPrevious.TabIndex = 3;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // guna2VSeparator12
            // 
            this.guna2VSeparator12.Location = new System.Drawing.Point(131, 6);
            this.guna2VSeparator12.Name = "guna2VSeparator12";
            this.guna2VSeparator12.Size = new System.Drawing.Size(8, 46);
            this.guna2VSeparator12.TabIndex = 17;
            // 
            // guna2TileButton1
            // 
            this.guna2TileButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton1.BorderRadius = 10;
            this.guna2TileButton1.BorderThickness = 2;
            this.guna2TileButton1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton1.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton1.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton1.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton1.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton1.Image = global::YamyProject.Properties.Resources.add_fileN;
            this.guna2TileButton1.Location = new System.Drawing.Point(139, 6);
            this.guna2TileButton1.Name = "guna2TileButton1";
            this.guna2TileButton1.Size = new System.Drawing.Size(54, 47);
            this.guna2TileButton1.TabIndex = 19;
            this.guna2TileButton1.Text = "New";
            this.guna2TileButton1.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // guna2TileButton15
            // 
            this.guna2TileButton15.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton15.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton15.BorderRadius = 10;
            this.guna2TileButton15.BorderThickness = 2;
            this.guna2TileButton15.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton15.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton15.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton15.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton15.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton15.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton15.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton15.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton15.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton15.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton15.Image = global::YamyProject.Properties.Resources.Invoice_Paid;
            this.guna2TileButton15.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2TileButton15.ImageOffset = new System.Drawing.Point(-10, 10);
            this.guna2TileButton15.Location = new System.Drawing.Point(681, 29);
            this.guna2TileButton15.Name = "guna2TileButton15";
            this.guna2TileButton15.Size = new System.Drawing.Size(100, 23);
            this.guna2TileButton15.TabIndex = 32;
            this.guna2TileButton15.Text = "Add Time / Costs";
            this.guna2TileButton15.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2TileButton15.TextOffset = new System.Drawing.Point(10, -12);
            this.guna2TileButton15.Visible = false;
            // 
            // BtnSaveNew
            // 
            this.BtnSaveNew.BackColor = System.Drawing.Color.Transparent;
            this.BtnSaveNew.BorderColor = System.Drawing.Color.Transparent;
            this.BtnSaveNew.BorderRadius = 10;
            this.BtnSaveNew.BorderThickness = 2;
            this.BtnSaveNew.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.BtnSaveNew.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnSaveNew.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnSaveNew.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnSaveNew.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnSaveNew.FillColor = System.Drawing.Color.Transparent;
            this.BtnSaveNew.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveNew.ForeColor = System.Drawing.Color.Black;
            this.BtnSaveNew.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.BtnSaveNew.HoverState.FillColor = System.Drawing.Color.Silver;
            this.BtnSaveNew.Image = global::YamyProject.Properties.Resources.Save;
            this.BtnSaveNew.Location = new System.Drawing.Point(191, 6);
            this.BtnSaveNew.Name = "BtnSaveNew";
            this.BtnSaveNew.Size = new System.Drawing.Size(54, 47);
            this.BtnSaveNew.TabIndex = 20;
            this.BtnSaveNew.Text = "Save";
            this.BtnSaveNew.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // guna2VSeparator9
            // 
            this.guna2VSeparator9.Location = new System.Drawing.Point(667, 6);
            this.guna2VSeparator9.Name = "guna2VSeparator9";
            this.guna2VSeparator9.Size = new System.Drawing.Size(8, 46);
            this.guna2VSeparator9.TabIndex = 31;
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.Transparent;
            this.BtnDelete.BorderColor = System.Drawing.Color.Transparent;
            this.BtnDelete.BorderRadius = 10;
            this.BtnDelete.BorderThickness = 2;
            this.BtnDelete.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.BtnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnDelete.FillColor = System.Drawing.Color.Transparent;
            this.BtnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.Black;
            this.BtnDelete.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.BtnDelete.HoverState.FillColor = System.Drawing.Color.Silver;
            this.BtnDelete.Image = global::YamyProject.Properties.Resources.deleteN;
            this.BtnDelete.Location = new System.Drawing.Point(247, 6);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(54, 47);
            this.BtnDelete.TabIndex = 21;
            this.BtnDelete.Text = "Delete";
            // 
            // BtnAttach
            // 
            this.BtnAttach.BackColor = System.Drawing.Color.Transparent;
            this.BtnAttach.BorderColor = System.Drawing.Color.Transparent;
            this.BtnAttach.BorderRadius = 10;
            this.BtnAttach.BorderThickness = 2;
            this.BtnAttach.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.BtnAttach.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnAttach.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnAttach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnAttach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnAttach.FillColor = System.Drawing.Color.Transparent;
            this.BtnAttach.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAttach.ForeColor = System.Drawing.Color.Black;
            this.BtnAttach.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.BtnAttach.HoverState.FillColor = System.Drawing.Color.Silver;
            this.BtnAttach.Image = global::YamyProject.Properties.Resources.attachN;
            this.BtnAttach.Location = new System.Drawing.Point(613, 7);
            this.BtnAttach.Name = "BtnAttach";
            this.BtnAttach.Size = new System.Drawing.Size(54, 47);
            this.BtnAttach.TabIndex = 30;
            this.BtnAttach.Text = "Attach File";
            this.BtnAttach.Visible = false;
            // 
            // BtnCopy
            // 
            this.BtnCopy.BackColor = System.Drawing.Color.Transparent;
            this.BtnCopy.BorderColor = System.Drawing.Color.Transparent;
            this.BtnCopy.BorderRadius = 10;
            this.BtnCopy.BorderThickness = 2;
            this.BtnCopy.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.BtnCopy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnCopy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnCopy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnCopy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnCopy.FillColor = System.Drawing.Color.Transparent;
            this.BtnCopy.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCopy.ForeColor = System.Drawing.Color.Black;
            this.BtnCopy.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.BtnCopy.HoverState.FillColor = System.Drawing.Color.Silver;
            this.BtnCopy.Image = global::YamyProject.Properties.Resources.copyN;
            this.BtnCopy.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnCopy.ImageOffset = new System.Drawing.Point(-10, 10);
            this.BtnCopy.Location = new System.Drawing.Point(301, 8);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(100, 23);
            this.BtnCopy.TabIndex = 22;
            this.BtnCopy.Text = "Create a Copy";
            this.BtnCopy.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnCopy.TextOffset = new System.Drawing.Point(10, -12);
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // guna2VSeparator10
            // 
            this.guna2VSeparator10.Location = new System.Drawing.Point(605, 6);
            this.guna2VSeparator10.Name = "guna2VSeparator10";
            this.guna2VSeparator10.Size = new System.Drawing.Size(8, 46);
            this.guna2VSeparator10.TabIndex = 29;
            // 
            // guna2TileButton19
            // 
            this.guna2TileButton19.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton19.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton19.BorderRadius = 10;
            this.guna2TileButton19.BorderThickness = 2;
            this.guna2TileButton19.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton19.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton19.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton19.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton19.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton19.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton19.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton19.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton19.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton19.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton19.Image = global::YamyProject.Properties.Resources.Cloud;
            this.guna2TileButton19.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2TileButton19.ImageOffset = new System.Drawing.Point(-10, 10);
            this.guna2TileButton19.Location = new System.Drawing.Point(309, 29);
            this.guna2TileButton19.Name = "guna2TileButton19";
            this.guna2TileButton19.Size = new System.Drawing.Size(100, 23);
            this.guna2TileButton19.TabIndex = 23;
            this.guna2TileButton19.Text = "Memorize";
            this.guna2TileButton19.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2TileButton19.TextOffset = new System.Drawing.Point(10, -12);
            // 
            // guna2VSeparator11
            // 
            this.guna2VSeparator11.Location = new System.Drawing.Point(401, 6);
            this.guna2VSeparator11.Name = "guna2VSeparator11";
            this.guna2VSeparator11.Size = new System.Drawing.Size(8, 46);
            this.guna2VSeparator11.TabIndex = 24;
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrint.Location = new System.Drawing.Point(517, 34);
            this.chkPrint.Margin = new System.Windows.Forms.Padding(2);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(88, 16);
            this.chkPrint.TabIndex = 27;
            this.chkPrint.Text = "Print  After Save";
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // BtnPrint
            // 
            this.BtnPrint.BackColor = System.Drawing.Color.Transparent;
            this.BtnPrint.BorderColor = System.Drawing.Color.Transparent;
            this.BtnPrint.BorderRadius = 10;
            this.BtnPrint.BorderThickness = 2;
            this.BtnPrint.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.BtnPrint.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnPrint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnPrint.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnPrint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnPrint.FillColor = System.Drawing.Color.Transparent;
            this.BtnPrint.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrint.ForeColor = System.Drawing.Color.Black;
            this.BtnPrint.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.BtnPrint.HoverState.FillColor = System.Drawing.Color.Silver;
            this.BtnPrint.Image = global::YamyProject.Properties.Resources.printN;
            this.BtnPrint.Location = new System.Drawing.Point(409, 8);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(54, 47);
            this.BtnPrint.TabIndex = 25;
            this.BtnPrint.Text = "Print";
            // 
            // BtnEmail
            // 
            this.BtnEmail.BackColor = System.Drawing.Color.Transparent;
            this.BtnEmail.BorderColor = System.Drawing.Color.Transparent;
            this.BtnEmail.BorderRadius = 10;
            this.BtnEmail.BorderThickness = 2;
            this.BtnEmail.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.BtnEmail.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnEmail.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnEmail.FillColor = System.Drawing.Color.Transparent;
            this.BtnEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEmail.ForeColor = System.Drawing.Color.Black;
            this.BtnEmail.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.BtnEmail.HoverState.FillColor = System.Drawing.Color.Silver;
            this.BtnEmail.Image = global::YamyProject.Properties.Resources.emailN;
            this.BtnEmail.Location = new System.Drawing.Point(463, 8);
            this.BtnEmail.Name = "BtnEmail";
            this.BtnEmail.Size = new System.Drawing.Size(54, 47);
            this.BtnEmail.TabIndex = 26;
            this.BtnEmail.Text = "Email";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtId.Enabled = false;
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtId.Location = new System.Drawing.Point(33, 18);
            this.txtId.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtId.Multiline = true;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(66, 24);
            this.txtId.TabIndex = 33;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtId.Visible = false;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage4.Controls.Add(this.guna2TileButton27);
            this.tabPage4.Controls.Add(this.guna2TileButton28);
            this.tabPage4.Controls.Add(this.guna2TileButton29);
            this.tabPage4.Controls.Add(this.guna2VSeparator13);
            this.tabPage4.Controls.Add(this.guna2TileButton26);
            this.tabPage4.Controls.Add(this.guna2TileButton25);
            this.tabPage4.Controls.Add(this.guna2TileButton24);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1056, 58);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Reports";
            // 
            // guna2TileButton27
            // 
            this.guna2TileButton27.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton27.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton27.BorderRadius = 10;
            this.guna2TileButton27.BorderThickness = 2;
            this.guna2TileButton27.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton27.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton27.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton27.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton27.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton27.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton27.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton27.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton27.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton27.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton27.Image = global::YamyProject.Properties.Resources._6;
            this.guna2TileButton27.Location = new System.Drawing.Point(385, 7);
            this.guna2TileButton27.Name = "guna2TileButton27";
            this.guna2TileButton27.Size = new System.Drawing.Size(94, 47);
            this.guna2TileButton27.TabIndex = 26;
            this.guna2TileButton27.Text = "Average Days To Pay Summary";
            this.guna2TileButton27.Visible = false;
            // 
            // guna2TileButton28
            // 
            this.guna2TileButton28.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton28.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton28.BorderRadius = 10;
            this.guna2TileButton28.BorderThickness = 2;
            this.guna2TileButton28.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton28.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton28.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton28.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton28.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton28.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton28.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton28.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton28.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton28.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton28.Image = global::YamyProject.Properties.Resources._5;
            this.guna2TileButton28.Location = new System.Drawing.Point(292, 7);
            this.guna2TileButton28.Name = "guna2TileButton28";
            this.guna2TileButton28.Size = new System.Drawing.Size(93, 47);
            this.guna2TileButton28.TabIndex = 25;
            this.guna2TileButton28.Text = "Sales By Customer Details";
            this.guna2TileButton28.Visible = false;
            // 
            // guna2TileButton29
            // 
            this.guna2TileButton29.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton29.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton29.BorderRadius = 10;
            this.guna2TileButton29.BorderThickness = 2;
            this.guna2TileButton29.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton29.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton29.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton29.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton29.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton29.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton29.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton29.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton29.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton29.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton29.Image = global::YamyProject.Properties.Resources._4;
            this.guna2TileButton29.Location = new System.Drawing.Point(222, 7);
            this.guna2TileButton29.Name = "guna2TileButton29";
            this.guna2TileButton29.Size = new System.Drawing.Size(70, 47);
            this.guna2TileButton29.TabIndex = 24;
            this.guna2TileButton29.Text = "View Open Invoice";
            this.guna2TileButton29.Visible = false;
            // 
            // guna2VSeparator13
            // 
            this.guna2VSeparator13.Location = new System.Drawing.Point(214, 7);
            this.guna2VSeparator13.Name = "guna2VSeparator13";
            this.guna2VSeparator13.Size = new System.Drawing.Size(8, 46);
            this.guna2VSeparator13.TabIndex = 23;
            // 
            // guna2TileButton26
            // 
            this.guna2TileButton26.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton26.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton26.BorderRadius = 10;
            this.guna2TileButton26.BorderThickness = 2;
            this.guna2TileButton26.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton26.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton26.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton26.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton26.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton26.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton26.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton26.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton26.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton26.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton26.Image = global::YamyProject.Properties.Resources._3;
            this.guna2TileButton26.Location = new System.Drawing.Point(135, 7);
            this.guna2TileButton26.Name = "guna2TileButton26";
            this.guna2TileButton26.Size = new System.Drawing.Size(79, 47);
            this.guna2TileButton26.TabIndex = 22;
            this.guna2TileButton26.Text = "Transaction Journal";
            // 
            // guna2TileButton25
            // 
            this.guna2TileButton25.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton25.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton25.BorderRadius = 10;
            this.guna2TileButton25.BorderThickness = 2;
            this.guna2TileButton25.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton25.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton25.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton25.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton25.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton25.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton25.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton25.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton25.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton25.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton25.Image = global::YamyProject.Properties.Resources._2;
            this.guna2TileButton25.Location = new System.Drawing.Point(63, 7);
            this.guna2TileButton25.Name = "guna2TileButton25";
            this.guna2TileButton25.Size = new System.Drawing.Size(72, 47);
            this.guna2TileButton25.TabIndex = 21;
            this.guna2TileButton25.Text = "Transaction History";
            // 
            // guna2TileButton24
            // 
            this.guna2TileButton24.BackColor = System.Drawing.Color.Transparent;
            this.guna2TileButton24.BorderColor = System.Drawing.Color.Transparent;
            this.guna2TileButton24.BorderRadius = 10;
            this.guna2TileButton24.BorderThickness = 2;
            this.guna2TileButton24.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2TileButton24.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton24.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton24.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton24.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton24.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton24.Font = new System.Drawing.Font("Segoe UI Semibold", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TileButton24.ForeColor = System.Drawing.Color.Black;
            this.guna2TileButton24.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.guna2TileButton24.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2TileButton24.Image = global::YamyProject.Properties.Resources._1;
            this.guna2TileButton24.Location = new System.Drawing.Point(3, 3);
            this.guna2TileButton24.Name = "guna2TileButton24";
            this.guna2TileButton24.Size = new System.Drawing.Size(60, 51);
            this.guna2TileButton24.TabIndex = 20;
            this.guna2TileButton24.Text = "Quick Report";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.guna2Panel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 449);
            this.panel1.TabIndex = 43;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tabControl1);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 194);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1064, 255);
            this.panel7.TabIndex = 19;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1064, 221);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvExpenses);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1056, 195);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Expenses";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvExpenses
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvExpenses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExpenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvExpenses.ColumnHeadersHeight = 17;
            this.dgvExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvExpenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.expId,
            this.Account,
            this.account_id,
            this.Amount,
            this.Memo,
            this.customer_job,
            this.payee_id,
            this.billable});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExpenses.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvExpenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExpenses.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvExpenses.Location = new System.Drawing.Point(3, 3);
            this.dgvExpenses.Name = "dgvExpenses";
            this.dgvExpenses.RowHeadersVisible = false;
            this.dgvExpenses.Size = new System.Drawing.Size(1050, 189);
            this.dgvExpenses.TabIndex = 0;
            this.dgvExpenses.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvExpenses.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvExpenses.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvExpenses.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvExpenses.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvExpenses.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvExpenses.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvExpenses.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvExpenses.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvExpenses.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvExpenses.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvExpenses.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvExpenses.ThemeStyle.HeaderStyle.Height = 17;
            this.dgvExpenses.ThemeStyle.ReadOnly = false;
            this.dgvExpenses.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvExpenses.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvExpenses.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvExpenses.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvExpenses.ThemeStyle.RowsStyle.Height = 22;
            this.dgvExpenses.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvExpenses.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvExpenses.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpenses_CellValueChanged);
            // 
            // expId
            // 
            this.expId.HeaderText = "Id";
            this.expId.Name = "expId";
            this.expId.ReadOnly = true;
            this.expId.Visible = false;
            // 
            // Account
            // 
            this.Account.HeaderText = "Account";
            this.Account.Name = "Account";
            this.Account.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Account.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // account_id
            // 
            this.account_id.HeaderText = "account_id";
            this.account_id.Name = "account_id";
            this.account_id.ReadOnly = true;
            this.account_id.Visible = false;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // Memo
            // 
            this.Memo.HeaderText = "Memo";
            this.Memo.Name = "Memo";
            // 
            // customer_job
            // 
            this.customer_job.HeaderText = "Customer:Job";
            this.customer_job.Name = "customer_job";
            // 
            // payee_id
            // 
            this.payee_id.HeaderText = "payee_id";
            this.payee_id.Name = "payee_id";
            this.payee_id.ReadOnly = true;
            this.payee_id.Visible = false;
            // 
            // billable
            // 
            this.billable.HeaderText = "Billable?";
            this.billable.Name = "billable";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvItems);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1056, 195);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Items";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvItems
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvItems.ColumnHeadersHeight = 17;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_item,
            this.item,
            this.item_id,
            this.Description,
            this.qty,
            this.cost,
            this.item_amount,
            this.item_customer_job,
            this.item_customer_id,
            this.item_billable});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvItems.Location = new System.Drawing.Point(3, 3);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.Size = new System.Drawing.Size(1050, 189);
            this.dgvItems.TabIndex = 1;
            this.dgvItems.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvItems.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvItems.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvItems.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvItems.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvItems.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvItems.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvItems.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvItems.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvItems.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItems.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvItems.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvItems.ThemeStyle.HeaderStyle.Height = 17;
            this.dgvItems.ThemeStyle.ReadOnly = false;
            this.dgvItems.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvItems.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvItems.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItems.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvItems.ThemeStyle.RowsStyle.Height = 22;
            this.dgvItems.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvItems.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellValueChanged);
            // 
            // Id_item
            // 
            this.Id_item.HeaderText = "Id";
            this.Id_item.Name = "Id_item";
            this.Id_item.ReadOnly = true;
            this.Id_item.Visible = false;
            // 
            // item
            // 
            this.item.HeaderText = "Item";
            this.item.Name = "item";
            // 
            // item_id
            // 
            this.item_id.HeaderText = "itemId";
            this.item_id.Name = "item_id";
            this.item_id.ReadOnly = true;
            this.item_id.Visible = false;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // qty
            // 
            this.qty.HeaderText = "Qty";
            this.qty.Name = "qty";
            // 
            // cost
            // 
            this.cost.HeaderText = "Cost";
            this.cost.Name = "cost";
            // 
            // item_amount
            // 
            this.item_amount.HeaderText = "Amount";
            this.item_amount.Name = "item_amount";
            // 
            // item_customer_job
            // 
            this.item_customer_job.HeaderText = "Customer:Job";
            this.item_customer_job.Name = "item_customer_job";
            // 
            // item_customer_id
            // 
            this.item_customer_id.HeaderText = "item_customer_id";
            this.item_customer_id.Name = "item_customer_id";
            this.item_customer_id.ReadOnly = true;
            this.item_customer_id.Visible = false;
            // 
            // item_billable
            // 
            this.item_billable.HeaderText = "Billable";
            this.item_billable.Name = "item_billable";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnSave);
            this.panel8.Controls.Add(this.btnClear);
            this.panel8.Controls.Add(this.btnClose);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 221);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1064, 34);
            this.panel8.TabIndex = 18;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BorderRadius = 5;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(764, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 24);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BorderRadius = 5;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(864, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 24);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderRadius = 5;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(964, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 24);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 42);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(10);
            this.panel6.Size = new System.Drawing.Size(1064, 152);
            this.panel6.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtAmount);
            this.panel2.Controls.Add(this.txtAmountInWord);
            this.panel2.Controls.Add(this.dtOpen);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtMemo);
            this.panel2.Controls.Add(this.cmbSubAccount);
            this.panel2.Controls.Add(this.lblDescription);
            this.panel2.Controls.Add(this.lblSubAccount);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1044, 132);
            this.panel2.TabIndex = 17;
            // 
            // txtAmount
            // 
            this.txtAmount.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtAmount.BorderRadius = 3;
            this.txtAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmount.DefaultText = "";
            this.txtAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAmount.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.Color.Black;
            this.txtAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmount.Location = new System.Drawing.Point(586, 20);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtAmount.PlaceholderText = "Amount";
            this.txtAmount.SelectedText = "";
            this.txtAmount.Size = new System.Drawing.Size(152, 25);
            this.txtAmount.TabIndex = 29;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // txtAmountInWord
            // 
            this.txtAmountInWord.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtAmountInWord.BorderRadius = 3;
            this.txtAmountInWord.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmountInWord.DefaultText = "";
            this.txtAmountInWord.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAmountInWord.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAmountInWord.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAmountInWord.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAmountInWord.Enabled = false;
            this.txtAmountInWord.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtAmountInWord.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmountInWord.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountInWord.ForeColor = System.Drawing.Color.Black;
            this.txtAmountInWord.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmountInWord.Location = new System.Drawing.Point(586, 54);
            this.txtAmountInWord.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAmountInWord.Name = "txtAmountInWord";
            this.txtAmountInWord.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtAmountInWord.PlaceholderText = "Amount In Word";
            this.txtAmountInWord.SelectedText = "";
            this.txtAmountInWord.Size = new System.Drawing.Size(443, 25);
            this.txtAmountInWord.TabIndex = 28;
            // 
            // dtOpen
            // 
            this.dtOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtOpen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dtOpen.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtOpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtOpen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtOpen.Location = new System.Drawing.Point(884, 17);
            this.dtOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtOpen.Name = "dtOpen";
            this.dtOpen.Size = new System.Drawing.Size(133, 22);
            this.dtOpen.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(51)))), ((int)(((byte)(67)))));
            this.label2.Location = new System.Drawing.Point(881, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMemo
            // 
            this.txtMemo.BorderRadius = 5;
            this.txtMemo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMemo.DefaultText = "";
            this.txtMemo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMemo.Location = new System.Drawing.Point(16, 84);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.PlaceholderText = "";
            this.txtMemo.SelectedText = "";
            this.txtMemo.Size = new System.Drawing.Size(734, 41);
            this.txtMemo.TabIndex = 11;
            // 
            // cmbSubAccount
            // 
            this.cmbSubAccount.BackColor = System.Drawing.Color.Transparent;
            this.cmbSubAccount.BorderRadius = 5;
            this.cmbSubAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSubAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubAccount.FocusedColor = System.Drawing.Color.Empty;
            this.cmbSubAccount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSubAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbSubAccount.ItemHeight = 22;
            this.cmbSubAccount.Location = new System.Drawing.Point(16, 17);
            this.cmbSubAccount.Name = "cmbSubAccount";
            this.cmbSubAccount.Size = new System.Drawing.Size(300, 28);
            this.cmbSubAccount.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(13, 71);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 23);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Memo";
            // 
            // lblSubAccount
            // 
            this.lblSubAccount.AutoSize = true;
            this.lblSubAccount.Location = new System.Drawing.Point(13, 4);
            this.lblSubAccount.Name = "lblSubAccount";
            this.lblSubAccount.Size = new System.Drawing.Size(94, 13);
            this.lblSubAccount.TabIndex = 4;
            this.lblSubAccount.Text = "Pay to the order of";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.cmbBankAccount);
            this.guna2Panel1.Controls.Add(this.txtBalance);
            this.guna2Panel1.Controls.Add(this.lblBankAccount);
            this.guna2Panel1.Controls.Add(this.lblName);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1064, 42);
            this.guna2Panel1.TabIndex = 15;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "account_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 206;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 206;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Memo";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 206;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Customer:Job";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 206;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "payee_id";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 206;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Item";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 147;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "itemId";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 147;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Description";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 147;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 147;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Cost";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 148;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 147;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Customer:Job";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 147;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "item_customer_id";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Visible = false;
            this.dataGridViewTextBoxColumn13.Width = 147;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "item_customer_id";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Visible = false;
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
            this.headerUC1.Size = new System.Drawing.Size(1068, 30);
            this.headerUC1.TabIndex = 15;
            // 
            // frmWriteCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1068, 565);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.headerUC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmWriteCheque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Write Cheque";
            this.Load += new System.EventHandler(this.frmWriteCheque_Load);
            this.panel9.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna2TextBox txtBalance;
        private Guna2ComboBox cmbBankAccount;
        private Label lblName;
        private Label lblBankAccount;
        private HeaderUC headerUC1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel5;
        private Panel panel9;
        private TabControl tabControl2;
        private TabPage tabPage3;
        private TextBox txtPVCode;
        private Guna2Button btnNext;
        private Guna2Button btnPrevious;
        private Guna2VSeparator guna2VSeparator12;
        private Guna2TileButton guna2TileButton1;
        private Guna2TileButton guna2TileButton15;
        private Guna2TileButton BtnSaveNew;
        private Guna2VSeparator guna2VSeparator9;
        private Guna2TileButton BtnDelete;
        private Guna2TileButton BtnAttach;
        private Guna2TileButton BtnCopy;
        private Guna2VSeparator guna2VSeparator10;
        private Guna2TileButton guna2TileButton19;
        private Guna2VSeparator guna2VSeparator11;
        private CheckBox chkPrint;
        private Guna2TileButton BtnPrint;
        private Guna2TileButton BtnEmail;
        private TextBox txtId;
        private TabPage tabPage4;
        private Guna2TileButton guna2TileButton27;
        private Guna2TileButton guna2TileButton28;
        private Guna2TileButton guna2TileButton29;
        private Guna2VSeparator guna2VSeparator13;
        private Guna2TileButton guna2TileButton26;
        private Guna2TileButton guna2TileButton25;
        private Guna2TileButton guna2TileButton24;
        private Panel panel1;
        private Guna2Panel guna2Panel1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Guna2DataGridView dgvExpenses;
        private Guna2DataGridView dgvItems;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private Panel panel6;
        private Panel panel2;
        private Guna2TextBox txtAmount;
        private Guna2TextBox txtAmountInWord;
        private DateTimePicker dtOpen;
        private Label label2;
        private Guna2TextBox txtMemo;
        private Guna2ComboBox cmbSubAccount;
        private Label lblDescription;
        private Label lblSubAccount;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private Panel panel7;
        private Panel panel8;
        private Guna2Button btnSave;
        private Guna2Button btnClear;
        private Guna2Button btnClose;
        private DataGridViewTextBoxColumn expId;
        private DataGridViewTextBoxColumn Account;
        private DataGridViewTextBoxColumn account_id;
        private DataGridViewTextBoxColumn Amount;
        private DataGridViewTextBoxColumn Memo;
        private DataGridViewTextBoxColumn customer_job;
        private DataGridViewTextBoxColumn payee_id;
        private DataGridViewCheckBoxColumn billable;
        private DataGridViewTextBoxColumn Id_item;
        private DataGridViewTextBoxColumn item;
        private DataGridViewTextBoxColumn item_id;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn qty;
        private DataGridViewTextBoxColumn cost;
        private DataGridViewTextBoxColumn item_amount;
        private DataGridViewTextBoxColumn item_customer_job;
        private DataGridViewTextBoxColumn item_customer_id;
        private DataGridViewCheckBoxColumn item_billable;
    }
}