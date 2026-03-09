using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.DAL;

namespace YamyProject.UI.Sales
{
    public partial class frmReceivePayments : Form
    {
        private int _salesInvoiceId, _customerId;
        private decimal _total;
        private decimal _advancePaid;
        private string _form;
        private int id;
        public frmReceivePayments(int _id, int salesInvoiceId, int customerId, string customerName, string invoiceNumber, decimal total, decimal advancePaid, string type)
        {
            InitializeComponent();
            headerUC1.FormText = this.Text;
            _salesInvoiceId = salesInvoiceId;
            _customerId = customerId;
            _total = total;
            _advancePaid = advancePaid;
            id = _id;
            _form = type;

            txtCustomer.Text = customerName;
            txtInvoice.Text = invoiceNumber;
            txtTotal.Text = total.ToString("N2");
            nudAmountReceived.Maximum = total - advancePaid;
        }

        private void frmReceivePayments_Load(object sender, EventArgs e)
        {
            BindCombos.LoadAllLevel4Account(cmbAccount);

            if(_salesInvoiceId>0 && _customerId > 0)
            {
                using(MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_sales_advance where customer_id = @customer and sales_order_id = @invId and form_type = @form",
                    DBClass.CreateParameter("@customer", _customerId),
                    DBClass.CreateParameter("@invId", _salesInvoiceId),
                    DBClass.CreateParameter("@form", _form)))
                {
                    if (reader.Read())
                    {
                        id = Convert.ToInt32(reader["id"]);
                        nudAmountReceived.Text = reader["amount"].ToString();
                        dtInv.Value = Convert.ToDateTime(reader["date"].ToString());
                        cmbAccount.SelectedValue = Convert.ToInt32(reader["account_id"]);
                    }
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal amountReceived = nudAmountReceived.Value;

            if (amountReceived <= 0)
            {
                MessageBox.Show("Enter a valid amount to receive.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (id > 0)
                {
                    //update
                    DBClass.ExecuteNonQuery(@"
                        Update tbl_sales_advance SET date = @date,customer_id = @custId, sales_order_id = @soId, invoice_id = @invoice_id, 
                        amount = @amount, payment_method = @method, form_type = @form_type, project_id = @project_id, account_id = @accId, description = @desc 
                        WHERE id = @id
                        ",
                            DBClass.CreateParameter("id", id),
                            DBClass.CreateParameter("date", dtInv.Value.Date),
                            DBClass.CreateParameter("@custId", _customerId),
                            DBClass.CreateParameter("@soId", _salesInvoiceId),
                            DBClass.CreateParameter("@invoice_id", "0"),
                            DBClass.CreateParameter("@amount", amountReceived),
                            DBClass.CreateParameter("@method", "Cash"),
                            DBClass.CreateParameter("@form_type", _form),
                            DBClass.CreateParameter("@project_id", "0"),
                            DBClass.CreateParameter("@accId", cmbAccount.SelectedValue),
                            DBClass.CreateParameter("@desc", $"Advance payment for SO #{txtInvoice.Text}"));
                }
                else
                {
                    DBClass.ExecuteNonQuery(@"
                        INSERT INTO tbl_sales_advance
                        (date, customer_id, sales_order_id, invoice_id, amount, payment_method, form_type, project_id, account_id, description)
                        VALUES (@date, @custId, @soId, @invoice_id, @amount, @method, @form_type, @project_id, @accId, @desc)",
                            DBClass.CreateParameter("date", dtInv.Value.Date),
                            DBClass.CreateParameter("@custId", _customerId),
                            DBClass.CreateParameter("@soId", _salesInvoiceId),
                            DBClass.CreateParameter("@invoice_id", "0"),
                            DBClass.CreateParameter("@amount", amountReceived),
                            DBClass.CreateParameter("@method", "Cash"),
                            DBClass.CreateParameter("@form_type", _form),
                            DBClass.CreateParameter("@project_id", "0"),
                            DBClass.CreateParameter("@accId", cmbAccount.SelectedValue),
                            DBClass.CreateParameter("@desc", $"Advance payment for SO #{txtInvoice.Text}")
                        );
                }


                MessageBox.Show("Payment saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
