using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace YamyProject.UI.ContractingGeneralMaintenance.Procurement
{
    public partial class PurchaseOrderForm : Form
    {
        int preId = 0;
        public PurchaseOrderForm(int _preId = 0)
        {
            InitializeComponent();
            this.preId = _preId;
        }

        private void PurchaseOrderForm_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateProjects(cmbProject);
            BindCombos.PopulateVendors(cmbSupplier);
            cmbProject.SelectedIndex = -1;
            cmbSupplier.SelectedIndex = -1;

            if (preId>0)
            {
                loadData();
            }
        }

        private void loadData()
        {
            using(MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_procurement_tracking where id=@id", DBClass.CreateParameter("@id", preId)))
            {
                if (reader.Read())
                {
                    txtPONo.Text = reader["purchase_order_id"].ToString();
                    cmbProject.SelectedValue = reader["project_id"];
                    cmbSupplier.SelectedValue = reader["vendor_id"];
                    txtAmount.Text = reader["amount"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!validateForm()) return;

            if (preId == 0)
            {
                // check if PO already exists using purchase_order_id
                using (MySqlDataReader reader = DBClass.ExecuteReader("select id from tbl_procurement_tracking where purchase_order_id=@invoice_id", DBClass.CreateParameter("@invoice_id", txtPONo.Text)))
                {
                    if (reader.Read())
                    {
                        MessageBox.Show("This Purchase Order is already tracked.");
                        return;
                    }
                }

                DBClass.ExecuteNonQuery("insert into tbl_procurement_tracking(purchase_order_id,vendor_id,project_id,amount,approval_status,payment_status,created_at) values (@invoice_id,@vendor_id,@project_id,@amount,'Pending','N/A',now())",
                    DBClass.CreateParameter("@invoice_id", txtPONo.Text),
                    DBClass.CreateParameter("@vendor_id", cmbSupplier.SelectedValue),
                    DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
                    DBClass.CreateParameter("@amount", Convert.ToDecimal(txtAmount.Text))
                    );

                MessageBox.Show("Purchase Order saved successfully.");
            }
            else
            {
                DBClass.ExecuteNonQuery("update  tbl_procurement_tracking set vendor_id=@vendor_id,project_id=@project_id,amount=@amount where id=@id",
                    DBClass.CreateParameter("@id", preId),
                    DBClass.CreateParameter("@invoice_id", txtPONo.Text),
                    DBClass.CreateParameter("@vendor_id", cmbSupplier.SelectedValue),
                    DBClass.CreateParameter("@project_id", cmbProject.SelectedValue),
                    DBClass.CreateParameter("@amount", Convert.ToDecimal(txtAmount.Text))
                    );
                MessageBox.Show("Purchase Order updated successfully.");
            }
        }

        private bool validateForm()
        {
            if (string.IsNullOrWhiteSpace(txtPONo.Text))
            {
                MessageBox.Show("Please enter PO Number.");
                return false;
            }
            if (cmbSupplier.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Supplier.");
                return false;
            }
            if (cmbProject.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Project.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAmount.Text) || !decimal.TryParse(txtAmount.Text, out _))
            {
                MessageBox.Show("Please enter a valid Amount.");
                return false;
            }

            return true;
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }

        private void txtPONo_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtPONo.Text)) return;

            using (MySqlDataReader reader = DBClass.ExecuteReader("select id,net,project_id,vendor_id from tbl_purchase_order where id=@ref", DBClass.CreateParameter("@ref", txtPONo.Text)))
            {
                if(reader.Read())
                {
                    txtAmount.Text = Convert.ToDecimal(reader["net"].ToString()).ToString("N2");
                    cmbProject.SelectedValue = reader["project_id"];
                    cmbSupplier.SelectedValue = reader["vendor_id"];
                    preId = Convert.ToInt32(reader["id"]);
                    txtAmount.ReadOnly = txtPONo.ReadOnly = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPONo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
