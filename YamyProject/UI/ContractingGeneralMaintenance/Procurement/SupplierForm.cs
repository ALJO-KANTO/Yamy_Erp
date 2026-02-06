using DocumentFormat.OpenXml.Office2010.Excel;
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

namespace YamyProject.UI.ContractingGeneralMaintenance.Procurement
{
    public partial class SupplierForm : Form
    {
        int id;
        public SupplierForm(int _id = 0)
        {
            InitializeComponent();
            this.id = _id;
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            if(id != 0)
            {
                LoadVendorData();
            }
        }

        private void LoadVendorData()
        {
            using(MySqlDataReader reader = DBClass.ExecuteReader("SELECT * FROM tbl_vendor WHERE id = @id",
                DBClass.CreateParameter("id", id)))
            {
                if(reader.Read())
                {
                    txtCode = reader["code"].ToString();
                    txtName.Text = reader["name"].ToString();
                    txtPhone.Text = reader["main_phone"].ToString();
                    cmbType.SelectedItem = reader["type"].ToString();
                    id = Convert.ToInt32(reader["id"]);
                }
            }
        }

        string txtCode = "";
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                if (insertVendor())
                {
                    this.Close();
                }
            }
            else
            {
                if (updateVendor())
                {
                    this.Close();
                }
            }
        }
        private bool updateVendor()
        {
            if (!ValidateVendorInputs())
                return false;

            DBClass.ExecuteNonQuery(@"Update tbl_vendor Set NAME=@NAME, DATE=@date, main_phone=@main_phone,type=@type where id = @id",
                                          DBClass.CreateParameter("name", txtName.Text),
                                          DBClass.CreateParameter("date", DateTime.Now.Date),
                                          DBClass.CreateParameter("main_phone", txtPhone.Text),
                                          DBClass.CreateParameter("type", cmbType.SelectedItem.ToString()),
                                          DBClass.CreateParameter("id", id));


            DBClass.ExecuteNonQuery("DELETE from tbl_transaction WHERE transaction_id=@id AND TYPE='Vendor Opening Balance'", DBClass.CreateParameter("id", id));

            Utilities.LogAudit(frmLogin.userId, "Update Vendor", "Vendor Center", id, "Updated Vendor: " + txtName.Text);
            return true;
        }

        private bool ValidateVendorInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Enter Vendor Name First.");
                return false;
            }
            if (cmbType.SelectedIndex == -1)
            {
                MessageBox.Show("Select Type First.");
                return false;
            }

            return true;
        }
        private bool insertVendor()
        {
            txtCode = GenerateNextVendorCode();

            if (!ValidateVendorInputs()) return false;

            if (IsVendorExists(txtName.Text)) return false;

            int vendorId = InsertVendorRecord(txtCode);
            if (vendorId <= 0) return false;

            return true;
        }


        private string GenerateNextVendorCode()
        {
            int code;
            using (var reader = DBClass.ExecuteReader("SELECT MAX(CAST(code AS UNSIGNED)) AS lastCode FROM tbl_vendor"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                    code = int.Parse(reader["lastCode"].ToString()) + 1;
                else
                    code = 20001;
            }
            return code.ToString("D5");
        }

        private bool IsVendorExists(string vendorName)
        {
            using (var reader = DBClass.ExecuteReader("SELECT 1 FROM tbl_vendor WHERE name = @name and type=@type",
                           DBClass.CreateParameter("name", vendorName),
                           DBClass.CreateParameter("@type", cmbType.SelectedItem.ToString())))
            {
                if (reader.Read())
                {
                    MessageBox.Show("Vendor Already Exists. Enter Another Name.");
                    return true;
                }
            }
            return false;
        }

        private int InsertVendorRecord(string formattedCode)
        {
            int cmbAccountId = BindCombos.SelectDefaultLevelAccount("Vendor");

            int retId = Convert.ToInt32(DBClass.ExecuteScalar(@"INSERT INTO tbl_vendor(code,
                                NAME, Cat_id, Balance, DATE, main_phone, work_phone, mobile, email, ccemail, website, country, city, region,
                                building_name, account_id, trn, facilty_name, active, created_by, created_date, state,type,project_id)
                                VALUES(@code,@name, @cat_id, @balance, @date, @main_phone, @work_phone, @mobile, @email, @ccemail, @website, @country,
                                @city, @region, @building_name, @account_id, @trn, @facilty_name, @active, @created_by, @created_date, @state, @type,@project_id);SELECT LAST_INSERT_ID();",
                                                          DBClass.CreateParameter("code", formattedCode),
                                                          DBClass.CreateParameter("name", txtName.Text),
                                                          DBClass.CreateParameter("cat_id", 0),
                                                          DBClass.CreateParameter("balance", 0),
                                                          DBClass.CreateParameter("date", DateTime.Now.Date),
                                                          DBClass.CreateParameter("main_phone", txtPhone.Text),
                                                          DBClass.CreateParameter("work_phone", ""),
                                                          DBClass.CreateParameter("mobile", ""),
                                                          DBClass.CreateParameter("email", ""),
                                                          DBClass.CreateParameter("ccemail", ""),
                                                          DBClass.CreateParameter("website", ""),
                                                          DBClass.CreateParameter("country", 0),
                                                          DBClass.CreateParameter("city", 0),
                                                          DBClass.CreateParameter("project_id", 0),
                                                          DBClass.CreateParameter("region", ""),
                                                          DBClass.CreateParameter("building_name", ""),
                                                          DBClass.CreateParameter("account_id", cmbAccountId),
                                                          DBClass.CreateParameter("trn", ""),
                                                          DBClass.CreateParameter("facilty_name", ""),
                                                          DBClass.CreateParameter("@type", cmbType.SelectedItem.ToString()),
                                                          DBClass.CreateParameter("active", 0),
                                                          DBClass.CreateParameter("created_by", frmLogin.userId),
                                                          DBClass.CreateParameter("created_date", DateTime.Now.Date),
                                                          DBClass.CreateParameter("state", 0)).ToString());
            Utilities.LogAudit(frmLogin.userId, "Add Vendor", "Vendor Center", retId, "Added Vendor: " + txtName.Text);
            return retId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
