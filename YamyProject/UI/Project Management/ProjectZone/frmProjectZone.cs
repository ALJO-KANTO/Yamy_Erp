using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class frmProjectZone : Form
    {
      
        private int id;
        frmViewProjectPlanning master;

        public frmProjectZone(frmViewProjectPlanning _master, int id=0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);

            this.id = id;
            this.master = _master;
            if (id == 0)
                this.Text = id == 0 ? "New Zone" : "Edit Zone";
            headerUC1.FormText = this.Text;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtZoneName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Name First");
                return;
            }

            MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_project_zone where zone_name = @name",
            DBClass.CreateParameter("name", txtZoneName.Text));
            if (reader.Read())
            {
                if (id == 0 || (id != int.Parse(reader["id"].ToString())))
                {
                    MessageBox.Show(" Name Already In Use. Enter Another Name.");
                    return;
                }
            }


            if (id == 0)
            {
                object result = DBClass.ExecuteScalar("SELECT LPAD(MAX(CAST(zone_code AS UNSIGNED)), 3, '0') FROM tbl_project_zone;");
                int nextId = (result == DBNull.Value || result == null) ? 1 : Convert.ToInt32(result) + 1;
                string formattedId = nextId.ToString().PadLeft(3, '0');
                txtZoneCode.Text = formattedId;
                int refId = DBClass.ExecuteNonQuery(@"INSERT INTO tbl_project_zone (zone_code, zone_name,site_setup_id,created_by,description) VALUES (@code, @name,@siteId,@created_by,@description);",
                            DBClass.CreateParameter("code", formattedId),
                            DBClass.CreateParameter("name", txtZoneName.Text),
                            DBClass.CreateParameter("siteId", cmbProjectSites.SelectedValue.ToString()),
                            DBClass.CreateParameter("created_by", frmLogin.userId),
                            DBClass.CreateParameter("description", txtDescription.Text));
                if (refId != 0)
                {
                    Utilities.LogAudit(frmLogin.userId, "Add Project Zone", "Project Zone", refId, "Added Project Zone: " + txtZoneName.Text);
                }
                else
                {
                    string message = Utilities.LastLogError();
                    MessageBox.Show("Error Check your data" + message);
                }
            }
            else
            {
                DBClass.ExecuteNonQuery(@"UPDATE tbl_project_zone SET zone_name = @name, site_setup_id = @siteId, description = @description WHERE id = @id;",
                            DBClass.CreateParameter("name", txtZoneName.Text),
                            DBClass.CreateParameter("siteId", cmbProjectSites.SelectedValue),
                            DBClass.CreateParameter("description", txtDescription.Text),
                        DBClass.CreateParameter("id", id));
                Utilities.LogAudit(frmLogin.userId, "Update Project Zone", "Project Zone", id, "Updated Project Zone: " + txtZoneName.Text);
            }
            if (master != null)
            {
                master.BindCombo();
            }
            else
            {
                EventHub.RefreshProject();
            }
            this.Close();
        }

        private void frmProjectZone_Load(object sender, EventArgs e)
        {
            BindCombo();

            if (id != 0)
            {
                MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_project_zone where id = @id",
                      DBClass.CreateParameter("id", id));
                if (reader.Read())
                {
                    txtZoneName.Text = reader["zone_name"].ToString();
                    txtZoneCode.Text = reader["zone_code"].ToString();
                    cmbProjectSites.SelectedValue = reader["site_setup_id"].ToString();
                    txtDescription.Text = reader["description"].ToString();
                }
            }

        }
        public void BindCombo()
        {
            cmbProjectSites.DataSource = DBClass.ExecuteDataTable("select pss.id,concat(pss.id,' - ',p.name) name from tbl_projects_site_setup pss INNER JOIN tbl_project_sites p ON p.id = pss.site_id");
            cmbProjectSites.DisplayMember = "name";
            cmbProjectSites.ValueMember = "id";
        }
    }
}
