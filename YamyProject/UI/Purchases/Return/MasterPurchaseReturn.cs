using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class MasterPurchaseReturn : Form
    {
        private EventHandler vendorUpdatedHandler;
        private EventHandler invoiceUpdatedHandler;

        int _currentPage = 1;
        int _pageSize = 50; // Or any default rows per page
        int _totalRecords = 0;
        int _totalPages = 0;

        public MasterPurchaseReturn()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            vendorUpdatedHandler = (sender, args) => BindCombos.PopulateCustomers(cmbCustomer);
            invoiceUpdatedHandler = (sender, args) => BindInvoices();
            EventHub.Vendor += vendorUpdatedHandler;
            EventHub.PurchaseReturn += invoiceUpdatedHandler;
            headerUC1.FormText = this.Text;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmPurchaseReturn(0));
        }
        private void MasterPurchaseReturn_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateVendors(cmbCustomer);
            BindInvoices();
        }
        public void BindInvoices()
        {
            DataTable dt;
            string query = @"SELECT 
                ROW_NUMBER() OVER (ORDER BY tbl_purchase_return.date) AS `SN`, 
                tbl_purchase_return.date AS Date, 
                tbl_purchase_return.id, 
                LPAD(tbl_purchase_return.id, 4, '0') AS 'JV NO', 
                tbl_purchase_return.invoice_id AS 'INV NO', 
                CONCAT(tbl_vendor.code,'-', tbl_vendor.name) AS 'Vendor Name', tbl_purchase_return.payment_method as 'Payment Method',
                tbl_purchase_return.total AS Total,tbl_purchase_return.vat AS Vat,tbl_purchase_return.Net as 'Net'
            FROM 
                tbl_purchase_return
            INNER JOIN 
                tbl_vendor ON tbl_purchase_return.vendor_id = tbl_vendor.id
            WHERE 
                tbl_purchase_return.state = 0

            ";
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (cmbCustomer.Text != "" && !chkCustomer.Checked)
            {
                query += " and tbl_purchase_return.vendor_id = @id";
                parameters.Add(DBClass.CreateParameter("id", cmbCustomer.SelectedValue.ToString()));
            }
            if (cmbPaymentMethod.Text != "" && !chkPayment.Checked)
            {
                query += " and tbl_purchase_return.payment_method = @payment";
                parameters.Add(DBClass.CreateParameter("payment", cmbPaymentMethod.Text));
            }
            if (!chkDate.Checked)
                query += " and tbl_purchase_return.date >= @dateFrom and tbl_purchase_return.date <= @dateTo";
            query+= " GROUP BY tbl_purchase_return.id, tbl_purchase_return.date, tbl_purchase_return.invoice_id, tbl_vendor.code, tbl_vendor.name, tbl_purchase_return.total ";
            parameters.Add(DBClass.CreateParameter("dateFrom", dtFrom.Value.Date));
            parameters.Add(DBClass.CreateParameter("dateTo", dtTo.Value.Date));

            int offset = (_currentPage - 1) * _pageSize;
            query += $" LIMIT @_limit OFFSET @_offset";

            parameters.Add(DBClass.CreateParameter("_limit", _pageSize));
            parameters.Add(DBClass.CreateParameter("_offset", offset));

            string countQuery = "SELECT COUNT(*) FROM tbl_purchase_return " +
                    "INNER JOIN tbl_vendor ON tbl_purchase_return.vendor_id = tbl_vendor.id " +
                    "WHERE tbl_purchase_return.state = 0";

            if (cmbCustomer.Text != "" && !chkCustomer.Checked)
            {
                countQuery += " AND tbl_purchase_return.vendor_id = @id";
                // Add param if not already
            }

            if (cmbPaymentMethod.Text != "" && !chkPayment.Checked)
            {
                countQuery += " AND tbl_purchase_return.payment_method = @payment";
            }

            if (!chkDate.Checked)
                countQuery += " AND tbl_purchase_return.date >= @dateFrom AND tbl_purchase_return.date <= @dateTo";

            _totalRecords = Convert.ToInt32(DBClass.ExecuteScalar(countQuery, parameters.ToArray()));
            _totalPages = (_totalRecords + _pageSize - 1) / _pageSize;

            dt = DBClass.ExecuteDataTable(query, parameters.ToArray());
            if (dt != null)
            {
                dgvCustomer.DataSource = dt;
                dgvCustomer.Columns["Vendor Name"].MinimumWidth = 200;
                dgvCustomer.Columns["Vendor Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCustomer.Columns["id"].Visible = false;
                if (dgvCustomer.Rows.Count > 0)
                {
                    btnEdit.Enabled = UserPermissions.canEdit("Purchase Return");
                    btnDelete.Enabled = btnRestore.Enabled = UserPermissions.canDelete("Purchase Return");
                }
                LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
                AddViewDocImageColumn();
            }
            lblPageInfo.Text = $"Page {_currentPage} of {_totalPages}";
            btnPrev.Enabled = btnFirst.Enabled = _currentPage > 1;
            btnNext.Enabled = btnLast.Enabled = _currentPage < _totalPages;
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvCustomer.Columns.Contains("ViewDoc"))
            {
                SetViewDocIcons();
            }
        }
        System.Drawing.Image enabledIcon = Properties.Resources.doc_icon;   // regular icon
        System.Drawing.Image disabledIcon = null; // or Properties.Resources.doc_icon_disabled

        private void SetViewDocIcons()
        {
            foreach (DataGridViewRow row in dgvCustomer.Rows)
            {
                int purchaseId = Convert.ToInt32(row.Cells["id"].Value);

                bool hasAttachment = AttachmentManager.HasAttachment(purchaseId, "PURCHASE RETURN");
                // You need a function to check if an invoice has attachments
                row.Cells["ViewDoc"].Value = hasAttachment ? enabledIcon : disabledIcon;
            }
        }

        private void AddViewDocImageColumn()
        {
            if (!dgvCustomer.Columns.Contains("ViewDoc"))
            {
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                imgColumn.Name = "ViewDoc";
                imgColumn.HeaderText = "View Doc";
                //imgColumn.Image = Properties.Resources.doc_icon; // <-- your image here
                imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // fit nicely
                dgvCustomer.Columns.Add(imgColumn);
            }
        }
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCustomer.Columns[e.ColumnIndex].Name == "ViewDoc")
            {
                var cell = dgvCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value == null) return; // no attachment, do nothing

                int purchaseId = Convert.ToInt32(dgvCustomer.Rows[e.RowIndex].Cells["id"].Value);
                AttachmentManager.OpenAttachmentByType(purchaseId, "PURCHASE RETURN");
            }
        }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentPage = 1;
            BindInvoices();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            frmLogin.frmMain.openChildForm(new frmPurchaseReturn(int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            if (dgvCustomer.Columns["JV NO"].Index == e.ColumnIndex)
                frmLogin.frmMain.openChildForm(new MasterTransactionJournal(dgvCustomer.CurrentRow.Cells["JV NO"].Value.ToString(), "PurchaseReturn"));
            else
                frmLogin.frmMain.openChildForm(new frmPurchaseReturn(int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())));
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
            if (dgvCustomer.Rows.Count == 0)
                return;
            DBClass.ExecuteNonQuery("UPDATE tbl_purchase_return SET state = -1 WHERE id = @id ",
                                          DBClass.CreateParameter("id", dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()));
            CommonInsert.DeleteItemTransaction("Purchase Return", dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString());
            Utilities.LogAudit(frmLogin.userId, "Delete Purchase Return", "Purchase Return", int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()), "Deleted Purchase Return: " + dgvCustomer.SelectedRows[0].Cells["INV NO"].Value.ToString());

            _currentPage = 1;
            BindInvoices();
        }
        private void btnRestore_Click(object sender, EventArgs e)
        {
            MasterRecycle restoreForm = new MasterRecycle("PurchaseReturn");
            restoreForm.DataRestored += RestoreForm_DataRestored;
            restoreForm.ShowDialog();

        }
        private void RestoreForm_DataRestored(object sender, EventArgs e)
        {
            _currentPage = 1;
            BindInvoices();
        }
        private void chkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustomer.Checked)
                cmbCustomer.Enabled = false;
            else
                cmbCustomer.Enabled = true;

            _currentPage = 1;
            BindInvoices();
        }
        private void chkPayment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPayment.Checked)
                cmbPaymentMethod.Enabled = false;
            else
                cmbPaymentMethod.Enabled = true;

            _currentPage = 1;
            BindInvoices();
        }
        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
                dtFrom.Enabled = dtTo.Enabled = false;
            else
                dtFrom.Enabled = dtTo.Enabled = true;

            _currentPage = 1;
            BindInvoices();
        }

        private void MasterPurchaseReturn_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.Vendor -= vendorUpdatedHandler;
            EventHub.PurchaseInv -= invoiceUpdatedHandler;
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            BindInvoices();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            BindInvoices();
        }
    }
}
