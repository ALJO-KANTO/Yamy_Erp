using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm
{
    public partial class frmEngProjectList : Form
    {
        public frmEngProjectList()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngProjectList_Load(object sender, EventArgs e)
        {
            DataTable dataTable = DBClass.ExecuteDataTable("select distinct status from tbl_projects");
            DataRow row = dataTable.NewRow();
            row["status"] = "All";
            dataTable.Rows.InsertAt(row, 0);
            cmbStatus.DataSource = dataTable;
            cmbStatus.DisplayMember = "status";
            cmbStatus.ValueMember = "status";
            BindData();
        }

        private void BindData()
        {
            dgvProjects.Rows.Clear();

            string query = "SELECT a.id,a.name,a.code,b.name client,a.category,a.description,a.start_date,a.end_date,a.status FROM tbl_projects a INNER JOIN tbl_customer b ON a.id = b.project_id where a.id > 0 ";

            List<MySqlParameter> parameters = new List<MySqlParameter>();

            // Status filter
            if (cmbStatus.SelectedValue != null &&
                cmbStatus.SelectedValue.ToString() != "All")
            {
                query += " AND a.status = @status";
                parameters.Add(DBClass.CreateParameter(
                    "@status",
                    cmbStatus.SelectedValue.ToString()
                ));
            }

            // Search filter
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                query += " AND a.name LIKE @search";
                parameters.Add(DBClass.CreateParameter(
                    "@search",
                    "%" + txtSearch.Text.Trim() + "%"
                ));
            }

            using (MySqlDataReader reader = DBClass.ExecuteReader(query, parameters.ToArray()))
            {
                while (reader.Read())
                {
                    dgvProjects.Rows.Add(
                        reader["id"],
                        reader["code"],
                        reader["name"],
                        reader["client"],
                        Convert.ToDateTime(reader["start_date"]).ToString("yyyy-MM-dd"),
                        Convert.ToDateTime(reader["end_date"]).ToString("yyyy-MM-dd"),
                        "",
                        reader["status"]
                    );
                }
            }

            LocalizationManager.LocalizeDataGridViewHeaders(dgvProjects);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmEngProjectSetup().ShowDialog();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dgvProjects.Rows.Count > 0) {
                if (dgvProjects.SelectedRows != null)
                {
                    if (dgvProjects.SelectedRows[0].Cells["id"] == null)
                        return;
                    else
                    {
                        int pId = int.Parse(dgvProjects.SelectedRows[0].Cells["id"].Value.ToString());
                        new frmEngProjectSetup(pId).ShowDialog();
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void dgvProjects_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                int pId = int.Parse(dgvProjects.Rows[e.RowIndex].Cells["id"].Value.ToString());
                new frmEngProjectSetup(pId).ShowDialog();
            }
        }
    }
}
