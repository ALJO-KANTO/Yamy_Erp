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

namespace YamyProject.UI.ContractingGeneralMaintenance.KPIDashboard
{
    public partial class KPIEntryForm : Form
    {
        int id;
        public KPIEntryForm(int _id = 0)
        {
            InitializeComponent();
            this.id = _id;
        }

        private void KPIEntryForm_Load(object sender, EventArgs e)
        {
            if (id > 0)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            using(MySqlDataReader reader = DBClass.ExecuteReader("SELECT * FROM tbl_kpi_master WHERE kpi_id = @id", DBClass.CreateParameter("@id", id)))
            {
                if (reader.Read())
                {
                    txtCode.Text = reader["kpi_code"].ToString();
                    txtName.Text = reader["kpi_name"].ToString();
                    cmbCategory.SelectedItem = reader["kpi_category"].ToString();
                    txtTarget.Text = Convert.ToDecimal(reader["target_value"]).ToString("N2");
                    txtActual.Text = Convert.ToDecimal(reader["weight"]).ToString("N2");
                }
            }
        }
        private string GenerateNextCustomerCode()
        {
            int code;
            using (var reader = DBClass.ExecuteReader("SELECT MAX(CAST(kpi_code AS UNSIGNED)) AS lastCode FROM tbl_kpi_master"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                    code = int.Parse(reader["lastCode"].ToString()) + 1;
                else
                    code = 001;
            }
            return code.ToString("D5");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the KPI name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the KPI category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTarget.Text) || !decimal.TryParse(txtTarget.Text, out _))
            {
                MessageBox.Show("Please enter a valid target value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtActual.Text) || !decimal.TryParse(txtActual.Text, out _))
            {
                MessageBox.Show("Please enter a valid actual value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (id == 0)
            {
                string newCode = GenerateNextCustomerCode();
                DBClass.ExecuteNonQuery("INSERT INTO tbl_kpi_master (kpi_code, kpi_name, kpi_category, target_value, weight) VALUES (@code, @name, @category, @target, @weight)",
                    DBClass.CreateParameter("@code", newCode),
                    DBClass.CreateParameter("@name", txtName.Text),
                    DBClass.CreateParameter("@category", cmbCategory.SelectedItem.ToString()),
                    DBClass.CreateParameter("@target", decimal.Parse(txtTarget.Text)),
                    DBClass.CreateParameter("@weight", decimal.Parse(txtActual.Text))
                );
                MessageBox.Show("KPI entry created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DBClass.ExecuteNonQuery("UPDATE tbl_kpi_master SET kpi_name = @name, kpi_category = @category, target_value = @target, weight = @weight WHERE kpi_id = @id",
                    DBClass.CreateParameter("@name", txtName.Text),
                    DBClass.CreateParameter("@category", cmbCategory.SelectedItem.ToString()),
                    DBClass.CreateParameter("@target", decimal.Parse(txtTarget.Text)),
                    DBClass.CreateParameter("@weight", decimal.Parse(txtActual.Text)),
                    DBClass.CreateParameter("@id", id)
                );
                MessageBox.Show("KPI entry updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTarget_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
