using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class MasterProjectSiteSetup : Form
    {

        private EventHandler eventHandler;
        bool isExported = false;
        public MasterProjectSiteSetup()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            eventHandler = (sender, args) => BindInvoices();
            EventHub.ProjectViewSites += eventHandler;
            this.Text = "Project Sites Center";
            headerUC1.FormText = this.Text;
            dtFrom.Value = DateTime.Now;
            dtTo.Value = DateTime.Now;
        }
        
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmViewProjectSiteSetup(0));
        }
        private void MasterProjectSites_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateProjects(cmbProject);
            BindInvoices();
        }
        public void BindInvoices()
        {
            DataTable dt;
            string query = @"SELECT 
                              ROW_NUMBER() OVER (ORDER BY pss.date) AS `SN`, pss.date AS DATE,pss.id,
				              CONCAT(tbl_projects.code,' - ', tbl_projects.name) AS 'Project Name',
				              CONCAT(tbl_tender_names.code,' - ', tbl_tender_names.name) AS 'Tender Name', 
				              pss.engineer_supervisor as 'Engineer/Supervisor', ps.name Site, pss.Status
                            FROM  tbl_projects_site_setup pss INNER JOIN  tbl_projects ON pss.project_id = tbl_projects.id
				            INNER JOIN tbl_tender_names ON pss.tender_name_id = tbl_tender_names.id
                            INNER JOIN tbl_project_sites ps ON ps.id = pss.site_id
                           ";

            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (cmbProject.Text != "" && !chkProject.Checked)
            {
                query += " and pss.project_id = @id";
                parameters.Add(DBClass.CreateParameter("id", cmbProject.SelectedValue.ToString()));
            }
            if (cmbTenderName.Text != "" && !chkTenderName.Checked)
            {
                query += " and pss.tender_name_id = @tender";
                parameters.Add(DBClass.CreateParameter("tender", cmbTenderName.SelectedValue.ToString()));
            }
            if (!chkDate.Checked)
                query += " and pss.date >= @dateFrom and pss.date <= @dateTo";
            
            parameters.Add(DBClass.CreateParameter("dateFrom", dtFrom.Value.Date));
            parameters.Add(DBClass.CreateParameter("dateTo", dtTo.Value.Date));
            dt = DBClass.ExecuteDataTable(query, parameters.ToArray());
            dgView.DataSource = dt;
            dgView.Columns["Project Name"].MinimumWidth = 200;
            dgView.Columns["Project Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgView.Columns["Tender Name"].MinimumWidth = 200;
            dgView.Columns["Tender Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgView.Columns["id"].Visible = false;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindInvoices();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgView.Rows.Count == 0)
                return;
            frmLogin.frmMain.openChildForm(new frmViewProjectSiteSetup(int.Parse(dgView.SelectedRows[0].Cells["id"].Value.ToString())));
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgView.Rows.Count == 0)
                return;

            frmLogin.frmMain.openChildForm(new frmViewProjectSiteSetup(int.Parse(dgView.CurrentRow.Cells["id"].Value.ToString())));
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
            //string query = "UPDATE tbl_project_tender SET state = -1 WHERE id = @id ";
            //DBClass.ExecuteNonQuery(query, DBClass.CreateParameter("id", dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString()));
            //BindInvoices();
        }
        private void btnRestore_Click(object sender, EventArgs e)
        {
            //_mainForm.openChildForm(new MasterInventoryRecycle(_mainForm, this));

        }
        private void chkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProject.Checked)
                cmbProject.Enabled = false;
            else
                cmbProject.Enabled = true;
            BindInvoices();
        }
        private void chkPayment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTenderName.Checked)
                cmbTenderName.Enabled = false;
            else
                cmbTenderName.Enabled = true;
            BindInvoices();
        }
        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
                dtFrom.Enabled = dtTo.Enabled = false;
            else
                dtFrom.Enabled = dtTo.Enabled = true;
            BindInvoices();
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void cmbSalesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindInvoices();
        }
        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            BindInvoices();
        }
    }
}
