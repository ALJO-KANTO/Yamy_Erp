using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using YamyProject.Localization;
using YamyProject.UI.Project_Management.ProjectWBS;

namespace YamyProject
{
    public partial class MasterProjectSiteWBS : Form
    {
        public MasterProjectSiteWBS()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
        }
        
        private void MasterProjectSites_Load(object sender, EventArgs e)
        {
            cmbSiteSetup.DataSource = DBClass.ExecuteDataTable("select pss.id,concat(pss.id,' - ',p.name) name from tbl_projects_site_setup pss INNER JOIN tbl_project_sites p ON p.id = pss.site_id");
            cmbSiteSetup.DisplayMember = "name";
            cmbSiteSetup.ValueMember = "id";

            BindInvoices();
        }
        public void BindInvoices()
        {
            DataTable dt;
            string query = @"SELECT 
                              ROW_NUMBER() OVER (ORDER BY pss.date) AS `SN`, pss.date AS DATE,pss.id,pss.project_id,pss.tender_id
				              CONCAT(tbl_projects.code,' - ', tbl_projects.name) AS 'Project Name',
				              CONCAT(tbl_tender_names.code,' - ', tbl_tender_names.name) AS 'Tender Name', 
				              pss.engineer_supervisor as 'Engineer/Supervisor', ps.name Site, pss.Status
                            FROM  tbl_projects_site_setup pss INNER JOIN  tbl_projects ON pss.project_id = tbl_projects.id
				            INNER JOIN tbl_tender_names ON pss.tender_name_id = tbl_tender_names.id
                            INNER JOIN tbl_project_sites ps ON ps.id = pss.site_id
                            WHERE pss.id > 0 
                           ";

            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (cmbSiteSetup.Text != "" && !chkSiteSetup.Checked)
            {
                query += " and pss.id = @id";
                parameters.Add(DBClass.CreateParameter("id", cmbSiteSetup.SelectedValue.ToString()));
            }
            if (cmbZone.Text != "" && !chkZone.Checked)
            {
                query += " and pss.id IN (select site_setup_id from tbl_project_zone where id = @zoneId)";
                parameters.Add(DBClass.CreateParameter("zoneId", cmbZone.SelectedValue.ToString()));
            }
            if (!string.IsNullOrEmpty(txtProject.Text))
            {
                query += " AND tbl_projects.name LIKE @ProjectName";
                parameters.Add(DBClass.CreateParameter("@ProjectName", "%" + txtProject.Text.Trim() + "%"));
            }
            if (!string.IsNullOrEmpty(txtSite.Text))
            {
                query += " AND ps.name LIKE @siteName";
                parameters.Add(DBClass.CreateParameter("@siteName", "%" + txtSite.Text.Trim() + "%"));
            }
            if (!string.IsNullOrEmpty(txtTender.Text))
            {
                query += " AND tbl_tender_names.name LIKE @tenderName";
                parameters.Add(DBClass.CreateParameter("@tenderName", "%" + txtTender.Text.Trim() + "%"));
            }
            if (!string.IsNullOrEmpty(txtSupervisor.Text))
            {
                query += " AND pss.engineer_supervisor LIKE @Supervisor";
                parameters.Add(DBClass.CreateParameter("@Supervisor", "%" + txtSupervisor.Text.Trim() + "%"));
            }

            dt = DBClass.ExecuteDataTable(query, parameters.ToArray());
            dgView.DataSource = dt;
            dgView.Columns["Project Name"].MinimumWidth = 200;
            dgView.Columns["Project Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgView.Columns["Tender Name"].MinimumWidth = 200;
            dgView.Columns["Tender Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgView.Columns["id"].Visible = false;
            dgView.Columns["project_id"].Visible = false;
            dgView.Columns["tender_id"].Visible = false;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindInvoices();
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgView.Rows.Count == 0)
                return;

            frmLogin.frmMain.openChildForm(new frmViewProjectWBSActivity(
                int.Parse(dgView.CurrentRow.Cells["project_id"].Value.ToString()),
                int.Parse(dgView.CurrentRow.Cells["tender_id"].Value.ToString()),
                int.Parse(dgView.CurrentRow.Cells["id"].Value.ToString())
                ));
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
            if (chkSiteSetup.Checked)
                cmbSiteSetup.Enabled = false;
            else
                cmbSiteSetup.Enabled = true;
            BindInvoices();
        }
        private void chkPayment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkZone.Checked)
                cmbZone.Enabled = false;
            else
                cmbZone.Enabled = true;
            BindInvoices();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            BindInvoices();
        }
    }
}
