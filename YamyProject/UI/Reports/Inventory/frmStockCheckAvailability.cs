using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YamyProject.UI.Reports.Inventory
{
    public partial class frmStockCheckAvailability : Form
    {
        public frmStockCheckAvailability()
        {
            InitializeComponent();
            Load += FrmStockCheck_Load;
            btnSearch.Click += BtnSearch_Click;
            dgvStock.CellClick += DgvStock_CellClick;
        }

        private void FrmStockCheck_Load(object sender, EventArgs e)
        {
            LoadItems();
            LoadWarehouses();
            LoadGrid();
        }

        void LoadItems()
        {
            cmbItem.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_items ORDER BY name");
            cmbItem.DisplayMember = "name";
            cmbItem.ValueMember = "id";
        }

        void LoadWarehouses()
        {
            cmbWarehouse.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_warehouse");
            cmbWarehouse.DisplayMember = "name";
            cmbWarehouse.ValueMember = "id";
        }

        void LoadGrid()
        {
            string sql = @"
            SELECT 
                item_id,
                SUM(qty_in) AS total_in,
                SUM(qty_out) AS total_out,
                SUM(qty_in - qty_out) AS balance
            FROM tbl_item_transaction
            GROUP BY item_id";

            dgvStock.DataSource = DBClass.ExecuteDataTable(sql);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string sql = @"
            SELECT 
                date,
                type,
                reference,
                qty_in,
                qty_out,
                (qty_in - qty_out) AS movement,
                description
            FROM tbl_item_transaction
            WHERE item_id=@item_id
            AND warehouse_id=@warehouse_id
            ORDER BY date";

            DataTable dt = DBClass.ExecuteDataTable(sql,
                DBClass.CreateParameter("@item_id", cmbItem.SelectedValue),
                DBClass.CreateParameter("@warehouse_id", cmbWarehouse.SelectedValue));

            dgvStock.DataSource = dt;

            LoadSummary();
        }

        void LoadSummary()
        {
            string sql = @"
            SELECT 
                IFNULL(SUM(qty_in),0),
                IFNULL(SUM(qty_out),0),
                IFNULL(SUM(qty_in - qty_out),0)
            FROM tbl_item_transaction
            WHERE item_id=@item_id
            AND warehouse_id=@warehouse_id";

            DataTable dt = DBClass.ExecuteDataTable(sql,
                DBClass.CreateParameter("@item_id", cmbItem.SelectedValue),
                DBClass.CreateParameter("@warehouse_id", cmbWarehouse.SelectedValue));

            if (dt.Rows.Count > 0)
            {
                txtTotalIn.Text = dt.Rows[0][0].ToString();
                txtTotalOut.Text = dt.Rows[0][1].ToString();
                txtBalance.Text = dt.Rows[0][2].ToString();
            }
        }

        private void DgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // future: drill down transaction
        }
    }
}
