using System;
using System.Data;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.HRPayroll
{
    public partial class HRPayrollControl : Form
    {
        public HRPayrollControl()
        {
            InitializeComponent();
        }

        private void HRPayrollControl_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            // Replace with DB integration
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Position");
            dt.Columns.Add("Basic Salary");
            dt.Columns.Add("Status");

            using (var reader = DBClass.ExecuteReader("SELECT e.id, e.name,p.name role, e.BasicSalary,e.state FROM tbl_employee e INNER JOIN tbl_position p ON p.id = e.Position_id"))
            {
                while (reader.Read())
                {
                    dt.Rows.Add(
                        reader["id"],
                        reader["name"],
                        reader["role"],
                        Convert.ToDecimal(reader["BasicSalary"]).ToString("N2"),
                        Convert.ToInt32(reader["state"]) == 0 ? "Active" : "Inactive"
                        );
                }
            }
            //dt.Rows.Add(1, "Ahmed", "Electrician", 3500, "Active");
            //dt.Rows.Add(2, "Khalid", "Technician", 3000, "Active");
            //dt.Rows.Add(3, "Sara", "HR Officer", 4500, "Active");

            dgvEmployees.DataSource = dt;
            dgvEmployees.Columns["Id"].Visible = false;
        }

        private void btnAddEmployee_Click(object sender, System.EventArgs e)
        {
            EmployeeForm frm = new EmployeeForm();
            frm.ShowDialog();
            LoadEmployees();
        }

        private void btnAttendance_Click(object sender, System.EventArgs e)
        {
            MasterAttendanceSheet frm = new MasterAttendanceSheet();
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }
        private void btnPayroll_Click(object sender, System.EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                int eId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["Id"].Value);
                PayrollForm frm = new PayrollForm(eId);
                frm.ShowDialog();
            }
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            LoadEmployees();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvEmployees_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int employeeId = Convert.ToInt32(dgvEmployees.Rows[e.RowIndex].Cells["Id"].Value);
                EmployeeForm frm = new EmployeeForm(employeeId);
                frm.ShowDialog();
                LoadEmployees();
            }
        }
    }
}
