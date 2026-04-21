using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;
using YamyProject.UI.Project_Management;

namespace YamyProject
{
    public partial class MasterProjectPaymentVoucher : Form
    {
        private EventHandler PaymentVoucherUpdatedHandler;

        public MasterProjectPaymentVoucher()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            PaymentVoucherUpdatedHandler = (sender, args) => BindPayment(cmbType.Text);
            EventHub.PaymentVoucher += PaymentVoucherUpdatedHandler;
            headerUC1.FormText = this.Text;
        }
        private void MasterProjectPaymentVoucher_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.PaymentVoucher -= PaymentVoucherUpdatedHandler;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmProjectPaymentVoucher());
        }
        private void MasterProjectPaymentVoucher_Load(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 0;
            AppTheme.DefaultFont(dgvCustomer);
            StyleGrid(dgvCustomer);
            guna2HtmlLabel2.Text = "Master Project Payment Voucher";
            cmbType.SelectedValue = -1;
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
                    SELECT pp.id,pp.code `Code`,pp.payment_date `Date`,p.name `Project`,c.name `Client / Owner`,project_value `Project Value`, pp.consultancy_fee `Consultancy`,pp.design_fee `Design`,pp.supervision_fee `Supervision`,pp.payment_source `Source`
                    FROM tbl_project_payments pp INNER JOIN tbl_projects p ON p.id=pp.project_id INNER JOIN tbl_customer c ON c.id = p.customer
                    WHERE pp.payment_source = @type",
                    DBClass.CreateParameter("type", type));
            else
                dt = DBClass.ExecuteDataTable(@"
                    SELECT pp.id,pp.code `Code`,pp.payment_date `Date`,p.name `Project`,c.name `Client / Owner`,project_value `Project Value`, pp.consultancy_fee `Consultancy`,pp.design_fee `Design`,pp.supervision_fee `Supervision`,pp.payment_source `Source`
                    FROM tbl_project_payments pp INNER JOIN tbl_projects p ON p.id=pp.project_id INNER JOIN tbl_customer c ON c.id = p.customer
                    WHERE pp.payment_source = @type
                        AND pp.payment_date >= @dateFrom 
                        AND pp.payment_date <= @dateTo",
                    DBClass.CreateParameter("dateFrom", dtFrom.Value.Date),
                    DBClass.CreateParameter("dateTo", dtTo.Value.Date),
                    DBClass.CreateParameter("type", type));

            dgvCustomer.DataSource = dt;

            if (dt == null) return;

            dgvCustomer.Columns["id"].Visible = false;
            //dgvCustomer.Columns["Amount"].DefaultCellStyle.Format = "N2";
            //dgvCustomer.Columns["Amount"].Width = 100;
            //dgvCustomer.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
            //if (dt != null)
            //{
            //    AddViewDocImageColumn();
            //}
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

                bool hasAttachment = AttachmentManager.HasAttachment(purchaseId, "PROJECT PAYMENT VOUCHER");
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
                AttachmentManager.OpenAttachmentByType(purchaseId, "PROJECT PAYMENT VOUCHER");
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;
            frmLogin.frmMain.openChildForm(new frmProjectPaymentVoucher(int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;

            //// Check if the double-clicked column is "JV NO"
            //if (dgvCustomer.Columns["JV NO"].Index == e.ColumnIndex)
            //{
            //    var jvNoCell = dgvCustomer.CurrentRow.Cells["JV NO"];

            //    // ✅ Check if JV NO cell is not null or empty
            //    if (jvNoCell != null && jvNoCell.Value != null && !string.IsNullOrWhiteSpace(jvNoCell.Value.ToString()))
            //    {
            //        frmLogin.frmMain.openChildForm(new MasterTransactionJournal(jvNoCell.Value.ToString(), "PROJECT PAYMENT"));
            //    }
            //    else
            //    {
            //        //MessageBox.Show("Journal Voucher No. is missing or invalid.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //else
            //{
                frmLogin.frmMain.openChildForm(new frmProjectPaymentVoucher(int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
            //}
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
