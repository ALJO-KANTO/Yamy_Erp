using Microsoft.Vbe.Interop;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Data;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace YamyProject.UI.Project_Management.DailySiteExcecution
{
    public partial class frmSiteDiaryList : Form
    {
        public frmSiteDiaryList()
        {
            InitializeComponent();
        }

        private void frmSiteDiaryList_Load(object sender, EventArgs e)
        {

            dtFrom.Value = DateTime.Today.AddMonths(-1);
            dtTo.Value = DateTime.Today;
            dgvDiary.AutoGenerateColumns = false;
            dgvDiary.Columns.Clear();

            dgvDiary.Columns.Add("diary_id", "ID");
            dgvDiary.Columns.Add("diary_no", "Diary No");
            dgvDiary.Columns.Add("diary_date", "Date");
            dgvDiary.Columns.Add("project", "Project");
            dgvDiary.Columns.Add("site", "Site");
            dgvDiary.Columns.Add("engineer", "Engineer");
            dgvDiary.Columns.Add("status", "Status");

            LoadGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = @"
                SELECT
                    d.diary_id,
                    d.diary_no,
                    d.diary_date,
                    p.name project,
                    s.name site,
                    e.name engineer,
                    d.status
                FROM tbl_site_diary d
                LEFT JOIN tbl_projects p
                ON p.id=d.project_id
                LEFT JOIN tbl_project_sites s
                ON s.id=d.site_id
                LEFT JOIN tbl_employee e
                ON e.id=d.engineer_id
                WHERE d.diary_no LIKE @search
                ";

            dgvDiary.DataSource = DBClass.ExecuteDataTable(sql, DBClass.CreateParameter("@search", "%" + txtSearch.Text + "%"));

        }
        private void dgvDiary_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            int id = Convert.ToInt32(dgvDiary.Rows[e.RowIndex].Cells["diary_id"].Value);

            frmSiteDiary frm = new frmSiteDiary();
            frm.Show();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmSiteDiary frm = new frmSiteDiary();
            frm.Show();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDiary.CurrentRow == null)
                return;

            int id = Convert.ToInt32(dgvDiary.CurrentRow.Cells["diary_id"].Value);
            DBClass.ExecuteNonQuery(@"DELETE FROM tbl_site_diary WHERE diary_id=@id", DBClass.CreateParameter("@id", id));

            LoadGrid();
        }

        private void LoadGrid()
        {
            string sql = @"
                SELECT
                    d.diary_id,
                    d.diary_no,
                    d.diary_date,
                    p.name project,
                    s.name site,
                    e.name engineer,
                    d.status
                FROM tbl_site_diary d
                LEFT JOIN tbl_projects p
                ON p.id=d.project_id
                LEFT JOIN tbl_project_sites s
                ON s.id=d.site_id
                LEFT JOIN tbl_employee e
                ON e.id=d.engineer_id
                WHERE d.diary_no LIKE @search
                ";

            dgvDiary.DataSource = DBClass.ExecuteDataTable(sql, DBClass.CreateParameter("@search", "%" + txtSearch.Text + "%"));

        }
    }
}
