using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.CRM
{
    partial class ContractForm
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
            this.lblNo = new System.Windows.Forms.Label();
            this.txtContractNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCust = new System.Windows.Forms.Label();
            this.cmbCustomer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblVal = new System.Windows.Forms.Label();
            this.txtContractValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNo
            // 
            this.lblNo.Location = new System.Drawing.Point(20, 44);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(100, 23);
            this.lblNo.TabIndex = 0;
            this.lblNo.Text = "Contract No";
            // 
            // txtContractNo
            // 
            this.txtContractNo.BorderRadius = 5;
            this.txtContractNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContractNo.DefaultText = "";
            this.txtContractNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtContractNo.Location = new System.Drawing.Point(20, 57);
            this.txtContractNo.Name = "txtContractNo";
            this.txtContractNo.PlaceholderText = "";
            this.txtContractNo.SelectedText = "";
            this.txtContractNo.Size = new System.Drawing.Size(200, 30);
            this.txtContractNo.TabIndex = 1;
            // 
            // lblCust
            // 
            this.lblCust.Location = new System.Drawing.Point(20, 101);
            this.lblCust.Name = "lblCust";
            this.lblCust.Size = new System.Drawing.Size(100, 23);
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
            this.cmbCustomer.ItemHeight = 22;
            this.cmbCustomer.Items.AddRange(new object[] {
            "ABC Contracting",
            "XYZ Mall"});
            this.cmbCustomer.Location = new System.Drawing.Point(20, 115);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(352, 28);
            this.cmbCustomer.TabIndex = 3;
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(20, 157);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(100, 23);
            this.lblStart.TabIndex = 4;
            this.lblStart.Text = "Start Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(20, 177);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(110, 20);
            this.dtpStartDate.TabIndex = 5;
            // 
            // lblEnd
            // 
            this.lblEnd.Location = new System.Drawing.Point(253, 157);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(100, 23);
            this.lblEnd.TabIndex = 6;
            this.lblEnd.Text = "End Date";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(253, 177);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(110, 20);
            this.dtpEndDate.TabIndex = 7;
            // 
            // lblVal
            // 
            this.lblVal.Location = new System.Drawing.Point(20, 213);
            this.lblVal.Name = "lblVal";
            this.lblVal.Size = new System.Drawing.Size(100, 23);
            this.lblVal.TabIndex = 8;
            this.lblVal.Text = "Contract Value";
            // 
            // txtContractValue
            // 
            this.txtContractValue.BorderRadius = 5;
            this.txtContractValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContractValue.DefaultText = "";
            this.txtContractValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtContractValue.Location = new System.Drawing.Point(20, 229);
            this.txtContractValue.Name = "txtContractValue";
            this.txtContractValue.PlaceholderText = "";
            this.txtContractValue.SelectedText = "";
            this.txtContractValue.Size = new System.Drawing.Size(200, 30);
            this.txtContractValue.TabIndex = 9;
            this.txtContractValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContractValue_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(20, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 30);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save Contract";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(278, 279);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(110, 30);
            this.guna2Button1.TabIndex = 11;
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
            this.panel1.Size = new System.Drawing.Size(400, 26);
            this.panel1.TabIndex = 18;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(400, 20);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Customer Contract";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 26);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 297);
            this.panel5.TabIndex = 25;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 321);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(396, 2);
            this.panel3.TabIndex = 27;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(398, 26);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 297);
            this.panel4.TabIndex = 26;
            // 
            // ContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 323);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.txtContractNo);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.txtContractValue);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblNo);
            this.Controls.Add(this.lblCust);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblVal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ContractForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Contract";
            this.Load += new System.EventHandler(this.ContractForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        Guna2TextBox txtContractNo, txtContractValue;
        Guna2ComboBox cmbCustomer;
        DateTimePicker dtpStartDate, dtpEndDate;
        Guna2Button btnSave;
        private Label lblNo;
        private Label lblCust;
        private Label lblStart;
        private Label lblEnd;
        private Label lblVal;
        private Guna2Button guna2Button1;
        private Panel panel1;
        private Label lblHeader;
        private Panel panel5;
        private Panel panel3;
        private Panel panel4;
    }
}