using CrystalDecisions.Shared.Json;
using DocumentFormat.OpenXml.Spreadsheet;
using Google.Protobuf.Collections;
using Guna.UI2.WinForms;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using PdfSharp.Pdf.Content.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace YamyProject.UI.Project_Management
{
    public partial class frmProjectsManage : Form
    {
        //private EventHandler customerUpdatedHandler;
        private int id;
        public frmProjectsManage(int _id = 0)
        {
            InitializeComponent();
            headerUC1.FormText = "Projects";
            //customerUpdatedHandler = (sender, args) => BindCombos.PopulateCustomers(cmbCustomer);
            //EventHub.Customer += customerUpdatedHandler;
            LocalizationManager.LocalizeForm(this);
            this.id = _id;
        }

        private void loadCustomers()
        {
            BindCombos.PopulateCustomers(cmbCustomer);
            BindCombos.PopulateCustomers(cmbSearchCustomer);
        }

        private void frmProjectsManage_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateProjects(cmbProject4Account);
            BindCombos.PopulateProjects(cmbProject4Attachments);
            BindCombos.PopulateProjects(cmbProject4Engineers);
            BindCombos.PopulateProjects(cmbProject4Location);
            BindCombos.PopulateProjects(cmbProject4SubContractor);
            loadCustomers();
            LoadAccountsCombo();
            LoadSubContractorCombo();
            LoadEngineersCombo();

            var generalS = Utilities.GeneralSettingsState("PROJECT OPTION");
            if (!string.IsNullOrEmpty(generalS) & int.Parse(generalS) > 0)
            {
                IsProjectOption = true;
            }
            else
            {
                IsProjectOption = false;
            }

            if (id != 0)
            {
                using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT a.id,a.code,a.name,a.name_ar,category,description,start_date,a.end_date,a.country_id,a.city_id,a.emirate,a.`status`,a.`type`,a.extend_delay,a.execution_period_months,a.customer,a.contractor,a.consultant,a.location,a.details,a.contract_value,a.additional_value,a.deduction_value,a.total_value,a.billed_to_date,a.expenses,a.balance FROM tbl_projects a where a.id = @id",
                      DBClass.CreateParameter("id", id)))
                    if (reader.Read())
                    {
                        txtCode.Text = reader["code"].ToString();
                        txtProjectName.Text = reader["name"].ToString();
                        txtProjectNameArabic.Text = reader["name_ar"].ToString();
                        txtDescription.Text = reader["description"].ToString();
                        dtStart.Value = reader["start_date"] != DBNull.Value ? Convert.ToDateTime(reader["start_date"]) : DateTime.Now;
                        dtEnd.Value = reader["end_date"] != DBNull.Value ? Convert.ToDateTime(reader["end_date"]) : DateTime.Now;
                            cmbEmirate.SelectedItem = reader["emirate"].ToString();
                        cmbStatus.SelectedItem = reader["status"].ToString();
                        cmbProjectType.SelectedItem = reader["type"].ToString();
                        dtExtendDelay.Value = reader["extend_delay"] != DBNull.Value ? Convert.ToDateTime(reader["extend_delay"]) : DateTime.Now;
                        txtExecutionPeriod.Text = reader["execution_period_months"].ToString();
                        cmbCustomer.SelectedValue = reader["customer"].ToString();
                        txtContractor.Text = reader["contractor"].ToString();
                        txtConsultant.Text = reader["consultant"].ToString();
                        txtLocation.Text = reader["location"].ToString();
                        txtDetails.Text = reader["details"].ToString();
                        txtContractValue.Text = reader["contract_value"].ToString();
                        txtAdditionalValue.Text = reader["additional_value"].ToString();
                        txtDeductionValue.Text = reader["deduction_value"].ToString();
                        txtprojectTotalvalue.Text = reader["total_value"].ToString();
                        txtBilledToDate1.Text = reader["billed_to_date"].ToString();
                        txtExpenses.Text = reader["expenses"].ToString();
                        txtBalance1.Text = reader["balance"].ToString();

                    }
            }
            else
            {
                txtCode.Text = GenerateNextCode();
            }
        }

        private string GenerateNextCode()
        {
            object result = DBClass.ExecuteScalar("SELECT LPAD(MAX(CAST(code AS UNSIGNED)), 4, '0') FROM tbl_projects;");
            int nextId = (result == DBNull.Value || result == null) ? 1 : Convert.ToInt32(result) + 1;
            string formattedId = nextId.ToString().PadLeft(3, '0');
            return formattedId;
        }

        private void frmProjectsManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            //EventHub.Customer -= customerUpdatedHandler;
        }


        bool IsProjectOption = false;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProjectName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Name First");
                return;
            }

            MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_projects where name = @name",
            DBClass.CreateParameter("name", txtProjectName.Text));
            if (reader.Read())
            {
                if (id == 0 || (id != int.Parse(reader["id"].ToString())))
                {
                    MessageBox.Show(" Name Already In Use. Enter Another Name.");
                    return;
                }
            }


            if (id == 0)
            {
                int projectId = Convert.ToInt32(DBClass.ExecuteScalar(@"
                                                    INSERT INTO tbl_projects (code, name, name_ar, category, description, start_date, end_date, country_id, city_id, emirate, status, type, extend_delay, execution_period_months, customer, contractor, consultant, location, details, contract_value, additional_value, deduction_value, total_value, billed_to_date, expenses, balance) 
                                                    VALUES (@code, @name, @name_ar, @category, @description, @start_date, @end_date, @country_id, @city_id, @emirate, @status, @type, @extend_delay, @execution_period_months, @customer, @contractor, @consultant, @location, @details, @contract_value, @additional_value, @deduction_value, @total_value, @billed_to_date, @expenses, @balance);
                                                    SELECT LAST_INSERT_ID();",
                                                    DBClass.CreateParameter("@code", txtCode.Text),
                                                    DBClass.CreateParameter("@name", txtProjectName.Text),
                                                    DBClass.CreateParameter("@name_ar", txtProjectNameArabic.Text),
                                                    DBClass.CreateParameter("@category", ""),
                                                    DBClass.CreateParameter("@description", txtDescription.Text),
                                                    DBClass.CreateParameter("@start_date", dtStart.Value.Date),
                                                    DBClass.CreateParameter("@end_date", dtEnd.Value.Date),
                                                    DBClass.CreateParameter("@country_id", 0),
                                                    DBClass.CreateParameter("@city_id", 0),
                                                    DBClass.CreateParameter("@emirate", cmbEmirate.SelectedItem == null ? "" : cmbEmirate.SelectedItem),
                                                    DBClass.CreateParameter("@status", cmbStatus.SelectedItem),
                                                    DBClass.CreateParameter("@type", cmbProjectType.SelectedItem),
                                                    DBClass.CreateParameter("@extend_delay", dtExtendDelay.Value.Date),
                                                    DBClass.CreateParameter("@execution_period_months", string.IsNullOrWhiteSpace(txtExecutionPeriod.Text) ? 0 : Convert.ToInt32(txtExecutionPeriod.Text)),
                                                    DBClass.CreateParameter("@customer", cmbCustomer.SelectedValue),
                                                    DBClass.CreateParameter("@contractor", txtContractor.Text),
                                                    DBClass.CreateParameter("@consultant", txtConsultant.Text),
                                                    DBClass.CreateParameter("@location", txtLocation.Text),
                                                    DBClass.CreateParameter("@details", txtDetails.Text),
                                                    DBClass.CreateParameter("@contract_value", string.IsNullOrWhiteSpace(txtContractValue.Text) ? 0 : Convert.ToDecimal(txtContractValue.Text)),
                                                    DBClass.CreateParameter("@additional_value", string.IsNullOrWhiteSpace(txtAdditionalValue.Text) ? 0 : Convert.ToDecimal(txtAdditionalValue.Text)),
                                                    DBClass.CreateParameter("@deduction_value", string.IsNullOrWhiteSpace(txtDeductionValue.Text) ? 0 : Convert.ToDecimal(txtDeductionValue.Text)),
                                                    DBClass.CreateParameter("@total_value", string.IsNullOrWhiteSpace(txtprojectTotalvalue.Text) ? 0 : Convert.ToDecimal(txtprojectTotalvalue.Text)),
                                                    DBClass.CreateParameter("@billed_to_date", string.IsNullOrWhiteSpace(txtBilledToDate1.Text) ? 0 : Convert.ToDecimal(txtBilledToDate1.Text)),
                                                    DBClass.CreateParameter("@expenses", string.IsNullOrWhiteSpace(txtExpenses.Text) ? 0 : Convert.ToDecimal(txtExpenses.Text)),
                                                    DBClass.CreateParameter("@balance", string.IsNullOrWhiteSpace(txtBalance1.Text) ? 0 : Convert.ToDecimal(txtBalance1.Text))
                                                ));

                if (IsProjectOption)
                {
                    var mainId = DBClass.ExecuteScalar(@"INSERT INTO tbl_cost_center (name, code, project_id)
                                  VALUES (@name, @code, @project_id);SELECT LAST_INSERT_ID();",
                            DBClass.CreateParameter("name", txtProjectName.Text),
                            DBClass.CreateParameter("code", txtCode.Text),
                            DBClass.CreateParameter("project_id", projectId));

                    DBClass.ExecuteNonQuery(@"INSERT INTO tbl_sub_cost_center (code, name, main_id, project_id)
                                  VALUES (@code, @name, @main_id, @project_id);",
                            DBClass.CreateParameter("code", txtCode.Text),
                            DBClass.CreateParameter("name", txtProjectName.Text),
                            DBClass.CreateParameter("project_id", projectId),
                            DBClass.CreateParameter("main_id", mainId.ToString()));
                }

                Utilities.LogAudit(frmLogin.userId, "Add Project", "Project", projectId, "Added New Project: " + txtProjectName.Text + " (Code: " + txtCode.Text + ")");
                SaveSite(projectId, txtLocation.Text);

                MessageBox.Show("Project Saved");
            }
            else
            {
                DBClass.ExecuteNonQuery(@"
                    UPDATE tbl_projects
                    SET code = @code, name = @name, name_ar = @name_ar, category = @category, description = @description, 
                        start_date = @start_date, end_date = @end_date, country_id  = @country_id, city_id = @city_id,emirate = @emirate , status = @status, type = @type, extend_delay = @extend_delay, execution_period_months = @execution_period_months, 
                        customer = @customer, contractor = @contractor, consultant = @consultant, location = @location, details = @details, contract_value = @contract_value, additional_value = @additional_value, deduction_value = @deduction_value, total_value = @total_value, billed_to_date = @billed_to_date, expenses = @expenses, balance = @balance
                    WHERE id = @id;",
                    DBClass.CreateParameter("@code", txtCode.Text),
                    DBClass.CreateParameter("@name", txtProjectName.Text),
                    DBClass.CreateParameter("@name_ar", txtProjectNameArabic.Text),
                    DBClass.CreateParameter("@category", ""),
                    DBClass.CreateParameter("@description", txtDescription.Text),
                    DBClass.CreateParameter("@start_date", dtStart.Value.Date),
                    DBClass.CreateParameter("@end_date", dtEnd.Value.Date),
                    DBClass.CreateParameter("@country_id", 0),
                    DBClass.CreateParameter("@city_id", 0),
                    DBClass.CreateParameter("@emirate", cmbEmirate.SelectedItem == null ? "" : cmbEmirate.SelectedItem),
                    DBClass.CreateParameter("@status", cmbStatus.SelectedItem),
                    DBClass.CreateParameter("@type", cmbProjectType.SelectedItem),
                    DBClass.CreateParameter("@extend_delay", dtExtendDelay.Value.Date),
                    DBClass.CreateParameter("@execution_period_months", string.IsNullOrWhiteSpace(txtExecutionPeriod.Text) ? 0 : Convert.ToInt32(txtExecutionPeriod.Text)),
                    DBClass.CreateParameter("@customer", cmbCustomer.SelectedValue),
                    DBClass.CreateParameter("@contractor", txtContractor.Text),
                    DBClass.CreateParameter("@consultant", txtConsultant.Text),
                    DBClass.CreateParameter("@location", txtLocation.Text),
                    DBClass.CreateParameter("@details", txtDetails.Text),
                    DBClass.CreateParameter("@contract_value", string.IsNullOrWhiteSpace(txtContractValue.Text) ? 0 : Convert.ToDecimal(txtContractValue.Text)),
                    DBClass.CreateParameter("@additional_value", string.IsNullOrWhiteSpace(txtAdditionalValue.Text) ? 0 : Convert.ToDecimal(txtAdditionalValue.Text)),
                    DBClass.CreateParameter("@deduction_value", string.IsNullOrWhiteSpace(txtDeductionValue.Text) ? 0 : Convert.ToDecimal(txtDeductionValue.Text)),
                    DBClass.CreateParameter("@total_value", string.IsNullOrWhiteSpace(txtprojectTotalvalue.Text) ? 0 : Convert.ToDecimal(txtprojectTotalvalue.Text)),
                    DBClass.CreateParameter("@billed_to_date", string.IsNullOrWhiteSpace(txtBilledToDate1.Text) ? 0 : Convert.ToDecimal(txtBilledToDate1.Text)),
                    DBClass.CreateParameter("@expenses", string.IsNullOrWhiteSpace(txtExpenses.Text) ? 0 : Convert.ToDecimal(txtExpenses.Text)),
                    DBClass.CreateParameter("@balance", string.IsNullOrWhiteSpace(txtBalance1.Text) ? 0 : Convert.ToDecimal(txtBalance1.Text)),
                    DBClass.CreateParameter("@id", id)
                );


                Utilities.LogAudit(frmLogin.userId, "Update Project", "Project", id, "Updated Project: " + txtProjectName.Text);

                if (IsProjectOption)
                {
                    int cId = 0;
                    using (MySqlDataReader reader0 = DBClass.ExecuteReader("select * from tbl_sub_cost_center where name = @name",
                        DBClass.CreateParameter("name", txtProjectName.Text)))
                        if (reader0.Read())
                        {
                            cId = int.Parse(reader0["id"].ToString());

                            DBClass.ExecuteNonQuery("update tbl_sub_cost_center set name=@name where id = @id",
                                DBClass.CreateParameter("id", cId),
                            DBClass.CreateParameter("name", txtProjectName.Text));
                        }
                }

                SaveSite(id, txtLocation.Text);

                MessageBox.Show("Project Edited");
            }
        }

        private void SaveSite(int pId, string location)
        {
            if (!string.IsNullOrEmpty(location))
            {
                MySqlDataReader reader1 = DBClass.ExecuteReader("select * from tbl_project_sites where name = @name",
                DBClass.CreateParameter("name", location));
                if (reader1.Read())
                {
                    if (id != int.Parse(reader1["id"].ToString()))
                    {
                        return;
                    }
                }

                object result = DBClass.ExecuteScalar("SELECT LPAD(MAX(CAST(code AS UNSIGNED)), 3, '0') FROM tbl_project_sites;");
                int nextId = (result == DBNull.Value || result == null) ? 1 : Convert.ToInt32(result) + 1;
                string formattedId = nextId.ToString().PadLeft(3, '0');

                int refId = DBClass.ExecuteNonQuery(@"INSERT INTO tbl_project_sites (code, name,location_id,plot_number,address) VALUES (@code, @name,@locationId,@plotNumber,@address);",
                            DBClass.CreateParameter("code", formattedId),
                            DBClass.CreateParameter("name", location),
                            DBClass.CreateParameter("locationId", pId),
                            DBClass.CreateParameter("plotNumber", ""),
                            DBClass.CreateParameter("address", ""));
                Utilities.LogAudit(frmLogin.userId, "Add Project Site", "Project Site", refId, "Added Project Site: " + location);
            }
        }
        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedValue == null)
            {
                return;
            }
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_customer where id = " + cmbCustomer.SelectedValue.ToString()))
                if (reader.Read())
                {
                    txtCustomerCode.Text = reader["code"].ToString();
                }
                else
                    txtCustomerCode.Text = "";
        }

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_customer where code =@code",
                DBClass.CreateParameter("code", txtCustomerCode.Text)))
                if (reader.Read())
                    cmbCustomer.SelectedValue = int.Parse(reader["id"].ToString());

            if (txtCustomerCode.Focused)
            {
                string input = txtCustomerCode.Text.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    lstAccountSuggestions.Visible = false;
                    return;
                }
                string query = @"SELECT code, name FROM tbl_customer 
                         WHERE code LIKE @search OR name LIKE @search LIMIT 20";

                DataTable dt = DBClass.ExecuteDataTable(query, DBClass.CreateParameter("@search", "%" + input + "%"));

                lstAccountSuggestions.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    lstAccountSuggestions.Items.Add(new ItemSuggestion { Code = row["code"].ToString(), Name = row["name"].ToString() });
                }
                if (lstAccountSuggestions.Items.Count > 0)
                {
                    Point locationOnForm = txtCustomerCode.Parent.PointToScreen(txtCustomerCode.Location);
                    Point locationRelativeToForm = this.PointToClient(locationOnForm);

                    lstAccountSuggestions.SetBounds(
                        locationRelativeToForm.X,
                        locationRelativeToForm.Y + txtCustomerCode.Height,
                        txtCustomerCode.Width + 100,
                        120
                    );

                    lstAccountSuggestions.Tag = txtCustomerCode;
                    lstAccountSuggestions.Visible = true;
                    lstAccountSuggestions.BringToFront();
                }
                else
                {
                    lstAccountSuggestions.Visible = false;
                }
            }
        }

        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_customer where code =@code",
            DBClass.CreateParameter("code", txtCustomerCode.Text)))
                if (!reader.Read())
                    cmbCustomer.SelectedIndex = -1;

            BeginInvoke((Action)(() =>
            {
                if (!lstAccountSuggestions.Focused)
                    lstAccountSuggestions.Visible = false;
            }));
        }

        private void lstAccountSuggestions_Click(object sender, EventArgs e)
        {
            if (lstAccountSuggestions.SelectedItem == null)
                return;

            string selected = lstAccountSuggestions.SelectedItem.ToString();

            string selectedCode = "";
            string selectedName = "";

            if (lstAccountSuggestions.SelectedItem is ItemSuggestion item)
            {
                selectedCode = item.Code;
                selectedName = item.Name;
            }

            if (lstAccountSuggestions.Tag is Guna2TextBox gunaTextBox)
            {
                gunaTextBox.Text = selectedCode;
                gunaTextBox.Focus();
                gunaTextBox.SelectionStart = gunaTextBox.Text.Length;

                if (gunaTextBox == txtCustomerCode)
                {
                    using (MySqlDataReader reader = DBClass.ExecuteReader("select id from tbl_customer where code =@code",
                        DBClass.CreateParameter("code", selectedCode)))
                        if (reader.Read())
                            cmbCustomer.SelectedValue = int.Parse(reader["id"].ToString());
                }
            }

            lstAccountSuggestions.Visible = false;
        }

        private void txtContractValue_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalValue();
        }

        private void CalculateTotalValue()
        {
            decimal contractValue = 0, additionalValue = 0, deductionValue = 0;
            if(!string.IsNullOrEmpty(txtContractValue.Text))
                decimal.TryParse(txtContractValue.Text, out contractValue);
            if (!string.IsNullOrEmpty(txtAdditionalValue.Text))
                decimal.TryParse(txtAdditionalValue.Text, out additionalValue);
            if (!string.IsNullOrEmpty(txtDeductionValue.Text))
                decimal.TryParse(txtDeductionValue.Text, out deductionValue);

            decimal totalValue = contractValue + additionalValue - deductionValue;
            txtprojectTotalvalue.Text = totalValue.ToString("0.##");
        }

        private void txtAdditionalValue_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalValue();
        }

        private void txtDeductionValue_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalValue();
        }

        private void cmbProject4Account_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbProject4Account.SelectedValue == null)
            {
                return;
            }

            LoadAccountData();
        }
        private void LoadAccountsCombo()
        {
            DataTable dtAccounts = DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_coa_level_4 ORDER BY name");

            DataGridViewComboBoxColumn col =
                (DataGridViewComboBoxColumn)dgvAccounts.Columns["colMainAccount"];

            col.DataSource = dtAccounts;
            col.DisplayMember = "name";
            col.ValueMember = "id";
        }
        private void LoadAccountData()
        {
            dgvAccounts.Rows.Clear();
            /*
             * tbl_projects_accounts` (
                          `id` int NOT NULL AUTO_INCREMENT,
                          `name` VARCHAR(3250) NOT NULL DEFAULT '',
                          `project_id` INT(10) NOT NULL DEFAULT '0',
                          `account_id`
             */
            bool isFirst = true;
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT pa.id,pa.name,pa.project_id,pa.account_id,ac.name account,ac.code,ac.name AS NameAr FROM tbl_projects_accounts pa INNER JOIN  tbl_coa_level_4 ac ON ac.id = pa.account_id where pa.project_id = @id",
                DBClass.CreateParameter("id", cmbProject4Account.SelectedValue)))
                while (reader.Read())
                {
                    // AccountID(ComboBox i want to load all account before but her only set id dataset ValueMember = "id" and displayMember = "name")
                    // Assuming dgvAccounts has columns: Id, AccountId, Code(TextBox), Name(textbox), Name-Arabic(textbox)
                    // colId,colCheck,colCategory,colMainAccount,colCode,colName,colNameArabic
                    // dgvAccounts.Rows.Add(reader["id"].ToString(), reader["name"].ToString(), reader["account_id"].ToString());
                    int rowIndex = dgvAccounts.Rows.Add();
                    DataGridViewRow row = dgvAccounts.Rows[rowIndex];
                    row.Cells["colId"].Value = reader["id"].ToString();
                    row.Cells["colCheck"].Value = true;
                    row.Cells["colCategory"].Value = reader["name"].ToString();
                    DataGridViewComboBoxCell comboCellCostCenter = row.Cells["colMainAccount"] as DataGridViewComboBoxCell;
                    if (comboCellCostCenter != null && reader["account_id"].ToString() != "0")
                    {
                        comboCellCostCenter.Value = int.Parse(reader["account_id"].ToString());
                        //row.Cells["colMainAccount"].Value = reader["account_id"].ToString();
                    }
                    row.Cells["colCode"].Value = reader["code"].ToString();
                    row.Cells["colName"].Value = reader["account"].ToString();
                    row.Cells["colNameArabic"].Value = reader["NameAr"].ToString();

                    isFirst = false;
                }

            if (isFirst)
            {
                dgvAccounts.Rows.Add(
                    1,
                    false,
                    "IncomeAccount",
                    null,
                    "",
                    "",
                    ""
                    );
                dgvAccounts.Rows.Add(
                    2,
                    false,
                    "ExpensesAccount",
                    null,
                    "",
                    "",
                    ""
                    );
                dgvAccounts.Rows.Add(
                    3,
                    false,
                    "RetentionAccount",
                    null,
                    "",
                    "",
                    ""
                    );
                dgvAccounts.Rows.Add(
                    4,
                    false,
                    "DownpaymentAccount",
                    null,
                    "",
                    "",
                    ""
                    );
                dgvAccounts.Rows.Add(
                    5,
                    false,
                    "Other1",
                    null,
                    "",
                    "",
                    ""
                    );
                dgvAccounts.Rows.Add(
                    6,
                    false,
                    "Other2",
                    null,
                    "",
                    "",
                    ""
                    );
            }
            else {
                        int rowCount = dgvAccounts.Rows.Count > 0 ? dgvAccounts.Rows.Count : 0;
                        dgvAccounts.Rows.Add(
                            rowCount + 1,
                            false,
                            "Other1",
                            null,
                            "",
                            "",
                            ""
                            );
                        dgvAccounts.Rows.Add(
                            rowCount + 2,
                            false,
                            "Other2",
                            null,
                            "",
                            "",
                            ""
                            );
                    }
        }

        private void txtExecutionPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtContractValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtAdditionalValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtDeductionValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void dgvAccounts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if(dgvAccounts.CurrentCell.ColumnIndex == dgvAccounts.Columns["colMainAccount"].Index)
            {
                if (e.Control is ComboBox cb)
                {
                    cb.SelectionChangeCommitted -= AccountCombo_SelectionChangeCommitted;
                    cb.SelectionChangeCommitted += AccountCombo_SelectionChangeCommitted;
                }
            }
        }
        private void AccountCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb != null && dgvAccounts.CurrentRow != null)
            {
                int selectedId = Convert.ToInt32(cb.SelectedValue);

                
                if (selectedId > 0)
                {
                    using(MySqlDataReader reader = DBClass.ExecuteReader("SELECT code, name FROM tbl_coa_level_4 WHERE id = @id",
                        DBClass.CreateParameter("id", selectedId)))
                    {
                        if (reader.Read())
                        {
                            dgvAccounts.CurrentRow.Cells["colCode"].Value = reader["code"].ToString();
                            dgvAccounts.CurrentRow.Cells["colName"].Value = reader["name"].ToString();
                            dgvAccounts.CurrentRow.Cells["colNameArabic"].Value = reader["name"].ToString();
                        }
                    }
                }
            }
        }

        private void btnCreateAccounts_Click(object sender, EventArgs e)
        {
            if(dgvAccounts.Rows.Count == 0 || cmbProject4Account.SelectedValue == null)
            {
                MessageBox.Show("Please select a project and ensure there are accounts listed.");
                return;
            }

                foreach (DataGridViewRow row in dgvAccounts.Rows)
                {
                    if (row.IsNewRow) continue;
    
                    int accountId = row.Cells["colMainAccount"].Value != null ? Convert.ToInt32(row.Cells["colMainAccount"].Value) : 0;
                    string category = row.Cells["colCategory"].Value?.ToString() ?? "";
                    string name = row.Cells["colName"].Value?.ToString() ?? "";
    
                    if (accountId > 0)
                    {
                        DBClass.ExecuteNonQuery(@"INSERT INTO tbl_projects_accounts (name, project_id, account_id) 
                                                VALUES (@name, @project_id, @account_id);",
                            DBClass.CreateParameter("name", category),
                            DBClass.CreateParameter("project_id", cmbProject4Account.SelectedValue),
                            DBClass.CreateParameter("account_id", accountId));
                    }
            }
        }

        private void LoadSubContractorCombo()
        {
            DataTable dtSubcontractor = DBClass.ExecuteDataTable("SELECT name , id FROM tbl_vendor WHERE type = 'Subcontractor'");

            DataGridViewComboBoxColumn col =
                (DataGridViewComboBoxColumn)dgvSubcontractor.Columns["colSubContractors"];

            col.DataSource = dtSubcontractor;
            col.DisplayMember = "name";
            col.ValueMember = "id";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            id = 0;
            ClearData();
        }

        private void ClearData()
        {
            txtAdditionalValue.Text = "0";
            txtAttachSearch.Text = "";
            txtBalance1.Text = "0";
            txtBalance2.Text = "0";
            txtBilledToDate1.Text = "0";
            txtBilledToDate2.Text = "0";
            txtContractValue.Text = "0";
            txtContractor.Text = "";
            txtConsultant.Text = "";
            txtCustomerCode.Text = "";
            txtCode.Text = GenerateNextCode();
            txtDeductionValue.Text = "0";
            txtDetails.Text = "";
            txtDescription.Text = "";
            txtExecutionPeriod.Text = "0";
            txtExpenses.Text = "0";
            txtFilePath.Text = "";
            txtLocation.Text = "";
            txtProjectLocation.Text = "";
            txtProjectName.Text = "";
            txtProjectNameArabic.Text = "";
            txtprojectTotalvalue.Text = "0";
            txtSearchCode.Text = "";
            txtSearchName.Text = "";
            txtTotalValueSummary.Text = "0";

            //cmbCustomer.SelectedIndex = -1;
            //cmbEmirate.SelectedIndex = -1;
            //cmbProject4Account.SelectedIndex = -1;
            //cmbProject4Attachments.SelectedIndex = -1;
            //cmbProject4Engineers.SelectedIndex = -1;
            //cmbProject4Location.SelectedIndex = -1;
            //cmbProject4SubContractor.SelectedIndex = -1;
            //cmbProjectType.SelectedIndex = -1;
            //cmbSearchCustomer.SelectedIndex = -1;
            //cmbSearchStatus.SelectedIndex = -1;
            //cmbStatus.SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            id = 0;
            ClearData();
        }

        private void btnAttachNew_Click(object sender, EventArgs e)
        {
            ClearAttach();
        }

        private void ClearAttach()
        {
            cmbProject4Attachments.SelectedIndex = -1;
            txtAttachSearch.Text = "";
            txtFilePath.Text = "";
            txtDescription.Text = "";
        }

        private void btnAttachClear_Click(object sender, EventArgs e)
        {
            ClearAttach();
        }

        private void btnAttachSave_Click(object sender, EventArgs e)
        {
            if(txtFilePath.Text == "" || cmbProject4Attachments.SelectedValue == null)
            {
                MessageBox.Show("Please select a project and file to attach.");
                return;
            }

            if(cmbProject4Attachments.SelectedValue == null)
            {
                MessageBox.Show("Please select a project to attach the file to.");
                return;
            }
            if(id == 0)
            {
                MessageBox.Show("Please save the project before adding attachments.");
                return;
            }
            if(cmbProject4Attachments.SelectedValue == null || cmbProject4Attachments.SelectedValue.ToString() == "0" || cmbProject4Attachments.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Please select a valid project to attach the file to.");
                return;
            }

            if (!string.IsNullOrEmpty(txtFilePath.Text))
            {
                int pId = Convert.ToInt32(cmbProject4Attachments.SelectedValue);
                AddFileData(pId);
                LoadAttachFile();
            }
        }
        private void AddFileData(int fId)
        {
            AttachmentManager.SaveAttachment(
                    "PROJECTS",
                    fId,
                    openFileDialog1.FileName
                );
        }
        private void btnAttachSearch_Click(object sender, EventArgs e)
        {
            LoadAttachFileByName();
        }

        private void LoadAttachFileByName()
        {
            // This method can be implemented to load vouchers if needed tbl_attachments
            dgvAttachments.Rows.Clear();
            string sql = @"SELECT attachment_id, reference_type, reference_id, file_name, file_type, file_data, uploaded_on FROM tbl_attachments where reference_type='PROJECTS' and file_name like '%@search%' ORDER BY uploaded_on DESC";
            using (MySqlDataReader reader = DBClass.ExecuteReader(sql, DBClass.CreateParameter("@search", txtAttachSearch.Text)))
            {
                while (reader.Read())
                {
                    //vId, vVoucherType, vrefId, vFileName, vFileType, vAdded
                    dgvAttachments.Rows.Add(
                        reader["attachment_id"],
                        reader["reference_type"],
                        reader["file_name"]
                    );
                }
            }
            if (dgvAttachments.Rows != null && dgvAttachments.Rows.Count > 0)
            {
                AddViewDocImageColumn();
            }
        }

        private void cmbProject4Attachments_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAttachFile();
        }

        private void LoadAttachFile()
        {
            // This method can be implemented to load vouchers if needed tbl_attachments
            dgvAttachments.Rows.Clear();
            string sql = @"SELECT attachment_id, reference_type, reference_id, file_name, file_type, file_data, uploaded_on FROM tbl_attachments where reference_type='PROJECTS' and reference_id = @refId ORDER BY uploaded_on DESC";
            using (MySqlDataReader reader = DBClass.ExecuteReader(sql, DBClass.CreateParameter("@refId", cmbProject4Attachments.SelectedValue)))
            {
                while (reader.Read())
                {
                    //vId, vVoucherType, vrefId, vFileName, vFileType, vAdded
                    dgvAttachments.Rows.Add(
                        reader["attachment_id"],
                        reader["reference_type"],
                        reader["file_name"]
                    );
                }
            }
            if (dgvAttachments.Rows != null && dgvAttachments.Rows.Count > 0)
            {
                AddViewDocImageColumn();
            }
        }
        private void AddViewDocImageColumn()
        {
            if (!dgvAttachments.Columns.Contains("ViewDoc"))
            {
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                imgColumn.Name = "ViewDoc";
                imgColumn.HeaderText = "View Doc";
                imgColumn.Image = Properties.Resources.doc_icon; // <-- your image here
                imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // fit nicely
                dgvAttachments.Columns.Add(imgColumn);
            }
        }
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void cmbProject4SubContractor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProject4SubContractor.SelectedValue == null)
            {
                return;
            }

            LoadSubContractor();
        }

        private void LoadSubContractor()
        {
            dgvSubcontractor.Rows.Clear();
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT * FROM tbl_subcontractors WHERE project_id = @projectId",
                DBClass.CreateParameter("projectId", cmbProject4SubContractor.SelectedValue)))
            {
                while (reader.Read())
                {
                    int rowIndex = dgvSubcontractor.Rows.Add();
                    DataGridViewRow row = dgvSubcontractor.Rows[rowIndex];
                    DataGridViewComboBoxCell comboCellCostCenter = row.Cells["colSubContractors"] as DataGridViewComboBoxCell;
                    if (comboCellCostCenter != null && reader["subcontractor_id"].ToString() != "0")
                    {
                        comboCellCostCenter.Value = int.Parse(reader["subcontractor_id"].ToString());
                    }
                    row.Cells["colSubCode"].Value = reader["code"].ToString();
                    row.Cells["colSubContractNo"].Value = reader["contact_no"].ToString();
                    row.Cells["colSubContractValue"].Value = reader["contract_value"].ToString();
                    row.Cells["colSubContractDate"].Value = reader["contract_date"] != DBNull.Value ? Convert.ToDateTime(reader["contract_date"]).ToString("yyyy-MM-dd") : "";
                    row.Cells["colSubContractPeriod"].Value = reader["contract_period"].ToString();
                    row.Cells["colSubWorks"].Value = reader["works"].ToString();
                    row.Cells["colSubWorkEn"].Value = reader["worksEn"].ToString();
                }
            }
        }

        private void dgvSubcontractor_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //,colSubContractors,colSubCode,colSubContractNo,colSubContractValue,colSubContractDate,colSubContractPeriod,colSubWorks,colSubWorkEn
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(cmbProject4SubContractor.SelectedValue == null)
            {
                MessageBox.Show("Please select a project to add subcontractors to.");
                return;
            }   
            if (dgvSubcontractor.Rows.Count > 0)
            {
                //delete if existing engineers for the project before adding new ones
                DBClass.ExecuteNonQuery("DELETE FROM tbl_subcontractors WHERE project_id = @project_id",
                    DBClass.CreateParameter("project_id", cmbProject4Engineers.SelectedValue)
                    );

                foreach (DataGridViewRow row in dgvSubcontractor.Rows)
                {
                    if (row.IsNewRow) continue;
                    //colSubContractors,colSubCode,colSubContractNo,colSubContractValue,colSubContractDate,colSubContractPeriod,colSubWorks,colSubWorkEn
                    DataGridViewComboBoxCell comboCellSubContractor = row.Cells["colSubContractors"] as DataGridViewComboBoxCell;
                    if (comboCellSubContractor != null && comboCellSubContractor.Value != null)
                    {
                        int subcontractorId = Convert.ToInt32(comboCellSubContractor.Value);
                        string subCode = row.Cells["colSubCode"].Value?.ToString() ?? "";
                        string subContactNo = row.Cells["colSubContractNo"].Value?.ToString() ?? "";
                        decimal subContractValue = 0;
                        decimal.TryParse(row.Cells["colSubContractValue"].Value?.ToString(), out subContractValue);
                        DateTime subContractDate = DateTime.Now;
                        DateTime.TryParse(row.Cells["colSubContractDate"].Value?.ToString(), out subContractDate);
                        string subContractPeriod = row.Cells["colSubContractPeriod"].Value?.ToString() ?? "";
                        string subWorks = row.Cells["colSubWorks"].Value?.ToString() ?? "";
                        string subWorksEn = row.Cells["colSubWorkEn"].Value?.ToString() ?? "";
                        DBClass.ExecuteNonQuery(@"INSERT INTO tbl_subcontractors (code, project_id, subcontractor_id, contact_no, contract_value, contract_date, contract_period, works, worksEn) 
                                                VALUES (@code, @project_id, @subcontractor_id, @contact_no, @contract_value, @contract_date, @contract_period, @works, @worksEn);",
                            DBClass.CreateParameter("code", subCode),
                            DBClass.CreateParameter("project_id", cmbProject4SubContractor.SelectedValue),
                            DBClass.CreateParameter("subcontractor_id", subcontractorId),
                            DBClass.CreateParameter("contact_no", subContactNo),
                            DBClass.CreateParameter("contract_value", subContractValue),
                            DBClass.CreateParameter("contract_date", subContractDate),
                            DBClass.CreateParameter("contract_period", subContractPeriod),
                            DBClass.CreateParameter("works", subWorks),
                            DBClass.CreateParameter("worksEn", subWorksEn)
                        );
                    }
                }
                MessageBox.Show("subcontractors Saved");
            }
            else
            {
                MessageBox.Show("Please select a project and ensure there are subcontractors listed.");
            }
        }
        private void LoadEngineersCombo()
        {
            DataTable dtSubcontractor = DBClass.ExecuteDataTable("SELECT name , id FROM tbl_engineers");
            // colEngCheck,colEngId,colEngCode,colEngName,colEngPhone,colEng,colEngDate
            DataGridViewComboBoxColumn col =
                (DataGridViewComboBoxColumn)dgvEngineers.Columns["colEngName"];

            col.DataSource = dtSubcontractor;
            col.DisplayMember = "name";
            col.ValueMember = "id";
        }
        private void cmbProject4Engineers_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProjectEngineer();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (cmbProject4Engineers.SelectedValue == null)
            {
                MessageBox.Show("Please select a project to add engineers to.");
                return;
            }

            if(dgvEngineers.Rows.Count > 0)
            {
                //delete if existing engineers for the project before adding new ones
                DBClass.ExecuteNonQuery("DELETE FROM tbl_projects_engineers WHERE project_id = @project_id",
                    DBClass.CreateParameter("project_id", cmbProject4Engineers.SelectedValue)
                    );

                foreach (DataGridViewRow row in dgvEngineers.Rows)
                {
                    if (row.IsNewRow) continue;

                    bool isChecked = row.Cells["colEngCheck"].Value != null ? bool.Parse(row.Cells["colEngCheck"].Value.ToString()) : false;
                    if (isChecked)
                    {
                        string engineerName = row.Cells["colEngName"].Value?.ToString() ?? "0";
                        string engineerDescription = row.Cells["colEngDescription"].Value?.ToString() ?? "";
                        string engineerDate = row.Cells["colEngDate"].Value?.ToString() ?? "2000-01-01";

                        if (!string.IsNullOrEmpty(engineerName))
                        {
                            DBClass.ExecuteNonQuery(@"INSERT INTO tbl_projects_engineers (project_id, engineer_id, date, description) 
                                                VALUES (@project_id, @name, @date, @description);",
                                DBClass.CreateParameter("project_id", cmbProject4Engineers.SelectedValue),
                                DBClass.CreateParameter("name", engineerName),
                                DBClass.CreateParameter("date", Convert.ToDateTime(engineerDate).Date),
                                DBClass.CreateParameter("description", engineerDescription)
                            );
                        }
                    }
                }

                MessageBox.Show("Engineers List Saved");
            }
            else
            {
                MessageBox.Show("Please select a project and ensure there are engineers listed.");
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            new frmProjectEngineers(0).ShowDialog();
            LoadEngineersCombo();
        }

        private void LoadProjectEngineer()
        {
            if(cmbProject4Engineers.SelectedValue == null)
            {
                return;
            }
            // colEngCheck,colEngId,colEngCode,colEngName,colEngPhone,colEngDate,colEngDescription
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT pe.id, pe.project_id, pe.engineer_id, e.code, e.name, e.contact_no,pe.date,pe.description FROM tbl_projects_engineers pe INNER JOIN tbl_engineers e ON e.id = pe.engineer_id WHERE pe.project_id = @projectId",
                DBClass.CreateParameter("projectId", cmbProject4Engineers.SelectedValue)))
            {
                //engineer_id,project_id,date,description
                dgvEngineers.Rows.Clear();
                while (reader.Read())
                {
                    int rowIndex = dgvEngineers.Rows.Add();
                    DataGridViewRow row = dgvEngineers.Rows[rowIndex];
                    row.Cells["colEngCheck"].Value = true;
                    row.Cells["colEngId"].Value = reader["id"].ToString();
                    row.Cells["colEngCode"].Value = reader["code"].ToString();
                    //row.Cells["colEngName"].Value = reader["name"].ToString();
                    DataGridViewComboBoxCell comboCellCostCenter = row.Cells["colEngName"] as DataGridViewComboBoxCell;
                    if (comboCellCostCenter != null && reader["engineer_id"].ToString() != "0")
                    {
                        comboCellCostCenter.Value = int.Parse(reader["engineer_id"].ToString());
                    }
                    row.Cells["colEngPhone"].Value = reader["contact_no"].ToString();
                    row.Cells["colEngDate"].Value = reader["date"].ToString();
                    row.Cells["colEngDescription"].Value = reader["description"].ToString();
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int pId = cmbProject4Location.SelectedValue != null ? Convert.ToInt32(cmbProject4Location.SelectedValue) : 0;
            SaveSite(pId, txtProjectLocation.Text);
        }

        private void cmbProject4Location_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load based project location if exist
        }

        private void dgvEngineers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvEngineers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;

            //if (dgvEngineers.Columns[e.ColumnIndex].Name == "engineer_id")
            //{
            //    int engineerId = Convert.ToInt32(dgvEngineers.Rows[e.RowIndex].Cells["engineer_id"].Value);

            //    object contact = DBClass.ExecuteScalar(
            //        "SELECT contact_value FROM tbl_engineers WHERE id = @id",
            //        DBClass.CreateParameter("@id", engineerId)
            //    );

            //    dgvEngineers.Rows[e.RowIndex].Cells["colEngPhone"].Value = contact;
            //}
        }

        private void dgvEngineers_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvEngineers.CurrentCell == null) return;

            if (dgvEngineers.Columns["colEngName"] == null) return;

            if (dgvEngineers.CurrentCell.ColumnIndex == dgvEngineers.Columns["colEngName"].Index)
            {
                ComboBox cb = e.Control as ComboBox;

                if (cb != null)
                {
                    cb.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                    cb.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                }
            }
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb == null) return;
            if (dgvEngineers.CurrentRow == null) return;
            if (cb.SelectedValue == null) return;

            // Ignore DataRowView
            if (cb.SelectedValue is DataRowView) return;

            int engineerId = Convert.ToInt32(cb.SelectedValue);

            object contact = DBClass.ExecuteScalar(
                "SELECT contact_no FROM tbl_engineers WHERE id = @id",
                DBClass.CreateParameter("@id", engineerId)
            );

            dgvEngineers.CurrentRow.Cells["colEngPhone"].Value = contact;
        }
    }
}
