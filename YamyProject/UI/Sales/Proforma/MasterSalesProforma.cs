using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class MasterSalesProforma : Form
    {
        private EventHandler customerUpdatedHandler;
        private EventHandler invoiceUpdatedHandler;

        public MasterSalesProforma()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            customerUpdatedHandler = (sender, args) => BindCombos.PopulateCustomers(cmbCustomer);
            invoiceUpdatedHandler = (sender, args) => BindInvoices();
            EventHub.Customer += customerUpdatedHandler;
            EventHub.SalesProforma += invoiceUpdatedHandler;
            headerUC1.FormText = this.Text;
        }
        private void MasterSalesProforma_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.Customer -= customerUpdatedHandler;
            EventHub.SalesProforma -= invoiceUpdatedHandler;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmSaleProforma(0));
        }
        private void MasterSalesProforma_Load(object sender, EventArgs e)
        {
            AppTheme.DefaultFont(dgvItems);
            AppTheme.DefaultFont(dgvInvoice);
            BindCombos.PopulateCustomers(cmbCustomer);
            BindInvoices();
        }
       
        public void BindInvoices()
        {
            string query = GetQuery();
            List<MySqlParameter> parameters = GetQueryParameters();

            DataTable dt = DBClass.ExecuteDataTable(query, parameters.ToArray());
            if (dt != null)
            {
                BindDataToGrid(dt);
                HandleInvoiceItems();
                AddViewDocImageColumn();
            }
        }
        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvInvoice.Columns.Contains("ViewDoc"))
            {
                SetViewDocIcons();
            }
        }
        System.Drawing.Image enabledIcon = Properties.Resources.doc_icon;   // regular icon
        System.Drawing.Image disabledIcon = null; // or Properties.Resources.doc_icon_disabled

        private void SetViewDocIcons()
        {
            foreach (DataGridViewRow row in dgvInvoice.Rows)
            {
                int purchaseId = Convert.ToInt32(row.Cells["id"].Value);

                bool hasAttachment = AttachmentManager.HasAttachment(purchaseId, "SALES PROFORMA");
                // You need a function to check if an invoice has attachments
                row.Cells["ViewDoc"].Value = hasAttachment ? enabledIcon : disabledIcon;
            }
        }

        private void AddViewDocImageColumn()
        {
            if (!dgvInvoice.Columns.Contains("ViewDoc"))
            {
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                imgColumn.Name = "ViewDoc";
                imgColumn.HeaderText = "View Doc";
                //imgColumn.Image = Properties.Resources.doc_icon; // <-- your image here
                imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // fit nicely
                dgvInvoice.Columns.Add(imgColumn);
            }
        }
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvInvoice.Columns[e.ColumnIndex].Name == "ViewDoc")
            {
                var cell = dgvInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value == null) return; // no attachment, do nothing

                int purchaseId = Convert.ToInt32(dgvInvoice.Rows[e.RowIndex].Cells["id"].Value);
                AttachmentManager.OpenAttachmentByType(purchaseId, "SALES PROFORMA");
            }
        }
        private string GetQuery()
        {
            string query = cmbSelectionMethod.Text == "Default" ? GetDefaultQuery() : GetDetailedQuery();
            string whereClause = GetWhereClause();
            string finalWhere = "WHERE tbl_sales_proforma.state = 0";
            if (!string.IsNullOrWhiteSpace(whereClause))
                finalWhere += " AND " + whereClause;

            // GROUP BY section differs by query type
            string groupBy = cmbSelectionMethod.Text != "Default"
                ? @"GROUP BY tbl_sales_proforma.id, tbl_sales_proforma.date, tbl_sales_proforma.invoice_id, 
                     tbl_customer.code, tbl_customer.name, tbl_sales_proforma.total, 
                     ti.code, ti.name, ts.qty, ts.price, ts.vat, ts.total"
                : @"GROUP BY tbl_sales_proforma.id, tbl_sales_proforma.date, tbl_sales_proforma.invoice_id, 
                     tbl_customer.code, tbl_customer.name, tbl_sales_proforma.total";

            // Return full combined query
            return $"{query} {finalWhere} {groupBy};";
        }
        private string GetWhereClause()
        {
            List<string> filters = new List<string>();

            if (!string.IsNullOrWhiteSpace(cmbCustomer.Text) && !chkCustomer.Checked)
                filters.Add("tbl_sales_proforma.customer_id = @id");

            if (!string.IsNullOrWhiteSpace(cmbPaymentMethod.Text) && !chkPayment.Checked)
                filters.Add("tbl_sales_proforma.payment_method = @payment");

            if (!chkDate.Checked)
                filters.Add("tbl_sales_proforma.date >= @dateFrom AND tbl_sales_proforma.date <= @dateTo");

            return string.Join(" AND ", filters);
        }
        private string GetDefaultQuery()
        {
            return @"SELECT 
                ROW_NUMBER() OVER (ORDER BY tbl_sales_proforma.date) AS SN, 
                tbl_sales_proforma.date AS Date, 
                tbl_sales_proforma.id,
                tbl_sales_proforma.invoice_id AS 'INV NO', 
                CONCAT(tbl_customer.code, ' - ', tbl_customer.name) AS 'Customer Name', 
                tbl_sales_proforma.payment_method AS 'Payment Method',
                tbl_sales_proforma.total AS Total,
                tbl_sales_proforma.vat AS Vat,
                tbl_sales_proforma.net AS Net,
                tbl_sales_proforma.sales_id AS SalesId,
                tbl_sales_proforma.tranfer_status
            FROM tbl_sales_proforma
            INNER JOIN tbl_customer ON tbl_sales_proforma.customer_id = tbl_customer.id";
        }

        private string GetDetailedQuery()
        {
            return @"SELECT 
                ROW_NUMBER() OVER (ORDER BY tbl_sales_proforma.date) AS SN, 
                tbl_sales_proforma.date AS Date, 
                tbl_sales_proforma.id,
                tbl_sales_proforma.invoice_id AS 'INV NO', 
                CONCAT(tbl_customer.code, ' - ', tbl_customer.name) AS 'Customer Name', 
                tbl_sales_proforma.payment_method AS 'Payment Method',
                tbl_sales_proforma.total AS Total,
                tbl_sales_proforma.vat AS Vat,
                tbl_sales_proforma.net AS Net,
                tbl_sales_proforma.sales_id AS SalesId,
                tbl_sales_proforma.tranfer_status,
                CONCAT(ti.code, ' - ', ti.name) AS 'Item Name',
                ts.qty AS Qty,
                ts.price AS Price,
                ts.vat AS 'Item Vat',
                ts.total AS 'Item Total'
            FROM tbl_sales_proforma
            INNER JOIN tbl_sales_proforma_details ts ON tbl_sales_proforma.id = ts.sales_id
            INNER JOIN tbl_items ti ON ts.item_id = ti.id
            INNER JOIN tbl_customer ON tbl_sales_proforma.customer_id = tbl_customer.id";
        }

        private List<MySqlParameter> GetQueryParameters()
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>
    {
        DBClass.CreateParameter("dateFrom", dtFrom.Value.Date),
        DBClass.CreateParameter("dateTo", dtTo.Value.Date)
    };

            AddCustomerAndPaymentFilters(parameters);
            return parameters;
        }

        private void AddCustomerAndPaymentFilters(List<MySqlParameter> parameters)
        {
            if (cmbCustomer.Text != "" && !chkCustomer.Checked)
            {
                parameters.Add(DBClass.CreateParameter("id", cmbCustomer.SelectedValue.ToString()));
            }
            if (cmbPaymentMethod.Text != "" && !chkPayment.Checked)
            {
                parameters.Add(DBClass.CreateParameter("payment", cmbPaymentMethod.Text));
            }
        }

        private void BindDataToGrid(DataTable dt)
        {
            dgvInvoice.DataSource = dt;
            dgvInvoice.Columns["Customer Name"].MinimumWidth = 200;
            dgvInvoice.Columns["Customer Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvInvoice.Columns["id"].Visible = dgvInvoice.Columns["tranfer_status"].Visible = false;
            if (dgvInvoice.Rows.Count > 0)
            {
                btnEdit.Enabled = UserPermissions.canEdit("Sales Proforma");
                btnDelete.Enabled = btnRecycle.Enabled = UserPermissions.canDelete("Sales Proforma");
            }

            LocalizationManager.LocalizeDataGridViewHeaders(dgvInvoice);
        }

        private void HandleInvoiceItems()
        {
            if (dgvInvoice.Rows.Count > 0 && cmbSelectionMethod.Text == "Default")
            {
                bindInvoiceItems();
            }
            else
            {
                dgvItems.DataSource = null;
            }
        }
        private void bindInvoiceItems()
        {
            DataTable dt = DBClass.ExecuteDataTable(@"select concat(ti.code,' - ' ,ti.name) as 'Item Name' ,ts.qty as Qty ,ts.price as Price , ts.vat as Vat , ts.total as Total from 
                                                     tbl_sales_proforma_details ts inner join tbl_items ti on ts.item_id = ti.id where sales_id = @id",
                                                     DBClass.CreateParameter("id", dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString()));
            dgvItems.DataSource = dt;
            dgvItems.Columns["item name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvItems);
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindInvoices();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.Rows.Count == 0)
                return;
            frmLogin.frmMain.openChildForm(new frmSaleProforma(int.Parse(dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString())));
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInvoice.Rows.Count == 0)
                return;
            frmLogin.frmMain.openChildForm(new frmSaleProforma(int.Parse(dgvInvoice.CurrentRow.Cells["id"].Value.ToString())));
        }
        private void dgvCustomer_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void dgvCustomer_Leave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.Rows.Count == 0)
                return;

            DBClass.ExecuteNonQuery("UPDATE tbl_sales_proforma SET state = -1 WHERE id = @id ",
                                          DBClass.CreateParameter("id", dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString()));

            Utilities.LogAudit(frmLogin.userId, "Delete Sales Proforma", "Sales Proforma", int.Parse(dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString()), "Deleted Sales Proforma: " + dgvInvoice.SelectedRows[0].Cells["INV NO"].Value.ToString());
            BindInvoices();
        }

        private void chkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustomer.Checked)
                cmbCustomer.Enabled = false;
            else
                cmbCustomer.Enabled = true;
            BindInvoices();
        }
        private void chkPayment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPayment.Checked)
                cmbPaymentMethod.Enabled = false;
            else
                cmbPaymentMethod.Enabled = true;
            BindInvoices();
        }
        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = chkDate.Checked;
            dtFrom.Enabled = dtTo.Enabled = !isChecked;
            BindInvoices();
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInvoice.Rows.Count > 0 && cmbSelectionMethod.Text == "Default")
                bindInvoiceItems();
            else
                dgvItems.DataSource = null;
        }

        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.Rows.Count == 0)
                return;
            if (int.Parse(dgvInvoice.SelectedRows[0].Cells["tranfer_status"].Value.ToString()) <= 0)
            {
                frmLogin.frmMain.openChildForm(new frmAddQuotation(int.Parse(dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString()), "Proforma"));
            }
            else
            {
                MessageBox.Show("SalesProforma already created.", "Cannot Create", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRecycle_Click(object sender, EventArgs e)
        {
            MasterRecycle restoreForm = new MasterRecycle("SalesProforma");
            restoreForm.DataRestored += RestoreForm_DataRestored;
            restoreForm.ShowDialog();

        }
        private void RestoreForm_DataRestored(object sender, EventArgs e)
        {
            BindInvoices();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            BindInvoices();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            BindInvoices();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.Rows.Count == 0)
                return;
            if (int.Parse(dgvInvoice.SelectedRows[0].Cells["tranfer_status"].Value.ToString()) <= 0)
            {
                frmLogin.frmMain.openChildForm(new frmSales(int.Parse(dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString()), "SP", int.Parse(cmbCustomer.SelectedValue.ToString())));
            }
            else
            {
                MessageBox.Show("SalesProforma already created.", "Cannot Create", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
