using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace YamyProject.UI.Banking
{
    partial class frmCreditCardRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreditCardRegister));
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.cmbAccountType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSubAccount = new System.Windows.Forms.Label();
            this.cmbSubAccount = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.cmbCurrency = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.txtAccountNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.headerUC1 = new YamyProject.HeaderUC();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(27, 58);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Card Name";
            // 
            // txtName
            // 
            this.txtName.BorderRadius = 5;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.Location = new System.Drawing.Point(167, 55);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(300, 26);
            this.txtName.TabIndex = 1;
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Location = new System.Drawing.Point(27, 98);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(74, 13);
            this.lblAccountType.TabIndex = 2;
            this.lblAccountType.Text = "Account Type";
            // 
            // cmbAccountType
            // 
            this.cmbAccountType.BackColor = System.Drawing.Color.Transparent;
            this.cmbAccountType.BorderRadius = 5;
            this.cmbAccountType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountType.FocusedColor = System.Drawing.Color.Empty;
            this.cmbAccountType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAccountType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbAccountType.ItemHeight = 22;
            this.cmbAccountType.Location = new System.Drawing.Point(167, 95);
            this.cmbAccountType.Name = "cmbAccountType";
            this.cmbAccountType.Size = new System.Drawing.Size(300, 28);
            this.cmbAccountType.TabIndex = 3;
            this.cmbAccountType.SelectedIndexChanged += new System.EventHandler(this.cmbAccountType_SelectedIndexChanged);
            // 
            // lblSubAccount
            // 
            this.lblSubAccount.AutoSize = true;
            this.lblSubAccount.Location = new System.Drawing.Point(27, 138);
            this.lblSubAccount.Name = "lblSubAccount";
            this.lblSubAccount.Size = new System.Drawing.Size(64, 13);
            this.lblSubAccount.TabIndex = 4;
            this.lblSubAccount.Text = "GL Account";
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
            this.cmbSubAccount.Location = new System.Drawing.Point(167, 135);
            this.cmbSubAccount.Name = "cmbSubAccount";
            this.cmbSubAccount.Size = new System.Drawing.Size(300, 28);
            this.cmbSubAccount.TabIndex = 5;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(27, 178);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(49, 13);
            this.lblCurrency.TabIndex = 6;
            this.lblCurrency.Text = "Currency";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.BackColor = System.Drawing.Color.Transparent;
            this.cmbCurrency.BorderRadius = 5;
            this.cmbCurrency.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FocusedColor = System.Drawing.Color.Empty;
            this.cmbCurrency.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCurrency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbCurrency.ItemHeight = 22;
            this.cmbCurrency.Location = new System.Drawing.Point(167, 175);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(150, 28);
            this.cmbCurrency.TabIndex = 7;
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(27, 218);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(89, 13);
            this.lblAccountNo.TabIndex = 8;
            this.lblAccountNo.Text = "Card Account No";
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.BorderRadius = 5;
            this.txtAccountNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAccountNo.DefaultText = "";
            this.txtAccountNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAccountNo.Location = new System.Drawing.Point(167, 215);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.PlaceholderText = "";
            this.txtAccountNo.SelectedText = "";
            this.txtAccountNo.Size = new System.Drawing.Size(300, 26);
            this.txtAccountNo.TabIndex = 9;
            this.txtAccountNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericOnly_KeyPress);
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(27, 258);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 23);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderRadius = 5;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescription.Location = new System.Drawing.Point(167, 255);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "";
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(300, 70);
            this.txtDescription.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(167, 353);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 33);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BorderRadius = 5;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(267, 353);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 33);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 5;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(367, 353);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 33);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.headerUC1.Size = new System.Drawing.Size(504, 30);
            this.headerUC1.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(502, 37);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 362);
            this.panel4.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 37);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 362);
            this.panel3.TabIndex = 17;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(2, 397);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(500, 2);
            this.panel5.TabIndex = 18;
            // 
            // frmCreditCardRegister
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(504, 399);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.headerUC1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblAccountType);
            this.Controls.Add(this.cmbAccountType);
            this.Controls.Add(this.lblSubAccount);
            this.Controls.Add(this.cmbSubAccount);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.cmbCurrency);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.txtAccountNo);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCreditCardRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credit Card";
            this.Load += new System.EventHandler(this.frmCreditCardRegister_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.Panel pnlHeader;
        //private System.Windows.Forms.Label lblAccountName;
        //private System.Windows.Forms.Label lblBalance;

        //private System.Windows.Forms.Panel pnlFilter;
        //private Guna2ComboBox cmbCreditCard;
        //private System.Windows.Forms.Label lblCard;
        //private System.Windows.Forms.DateTimePicker dtFrom;
        //private System.Windows.Forms.DateTimePicker dtTo;
        //private System.Windows.Forms.Label lblFrom;
        //private System.Windows.Forms.Label lblTo;
        //private Guna2TextBox txtSearch;

        //private Guna2DataGridView dgvRegister;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        //private Guna2Button btnAdd;
        //private System.Windows.Forms.Panel panel4;
        //private System.Windows.Forms.Panel panel3;
        //private System.Windows.Forms.Panel panel5;
        //private System.Windows.Forms.Label label1;
        //private Guna2TextBox txtRef;
        //private Guna2TextBox txtMemo;
        //private Guna2TextBox txtPayee;
        //private System.Windows.Forms.Label label2;
        //private System.Windows.Forms.Label label3;
        //private Guna2TextBox txtCredit;
        //private System.Windows.Forms.Label label5;
        //private Guna2TextBox txtCharge;
        //private System.Windows.Forms.Label label4;
        private Guna2TextBox txtName;
        private Guna2ComboBox cmbAccountType;
        private Guna2ComboBox cmbSubAccount;
        private Guna2ComboBox cmbCurrency;
        private Guna2TextBox txtAccountNo;
        private Guna2TextBox txtDescription;

        private Guna2Button btnSave;
        private Guna2Button btnClear;
        private Guna2Button btnClose;
        private Label lblName;
        private Label lblAccountType;
        private Label lblSubAccount;
        private Label lblCurrency;
        private Label lblAccountNo;
        private Label lblDescription;
        private HeaderUC headerUC1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel5;
    }
}