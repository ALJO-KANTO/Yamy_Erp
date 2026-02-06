using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.FinanceBilling
{
    partial class InvoiceForm
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
            this.lblInv = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCust = new System.Windows.Forms.Label();
            this.cmbCustomer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblProj = new System.Windows.Forms.Label();
            this.cmbProject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblAmt = new System.Windows.Forms.Label();
            this.txtAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInv
            // 
            this.lblInv.Location = new System.Drawing.Point(20, 46);
            this.lblInv.Name = "lblInv";
            this.lblInv.Size = new System.Drawing.Size(100, 17);
            this.lblInv.TabIndex = 0;
            this.lblInv.Text = "Invoice No";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BorderRadius = 5;
            this.txtInvoiceNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInvoiceNo.DefaultText = "";
            this.txtInvoiceNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtInvoiceNo.Location = new System.Drawing.Point(20, 66);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.PlaceholderText = "";
            this.txtInvoiceNo.SelectedText = "";
            this.txtInvoiceNo.Size = new System.Drawing.Size(100, 24);
            this.txtInvoiceNo.TabIndex = 1;
            // 
            // lblCust
            // 
            this.lblCust.Location = new System.Drawing.Point(20, 107);
            this.lblCust.Name = "lblCust";
            this.lblCust.Size = new System.Drawing.Size(100, 14);
            this.lblCust.TabIndex = 2;
            this.lblCust.Text = "Customer";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.BackColor = System.Drawing.Color.Transparent;
            this.cmbCustomer.BorderRadius = 5;
            this.cmbCustomer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FocusedColor = System.Drawing.Color.Empty;
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbCustomer.ItemHeight = 20;
            this.cmbCustomer.Location = new System.Drawing.Point(20, 124);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(264, 26);
            this.cmbCustomer.TabIndex = 3;
            // 
            // lblProj
            // 
            this.lblProj.Location = new System.Drawing.Point(20, 166);
            this.lblProj.Name = "lblProj";
            this.lblProj.Size = new System.Drawing.Size(100, 14);
            this.lblProj.TabIndex = 4;
            this.lblProj.Text = "Project";
            // 
            // cmbProject
            // 
            this.cmbProject.BackColor = System.Drawing.Color.Transparent;
            this.cmbProject.BorderRadius = 5;
            this.cmbProject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FocusedColor = System.Drawing.Color.Empty;
            this.cmbProject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbProject.ItemHeight = 20;
            this.cmbProject.Location = new System.Drawing.Point(20, 183);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(264, 26);
            this.cmbProject.TabIndex = 5;
            // 
            // lblAmt
            // 
            this.lblAmt.Location = new System.Drawing.Point(20, 226);
            this.lblAmt.Name = "lblAmt";
            this.lblAmt.Size = new System.Drawing.Size(100, 14);
            this.lblAmt.TabIndex = 6;
            this.lblAmt.Text = "Invoice Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.BorderRadius = 5;
            this.txtAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmount.DefaultText = "";
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAmount.Location = new System.Drawing.Point(20, 243);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PlaceholderText = "";
            this.txtAmount.SelectedText = "";
            this.txtAmount.Size = new System.Drawing.Size(115, 24);
            this.txtAmount.TabIndex = 7;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(20, 284);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save Invoice";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(253, 284);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(115, 30);
            this.guna2Button1.TabIndex = 9;
            this.guna2Button1.Text = "Close";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 26);
            this.panel1.TabIndex = 16;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(380, 20);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Customer Invoice";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 321);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(376, 2);
            this.panel3.TabIndex = 30;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(378, 26);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 297);
            this.panel4.TabIndex = 29;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 26);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 297);
            this.panel5.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(184, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 14);
            this.label1.TabIndex = 31;
            this.label1.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbStatus.BorderRadius = 5;
            this.cmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FocusedColor = System.Drawing.Color.Empty;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbStatus.ItemHeight = 20;
            this.cmbStatus.Items.AddRange(new object[] {
            "Unpaid",
            "Paid"});
            this.cmbStatus.Location = new System.Drawing.Point(184, 243);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(100, 26);
            this.cmbStatus.TabIndex = 32;
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(187, 66);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(97, 20);
            this.dtpInvoiceDate.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(184, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "Date";
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 323);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpInvoiceDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.lblCust);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.lblProj);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.lblAmt);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblInv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InvoiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Invoice";
            this.Load += new System.EventHandler(this.InvoiceForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        Guna2TextBox txtInvoiceNo, txtAmount;
        Guna2ComboBox cmbCustomer, cmbProject;
        Guna2Button btnSave;
        private Label lblInv;
        private Label lblCust;
        private Label lblProj;
        private Label lblAmt;
        private Guna2Button guna2Button1;
        private Panel panel1;
        private Label lblHeader;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Label label1;
        private Guna2ComboBox cmbStatus;
        private DateTimePicker dtpInvoiceDate;
        private Label label2;
    }
}