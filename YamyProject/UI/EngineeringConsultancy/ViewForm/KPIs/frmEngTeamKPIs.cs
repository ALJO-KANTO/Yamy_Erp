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

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.KPIs
{
    public partial class frmEngTeamKPIs : Form
    {
        public frmEngTeamKPIs()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngTeamKPIs_Load(object sender, EventArgs e)
        {
            btnSaveComment.Enabled = frmLogin.userRole.ToLower() == "manager" || frmLogin.userRole == "hr" || frmLogin.userRole == "admin";

            cmbMonth.Items.AddRange(System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames.Where(m => !string.IsNullOrEmpty(m)).ToArray());

            cmbMonth.SelectedIndex = DateTime.Now.Month - 1;
            numYear.Minimum = 2000;
            numYear.Maximum = 2100;
            numYear.Value = DateTime.Now.Year;

            LoadProjects();
            LoadTeamKPIs();
        }
        private void LoadProjects()
        {
            cmbProject.DataSource = DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_projects"
            );
            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";
        }

        private void btnSaveComment_Click(object sender, EventArgs e)
        {
            if (dgvTeamKPIs.CurrentRow == null) return;

            int resultId = Convert.ToInt32(
                dgvTeamKPIs.CurrentRow.Cells["result_id"].Value
            );

            DBClass.ExecuteNonQuery(
                @"INSERT INTO tbl_kpi_comments
                  (result_id, commented_by, comment, commented_at)
                  VALUES (@rId,@uId,@comment,NOW())",
                DBClass.CreateParameter("@rId", resultId),
                DBClass.CreateParameter("@uId", frmLogin.userId),
                DBClass.CreateParameter("@comment", txtComment.Text)
            );

            MessageBox.Show("Comment saved successfully");
            txtComment.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTeamKPIs();
        }
        private void LoadTeamKPIs()
        {
            int month = cmbMonth.SelectedIndex + 1;
            int year = (int)numYear.Value;

            dgvTeamKPIs.DataSource = DBClass.ExecuteDataTable(
                @"SELECT 
                      r.result_id,e.name AS Engineer,
                      ROUND(SUM(r.score * k.weight) / NULLIF(SUM(k.weight),0),2) AS KPI_Score
                  FROM tbl_kpi_results r
                  JOIN tbl_kpi_master k ON k.kpi_id=r.kpi_id
                  JOIN tbl_employee e ON e.id=r.employee_id
                  WHERE r.period_month=@m
                    AND r.period_year=@y
                  GROUP BY e.id, e.name, r.result_id
                  ORDER BY KPI_Score DESC",
                DBClass.CreateParameter("@m", month),
                DBClass.CreateParameter("@y", year)
            );
            dgvTeamKPIs.Columns["result_id"].Visible = false;

            LocalizationManager.LocalizeDataGridViewHeaders(dgvTeamKPIs);
            LoadRanking();
        }
        private void LoadRanking()
        {
            dgvRanking.DataSource = dgvTeamKPIs.DataSource;
            dgvRanking.Columns["result_id"].Visible = false;
            LocalizationManager.LocalizeDataGridViewHeaders(dgvRanking);
        }

    }
}
