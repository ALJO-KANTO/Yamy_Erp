using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.KPIDashboard
{
    public partial class KPIControl : Form
    {
        public KPIControl()
        {
            InitializeComponent();
        }

        private void KPIControl_Load(object sender, EventArgs e)
        {

            LoadKPIs();
        }
        private void LoadKPIs()
        {
            // Replace with DB logic
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("KPI Code");
            dt.Columns.Add("KPI Name");
            dt.Columns.Add("Category");
            dt.Columns.Add("Target");
            dt.Columns.Add("Actual");
            dt.Columns.Add("Score (%)");

            //dt.Rows.Add("PRJ-01", "Project Completion", "Project", 100, 92, 92);
            //dt.Rows.Add("FIN-01", "Gross Margin", "Finance", 30, 27, 90);
            //dt.Rows.Add("MNT-01", "Maintenance Response Time", "Maintenance", 2, 2.4, 83);
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT * FROM tbl_kpi_master"))
            {
                while (reader.Read())
                {
                    decimal score = 0;
                    decimal actual = Convert.ToDecimal(reader["weight"]);
                    decimal target = Convert.ToDecimal(reader["target_value"]);

                    score = actual< target ? ((actual / target) * 100) : ((target / actual) * 100);
                    dt.Rows.Add(reader["kpi_id"], reader["kpi_code"], reader["kpi_name"], reader["kpi_category"], reader["target_value"], reader["weight"], score.ToString("N2"));
                }
            }
            dgvKPI.DataSource = dt;

            dgvKPI.Columns["Id"].Visible = false;
        }

        private void btnAddKPI_Click(object sender, EventArgs e)
        {
            KPIEntryForm frm = new KPIEntryForm();
            frm.ShowDialog();
            LoadKPIs();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            KPIDashboardForm frm = new KPIDashboardForm();
            frm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadKPIs();
        }

        private void dgvKPI_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                int kpiCode = Convert.ToInt32(dgvKPI.Rows[e.RowIndex].Cells["Id"].Value);
                KPIEntryForm frm = new KPIEntryForm(kpiCode);
                frm.ShowDialog();
                LoadKPIs();
            }
        }
    }
}
