using DocumentFormat.OpenXml.Bibliography;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.Labor
{
    public partial class LaborControl : Form
    {
        public LaborControl()
        {
            InitializeComponent();
        }

        private void LaborControl_Load(object sender, EventArgs e)
        {
            LoadLaborData();
        }

        private void LoadLaborData()
        {
            // Replace with DB integration
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Employee");
            dt.Columns.Add("Role");
            dt.Columns.Add("Project");
            dt.Columns.Add("Daily Rate");
            dt.Columns.Add("Hours Worked");
            dt.Columns.Add("Labor Cost");
            dt.Columns.Add("Productivity");

            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT l.id, e.name employee,po.name role, p.name project, l.daily_rate, l.hours_worked, l.labor_cost, l.productivity FROM tbl_labor_assignments l INNER JOIN tbl_employee e ON e.id = l.employee_id INNER JOIN tbl_projects p ON p.id = l.project_id INNER JOIN tbl_position po ON po.id = e.Position_id"))
            {
                while (reader.Read())
                {
                    dt.Rows.Add(
                        reader["id"],
                        reader["employee"],
                        reader["role"],
                        reader["project"],
                        Convert.ToDecimal(reader["daily_rate"]).ToString("N2"),
                        Convert.ToDecimal(reader["hours_worked"]).ToString("N2"),
                        Convert.ToDecimal(reader["labor_cost"]).ToString("N2"),
                        (Convert.ToDecimal(reader["productivity"]).ToString("N2"))+"%"
                        );
                    //dt.Rows.Add("Ahmed", "Electrician", "Tower Project", 150, 8, 150, "100%");
                    //dt.Rows.Add("Khalid", "Technician", "Mall Renovation", 120, 10, 150, "120%");
                    //dt.Rows.Add("Team A", "Civil Crew", "Warehouse", 600, 7, 525, "87%");
                }
            }
            dgvLabor.DataSource = dt;

            dgvLabor.Columns["Id"].Visible = false;
            dgvLabor.Columns["Role"].Visible = false;
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            LaborAssignmentForm frm = new LaborAssignmentForm();
            frm.ShowDialog();
            LoadLaborData();
        }

        private void btnUpdateHours_Click(object sender, EventArgs e)
        {
            if (dgvLabor.SelectedRows.Count == 0) return;

            string TextValue = Interaction.InputBox(
                "Enter Working Hours:",
                "Confirm Worked Hours",
                ""
            );

            // Close or empty → do nothing
            if (string.IsNullOrWhiteSpace(TextValue))
                return;

            decimal workedHours = 0;
            decimal.TryParse(TextValue, out workedHours);
            decimal dailyRate = Convert.ToDecimal(dgvLabor.SelectedRows[0].Cells["Daily Rate"].Value ?? "0");
            decimal laborCost = dailyRate * workedHours;

            DBClass.ExecuteNonQuery("UPDATE tbl_labor_assignments SET hours_worked = @HoursWorked, labor_cost = @laborCost WHERE id = @Id",
                DBClass.CreateParameter("@HoursWorked", workedHours),
                DBClass.CreateParameter("@laborCost", laborCost),
                DBClass.CreateParameter("@Id", Convert.ToInt32(dgvLabor.SelectedRows[0].Cells["Id"].Value))
            );
            MessageBox.Show("Working hours updated.");

            LoadLaborData();
        }

        private void btnProductivity_Click(object sender, EventArgs e)
        {
            if (dgvLabor.SelectedRows.Count == 0) return;

            decimal hoursWorked = Convert.ToDecimal(dgvLabor.SelectedRows[0].Cells["Hours Worked"].Value ?? "0");
            decimal dailyRate = Convert.ToDecimal(dgvLabor.SelectedRows[0].Cells["Daily Rate"].Value ?? "0");
            decimal laborCost = Convert.ToDecimal(dgvLabor.SelectedRows[0].Cells["Labor Cost"].Value ?? "0");

            // calculate productivity
            decimal expectedCost = dailyRate * hoursWorked;

            decimal productivity = laborCost == 0
                ? 0
                : (expectedCost / laborCost) * 100;

            DBClass.ExecuteNonQuery("UPDATE tbl_labor_assignments SET productivity = @productivity WHERE id = @id",
                DBClass.CreateParameter("@productivity", productivity),
                DBClass.CreateParameter("@Id", Convert.ToInt32(dgvLabor.SelectedRows[0].Cells["Id"].Value))
            );

            MessageBox.Show("Productivity analysis calculated.");

            LoadLaborData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLaborData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLabor_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int eId = Convert.ToInt32(dgvLabor.Rows[e.RowIndex].Cells["Id"].Value);
            LaborAssignmentForm frm = new LaborAssignmentForm(eId);
            frm.ShowDialog();
            LoadLaborData();
        }
    }
}
