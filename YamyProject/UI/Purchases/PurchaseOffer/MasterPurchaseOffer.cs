using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class MasterPurchaseOffer : Form
    {
        private EventHandler vendorUpdatedHandler;
        private EventHandler invoiceUpdatedHandler;

        int _currentPage = 1;
        int _pageSize = 50; // Or any default rows per page
        int _totalRecords = 0;
        int _totalPages = 0;

        public MasterPurchaseOffer()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            vendorUpdatedHandler = (sender, args) => BindCombos.PopulateCustomers(cmbCustomer);
            invoiceUpdatedHandler = (sender, args) => BindInvoices();
            EventHub.Vendor += vendorUpdatedHandler;
            EventHub.PurchaseOffer += invoiceUpdatedHandler;
            headerUC1.FormText = this.Text;
        }
        private void MasterPurchaseOffer_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.Vendor -= vendorUpdatedHandler;
            EventHub.PurchaseOffer -= invoiceUpdatedHandler;

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmPurchaseOffer());
        }
        private void MasterPurchaseOffer_Load(object sender, EventArgs e)
        {
            AppTheme.DefaultFont(dgvCustomer);
            AppTheme.DefaultFont(dgvItems);
            BindCombos.PopulateVendors(cmbCustomer);
            BindInvoices();
        }
        public void BindInvoices()
        {
            DataTable dt;
            string query = "";
            if (cmbSelectionMethod.Text == "Default")
            {
                query = @"SELECT 
                        ROW_NUMBER() OVER (ORDER BY tbl_purchase_offer.date) AS `SN`, 
                        tbl_purchase_offer.date AS Date, 
                        tbl_purchase_offer.id,
                        tbl_purchase_offer.invoice_id AS 'INV NO', 
                        CONCAT(tbl_vendor.code,' - ', tbl_vendor.name) AS 'Vendor Name', tbl_purchase_offer.payment_method as 'Payment Method',
                        tbl_purchase_offer.total AS Total,tbl_purchase_offer.vat AS Vat,tbl_purchase_offer.net as 'Net',tbl_purchase_offer.purchase_id as 'P - No',tbl_purchase_offer.tranfer_status
                    FROM 
                        tbl_purchase_offer
                    INNER JOIN 
                        tbl_vendor ON tbl_purchase_offer.vendor_id = tbl_vendor.id
                    WHERE 
                        tbl_purchase_offer.state = 0

                    ";
            }
            else
            {
                query = @"SELECT 
                            ROW_NUMBER() OVER (ORDER BY tbl_purchase_offer.date) AS `SN`, 
                            tbl_purchase_offer.date AS Date, 
                            tbl_purchase_offer.id,
                            tbl_purchase_offer.invoice_id AS 'INV NO', 
                            CONCAT(tbl_vendor.code,' - ', tbl_vendor.name) AS 'Vendor Name', tbl_purchase_offer.payment_method as 'Payment Method',
                            tbl_purchase_offer.total AS Total,tbl_purchase_offer.vat AS Vat,tbl_purchase_offer.net as 'Net',tbl_purchase_offer.purchase_id as 'P - No',concat(ti.code,' - ',ti.name) as 'Item Name' ,ts.qty As Qty,ts.cost_price 
                            As 'Cost Price' , ts.Vat as 'Item Vat' ,ts.total as 'Item Total',tbl_purchase_offer.tranfer_status
                        FROM 
                            tbl_purchase_offer
                         INNER JOIN tbl_purchase_offer_details ts ON tbl_purchase_offer.id = ts.purchase_id
                        inner join tbl_items ti on ts.item_id =ti.id
                        INNER JOIN 
                            tbl_vendor ON tbl_purchase_offer.vendor_id = tbl_vendor.id
                        WHERE 
                            tbl_purchase_offer.state = 0

                        ";
            }
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (cmbCustomer.Text != "" && !chkCustomer.Checked)
            {
                query += " and tbl_purchase_offer.vendor_id = @id";
                parameters.Add(DBClass.CreateParameter("id", cmbCustomer.SelectedValue.ToString()));
            }
            if (cmbPaymentMethod.Text != "" && !chkPayment.Checked)
            {
                query += " and tbl_purchase_offer.payment_method = @payment";
                parameters.Add(DBClass.CreateParameter("payment", cmbPaymentMethod.Text));
            }
            if (!chkDate.Checked)
                query += " and tbl_purchase_offer.date >= @dateFrom and tbl_purchase_offer.date <= @dateTo";
            if (cmbSelectionMethod.Text == "Default")
                query += " GROUP BY tbl_purchase_offer.id, tbl_purchase_offer.date, tbl_purchase_offer.invoice_id, tbl_vendor.code, tbl_vendor.name, tbl_purchase_offer.total ";

            else
                query += " GROUP BY tbl_purchase_offer.id, tbl_purchase_offer.date, tbl_purchase_offer.invoice_id, tbl_vendor.code, tbl_vendor.name, tbl_purchase_offer.total,ti.code,ti.name,ts.qty,ts.cost_price,ts.vat,ts.total ";
            parameters.Add(DBClass.CreateParameter("dateFrom", dtFrom.Value.Date));
            parameters.Add(DBClass.CreateParameter("dateTo", dtTo.Value.Date));

            int offset = (_currentPage - 1) * _pageSize;
            query += $" LIMIT @_limit OFFSET @_offset";

            parameters.Add(DBClass.CreateParameter("_limit", _pageSize));
            parameters.Add(DBClass.CreateParameter("_offset", offset));
            string countQuery = "SELECT COUNT(*) FROM tbl_purchase_offer " +
                    "INNER JOIN tbl_vendor ON tbl_purchase_offer.vendor_id = tbl_vendor.id " +
                    "WHERE tbl_purchase_offer.state = 0";

            if (cmbCustomer.Text != "" && !chkCustomer.Checked)
            {
                countQuery += " AND tbl_purchase_offer.vendor_id = @id";
            }

            if (cmbPaymentMethod.Text != "" && !chkPayment.Checked)
            {
                countQuery += " AND tbl_purchase_offer.payment_method = @payment";
            }

            if (!chkDate.Checked)
                countQuery += " AND tbl_purchase_offer.date >= @dateFrom AND tbl_purchase_offer.date <= @dateTo";

            _totalRecords = Convert.ToInt32(DBClass.ExecuteScalar(countQuery, parameters.ToArray()));
            _totalPages = (_totalRecords + _pageSize - 1) / _pageSize;

            dt = DBClass.ExecuteDataTable(query, parameters.ToArray());
            if (dt != null)
            {
                dgvCustomer.DataSource = dt;
                dgvCustomer.Columns["Vendor Name"].MinimumWidth = 200;
                dgvCustomer.Columns["Vendor Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCustomer.Columns["id"].Visible = false;
                if (dgvCustomer.Rows.Count > 0 && cmbSelectionMethod.Text == "Default")
                    bindInvoiceItems();
                else
                    dgvItems.DataSource = null;

                if (dgvCustomer.Rows.Count > 0)
                {
                    btnEdit.Enabled = UserPermissions.canEdit("Purchase Offer");
                    btnDelete.Enabled = btnRecycle.Enabled = UserPermissions.canDelete("Purchase Offer");
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

                bool hasAttachment = AttachmentManager.HasAttachment(purchaseId, "PURCHASE OFFER");
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
                AttachmentManager.OpenAttachmentByType(purchaseId, "PURCHASE OFFER");
            }
        }

        private void bindInvoiceItems()
        {
            DataTable dt = DBClass.ExecuteDataTable(@"select concat(ti.code,' - ' ,ti.name) as 'Item Name' ,ts.qty as Qty ,ts.cost_price as 'Cost Price' , ts.vat as Vat , ts.total as Total from 
                                                     tbl_purchase_offer_details ts inner join tbl_items ti on ts.item_id = ti.id where purchase_id = @id",
                                                     DBClass.CreateParameter("id", dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()));
            dgvItems.DataSource = dt;
            dgvItems.Columns["item name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvItems);
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
            frmLogin.frmMain.openChildForm(new frmPurchaseOffer( int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            frmLogin.frmMain.openChildForm(new frmPurchaseOffer(int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())));
        }
        private void dgvCustomer_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void dgvCustomer_Leave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Rows.Count > 0 && cmbSelectionMethod.Text == "Default")
                bindInvoiceItems();
            else
                dgvItems.DataSource = null;
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;

            if (int.Parse(dgvCustomer.SelectedRows[0].Cells["tranfer_status"].Value.ToString()) <= 0)
            {
                //frmLogin.frmMain.openChildForm(new frmPurchase(int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString()), "POF"));
            }
            else
            {
                MessageBox.Show("PurchaseOffer already created.", "Cannot Create", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            DBClass.ExecuteNonQuery("UPDATE tbl_purchase_offer SET state = -1 WHERE id = @id ",
                                          DBClass.CreateParameter("id", dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()));
            Utilities.LogAudit(frmLogin.userId, "Delete Purchase Offer", "Purchase Offer", int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()), "Deleted Purchase Offer: " + dgvCustomer.SelectedRows[0].Cells["INV NO"].Value.ToString());

            _currentPage = 1;
            BindInvoices();
        }
        private void btnRecycle_Click(object sender, EventArgs e)
        {
            MasterRecycle restoreForm = new MasterRecycle("PurchaseOffer");
            restoreForm.DataRestored += RestoreForm_DataRestored;
            restoreForm.ShowDialog();
        }
        private void RestoreForm_DataRestored(object sender, EventArgs e)
        {
            _currentPage = 1;
            BindInvoices();
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
