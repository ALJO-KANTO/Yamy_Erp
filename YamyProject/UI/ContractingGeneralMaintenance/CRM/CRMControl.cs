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

namespace YamyProject.UI.ContractingGeneralMaintenance.CRM
{
    public partial class CRMControl : Form
    {
        public CRMControl()
        {
            InitializeComponent();
        }
        private void CRMControl_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }
        private void LoadCustomers()
        {
            // Replace with database logic
            DataTable dt = new DataTable();
            dt.Columns.Add("Customer ID");
            dt.Columns.Add("Customer Name");
            dt.Columns.Add("Type");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Email");
            dt.Columns.Add("Status");

            //dt.Rows.Add(1, "ABC Contracting", "Contracting", "0501234567", "info@abc.com", "Active");
            //dt.Rows.Add(2, "XYZ Mall", "Maintenance", "0559876543", "admin@xyzmall.com", "Active");
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT id, name,building_name type,main_phone phone, email,state FROM tbl_customer"))
            {
                while (reader.Read())
                {
                    dt.Rows.Add(
                        reader["id"],
                        reader["name"],
                        reader["type"],
                        reader["phone"],
                        reader["email"],
                        Convert.ToInt32(reader["state"]) == 0 ? "Active" : "Inactive"
                    );
                }
            }
            dgvCustomers.DataSource = dt;
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm frm = new CustomerForm();
            frm.ShowDialog();
            LoadCustomers();
        }

        private void btnContracts_Click(object sender, EventArgs e)
        {
            int refId = 0;
            if(dgvCustomers.SelectedRows.Count>0)
            {
                int cId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["Customer ID"].Value);
                object obj = DBClass.ExecuteScalar("SELECT contract_id FROM tbl_crm_contracts WHERE client_id = @Id", DBClass.CreateParameter("@Id", cId));
                refId = obj != null ? Convert.ToInt32(obj) : 0;
            }
            ContractForm frm = new ContractForm(refId);
            frm.ShowDialog();
        }

        private void btnFollowUp_Click(object sender, EventArgs e)
        {
            int refId = 0;
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                int cId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["Customer ID"].Value);
                object obj = DBClass.ExecuteScalar("SELECT lead_id FROM tbl_crm_leads WHERE assigned_to = @Id", DBClass.CreateParameter("@Id", cId));
                refId = obj != null ? Convert.ToInt32(obj) : 0;
            }
            FollowUpForm frm = new FollowUpForm(refId);
            frm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int customerId = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["Customer ID"].Value);
                CustomerForm frm = new CustomerForm(customerId);
                frm.ShowDialog();
                LoadCustomers();
            }
        }
    }
}
