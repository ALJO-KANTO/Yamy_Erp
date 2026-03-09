using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class MasterReceiptVoucher : Form
    {
        private EventHandler ReceiptVoucherUpdatedHandler;

        public MasterReceiptVoucher()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            ReceiptVoucherUpdatedHandler = (sender, args) => BindVoucherData(cmbType.Text);
            EventHub.ReceiptVoucher += ReceiptVoucherUpdatedHandler;
            headerUC1.FormText = this.Text;
        }
        private void MasterReceiptVoucher_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.ReceiptVoucher -= ReceiptVoucherUpdatedHandler;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmViewReceiptVoucher());
        }
        private void MasterReceiptVoucher_Load(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 0;
            AppTheme.DefaultFont(dgvCustomer);
            AppTheme.DefaultFont(dgvDetails);
            StyleGrid(dgvCustomer);
            StyleGrid(dgvDetails);
        }
        private void StyleGrid(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(204, 229, 255);
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            // Header styles
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Silver; // Set header background to Silver
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;  // Keep text black for contrast
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9);

            // General Grid Appearance
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 28;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public void BindVoucherData(string type)
        {
            DataTable dt;
            if (chkDate.Checked)
             dt = DBClass.ExecuteDataTable(@"SELECT tp.id,tp.date AS Date,
                                            tp.code AS 'Receipt Code',
                                            LPAD(tp.id, 4, '0') AS 'JV NO',
                                            tp.amount AS Amount,
                                            concat(tc.code,' - ',tc.name) AS 'Debit Account', 
                                            concat(tc1.code,' - ',tc1.name) AS 'Credit Account' 
                                            FROM 
                                            tbl_receipt_voucher tp
                                            INNER JOIN 
                                            tbl_coa_level_4 tc ON tp.debit_account_id = tc.id
                                            INNER JOIN 
                                            tbl_coa_level_4 AS tc1 ON tp.credit_account_id = tc1.id where tp.type=@type",
                    DBClass.CreateParameter("type",type));
       else
                                dt = DBClass.ExecuteDataTable(@"SELECT tp.id,tp.date AS Date,
                                            tp.code AS 'Receipt Code',
                                            LPAD(tp.id, 4, '0') AS 'JV NO',
                                            tp.amount AS Amount,
                                            concat(tc.code,' - ',tc.name) AS 'Debit Account', 
                                            concat(tc1.code,' - ',tc1.name) AS 'Credit Account' 
                                            FROM 
                                            tbl_receipt_voucher tp
                                            INNER JOIN 
                                            tbl_coa_level_4 tc ON tp.debit_account_id = tc.id
                                            INNER JOIN 
                                            tbl_coa_level_4 AS tc1 ON tp.credit_account_id = tc1.id where tp.type=@type and tp.date >= @dateFrom and tp.date<= @dateTo",
                   DBClass.CreateParameter("dateFrom", dtFrom.Value.Date),
                   DBClass.CreateParameter("dateTo", dtTo.Value.Date),
                   DBClass.CreateParameter("type", type));
                            dgvCustomer.DataSource = dt;
            if (dt == null)
                return;

            dgvCustomer.Columns["id"].Visible = false;
            dgvCustomer.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvCustomer.Columns["Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvCustomer.Columns["Date"].Width = 120;

            //dgvCustomer.Columns["Receipt Code"].Width = 120;
            dgvCustomer.Columns["Receipt Code"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCustomer.Columns["Amount"].DefaultCellStyle.Format = "N2";
            dgvCustomer.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvCustomer.Columns["Amount"].Width = 100;

            //dgvCustomer.Columns["Debit Account"].Width = 180;
            //dgvCustomer.Columns["Credit Account"].Width = 180;


            LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);

            btnDelete.Enabled = btnEdit.Enabled = UserPermissions.canEdit("Receipt Voucher");
            btnDelete.Enabled = UserPermissions.canDelete("Receipt Voucher");
            AddViewDocImageColumn();
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

                bool hasAttachment = AttachmentManager.HasAttachment(purchaseId, "RECEIPT VOUCHER");
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
                AttachmentManager.OpenAttachmentByType(purchaseId, "RECEIPT VOUCHER");
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;

            frmLogin.frmMain.openChildForm(new frmViewReceiptVoucher(int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            if (dgvCustomer.Columns["JV NO"].Index == e.ColumnIndex)
                frmLogin.frmMain.openChildForm(new MasterTransactionJournal(dgvCustomer.CurrentRow.Cells["JV NO"].Value.ToString(), "RECEIPT"));
            else
                frmLogin.frmMain.openChildForm(new frmViewReceiptVoucher(int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())));
        }
        private void dgvCustomer_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void dgvCustomer_Leave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;

        }
      
        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
                dtFrom.Enabled = dtTo.Enabled = false;
            else
                dtFrom.Enabled = dtTo.Enabled = true;
            BindVoucherData(cmbType.Text);
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindVoucherData(cmbType.Text);
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = new DataTable();
            if (cmbType.Text == "Customer")
            {
                dt = DBClass.ExecuteDataTable(@"SELECT tp.Id,tp.Date,tp.inv_id `Inv No`,tp.inv_code `Invoice`,tp.Total,tp.Payment,tp.Description FROM tbl_receipt_voucher_details tp where payment_id = @id ",
                        DBClass.CreateParameter("id",dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()));

                dgvDetails.DataSource = dt;
                dgvDetails.Columns["Total"].DefaultCellStyle.Format = dgvDetails.Columns["Payment"].DefaultCellStyle.Format = "N2";
                dgvDetails.Columns["Total"].Width = 70;
                dgvDetails.Columns["Payment"].Width = 70;
                dgvDetails.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDetails.Columns["Payment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
                //dgvDetails.Columns["date"].HeaderText = "Date";
                //dgvDetails.Columns["date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                //dgvDetails.Columns["date"].Width = 120;

                //dgvDetails.Columns["invoice_id"].HeaderText = "Invoice ID";
                //dgvDetails.Columns["invoice_id"].Width = 120;

                //dgvDetails.Columns["payment"].HeaderText = "Payment";
                //dgvDetails.Columns["payment"].DefaultCellStyle.Format = "N2";
                //dgvDetails.Columns["payment"].Width = 100;

                //dgvDetails.Columns["description"].HeaderText = "Description";
                //dgvDetails.Columns["description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvDetails.Columns["description"].Width = 180;

                //dgvDetails.Columns["Cost center"].HeaderText = "Cost Center";
                //dgvDetails.Columns["Cost center"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvDetails.Columns["Cost center"].Width = 180;

                //// Apply alternate row color
                //dgvDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                //dgvDetails.DefaultCellStyle.SelectionForeColor = Color.Black; // Selection text color
                //dgvDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold); // Header font
                //dgvDetails.DefaultCellStyle.Font = new Font("Times New Roman", 9); // Cell font
                //dgvDetails.EnableHeadersVisualStyles = false; // Disable default header style for better customization

            }
         
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            DBClass.ExecuteNonQuery("UPDATE tbl_receipt_voucher SET state = -1 WHERE id = @id ",
                                          DBClass.CreateParameter("id", dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()));
            Utilities.LogAudit(frmLogin.userId, "Delete Receipt Voucher", "Receipt Voucher", int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()), "Deleted Receipt Voucher: " + dgvCustomer.SelectedRows[0].Cells["Receipt Code"].Value.ToString());
            BindVoucherData(cmbType.Text);
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            MasterRecycle restoreForm = new MasterRecycle("Receipt");
            restoreForm.DataRestored += RestoreForm_DataRestored;
            restoreForm.ShowDialog();

        }
        private void RestoreForm_DataRestored(object sender, EventArgs e)
        {
            BindVoucherData(cmbType.Text);
        }
    }
}
