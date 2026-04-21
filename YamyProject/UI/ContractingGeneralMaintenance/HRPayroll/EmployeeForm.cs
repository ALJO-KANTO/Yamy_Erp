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

namespace YamyProject.UI.ContractingGeneralMaintenance.HRPayroll
{
    public partial class EmployeeForm : Form
    {
        int employeeId;
        public EmployeeForm(int _employeeId = 0)
        {
            InitializeComponent();
            this.employeeId = _employeeId;
        }

        int cmbAccountNameId = 0, cmbAccruedSalariesId = 0, cmbEmployeeReceivableId = 0, cmbAccrualLeaveSalaryId = 0, cmbGratuityId = 0, cmbPettyCashId = 0, cmbBankNameId = 0;
        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateDepartments(cmbDepartment);
            BindCombos.PopulatePositions(cmbPosition, 0);
            cmbAccountNameId = frmLogin.defaultAccounts.ContainsKey("Employee")
               ? frmLogin.defaultAccounts["Employee"] : 0;
            cmbAccruedSalariesId = BindCombos.SelectDefaultLevelAccount("Accrued Salaries");
            cmbEmployeeReceivableId = BindCombos.SelectDefaultLevelAccount("Employee Receivable");
            cmbAccrualLeaveSalaryId = BindCombos.SelectDefaultLevelAccount("Acroal Leave Salary");
            cmbGratuityId = BindCombos.SelectDefaultLevelAccount("Gratuit");
            cmbPettyCashId = frmLogin.defaultAccounts.ContainsKey("Petty Cash")
               ? frmLogin.defaultAccounts["Petty Cash"] : 0;
            if (cmbDepartment.SelectedValue != null)
                BindCombos.PopulatePositions(cmbPosition, cmbDepartment.SelectedValue.ToString() == "" ? 0 : (int)cmbDepartment.SelectedValue);
            
