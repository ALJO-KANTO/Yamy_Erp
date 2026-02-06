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
    public partial class frmEngKPIHistory : Form
    {
        public frmEngKPIHistory()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngKPIHistory_Load(object sender, EventArgs e)
        {
            numYear.Minimum = 2000;
            numYear.Maximum = 2100;
            numYear.Value = DateTime.Now.Year;
            LoadEmployees();
            LoadHistory();
        }
        private void LoadEmployees()
        {
            DataTable dt = DBClass.ExecuteDataTable(
                @"SELECT id, name 
              FROM tbl_employee 
              WHERE sRole IN ('Engineer','Manager')"
            );

            cmbEmployee.DataSource = dt;
            cmbEmployee.DisplayMember = "name";
            cmbEmployee.ValueMember = "id";
            
            if (frmLogin.userRole == "Employee")
            {
                cmbEmployee.SelectedValue = frmLogin.userId;
                cmbEmployee.Enabled = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadHistory();
        }
        private void LoadHistory()
        {
            dgvKPIHistory.DataSource = DBClass.ExecuteDataTable(
                @"SELECT 
                    r.period_month AS Month,
                    k.kpi_name,
                    r.actual_value,
                    r.score,
                    r.calculated_at
                  FROM tbl_kpi_results r
                  JOIN tbl_kpi_master k ON k.kpi_id=r.kpi_id
                  WHERE r.employee_id=@eid
                    AND r.period_year=@y
                  ORDER BY r.period_month",
                DBClass.CreateParameter("@eid", cmbEmployee.SelectedValue),
                DBClass.CreateParameter("@y", numYear.Value)
            );

            LocalizationManager.LocalizeDataGridViewHeaders(dgvKPIHistory);
        }

        private void dgvKPIHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int resultId = Convert.ToInt32(
                dgvKPIHistory.Rows[e.RowIndex].Cells["result_id"].Value
            );

            dgvKPIComments.DataSource = DBClass.ExecuteDataTable(
                @"SELECT 
                    c.comment,
                    e.employee_name AS CommentedBy,
                    c.commented_at
                  FROM tbl_kpi_comments c
                  JOIN tbl_employee e ON e.id=c.commented_by
                  WHERE c.result_id=@rid
                  ORDER BY c.commented_at DESC",
                DBClass.CreateParameter("@rid", resultId)
            );

            LocalizationManager.LocalizeDataGridViewHeaders(dgvKPIComments);
        }
    }
}
