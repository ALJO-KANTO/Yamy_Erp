using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.KPIs
{
    public partial class frmEngKPIMaster : Form
    {
        int id = 0;
        public frmEngKPIMaster()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngKPIMaster_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateEmployees(cmbEmployee);
            cmbEmployee.DisplayMember = "name";
            cmbEmployee.ValueMember = "id";

            cmbType.Items.Clear();
            cmbType.DataSource = new BindingSource((IsArabicCulture() ? KpiCalculationService.KpiArabicNames : KpiCalculationService.KpiEnglishNames), null);
            cmbType.DisplayMember = "Value";
            cmbType.ValueMember = "Key";
            cmbType.SelectedIndex = 0;

            cmbCalculation.Items.Clear();
            cmbCalculation.DataSource = new BindingSource((IsArabicCulture() ? KpiCalculationService.CalculationArabicNames : KpiCalculationService.CalculationEnglishNames), null);
            cmbCalculation.DisplayMember = "Value";
            cmbCalculation.ValueMember = "Key";
            cmbCalculation.SelectedIndex = 0;

            LoadKPIs();

            if(frmLogin.userRole.ToLower() == "employee")
            {
                // Disable editing features for employees
                //btnSave.Enabled = false;
                btnDelete.Enabled = false;
                cmbType.Enabled = false;
                txtName.Enabled = false;
                //numTargetTxt.Enabled = false;
                numWeightTxt.Enabled = false;
                cmbCalculation.Enabled = false;
                chkActive.Enabled = false;
            }
        }

        private bool IsArabicCulture()
        {
            // You can check either CurrentUICulture or CurrentCulture
            CultureInfo currentUICulture = Thread.CurrentThread.CurrentUICulture;

            // Arabic cultures start with "ar" (e.g., ar-SA, ar-EG)
            return currentUICulture.TwoLetterISOLanguageName.Equals("ar", StringComparison.OrdinalIgnoreCase);
        }

        private void LoadKPIs()
        {
            string query = "";
            if (frmLogin.userRole.ToLower() == "employee")
            {
                query = @"SELECT kpi_id, kpi_code, kpi_name, kpi_category,
                 target_value, weight, calculation_method, is_active, employee_id,(select name from tbl_employee where id=employee_id) as EmployeeName, EvaluationPeriod
                  FROM tbl_kpi_master
                  WHERE employee_id = @empId
                  ORDER BY kpi_category, kpi_name";
            }
            else
            {
                query = @"SELECT kpi_id, kpi_code, kpi_name, kpi_category,
                 target_value, weight, calculation_method, is_active, employee_id,(select name from tbl_employee where id=employee_id) as EmployeeName, EvaluationPeriod
                  FROM tbl_kpi_master
                  ORDER BY kpi_category, kpi_name";
            }
            using (MySqlDataReader reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("@empId", cmbEmployee.SelectedValue)))
            {

                dgvKPIs.Rows.Clear();
                while (reader.Read())
                {
                    dgvKPIs.Rows.Add(
                        reader["kpi_id"],
                        reader["kpi_code"],
                        reader["kpi_name"],
                        reader["kpi_category"],
                        reader["target_value"],
                        reader["weight"],
                        reader["calculation_method"],
                        reader["is_active"],
                        reader["employee_id"],
                        reader["EmployeeName"],
                        reader["EvaluationPeriod"]
                    );
                }
            }

            LocalizationManager.LocalizeDataGridViewHeaders(dgvKPIs);
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cmbType.SelectedIndex < 0)
            {
                MessageBox.Show("Please select Type");
                return;
            }
            if (cmbEvaluation.SelectedIndex < 0)
            {
                MessageBox.Show("Please select EvaluationPeriod");
                return;
            }
            int empId = Convert.ToInt32(cmbEmployee.SelectedValue);
            decimal weight = Convert.ToDecimal(numWeightTxt.Text);
            if (!ValidateTotalWeight(empId, weight, id))
            {
                MessageBox.Show("Total KPI weight cannot exceed 100%");
                return;
            }

            DBClass.ExecuteNonQuery(
                    @"INSERT INTO tbl_kpi_master (kpi_code, kpi_name, kpi_category, target_value, weight, calculation_method, is_active,employee_id,EvaluationPeriod)
                    VALUES (@code,@name,@category,@target,@weight,@calc,@active, @employeeId, @EvaluationPeriod)
                    ON DUPLICATE KEY UPDATE
                        kpi_name = VALUES(kpi_name),
                        kpi_category = VALUES(kpi_category),
                        target_value = VALUES(target_value),
                        is_active = VALUES(is_active),
                        employee_id = VALUES(employee_id),
                        EvaluationPeriod = VALUES(EvaluationPeriod);",
                    DBClass.CreateParameter("@code", cmbType.SelectedValue.ToString()),
                    DBClass.CreateParameter("@name", txtName.Text),
                    DBClass.CreateParameter("@category", ""),
                    DBClass.CreateParameter("@target", numTargetTxt.Text),
                    DBClass.CreateParameter("@weight", numWeightTxt.Text),
                    DBClass.CreateParameter("@calc", cmbCalculation.Text),
                    DBClass.CreateParameter("@employeeId", empId),
                    DBClass.CreateParameter("@EvaluationPeriod", cmbEvaluation.Text),
                    DBClass.CreateParameter("@active", chkActive.Checked ? 1 : 0)
                );
            //if (id == 0)
            //{
            //    DBClass.ExecuteNonQuery(
            //        @"INSERT INTO tbl_kpi_master
            //      (kpi_code, kpi_name, kpi_category, target_value, weight, calculation_method, is_active)
            //      VALUES (@code,@name,@cat,@target,@weight,@calc,@active)",
            //        DBClass.CreateParameter("@code", cmbType.SelectedValue.ToString()),
            //        DBClass.CreateParameter("@name", txtName.Text),
            //        DBClass.CreateParameter("@cat", cmbCategory.Text),
            //        DBClass.CreateParameter("@target", numTarget.Value),
            //        DBClass.CreateParameter("@weight", numWeight.Value),
            //        DBClass.CreateParameter("@calc", cmbCalculation.Text),
            //        DBClass.CreateParameter("@active", chkActive.Checked ? 1 : 0)
            //    );
            //}
            //else
            //{
            //    DBClass.ExecuteNonQuery(
            //        @"Update tbl_kpi_master SET kpi_code=@code,kpi_name=@name, kpi_category=@cat, target_value=@target,weight=@weight, calculation_method=@calc, is_active=@active where kpi_id = @id",
            //        DBClass.CreateParameter("@id", id),
            //        DBClass.CreateParameter("@code", cmbType.SelectedValue.ToString()),
            //        DBClass.CreateParameter("@name", txtName.Text),
            //        DBClass.CreateParameter("@cat", cmbCategory.Text),
            //        DBClass.CreateParameter("@target", numTarget.Value),
            //        DBClass.CreateParameter("@weight", numWeight.Value),
            //        DBClass.CreateParameter("@calc", cmbCalculation.Text),
            //        DBClass.CreateParameter("@active", chkActive.Checked ? 1 : 0)
            //        );
            //}
            MessageBox.Show( id > 0 ? "Edited" : "Saved" +" Successfully");
            LoadKPIs();
            ClearForm();
        }

        private bool ValidateTotalWeight(int employeeId, decimal newWeight, int currentKpiId)
        {
            object result = DBClass.ExecuteScalar(
                @"SELECT IFNULL(SUM(weight),0)
                      FROM tbl_kpi_master
                      WHERE employee_id=@emp
                        AND is_active=1
                        AND kpi_id <> @id",
                DBClass.CreateParameter("@emp", employeeId),
                DBClass.CreateParameter("@id", currentKpiId)
            );

            decimal total = Convert.ToDecimal(result) + newWeight;
            return total <= 100;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvKPIs.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvKPIs.CurrentRow.Cells["kpi_id"].Value);

            DBClass.ExecuteNonQuery(
                "UPDATE tbl_kpi_master SET is_active=0 WHERE kpi_id=@id",
                DBClass.CreateParameter("@id", id)
            );

            LoadKPIs();
        }

        private void dgvKPIs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            cmbType.SelectedValue = dgvKPIs.Rows[e.RowIndex].Cells["kpi_code"].Value.ToString();
            txtName.Text = dgvKPIs.Rows[e.RowIndex].Cells["kpi_name"].Value.ToString();
            //cmbCategory.Text = dgvKPIs.Rows[e.RowIndex].Cells["kpi_category"].Value.ToString();
            numTargetTxt.Text = dgvKPIs.Rows[e.RowIndex].Cells["target_value"].Value.ToString();
            numWeightTxt.Text = dgvKPIs.Rows[e.RowIndex].Cells["weight"].Value.ToString();
            cmbCalculation.Text = dgvKPIs.Rows[e.RowIndex].Cells["calculation_method"].Value.ToString();
            chkActive.Checked = Convert.ToBoolean(dgvKPIs.Rows[e.RowIndex].Cells["is_active"].Value);
            id = int.Parse(dgvKPIs.Rows[e.RowIndex].Cells["kpi_id"].Value.ToString());
            cmbEmployee.SelectedValue = dgvKPIs.Rows[e.RowIndex].Cells["EmployeeId"].Value;
            cmbEvaluation.Text = dgvKPIs.Rows[e.RowIndex].Cells["Period"].Value.ToString();
        }

        private void ClearForm()
        {
            cmbType.SelectedIndex = -1; 
            //cmbCategory.SelectedIndex = -1;
            txtName.Clear();
            numTargetTxt.Text = "0";
            numWeightTxt.Text = "0";
            chkActive.Checked = true;
        }
        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }
    }
}