            if (employeeId > 0)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            using(MySqlDataReader reader = DBClass.ExecuteReader("SELECT * FROM tbl_employee where id = @id", 
                DBClass.CreateParameter("@id", employeeId)))
            {
                if (reader.Read())
                {
                    EmployeeCode = reader["code"].ToString();
                    txtName.Text = reader["name"].ToString();
                    cmbDepartment.SelectedValue = reader["Department_id"];
                    BindCombos.PopulatePositions(cmbPosition, int.Parse(cmbDepartment.SelectedValue.ToString()));
                    cmbPosition.SelectedValue = reader["Position_id"];
                    txtSalary.Text = Convert.ToDecimal(reader["BasicSalary"]).ToString("N2");
                }
            }
        }
        string EmployeeCode = "";
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                if (employeeId == 0)
                {
                    using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_employee where Name = @name",
               DBClass.CreateParameter("name", txtName.Text)))
                        if (reader.Read())
                        {
                            MessageBox.Show("Employee Name Already Exists. Enter Another Name.");
                            return;
                        }

                    EmployeeCode = GenerateNextEmployeeCode();

                    int refId = DBClass.ExecuteNonQuery(@"INSERT INTO `tbl_employee`(`code`, `name`, `birth_day`, `Social_Status`, `city_id`, 
                                `address`, `phone`, `Email`, `Social_Insurance_Number`, `EmergencyName`, 
                                `EmergencyAddress`, `EmergencyPhone`, `Relation`, `PassportNumber`, `CountryOfIssue`, 
                                `PassportIssueDate`, `PassportExpiryDate`, `WorkContractNumber`, `Position_id`, 
                                `Department_id`, `WorkContractType`, `WorkDays`, `workinghours`, `ContractIssueDate`, 
                                `ContractExpiryDate`, `ResidencyFileNumber`, `ResidencyIssuingAuthority`, 
                                `ResidencyIssueDate`, `ResidencyExpiryDate`, `EmiratesIDFileNumber`, 
                                `EmiratesIDIssuingAuthority`, `EmiratesIDIssueDate`, `EmiratesIDExpiryDate`, 
                                `BasicSalary`, `HousingAllowance`, `TransportationAllowance`, `Other`, 
                                `account_id`, `bank_id`, `Iban_Number`, `Bank_account_Number`, 
                                `Employee_Recivable_id`, `Accrued_Salaries_id`, `Acroal_Leave_Salary_id`, `Gratuit_id`,Petty_Cash_id,
                                `active`, `state`) 
                        VALUES(@code, @name, @birth_day, @Social_Status, @city_id, @address, @phone, @Email, 
                               @Social_Insurance_Number, @EmergencyName, @EmergencyAddress, @EmergencyPhone, 
                               @Relation, @PassportNumber, @CountryOfIssue, @PassportIssueDate, @PassportExpiryDate, 
                               @WorkContractNumber, @Position_id, @Department_id, @WorkContractType, @WorkDays, 
                               @workinghours, @ContractIssueDate, @ContractExpiryDate, @ResidencyFileNumber, 
                               @ResidencyIssuingAuthority, @ResidencyIssueDate, @ResidencyExpiryDate, 
                               @EmiratesIDFileNumber, @EmiratesIDIssuingAuthority, @EmiratesIDIssueDate, 
                               @EmiratesIDExpiryDate, @BasicSalary, @HousingAllowance, @TransportationAllowance, 
                               @Other, @account_id, @bank_id, @Iban_Number, @Bank_account_Number, 
                               @Employee_Recivable_id, @Accrued_Salaries_id, @Acroal_Leave_Salary_id, @Gratuit_id,@Petty_Cash_id, 
                               @active, 0);",
                           DBClass.CreateParameter("code", GenerateNextEmployeeCode()),
                           DBClass.CreateParameter("name", txtName.Text),
                           DBClass.CreateParameter("birth_day", "2000-01-01"),
                           DBClass.CreateParameter("Social_Status", ""),
                           DBClass.CreateParameter("city_id", 0),
                           DBClass.CreateParameter("address", ""),
                           DBClass.CreateParameter("phone", ""),
                           DBClass.CreateParameter("Email", ""),
                           DBClass.CreateParameter("Social_Insurance_Number", ""),
                           DBClass.CreateParameter("EmergencyName", ""),
                           DBClass.CreateParameter("EmergencyAddress", ""),
                           DBClass.CreateParameter("EmergencyPhone", ""),
                           DBClass.CreateParameter("Relation", ""),
                           DBClass.CreateParameter("PassportNumber", ""),
                           DBClass.CreateParameter("CountryOfIssue", "Albania"),
                           DBClass.CreateParameter("PassportIssueDate", "2000-01-01"),
                           DBClass.CreateParameter("PassportExpiryDate", "2000-01-01"),
                           DBClass.CreateParameter("WorkContractNumber", ""),
                           DBClass.CreateParameter("Position_id", cmbPosition.SelectedValue ?? 0),
                           DBClass.CreateParameter("Department_id", cmbDepartment.SelectedValue ?? 0),
                           DBClass.CreateParameter("WorkContractType", ""),
                           DBClass.CreateParameter("WorkDays", "25"),
                           DBClass.CreateParameter("workinghours", "8"),
                           DBClass.CreateParameter("ContractIssueDate", "2000-01-01"),
                           DBClass.CreateParameter("ContractExpiryDate", "2000-01-01"),
                           DBClass.CreateParameter("ResidencyFileNumber", ""),
                           DBClass.CreateParameter("ResidencyIssuingAuthority", ""),
                           DBClass.CreateParameter("ResidencyIssueDate", "2000-01-01"),
                           DBClass.CreateParameter("ResidencyExpiryDate", "2000-01-01"),
                           DBClass.CreateParameter("EmiratesIDFileNumber", ""),
                           DBClass.CreateParameter("EmiratesIDIssuingAuthority", ""),
                           DBClass.CreateParameter("EmiratesIDIssueDate", "2000-01-01"),
                           DBClass.CreateParameter("EmiratesIDExpiryDate", "2000-01-01"),
                           DBClass.CreateParameter("BasicSalary", txtSalary.Text),
                           DBClass.CreateParameter("HousingAllowance", "0"),
                           DBClass.CreateParameter("TransportationAllowance", "0"),
                           DBClass.CreateParameter("Other", "0"),
                           DBClass.CreateParameter("account_id", cmbAccountNameId),
                           DBClass.CreateParameter("bank_id", cmbBankNameId),
                           DBClass.CreateParameter("Iban_Number", ""),
                           DBClass.CreateParameter("Bank_account_Number", ""),
                           DBClass.CreateParameter("Employee_Recivable_id", cmbEmployeeReceivableId),
                           DBClass.CreateParameter("Accrued_Salaries_id", cmbAccruedSalariesId),
                           DBClass.CreateParameter("Acroal_Leave_Salary_id", cmbAccrualLeaveSalaryId),
                           DBClass.CreateParameter("Gratuit_id", cmbGratuityId),
                           DBClass.CreateParameter("Petty_Cash_id", cmbPettyCashId),
                           DBClass.CreateParameter("active", 0));

                    if (refId != 0)
                    {
                        Utilities.LogAudit(frmLogin.userId, "Insert Employee", "Employee", refId,
                            "Inserted Employee: " + txtName.Text + ", Code: " + EmployeeCode);

                        MessageBox.Show("Employee Added Successfully.");
                    }
                    else
                    {
                        string message = Utilities.LastLogError();
                        MessageBox.Show("Error Check your data" + message);
                    }
                }
                else
                {
                    //update
                    using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_employee where  Name = @name",
                    DBClass.CreateParameter("name", txtName.Text)))
                        if (reader.Read() && employeeId != int.Parse(reader["id"].ToString()))
                        {
                            MessageBox.Show("Employee Name Already Exists. Enter Another Name.");
                            return;
                        }
                    DBClass.ExecuteNonQuery(@"UPDATE `tbl_employee` SET
                        `code` = @code, `name` = @name, `birth_day` = @birth_day, `Social_Status` = @Social_Status,
                        `city_id` = @city_id, `address` = @address, `phone` = @phone, `Email` = @Email,
                        `Social_Insurance_Number` = @Social_Insurance_Number, `EmergencyName` = @EmergencyName,
                        `EmergencyAddress` = @EmergencyAddress, `EmergencyPhone` = @EmergencyPhone, `Relation` = @Relation,
                        `PassportNumber` = @PassportNumber, `CountryOfIssue` = @CountryOfIssue, `PassportIssueDate` = @PassportIssueDate,
                        `PassportExpiryDate` = @PassportExpiryDate, `WorkContractNumber` = @WorkContractNumber, `Position_id` = @Position_id,
                        `Department_id` = @Department_id, `WorkContractType` = @WorkContractType, `WorkDays` = @WorkDays,
                        `workinghours` = @workinghours, `ContractIssueDate` = @ContractIssueDate, `ContractExpiryDate` = @ContractExpiryDate,
                        `ResidencyFileNumber` = @ResidencyFileNumber, `ResidencyIssuingAuthority` = @ResidencyIssuingAuthority,
                        `ResidencyIssueDate` = @ResidencyIssueDate, `ResidencyExpiryDate` = @ResidencyExpiryDate,
                        `EmiratesIDFileNumber` = @EmiratesIDFileNumber, `EmiratesIDIssuingAuthority` = @EmiratesIDIssuingAuthority,
                        `EmiratesIDIssueDate` = @EmiratesIDIssueDate, `EmiratesIDExpiryDate` = @EmiratesIDExpiryDate,
                        `BasicSalary` = @BasicSalary, `HousingAllowance` = @HousingAllowance, `TransportationAllowance` = @TransportationAllowance,
                        `Other` = @Other, `account_id` = @account_id, `bank_id` = @bank_id, `Iban_Number` = @Iban_Number,
                        `Bank_account_Number` = @Bank_account_Number, `Employee_Recivable_id` = @Employee_Recivable_id,
                        `Accrued_Salaries_id` = @Accrued_Salaries_id, `Acroal_Leave_Salary_id` = @Acroal_Leave_Salary_id,
                        `Gratuit_id` = @Gratuit_id,Petty_Cash_id=@Petty_Cash_id, `active` = @active, `state` = 0 WHERE `id` = @id;",
                        DBClass.CreateParameter("id", employeeId),
                        DBClass.CreateParameter("code", EmployeeCode),
                        DBClass.CreateParameter("name", txtName.Text),
                           DBClass.CreateParameter("birth_day", "2000-01-01"),
                           DBClass.CreateParameter("Social_Status", ""),
                           DBClass.CreateParameter("city_id", 0),
                           DBClass.CreateParameter("address", ""),
                           DBClass.CreateParameter("phone", ""),
                           DBClass.CreateParameter("Email", ""),
                           DBClass.CreateParameter("Social_Insurance_Number", ""),
                           DBClass.CreateParameter("EmergencyName", ""),
                           DBClass.CreateParameter("EmergencyAddress", ""),
                           DBClass.CreateParameter("EmergencyPhone", ""),
                           DBClass.CreateParameter("Relation", ""),
                           DBClass.CreateParameter("PassportNumber", ""),
                           DBClass.CreateParameter("CountryOfIssue", "Albania"),
                           DBClass.CreateParameter("PassportIssueDate", "2000-01-01"),
                           DBClass.CreateParameter("PassportExpiryDate", "2000-01-01"),
                           DBClass.CreateParameter("WorkContractNumber", ""),
                           DBClass.CreateParameter("Position_id", cmbPosition.SelectedValue ?? 0),
                           DBClass.CreateParameter("Department_id", cmbDepartment.SelectedValue ?? 0),
                           DBClass.CreateParameter("WorkContractType", ""),
                           DBClass.CreateParameter("WorkDays", "25"),
                           DBClass.CreateParameter("workinghours", "8"),
                           DBClass.CreateParameter("ContractIssueDate", "2000-01-01"),
                           DBClass.CreateParameter("ContractExpiryDate", "2000-01-01"),
                           DBClass.CreateParameter("ResidencyFileNumber", ""),
                           DBClass.CreateParameter("ResidencyIssuingAuthority", ""),
                           DBClass.CreateParameter("ResidencyIssueDate", "2000-01-01"),
                           DBClass.CreateParameter("ResidencyExpiryDate", "2000-01-01"),
                           DBClass.CreateParameter("EmiratesIDFileNumber", ""),
                           DBClass.CreateParameter("EmiratesIDIssuingAuthority", ""),
                           DBClass.CreateParameter("EmiratesIDIssueDate", "2000-01-01"),
                           DBClass.CreateParameter("EmiratesIDExpiryDate", "2000-01-01"),
                           DBClass.CreateParameter("BasicSalary", txtSalary.Text),
                           DBClass.CreateParameter("HousingAllowance", "0"),
                           DBClass.CreateParameter("TransportationAllowance", "0"),
                           DBClass.CreateParameter("Other", "0"),
                           DBClass.CreateParameter("account_id", cmbAccountNameId),
                           DBClass.CreateParameter("bank_id", cmbBankNameId),
                           DBClass.CreateParameter("Iban_Number", ""),
                           DBClass.CreateParameter("Bank_account_Number", ""),
                           DBClass.CreateParameter("Employee_Recivable_id", cmbEmployeeReceivableId),
                           DBClass.CreateParameter("Accrued_Salaries_id", cmbAccruedSalariesId),
                           DBClass.CreateParameter("Acroal_Leave_Salary_id", cmbAccrualLeaveSalaryId),
                           DBClass.CreateParameter("Gratuit_id", cmbGratuityId),
                           DBClass.CreateParameter("Petty_Cash_id", cmbPettyCashId),
                           DBClass.CreateParameter("active", 0));

                    Utilities.LogAudit(frmLogin.userId, "Update Employee", "Employee", employeeId, GenerateNextEmployeeCode() + ", Updated Employee: " + txtName.Text + ", Code: " + EmployeeCode);

                    MessageBox.Show("Employee Updated Successfully.");
                }
            }
        }
        private string GenerateNextEmployeeCode()
        {
            int code;
            using (var reader = DBClass.ExecuteReader("SELECT MAX(CAST(code AS UNSIGNED)) AS lastCode FROM tbl_employee"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                    code = int.Parse(reader["lastCode"].ToString()) + 1;
                else
                    code = 30001;
            }
            return code.ToString("D5");
        }
        private bool validateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) {
                MessageBox.Show("enter Name");
                return false;
            }
            if (cmbDepartment.SelectedValue == null)
            {
                MessageBox.Show("Please select a department");
                return false;
            }
            if (cmbPosition.SelectedValue == null)
            {
                MessageBox.Show("Please select a position");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSalary.Text))
                txtSalary.Text = "0";

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmViewDepartments frm = new frmViewDepartments();
            frm.ShowDialog();

            BindCombos.PopulateDepartments(cmbDepartment);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmViewPosition frm = new frmViewPosition();
            frm.ShowDialog();

            BindCombos.PopulatePositions(cmbPosition, Convert.ToInt32(cmbDepartment.SelectedValue));
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbDepartment.Focused)
                return;

            BindCombos.PopulatePositions(cmbPosition, Convert.ToInt32(cmbDepartment.SelectedValue));
        }
    }
}
