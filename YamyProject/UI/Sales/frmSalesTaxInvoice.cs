using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.DAL;

namespace YamyProject.UI.Sales
{
    public partial class frmSalesTaxInvoice : Form
    {
        int id = 0;

        public frmSalesTaxInvoice(int _id = 0)
        {
            InitializeComponent();
            id = _id;
            headerUC1.FormText = "Sales Tax Invoice (Advance & Retention)";
        }
        private void frmSalesTaxInvoice_Load(object sender, EventArgs e)
        {
            AppTheme.DefaultFont(dgvItems);
            dtInvoiceDate.Value = DateTime.Now.Date;
            BindCustomers();
            GenerateInvoiceNo();

            if (id != 0)
                BindInvoice();
        }

        // ============================================
        // LOAD CUSTOMERS
        // ============================================
        private void BindCustomers()
        {
            cmbCustomer.DataSource = DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_customer WHERE state = 0");

            cmbCustomer.DisplayMember = "name";
            cmbCustomer.ValueMember = "id";
            cmbCustomer.SelectedIndex = -1;
        }

        // ============================================
        // GENERATE NEXT INVOICE NUMBER
        // ============================================
        private void GenerateInvoiceNo()
        {
            object result = DBClass.ExecuteScalar(
                "SELECT IFNULL(MAX(id),0)+1 FROM tbl_sales_tax_invoice");

            txtInvoiceNo.Text = "STI-" + result.ToString().PadLeft(5, '0');
        }

        // ============================================
        // SAVE BUTTON
        // ============================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show("Select customer");
                return;
            }

            if (dgvItems.Rows.Count <= 1)
            {
                MessageBox.Show("Add at least one item");
                return;
            }

