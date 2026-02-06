using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.HRPayroll
{
    partial class PayrollForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayrollForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblBasic = new System.Windows.Forms.Label();
            this.txtBasic = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblOT = new System.Windows.Forms.Label();
            this.txtOvertime = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDed = new System.Windows.Forms.Label();
            this.txtDeductions = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNet = new System.Windows.Forms.Label();
            this.txtNet = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCalculate = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 26);
            this.panel1.TabIndex = 14;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(374, 20);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Payroll Calculation";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBasic
            // 
            this.lblBasic.Location = new System.Drawing.Point(26, 91);
            this.lblBasic.Name = "lblBasic";
            this.lblBasic.Size = new System.Drawing.Size(100, 23);
            this.lblBasic.TabIndex = 0;
            this.lblBasic.Text = "Basic Salary";
            // 
            // txtBasic
            // 
            this.txtBasic.BorderRadius = 5;
            this.txtBasic.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBasic.DefaultText = "";
            this.txtBasic.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBasic.Location = new System.Drawing.Point(26, 107);
            this.txtBasic.Name = "txtBasic";
            this.txtBasic.PlaceholderText = "";
            this.txtBasic.SelectedText = "";
            this.txtBasic.Size = new System.Drawing.Size(200, 36);
            this.txtBasic.TabIndex = 1;
            this.txtBasic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNum_KeyPress);
            // 
            // lblOT
            // 
            this.lblOT.Location = new System.Drawing.Point(26, 155);
            this.lblOT.Name = "lblOT";
            this.lblOT.Size = new System.Drawing.Size(100, 23);
            this.lblOT.TabIndex = 2;
            this.lblOT.Text = "Overtime";
            // 
            // txtOvertime
            // 
            this.txtOvertime.BorderRadius = 5;
            this.txtOvertime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOvertime.DefaultText = "";
            this.txtOvertime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOvertime.Location = new System.Drawing.Point(26, 170);
            this.txtOvertime.Name = "txtOvertime";
            this.txtOvertime.PlaceholderText = "";
            this.txtOvertime.SelectedText = "";
            this.txtOvertime.Size = new System.Drawing.Size(200, 36);
            this.txtOvertime.TabIndex = 3;
            this.txtOvertime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNum_KeyPress);
            // 
            // lblDed
            // 
            this.lblDed.Location = new System.Drawing.Point(26, 221);
            this.lblDed.Name = "lblDed";
            this.lblDed.Size = new System.Drawing.Size(100, 23);
            this.lblDed.TabIndex = 4;
            this.lblDed.Text = "Deductions";
            // 
            // txtDeductions
            // 
            this.txtDeductions.BorderRadius = 5;
            this.txtDeductions.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDeductions.DefaultText = "";
            this.txtDeductions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDeductions.Location = new System.Drawing.Point(26, 236);
            this.txtDeductions.Name = "txtDeductions";
            this.txtDeductions.PlaceholderText = "";
            this.txtDeductions.SelectedText = "";
            this.txtDeductions.Size = new System.Drawing.Size(200, 36);
            this.txtDeductions.TabIndex = 5;
            this.txtDeductions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNum_KeyPress);
            // 
            // lblNet
            // 
            this.lblNet.Location = new System.Drawing.Point(26, 290);
            this.lblNet.Name = "lblNet";
            this.lblNet.Size = new System.Drawing.Size(100, 23);
            this.lblNet.TabIndex = 6;
            this.lblNet.Text = "Net Salary";
            // 
            // txtNet
            // 
            this.txtNet.BorderRadius = 5;
            this.txtNet.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNet.DefaultText = "";
            this.txtNet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNet.Location = new System.Drawing.Point(26, 304);
            this.txtNet.Name = "txtNet";
            this.txtNet.PlaceholderText = "";
            this.txtNet.ReadOnly = true;
            this.txtNet.SelectedText = "";
            this.txtNet.Size = new System.Drawing.Size(200, 36);
            this.txtNet.TabIndex = 7;
            this.txtNet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNum_KeyPress);
            // 
            // btnCalculate
            // 
            this.btnCalculate.BorderRadius = 5;
            this.btnCalculate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.Location = new System.Drawing.Point(125, 346);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(84, 31);
            this.btnCalculate.TabIndex = 8;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 5;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(279, 346);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 31);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 384);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(370, 2);
            this.panel3.TabIndex = 30;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(372, 26);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 360);
            this.panel4.TabIndex = 29;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 26);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 360);
            this.panel5.TabIndex = 28;
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(152, 32);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(72, 21);
            this.cmbYear.TabIndex = 33;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbMonth.Location = new System.Drawing.Point(68, 32);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(37, 21);
            this.cmbMonth.TabIndex = 34;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Month";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Year";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(26, 64);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(200, 14);
            this.lblName.TabIndex = 35;
            this.lblName.Text = "name";
            // 
            // PayrollForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 386);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtBasic);
            this.Controls.Add(this.txtOvertime);
            this.Controls.Add(this.txtDeductions);
            this.Controls.Add(this.txtNet);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblBasic);
            this.Controls.Add(this.lblOT);
            this.Controls.Add(this.lblDed);
            this.Controls.Add(this.lblNet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PayrollForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payroll Calculation";
            this.Load += new System.EventHandler(this.PayrollForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHeader;
        Guna2TextBox txtBasic, txtOvertime, txtDeductions, txtNet;
        Guna2Button btnCalculate;
        private Label lblBasic;
        private Label lblOT;
        private Label lblDed;
        private Label lblNet;
        private Guna2Button btnClose;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private ComboBox cmbYear;
        private ComboBox cmbMonth;
        private Label label3;
        private Label label4;
        private Label lblName;
    }
}