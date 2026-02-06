using DocumentFormat.OpenXml.Office2010.Excel;
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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace YamyProject.UI.ContractingGeneralMaintenance.ProjectManagement
{
    public partial class ProjectManagementControl : Form
    {
        public ProjectManagementControl()
        {
            InitializeComponent();
        }

        private void ProjectManagementControl_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Project ID");
            dt.Columns.Add("Project Name");
            dt.Columns.Add("Start Date");
            dt.Columns.Add("End Date");
            dt.Columns.Add("Budget");
            dt.Columns.Add("Actual Cost");
            dt.Columns.Add("Profit");

            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_projects"))
                while (reader.Read())
                {
                    decimal budget = 0, actualCost = 0;
                    decimal.TryParse(reader["category"].ToString(), out budget);
                    decimal.TryParse(reader["description"].ToString(), out actualCost);

                    dt.Rows.Add(reader["id"], reader["name"], reader["start_date"], reader["end_date"], budget, actualCost, budget-actualCost);
                }

            dgvProjects.DataSource = dt;

            dgvProjects.Columns["Project ID"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProjectForm frm = new ProjectForm();
            frm.ShowDialog();
            loadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedRows.Count == 0) return;

            int projectId = Convert.ToInt32(dgvProjects.CurrentRow.Cells["Project ID"].Value);
            ProjectForm frm = new ProjectForm(projectId);
            frm.ShowDialog();
            loadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Delete selected project?", "Confirm",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int projectId = Convert.ToInt32(dgvProjects.CurrentRow.Cells["Project ID"].Value);
                DBClass.ExecuteNonQuery(@"DELETE from tbl_projects WHERE id = @id", DBClass.CreateParameter("@id", projectId));

                Utilities.LogAudit(frmLogin.userId, "Delete Eng Project", "Eng Project", projectId, "Delete Eng Project: " + projectId);

                MessageBox.Show("Delete", "Successful");
                loadData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProjects_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0) return;

            int projectId = Convert.ToInt32(dgvProjects.Rows[e.RowIndex].Cells["Project ID"].Value);
            ProjectForm frm = new ProjectForm(projectId);
            frm.ShowDialog();
            loadData();
        }
    }
}
