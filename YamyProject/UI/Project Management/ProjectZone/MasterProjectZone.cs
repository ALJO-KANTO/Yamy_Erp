using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class MasterProjectZone : Form
    {
        private EventHandler projectUpdatedHandler;

        public MasterProjectZone()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            projectUpdatedHandler  = (sender, args) => ProjectSiteData();
            EventHub.Project += projectUpdatedHandler;
            headerUC1.FormText = this.Text;
        }
        private void MasterProjectZone_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.Project -= projectUpdatedHandler;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmProjectZone(null, 0).ShowDialog();
        }
        private void MasterProjectZone_Load(object sender, EventArgs e)
        {
            ProjectSiteData();
        }
        public void ProjectSiteData()
        {
            DataTable dT = DBClass.ExecuteDataTable(@"SELECT ROW_NUMBER() OVER (ORDER BY pz.id) AS SN, pz.id, pz.zone_code Code, pz.zone_name Name,description Description,status Status FROM tbl_project_zone pz LEFT JOIN tbl_project_sites ps ON ps.id = pz.site_setup_id;");
            dgvCustomer.DataSource = dT;
            dgvCustomer.Columns["id"].Visible = false;
            dgvCustomer.Columns["SN"].Width = 50;
            dgvCustomer.Columns["code"].Width = 100;
            dgvCustomer.Columns["Name"].MinimumWidth = 200;
            dgvCustomer.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;

            object result = DBClass.ExecuteScalar(@"SELECT COUNT(1) FROM tbl_project_activity_plan 
                  WHERE zone_id = @id", DBClass.CreateParameter("id", int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
            int recordCount = 0;
            if (result != null && result != DBNull.Value)
                recordCount = Convert.ToInt32(result);
            if (recordCount > 0)
            {
                MessageBox.Show("Already used");
                return;
            }
            DBClass.ExecuteNonQuery("DELETE FROM tbl_project_zone WHERE id=@id", DBClass.CreateParameter("id", int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
            MessageBox.Show("Deleted");
            ProjectSiteData();
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;

            new frmProjectZone(null, int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())).ShowDialog();
        }
    }
}
