using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class frmModules : Form
    {
        public frmModules()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            headerUC1.FormText = this.Text;
        }
        private void frmModules_Load(object sender, EventArgs e)
        {
            LoaddgvItems();
        }
        public void LoaddgvItems()
        {
            int count = 1;
            dgvResource.Rows.Clear();
            DataTable dt = BindDataTable.tableModules;
            foreach (DataRow row in dt.Rows)
            {
                bool isActive = row["status"].ToString() == "1" ? true : false;
                dgvResource.Rows.Add(count, row["id"], row["name"], isActive);
                count++;
            }
        }

        private void btnClose_Click(object senderc, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (updateData())
            {
                this.Close();
            }
        }

        private void dgvResource_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvResource.Rows.Count == 0)
                return;

            if (int.Parse(dgvResource.CurrentRow.Cells["ResourceId"].Value.ToString()) > 0)
            {
                bool isSelected = Convert.ToBoolean(dgvResource.CurrentRow.Cells["select"].Value);
                int resourceId = int.Parse(dgvResource.CurrentRow.Cells["ResourceId"].Value.ToString());
                BindDataTable.tableModules.Rows.Find(resourceId)["status"] = isSelected ? "1" : "0";
            }
        }

        private bool updateData()
        {
            DBClass.ExecuteNonQuery(@"UPDATE tbl_set_main_menu SET status = 0");

            foreach (DataGridViewRow row in dgvResource.Rows)
            {
                // Skip the last empty row (DataGridView includes a blank row)
                if (row.IsNewRow) continue;

                bool isSelected = Convert.ToBoolean(row.Cells["select"].Value);

                if (isSelected)
                {
                    DBClass.ExecuteNonQuery(
                        @"UPDATE tbl_set_main_menu SET status = @status WHERE id = @id;",
                        DBClass.CreateParameter("status", 1),
                        DBClass.CreateParameter("id", row.Cells["ResourceId"].Value)
                    );

                    // Example: update your DataTable (BindDataTable.tableModules)
                    DataRow[] found = BindDataTable.tableModules.Select($"id = {row.Cells["ResourceId"].Value}");
                    if (found.Length > 0)
                    {
                        found[0]["status"] = 1;
                    }
                }
                else
                {
                    // Optional: update DataTable for unselected rows
                    DataRow[] found = BindDataTable.tableModules.Select($"id = {row.Cells["ResourceId"].Value}");
                    if (found.Length > 0)
                    {
                        found[0]["status"] = 0;
                    }
                }
            }

            return true;
        }
    }
}

