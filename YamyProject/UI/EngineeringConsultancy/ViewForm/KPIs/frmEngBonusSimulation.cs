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
using YamyProject.UI.EngineeringConsultancy.ViewForm.Timesheet_Resources;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.KPIs
{
    public partial class frmEngBonusSimulation : Form
    {
        public frmEngBonusSimulation()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngBonusSimulation_Load(object sender, EventArgs e)
        {
            numYear.Minimum = 2000;
            numYear.Maximum = 2100;
            numYear.Value = DateTime.Now.Year;

            cmbMonth.Items.AddRange(System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames.Where(m => !string.IsNullOrEmpty(m)).ToArray());

            cmbMonth.SelectedIndex = DateTime.Now.Month - 1;

            numBasePercent.Value = 10; // default 10%
        }

        private void btnSimulate_Click(object sender, EventArgs e)
        {
            int month = cmbMonth.SelectedIndex + 1;
            int year = (int)numYear.Value;
            decimal basePercent = numBasePercent.Value;

            dgvBonusSim.DataSource = DBClass.ExecuteDataTable(
                @"SELECT 
            e.name AS Employee,
            ROUND(AVG(r.score),2) AS KPI_Score,
            ROUND(
                (AVG(r.score) / 100) * @bp, 
            2) AS BonusPercent
          FROM tbl_kpi_results r
          JOIN tbl_employee e ON e.id=r.employee_id
          WHERE r.period_month=@m
            AND r.period_year=@y
          GROUP BY e.id, e.name
          ORDER BY KPI_Score DESC",
                DBClass.CreateParameter("@m", month),
                DBClass.CreateParameter("@y", year),
                DBClass.CreateParameter("@bp", basePercent)
            );

            LocalizationManager.LocalizeDataGridViewHeaders(dgvBonusSim);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            CommonExport.ExportToExcel((DataTable)dgvBonusSim.DataSource, "Bonus_Simulation");
        }
    }
}
