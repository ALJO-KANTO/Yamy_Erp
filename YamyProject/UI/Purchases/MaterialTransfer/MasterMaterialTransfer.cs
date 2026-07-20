using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;
using YamyProject.UI.Purchases.MaterialTransfer;

namespace YamyProject
{
    public partial class MasterMaterialTransfer : Form
    {
        private EventHandler vendorUpdatedHandler;
        private EventHandler invoiceUpdatedHandler;

        int _currentPage = 1;
        int _pageSize = 50; // Or any default rows per page
        int _totalRecords = 0;
        int _totalPages = 0;

        public MasterMaterialTransfer()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            vendorUpdatedHandler = (sender, args) => BindCombos.PopulateEmployees(cmbCustomer);
            invoiceUpdatedHandler = (sender, args) => BindInvoices();
            EventHub.Vendor += vendorUpdatedHandler;
            EventHub.MaterialTransfer += invoiceUpdatedHandler;
            headerUC1.FormText = this.Text;
        }
        private void MasterMaterialTransfer_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.Vendor -= vendorUpdatedHandler;
            EventHub.MaterialTransfer -= invoiceUpdatedHandler;

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmMaterialTransfer());
        }
        private void MasterMaterialTransfer_Load(object sender, EventArgs e)
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
                query = @"SELECT ROW_NUMBER() OVER (ORDER BY mt.transfer_date) AS `SN`,mt.transfer_id id,mt.transfer_no `No`,mt.transfer_type `Transfer Type`,p.name Project,w.name `From Warehouse`,mt.vehicle_no `Vehicle No`,mt.driver_name `DriverName`,mt.Status
                        FROM tbl_material_transfer mt INNER JOIN tbl_projects p ON p.id = from_project_id INNER JOIN tbl_warehouse w ON w.id = mt.from_warehouse_id";
            }
            else
            {
                query = @"Select ROW_NUMBER() OVER (ORDER BY mt.transfer_date) AS `SN`,mt.transfer_id id,mt.transfer_no `No`,p.name Project,i.name `Item Name`,mti.available_qty `Available Qty`,mti.transfer_qty `Transfer Qty`,uom `UOM`,unit_cost `Cost`,line_total `Total`,mti.remarks
                        FROM tbl_material_transfer mt INNER JOIN tbl_projects p ON p.id = from_project_id
                        INNER JOIN tbl_material_transfer_item mti ON mti.item_id = mt.transfer_id 
                        INNER JOIN tbl_items i ON i.id = mti.item_id";
            }


            if (!chkDate.Checked)
            {
                query += " AND mt.transfer_date >= @dateFrom AND mt.transfer_date <= @dateTo";

                parameters.Add(DBClass.CreateParameter("@dateFrom", dtFrom.Value.Date));
                parameters.Add(DBClass.CreateParameter("@dateTo", dtTo.Value.Date));
            }
            if (cmbCustomer.SelectedValue != null && !chkCustomer.Checked)
            {
                query += " AND mt.received_by = @received_by";
                parameters.Add(DBClass.CreateParameter("@received_by", cmbCustomer.SelectedValue));
            }

            int offset = (_currentPage - 1) * _pageSize;

            query += " LIMIT @_limit OFFSET @_offset";

            parameters.Add(DBClass.CreateParameter("@_limit", _pageSize));
            parameters.Add(DBClass.CreateParameter("@_offset", offset));


            DataTable dt = DBClass.ExecuteDataTable(query, parameters.ToArray());


            string countQuery = @"
                                SELECT COUNT(*) 
                                FROM tbl_material_transfer mt
                                WHERE mt.transfer_id > 0
                            ";

            List<MySqlParameter> countParams = new List<MySqlParameter>();

            if (!chkDate.Checked)
            {
                countQuery += " AND mt.transfer_date >= @dateFrom AND mt.transfer_date <= @dateTo";

                countParams.Add(DBClass.CreateParameter("@dateFrom", dtFrom.Value.Date));
                countParams.Add(DBClass.CreateParameter("@dateTo", dtTo.Value.Date));
            }

            _totalRecords = Convert.ToInt32(DBClass.ExecuteScalar(countQuery, countParams.ToArray()));
            _totalPages = (_totalRecords + _pageSize - 1) / _pageSize;


            if (dt != null)
            {
                dgvCustomer.DataSource = dt;

                if (dgvCustomer.Columns.Contains("id"))
                    dgvCustomer.Columns["id"].Visible = false;

                if (dgvCustomer.Columns.Contains("No"))
                    dgvCustomer.Columns["No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Load items if header mode
                if (dgvCustomer.Rows.Count > 0 && cmbSelectionMethod.Text == "Default")
                    bindInvoiceItems();
                else
                    dgvItems.DataSource = null;

                if (dgvCustomer.Rows.Count > 0)
                {
                    btnEdit.Enabled = UserPermissions.canEdit("Material Transfer");
                    btnDelete.Enabled = btnRecycle.Enabled = UserPermissions.canDelete("Material Transfer");
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

                bool hasAttachment = AttachmentManager.HasAttachment(purchaseId, "MATERIAL TRANSFER");
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
                AttachmentManager.OpenAttachmentByType(purchaseId, "MATERIAL TRANSFER");
            }
        }

        private void bindInvoiceItems()
        {
            DataTable dt = DBClass.ExecuteDataTable(@"SELECT 
                                concat(i.code,' - ' ,i.name) as 'Item Name',
								mti.available_qty `Available Qty`,mti.transfer_qty `Transfer Qty`,mti.uom `UOM`,mti.unit_cost `Cost`,mti.line_total `Total`,
                                mti.Remarks
									 FROM tbl_material_transfer_item mti
                            INNER JOIN tbl_items i ON mti.item_id = i.id
                            WHERE mti.transfer_id = @id",
                            DBClass.CreateParameter("@id", dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()));

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

            frmLogin.frmMain.openChildForm(new frmMaterialTransfer( int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;

            frmLogin.frmMain.openChildForm(new frmMaterialTransfer(int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())));
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

            //if (int.Parse(dgvCustomer.SelectedRows[0].Cells["tranfer_status"].Value.ToString()) <= 0)
            //{
            //    frmLogin.frmMain.openChildForm(new frmPurchaseOrder(int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString()), "PR"));
            //}
            //else
            //{
            //    MessageBox.Show("Materila Transfer already created.", "Cannot Create", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (dgvCustomer.Rows.Count == 0)
            //    return;
            //DBClass.ExecuteNonQuery("UPDATE tbl_material_transfer SET state = -1 WHERE id = @id ",
            //                              DBClass.CreateParameter("id", dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()));
            //Utilities.LogAudit(frmLogin.userId, "Delete Material Transfer", "Maretial Transfer", int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()), "Deleted Material Transfer: " + dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString());

            //_currentPage = 1;
            //BindInvoices();
        }
        private void btnRecycle_Click(object sender, EventArgs e)
        {
            //MasterRecycle restoreForm = new MasterRecycle("MaterialReservation");
            //restoreForm.DataRestored += RestoreForm_DataRestored;
            //restoreForm.ShowDialog();
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
