using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class MasterDeliveryNote : Form
    {
        private EventHandler customerUpdatedHandler;
        private EventHandler invoiceUpdatedHandler;

        public MasterDeliveryNote()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            customerUpdatedHandler = (sender, args) => BindCombos.PopulateCustomers(cmbCustomer);
            invoiceUpdatedHandler = (sender, args) => BindInvoices();
            EventHub.Customer += customerUpdatedHandler;
            EventHub.SalesInv += invoiceUpdatedHandler;
            headerUC1.FormText = this.Text;
        }
        private void MasterDeliveryNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.Customer -= customerUpdatedHandler;
            EventHub.SalesInv -= invoiceUpdatedHandler;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {          
            frmLogin.frmMain.openChildForm(new frmDeliveryNote(0));
        }
        private void MasterDeliveryNote_Load(object sender, EventArgs e)
        {
            AppTheme.DefaultFont(dgvInvoice);
            AppTheme.DefaultFont(dgvItems);
            btnDelete.Enabled = UserPermissions.canDelete("Create Invoice");
            BindCombos.PopulateCustomers(cmbCustomer);
            BindInvoices();
        }
        private void BindInvoices()
        {
            // Disable UI controls while loading (optional)
            dgvInvoice.Enabled = false;

            // Capture current filter values to avoid cross-thread issues
            string selectionMethod = cmbSelectionMethod.Text;
            string customerText = cmbCustomer.Text;
            bool customerChecked = chkCustomer.Checked;
            bool dateChecked = chkDate.Checked;
            DateTime dateFrom = dtFrom.Value.Date;
            DateTime dateTo = dtTo.Value.Date;

            // Prepare query and parameters on background thread
            string query = GetQuery();
            List<MySqlParameter> parameters = GetQueryParameters();

            DataTable dt = DBClass.ExecuteDataTable(query, parameters.ToArray());
            if (dt != null)
            {
                BindDataToGrid(dt);
                HandleInvoiceItems();
                dgvInvoice.Enabled = true;
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

                bool hasAttachment = AttachmentManager.HasAttachment(purchaseId, "DELIVERY NOTE");
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
                AttachmentManager.OpenAttachmentByType(purchaseId, "DELIVERY NOTE");
            }
        }
        private string GetQuery()
        {
            string query = cmbSelectionMethod.Text == "Default" ? GetDefaultQuery() : GetDetailedQuery();
            return query;
        }
        private string GetDefaultQuery()
        {
            return @"SELECT 
                        ROW_NUMBER() OVER (ORDER BY tbl_delivery_note.date) AS `SN`, 
                        tbl_delivery_note.date AS Date, 
                        tbl_delivery_note.id,
                        tbl_delivery_note.invoice_id AS 'INV NO', 
                        CONCAT(tbl_customer.code, ' - ', tbl_customer.name) AS 'Customer Name', 
                        tbl_delivery_note.ship_to AS 'Ship To',
                        tbl_delivery_note.total AS Total,
                        tbl_delivery_note.vat AS Vat,
                        tbl_delivery_note.Net AS 'Net'
                    FROM tbl_delivery_note
                    INNER JOIN tbl_customer ON tbl_delivery_note.customer_id = tbl_customer.id 
                    WHERE tbl_delivery_note.state = 0
                    GROUP BY tbl_delivery_note.id, tbl_delivery_note.date, tbl_delivery_note.invoice_id, tbl_customer.code, tbl_customer.name, tbl_delivery_note.total;";
        }

        private string GetDetailedQuery()
        {
            return @"SELECT 
                    ROW_NUMBER() OVER (ORDER BY tbl_delivery_note.date) AS `SN`, 
                    tbl_delivery_note.date AS Date, 
                    tbl_delivery_note.id,
                    tbl_delivery_note.invoice_id AS 'INV NO', 
                    CONCAT(tbl_customer.code, ' - ', tbl_customer.name) AS 'Customer Name', 
                        tbl_delivery_note.ship_to AS 'Ship To',
                    tbl_delivery_note.total AS Total,
                    tbl_delivery_note.vat AS Vat,
                    tbl_delivery_note.net AS 'Net',
                    CONCAT(ti.code, ' - ', ti.name) AS 'Item Name',
                    ts.qty AS Qty,
                    ts.price AS Price,
                    ts.vat AS 'Item Vat',
                    ts.total AS 'Item Total'
                FROM tbl_delivery_note
                INNER JOIN tbl_delivery_note_details ts ON tbl_delivery_note.id = ts.sales_id
                INNER JOIN tbl_items ti ON ts.item_id = ti.id
                INNER JOIN tbl_customer ON tbl_delivery_note.customer_id = tbl_customer.id
                WHERE tbl_delivery_note.state = 0
                GROUP BY tbl_delivery_note.id, tbl_delivery_note.date, tbl_delivery_note.invoice_id, tbl_customer.code, tbl_customer.name, tbl_delivery_note.total, ti.code, ti.name, ts.qty, ts.price, ts.vat, ts.total;";
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
        }

        private void BindDataToGrid(DataTable dt)
        {
            dgvInvoice.DataSource = dt;
            dgvInvoice.Columns["Customer Name"].MinimumWidth = 200;
            dgvInvoice.Columns["Customer Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvInvoice.Columns["id"].Visible = false;
            if (dgvInvoice.Rows.Count > 0)
            {
                btnEdit.Enabled = UserPermissions.canEdit("Create Invoice");
                btnDelete.Enabled = btnRecycle.Enabled = UserPermissions.canDelete("Create Invoice");
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
                                                     tbl_delivery_note_details ts inner join tbl_items ti on ts.item_id = ti.id where sales_id = @id",
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
            frmLogin.frmMain.openChildForm(new frmDeliveryNote(int.Parse(dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString())));
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvInvoice.Rows.Count == 0)
                return;
            if(dgvInvoice.CurrentRow.Cells["id"].Value !=null)
            {
                frmLogin.frmMain.openChildForm(new frmDeliveryNote(int.Parse(dgvInvoice.CurrentRow.Cells["id"].Value.ToString())));
            }
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

            DBClass.ExecuteNonQuery("UPDATE tbl_delivery_note SET state = -1 WHERE id = @id ; UPDATE tbl_transaction SET state= -1 WHERE transaction_id=@id AND t_type = 'SALES'; ",
                                          DBClass.CreateParameter("id", dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString()));
            CommonInsert.DeleteItemTransaction("Sales", dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString());

            Utilities.LogAudit(frmLogin.userId, "Delete Invoice", "Sales", int.Parse(dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString()), "Deleted Invoice: " + dgvInvoice.SelectedRows[0].Cells["INV NO"].Value.ToString());

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

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRecycle_Click(object sender, EventArgs e)
        {
            MasterRecycle restoreForm = new MasterRecycle("Sales");
            restoreForm.DataRestored += RestoreForm_DataRestored;
            restoreForm.ShowDialog();

        }
        private void RestoreForm_DataRestored(object sender, EventArgs e)
        {
            BindInvoices();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
