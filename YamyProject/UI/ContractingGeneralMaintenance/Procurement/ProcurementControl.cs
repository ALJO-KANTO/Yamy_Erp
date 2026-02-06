using Microsoft.Vbe.Interop;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.Procurement
{
    public partial class ProcurementControl : Form
    {
        public ProcurementControl()
        {
            InitializeComponent();
        }

        private void ProcurementControl_Load(object sender, EventArgs e)
        {
            LoadPurchaseOrders();
        }
        private void LoadPurchaseOrders()
        {
            // Replace with DB query
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("PO No");
            dt.Columns.Add("Supplier");
            dt.Columns.Add("Project");
            dt.Columns.Add("Total Amount");
            dt.Columns.Add("Status");
            dt.Columns.Add("Payment Status");

            //dt.Rows.Add("PO-1001", "ABC Suppliers", "Tower Project", 85000, "Approved", "Unpaid");
            //dt.Rows.Add("PO-1002", "Electro Works", "Mall Renovation", 42000, "Pending", "N/A");
            //dt.Rows.Add("PO-1003", "Steel Co", "Warehouse", 125000, "Approved", "Paid");

            string query = @"SELECT 
                                t.id,
                                t.purchase_order_id,
                                s.name AS supplier,
                                pr.name AS project,
                                t.amount,
                                t.approval_status,
                                t.payment_status
                            FROM tbl_procurement_tracking t
                            LEFT JOIN tbl_vendor s 
                                ON s.id = t.vendor_id
                            LEFT JOIN tbl_projects pr 
                                ON pr.id = t.project_id
                            ";
            using (MySqlDataReader reader = DBClass.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    dt.Rows.Add(
                        reader["id"].ToString(),
                        reader["purchase_order_id"].ToString(),
                        reader["supplier"].ToString(),
                        reader["project"].ToString(),
                        decimal.Parse(reader["amount"].ToString()).ToString("N2"),
                        reader["approval_status"].ToString(),
                        reader["payment_status"].ToString()
                    );
                }
            }
            dgvPO.DataSource = dt;

            dgvPO.Columns["id"].Visible = false;
        }

        private void btnNewPO_Click(object sender, EventArgs e)
        {
            PurchaseOrderForm frm = new PurchaseOrderForm();
            frm.ShowDialog();
            LoadPurchaseOrders();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvPO.SelectedRows.Count == 0) return;

            // Update status to Approved
            int poId = int.Parse(dgvPO.SelectedRows[0].Cells["Id"].Value.ToString());

            DBClass.ExecuteNonQuery("update  tbl_procurement_tracking set approval_status=@status where id=@id",
                    DBClass.CreateParameter("@id", poId),
                    DBClass.CreateParameter("@status", "Approved")
                    );
            MessageBox.Show("Purchase Order Approved");
            LoadPurchaseOrders();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (dgvPO.SelectedRows.Count == 0) return;
            int poId = int.Parse(dgvPO.SelectedRows[0].Cells["Id"].Value.ToString());

            DBClass.ExecuteNonQuery("update  tbl_procurement_tracking set payment_status=@status where id=@id",
                    DBClass.CreateParameter("@id", poId),
                    DBClass.CreateParameter("@status", "Paid")
                    );
            MessageBox.Show("Payment recorded for selected PO");
            LoadPurchaseOrders();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPurchaseOrders();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0) return;

            int poId = int.Parse(dgvPO.Rows[e.RowIndex].Cells["Id"].Value.ToString());

            PurchaseOrderForm purchaseOrderForm = new PurchaseOrderForm(poId);
            purchaseOrderForm.ShowDialog();
            LoadPurchaseOrders();
        }
    }
}
