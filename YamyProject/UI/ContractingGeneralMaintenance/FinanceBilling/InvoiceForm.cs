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
    public partial class InvoiceForm : Form
    {
        int id;
        public InvoiceForm(int _id = 0)
        {
            InitializeComponent();
            this.id = _id;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateCustomers(cmbCustomer);
            BindCombos.PopulateProjects(cmbProject);

            if (id > 0)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            string query = "SELECT id, invoice_no, customer_id, project_id, amount, status, invoice_date From tbl_invoices WHERE id = @Id";
            using (var reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("@Id", id)))
            {
                if (reader.Read())
                {
                    txtInvoiceNo.Text = reader["invoice_no"].ToString();
                    cmbCustomer.SelectedValue = Convert.ToInt32(reader["customer_id"]);
                    cmbProject.SelectedValue = Convert.ToInt32(reader["project_id"]);
                    txtAmount.Text = reader["amount"].ToString();
                    cmbStatus.SelectedItem = reader["status"].ToString();
                    dtpInvoiceDate.Value = Convert.ToDateTime(reader["invoice_date"]);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                if(id == 0)
                {
                    // Insert new invoice logic
                    DBClass.ExecuteNonQuery("INSERT INTO tbl_invoices (invoice_no, customer_id, project_id, amount, status, invoice_date) VALUES (@InvoiceNo, @CustomerId, @ProjectId, @Amount, @Status, @InvoiceDate)",
                            DBClass.CreateParameter("@InvoiceNo", txtInvoiceNo.Text ),
                            DBClass.CreateParameter("@CustomerId", cmbCustomer.SelectedValue ),
                            DBClass.CreateParameter("@ProjectId", cmbProject.SelectedValue ),
                            DBClass.CreateParameter("@Amount", txtAmount.Text),
                            DBClass.CreateParameter("@Status", cmbStatus.SelectedItem.ToString()),
                            DBClass.CreateParameter("@InvoiceDate", dtpInvoiceDate.Value )
                        );
                    MessageBox.Show("Invoice created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Update existing invoice logic
                    DBClass.ExecuteNonQuery("UPDATE tbl_invoices SET invoice_no = @InvoiceNo, customer_id = @CustomerId, project_id = @ProjectId, amount = @Amount, status = @Status, invoice_date = @InvoiceDate WHERE id = @Id",
                            DBClass.CreateParameter("@InvoiceNo", txtInvoiceNo.Text),
                            DBClass.CreateParameter("@CustomerId", cmbCustomer.SelectedValue),
                            DBClass.CreateParameter("@ProjectId", cmbProject.SelectedValue),
                            DBClass.CreateParameter("@Amount", txtAmount.Text),
                            DBClass.CreateParameter("@Status", cmbStatus.SelectedItem.ToString()),
                            DBClass.CreateParameter("@InvoiceDate", dtpInvoiceDate.Value),
                            DBClass.CreateParameter("@Id", id)
                        );
                    MessageBox.Show("Invoice updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private bool validateForm()
        {
            if(string.IsNullOrWhiteSpace(txtInvoiceNo.Text))
            {
                MessageBox.Show("Please enter Invoice Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(cmbCustomer.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a Customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(cmbProject.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a Project.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(string.IsNullOrWhiteSpace(txtAmount.Text) || !decimal.TryParse(txtAmount.Text, out _))
            {
                MessageBox.Show("Please enter a valid Amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
