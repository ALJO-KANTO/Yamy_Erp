using DocumentFormat.OpenXml.Office2010.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace YamyProject.UI.Manufacturing.Viewform
{
    public partial class frmManWorkOrderDetails : Form
    {
        bool AllowItemWithOutQty = true;
        int workOrderId = 0, warehouseFromId = 0, warehouseToId = 0;
        DateTime date;

        public List<int> SelectedStepIds { get; private set; } = new List<int>();

        public frmManWorkOrderDetails(int _wId)
        {
            InitializeComponent();
            this.workOrderId = _wId;
        }

        string status = "";

        public void GetMaterialDetails(int id)
        {
            int sn = 0;
            sn = sn + 1;
            string qry = @" SELECT  B.id, C.id itemId,C.code, C.name,B.cost,B.qty,IFNULL(C.on_hand,0) AvQty,B.Total,B.RequestQty,B.ReceiveQty
                           FROM `tbl_manufacturer_batchdetails` B
                           INNER JOIN tbl_items C ON C.id = B.itemid where   B.batchID = '" + id + "'";
            using (MySqlDataReader reader = DBClass.ExecuteReader(qry))
            {
                dgvItems.Rows.Clear();
                while (reader.Read())
                {
                    int rowIndex = dgvItems.Rows.Add(sn, reader["id"], reader["itemId"], reader["code"], reader["name"],
                                     reader["qty"], reader["AvQty"] , reader["RequestQty"], reader["ReceiveQty"], reader["cost"], reader["Total"]);

                    sn++;
                }
            }
        }

        private void frmManWorkOrderDetails_Load(object sender, EventArgs e)
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


            dgvItems.Rows.Clear();
            if (workOrderId > 0)
            {
                string qry = @" SELECT a.id, a.batchname, a.date, a.hours, a.amount, a.Description, IFNULL(b.status,'Pending') status,a.warehouse_id,a.warehouse_to_id,a.process_stage FROM tbl_manufacturer_batch a LEFT JOIN (
                                SELECT t.batchId,t.status FROM tbl_manufacturer_task t WHERE t.id IN (SELECT MAX(id) FROM tbl_manufacturer_task GROUP BY BatchID)
                            ) b ON b.BatchID = a.id WHERE a.id = '" + workOrderId + "'";

                using (MySqlDataReader reader = DBClass.ExecuteReader(qry))
                {
                    if (reader.Read())
                    {
                        status = reader["status"].ToString();
                        lblBatchName.Text = reader["batchname"].ToString();
                        lblStatus.Text = status;
                        warehouseFromId = Convert.ToInt32(reader["warehouse_id"]);
                        warehouseToId = Convert.ToInt32(reader["warehouse_to_id"]);
                        date = Convert.ToDateTime(reader["date"]);
                        GetMaterialDetails(workOrderId);
                        string stageString = reader["process_stage"].ToString();

                        List<int> stages = stageString
                            .Split(',')
                            .Where(x => !string.IsNullOrWhiteSpace(x))
                            .Select(x => int.Parse(x))
                            .ToList();

                        SelectedStepIds = stages;  // or AddRange
                        SelectedStepIds.AddRange(stages);
                    }
                }
            }

        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

            if (status == "Done" || status == "Progress")
            {
                MessageBox.Show("Cant update this work already " + status);
            }
            else
            {
                bool isValid = true;
                decimal _receiveQty = 0, _requestQty = 0, _qty = 0, _availableQty = 0;
                foreach (DataGridViewRow row in dgvItems.Rows)
                {
                    if (row != null && row.Cells["dgvqty"].Value != DBNull.Value)
                    {
                        decimal.TryParse(row.Cells["dgvqty"].Value?.ToString(), out _qty);
                    }
                    if (row != null && row.Cells["dgvReceiveQty"].Value != DBNull.Value)
                    {
                        decimal.TryParse(row.Cells["dgvReceiveQty"].Value?.ToString(), out _receiveQty);
                    }
                    if (row != null && row.Cells["dgvRequestQty"].Value != DBNull.Value)
                    {
                        decimal.TryParse(row.Cells["dgvRequestQty"].Value?.ToString(), out _requestQty);
                    }
                    if (row != null && row.Cells["dgvAvailQty"].Value != DBNull.Value)
                    {
                        decimal.TryParse(row.Cells["dgvAvailQty"].Value?.ToString(), out _availableQty);
                    }
                    if (_receiveQty > _requestQty)
                    {
                        MessageBox.Show(
                            "Receive Qty is greater than Request Qty",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                        isValid = false;
                        break;
                    }

                    if (_receiveQty > _qty || _requestQty > _qty)
                    {
                        MessageBox.Show(
                            "Receive Qty or Request Qty is greater than Qty",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                        isValid = false;
                        break;
                    }

                    if (_receiveQty > _availableQty)
                    {
                        MessageBox.Show(
                            "Receive Qty is no in stock please purchase",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                        isValid = false;
                        break;
                    }

                }
                if (isValid)
                {
                    string stages = SelectedStepIds.Count > 0 ? string.Join(",", SelectedStepIds) : "";
                    
                    // Remove previous batch details and stock consumption
                    DBClass.ExecuteNonQuery(@"DELETE FROM tbl_item_transaction 
                                  WHERE reference=@invId AND type='Manufacturing';
                                  DELETE FROM tbl_item_card_details 
                                  WHERE trans_type='Manufacturing' AND trans_no=@invId",
                                          DBClass.CreateParameter("@invId", workOrderId));
                    foreach (DataGridViewRow row in dgvItems.Rows)
                    {
                        int id = Convert.ToInt32(row.Cells["dgvid"].Value);
                        int itemId = Convert.ToInt32(row.Cells["dgvItemId"].Value);
                        _qty = Convert.ToDecimal(row.Cells["Dgvqty"].Value);
                        _requestQty = Convert.ToDecimal(row.Cells["dgvRequestQty"].Value);
                        _receiveQty = Convert.ToDecimal(row.Cells["dgvReceiveQty"].Value);

                        DBClass.ExecuteNonQuery("UPDATE tbl_manufacturer_batchdetails set RequestQty = @requestQty,ReceiveQty = @receiveQty where id = @id",
                            DBClass.CreateParameter("id", id),
                            DBClass.CreateParameter("requestQty", _requestQty),
                            DBClass.CreateParameter("receiveQty", _receiveQty));

                        if (_receiveQty>0)
                        {
                            // --------------------------------------------
                            // Save Batch Raw Material Details + Deduct Stock
                            // --------------------------------------------
                            //    foreach (DataGridViewRow row in dgvItems.Rows)
                            //    {
                            //        if (row.IsNewRow) continue;
                            //        if (row.Cells[3].Value == null) continue;

                            //        int itemId = Convert.ToInt32(row.Cells["dgvid"].Value);
                            decimal qtyUsed = Convert.ToDecimal(row.Cells["Dgvqty"].Value);
                            decimal cost = Convert.ToDecimal(row.Cells["dgvCost"].Value);

                            //        // 1. Save batch details
                            //        string qry2 = @"INSERT INTO tbl_manufacturer_batchdetails
                            //(batchID, itemid, cost, qty, Total)
                            //VALUES
                            //(@batchID, @itemid, @cost, @qty, @Total)";

                            //        DBClass.ExecuteNonQuery(qry2,
                            //            DBClass.CreateParameter("@batchID", id),
                            //            DBClass.CreateParameter("@itemid", itemId),
                            //            DBClass.CreateParameter("@cost", cost),
                            //            DBClass.CreateParameter("@qty", qtyUsed),
                            //            DBClass.CreateParameter("@Total", Convert.ToDecimal(row.Cells["DGVTOTATL"].Value))
                            //        );

                            // -----------------------------------------
                            // 2. Deduct stock from tbl_item_transaction
                            // -----------------------------------------
                            //From Warehouse
                            CommonInsert.InsertItemTransaction(date.Date, "Manufacturing", workOrderId.ToString(), itemId.ToString(), cost.ToString(), "0", "0", qtyUsed.ToString(), "0", "Material Transfer IN to Production Store for Batch " + lblBatchName.Text, warehouseFromId.ToString());
                            //To Warehouse
                            CommonInsert.InsertItemTransaction(date.Date, "Manufacturing", workOrderId.ToString(), itemId.ToString(), cost.ToString(), qtyUsed.ToString(), "0", "0", "0", "Material Consumed in Manufacturing for Batch " + lblBatchName.Text, warehouseToId.ToString());
                            //}
                            //using (MySqlDataReader itemReader = DBClass.ExecuteReader("select * from tbl_items where id = @id", DBClass.CreateParameter("id", Convert.ToInt32(itemId))))
                            //{
                            //    if (_receiveQty > 0)
                            //    {
                            //        if (itemReader.Read())
                            //        {
                            //            string itemType = Convert.ToString(itemReader["type"]);
                            //            string method = Convert.ToString(itemReader["method"]);
                            //            string salesPrice = Convert.ToString(itemReader["sales_price"]);
                            //            decimal qty = _receiveQty;

                            //            decimal costAmount = 0;

                            //            if (itemType == "12 - Service")
                            //            {
                            //                //
                            //            }
                            //            else if (itemType == "13 - Inventory Assembly")
                            //            {
                            //                using (MySqlDataReader componentReader = DBClass.ExecuteReader(@"
                            //                SELECT itemid, qty,(select method FROM tbl_items WHERE tbl_items.id = tbl_manufacturer_batchdetails.itemid) as method 
                            //                FROM tbl_manufacturer_batchdetails WHERE batchid = @assemblyId",
                            //                    DBClass.CreateParameter("assemblyId", itemId)))
                            //                {
                            //                    while (componentReader.Read())
                            //                    {
                            //                        int componentId = Convert.ToInt32(componentReader["item_id"]);
                            //                        decimal componentQty = Convert.ToDecimal(componentReader["qty"]) * qty;
                            //                        string methodOfIngrediant = componentReader["method"].ToString().Trim();

                            //                        DBClass.ExecuteNonQuery(@"
                            //                    UPDATE tbl_items 
                            //                    SET on_hand = on_hand - @qty 
                            //                    WHERE id = @componentId",
                            //                            DBClass.CreateParameter("qty", componentQty),
                            //                            DBClass.CreateParameter("componentId", componentId));

                            //                        decimal costReturned = InsertItemTransaction(componentId, componentQty, methodOfIngrediant, salesPrice);
                            //                        costAmount = costReturned;
                            //                        //totalCostAllItems += costReturned;
                            //                    }
                            //                }
                            //            }
                            //            else
                            //            {
                            //                using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT * FROM tbl_items WHERE id=@id",
                            //               DBClass.CreateParameter("id", itemId)))
                            //                {
                            //                    if (reader.Read())
                            //                    {
                            //                        decimal onHand = Convert.ToDecimal(reader["on_hand"]);
                            //                        DBClass.ExecuteNonQuery("UPDATE tbl_items SET on_hand = @newQty WHERE id = @id",
                            //                            DBClass.CreateParameter("newQty", onHand - qty),
                            //                            DBClass.CreateParameter("id", itemId));

                            //                        decimal costReturned = InsertItemTransaction(itemId, qty, method, salesPrice);
                            //                        costAmount = costReturned;
                            //                        //totalCostAllItems += costReturned;
                            //                    }
                            //                }
                            //            }
                            //        }
                            //    }
                            //}
                        }
                    }
                    DBClass.ExecuteNonQuery("UPDATE tbl_manufacturer_batch set process_stage=@stages where id = @id",
                            DBClass.CreateParameter("id", workOrderId),
                            DBClass.CreateParameter("stages", stages));

                    Utilities.LogAudit(frmLogin.userId, "Update Work Order", "Work Order", workOrderId, "Updated Work Order: " + lblBatchName.Text);

                    MessageBox.Show(
                        "Update Successfully",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );


                }
            }
        }

        private decimal InsertItemTransactionOldXXX(int itemId, decimal qty, string method, string sales_price)
        {
            string invId = workOrderId.ToString();
            DateTime dated = DateTime.Now;
            if (AllowItemWithOutQty)
            {
                decimal cost_price = 0;
                decimal totalCost = 0;


                DeleteItemTransaction(invId.ToString(), itemId);

                object result = DBClass.ExecuteScalar(@"SELECT cost_price FROM tbl_item_transaction 
                                            WHERE item_id = @id AND date <= @date 
                                            ORDER BY date DESC LIMIT 1",
                                DBClass.CreateParameter("id", itemId), DBClass.CreateParameter("date", dated.Date));

                if (result != null && result != DBNull.Value)
                {
                    cost_price = Convert.ToDecimal(result);
                }

                totalCost = cost_price * qty;

                CommonInsert.InsertItemTransaction(dated.Date, "Manufacturing", invId.ToString(), itemId.ToString(),
                    cost_price.ToString(), "0", sales_price, qty.ToString(), "0",
                    "Manufacturing (Negative Stock)", warehouseFromId.ToString());

                return totalCost;
            }
            else
            {
                if (itemId <= 0 || qty <= 0)
                {
                    MessageBox.Show("Invalid Item ID or Quantity.");
                    return 0;
                }

                decimal cost_price = 0;
                decimal totalCost = 0;
                DeleteItemTransaction(invId.ToString(), itemId);
                MySqlDataReader reader = null;

                if (method == "fifo" || method == "lifo")
                {
                    string orderBy = method == "fifo" ? "ASC" : "DESC";
                    decimal remainingQty = qty;

                    reader = DBClass.ExecuteReader(@"
                        SELECT * FROM tbl_item_transaction 
                        WHERE date <= @date AND qty_inc > 0 AND item_id = @id 
                        ORDER BY id " + orderBy,
                        DBClass.CreateParameter("id", itemId), DBClass.CreateParameter("date", dated.Date));

                    while (reader.Read() && remainingQty > 0)
                    {
                        decimal availableQty = Convert.ToDecimal(reader["qty_inc"]);
                        cost_price = Convert.ToDecimal(reader["cost_price"]);
                        decimal qtyToUse = Math.Min(remainingQty, availableQty);

                        remainingQty -= qtyToUse;
                        totalCost += cost_price * qtyToUse;

                        CommonInsert.InsertItemTransaction(dated.Date, "Manufacturing", invId.ToString(), itemId.ToString(),
                            cost_price.ToString(), "0", sales_price, qtyToUse.ToString(), "0",
                            "Manufacturing . ", warehouseFromId.ToString());

                        DBClass.ExecuteNonQuery("UPDATE tbl_item_transaction SET qty_inc = qty_inc - @qty WHERE id = @id",
                            DBClass.CreateParameter("qty", qtyToUse),
                            DBClass.CreateParameter("id", reader["id"].ToString()));
                    }

                    // If some quantity remains unprocessed (not enough stock), allow negative stock handling
                    if (remainingQty > 0)
                    {
                        // Use last known or default cost
                        if (cost_price <= 0)
                        {
                            object fallbackCost = DBClass.ExecuteScalar(@"SELECT cost_price FROM tbl_item_transaction 
                                                              WHERE item_id = @id AND date <= @date 
                                                              ORDER BY date DESC LIMIT 1",
                                        DBClass.CreateParameter("id", itemId), DBClass.CreateParameter("date", dated.Date));
                            if (fallbackCost != null && fallbackCost != DBNull.Value)
                                cost_price = Convert.ToDecimal(fallbackCost);
                        }

                        totalCost += cost_price * remainingQty;

                        CommonInsert.InsertItemTransaction(dated.Date, "Manufacturing", invId.ToString(), itemId.ToString(),
                            cost_price.ToString(), "0", sales_price, remainingQty.ToString(), "0",
                            "Manufacturing No. " + " (Neg. Stock)", warehouseFromId.ToString());
                    }
                }
                else
                {
                    object result = DBClass.ExecuteScalar(@"SELECT 
                            CASE 
                                WHEN SUM(qty_in - qty_out) = 0 THEN 0
                                ELSE SUM((qty_in - qty_out) * cost_price) / SUM(qty_in - qty_out)
                            END AS cost_price 
                        FROM 
                            tbl_item_transaction 
                        WHERE item_id = @id AND date <= @date",
                                DBClass.CreateParameter("id", itemId), DBClass.CreateParameter("date", dated.Date));

                    decimal recordcost_price = (result != null && result != DBNull.Value) ? Convert.ToDecimal(result) : 0;

                    if (recordcost_price > 0)
                    {
                        cost_price = recordcost_price;
                    }

                    CommonInsert.InsertItemTransaction(dated.Date, "Manufacturing", invId.ToString(), itemId.ToString(),
                        cost_price.ToString(), "0", sales_price.ToString(), qty.ToString(), "0",
                        "Manufacturing No. ", warehouseFromId.ToString());

                    using (MySqlDataReader dr = DBClass.ExecuteReader(@"SELECT (balance / qty_balance) cost FROM tbl_item_card_details 
                                WHERE DATE <= @date AND trans_type = 'Purchase Invoice' AND itemId = @itemId
                                ORDER BY trans_no DESC LIMIT 1",
                            DBClass.CreateParameter("date", dated.Date),
                            DBClass.CreateParameter("itemId", itemId.ToString())))
                    {
                        if (dr.Read())
                        {
                            totalCost = decimal.Parse(dr["cost"].ToString()) * qty;
                        }
                    }
                }

                return totalCost;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal; // Restore down
            }
            else
            {
                this.WindowState = FormWindowState.Maximized; // Maximize
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnProcessStage_Click(object sender, EventArgs e)
        {
            //dialog with tbl_manufacturing_steps
            var selectedIds = ShowStepSelectionDialog();

            if (selectedIds != null && selectedIds.Count > 0)
            {
                string stages = string.Join(",", selectedIds);
                SelectedStepIds = selectedIds;
            }
        }

        private void DeleteItemTransaction(string reference, int itemId)
        {
            DBClass.ExecuteNonQuery("DELETE FROM tbl_item_transaction WHERE `type` = 'Manufacturing' and item_id = @itemId AND `REFERENCE` = @id", DBClass.CreateParameter("id", reference), DBClass.CreateParameter("itemId", itemId));
            DBClass.ExecuteNonQuery("DELETE FROM tbl_item_card_details WHERE `trans_type` = 'Manufacturing' and itemId = @itemId AND `trans_no` = @id", DBClass.CreateParameter("id", reference), DBClass.CreateParameter("itemId", itemId));
            CommonInsert.UpdateOnHandItem(itemId.ToString());
        }

        private List<int> ShowStepSelectionDialog()
        {
            // Load steps from DB
            List<StepInfo> steps = LoadStepsFromDB();
            HeaderUC headerUC1 = new HeaderUC();
            System.Windows.Forms.Panel panel3 = new System.Windows.Forms.Panel();
            System.Windows.Forms.Panel panel1 = new System.Windows.Forms.Panel();
            System.Windows.Forms.Panel panel2 = new System.Windows.Forms.Panel();

            // Create dynamic form
            Form dialog = new Form();
            dialog.Text = "Select Manufacturing Steps";
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.Size = new System.Drawing.Size(400, 500);
            dialog.FormBorderStyle = FormBorderStyle.None;
            // 
            // headerUC1
            // 
            headerUC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            headerUC1.Dock = System.Windows.Forms.DockStyle.Top;
            headerUC1.FormText = "";
            headerUC1.HeaderText = "";
            headerUC1.Location = new System.Drawing.Point(0, 0);
            headerUC1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            headerUC1.Name = "headerUC1";
            headerUC1.Size = new System.Drawing.Size(325, 37);
            headerUC1.TabIndex = 1;
            headerUC1.FormText = "Manufacturing Steps";
            // 
            // panel3
            // 
            panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            panel3.Dock = System.Windows.Forms.DockStyle.Left;
            panel3.Location = new System.Drawing.Point(0, 41);
            panel3.Margin = new System.Windows.Forms.Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(2, 235);
            panel3.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(2, 274);
            panel1.Margin = new System.Windows.Forms.Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(309, 2);
            panel1.TabIndex = 14;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            panel2.Dock = System.Windows.Forms.DockStyle.Right;
            panel2.Location = new System.Drawing.Point(309, 41);
            panel2.Margin = new System.Windows.Forms.Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(2, 233);
            panel2.TabIndex = 15;
            // Create checked list box dynamically
            CheckedListBox clb = new CheckedListBox();
            clb.Dock = DockStyle.Top;
            clb.Height = 400;

            // Add steps + pre-check existing selected steps
            foreach (var step in steps)
            {
                int index = clb.Items.Add(step);

                if (SelectedStepIds.Contains(step.Id))
                    clb.SetItemChecked(index, true);
            }

            // OK button
            Button btnOk = new Button();
            btnOk.Text = "OK";
            btnOk.Dock = DockStyle.Bottom;
            btnOk.Height = 40;

            // Close dialog when OK is clicked
            btnOk.Click += (s, e) => dialog.DialogResult = DialogResult.OK;

            // Add controls to form
            dialog.Controls.Add(clb);
            dialog.Controls.Add(btnOk);
            dialog.Controls.Add(headerUC1);
            dialog.Controls.Add(panel2);
            dialog.Controls.Add(panel1);
            dialog.Controls.Add(panel3);

            // Show dialog
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<int> selectedIds = new List<int>();

                foreach (var item in clb.CheckedItems)
                    selectedIds.Add(((StepInfo)item).Id);

                return selectedIds;
            }

            return new List<int>();
        }
        private List<StepInfo> LoadStepsFromDB()
        {
            List<StepInfo> list = new List<StepInfo>();
            string query = "SELECT id, step_name FROM tbl_Manufacturing_Steps ORDER BY step_order";

            using (MySqlDataReader dr = DBClass.ExecuteReader(query))
            {
                while (dr.Read())
                {
                    list.Add(new StepInfo
                    {
                        Id = dr.GetInt32("id"),
                        Name = dr.GetString("step_name")
                    });
                }
            }

            return list;
        }

        private void BtnLPO_Click(object sender, EventArgs e)
        {
            new frmPurchaseOrder().ShowDialog();
        }

        private class StepInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }

    }
}
