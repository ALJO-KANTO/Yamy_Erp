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
    public partial class frmEngProposal : Form
    {
        public frmEngProposal()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngProposal_Load(object sender, EventArgs e)
        {
            cmbClient.DataSource = DBClass.ExecuteDataTable(
                "SELECT id, leadName FROM tbl_crmcustomer");
            cmbClient.DisplayMember = "leadName";
            cmbClient.ValueMember = "id";
            cmbEmployee.DataSource = DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_employee");
            cmbEmployee.DisplayMember = "name";
            cmbEmployee.ValueMember = "id";
            LoadProposals();
        }

        private void LoadProposals()
        {
            dgvProposals.DataSource = DBClass.ExecuteDataTable(
                @"SELECT p.proposal_id, c.LeadName `Client Name`, p.Title, p.Amount, p.Status, p.employee_id, p.client_id
                  FROM tbl_crm_proposals p
                  JOIN tbl_crmcustomer c ON c.id = p.client_id");

            dgvProposals.Columns["proposal_id"].Visible = false;
            dgvProposals.Columns["employee_id"].Visible = false;
            dgvProposals.Columns["client_id"].Visible = false;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvProposals);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                DBClass.ExecuteNonQuery(
                @"UPDATE tbl_crm_proposals
                  SET client_id=@client_id, title= @title, amount= @amount, status= @status, updated_at = NOW(), employee_id = @employee where proposal_id = @proposal_id",
                DBClass.CreateParameter("@proposal_id", id),
                DBClass.CreateParameter("@client_id", cmbClient.SelectedValue),
                DBClass.CreateParameter("@title", txtTitle.Text),
                DBClass.CreateParameter("@amount", txtAmount.Text),
                DBClass.CreateParameter("@status", cmbStatus.Text),
                DBClass.CreateParameter("@employee", cmbEmployee.SelectedValue)
            );
            }
            else
            {
                DBClass.ExecuteNonQuery(
                    @"INSERT INTO tbl_crm_proposals
                    (client_id, title, amount, status, created_date, employee_id)
                    VALUES (@client_id, @title, @amount, @status, NOW(), @employee)",
                    DBClass.CreateParameter("@client_id", cmbClient.SelectedValue),
                    DBClass.CreateParameter("@title", txtTitle.Text),
                    DBClass.CreateParameter("@amount", txtAmount.Text),
                    DBClass.CreateParameter("@status", cmbStatus.Text),
                    DBClass.CreateParameter("@employee", cmbEmployee.SelectedValue)
                );
            }

            LoadProposals();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int id = 0;
        private void dgvProposals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvProposals.Rows[e.RowIndex];

            id = Convert.ToInt32(row.Cells["proposal_id"].Value);
            cmbClient.SelectedValue = Convert.ToInt32(row.Cells["client_id"].Value);
            cmbEmployee.SelectedValue = Convert.ToInt32(row.Cells["employee_id"].Value);
            cmbStatus.SelectedItem = row.Cells["Status"].Value.ToString();
            txtTitle.Text = row.Cells["Title"].Value.ToString();
            txtAmount.Text = decimal.Parse(row.Cells["Amount"].Value.ToString()).ToString("N2");
        }

    }
}
