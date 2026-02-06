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
    public partial class frmEngKPIs : Form
    {
        public frmEngKPIs()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngKPIs_Load(object sender, EventArgs e)
        {
            cmbProject.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_projects ORDER BY name");
            cmbProject.DisplayMember = "name";
            cmbProject.ValueMember = "id";
            cmbProject.SelectedIndex = -1;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadKPIs();
        }

        private void LoadKPIs()
        {
            if (cmbProject.SelectedIndex == -1) return;

            // Example KPI calculation: Engineer productivity, Phase completion, Financial margin
            dgvKPIs.DataSource = DBClass.ExecuteDataTable(
                @"SELECT 
                    e.name AS Engineer,
                    IFNULL(SUM(t.hours),0) AS TotalHours,
                    IFNULL(SUM(CASE WHEN t.is_billable=1 THEN t.hours ELSE 0 END),0) AS BillableHours,
                    IFNULL(SUM(p.weight_percentage),0) AS ProjectProgress,
                    IFNULL(SUM(rc.recognized_amount),0) AS RecognizedRevenue,
                    IFNULL(SUM(c.actual_cost),0) AS ActualCost,
                    (IFNULL(SUM(rc.recognized_amount),0) - IFNULL(SUM(c.actual_cost),0)) AS Profit,
                    CASE WHEN IFNULL(SUM(rc.recognized_amount),0)=0 THEN 0 ELSE
                        (IFNULL(SUM(rc.recognized_amount),0) - IFNULL(SUM(c.actual_cost),0)) / IFNULL(SUM(rc.recognized_amount),0) * 100 END AS MarginPercent
                FROM tbl_eng_timesheets t
                JOIN tbl_employee e ON e.id = t.employee_id
                LEFT JOIN tbl_eng_project_phases p ON p.phase_id = t.phase_id
                LEFT JOIN tbl_eng_project_costing c ON c.project_id = t.project_id
                LEFT JOIN tbl_eng_project_revenue rc 
                    ON rc.project_id = t.project_id
                    -- AND (@ph IS NULL OR rc.phase_id = @ph)
                WHERE t.project_id = @pid
                GROUP BY e.name",
                DBClass.CreateParameter("@pid", cmbProject.SelectedValue)
            );

            LocalizationManager.LocalizeDataGridViewHeaders(dgvKPIs);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
