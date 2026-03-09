using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class MasterMaterialRequest : Form
    {
        private EventHandler vendorUpdatedHandler;
        private EventHandler invoiceUpdatedHandler;

        int _currentPage = 1;
        int _pageSize = 50; // Or any default rows per page
        int _totalRecords = 0;
        int _totalPages = 0;

        public MasterMaterialRequest()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            vendorUpdatedHandler = (sender, args) => BindCombos.PopulateEmployees(cmbCustomer);
            invoiceUpdatedHandler = (sender, args) => BindInvoices();
            EventHub.Vendor += vendorUpdatedHandler;
            EventHub.MaterialRequest += invoiceUpdatedHandler;
            headerUC1.FormText = this.Text;
        }
        private void MasterMaterialRequest_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.Vendor -= vendorUpdatedHandler;
            EventHub.MaterialRequest -= invoiceUpdatedHandler;

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmMaterialRequest());
        }
        private void MasterMaterialRequest_Load(object sender, EventArgs e)
        {
            AppTheme.DefaultFont(dgvCustomer);
            AppTheme.DefaultFont(dgvItems);
            BindCombos.PopulateVendors(cmbCustomer);
            BindInvoices();
        }
        public void BindInvoices()
        {
            string query = "";
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (cmbSelectionMethod.Text == "Default")
            {
                query = @"
                        SELECT 
                            ROW_NUMBER() OVER (ORDER BY mr.request_date DESC) AS `SN`,
                            mr.mr_id,
                            mr.request_date AS Date,
                            mr.mr_no AS 'MR NO',
                            u.name AS 'Requested By',
                            d.name AS 'Department',
                            mr.status,
                            mr.remarks
                        FROM tbl_material_request mr
                        LEFT JOIN tbl_employee u 
                            ON mr.requested_by = u.id
                        LEFT JOIN tbl_departments d 
                            ON mr.department_id = d.id
                        WHERE mr.mr_id > 0
                    ";
            }
            else
            {
                query = @"
                        SELECT 
                            ROW_NUMBER() OVER (ORDER BY mr.request_date DESC) AS `SN`,
                            mr.mr_id,
                            mr.request_date AS Date,
                            mr.mr_no AS 'MR NO',
                            u.name AS 'Requested By',
                            d.name AS 'Department',
                            CONCAT(i.code,' - ',i.name) AS 'Item Name',
                            mri.required_qty AS Qty,
                            mri.uom,
                            mri.expected_date AS 'Expected Date',
                            mri.status AS 'Item Status'
                        FROM tbl_material_request mr
                        INNER JOIN tbl_material_request_item mri 
                            ON mr.mr_id = mri.mr_id
                        INNER JOIN tbl_items i 
                            ON mri.item_id = i.id
                        LEFT JOIN tbl_employee u 
                            ON mr.requested_by = u.id
                        LEFT JOIN tbl_departments d 
                            ON mr.department_id = d.id
                        WHERE mr.mr_id > 0
                    ";
            }


            if (!chkDate.Checked)
            {
                query += " AND mr.request_date >= @dateFrom AND mr.request_date <= @dateTo";

                parameters.Add(DBClass.CreateParameter("@dateFrom", dtFrom.Value.Date));
                parameters.Add(DBClass.CreateParameter("@dateTo", dtTo.Value.Date));
            }
            if (cmbCustomer.SelectedValue != null && !chkCustomer.Checked)
            {
                query += " AND mr.requested_by = @requestedBy";
                parameters.Add(DBClass.CreateParameter("@requestedBy", cmbCustomer.SelectedValue));
            }

            int offset = (_currentPage - 1) * _pageSize;

            query += " LIMIT @_limit OFFSET @_offset";

            parameters.Add(DBClass.CreateParameter("@_limit", _pageSize));
            parameters.Add(DBClass.CreateParameter("@_offset", offset));


            DataTable dt = DBClass.ExecuteDataTable(query, parameters.ToArray());


            string countQuery = @"
                                SELECT COUNT(*) 
                                FROM tbl_material_request mr
                                WHERE mr.mr_id > 0
                            ";

            List<MySqlParameter> countParams = new List<MySqlParameter>();

            if (!chkDate.Checked)
            {
                countQuery += " AND mr.request_date >= @dateFrom AND mr.request_date <= @dateTo";

                countParams.Add(DBClass.CreateParameter("@dateFrom", dtFrom.Value.Date));
                countParams.Add(DBClass.CreateParameter("@dateTo", dtTo.Value.Date));
            }

            _totalRecords = Convert.ToInt32(DBClass.ExecuteScalar(countQuery, countParams.ToArray()));
            _totalPages = (_totalRecords + _pageSize - 1) / _pageSize;


            if (dt != null)
            {
                dgvCustomer.DataSource = dt;

                // Hide MR ID column
                if (dgvCustomer.Columns.Contains("mr_id"))
                    dgvCustomer.Columns["mr_id"].Visible = false;

                // Auto-size MR No column if exists
                if (dgvCustomer.Columns.Contains("MR NO"))
                    dgvCustomer.Columns["MR NO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Load items if header mode
                if (dgvCustomer.Rows.Count > 0 && cmbSelectionMethod.Text == "Default")
                    bindInvoiceItems();
                else
                    dgvItems.DataSource = null;

                if (dgvCustomer.Rows.Count > 0)
                {
                    btnEdit.Enabled = UserPermissions.canEdit("Material Request");
                    btnDelete.Enabled = btnRecycle.Enabled = UserPermissions.canDelete("Material Request");
                }

                LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
                AddViewDocImageColumn();
            }

            lblPageInfo.Text = $"Page {_currentPage} of {_totalPages}";
            btnPrev.Enabled = btnFirst.Enabled = _currentPage > 1;
            btnNext.Enabled = btnLast.Enabled = _currentPage < _totalPages;
        }

        public void BindInvoicesOld()
        {
            DataTable dt;
            string query = "";
            if (cmbSelectionMethod.Text == "Default")
            {
                query = @"SELECT 
                        ROW_NUMBER() OVER (ORDER BY tbl_material_request.date) AS `SN`, 
                        tbl_material_request.date AS Date, 
                        tbl_material_request.id,
                        tbl_material_request.invoice_id AS 'INV NO', 
                        CONCAT(tbl_vendor.code,' - ', tbl_vendor.name) AS 'Vendor Name', tbl_material_request.payment_method as 'Payment Method',
                        tbl_material_request.total AS Total,tbl_material_request.vat AS Vat,tbl_material_request.net as 'Net',tbl_material_request.purchase_id as 'P - No',tbl_material_request.tranfer_status
                    FROM 
                        tbl_material_request
                    INNER JOIN 
                        tbl_vendor ON tbl_material_request.vendor_id = tbl_vendor.id
                    WHERE 
                        tbl_material_request.state = 0

                    ";
            }
            else
            {
                query = @"SELECT 
                            ROW_NUMBER() OVER (ORDER BY tbl_material_request.date) AS `SN`, 
                            tbl_material_request.date AS Date, 
                            tbl_material_request.id,
                            tbl_material_request.invoice_id AS 'INV NO', 
                            CONCAT(tbl_vendor.code,' - ', tbl_vendor.name) AS 'Vendor Name', tbl_material_request.payment_method as 'Payment Method',
                            tbl_material_request.total AS Total,tbl_material_request.vat AS Vat,tbl_material_request.net as 'Net',tbl_material_request.purchase_id as 'P - No',concat(ti.code,' - ',ti.name) as 'Item Name' ,ts.qty As Qty,ts.cost_price 
                            As 'Cost Price' , ts.Vat as 'Item Vat' ,ts.total as 'Item Total',tbl_material_request.tranfer_status
                        FROM 
                            tbl_material_request
                         INNER JOIN tbl_material_request_details ts ON tbl_material_request.id = ts.purchase_id
                        inner join tbl_items ti on ts.item_id =ti.id
                        INNER JOIN 
                            tbl_vendor ON tbl_material_request.vendor_id = tbl_vendor.id
                        WHERE 
                            tbl_material_request.state = 0

                        ";
            }
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (cmbCustomer.Text != "" && !chkCustomer.Checked)
            {
                query += " and tbl_material_request.requested_by = @id";
                parameters.Add(DBClass.CreateParameter("mr_id", cmbCustomer.SelectedValue.ToString()));
            }
            if (cmbPaymentMethod.Text != "" && !chkPayment.Checked)
            {
                query += " and tbl_material_request.payment_method = @payment";
                parameters.Add(DBClass.CreateParameter("payment", cmbPaymentMethod.Text));
            }
            if (!chkDate.Checked)
                query += " and tbl_material_request.date >= @dateFrom and tbl_material_request.date <= @dateTo";
            if (cmbSelectionMethod.Text == "Default")
                query += " GROUP BY tbl_material_request.id, tbl_material_request.date, tbl_material_request.invoice_id, tbl_vendor.code, tbl_vendor.name, tbl_material_request.total ";

            else
                query += " GROUP BY tbl_material_request.id, tbl_material_request.date, tbl_material_request.invoice_id, tbl_vendor.code, tbl_vendor.name, tbl_material_request.total,ti.code,ti.name,ts.qty,ts.cost_price,ts.vat,ts.total ";
            parameters.Add(DBClass.CreateParameter("dateFrom", dtFrom.Value.Date));
            parameters.Add(DBClass.CreateParameter("dateTo", dtTo.Value.Date));

            int offset = (_currentPage - 1) * _pageSize;
            query += $" LIMIT @_limit OFFSET @_offset";

            parameters.Add(DBClass.CreateParameter("_limit", _pageSize));
            parameters.Add(DBClass.CreateParameter("_offset", offset));
            string countQuery = "SELECT COUNT(*) FROM tbl_material_request " +
                    "INNER JOIN tbl_vendor ON tbl_material_request.vendor_id = tbl_vendor.id " +
                    "WHERE tbl_material_request.state = 0";

            if (cmbCustomer.Text != "" && !chkCustomer.Checked)
            {
                countQuery += " AND tbl_material_request.vendor_id = @id";
            }

            if (cmbPaymentMethod.Text != "" && !chkPayment.Checked)
            {
                countQuery += " AND tbl_material_request.payment_method = @payment";
            }

            if (!chkDate.Checked)
                countQuery += " AND tbl_material_request.date >= @dateFrom AND tbl_material_request.date <= @dateTo";

            _totalRecords = Convert.ToInt32(DBClass.ExecuteScalar(countQuery, parameters.ToArray()));
            _totalPages = (_totalRecords + _pageSize - 1) / _pageSize;

            dt = DBClass.ExecuteDataTable(query, parameters.ToArray());
            if (dt != null)
            {
                dgvCustomer.DataSource = dt;
                dgvCustomer.Columns["Vendor Name"].MinimumWidth = 200;
                dgvCustomer.Columns["Vendor Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCustomer.Columns["mr_id"].Visible = false;
                if (dgvCustomer.Rows.Count > 0 && cmbSelectionMethod.Text == "Default")
                    bindInvoiceItems();
                else
                    dgvItems.DataSource = null;

                if (dgvCustomer.Rows.Count > 0)
                {
                    btnEdit.Enabled = UserPermissions.canEdit("Material Request");
                    btnDelete.Enabled = btnRecycle.Enabled = UserPermissions.canDelete("Material Request");
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
                int purchaseId = Convert.ToInt32(row.Cells["mr_id"].Value);

                bool hasAttachment = AttachmentManager.HasAttachment(purchaseId, "MATERIAL REQUEST");
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

                int purchaseId = Convert.ToInt32(dgvCustomer.Rows[e.RowIndex].Cells["mr_id"].Value);
                AttachmentManager.OpenAttachmentByType(purchaseId, "MATERIAL REQUEST");
            }
        }

        private void bindInvoiceItems()
        {
            DataTable dt = DBClass.ExecuteDataTable(@"SELECT 
                                concat(i.code,' - ' ,i.name) as 'Item Name',
										  mri.required_qty Qty,
                                mri.uom UOM,
                                mri.expected_date 'Expected Date',
                                mri.Status,
                                mri.Remarks
									 FROM tbl_material_request_item mri
                            INNER JOIN tbl_items i ON mri.item_id = i.id
                            WHERE mri.mr_id = @id",
                                                     DBClass.CreateParameter("@id", dgvCustomer.SelectedRows[0].Cells["mr_id"].Value.ToString()));
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
            frmLogin.frmMain.openChildForm(new frmMaterialRequest( int.Parse(dgvCustomer.SelectedRows[0].Cells["mr_id"].Value.ToString())));
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            frmLogin.frmMain.openChildForm(new frmMaterialRequest(int.Parse(dgvCustomer.CurrentRow.Cells["mr_id"].Value.ToString())));
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
                frmLogin.frmMain.openChildForm(new frmPurchaseOrder(int.Parse(dgvCustomer.CurrentRow.Cells["mr_id"].Value.ToString()), "MR"));
            }
            else
            {
                MessageBox.Show("Material Request already created.", "Cannot Create", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            DBClass.ExecuteNonQuery("UPDATE tbl_material_request SET state = -1 WHERE id = @id ",
                                          DBClass.CreateParameter("mr_id", dgvCustomer.SelectedRows[0].Cells["mr_id"].Value.ToString()));
            Utilities.LogAudit(frmLogin.userId, "Delete Material Request", "Material Request", int.Parse(dgvCustomer.SelectedRows[0].Cells["mr_id"].Value.ToString()), "Deleted Material Request: " + dgvCustomer.SelectedRows[0].Cells["INV NO"].Value.ToString());

            _currentPage = 1;
            BindInvoices();
        }
        private void btnRecycle_Click(object sender, EventArgs e)
        {
            MasterRecycle restoreForm = new MasterRecycle("MaterialRequest");
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
