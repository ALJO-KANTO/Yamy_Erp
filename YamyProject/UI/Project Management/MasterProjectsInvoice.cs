using System;
using System.Data;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;
using YamyProject.UI.Project_Management;

namespace YamyProject
{
    public partial class MasterProjectsInvoice : Form
    {
        private EventHandler projectInvoiceUpdatedHandler;

        public MasterProjectsInvoice()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            projectInvoiceUpdatedHandler  = (sender, args) => ProjectData();
            EventHub.ProjectInvoice += projectInvoiceUpdatedHandler;
            this.Text = "Projects Invoice Center";
            headerUC1.FormText = this.Text;
        }
        private void MasterProjectsInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.ProjectInvoice -= projectInvoiceUpdatedHandler;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmProjectsInvoiceForm());
        }
        private void MasterProjectsInvoice_Load(object sender, EventArgs e)
        {
            ProjectData();
        }
        public void ProjectData()
        {
            DataTable dT = DBClass.ExecuteDataTable(@"SELECT ROW_NUMBER() OVER (ORDER BY pi.invoice_id) AS SN, pi.invoice_id id, pi.invoice_number `Invoice No`,pi.invoice_date `Invoice Date`, p.name `Project`,l4.name `Account`,
                                                    pi.Amount,pi.Vat,pi.retention_amount as Retention, pi.Deduction,pi.Total,pi.Status,pi.paid_amount `Paid` FROM tbl_projects_invoices pi 
                                                    INNER JOIN tbl_projects p ON p.id = pi.project_id
                                                    INNER JOIN tbl_coa_level_4 l4 ON l4.id = pi.account_id");
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                string filterExpression = $"[Invoice No] LIKE '%{txtSearch.Text}%' OR [Project] LIKE '%{txtSearch.Text}%' OR [Account] LIKE '%{txtSearch.Text}%'";
                DataRow[] filteredRows = dT.Select(filterExpression);
                if (filteredRows.Length > 0)
                {
                    dT = filteredRows.CopyToDataTable();
                }
                else
                {
                    dT.Clear(); // Clear the DataTable if no matches found
                }
            }

            if (dT == null)
                return;

            dgvCustomer.DataSource = dT;
            dgvCustomer.Columns["id"].Visible = false;
            dgvCustomer.Columns["SN"].Width = 20;
            dgvCustomer.Columns["Invoice No"].Width = 50;
            dgvCustomer.Columns["Invoice Date"].Width = 60;
            dgvCustomer.Columns["Project"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.Columns["Amount"].DefaultCellStyle.Alignment = dgvCustomer.Columns["Retention"].DefaultCellStyle.Alignment = dgvCustomer.Columns["deduction"].DefaultCellStyle.Alignment = dgvCustomer.Columns["Vat"].DefaultCellStyle.Alignment = dgvCustomer.Columns["Total"].DefaultCellStyle.Alignment = dgvCustomer.Columns["Paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCustomer.Columns["Amount"].DefaultCellStyle.Format = dgvCustomer.Columns["Retention"].DefaultCellStyle.Format = dgvCustomer.Columns["deduction"].DefaultCellStyle.Format = dgvCustomer.Columns["Vat"].DefaultCellStyle.Format = dgvCustomer.Columns["Total"].DefaultCellStyle.Format = dgvCustomer.Columns["Paid"].DefaultCellStyle.Format = "0.00";
            //dgvCustomer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //if (dgvCustomer.Rows.Count > 0)
            //{
            //    btnRemove.Enabled = UserPermissions.canDelete("Project Center");
            //}
            LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);


            if (dgvCustomer.Rows != null && dgvCustomer.Rows.Count > 0)
            {
                AddViewDocImageColumn();
            }
        }
        private void AddViewDocImageColumn()
        {
            if (!dgvCustomer.Columns.Contains("ViewDoc"))
            {
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                imgColumn.Name = "ViewDoc";
                imgColumn.HeaderText = "View Doc";
                imgColumn.Image = Properties.Resources.doc_icon; // <-- your image here
                imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // fit nicely
                dgvCustomer.Columns.Add(imgColumn);
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;

            object result = DBClass.ExecuteScalar(@"SELECT COUNT(1) FROM tbl_projects_invoices 
                  WHERE invoice_id = @id", DBClass.CreateParameter("id", int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
            int recordCount = 0;
            if (result != null && result != DBNull.Value)
                recordCount = Convert.ToInt32(result);
            if (recordCount > 0)
            {
                MessageBox.Show("Already used");
                return;
            }
            DBClass.ExecuteNonQuery("DELETE FROM tbl_projects_invoices WHERE invoice_id=@id", DBClass.CreateParameter("id", int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
            MessageBox.Show("Deleted");
            ProjectData();
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;

            frmLogin.frmMain.openChildForm(new frmProjectsInvoiceForm(int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())));
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCustomer.Columns[e.ColumnIndex].Name == "ViewDoc")
            {
                var cell = dgvCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value == null) return; // no attachment, do nothing

                int _vId = Convert.ToInt32(dgvCustomer.Rows[e.RowIndex].Cells["vrefId"].Value);
                string type = dgvCustomer.Rows[e.RowIndex].Cells["vVoucherType"].Value.ToString();
                AttachmentManager.OpenAttachmentByType(_vId, type);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(!txtSearch.Focused) return;

            ProjectData();
        }
    }
}
