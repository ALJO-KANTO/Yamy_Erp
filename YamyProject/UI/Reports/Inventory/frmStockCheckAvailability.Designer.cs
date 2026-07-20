using System.Windows.Forms;

namespace YamyProject.UI.Reports.Inventory
{
    partial class frmStockCheckAvailability
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

        private GroupBox grpFilter;
        private ComboBox cmbItem;
        private ComboBox cmbWarehouse;
        private Button btnSearch;

        private Label lblItem;
        private Label lblWarehouse;

        private DataGridView dgvStock;

        private TextBox txtTotalIn;
        private TextBox txtTotalOut;
        private TextBox txtBalance;

        private Label lblIn;
        private Label lblOut;
        private Label lblBalance;

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.txtTotalIn = new System.Windows.Forms.TextBox();
            this.txtTotalOut = new System.Windows.Forms.TextBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.lblIn = new System.Windows.Forms.Label();
            this.lblOut = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
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
            this.lblTitle.Size = new System.Drawing.Size(278, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "STOCK CHECK / AVAILABILITY";
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.lblItem);
            this.grpFilter.Controls.Add(this.cmbItem);
            this.grpFilter.Controls.Add(this.lblWarehouse);
            this.grpFilter.Controls.Add(this.cmbWarehouse);
            this.grpFilter.Controls.Add(this.btnSearch);
            this.grpFilter.Location = new System.Drawing.Point(10, 65);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(1160, 80);
            this.grpFilter.TabIndex = 1;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // lblItem
            // 
            this.lblItem.Location = new System.Drawing.Point(15, 30);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(40, 25);
            this.lblItem.TabIndex = 0;
            this.lblItem.Text = "Item";
            // 
            // cmbItem
            // 
            this.cmbItem.Location = new System.Drawing.Point(60, 25);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(300, 21);
            this.cmbItem.TabIndex = 1;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.Location = new System.Drawing.Point(380, 30);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(80, 25);
            this.lblWarehouse.TabIndex = 2;
            this.lblWarehouse.Text = "Warehouse";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.Location = new System.Drawing.Point(470, 25);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(200, 21);
            this.cmbWarehouse.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(700, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 30);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStock.Location = new System.Drawing.Point(10, 155);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.RowHeadersVisible = false;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(1160, 350);
            this.dgvStock.TabIndex = 2;
            // 
            // txtTotalIn
            // 
            this.txtTotalIn.Location = new System.Drawing.Point(90, 515);
            this.txtTotalIn.Name = "txtTotalIn";
            this.txtTotalIn.ReadOnly = true;
            this.txtTotalIn.Size = new System.Drawing.Size(120, 20);
            this.txtTotalIn.TabIndex = 4;
            // 
            // txtTotalOut
            // 
            this.txtTotalOut.Location = new System.Drawing.Point(310, 515);
            this.txtTotalOut.Name = "txtTotalOut";
            this.txtTotalOut.ReadOnly = true;
            this.txtTotalOut.Size = new System.Drawing.Size(120, 20);
            this.txtTotalOut.TabIndex = 6;
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(530, 515);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(120, 20);
            this.txtBalance.TabIndex = 8;
            // 
            // lblIn
            // 
            this.lblIn.Location = new System.Drawing.Point(10, 520);
            this.lblIn.Name = "lblIn";
            this.lblIn.Size = new System.Drawing.Size(80, 25);
            this.lblIn.TabIndex = 3;
            this.lblIn.Text = "Total In";
            // 
            // lblOut
            // 
            this.lblOut.Location = new System.Drawing.Point(230, 520);
            this.lblOut.Name = "lblOut";
            this.lblOut.Size = new System.Drawing.Size(80, 25);
            this.lblOut.TabIndex = 5;
            this.lblOut.Text = "Total Out";
            // 
            // lblBalance
            // 
            this.lblBalance.Location = new System.Drawing.Point(450, 520);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(80, 25);
            this.lblBalance.TabIndex = 7;
            this.lblBalance.Text = "Balance";
            // 
            // frmStockCheckAvailability
            // 
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.lblIn);
            this.Controls.Add(this.txtTotalIn);
            this.Controls.Add(this.lblOut);
            this.Controls.Add(this.txtTotalOut);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.txtBalance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStockCheckAvailability";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Check";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}