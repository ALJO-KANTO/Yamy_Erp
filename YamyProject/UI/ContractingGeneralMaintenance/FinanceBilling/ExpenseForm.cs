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
    public partial class ExpenseForm : Form
    {
        int id;
        public ExpenseForm(int _id = 0)
        {
            InitializeComponent();
            this.id = _id;
        }

        private void ExpenseForm_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateProjects(cmbProject);

            if (id > 0)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("Select expense_date, expense_type, description, amount, project_id from tbl_expenses WHERE id = @Id", DBClass.CreateParameter("@Id", id)))
            {
                if (reader.Read())
                {
                    cmbProject.SelectedValue = Convert.ToInt32(reader["project_id"]);
                    cmbType.SelectedItem = reader["expense_type"];
                    dtExpenseDate.Value = Convert.ToDateTime(reader["expense_date"]);
                    txtAmount.Text = reader["amount"].ToString();
                    txtDescription.Text = reader["description"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                if(id == 0)
                {
                    // Insert new expense
                    string sql = @"INSERT INTO tbl_expenses
                                   (expense_date, expense_type, description, amount, project_id)
                                   VALUES
                                   (@date, @type, @desc, @amount, @projectId)";

                    DBClass.ExecuteNonQuery(sql,
                        DBClass.CreateParameter("@date", dtExpenseDate.Value.Date),
                        DBClass.CreateParameter("@type", cmbType.SelectedItem.ToString()),
                        DBClass.CreateParameter("@desc", txtDescription.Text),
                        DBClass.CreateParameter("@amount", Convert.ToDecimal(txtAmount.Text)),
                        DBClass.CreateParameter("@projectId", cmbProject.SelectedValue)
                    );

                    MessageBox.Show("Expense saved successfully");
                }
                else
                {
                    // Update existing expense
                    DBClass.ExecuteNonQuery(
                        "UPDATE tbl_expenses SET project_id = @ProjectId, amount = @Amount, expense_type = @type, expense_date = @ExpenseDate, description = @Description WHERE id = @Id",
                        DBClass.CreateParameter("@ProjectId", cmbProject.SelectedValue),
                        DBClass.CreateParameter("@Amount", decimal.Parse(txtAmount.Text)),
                        DBClass.CreateParameter("@ExpenseDate", dtExpenseDate.Value),
                        DBClass.CreateParameter("@type", cmbType.SelectedItem.ToString()),
                        DBClass.CreateParameter("@Description", txtDescription.Text),
                        DBClass.CreateParameter("@Id", id)
                    );

                    MessageBox.Show("Expense updated successfully");
                }
            }
        }

        private bool validateForm()
        {
            if (cmbProject.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a project.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAmount.Text) || !decimal.TryParse(txtAmount.Text, out _))
            {
                MessageBox.Show("Please enter a valid amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
