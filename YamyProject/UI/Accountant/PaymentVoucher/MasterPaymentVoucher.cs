using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class MasterPaymentVoucher : Form
    {
        private EventHandler PaymentVoucherUpdatedHandler;

        public MasterPaymentVoucher()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            PaymentVoucherUpdatedHandler = (sender, args) => BindPayment(cmbType.Text);
            EventHub.PaymentVoucher += PaymentVoucherUpdatedHandler;
            headerUC1.FormText = this.Text;
        }
        private void MasterPaymentVoucher_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.PaymentVoucher -= PaymentVoucherUpdatedHandler;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmViewPaymentVoucher());
        }
        private void MasterPaymentVoucher_Load(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 0;
            AppTheme.DefaultFont(dgvCustomer);
            AppTheme.DefaultFont(dgvDetails);
            StyleGrid(dgvCustomer);
            StyleGrid(dgvDetails);
            guna2HtmlLabel2.Text = "Master Payment Voucher";
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

        public void BindPayment(string type)
        {
            DataTable dt;
            if (chkDate.Checked)
                dt = DBClass.ExecuteDataTable(@"
                    SELECT 
                        tp.id, 
                        tp.date AS Date,
                        tp.code AS 'Payment Code',
                        LPAD(tp.id, 4, '0') AS 'JV NO', 
                        tp.amount AS Amount,
                        CONCAT(tc.code, ' - ', tc.name) AS 'Debit Account', 
                        CONCAT(tc1.code, ' - ', tc1.name) AS 'Credit Account' 
                    FROM tbl_payment_voucher tp
                    INNER JOIN tbl_coa_level_4 tc ON tp.debit_account_id = tc.id
                    INNER JOIN tbl_coa_level_4 tc1 ON tp.credit_account_id = tc1.id
                    WHERE tp.type = @type",
                    DBClass.CreateParameter("type", type));
            else
                dt = DBClass.ExecuteDataTable(@"
                    SELECT 
                        tp.id, 
                        tp.date AS Date,
                        tp.code AS 'Payment Code',
                        LPAD(tp.id, 4, '0') AS 'JV NO', 
                        tp.amount AS Amount,
                        CONCAT(tc.code, ' - ', tc.name) AS 'Debit Account', 
                        CONCAT(tc1.code, ' - ', tc1.name) AS 'Credit Account' 
                    FROM tbl_payment_voucher tp
                    INNER JOIN tbl_coa_level_4 tc ON tp.debit_account_id = tc.id
                    INNER JOIN tbl_coa_level_4 tc1 ON tp.credit_account_id = tc1.id
                    WHERE tp.type = @type 
                        AND tp.date >= @dateFrom 
                        AND tp.date <= @dateTo",
                    DBClass.CreateParameter("dateFrom", dtFrom.Value.Date),
                    DBClass.CreateParameter("dateTo", dtTo.Value.Date),
                    DBClass.CreateParameter("type", type));

            dgvCustomer.DataSource = dt;
            dgvCustomer.Columns["id"].Visible = false;
            dgvCustomer.Columns["Amount"].DefaultCellStyle.Format = "N2";
            //dgvCustomer.Columns["Amount"].Width = 100;
            dgvCustomer.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (dgvCustomer.Rows.Count > 0)
            {
                BindPVDetails();
                btnDelete.Enabled = UserPermissions.canDelete("Payment Voucher");
            }
            else
                dgvDetails.DataSource = null;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
            if (dt != null)
            {
                AddViewDocImageColumn();
            }
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

                bool hasAttachment = AttachmentManager.HasAttachment(purchaseId, "PAYMENT VOUCHER");
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
                AttachmentManager.OpenAttachmentByType(purchaseId, "PAYMENT VOUCHER");
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            frmLogin.frmMain.openChildForm(new frmViewPaymentVoucher(int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;

            // Check if the double-clicked column is "JV NO"
            if (dgvCustomer.Columns["JV NO"].Index == e.ColumnIndex)
            {
                var jvNoCell = dgvCustomer.CurrentRow.Cells["JV NO"];

                // ✅ Check if JV NO cell is not null or empty
                if (jvNoCell != null && jvNoCell.Value != null && !string.IsNullOrWhiteSpace(jvNoCell.Value.ToString()))
                {
                    frmLogin.frmMain.openChildForm(new MasterTransactionJournal(jvNoCell.Value.ToString(), "PAYMENT"));
                }
                else
                {
                    //MessageBox.Show("Journal Voucher No. is missing or invalid.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                frmLogin.frmMain.openChildForm(new frmViewPaymentVoucher(int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
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
        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
                dtFrom.Enabled = dtTo.Enabled = false;
            else
                dtFrom.Enabled = dtTo.Enabled = true;
            BindPayment(cmbType.Text);
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPayment(cmbType.Text);

        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BindPVDetails();
        }

        private void BindPVDetails()
        {
            DataTable dt = DBClass.ExecuteDataTable(@"
                               SELECT tp.Id,tp.Date,tp.inv_id `Inv No`,tp.inv_code `Invoice`,tp.Total,tp.Payment,tp.Description
                                FROM tbl_payment_voucher_details tp WHERE tp.payment_id = @id;",
                      DBClass.CreateParameter("id", dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()));

            dgvDetails.DataSource = dt;

            dgvDetails.Columns["Total"].DefaultCellStyle.Format = dgvDetails.Columns["Payment"].DefaultCellStyle.Format = "N2";
            //dgvDetails.Columns["Total"].Width = 100;
            dgvDetails.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetails.Columns["Payment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            LocalizationManager.LocalizeDataGridViewHeaders(dgvDetails);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            DBClass.ExecuteNonQuery("UPDATE tbl_payment_voucher SET state = -1 WHERE id = @id ",
                                          DBClass.CreateParameter("id", dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()));
            Utilities.LogAudit(frmLogin.userId, "Delete Payment Voucher", "Payment Voucher", int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()), "Deleted Payment Voucher: " + dgvCustomer.SelectedRows[0].Cells["Payment Code"].Value.ToString());
            BindPayment(cmbType.SelectedItem.ToString());
        }

        private void btnRecycle_Click(object sender, EventArgs e)
        {
            MasterRecycle restoreForm = new MasterRecycle("Payment");
            restoreForm.DataRestored += RestoreForm_DataRestored;
            restoreForm.ShowDialog();
        }
        private void RestoreForm_DataRestored(object sender, EventArgs e)
        {
            BindPayment(cmbType.SelectedItem.ToString());
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            BindPayment(cmbType.SelectedItem.ToString());
        }
        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            BindPayment(cmbType.SelectedItem.ToString());
        }
    }
}
