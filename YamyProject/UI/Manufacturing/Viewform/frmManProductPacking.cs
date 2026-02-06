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

namespace YamyProject.UI.Manufacturing.Viewform
{
    public partial class frmManProductPacking : Form
    {
        int id;
        bool AllowItemWithOutQty = true;
        public frmManProductPacking(int _id = 0)
        {
            this.id = _id;
            InitializeComponent();
        }

        int itemId = 0;
        decimal totalCostAmount = 0;
        decimal totalQty = 0;

        private void frmManProductPacking_Load(object sender, EventArgs e)
        {
            var generalS = Utilities.GeneralSettingsState("ALLOW ITEM WITHOUT QTY");
            if (!string.IsNullOrEmpty(generalS) & int.Parse(generalS) > 0)
            {
                AllowItemWithOutQty = true;
            }
            else
            {
                AllowItemWithOutQty = false;
            }
            getdata();
            dgvitem2.Visible = false;
            BindCombos.PopulateWarehouse(cmbWarehouseTo);
            if (id != 0)
            {
                LoadDetails();
            }
        }
        int warehouseId = 0;
        private void getdata()
        {
            string qry1 = @"SELECT 
                                a.id,
                                a.code,
                                a.name,
                                IFNULL(
                                    (SELECT b.cost_price 
                                     FROM tbl_item_transaction b 
                                     WHERE b.item_id = a.id 
                                     ORDER BY b.id DESC   -- ensures the latest record
                                     LIMIT 1
                                    ),
                                    a.cost_price
                                ) AS cost_price
                            FROM tbl_items a
                            ORDER BY a.name;
                            ";
            DataTable DT = DBClass.ExecuteDataTable(qry1);
            dgvitem2.DataSource = DT;
            dgvitem2.Columns[0].Visible = false;
            dgvitem2.Columns[2].Width = 90;
            dgvitem2.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvitem2.Columns["cost_price"].Visible = dgvitem2.Columns["code"].Visible = false;
        }
        private void getdatasearchname(string st)
        {
            string qry1 = @"SELECT 
                                a.id,
                                a.code,
                                a.name,
                                IFNULL(
                                    (SELECT b.cost_price 
                                     FROM tbl_item_transaction b 
                                     WHERE b.item_id = a.id 
                                     ORDER BY b.id DESC   -- ensures the latest record
                                     LIMIT 1
                                    ),
                                    a.cost_price
                                ) AS cost_price
                            FROM tbl_items a 
                            where a.name like '%" + st + "%'";

            DataTable DT = DBClass.ExecuteDataTable(qry1);
            dgvitem2.DataSource = DT;
            dgvitem2.Columns[0].Visible = false;
            dgvitem2.Columns[2].Width = 90;
            dgvitem2.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvitem2.Columns["cost_price"].Visible = false;
        }
        private void getdatasearchcode(string st)
        {
            string qry1 = @"SELECT 
                        a.id,
                        a.code,
                        a.name,
                        IFNULL(
                            (SELECT b.cost_price 
                             FROM tbl_item_transaction b 
                             WHERE b.item_id = a.id 
                             ORDER BY b.id DESC
                             LIMIT 1
                            ),
                            a.cost_price
                        ) AS cost_price
                    FROM tbl_items a 
                    WHERE a.code LIKE '%" + st + "%'";

            DataTable DT = DBClass.ExecuteDataTable(qry1);
            dgvitem2.DataSource = DT;
            dgvitem2.Columns[0].Visible = false;
            //dgvitem2.Columns[2].Width = dgvitem2.Columns[3].Width = 90;
            dgvitem2.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvitem2.Columns["cost_price"].Visible = false;
        }
        private void LoadDetails()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT a.id,a.amount,a.Costamount,a.date,a.warehouse_id,a.warehouse_to_id,a.batchname,a.product_id,(SELECT concat(CODE,' - ',NAME) FROM tbl_items WHERE id = a.product_id) ProductName,a.product_qty FROM tbl_manufacturer_batch a where a.id=@id", DBClass.CreateParameter("id", id)))
            {
                if (reader.Read())
                {
                    textBoxBatchNo.Text = reader["batchname"].ToString();
                    textBoxItemName.Text = reader["ProductName"].ToString();
                    itemId = int.Parse(reader["product_id"].ToString());
                    textBoxTotalQty.Text = reader["product_qty"].ToString();
                    dtInv.Value = DateTime.Parse(reader["date"].ToString());
                    totalCostAmount = decimal.Parse(reader["Costamount"].ToString());
                    totalQty = decimal.Parse(reader["product_qty"].ToString());
                    var wId = DBClass.ExecuteScalar("SELECT warehouse_id FROM tbl_item_transaction WHERE reference=@ref AND type='Manufacturing' AND item_id=@itemId;", DBClass.CreateParameter("ref", id.ToString()), DBClass.CreateParameter("itemId", itemId));
                    warehouseId = wId != null ? int.Parse(wId.ToString()) : int.Parse(reader["warehouse_to_id"].ToString());
                    cmbWarehouseTo.SelectedValue = warehouseId;
                    //Sn,Variant,Quantity,BatchNumber,RackNo
                    //dataGridViewPacking.Rows.Add(null,"","1","",dtInv.Value,"1");
                    using (MySqlDataReader readerVariant = DBClass.ExecuteReader("SELECT a.item_id,i.code,i.name item_name,a.batch_id,a.variant,a.quantity,a.batch_number,a.packing_date,a.rack_no,a.warehouse_id FROM tbl_manufacturer_packing a, tbl_items i WHERE a.item_id=i.id and a.batch_id = @batch_id", DBClass.CreateParameter("batch_id", id)))
                    {
                        while (readerVariant.Read())
                        {
                            dataGridViewPacking.Rows.Add(null,
                                readerVariant["item_id"].ToString(),
                                readerVariant["code"].ToString(),
                                readerVariant["item_name"].ToString(),
                                readerVariant["variant"].ToString(),
                                readerVariant["quantity"].ToString(),
                                readerVariant["batch_number"].ToString(),
                                DateTime.Parse(readerVariant["packing_date"].ToString()).ToString("yyyy-MM-dd"),
                                readerVariant["rack_no"].ToString()
                            );
                            cmbWarehouseTo.SelectedValue = readerVariant["warehouse_id"];
                        }
                    }
                }
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //save logic
            if (CheckRequiredData())
            {
                // First, delete existing packing records for the batch
                using (MySqlDataReader readerVariant = DBClass.ExecuteReader("SELECT batch_id FROM tbl_manufacturer_packing WHERE batch_id=@batch_id", DBClass.CreateParameter("batch_id", id)))
                {
                    if (readerVariant.HasRows)
                    {
                        DBClass.ExecuteNonQuery("DELETE FROM tbl_manufacturer_packing WHERE batch_id=@batch_id", DBClass.CreateParameter("batch_id", id));
                        //delete related item transactions
                        DBClass.ExecuteNonQuery("DELETE FROM tbl_item_transaction WHERE reference = @reference_id AND type ='Manufacture Packing'", DBClass.CreateParameter("reference_id", id.ToString()));
                    }
                }

                totalQty = Convert.ToDecimal(textBoxTotalQty.Text);

                //Sn,Variant,Quantity,BatchNumber,PackingDate,RackNo
                for (int i = 0; i < dataGridViewPacking.Rows.Count - 1; i++)
                {
                    var row = dataGridViewPacking.Rows[i];
                    if (row.IsNewRow || string.IsNullOrWhiteSpace(row.Cells["Quantity"].Value?.ToString()))
                        continue;

                    DBClass.ExecuteNonQuery("INSERT INTO tbl_manufacturer_packing (item_id,batch_id,variant,quantity,batch_number,packing_date,rack_no,created_by,warehouse_id) VALUES (@item_id,@batch_id,@variant,@quantity,@batch_number,@packing_date,@rack_no,@created_by,@warehouse_id)",
                        DBClass.CreateParameter("item_id", row.Cells["dgvItemid"].Value.ToString()),
                        DBClass.CreateParameter("batch_id", id.ToString()),
                        DBClass.CreateParameter("variant", row.Cells["Variant"].Value.ToString()),
                        DBClass.CreateParameter("quantity", row.Cells["Quantity"].Value.ToString()),
                        DBClass.CreateParameter("batch_number", row.Cells["BatchNumber"].Value.ToString()),
                        DBClass.CreateParameter("packing_date", DateTime.Parse(row.Cells["PackingDate"].Value.ToString()).Date),
                        DBClass.CreateParameter("rack_no", row.Cells["RackNo"].Value.ToString()),
                        DBClass.CreateParameter("warehouse_id", cmbWarehouseTo.SelectedValue),
                        DBClass.CreateParameter("created_by", frmLogin.userId)
                    );
                    string cost = (totalCostAmount / totalQty).ToString("N2");

                    //// -----------------------------------------
                    //// 2. Deduct stock from tbl_item_transaction
                    //// -----------------------------------------
                    ////From Warehouse
                    //CommonInsert.InsertItemTransaction(dtInv.Value.Date, "Manufacture Packing", id.ToString(), itemId.ToString(), cost.ToString(), "0", "0", row.Cells["Quantity"].Value.ToString(), "0", "Production Packing from " + textBoxItemName.Text + row.Cells["Variant"].Value.ToString(),
                    //    Convert.ToInt32(warehouseId).ToString());


                    //To Warehouse
                    CommonInsert.InsertItemTransaction(dtInv.Value.Date, "Manufacture Packing", id.ToString(), itemId.ToString(), cost.ToString(), row.Cells["Quantity"].Value.ToString(), "0", "0", "0", "Production Packing for" + textBoxItemName.Text + row.Cells["Variant"].Value.ToString(),
                        Convert.ToInt32(cmbWarehouseTo.SelectedValue).ToString());
                }
                if (AllowItemWithOutQty)
                {
                    DBClass.ExecuteNonQuery(@"UPDATE tbl_manufacturer_batch SET product_qty = @finishedQty WHERE product_id =@productId and id = @bId",
                            DBClass.CreateParameter("finishedQty", textBoxTotalQty.Text),
                            DBClass.CreateParameter("productId", itemId),
                            DBClass.CreateParameter("bId", id));
                }

                MessageBox.Show("Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private bool CheckRequiredData()
        {
            decimal available = decimal.Parse(textBoxTotalQty.Text);
            decimal takenQty = 0;
            for (int i = 0; i < dataGridViewPacking.Rows.Count - 1; i++)
            {
                //Sn,Variant,Quantity,BatchNumber,PackingDate,RackNo
                if (dataGridViewPacking.Rows[i].Cells["Quantity"].Value == null
                    || dataGridViewPacking.Rows[i].Cells["Quantity"].Value.ToString() == ""
                    || decimal.Parse(dataGridViewPacking.Rows[i].Cells["Quantity"].Value.ToString()) == 0)
                {
                    MessageBox.Show("Total Item In Row " + (dataGridViewPacking.Rows[i].Index + 1) + " Can't Be 0 or Null");
                    return false;
                }
                if (dataGridViewPacking.Rows[i].Cells["BatchNumber"].Value == null
                    || dataGridViewPacking.Rows[i].Cells["BatchNumber"].Value.ToString() == "")
                {
                    MessageBox.Show("Batch Number In Row " + (dataGridViewPacking.Rows[i].Index + 1) + " Can't Be Null");
                    return false;
                }
                if (dataGridViewPacking.Rows[i].Cells["RackNo"].Value == null
                    || dataGridViewPacking.Rows[i].Cells["RackNo"].Value.ToString() == "")
                {
                    MessageBox.Show("Rack No In Row " + (dataGridViewPacking.Rows[i].Index + 1) + " Can't Be Null");
                    return false;
                }
                if (decimal.Parse(dataGridViewPacking.Rows[i].Cells["Quantity"].Value.ToString()) > decimal.Parse(textBoxTotalQty.Text))
                {
                    MessageBox.Show("Quantity In Row " + (dataGridViewPacking.Rows[i].Index + 1) + " Can't Be Greater Than Total Quantity");
                    return false;
                }
                if (decimal.Parse(dataGridViewPacking.Rows[i].Cells["Quantity"].Value.ToString()) <= 0)
                {
                    MessageBox.Show("Quantity In Row " + (dataGridViewPacking.Rows[i].Index + 1) + " Can't Be Less Than Or Equal To 0");
                    return false;
                }
                if (dataGridViewPacking.Rows[i].Cells["PackingDate"].Value == null
                    || dataGridViewPacking.Rows[i].Cells["PackingDate"].Value.ToString() == "")
                {
                    MessageBox.Show("Packing Date In Row " + (dataGridViewPacking.Rows[i].Index + 1) + " Can't Be Null");
                    return false;
                }
                takenQty += decimal.Parse(dataGridViewPacking.Rows[i].Cells["Quantity"].Value.ToString());
                if (takenQty > available)
                {
                    MessageBox.Show("Quantity Not Available");
                    return false;
                }
            }
            if (dataGridViewPacking.Rows.Count == 0)
            {
                MessageBox.Show("Please add packing details!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (id <= 0)
            {
                MessageBox.Show("Invalid batch details!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void dataGridViewPacking_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewPacking.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridViewPacking_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (AllowItemWithOutQty)
            {
                textBoxTotalQty.Text = dataGridViewPacking.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells["Quantity"].Value != null && decimal.TryParse(r.Cells["Quantity"].Value.ToString(), out _))
                    .Sum(r => decimal.Parse(r.Cells["Quantity"].Value.ToString()))
                    .ToString("N2");
            }
        }

        private TextBox editingTextBox;
        private void dataGridViewPacking_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int col = dataGridViewPacking.CurrentCell.ColumnIndex;

            // Remove old TextChanged handler
            if (editingTextBox != null)
                editingTextBox.TextChanged -= EditingTextBox_TextChanged;

            editingTextBox = e.Control as TextBox;

            if (editingTextBox != null)
            {
                editingTextBox.TextChanged += EditingTextBox_TextChanged;

                // Columns for live search: Code (2) or Name (3)
                if (col == 2 || col == 3)
                {
                    dgvitem2.Visible = true;

                    // Position dgvitem2 under the current cell
                    Rectangle cellRectangle = dataGridViewPacking.GetCellDisplayRectangle(
                        dataGridViewPacking.CurrentCell.ColumnIndex,
                        dataGridViewPacking.CurrentCell.RowIndex,
                        true
                    );

                    dgvitem2.Left = dataGridViewPacking.Left + cellRectangle.Left;
                    dgvitem2.Top = dataGridViewPacking.Top + cellRectangle.Bottom;
                    dgvitem2.Width = cellRectangle.Width + 200; // adjust width if needed
                    dgvitem2.Height = 150; // dropdown height

                    // Call search function based on column
                    if (col == 2) // Code column
                        getdatasearchcode(editingTextBox.Text);
                    else if (col == 3) // Name column
                        getdatasearchname(editingTextBox.Text);
                }
                else
                {
                    dgvitem2.Visible = false;
                }
            }

            // Column 5 logic
            if (col == 5)
            {
                int row = dataGridViewPacking.CurrentCell.RowIndex;
                double qty = 0;

                double.TryParse(
                    Convert.ToString(dataGridViewPacking.Rows[row].Cells[4].Value),
                    out qty
                );

                // Do something with qty
            }
        }

        //private void dataGridViewPacking_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    int col = dataGridViewPacking.CurrentCell.ColumnIndex;

        //    // Remove old TextChanged handler
        //    if (editingTextBox != null)
        //        editingTextBox.TextChanged -= EditingTextBox_TextChanged;

        //    editingTextBox = e.Control as TextBox;

        //    if (editingTextBox != null)
        //    {
        //        // Attach handler only once
        //        editingTextBox.TextChanged += EditingTextBox_TextChanged;

        //        // If column 3, call live search
        //        if (col == 3)
        //        {
        //            dgvitem2.Visible = true;
        //            getdatasearchname(editingTextBox.Text);
        //        }
        //        else
        //        {
        //            dgvitem2.Visible = false;
        //        }
        //    }

        //    // Column 5 logic
        //    if (col == 5)
        //    {
        //        int row = dataGridViewPacking.CurrentCell.RowIndex;
        //        double qty = 0;

        //        double.TryParse(
        //            Convert.ToString(dataGridViewPacking.Rows[row].Cells[4].Value),
        //            out qty
        //        );

        //        // Do something with qty
        //    }
        //}

        private void txtbox_TextChanged(object sender, EventArgs e)
        {
            {
                if (dataGridViewPacking.CurrentCell == null)
                    return;

                int colindex = dataGridViewPacking.CurrentCell.ColumnIndex;
                TextBox txtbox = (TextBox)sender;
                string content = txtbox.Text;
                if (colindex == 3)
                {
                    dgvitem2.Visible = true;

                }

                Rectangle cellRect = dataGridViewPacking.GetCellDisplayRectangle(dataGridViewPacking.CurrentCell.ColumnIndex,
                    dataGridViewPacking.CurrentCell.RowIndex, false);

                int centerX = cellRect.Left + 30;
                int centerY = cellRect.Top + 60;
                dgvitem2.Location = new Point(centerX, centerY);

                dgvitem2.CellClick -= dgvitem2_CellClick;
                dgvitem2.CellClick += dgvitem2_CellClick;
            }
        }
        private void EditingTextBox_TextChanged(object sender, EventArgs e)
        {
            if (dataGridViewPacking.CurrentCell == null)
                return;
            if (dataGridViewPacking.CurrentCell.ColumnIndex == 3 || sender is TextBox txt0)
            {
                var txt = ((TextBox)sender).Text;
                getdatasearchname(txt);
            }
        }
        private void dgvitem2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewPacking.CurrentCell.ColumnIndex == 2 || dataGridViewPacking.CurrentCell.ColumnIndex == 3)
            {
                int row = dataGridViewPacking.CurrentCell.RowIndex;

                dataGridViewPacking.Rows[row].Cells[1].Value = dgvitem2.CurrentRow.Cells[0].Value;
                dataGridViewPacking.Rows[row].Cells[2].Value = dgvitem2.CurrentRow.Cells[1].Value;
                dataGridViewPacking.Rows[row].Cells[3].Value = dgvitem2.CurrentRow.Cells[2].Value;
                //dataGridViewPacking.Rows[row].Cells[5].Value = 0;
                //dataGridViewPacking.CurrentCell.Value = dgvitem2.CurrentRow.Cells[2].Value;

                dgvitem2.Visible = false;

                if (Convert.ToString(dataGridViewPacking.Rows[row].Cells[3].Value) == string.Empty)
                {
                    dataGridViewPacking.Rows[row].Cells[1].Value = 0;
                }
            }
        }

        private void dataGridViewPacking_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void dgvitem2_Leave(object sender, EventArgs e)
        {
            dgvitem2.Visible = false;
        }
    }
}