            if (id == 0)
            {
                if (InsertInvoice())
                    MessageBox.Show("Saved Successfully");
            }
            else
            {
                if (UpdateInvoice())
                    MessageBox.Show("Updated Successfully");
            }
        }

        // ============================================
        // INSERT HEADER
        // ============================================
        private bool InsertInvoice()
        {
            try
            {
                int invoiceId = Convert.ToInt32(DBClass.ExecuteScalar(@"
                    INSERT INTO tbl_sales_tax_invoice
                    (invoice_no, invoice_date, customer_id, type, remarks, subtotal, vat, total, created_by)
                    VALUES
                    (@invoice_no, @invoice_date, @customer_id, @type, @remarks, @subtotal, @vat, @total, @created_by);
                    SELECT LAST_INSERT_ID();",

                    DBClass.CreateParameter("@invoice_no", txtInvoiceNo.Text),
                    DBClass.CreateParameter("@invoice_date", dtInvoiceDate.Value.Date),
                    DBClass.CreateParameter("@customer_id", cmbCustomer.SelectedValue),
                    DBClass.CreateParameter("@type", cmbType.Text),
                    DBClass.CreateParameter("@remarks", txtRemarks.Text),
                    DBClass.CreateParameter("@subtotal", Convert.ToDecimal(txtSubTotal.Text)),
                    DBClass.CreateParameter("@vat", Convert.ToDecimal(txtVat.Text)),
                    DBClass.CreateParameter("@total", Convert.ToDecimal(txtTotal.Text)),
                    DBClass.CreateParameter("@created_by", frmLogin.userId)
                ));

                InsertItems(invoiceId);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        // ============================================
        // UPDATE HEADER
        // ============================================
        private bool UpdateInvoice()
        {
            try
            {
                DBClass.ExecuteNonQuery(@"
                    UPDATE tbl_sales_tax_invoice
                    SET invoice_date=@invoice_date,
                        customer_id=@customer_id,
                        type=@type,
                        remarks=@remarks,
                        subtotal=@subtotal,
                        vat=@vat,
                        total=@total,
                        modified_by=@modified_by,
                        modified_date=NOW()
                    WHERE id=@id",

                    DBClass.CreateParameter("@id", id),
                    DBClass.CreateParameter("@invoice_date", dtInvoiceDate.Value.Date),
                    DBClass.CreateParameter("@customer_id", cmbCustomer.SelectedValue),
                    DBClass.CreateParameter("@type", cmbType.Text),
                    DBClass.CreateParameter("@remarks", txtRemarks.Text),
                    DBClass.CreateParameter("@subtotal", Convert.ToDecimal(txtSubTotal.Text)),
                    DBClass.CreateParameter("@vat", Convert.ToDecimal(txtVat.Text)),
                    DBClass.CreateParameter("@total", Convert.ToDecimal(txtTotal.Text)),
                    DBClass.CreateParameter("@modified_by", frmLogin.userId)
                );

                DBClass.ExecuteNonQuery(
                    "DELETE FROM tbl_sales_tax_invoice_item WHERE invoice_id=@id",
                    DBClass.CreateParameter("@id", id));

                InsertItems(id);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        // ============================================
        // INSERT ITEMS
        // ============================================
        private void InsertItems(int invoiceId)
        {
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_sales_tax_invoice_item
                    (invoice_id, item_id, description, qty, rate, vat, total)
                    VALUES
                    (@invoice_id, @item_id, @description, @qty, @rate, @vat, @total)",

                    DBClass.CreateParameter("@invoice_id", invoiceId),
                    DBClass.CreateParameter("@item_id", row.Cells["item_id"].Value),
                    DBClass.CreateParameter("@description", row.Cells["description"].Value),
                    DBClass.CreateParameter("@qty", row.Cells["qty"].Value),
                    DBClass.CreateParameter("@rate", row.Cells["rate"].Value),
                    DBClass.CreateParameter("@vat", row.Cells["vat"].Value),
                    DBClass.CreateParameter("@total", row.Cells["total"].Value)
                );
            }
        }

        // ============================================
        // CALCULATE TOTALS
        // ============================================
        private void dgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            decimal subtotal = 0;
            decimal vat = 0;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow) continue;

                decimal qty = Convert.ToDecimal(row.Cells["qty"].Value ?? 0);
                decimal rate = Convert.ToDecimal(row.Cells["rate"].Value ?? 0);
                decimal vatp = Convert.ToDecimal(row.Cells["vat"].Value ?? 0);

                decimal lineTotal = qty * rate;
                decimal lineVat = (lineTotal * vatp) / 100;

                row.Cells["total"].Value = lineTotal + lineVat;

                subtotal += lineTotal;
                vat += lineVat;
            }

            txtSubTotal.Text = subtotal.ToString("0.00");
            txtVat.Text = vat.ToString("0.00");
            txtTotal.Text = (subtotal + vat).ToString("0.00");
        }

        // ============================================
        // LOAD EXISTING INVOICE
        // ============================================
        private void BindInvoice()
        {
            DataTable dt = DBClass.ExecuteDataTable(
                "SELECT * FROM tbl_sales_tax_invoice WHERE id=@id",
                DBClass.CreateParameter("@id", id));

            if (dt.Rows.Count == 0) return;

            txtInvoiceNo.Text = dt.Rows[0]["invoice_no"].ToString();
            dtInvoiceDate.Value = Convert.ToDateTime(dt.Rows[0]["invoice_date"]);
            cmbCustomer.SelectedValue = dt.Rows[0]["customer_id"];
            cmbType.Text = dt.Rows[0]["type"].ToString();
            txtRemarks.Text = dt.Rows[0]["remarks"].ToString();
            txtSubTotal.Text = dt.Rows[0]["subtotal"].ToString();
            txtVat.Text = dt.Rows[0]["vat"].ToString();
            txtTotal.Text = dt.Rows[0]["total"].ToString();

            BindItems();
        }

        private void BindItems()
        {
            dgvItems.Rows.Clear();

            DataTable dt = DBClass.ExecuteDataTable(
                "SELECT * FROM tbl_sales_tax_invoice_item WHERE invoice_id=@id",
                DBClass.CreateParameter("@id", id));

            foreach (DataRow dr in dt.Rows)
            {
                dgvItems.Rows.Add(
                    dr["item_id"],
                    dr["description"],
                    dr["qty"],
                    dr["rate"],
                    dr["vat"],
                    dr["total"]);
            }
        }
    }
}
