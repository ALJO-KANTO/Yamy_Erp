using System.Windows.Forms;

namespace YamyProject.UI.Reports.Inventory
{
    partial class frmStockLedger
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

        private Panel pnlTop;
        private Label lblTitle;

        private GroupBox grpFilters;
        private GroupBox grpSummary;

        private DateTimePicker dtFrom;
        private DateTimePicker dtTo;

        private ComboBox cmbItem;
        private ComboBox cmbWarehouse;
        private ComboBox cmbProject;

        private ComboBox cmbViewType;

        private Button btnLoad;
        private Button btnPrint;
        private Button btnExport;

        private DataGridView dgvLedger;

        private TextBox txtTotalIn;
        private TextBox txtTotalOut;
        private TextBox txtClosing;

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpFilters = new System.Windows.Forms.GroupBox();
            this.f1 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.f2 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.f3 = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.f4 = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.f5 = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.f6 = new System.Windows.Forms.Label();
            this.cmbViewType = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.s1 = new System.Windows.Forms.Label();
            this.txtTotalIn = new System.Windows.Forms.TextBox();
            this.s2 = new System.Windows.Forms.Label();
            this.txtTotalOut = new System.Windows.Forms.TextBox();
            this.s3 = new System.Windows.Forms.Label();
            this.txtClosing = new System.Windows.Forms.TextBox();
            this.dgvLedger = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.grpFilters.SuspendLayout();
            this.grpSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedger)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1184, 55);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(253, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "STOCK LEDGER / BIN CARD";
            // 
            // grpFilters
            // 
            this.grpFilters.Controls.Add(this.f1);
            this.grpFilters.Controls.Add(this.dtFrom);
            this.grpFilters.Controls.Add(this.f2);
            this.grpFilters.Controls.Add(this.dtTo);
            this.grpFilters.Controls.Add(this.f3);
            this.grpFilters.Controls.Add(this.cmbItem);
            this.grpFilters.Controls.Add(this.f4);
            this.grpFilters.Controls.Add(this.cmbWarehouse);
            this.grpFilters.Controls.Add(this.f5);
            this.grpFilters.Controls.Add(this.cmbProject);
            this.grpFilters.Controls.Add(this.f6);
            this.grpFilters.Controls.Add(this.cmbViewType);
            this.grpFilters.Controls.Add(this.btnLoad);
            this.grpFilters.Controls.Add(this.btnPrint);
            this.grpFilters.Controls.Add(this.btnExport);
            this.grpFilters.Location = new System.Drawing.Point(10, 65);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Size = new System.Drawing.Size(1160, 110);
            this.grpFilters.TabIndex = 1;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "Filters";
            // 
            // f1
            // 
            this.f1.Location = new System.Drawing.Point(15, 30);
            this.f1.Name = "f1";
            this.f1.Size = new System.Drawing.Size(40, 25);
            this.f1.TabIndex = 0;
            this.f1.Text = "From";
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(60, 25);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(150, 20);
            this.dtFrom.TabIndex = 1;
            // 
            // f2
            // 
            this.f2.Location = new System.Drawing.Point(230, 30);
            this.f2.Name = "f2";
            this.f2.Size = new System.Drawing.Size(25, 25);
            this.f2.TabIndex = 2;
            this.f2.Text = "To";
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(260, 25);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(150, 20);
            this.dtTo.TabIndex = 3;
            // 
            // f3
            // 
            this.f3.Location = new System.Drawing.Point(430, 30);
            this.f3.Name = "f3";
            this.f3.Size = new System.Drawing.Size(35, 25);
            this.f3.TabIndex = 4;
            this.f3.Text = "Item";
            // 
            // cmbItem
            // 
            this.cmbItem.Location = new System.Drawing.Point(470, 25);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(250, 21);
            this.cmbItem.TabIndex = 5;
            // 
            // f4
            // 
            this.f4.Location = new System.Drawing.Point(740, 30);
            this.f4.Name = "f4";
            this.f4.Size = new System.Drawing.Size(70, 25);
            this.f4.TabIndex = 6;
            this.f4.Text = "Warehouse";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.Location = new System.Drawing.Point(815, 25);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(220, 21);
            this.cmbWarehouse.TabIndex = 7;
            // 
            // f5
            // 
            this.f5.Location = new System.Drawing.Point(15, 70);
            this.f5.Name = "f5";
            this.f5.Size = new System.Drawing.Size(50, 25);
            this.f5.TabIndex = 8;
            this.f5.Text = "Project";
            // 
            // cmbProject
            // 
            this.cmbProject.Location = new System.Drawing.Point(70, 65);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(250, 21);
            this.cmbProject.TabIndex = 9;
            // 
            // f6
            // 
            this.f6.Location = new System.Drawing.Point(340, 70);
            this.f6.Name = "f6";
            this.f6.Size = new System.Drawing.Size(40, 25);
            this.f6.TabIndex = 10;
            this.f6.Text = "View";
            // 
            // cmbViewType
            // 
            this.cmbViewType.Location = new System.Drawing.Point(385, 65);
            this.cmbViewType.Name = "cmbViewType";
            this.cmbViewType.Size = new System.Drawing.Size(180, 21);
            this.cmbViewType.TabIndex = 11;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(620, 63);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 30);
            this.btnLoad.TabIndex = 12;
            this.btnLoad.Text = "Load";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(730, 63);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 30);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(840, 63);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 30);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // grpSummary
            // 
            this.grpSummary.Controls.Add(this.s1);
            this.grpSummary.Controls.Add(this.txtTotalIn);
            this.grpSummary.Controls.Add(this.s2);
            this.grpSummary.Controls.Add(this.txtTotalOut);
            this.grpSummary.Controls.Add(this.s3);
            this.grpSummary.Controls.Add(this.txtClosing);
            this.grpSummary.Location = new System.Drawing.Point(630, 580);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(540, 70);
            this.grpSummary.TabIndex = 3;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "Summary";
            // 
            // s1
            // 
            this.s1.Location = new System.Drawing.Point(15, 30);
            this.s1.Name = "s1";
            this.s1.Size = new System.Drawing.Size(55, 25);
            this.s1.TabIndex = 0;
            this.s1.Text = "Total In";
            // 
            // txtTotalIn
            // 
            this.txtTotalIn.Location = new System.Drawing.Point(75, 25);
            this.txtTotalIn.Name = "txtTotalIn";
            this.txtTotalIn.Size = new System.Drawing.Size(100, 20);
            this.txtTotalIn.TabIndex = 1;
            // 
            // s2
            // 
            this.s2.Location = new System.Drawing.Point(190, 30);
            this.s2.Name = "s2";
            this.s2.Size = new System.Drawing.Size(60, 25);
            this.s2.TabIndex = 2;
            this.s2.Text = "Total Out";
            // 
            // txtTotalOut
            // 
            this.txtTotalOut.Location = new System.Drawing.Point(255, 25);
            this.txtTotalOut.Name = "txtTotalOut";
            this.txtTotalOut.Size = new System.Drawing.Size(100, 20);
            this.txtTotalOut.TabIndex = 3;
            // 
            // s3
            // 
            this.s3.Location = new System.Drawing.Point(370, 30);
            this.s3.Name = "s3";
            this.s3.Size = new System.Drawing.Size(55, 25);
            this.s3.TabIndex = 4;
            this.s3.Text = "Closing";
            // 
            // txtClosing
            // 
            this.txtClosing.Location = new System.Drawing.Point(425, 25);
            this.txtClosing.Name = "txtClosing";
            this.txtClosing.Size = new System.Drawing.Size(100, 20);
            this.txtClosing.TabIndex = 5;
            // 
            // dgvLedger
            // 
            this.dgvLedger.AllowUserToAddRows = false;
            this.dgvLedger.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLedger.Location = new System.Drawing.Point(10, 185);
            this.dgvLedger.Name = "dgvLedger";
            this.dgvLedger.ReadOnly = true;
            this.dgvLedger.RowHeadersVisible = false;
            this.dgvLedger.Size = new System.Drawing.Size(1160, 390);
            this.dgvLedger.TabIndex = 2;
            // 
            // frmStockLedger
            // 
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grpFilters);
            this.Controls.Add(this.dgvLedger);
            this.Controls.Add(this.grpSummary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStockLedger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Ledger";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpFilters.ResumeLayout(false);
            this.grpSummary.ResumeLayout(false);
            this.grpSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedger)).EndInit();
            this.ResumeLayout(false);

        }

        private Label f1;
        private Label f2;
        private Label f3;
        private Label f4;
        private Label f5;
        private Label f6;
        private Label s1;
        private Label s2;
        private Label s3;
    }
}