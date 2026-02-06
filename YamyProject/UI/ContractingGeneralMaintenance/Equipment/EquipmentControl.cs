using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.Equipment
{
    public partial class EquipmentControl : Form
    {
        public EquipmentControl()
        {
            InitializeComponent();
        }

        private void EquipmentControl_Load(object sender, EventArgs e)
        {
            LoadEquipment();
        }

        private void LoadEquipment()
        {
            // Replace with database integration
            DataTable dt = new DataTable();
            dt.Columns.Add("Equipment ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Category");
            dt.Columns.Add("Status");
            dt.Columns.Add("Allocated To");
            dt.Columns.Add("Purchase Date");
            dt.Columns.Add("Cost");
            dt.Columns.Add("Depreciation");

            //dt.Rows.Add(1, "Excavator X1", "Heavy Machinery", "Available", "-", "2023-01-01", 150000, 15000);
            //dt.Rows.Add(2, "Forklift F2", "Material Handling", "In Use", "Tower Project", "2022-05-01", 45000, 5000);
            //dt.Rows.Add(3, "Generator G3", "Power Equipment", "Maintenance", "-", "2021-08-15", 60000, 12000);
            using(MySqlDataReader reader = DBClass.ExecuteReader("SELECT equipment_id, name, category, status, allocated_to, purchase_date, cost, depreciation FROM tbl_equipment"))
            {
                while (reader.Read())
                {
                    dt.Rows.Add(
                        reader["equipment_id"],
                        reader["name"],
                        reader["category"],
                        reader["status"],
                        reader["allocated_to"],
                        reader["purchase_date"],
                        reader["cost"],
                        reader["depreciation"]
                        );
                }
            }
            dgvEquipment.DataSource = dt;

            dgvEquipment.Columns["Equipment ID"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EquipmentForm frm = new EquipmentForm();
            frm.ShowDialog();
            LoadEquipment();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (dgvEquipment.SelectedRows.Count == 0) return;

            int equipmentId = Convert.ToInt32(dgvEquipment.SelectedRows[0].Cells["equipment id"].Value);

            string depreciation = Interaction.InputBox(
                "Enter allocated to:",
                "Confirm Allocation",
                ""
            );

            // Close or empty → do nothing
            if (string.IsNullOrWhiteSpace(depreciation))
                return;

            DBClass.ExecuteNonQuery(
                "UPDATE tbl_equipment SET allocated_to = @allocated_to WHERE equipment_id = @id",
                DBClass.CreateParameter("@allocated_to", depreciation),
                DBClass.CreateParameter("@id", equipmentId)
            );

            MessageBox.Show(
                "Equipment allocated successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            LoadEquipment();
        }

        private void btnDepreciation_Click(object sender, EventArgs e)
        {
            if (dgvEquipment.SelectedRows.Count == 0) return;

            int equipmentId = Convert.ToInt32(dgvEquipment.SelectedRows[0].Cells["equipment id"].Value);

            string depreciation = Interaction.InputBox(
                "Enter depreciation value:",
                "Confirm Depreciation",
                ""
            );

            // Close or empty → do nothing
            if (string.IsNullOrWhiteSpace(depreciation))
                return;

            DBClass.ExecuteNonQuery(
                "UPDATE tbl_equipment SET depreciation = @depreciation WHERE equipment_id = @id",
                DBClass.CreateParameter("@depreciation", depreciation),
                DBClass.CreateParameter("@id", equipmentId)
            );

            MessageBox.Show("Depreciation recalculated for selected equipment.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            LoadEquipment();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEquipment();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
