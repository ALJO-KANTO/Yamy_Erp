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

namespace YamyProject.UI.ContractingGeneralMaintenance.FinanceBilling
{
    public partial class FinanceControl : Form
    {
        public FinanceControl()
        {
            InitializeComponent();
        }

        private void FinanceControl_Load(object sender, EventArgs e)
        {
            //LoadInvoices();
            LoadFinanceTransactions();
        }
        private void LoadFinanceTransactions()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Type");
            dt.Columns.Add("Reference");
            dt.Columns.Add("Party");
            dt.Columns.Add("Project");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Status");
            dt.Columns.Add("Date");

            string sql = @"
                            SELECT 
                                i.id,
                                'Invoice' COLLATE utf8mb4_general_ci AS type,
                                i.invoice_no COLLATE utf8mb4_general_ci AS ref_no,
                                c.name COLLATE utf8mb4_general_ci AS party,
                                p.name COLLATE utf8mb4_general_ci AS project,
                                i.amount,
                                i.status COLLATE utf8mb4_general_ci AS status,
                                i.invoice_date AS trx_date
                            FROM tbl_invoices i
                            JOIN tbl_customer c ON i.customer_id = c.id
                            JOIN tbl_projects p ON i.project_id = p.id

                            UNION ALL

                            SELECT
                                e.id,
                                'Expense' COLLATE utf8mb4_general_ci AS type,
                                e.expense_type COLLATE utf8mb4_general_ci AS ref_no,
                                'Internal' COLLATE utf8mb4_general_ci AS party,
                                p.name COLLATE utf8mb4_general_ci AS project,
                                e.amount,
                                'Paid' COLLATE utf8mb4_general_ci AS status,
                                e.expense_date AS trx_date
                            FROM tbl_expenses e
                            LEFT JOIN tbl_projects p ON e.project_id = p.id

                            ORDER BY trx_date DESC;";

            using (MySqlDataReader r = DBClass.ExecuteReader(sql))
            {
                while (r.Read())
                {
                    dt.Rows.Add(
                        r["id"],
                        r["type"],
                        r["ref_no"],
                        r["party"],
                        r["project"],
                        r["amount"],
                        r["status"],
                        Convert.ToDateTime(r["trx_date"]).ToString("yyyy-MM-dd")
                    );
                }
            }

            dgvInvoices.DataSource = dt;
            dgvInvoices.Columns["Id"].Visible = false;
        }

        private void LoadInvoicesOld()
        {
            // Replace with DB integration
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Type");
            dt.Columns.Add("Invoice No");
            dt.Columns.Add("Customer");
            dt.Columns.Add("Project");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Status");
            dt.Columns.Add("Invoice Date");

            //dt.Rows.Add("INV-001", "ABC Contracting", "Villa Project", 45000, "Unpaid", "2026-01-10");
            //dt.Rows.Add("INV-002", "XYZ Maintenance", "Mall Maintenance", 18000, "Paid", "2026-01-12");
            
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT i.id, i.type,i.invoice_no, c.name customer_name, p.name project_name, i.amount, i.status, i.invoice_date FROM tbl_invoices i JOIN tbl_customer c ON i.customer_id = c.id JOIN tbl_projects p ON i.project_id = p.id"))
            {
                while(reader.Read())
                {
                    dt.Rows.Add(
                        reader["id"].ToString(),
                        reader["type"].ToString(),
                        reader["invoice_no"].ToString(),
                        reader["customer_name"].ToString(),
                        reader["project_name"].ToString(),
                        reader["amount"].ToString(),
                        reader["status"].ToString(),
                        Convert.ToDateTime(reader["invoice_date"]).ToString("yyyy-MM-dd")
                    );
                }
            }
            dgvInvoices.DataSource = dt;

            dgvInvoices.Columns["Id"].Visible = false;
        }

        private void btnNewInvoice_Click(object sender, System.EventArgs e)
        {
            InvoiceForm frm = new InvoiceForm();
            frm.ShowDialog();
            LoadFinanceTransactions();
        }

        private void btnExpenses_Click(object sender, System.EventArgs e)
        {
            ExpenseForm frm = new ExpenseForm();
            frm.ShowDialog();
            LoadFinanceTransactions();
        }

        private void btnPL_Click(object sender, System.EventArgs e)
        {
            ProfitLossForm frm = new ProfitLossForm();
            frm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            LoadFinanceTransactions();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvInvoices.Rows[e.RowIndex].Cells["Id"].Value);
            string type = dgvInvoices.Rows[e.RowIndex].Cells["Type"].Value.ToString();

            if (type == "Invoice")
            {
                InvoiceForm frm = new InvoiceForm(id);
                frm.ShowDialog();
            }
            else if (type == "Expense")
            {
                ExpenseForm frm = new ExpenseForm(id);
                frm.ShowDialog();
            }

            LoadFinanceTransactions();
        }

    }
}
