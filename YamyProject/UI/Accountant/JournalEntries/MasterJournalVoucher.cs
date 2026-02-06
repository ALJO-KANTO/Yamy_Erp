using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class MasterJournalVoucher : Form
    {
        private EventHandler JournalVoucherUpdatedHandler;

        public MasterJournalVoucher()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            JournalVoucherUpdatedHandler = (sender, args) => BindVoucherData();
            EventHub.Journal += JournalVoucherUpdatedHandler;
            headerUC1.FormText = this.Text;
        }
        private void MasterPaymentVoucher_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.Journal -= JournalVoucherUpdatedHandler;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmViewJournalVoucher(0));
        }
        private void MasterJournalVoucher_Load(object sender, EventArgs e)
        {
            StyleGrid(dgvCustomer);
            StyleGrid(dgvDetails);
            Lbheader.Text = "Master Journal Voucher";
            BindVoucherData();
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

        public void BindVoucherData()
        {
            DataTable dt;
            if (chkDate.Checked)
                dt = DBClass.ExecuteDataTable(@"
                        SELECT 
                            jv.id, 
                            jv.date AS Date,
                            jv.code AS 'Journal Code',
                            LPAD(jv.id, 4, '0') AS 'JV NO',
                            jv.debit AS 'Debit Amount', 
                            jv.credit AS 'Credit Amount' 
                        FROM tbl_journal_voucher jv Where state=0");
            else
                dt = DBClass.ExecuteDataTable(@"
                        SELECT 
                            jv.id, 
                            jv.date AS Date,
                            jv.code AS 'Journal Code',
                            LPAD(jv.id, 4, '0') AS 'JV NO',
                            jv.debit AS 'Debit Amount', 
                            jv.credit AS 'Credit Amount' 
                        FROM tbl_journal_voucher jv Where state=0
                            AND jv.date >= @dateFrom 
                            AND jv.date <= @dateTo",
                    DBClass.CreateParameter("dateFrom", dtFrom.Value.Date),
                    DBClass.CreateParameter("dateTo", dtTo.Value));

            dgvCustomer.DataSource = dt;
            dgvCustomer.Columns["id"].Visible = false;
            if (dgvCustomer.Rows.Count > 0)
                BindJVDetails();
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

                bool hasAttachment = AttachmentManager.HasAttachment(purchaseId, "JOURNAL VOUCHER");
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
                AttachmentManager.OpenAttachmentByType(purchaseId, "JOURNAL VOUCHER");
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            frmLogin.frmMain.openChildForm(new frmViewJournalVoucher(int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            if (dgvCustomer.Columns["JV NO"].Index == e.ColumnIndex)
                frmLogin.frmMain.openChildForm(new MasterTransactionJournal(dgvCustomer.CurrentRow.Cells["JV NO"].Value.ToString(), "JOURNAL"));
            else
                frmLogin.frmMain.openChildForm(new frmViewJournalVoucher(int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
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
            BindVoucherData();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindVoucherData();
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BindJVDetails();
        }

        private void BindJVDetails()
        {
            DataTable dt = DBClass.ExecuteDataTable(@"
                           SELECT 
                           jd.date,
                           a.name,
                           jd.debit AS 'Debit Amount',
                           jd.credit AS 'Credit Amount',
                           jd.partner AS Partner,
                           jd.description AS Description
                        FROM tbl_journal_voucher_details jd
                        INNER JOIN tbl_coa_level_4 a ON jd.account_id = a.id
                        WHERE jd.inv_id = @id;",
                      DBClass.CreateParameter("id", dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()));

            dgvDetails.DataSource = dt;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvDetails);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            DBClass.ExecuteNonQuery("UPDATE tbl_journal_voucher SET state = -1 WHERE id = @id ",
                                          DBClass.CreateParameter("id", dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()));
            Utilities.LogAudit(frmLogin.userId, "Delete Journal Voucher", "Journal Voucher", int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()), "Deleted Journal Voucher: " + dgvCustomer.SelectedRows[0].Cells["Journal Code"].Value.ToString());
            BindVoucherData();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            MasterRecycle restoreForm = new MasterRecycle("Journal");
            restoreForm.DataRestored += RestoreForm_DataRestored;
            restoreForm.ShowDialog();
        }
        private void RestoreForm_DataRestored(object sender, EventArgs e)
        {
            BindVoucherData();
        }

        private void nToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmViewJournalVoucher(0));
        }

        private void editCustomerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            frmLogin.frmMain.openChildForm(new frmViewJournalVoucher(int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
        }

        private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            DBClass.ExecuteNonQuery("UPDATE tbl_journal_voucher SET state = -1 WHERE id = @id ",
                                          DBClass.CreateParameter("id", dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()));
            Utilities.LogAudit(frmLogin.userId, "Delete Journal Voucher", "Journal Voucher", int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()), "Deleted Journal Voucher: " + dgvCustomer.SelectedRows[0].Cells["Journal Code"].Value.ToString());
            BindVoucherData();
        }

        private void restoreJournalVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterRecycle restoreForm = new MasterRecycle("Journal");
            restoreForm.DataRestored += RestoreForm_DataRestored;
            restoreForm.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void Lbheader_Click(object sender, EventArgs e)
        {
            this.BringToFront();
        }
    }
}
