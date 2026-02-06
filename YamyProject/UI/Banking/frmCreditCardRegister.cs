using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Util;
using System.Windows.Forms;

namespace YamyProject.UI.Banking
{
    public partial class frmCreditCardRegister : Form
    {
        int id = 0;
        public frmCreditCardRegister(int _id=0)
        {
            InitializeComponent();
            this.id = _id;
        }
        private void frmCreditCardRegister_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            cmbAccountType.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_coa_level_4");
            cmbAccountType.DisplayMember = "name";
            cmbAccountType.ValueMember = "id";
            cmbAccountType.SelectedIndex = 0;
            loadSubAccount();

            cmbCurrency.Items.AddRange(new object[] { "USD", "EUR", "AED" });
            cmbCurrency.SelectedIndex = 0;
        }

        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the credit card name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAccountNo.Text))
            {
                MessageBox.Show("Please enter the credit card account number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(id>0)
            {
                UpdateCreditCard();
                MessageBox.Show("Credit card updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                InsertCreditCard();
                MessageBox.Show("Credit card saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateCreditCard()
        {
            DBClass.ExecuteNonQuery(@"
                UPDATE tbl_credit_card SET 
                name = @name, 
                account_type_id = @account_type_id, 
                currency = @currency, 
                description = @description, 
                credit_card_ac_no = @credit_card_ac_no
                WHERE id = @id;",
                DBClass.CreateParameter("@name", txtName.Text.Trim()),
                DBClass.CreateParameter("account_type_id", cmbAccountType.SelectedValue),
                DBClass.CreateParameter("currency", cmbCurrency.SelectedItem.ToString()),
                DBClass.CreateParameter("description", txtDescription.Text.Trim()),
                DBClass.CreateParameter("credit_card_ac_no", txtAccountNo.Text.Trim()),
                DBClass.CreateParameter("id", id)
                );
        }

        private void InsertCreditCard()
        {
            DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_credit_card 
                (name, account_type_id, sub_account_id, currency, description, credit_card_ac_no) 
                VALUES 
                (@name, @account_type_id, 0, @currency, @description, @credit_card_ac_no);",
                DBClass.CreateParameter("@name", txtName.Text.Trim()),
                DBClass.CreateParameter("account_type_id", cmbAccountType.SelectedValue),
                DBClass.CreateParameter("sub_account_id", 0),
                DBClass.CreateParameter("currency", cmbCurrency.SelectedItem.ToString()),
                DBClass.CreateParameter("description", txtDescription.Text.Trim()),
                DBClass.CreateParameter("credit_card_ac_no", txtAccountNo.Text.Trim())
                );
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtAccountNo.Clear();
            txtDescription.Clear();
            cmbAccountType.SelectedIndex = 0;
            cmbCurrency.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //loadSubAccount();
        }

        private void loadSubAccount()
        {
            cmbSubAccount.DataSource = DBClass.ExecuteDataTable("SELECT id, name FROM tbl_coa_level_4");
            cmbSubAccount.DisplayMember = "name";
            cmbSubAccount.ValueMember = "id";
            cmbSubAccount.SelectedIndex = 0;
        }
    }
}
