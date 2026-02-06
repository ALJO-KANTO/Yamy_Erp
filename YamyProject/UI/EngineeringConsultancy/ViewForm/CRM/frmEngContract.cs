using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.CRM
{
    public partial class frmEngContract : Form
    {
        public frmEngContract()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngContract_Load(object sender, EventArgs e)
        {
            cmbClient.DataSource = DBClass.ExecuteDataTable(
                "SELECT id, leadName FROM tbl_crmcustomer");
            cmbClient.DisplayMember = "leadName";
            cmbClient.ValueMember = "id";

            LoadContracts();
        }

        private void LoadContracts()
        {
            dgvContracts.DataSource = DBClass.ExecuteDataTable(
                @"SELECT ct.contract_id,ct.contract_no, c.LeadName client_name, ct.contract_value,
                         ct.start_date, ct.end_date,ct.client_id, ct.signed_date
                  FROM tbl_crm_contracts ct
                  JOIN tbl_crmcustomer c ON c.id = ct.client_id");

            dgvContracts.Columns["contract_id"].Visible = false;
            dgvContracts.Columns["client_id"].Visible = false;
            LocalizationManager.LocalizeDataGridViewHeaders(dgvContracts);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id > 0) // existing contract, update
            {
                DBClass.ExecuteNonQuery(
                    @"UPDATE tbl_crm_contracts
                      SET client_id = @cid,
                          contract_no = @no,
                          contract_value = @val,
                          start_date = @start,
                          end_date = @end,
                          signed_date = @signed_date
                      WHERE contract_id = @id",
                    DBClass.CreateParameter("@id", id),
                    DBClass.CreateParameter("@cid", cmbClient.SelectedValue),
                    DBClass.CreateParameter("@no", txtContractNo.Text),
                    DBClass.CreateParameter("@val", txtValue.Text.Replace(",","")),
                    DBClass.CreateParameter("@start", dtStart.Value),
                    DBClass.CreateParameter("@end", dtEnd.Value),
                    DBClass.CreateParameter("@signed_date", dtSignedDate.Value)
                );
            }
            else // new contract, insert
            {
                DBClass.ExecuteNonQuery(
                    @"INSERT INTO tbl_crm_contracts
                      (client_id, contract_no, contract_value, start_date, end_date, signed_date)
                      VALUES (@cid, @no, @val, @start, @end, @signed_date)",
                    DBClass.CreateParameter("@cid", cmbClient.SelectedValue),
                    DBClass.CreateParameter("@no", txtContractNo.Text),
                    DBClass.CreateParameter("@val", txtValue.Text.Replace(",", "")),
                    DBClass.CreateParameter("@start", dtStart.Value),
                    DBClass.CreateParameter("@end", dtEnd.Value),
                    DBClass.CreateParameter("@signed_date", dtSignedDate.Value)
                );
            }

            LoadContracts();
        }
        int id = 0;

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvContracts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header clicks

            var row = dgvContracts.Rows[e.RowIndex];

            // Set the current contract ID for updates
            id = Convert.ToInt32(row.Cells["contract_id"].Value);

            // Populate form fields
            cmbClient.SelectedValue = Convert.ToInt32(row.Cells["client_id"].Value);
            txtContractNo.Text = row.Cells["contract_no"].Value.ToString();
            txtValue.Text = decimal.Parse(row.Cells["contract_value"].Value.ToString()).ToString("N2");
            dtStart.Value = Convert.ToDateTime(row.Cells["start_date"].Value);
            dtEnd.Value = Convert.ToDateTime(row.Cells["end_date"].Value);
            dtSignedDate.Value = Convert.ToDateTime(row.Cells["signed_date"].Value);
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            // Allow digits only
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
