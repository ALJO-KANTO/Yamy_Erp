using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class MasterProjectDailySiteWork : Form
    {
        public MasterProjectDailySiteWork()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MasterDailySiteWork_Load(object sender, EventArgs e)
        {
            ProjectSiteData();
        }
        public void ProjectSiteData()
        {
            DataTable dT = DBClass.ExecuteDataTable(@"SELECT ROW_NUMBER() OVER (ORDER BY pdw.id) AS SN, pdw.id, pdw.work_date Date,p.name Project,ps.name Site,boq.name Name, pdw.today_qty `Today Qty`, pdw.cumulative_qty `Cum Qty`,pdw.Progress FROM tbl_project_daily_work pdw INNER JOIN tbl_items_boq boq ON boq.id = pdw.boq_item_id INNER JOIN tbl_projects p ON p.id = pdw.project_id INNER JOIN tbl_project_sites ps ON ps.id=pdw.site_id");
            dgvCustomer.DataSource = dT;
            dgvCustomer.Columns["id"].Visible = false;
            dgvCustomer.Columns["SN"].Width = 50;
            dgvCustomer.Columns["Date"].Width = 50;
            dgvCustomer.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.Columns["Project"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.Columns["Site"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //if (dgvCustomer.Rows.Count > 0)
            //{
            //    btnRemove.Enabled = UserPermissions.canDelete("Project Center");
            //}
            LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;

            var confirmResult = MessageBox.Show("Are you sure to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;

            DBClass.ExecuteNonQuery("DELETE FROM tbl_project_daily_work WHERE id=@id", DBClass.CreateParameter("id", int.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString())));
            MessageBox.Show("Deleted");
            ProjectSiteData();
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
                return;

            //new frmProjectSites(null, int.Parse(dgvCustomer.CurrentRow.Cells["id"].Value.ToString())).ShowDialog();
        }
    }
}
