using DlhSoft.ProjectDataControlLibrary;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class frmViewProjectSiteSetup : Form
    {
        decimal invId;
        int id, tenderId, tenderNameId;
        public frmViewProjectSiteSetup(int id)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            this.id = id;
            headerUC1.FormText = this.Text;
        }
        int AccountCashId = 0;
        private void frmViewProjectSites_Load(object sender, EventArgs e)
        {
            dtInv.Value = dtp_start.Value = dtp_end.Value = DateTime.Now.Date;

            BindCombos.PopulateVendors(cmbSubcontractor, false, false, "Subcontractor");

            BindCombo();

            if (id != 0)
            {
                BindData();
            }

        }
        public void BindCombo()
        {
            BindCombos.PopulateTenderedProjects(cmbProjectName);
            BindCombos.PopulateTenderNames(cmbTenderName);
            BindCombos.populateSites(cmbProjectSite);
        }
        private void BindData()
        {
            MySqlDataReader reader = DBClass.ExecuteReader(" select * from tbl_projects_site_setup where id = @id",
                DBClass.CreateParameter("id", id));
            if (reader.Read())
            {
                invId = id;
                dtInv.Value = DateTime.Parse(reader["date"].ToString());
                cmbProjectName.SelectedValue = int.Parse(reader["project_id"].ToString());
                cmbProjectSite.SelectedValue = int.Parse(reader["site_id"].ToString());
                cmbProjectStatus.Text = reader["status"].ToString();
                dtp_start.Value = reader["start_date"] != null ? DateTime.Parse(reader["start_date"].ToString()) : DateTime.Now.Date;
                dtp_end.Value = reader["end_date"] != null ? DateTime.Parse(reader["end_date"].ToString()) : DateTime.Now.Date;
                cmbSubcontractor.SelectedValue = int.Parse(reader["subcontractor_id"].ToString());
                txtZone.Text = reader["engineer_supervisor"].ToString();
                tenderId = int.Parse(reader["tender_id"].ToString());
                cmbTenderName.SelectedValue = int.Parse(reader["tender_name_id"].ToString());

                LoaddgvItems();
            }
        }
        public void LoaddgvItems()
        {
            dgvResource.Rows.Clear();
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT pr.id, pr.code, date, pr.name,r.name as roleName, phone, type, price_unit, unit_time, max_unit_time FROM tbl_project_resource pr, tbl_project_role r where r.id = pr.role"))
            {
                int count = 1;
                while (reader.Read())
                {
                    dgvResource.Rows.Add(count, reader["id"], reader["name"]);
                    count++;
                }
                SelectedResourceData();
            }
        }

        private void SelectedResourceData()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader(@"SELECT id FROM tbl_project_resource WHERE id IN (SELECT resource_id FROM tbl_project_resource_assignment WHERE site_setup_id = @sId);",
                DBClass.CreateParameter("sId", id)))
            {
                while (reader.Read())
                {
                    foreach (DataGridViewRow dr in dgvResource.Rows)
                    {
                        if (dr.Cells["ResourceId"].Value.ToString() == reader["id"].ToString())
                        {
                            dr.Cells["select"].Value = true;
                        }
                    }
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                if (insertData())
                {
                    MessageBox.Show("Site Setup Saved");
                }
            }
            else
            {
                if (updateData())
                {
                    MessageBox.Show("Site Setup Updated");
                }
            }
        }
        
        private bool updateData()
        {
            if (!chkRequiredDate())
                return false;

            DBClass.ExecuteNonQuery(@"UPDATE tbl_projects_site_setup SET modified_by = @modifiedBy, date=@date,project_id=@projectId, site_id=@site,tender_id=@tenderId, tender_name_id=@tender_name_id, start_date=@startDate, end_date=@endDate, subcontractor_id=@subcontractor_id, status=@status, engineer_supervisor=@engineer_supervisor WHERE id = @id;",
                DBClass.CreateParameter("id", id),
                DBClass.CreateParameter("date", dtInv.Value.Date),
                DBClass.CreateParameter("projectId", cmbProjectName.SelectedValue.ToString()),
                DBClass.CreateParameter("site", cmbProjectSite.SelectedValue.ToString()),
                DBClass.CreateParameter("tenderId", tenderId.ToString()),
                DBClass.CreateParameter("tender_name_id", cmbTenderName.SelectedValue),
                DBClass.CreateParameter("startDate", DateTime.Now.Date),
                DBClass.CreateParameter("endDate", DateTime.Now.Date),
                DBClass.CreateParameter("subcontractor_id", cmbSubcontractor.SelectedValue.ToString()),
                DBClass.CreateParameter("status", cmbProjectStatus.SelectedItem.ToString()),
                DBClass.CreateParameter("engineer_supervisor", txtZone.Text),
                DBClass.CreateParameter("@modifiedBy", frmLogin.userId)
            );
            UpdateResourceData(id);
            UpdateSiteZone(id);

            Utilities.LogAudit(frmLogin.userId, "Update Project Site Setup", "Project Site Setup", id, "Updated Project Site Setup: " + cmbProjectName.Text + " Tender Name: " + cmbTenderName.Text);
            return true;
        }
        private bool insertData()
        {
            if (!chkRequiredDate())
                return false;

            invId = decimal.Parse(DBClass.ExecuteScalar(@"INSERT INTO tbl_projects_site_setup(date,project_id, site_id,tender_id, tender_name_id, start_date, end_date, subcontractor_id, status, engineer_supervisor, created_by) 
                        VALUES (@date,@projectId, @site,@tenderId, @tender_name_id, @startDate, @endDate, @subcontractor_id, @status,@engineer_supervisor, @created_by);SELECT LAST_INSERT_ID();",
                                DBClass.CreateParameter("date", dtInv.Value.Date),
                                DBClass.CreateParameter("projectId", cmbProjectName.SelectedValue.ToString()),
                                DBClass.CreateParameter("site", cmbProjectSite.SelectedValue.ToString()),
                                DBClass.CreateParameter("tenderId", tenderId.ToString()),
                                DBClass.CreateParameter("tender_name_id", cmbTenderName.SelectedValue),
                                DBClass.CreateParameter("startDate", DateTime.Now.Date),
                                DBClass.CreateParameter("endDate", DateTime.Now.Date),
                                DBClass.CreateParameter("subcontractor_id", cmbSubcontractor.SelectedValue.ToString()),
                                DBClass.CreateParameter("status", cmbProjectStatus.SelectedItem.ToString()),
                                DBClass.CreateParameter("engineer_supervisor", txtZone.Text),
                                DBClass.CreateParameter("created_by", frmLogin.userId)
            ).ToString());

            int sId = (int)decimal.Parse(invId.ToString());
            UpdateResourceData(sId);
            UpdateSiteZone(sId);

            Utilities.LogAudit(frmLogin.userId, "Create Project Site Setup", "Project Site Setup", id, "Created Project Site Setup: " + cmbProjectName.Text + " Tender Name: " + cmbTenderName.Text);

            return true;
        }

        private bool chkRequiredDate()
        {
            if (!string.IsNullOrEmpty(cmbProjectName.SelectedText.ToString()))
            {
                MessageBox.Show("Select Project First.");
                return false;
            }
            if (tenderId<=0)
            {
                MessageBox.Show("Tender is not initiated for this project");
                return false;
            }
            if (cmbTenderName.SelectedValue==null)
            {
                MessageBox.Show("Select Tender Name First.");
                return false;
            }
            if (cmbProjectSite.SelectedValue == null)
            {
                MessageBox.Show("Select Site Name First.");
                return false;
            }
            if (cmbSubcontractor.SelectedValue == null)
            {
                MessageBox.Show("Select Subcontractor First.");
                return false;
            }

            return true;
        }
        private void resetTextBox()
        {

            txtZone.Text = "";
            id = 0;
            dtInv.Value = DateTime.Now;
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                if (insertData())
                    resetTextBox();
            }
            else
            {
                if (updateData())
                    resetTextBox();
            }
        }
        private bool UpdateResourceData(int siteId)
        {
            bool isSaved = false;
            DBClass.ExecuteNonQuery("Delete from tbl_project_resource_assignment where site_setup_id = @id", DBClass.CreateParameter("id", siteId));
            foreach (DataGridViewRow row in dgvResource.Rows)
            {
                if (Convert.ToBoolean(row.Cells["select"].Value))
                {
                    string ResourceId = row.Cells["ResourceId"].Value.ToString();
                    DBClass.ExecuteNonQuery(@"insert into tbl_project_resource_assignment(site_setup_id,resource_id,project_id,tender_id) Values(@site,@resource,@project,@tender)",
                    DBClass.CreateParameter("site", siteId),
                    DBClass.CreateParameter("resource", ResourceId),
                    DBClass.CreateParameter("project", cmbProjectName.SelectedValue),
                    DBClass.CreateParameter("tender", cmbTenderName.SelectedValue));

                    isSaved = true;
                }
            }
            
            if (isSaved)
                Utilities.LogAudit(frmLogin.userId, (id == 0 ? "Add Project Resource" : "Update Project Resource"), "Project Resource", id, (id == 0 ? "Added Project Resource: " : "Updated Project Resource: "));

            return true;
        }

        private void UpdateSiteZone(int siteId)
        {
            if (txtZone.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Name First");
                return;
            }

            MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_project_zone where zone_name = @name",
            DBClass.CreateParameter("name", txtZone.Text));
            if (reader.Read())
            {
                DBClass.ExecuteNonQuery(@"UPDATE tbl_project_zone SET zone_name = @name WHERE id = @id and site_setup_id = @siteId;",
                            DBClass.CreateParameter("name", txtZone.Text),
                            DBClass.CreateParameter("siteId", siteId),
                        DBClass.CreateParameter("id", id));
                Utilities.LogAudit(frmLogin.userId, "Update Project Zone", "Project Zone", id, "Updated Project Zone: " + txtZone.Text);
                
            }
            else
            {
                object result = DBClass.ExecuteScalar("SELECT LPAD(MAX(CAST(zone_code AS UNSIGNED)), 3, '0') FROM tbl_project_zone;");
                int nextId = (result == DBNull.Value || result == null) ? 1 : Convert.ToInt32(result) + 1;
                string formattedId = nextId.ToString().PadLeft(3, '0');
                int refId = DBClass.ExecuteNonQuery(@"INSERT INTO tbl_project_zone (zone_code, zone_name,site_setup_id,created_by,description) VALUES (@code, @name,@siteId,@created_by,@description);",
                            DBClass.CreateParameter("code", formattedId),
                            DBClass.CreateParameter("name", txtZone.Text),
                            DBClass.CreateParameter("siteId", siteId),
                            DBClass.CreateParameter("created_by", frmLogin.userId),
                            DBClass.CreateParameter("description", ""));
                if (refId != 0)
                {
                    Utilities.LogAudit(frmLogin.userId, "Add Project Zone", "Project Zone", refId, "Added Project Zone: " + txtZone.Text);
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTenderName_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlDataReader reader = DBClass.ExecuteReader(" select * from tbl_project_tender WHERE project_id=@pId AND tender_name_id=@tId",
                DBClass.CreateParameter("pId", cmbProjectName.SelectedValue),
                DBClass.CreateParameter("tId", cmbTenderName.SelectedValue));
            if (reader.Read())
            {
                string checkQuery = "SELECT COUNT(*) from tbl_project_tender WHERE project_id=@pId AND tender_name_id=@tId";
                int count = Convert.ToInt32(DBClass.ExecuteScalar(checkQuery,
                    DBClass.CreateParameter("pId", cmbProjectName.SelectedValue),
                DBClass.CreateParameter("tId", cmbTenderName.SelectedValue)));
                if (count == 1) {
                    tenderId = int.Parse(reader["id"].ToString());
                }
            }
        }

        private void btnAddTender_Click(object sender, EventArgs e)
        {
            new frmProjectSites(null, 0).ShowDialog();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgvResource_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnShowTenderList_Click(object sender, EventArgs e)
        {
            frmViewSelectTender selectTenderForm = new frmViewSelectTender(int.Parse(cmbTenderName.SelectedValue.ToString()),int.Parse(cmbProjectName.SelectedValue.ToString()));
            if (selectTenderForm.ShowDialog() == DialogResult.OK)
            {
                int selectedTenderId = selectTenderForm.SelectedTenderId;
                tenderId = selectedTenderId;
            }
        }

        private void cmbProjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProjectName.Focused)
            {
                using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT start_date,end_date FROM tbl_projects WHERE id = @id", DBClass.CreateParameter("@id", cmbProjectName.SelectedValue)))
                {
                    if (reader.Read())
                    {
                        if (reader["start_date"] != null)
                        {
                            dtp_start.Value = Convert.ToDateTime(reader["start_date"]);
                        }

                        if (reader["end_date"] != null)
                        {
                            dtp_end.Value = Convert.ToDateTime(reader["end_date"]);
                        }
                    }
                }
            }
        }
    }
}
