using Microsoft.Vbe.Interop;
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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace YamyProject.UI.ContractingGeneralMaintenance.CRM
{
    public partial class CustomerForm : Form
    {
        int id;
        public CustomerForm(int _id = 0)
        {
            InitializeComponent();
            this.id = _id;
        }
        int cmbAccountId = 0;
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            cmbAccountId = BindCombos.SelectDefaultLevelAccount("Customer");
            if (id > 0)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT name, building_name, main_phone, email, state FROM tbl_customer WHERE id = @Id", DBClass.CreateParameter("@Id", id)))
            {
                if (reader.Read())
                {
                    txtName.Text = reader["name"].ToString();
                    cmbType.SelectedItem = reader["building_name"].ToString();
                    txtPhone.Text = reader["main_phone"].ToString();
                    txtEmail.Text = reader["email"].ToString();
                    //cmbStatus.SelectedItem = Convert.ToInt32(reader["state"]) == 0 ? "Active" : "Inactive";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the customer name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbType.Text))
            {
                MessageBox.Show("Please select the customer type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (id > 0)
            {
                //check if customer name exists
                if (DBClass.ExecuteScalar("SELECT COUNT(*) FROM tbl_customer WHERE name = @Name AND id != @Id",
                    DBClass.CreateParameter("@Name", txtName.Text),
                    DBClass.CreateParameter("@Id", id)) is long count && count > 0)
                {
                    MessageBox.Show("A customer with this name already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Update existing customer
                DBClass.ExecuteNonQuery("UPDATE tbl_customer SET name = @Name, building_name = @Type, main_phone = @Phone, email = @Email WHERE id = @Id",
                    DBClass.CreateParameter("@Name", txtName.Text),
                    DBClass.CreateParameter("@Type", cmbType.SelectedItem),
                    DBClass.CreateParameter("@Phone", txtPhone.Text),
                    DBClass.CreateParameter("@Email", txtEmail.Text),
                    DBClass.CreateParameter("@Id", id));

                MessageBox.Show("Customer updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string formattedCode = GenerateNextCustomerCode();

                //check if customer name exists
                if (IsCustomerExists(txtName.Text.Trim()))
                {
                    MessageBox.Show("A customer with this name already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Insert new customer
                
                DBClass.ExecuteScalar(@"INSERT INTO tbl_customer (code, NAME, Cat_id, Balance, DATE, 
                main_phone, work_phone, mobile, email, ccemail, website, country, city, region, building_name, account_id, 
                trn, facilty_name, active, created_by, created_date, state, project_id, project_site) 
                VALUES(@code, @name, @cat_id, @balance, @date, @main_phone, @work_phone, @mobile, @email, @ccemail, @website, 
                @country, @city, @region, @building_name, @account_id, @trn, @facilty_name, @active, @created_by, @created_date, @state, @project_id, @project_site);
                SELECT LAST_INSERT_ID();",
                DBClass.CreateParameter("code", formattedCode),
                DBClass.CreateParameter("name", txtName.Text),
                DBClass.CreateParameter("cat_id", 0),
                DBClass.CreateParameter("balance", 0),
                DBClass.CreateParameter("date", DateTime.Now.Date),
                DBClass.CreateParameter("main_phone", txtPhone.Text),
                DBClass.CreateParameter("work_phone", ""),
                DBClass.CreateParameter("mobile", ""),
                DBClass.CreateParameter("email", txtEmail.Text),
                DBClass.CreateParameter("ccemail", ""),
                DBClass.CreateParameter("website", ""),
                DBClass.CreateParameter("country", 0),
                DBClass.CreateParameter("city", 0),
                DBClass.CreateParameter("project_id", 0),
                DBClass.CreateParameter("project_site", ""),
                DBClass.CreateParameter("region", ""),
                DBClass.CreateParameter("building_name", cmbType.SelectedItem),
                DBClass.CreateParameter("account_id", cmbAccountId),
                DBClass.CreateParameter("trn", ""),
                DBClass.CreateParameter("facilty_name", ""),
                DBClass.CreateParameter("active", 0),
                DBClass.CreateParameter("created_by", frmLogin.userId),
                DBClass.CreateParameter("created_date", DateTime.Now.Date),
                DBClass.CreateParameter("state", 0));

                MessageBox.Show("Customer created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GenerateNextCustomerCode()
        {
            int code;
            using (var reader = DBClass.ExecuteReader("SELECT MAX(CAST(code AS UNSIGNED)) AS lastCode FROM tbl_customer"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                    code = int.Parse(reader["lastCode"].ToString()) + 1;
                else
                    code = 10001;
            }
            return code.ToString("D5");
        }
        private bool IsCustomerExists(string customerName)
        {
            using (var reader = DBClass.ExecuteReader("SELECT 1 FROM tbl_customer WHERE name = @name",
                           DBClass.CreateParameter("name", customerName)))
            {
                if (reader.Read())
                {
                    MessageBox.Show("Customer Already Exists. Enter Another Name.");
                    return true;
                }
            }
            return false;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
