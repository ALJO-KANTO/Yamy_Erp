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

namespace YamyProject.UI.ContractingGeneralMaintenance.Inventory
{
    public partial class InventoryControl : Form
    {
        public InventoryControl()
        {
            InitializeComponent();
        }

        private void InventoryControl_Load(object sender, EventArgs e)
        {
            LoadInventory();
        }

        private void LoadInventory()
        {
            // Replace with DB data
            DataTable dt = new DataTable();
            dt.Columns.Add("Material ID");
            dt.Columns.Add("Material Name");
            dt.Columns.Add("Warehouse");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Min Level");
            dt.Columns.Add("Unit Cost");
            dt.Columns.Add("Total Value");

            //dt.Rows.Add(1, "Cement Bag", "Main Store", 500, 100, 20, 10000);
            //dt.Rows.Add(2, "Steel Rod", "Warehouse B", 120, 50, 150, 18000);
            //dt.Rows.Add(3, "Electrical Cable", "Main Store", 80, 100, 60, 4800);

            using(MySqlDataReader reader = DBClass.ExecuteReader("SELECT m.id, m.name,m.warehouse_id, w.name warehouse_name, m.on_hand quantity, m.min_amount, m.cost_price, (m.on_hand * m.cost_price) AS total_value FROM tbl_items m LEFT JOIN tbl_warehouse w ON w.id = m.warehouse_id"))
            {
                while (reader.Read())
                {
                    dt.Rows.Add(
                        reader["id"],
                        reader["name"],
                        reader["warehouse_name"],
                        decimal.Parse(reader["quantity"].ToString()).ToString("N2"),
                        decimal.Parse(reader["min_amount"].ToString()).ToString("N2"),
                        decimal.Parse(reader["cost_price"].ToString()).ToString("N2"),
                        decimal.Parse(reader["total_value"].ToString()).ToString("N2")
                    );
                }
            }

            dgvInventory.DataSource = dt;

            dgvInventory.Columns["Material ID"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MaterialForm frm = new MaterialForm();
            frm.ShowDialog();
            LoadInventory();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0) return;

            MessageBox.Show("Material issued to job/project.");
            LoadInventory();
        }

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0) return;

            MessageBox.Show("Stock adjustment recorded.");
            LoadInventory();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInventory();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0) return;

            int materialId = Convert.ToInt32(dgvInventory.Rows[e.RowIndex].Cells["Material ID"].Value);
            MaterialForm frm = new MaterialForm(materialId);
            frm.ShowDialog();
        }
    }
}
