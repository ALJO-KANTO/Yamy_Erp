using CrystalDecisions.CrystalReports.Engine;
using Guna.UI2.WinForms;
using Microsoft.Vbe.Interop;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace YamyProject.UI.Construction.DailySiteWork
{
    public partial class frmProjectDailySiteWork : Form
    {
        int id;
        int tenderIds = 0, PlanningId = 0;
        public frmProjectDailySiteWork(int id = 0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            dgvDailyWork.EnableHeadersVisualStyles = false; // important
            AppTheme.DefaultFont(dgvDailyWork);
            this.id = id;
            headerUC1.FormText = this.Text;
        }

        private void DailySiteWork_Load(object sender, EventArgs e)
        {
            BindCombo();
            /*
             * tbl_project_daily_work (
                            id INT NOT NULL AUTO_INCREMENT,
                            planning_id INT NOT NULL DEFAULT 0,
                            project_id INT NOT NULL DEFAULT 0,
                            site_id INT NOT NULL DEFAULT 0,
                            tender_id INT NOT NULL DEFAULT 0,
                            boq_item_id INT NOT NULL DEFAULT 0,
                            work_date DATE,
                            today_qty DECIMAL(18,3) NOT NULL DEFAULT 0,
                            cumulative_qty DECIMAL(18,3) NOT NULL DEFAULT 0,
                            progress DECIMAL(10,2) NOT NULL DEFAULT 0,
                            remarks VARCHAR(500) DEFAULT '',
                            created_by INT NOT NULL DEFAULT 0,
                            created_date DATETIME,
                            modified_by INT NOT NULL DEFAULT 0,
                            modified_date
             */
            if (id != 0)
            {
                BindData();
            }
        }

        private void BindData()
        {
            MySqlDataReader reader = DBClass.ExecuteReader(" select * from tbl_project_daily_work where id = @id",
                DBClass.CreateParameter("id", id));
            if (reader.Read())
            {
                dtInv.Value = DateTime.Parse(reader["date"].ToString());
                cmbProjectName.SelectedValue = int.Parse(reader["project_id"].ToString());
                cmbProjectSite.SelectedValue = int.Parse(reader["site"].ToString());
            }
        }

        public void BindCombo()
        {
            //BindCombos.PopulateTenderedProjects(cmbProjectName);
            string query = @"
                SELECT 
                    CONCAT(p.CODE, ' - ', p.name) AS name, 
                    p.id 
                FROM tbl_projects p
                WHERE p.id IN (SELECT project_id FROM tbl_projects_site_setup)";
            cmbProjectName.DataSource = DBClass.ExecuteDataTable(query);
            cmbProjectName.DisplayMember = "name";
            cmbProjectName.ValueMember = "id";

            query = @"
                    SELECT 
                        CONCAT(p.CODE, ' - ', p.name) AS name, 
                        p.id 
                    FROM tbl_project_sites p
                    WHERE p.id IN (SELECT site FROM tbl_projects_site_setup)";
            cmbProjectSite.DataSource = DBClass.ExecuteDataTable(query);
            cmbProjectSite.DisplayMember = "name";
            cmbProjectSite.ValueMember = "id";
        }
        private void BOQItemComboBox()
        {
            if (tenderIds == 0) return;

            DataTable dt = DBClass.ExecuteDataTable(@"SELECT tbl_items_boq.id,tbl_items_boq.name FROM tbl_project_tender_details 
                                INNER JOIN tbl_items_boq ON tbl_project_tender_details.tender_id = ref_id AND tbl_project_tender_details.item_id=tbl_items_boq.id
                                WHERE tbl_project_tender_details.tender_id = @tenderId", DBClass.CreateParameter("tenderId", tenderIds));

            DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)dgvDailyWork.Columns["BOQItem"];
            col.DataSource = dt;
            col.DisplayMember = "name";
            col.ValueMember = "id";
            col.FlatStyle = FlatStyle.Popup;
            col.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
        }

        private void dgvDailyWork_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int colIndex = dgvDailyWork.CurrentCell.ColumnIndex;

            if (e.Control is TextBox textBoxBase)
            {
                textBoxBase.KeyPress -= NumericColumn_KeyPress;
            }

            if (colIndex == dgvDailyWork.Columns["BOQItem"].Index)
            {
                if (e.Control is ComboBox comboBox)
                {
                    comboBox.SelectedIndexChanged -= ComboBoxBoqItem_SelectedIndexChanged;
                    comboBox.SelectedIndexChanged += ComboBoxBoqItem_SelectedIndexChanged;
                }
            }
            else if (dgvDailyWork.CurrentCell.OwningColumn.Name == "TodayQty")
            {
                if (e.Control is TextBox textBox)
                {
                    textBox.KeyPress -= NumericColumn_KeyPress;
                    textBox.KeyPress += NumericColumn_KeyPress;
                }
            }
        }
        private void ComboBoxBoqItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox combo && combo.SelectedItem is DataRowView selectedRow)
            {
                if (dgvDailyWork.CurrentCell == null || dgvDailyWork.CurrentCell.ColumnIndex != dgvDailyWork.Columns["BOQItem"].Index)
                    return;

                var row = dgvDailyWork.CurrentRow;
                if (row == null) return;

                string itemId = selectedRow["id"].ToString();
                string itemName = selectedRow["name"].ToString();

                using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT qty,unit_name,sr FROM tbl_items_boq WHERE id = @id",
                    DBClass.CreateParameter("id", itemId)))
                {
                    if (reader.Read())
                    {
                        decimal qty = reader.GetDecimal("qty");
                        row.Cells["BoqQty"].Value = qty;
                        row.Cells["unit"].Value = reader["unit_name"].ToString();
                        row.Cells["sr"].Value = reader["sr"].ToString();
                        object prevDoneQtyObj = DBClass.ExecuteScalar("SELECT IFNULL(SUM(today_qty),0) FROM tbl_project_daily_work WHERE boq_item_id = @boqItemId and project_id = @projectId and site_id = @siteId and tender_id=@tenderId",
                            DBClass.CreateParameter("boqItemId", itemId), DBClass.CreateParameter("projectId", cmbProjectName.SelectedValue), DBClass.CreateParameter("siteId", cmbProjectSite.SelectedValue), DBClass.CreateParameter("tenderId", tenderIds));
                        row.Cells["PrevDoneQty"].Value = "0";
                        if (prevDoneQtyObj != null && decimal.TryParse(prevDoneQtyObj.ToString(), out decimal _prevDoneQty))
                        {
                            row.Cells["PrevDoneQty"].Value = _prevDoneQty;
                        }
                    }
                }

                decimal boqQty = GetDecimalValue(row, "BoqQty");
                decimal prevDoneQty = GetDecimalValue(row, "PrevDoneQty");

                if (boqQty == 0)
                {
                    row.Cells["CumQty"].Value = "0";
                }
                else
                {
                    ChkRowValidity(row);
                }
            }
        }
        private void ChkRowValidity(DataGridViewRow row)
        {
            if (row == null) return;

            decimal todayQty = GetDecimalValue(row, "todayQty");
            decimal prevDoneQty = GetDecimalValue(row, "PrevDoneQty");
            decimal boqQty = GetDecimalValue(row, "BoqQty");

            if (todayQty != 0)
            {
                if(boqQty < todayQty + prevDoneQty)
                {
                    MessageBox.Show("BOQ Qty not available");
                    row.Cells["todayQty"].Value = "0";
                    return;
                }
                try
                {
                    decimal cumQty = prevDoneQty + todayQty;
                    row.Cells["CumQty"].Value = cumQty;
                    decimal balanceQty = boqQty - cumQty;
                    decimal progress = (cumQty / boqQty) * 100;

                    string itemId = row.Cells["BOQItem"].Value?.ToString() ?? "0";

                    row.Cells["BalanceQty"].Value = balanceQty;
                    row.Cells["Progress"].Value = progress.ToString("0.00");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("calc error: " + ex.Message);
                }
            }
        }
        private decimal GetDecimalValue(DataGridViewRow row, string columnName)
        {
            decimal result;
            var cellValue = row.Cells[columnName].Value;
            if (cellValue != null && decimal.TryParse(cellValue.ToString(), out result))
                return result;
            else
                return 0;
        }
        private void NumericColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // block anything that's not a digit or decimal point
            }

            // Allow only one decimal point
            TextBox txt = sender as TextBox;
            if (e.KeyChar == '.' && txt.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
        private void dgvDailyWork_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var row = dgvDailyWork.Rows[e.RowIndex];
            var columnName = dgvDailyWork.Columns[e.ColumnIndex].Name;
            string inputText = row.Cells[e.ColumnIndex].Value?.ToString()?.Trim();
            //var itemId = row.Cells["itemId"].Value?.ToString();
        }

        private void dgvDailyWork_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDailyWork.Rows.Count > 1)
            {
                var row = dgvDailyWork.Rows[e.RowIndex];
                //decimal price = GetDecimalValue(row, "price");
                //decimal qty = GetDecimalValue(row, "todayQty");
                //decimal costPrice = GetDecimalValue(row, "cost_price");
                //decimal discount = GetDecimalValue(row, "discount");
                //if (e.ColumnIndex == dgvDailyWork.Columns["price"].Index && dgvDailyWork.Rows[e.RowIndex].Cells["type"].Value != null && dgvDailyWork.Rows[e.RowIndex].Cells["type"].Value.ToString() != "Service")
                //{
                //    if (price < costPrice)
                //    {
                //        MessageBox.Show("Sales Price Must Be Greater Than Cost Price");
                //        row.Cells["price"].Value = costPrice;
                //    }
                //}
                //else if (e.ColumnIndex == dgvDailyWork.Columns["Name"].Index)
                //{
                //    string nameValue = row.Cells["Name"].Value?.ToString();
                //    if (!string.IsNullOrWhiteSpace(nameValue))
                //        insertItemThroughCodeOrText("name", nameValue);
                //}
                //else 
                if (e.ColumnIndex == dgvDailyWork.Columns["todayQty"].Index)
                {
                    ChkRowValidity(row);
                    CalculateTotal();
                }
            }
        }

        private void cmbProjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmbProjectSite
        }

        private void cmbProjectSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if (!cmbProjectSite.Focused) return;
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT tender_id,(SELECT NAME FROM tbl_tender_names WHERE id = tender_id) name FROM tbl_projects_site_setup WHERE project_id = @projectId AND site = @siteId",
                DBClass.CreateParameter("projectId", cmbProjectName.SelectedValue), DBClass.CreateParameter("siteId", cmbProjectSite.SelectedValue)))
            {
                if (reader.Read())
                {
                    tenderIds = int.Parse(reader["tender_id"].ToString());
                    txtTenderName.Text = reader["name"].ToString();
                    BOQItemComboBox();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProjectName.SelectedIndex == -1 || cmbProjectName.SelectedValue == null)
                {
                    MessageBox.Show("Please select project.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbProjectName.Focus();
                    return;
                }

                if (cmbProjectSite.SelectedIndex == -1 || cmbProjectSite.SelectedValue == null)
                {
                    MessageBox.Show("Please select site.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbProjectSite.Focus();
                    return;
                }

                if (tenderIds <= 0)
                {
                    MessageBox.Show("Please select tender.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool hasValidRow = false;

                foreach (DataGridViewRow row in dgvDailyWork.Rows)
                {
                    if (row.IsNewRow) continue;

                    decimal boqQty = 0;
                    decimal prevDoneQty = 0;
                    decimal todayQty = 0;
                    decimal cumQty = 0;

                    decimal.TryParse(Convert.ToString(row.Cells["boqQty"].Value), out boqQty);
                    decimal.TryParse(Convert.ToString(row.Cells["prevDoneQty"].Value), out prevDoneQty);
                    decimal.TryParse(Convert.ToString(row.Cells["todayQty"].Value), out todayQty);
                    decimal.TryParse(Convert.ToString(row.Cells["cumQty"].Value), out cumQty);

                    // Save only rows where Today Qty > 0
                    if (todayQty > 0)
                    {
                        hasValidRow = true;

                        // BOQ item required
                        if (row.Cells["boqItem"].Value == null || row.Cells["boqItem"].Value.ToString() == "")
                        {
                            MessageBox.Show("BOQ Item is missing in one of the rows.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvDailyWork.CurrentCell = row.Cells["todayQty"];
                            dgvDailyWork.BeginEdit(true);
                            return;
                        }

                        // Today Qty should not be negative
                        if (todayQty < 0)
                        {
                            MessageBox.Show("Today Qty cannot be negative.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvDailyWork.CurrentCell = row.Cells["todayQty"];
                            dgvDailyWork.BeginEdit(true);
                            return;
                        }

                        // Cum Qty validation
                        if (cumQty > boqQty)
                        {
                            MessageBox.Show("Cumulative Qty cannot exceed BOQ Qty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvDailyWork.CurrentCell = row.Cells["todayQty"];
                            dgvDailyWork.BeginEdit(true);
                            return;
                        }
                    }
                }

                if (!hasValidRow)
                {
                    MessageBox.Show("Please enter at least one row with Today Qty greater than zero.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int projectId = Convert.ToInt32(cmbProjectName.SelectedValue);
                int siteId = Convert.ToInt32(cmbProjectSite.SelectedValue);
                DateTime workDate = dtInv.Value.Date;

                string deleteQuery = @"DELETE FROM tbl_project_daily_work 
                               WHERE project_id = @project_id 
                               AND site_id = @site_id 
                               AND work_date = @work_date";

                using (MySqlConnection con = new MySqlConnection(DBClass.GetConnectionString()))
                {
                    con.Open();

                    using (MySqlTransaction tran = con.BeginTransaction())
                    {
                        try
                        {
                            // Delete existing rows for same date/site
                            using (MySqlCommand cmdDelete = new MySqlCommand(deleteQuery, con, tran))
                            {
                                cmdDelete.Parameters.AddWithValue("@project_id", projectId);
                                cmdDelete.Parameters.AddWithValue("@site_id", siteId);
                                cmdDelete.Parameters.AddWithValue("@work_date", workDate);
                                cmdDelete.ExecuteNonQuery();
                            }

                            // Insert rows
                            foreach (DataGridViewRow row in dgvDailyWork.Rows)
                            {
                                if (row.IsNewRow) continue;

                                decimal boqQty = 0;
                                decimal prevDoneQty = 0;
                                decimal todayQty = 0;
                                decimal cumQty = 0;
                                decimal progress = 0;

                                decimal.TryParse(Convert.ToString(row.Cells["boqQty"].Value), out boqQty);
                                decimal.TryParse(Convert.ToString(row.Cells["prevDoneQty"].Value), out prevDoneQty);
                                decimal.TryParse(Convert.ToString(row.Cells["todayQty"].Value), out todayQty);
                                decimal.TryParse(Convert.ToString(row.Cells["cumQty"].Value), out cumQty);
                                decimal.TryParse(Convert.ToString(row.Cells["progress"].Value), out progress);

                                if (todayQty <= 0) continue; // Save only worked rows

                                int boqItemId = Convert.ToInt32(row.Cells["boqItem"].Value);
                                string remarks = Convert.ToString(row.Cells["remarks"].Value ?? "");

                                string insertQuery = @"INSERT INTO tbl_project_daily_work
                                                (
                                                    planning_id,
                                                    project_id,
                                                    site_id,
                                                    tender_id,
                                                    boq_item_id,
                                                    work_date,
                                                    today_qty,
                                                    cumulative_qty,
                                                    progress,
                                                    remarks,
                                                    created_by,
                                                    created_date,
                                                    modified_by,
                                                    modified_date
                                                )
                                                VALUES
                                                (
                                                    @planning_id,
                                                    @project_id,
                                                    @site_id,
                                                    @tender_id,
                                                    @boq_item_id,
                                                    @work_date,
                                                    @today_qty,
                                                    @cumulative_qty,
                                                    @progress,
                                                    @remarks,
                                                    @created_by,
                                                    @created_date,
                                                    @modified_by,
                                                    @modified_date
                                                )";

                                using (MySqlCommand cmdInsert = new MySqlCommand(insertQuery, con, tran))
                                {
                                    // if you have PlanningId property in form
                                    cmdInsert.Parameters.AddWithValue("@planning_id", PlanningId); // or 0 if not used
                                    cmdInsert.Parameters.AddWithValue("@project_id", projectId);
                                    cmdInsert.Parameters.AddWithValue("@site_id", siteId);
                                    cmdInsert.Parameters.AddWithValue("@tender_id", tenderIds);
                                    cmdInsert.Parameters.AddWithValue("@boq_item_id", boqItemId);
                                    cmdInsert.Parameters.AddWithValue("@work_date", workDate);
                                    cmdInsert.Parameters.AddWithValue("@today_qty", todayQty);
                                    cmdInsert.Parameters.AddWithValue("@cumulative_qty", cumQty);
                                    cmdInsert.Parameters.AddWithValue("@progress", progress);
                                    cmdInsert.Parameters.AddWithValue("@remarks", remarks);

                                    // replace with your actual login user id
                                    cmdInsert.Parameters.AddWithValue("@created_by", frmLogin.userId);
                                    cmdInsert.Parameters.AddWithValue("@created_date", DateTime.Now);
                                    cmdInsert.Parameters.AddWithValue("@modified_by", frmLogin.userId);
                                    cmdInsert.Parameters.AddWithValue("@modified_date", DateTime.Now);

                                    cmdInsert.ExecuteNonQuery();
                                }
                            }

                            tran.Commit();

                            MessageBox.Show("Daily site work saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh grid after save
                            LoadBOQDailyWork();   // your method to reload BOQ + previous progress
                            CalculateTotal();
                        }
                        catch (Exception exTran)
                        {
                            tran.Rollback();
                            MessageBox.Show("Error while saving daily site work.\n\n" + exTran.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBOQDailyWork()
        {
            // Implement this method to load BOQ items along with previous progress based on selected project/site
        }

        private void guna2TileButton25_Click(object sender, EventArgs e)
        {
            frmLogin.frmMain.openChildForm(new MasterProjectDailySiteWork());
        }

        private void CalculateTotal()
        {
            decimal totalTodayQty = 0;
            decimal totalBOQQty = 0;
            decimal totalCumQty = 0;

            foreach (DataGridViewRow row in dgvDailyWork.Rows)
            {
                if (row.IsNewRow) continue;

                // Total Today Qty
                if (row.Cells["todayQty"].Value != null && row.Cells["todayQty"].Value.ToString() != "")
                    totalTodayQty += Convert.ToDecimal(row.Cells["todayQty"].Value);

                // Total BOQ Qty
                if (row.Cells["boqQty"].Value != null && row.Cells["boqQty"].Value.ToString() != "")
                    totalBOQQty += Convert.ToDecimal(row.Cells["boqQty"].Value);

                // Total Cumulative Qty
                if (row.Cells["cumQty"].Value != null && row.Cells["cumQty"].Value.ToString() != "")
                    totalCumQty += Convert.ToDecimal(row.Cells["cumQty"].Value);
            }

            lblTodayQty.Text = totalTodayQty.ToString("0.00");

            decimal overallProgress = 0;
            if (totalBOQQty > 0)
                overallProgress = (totalCumQty / totalBOQQty) * 100;

            lblOverallProgress.Text = overallProgress.ToString("0.00") + " %";
        }
    }
}
