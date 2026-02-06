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
    public partial class ContractForm : Form
    {
        int id;
        public ContractForm(int id = 0)
        {
            InitializeComponent();
            this.id = id;
        }

        private void ContractForm_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateCustomers(cmbCustomer);
            cmbCustomer.SelectedIndex = -1;
            if (id > 0)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            using(MySqlDataReader reader = DBClass.ExecuteReader("SELECT contract_no, client_id, start_date, end_date, contract_no, contract_value FROM tbl_crm_contracts WHERE contract_id = @Id", DBClass.CreateParameter("@Id", id)))
            {
                if (reader.Read())
                {
                    txtContractNo.Text = reader["contract_no"].ToString();
                    cmbCustomer.SelectedValue = Convert.ToInt32(reader["client_id"]);
                    dtpStartDate.Value = Convert.ToDateTime(reader["start_date"]);
                    dtpEndDate.Value = Convert.ToDateTime(reader["end_date"]);
                    txtContractNo.Text = reader["contract_no"].ToString();
                    txtContractValue.Text = Convert.ToDecimal(reader["contract_value"]).ToString("N2");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContractNo.Text))
            {
                MessageBox.Show("Please enter the contract number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbCustomer.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(dtpEndDate.Value < dtpStartDate.Value)
            {
                MessageBox.Show("End date cannot be earlier than start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!decimal.TryParse(txtContractValue.Text, out decimal contractValue) || contractValue < 0)
            {
                MessageBox.Show("Please enter a valid contract value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (id > 0)
            {
                // Update existing contract
                DBClass.ExecuteNonQuery("UPDATE tbl_crm_contracts SET contract_no = @ContractNo, client_id = @ClientId, start_date = @StartDate, end_date = @EndDate, contract_value = @ContractValue WHERE contract_id = @Id",
                    DBClass.CreateParameter("@ContractNo", txtContractNo.Text),
                    DBClass.CreateParameter("@ClientId", cmbCustomer.SelectedValue),
                    DBClass.CreateParameter("@StartDate", dtpStartDate.Value),
                    DBClass.CreateParameter("@EndDate", dtpEndDate.Value),
                    DBClass.CreateParameter("@ContractValue", Convert.ToDecimal(txtContractValue.Text)),
                    DBClass.CreateParameter("@Id", id)
                );

                MessageBox.Show("Contract updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Insert new contract
                DBClass.ExecuteNonQuery("INSERT INTO tbl_crm_contracts (contract_no, client_id, start_date, end_date, contract_value, signed_date) VALUES (@ContractNo, @ClientId, @StartDate, @EndDate, @ContractValue, now())",
                    DBClass.CreateParameter("@ContractNo", txtContractNo.Text),
                    DBClass.CreateParameter("@ClientId", cmbCustomer.SelectedValue),
                    DBClass.CreateParameter("@StartDate", dtpStartDate.Value),
                    DBClass.CreateParameter("@EndDate", dtpEndDate.Value),
                    DBClass.CreateParameter("@ContractValue", Convert.ToDecimal(txtContractValue.Text))
                );

                MessageBox.Show("Contract created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtContractValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
