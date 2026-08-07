using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.Job_Card
{
    public partial class frmJobCard : Form
    {
        private EventHandler customerUpdatedHandler;
        private EventHandler warehouseUpdatedHandler;
        int jId;
        string type = "";
        string quotation_id = "0", sales_order_id = "0";
        public frmJobCard(int _id = 0, string _type = "")
        {
            InitializeComponent();
            headerUC1.FormText = "Job Card";
            LocalizationManager.LocalizeForm(this);
            customerUpdatedHandler = (sender, args) => BindCombos.PopulateCustomers(cmbCustomer);
            warehouseUpdatedHandler = (sender, args) => BindCombos.PopulateWarehouse(cmbWarehouse);
            EventHub.Customer += customerUpdatedHandler;
            EventHub.wareHouse += warehouseUpdatedHandler;
            this.jId = _id;
            type = _type;
        }

        private void frmJobCard_Load(object sender, EventArgs e)
        {
            txtJobCardNo.Text = GenerateNextJobCode();
            BindCombos.PopulateEmployees(cmbSalesMan);
            BindCombos.PopulateEmployees(cmbTechnician); 
            BindCombos.PopulateCustomers(cmbCustomer);
            BindCombos.PopulateWarehouse(cmbWarehouse);
            cmbCustomer.SelectedIndex = -1;

            txtId.Text = GenerateNextJobId();
            loadVat();

            if (jId != 0)
            {
                BindInvoice();
            }
            if (type.StartsWith("SQ"))
            {
                string typeOf = type.Split('-')[0];
                quotation_id = type.Split('-')[1];
            } else if (type.StartsWith("SO"))
            {
                string typeOf = type.Split('-')[0];
                sales_order_id = type.Split('-')[1];
            }
        }
        private void loadVat()
        {
            // ColumnPartCode, ColumnDescription, ColumnWarehouse, ColumnQty, ColumnPrice, ColumnDiscount, ColumnVAT, ColumnVatP, ColumnCharge, ColumnTotal

            DataTable dtItem = DBClass.ExecuteDataTable("select id,name from tbl_items");
            DataGridViewComboBoxColumn itemCol = (DataGridViewComboBoxColumn)dgvParts.Columns["ColumnDescription"];
            itemCol.DataSource = dtItem;
            itemCol.DisplayMember = "name";
            itemCol.ValueMember = "id";
            itemCol.FlatStyle = FlatStyle.Popup;
            itemCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            itemCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            itemCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataTable dt = DBClass.ExecuteDataTable("SELECT id, CONCAT(name, '-', value, '%') AS display_text, value FROM tbl_tax");

            DataGridViewComboBoxColumn vatCol = (DataGridViewComboBoxColumn)dgvParts.Columns["ColumnVatP"];
            vatCol.DataSource = dt;
            vatCol.DisplayMember = "display_text";
            vatCol.ValueMember = "id";
            vatCol.FlatStyle = FlatStyle.Popup;
            vatCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            vatCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            vatCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //vatCol.Width = 110;

            string dTax = Utilities.GeneralSettings("DEFAULT TAX PERCENTAGE");
            if (!string.IsNullOrEmpty(dTax) && int.TryParse(dTax, out int val) && val > 0)
            {
                defaultTax = dTax;
            }
        }
        string defaultTax = "";
        private void BindInvoice()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader(" select * from tbl_job_card where id = @id",
                DBClass.CreateParameter("id", jId)))
                if (reader.Read())
                {
                    txtId.Text = reader["id"].ToString();
                    txtCustCode.Text = reader["code"].ToString();
                    cmbCustomer.SelectedValue = reader["customer_id"];
                    cmbVehicle.SelectedValue = reader["vehicle_id"];
                    cmbSalesMan.SelectedValue = reader["advisor_id"];
                    dtDate.Value = reader.GetDateTime("job_date");
                    dtExpectedDelivery.Value = reader.GetDateTime("expected_delivery");
                    txtMileage.Text = reader["mileage"].ToString();
                    txtFuelLevel.Text = reader["fuel_type"].ToString();
                    //txtPriority.Text = reader["priority"];
                    richTextCustomerComplaint.Text = reader["complaint"].ToString();
                    richTextBoxDiagnosis.Text = reader["diagnosis"].ToString();
                    richTextBoxWorkRequired.Text = reader["work_required"].ToString();
                    //txtremarks.Text = reader["remarks"];
                    //txtestimated_amount.Text = reader["estimated_amount"];
                    //txtapproved_amount.Text = reader["approved_amount"];
                    cmbStatus.Text = reader["status"].ToString();
                    //chkActive.Checked = reader.GetInt32("active") ==1? true : false;
                    //        created_by
                    //        created_date DATE,
                    //        state

                    if (cmbCustomer.SelectedValue != null)
                    {
                        LoadCustomerDetial();
                        cmbVehicle.SelectedValue = reader["vehicle_id"];
                    }
                    if (cmbVehicle.SelectedValue != null)
                        LoadVehicleDetial();

                    LoadInspection();
                    LoadParts();
                    LoadLabor();
                }
        }
        private string GenerateNextJobCode()
        {
            string newCode = "JC-0001";

            using (var reader = DBClass.ExecuteReader("SELECT MAX(CAST(SUBSTRING(id, 4) AS UNSIGNED)) AS lastCode FROM tbl_job_card"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                {
                    int code = int.Parse(reader["lastCode"].ToString()) + 1;
                    newCode = "JC-" + code.ToString("D4");
                }
            }

            return newCode;
        }
        private string GenerateNextJobId()
        {
            string newCode = "1";

            using (var reader = DBClass.ExecuteReader("SELECT MAX(id) AS lastCode FROM tbl_job_card"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                {
                    int code = int.Parse(reader["lastCode"].ToString()) + 1;
                    newCode = code.ToString();
                }
            }

            return newCode;
        }

        private void btnTopSave_Click(object sender, EventArgs e)
        {
            if (ValidData())
            {
                if (jId > 0)
                    UpdateJobCard();
                else
                    SaveJobCard();
            }
            else
            {
                MessageBox.Show("Fill all data");
            }
        }

        private bool ValidData()
        {
            if (cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show("please add customer");
                return false;
            }
            
            if (cmbVehicle.SelectedValue == null)
            {
                MessageBox.Show("please add vehicle");
                return false;
            }

            if (string.IsNullOrEmpty(txtJobCardNo.Text))
                return false;

            if (string.IsNullOrEmpty(txtPlateNo.Text))
            {
                MessageBox.Show("please fill plate no");
                return false;
            }

            return true;
        }

        private void UpdateJobCard()
        {
            DBClass.ExecuteNonQuery(@"UPDATE tbl_job_card
                        SET code=@code,customer_id=@customer_id,vehicle_id=@vehicle_id,advisor_id=@advisor_id,job_date=@job_date,
                            expected_delivery=@expected_delivery,mileage=@mileage,fuel_type=@fuel_type,priority=@priority,
                            complaint=@complaint,diagnosis=@diagnosis, work_required=@work_required,remarks=@remarks,
                            estimated_amount=@estimated_amount,approved_amount=@approved_amount,
                            status=@status where id = @id ",
                    DBClass.CreateParameter("id", jId),
                    DBClass.CreateParameter("code", txtJobCardNo.Text),
                    DBClass.CreateParameter("customer_id", cmbCustomer.SelectedValue),
                    DBClass.CreateParameter("vehicle_id", cmbVehicle.SelectedValue),
                    DBClass.CreateParameter("advisor_id", cmbSalesMan.SelectedValue),
                    DBClass.CreateParameter("job_date", dtDate.Value.Date),
                    DBClass.CreateParameter("expected_delivery", dtExpectedDelivery.Value.Date),
                    DBClass.CreateParameter("mileage", txtMileage.Text),
                    DBClass.CreateParameter("fuel_type", txtFuelLevel.Text),
                    DBClass.CreateParameter("priority", ""),
                    DBClass.CreateParameter("complaint", richTextCustomerComplaint.Text),
                    DBClass.CreateParameter("diagnosis", richTextBoxDiagnosis.Text),
                    DBClass.CreateParameter("work_required", richTextBoxWorkRequired.Text),
                    DBClass.CreateParameter("remarks", ""),
                    DBClass.CreateParameter("estimated_amount", "0"),
                    DBClass.CreateParameter("approved_amount", "0"),
                    DBClass.CreateParameter("status", cmbStatus.Text)
            );

            DBClass.ExecuteNonQuery(@"DELETE FROM tbl_vehicle_inspection where jobcard_id = @id;
                                      DELETE FROM tbl_job_card_labor where jobcard_id = @id;
                                      DELETE FROM tbl_job_card_parts where jobcard_id = @id", DBClass.CreateParameter("id", jId));

            SaveInspection();
            SaveParts();
            SaveLabor();
            loadPrint();

            MessageBox.Show("JobCard Updated!");
            Clear();
        }

        private void SaveJobCard()
        {
            jId = Convert.ToInt32(
                DBClass.ExecuteScalar(@"INSERT INTO tbl_job_card
                        (code,customer_id,vehicle_id,advisor_id,job_date,expected_delivery,mileage,fuel_type,priority,
                            complaint,diagnosis, work_required,remarks,estimated_amount,approved_amount,
                            status,active,created_by,created_date,state,quotation_id,sales_order_id) 
                    values(@code,@customer_id,@vehicle_id,@advisor_id,@job_date,@expected_delivery,
                            @mileage,@fuel_type,@priority, @complaint,@diagnosis, @work_required,@remarks,
                            @estimated_amount, @approved_amount,
                            @status,@active,@created_by,@created_date,@state,@quotation_id,@sales_order_id);
                    SELECT LAST_INSERT_ID();", 
                    DBClass.CreateParameter("code", txtJobCardNo.Text), 
                    DBClass.CreateParameter("customer_id", cmbCustomer.SelectedValue), 
                    DBClass.CreateParameter("vehicle_id", cmbVehicle.SelectedValue), 
                    DBClass.CreateParameter("advisor_id", cmbSalesMan.SelectedValue), 
                    DBClass.CreateParameter("job_date", dtDate.Value.Date), 
                    DBClass.CreateParameter("expected_delivery", dtExpectedDelivery.Value.Date), 
                    DBClass.CreateParameter("mileage", txtMileage.Text), 
                    DBClass.CreateParameter("fuel_type", txtFuelLevel.Text), 
                    DBClass.CreateParameter("priority", ""), 
                    DBClass.CreateParameter("complaint", richTextCustomerComplaint.Text), 
                    DBClass.CreateParameter("diagnosis", richTextBoxDiagnosis.Text),
                    DBClass.CreateParameter("work_required", richTextBoxWorkRequired.Text), 
                    DBClass.CreateParameter("remarks", ""), 
                    DBClass.CreateParameter("estimated_amount", "0"),
                    DBClass.CreateParameter("approved_amount", "0"),
                    DBClass.CreateParameter("status", cmbStatus.Text),
                    DBClass.CreateParameter("active", "1"), 
                    DBClass.CreateParameter("created_by", frmLogin.userId), 
                    DBClass.CreateParameter("created_date", DateTime.Now.Date), 
                    DBClass.CreateParameter("state","1"),
                    DBClass.CreateParameter("quotation_id", quotation_id),
                    DBClass.CreateParameter("sales_order_id", sales_order_id)
                )
            );
            SaveInspection();
            SaveParts();
            SaveLabor();
            loadPrint();
            MessageBox.Show("JobCard saved!");
            Clear();
        }
        public void loadPrint()
        {
            if (chkPrint.Checked)
            {
                ShowReport();
            }
        }

        private void btnTopPrint_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        
        private void btnTopDelete_Click(object sender, EventArgs e)
        {
            DeleteJobCard();
        }

        private void DeleteJobCard()
        {
            if (jId > 0)
            {
                DBClass.ExecuteNonQuery(@"DELETE FROM tbl_vehicle_inspection where jobcard_id = @id;
                                      DELETE FROM tbl_job_card_labor where jobcard_id = @id;
                                      DELETE FROM tbl_job_card_parts where jobcard_id = @id;
                                      DELETE FROM tbl_job_card where id = @id", DBClass.CreateParameter("id", jId));

                Clear();
                MessageBox.Show("JobCard Deleted!");
            }
            else
            {
                MessageBox.Show("JobCard Not Found!");
            }
        }

        private void btnTopNew_Click(object sender, EventArgs e)
        {
            NewJobCard();
        }

        private void NewJobCard()
        {
            txtJobCardNo.Text = GenerateNextJobCode();
            jId = 0;
            Clear();
        }
        public void Clear()
        {
            //cmbCustomer.SelectedValue),
            //cmbVehicle.SelectedValue),
            //cmbSalesMan.SelectedValue),
            dtDate.Value = dtExpectedDelivery.Value = DateTime.Now.Date;
            txtMileage.Text = "";
            txtFuelLevel.Text = "";
            richTextCustomerComplaint.Text = "";
            richTextBoxDiagnosis.Text = "";
            richTextBoxWorkRequired.Text = "";
            chk_engine_oil.Checked =
                            chk_brake_oil.Checked =
                            chk_coolant.Checked =
                            chk_battery.Checked =
                            chk_tyres.Checked =
                            chk_brake_pads.Checked =
                            chk_steering.Checked =
                            chk_suspension.Checked =
                            chk_lights.Checked =
                            chk_horn.Checked =
                            chk_wiper.Checked =
                            chk_ac.Checked =
                            chk_interior.Checked =
                            chk_exterior.Checked = false;

            dgvParts.Rows.Clear();

            txtLaborHours.Text =
            txtLaborHours.Text =
                            txtLaborRate.Text =
                            txtLaborTotal.Text =
                            richTextBoxLaborDescription.Text = "";
        }

        private void LoadInspection()
        {
            using(MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_vehicle_inspection where jobcard_id = @jobcard_id", DBClass.CreateParameter("jobcard_id", jId)))
            {
                if (reader.Read())
                {
                    chk_engine_oil.Checked = reader.GetBoolean("engine_oil");
                    chk_brake_oil.Checked = reader.GetBoolean("brake_oil");
                    chk_coolant.Checked = reader.GetBoolean("coolant");
                    chk_battery.Checked = reader.GetBoolean("battery");
                    chk_tyres.Checked = reader.GetBoolean("tyres");
                    chk_brake_pads.Checked = reader.GetBoolean("brake_pads");
                    chk_steering.Checked = reader.GetBoolean("steering");
                    chk_suspension.Checked = reader.GetBoolean("suspension");
                    chk_lights.Checked = reader.GetBoolean("lights");
                    chk_horn.Checked = reader.GetBoolean("horn");
                    chk_wiper.Checked = reader.GetBoolean("wiper");
                    chk_ac.Checked = reader.GetBoolean("ac");
                    chk_interior.Checked = reader.GetBoolean("interior");
                    chk_exterior.Checked = reader.GetBoolean("exterior");
                    //chk_r.Checked = reader.GetBoolean("remarks");
                }
            }
        }

        private void SaveInspection()
        {
            DBClass.ExecuteNonQuery(@"Insert into tbl_vehicle_inspection(jobcard_id,
                            engine_oil, brake_oil, coolant, battery, tyres, brake_pads,
                            steering, suspension, lights, horn,
                            wiper, ac, interior, exterior, remarks) 
                    values(
                            @jobcard_id, @engine_oil, @brake_oil, @coolant, @battery,
                            @tyres, @brake_pads, @steering, @suspension, @lights, @horn, @wiper,
                            @ac, @interior, @exterior, @remarks)",
                            DBClass.CreateParameter("@jobcard_id", jId),
                            DBClass.CreateParameter("@engine_oil", chk_engine_oil.Checked),
                            DBClass.CreateParameter("@brake_oil", chk_brake_oil.Checked),
                            DBClass.CreateParameter("@coolant", chk_coolant.Checked),
                            DBClass.CreateParameter("@battery", chk_battery.Checked),
                            DBClass.CreateParameter("@tyres", chk_tyres.Checked),
                            DBClass.CreateParameter("@brake_pads", chk_brake_pads.Checked),
                            DBClass.CreateParameter("@steering", chk_steering.Checked),
                            DBClass.CreateParameter("@suspension", chk_suspension.Checked),
                            DBClass.CreateParameter("@lights", chk_lights.Checked),
                            DBClass.CreateParameter("@horn", chk_horn.Checked),
                            DBClass.CreateParameter("@wiper", chk_wiper.Checked),
                            DBClass.CreateParameter("@ac", chk_ac.Checked),
                            DBClass.CreateParameter("@interior", chk_interior.Checked),
                            DBClass.CreateParameter("@exterior", chk_exterior.Checked),
                            DBClass.CreateParameter("@remarks", "")
            );
        }

        private void LoadParts()
        {
            dgvParts.Rows.Clear();

            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_job_card_parts where jobcard_id = @jobcard_id", DBClass.CreateParameter("jobcard_id", jId)))
            {
                while (reader.Read())
                {
                    //jobcard_id, item_id, warehouse_id, qty, issued_qty, returned_qty,
                    //unit_price, discount, vat, charge, total, remarks
                    //ColumnPartCode, ColumnDescription, ColumnQty, ColumnPrice, ColumnDiscount, ColumnVatP, ColumnVAT, ColumnCharge, ColumnTotal
                    dgvParts.Rows.Add("", null, Utilities.FormatDecimal(reader["qty"]), Utilities.FormatDecimal(reader["unit_price"]), Utilities.FormatDecimal(reader["discount"]), null, Utilities.FormatDecimal(reader["vat"]), Utilities.FormatDecimal(reader["charge"] ?? "0"), Utilities.FormatDecimal(reader["total"]));
                    DataGridViewComboBoxCell comboNameCell = dgvParts.Rows[dgvParts.Rows.Count - 2].Cells["ColumnDescription"] as DataGridViewComboBoxCell;
                    if (comboNameCell != null && reader["item_id"].ToString() != "0")
                    {
                        comboNameCell.Value = int.Parse(reader["item_id"].ToString());
                    }
                    DataGridViewComboBoxCell comboCell = dgvParts.Rows[dgvParts.Rows.Count - 2].Cells["ColumnVAT"] as DataGridViewComboBoxCell;
                    if (comboCell != null && reader["vatP"].ToString() != "0")
                    {
                         comboCell.Value = int.Parse(reader["vatP"].ToString());
                        //dgvParts.Rows[dgvParts.Rows.Count - 2].Cells["ColumnVatP"].Value = decimal.Parse(reader["ColumnVatP"].ToString());
                    }
                }
            }
        }

        private void SaveParts()
        {
            if (dgvParts.Rows.Count > 0)
            {
                int slno = 1;

                foreach (DataGridViewRow row in dgvParts.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    string description = row.Cells["ColumnDescription"].Value?.ToString();
                    string qtyText = row.Cells["ColumnQty"].Value?.ToString();
                    string priceText = row.Cells["ColumnPrice"].Value?.ToString();
                    string chargeText = row.Cells["ColumnCharge"].Value?.ToString();

                    if (!string.IsNullOrWhiteSpace(description) &&
                        !string.IsNullOrWhiteSpace(qtyText) &&
                        !string.IsNullOrWhiteSpace(priceText))
                    {
                        int itemId = Convert.ToInt32(row.Cells["ColumnDescription"].Value);
                        decimal qty = string.IsNullOrWhiteSpace(qtyText) ? 0 : Convert.ToDecimal(qtyText);
                        decimal price = string.IsNullOrWhiteSpace(priceText) ? 0 : Convert.ToDecimal(priceText);
                        decimal charge = string.IsNullOrWhiteSpace(chargeText) ? 0 : Convert.ToDecimal(chargeText);
                        decimal discount = string.IsNullOrWhiteSpace(row.Cells["ColumnDiscount"].Value?.ToString())
                            ? 0
                            : Convert.ToDecimal(row.Cells["ColumnDiscount"].Value);

                        decimal vat = string.IsNullOrWhiteSpace(row.Cells["ColumnVAT"].Value?.ToString())
                            ? 0
                            : Convert.ToDecimal(row.Cells["ColumnVAT"].Value);

                        decimal total = string.IsNullOrWhiteSpace(row.Cells["ColumnTotal"].Value?.ToString())
                            ? 0
                            : Convert.ToDecimal(row.Cells["ColumnTotal"].Value);
                        int vatP = string.IsNullOrWhiteSpace(row.Cells["ColumnVATP"].Value?.ToString())
                            ? 0
                            : Convert.ToInt32(row.Cells["ColumnVATP"].Value);

                        DBClass.ExecuteNonQuery(
                            @"INSERT INTO tbl_job_card_parts
                            (
                                jobcard_id, item_id, warehouse_id, qty, issued_qty, returned_qty,
                                unit_price, discount, vatP, vat, charge, total, remarks
                            )
                            VALUES
                            (
                                @jobcard_id, @item_id, @warehouse_id, @qty, @issued_qty, @returned_qty,
                                @unit_price, @discount, @vatP, @vat, @charge, @total, @remarks
                            )",
                            DBClass.CreateParameter("@jobcard_id", jId),
                            DBClass.CreateParameter("@item_id", itemId),
                            DBClass.CreateParameter("@warehouse_id", cmbWarehouse.SelectedValue),
                            DBClass.CreateParameter("@qty", qty),
                            DBClass.CreateParameter("@issued_qty", qty),
                            DBClass.CreateParameter("@returned_qty", 0), // Usually returned qty starts at 0
                            DBClass.CreateParameter("@unit_price", price),
                            DBClass.CreateParameter("@discount", discount),
                            DBClass.CreateParameter("@vatP", vatP),
                            DBClass.CreateParameter("@vat", vat),
                            DBClass.CreateParameter("@charge", charge),
                            DBClass.CreateParameter("@total", total),
                            DBClass.CreateParameter("@remarks", "")
                        );

                        slno++;
                    }
                }
            }
        }

        private void LoadLabor()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_job_card_labor where jobcard_id = @jobcard_id", DBClass.CreateParameter("jobcard_id", jId)))
            {
                if (reader.Read())
                {
                    //jobcard_id, employee_id, labor_name, estimated_hours, actual_hours, hourly_rate, total, status, remarks
                    cmbTechnician.SelectedValue = reader["employee_id"];
                    txtLaborHours.Text = reader["estimated_hours"].ToString();
                    txtLaborRate.Text = reader["hourly_rate"].ToString();
                    txtLaborTotal.Text = reader["total"].ToString();
                    richTextBoxLaborDescription.Text = reader["remarks"].ToString();
                }
            }
        }

        private void SaveLabor()
        {
            if (cmbTechnician.DataSource == null || cmbTechnician.SelectedValue == null) return;

            DBClass.ExecuteNonQuery(@"Insert into tbl_job_card_labor
                        (jobcard_id, employee_id, labor_name, estimated_hours, actual_hours, hourly_rate, total, status, remarks)
                Values(@jobcard_id, @employee_id, @labor_name, @estimated_hours, @actual_hours, @hourly_rate, @total, @status, @remarks)",
                            DBClass.CreateParameter("@jobcard_id", jId),
                            DBClass.CreateParameter("@employee_id", cmbTechnician.SelectedValue),
                            DBClass.CreateParameter("@labor_name", cmbTechnician.Text),
                            DBClass.CreateParameter("@estimated_hours", string.IsNullOrEmpty(txtLaborHours.Text) ? "0" : txtLaborHours.Text),
                            DBClass.CreateParameter("@actual_hours", string.IsNullOrEmpty(txtLaborHours.Text) ? "0" : txtLaborHours.Text),
                            DBClass.CreateParameter("@hourly_rate", string.IsNullOrEmpty(txtLaborRate.Text) ? "0" : txtLaborRate.Text),
                            DBClass.CreateParameter("@total", string.IsNullOrEmpty(txtLaborTotal.Text) ? "0" : txtLaborTotal.Text),
                            DBClass.CreateParameter("@status", "Start"),
                            DBClass.CreateParameter("@remarks", richTextBoxLaborDescription.Text)
            );
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int? currentId = Convert.ToInt32(txtId.Text);
            if (currentId is null) return;

            currentId = currentId + 1;
            string query = "SELECT id FROM tbl_job_card WHERE id =@id";

            using (MySqlDataReader reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("id", currentId)))
                if (reader.Read())
                {
                    jId = int.Parse(reader["id"].ToString());
                    BindInvoice();
                }
                else
                {
                    clearData();
                    MessageBox.Show("No More Records");
                }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int? currentId = Convert.ToInt32(txtId.Text);
            if (currentId == null || currentId <= 1)
                return;

            currentId = currentId - 1;
            if (currentId <= 0)
            {
                clearData();
                MessageBox.Show("No previous records.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = "select id from tbl_job_card where id =@id";

            using (MySqlDataReader reader = DBClass.ExecuteReader(query, DBClass.CreateParameter("id", currentId)))
                if (reader.Read())
                {
                    jId = int.Parse(reader["id"].ToString());
                    BindInvoice();
                }
                else
                {
                    clearData();
                    MessageBox.Show("No previous records.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void clearData()
        {
            Clear();
        }

        private void frmJobCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.Customer -= customerUpdatedHandler;
            EventHub.wareHouse -= warehouseUpdatedHandler;
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.Focused)
            {
                LoadCustomerDetial();
            }
        }

        private void LoadCustomerDetial()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_customer where id =@id", DBClass.CreateParameter("id", cmbCustomer.SelectedValue)))
                if (reader.Read())
                {
                    txtCustMobile.Text = reader["main_phone"].ToString();
                    txtCustTrn.Text = reader["trn"].ToString();
                    cmbVehicle.DataSource = DBClass.ExecuteDataTable("SELECT id,plate_no name FROM tbl_vehicle WHERE customer_id = @CustomerID", DBClass.CreateParameter("CustomerID", cmbCustomer.SelectedValue));
                    cmbVehicle.ValueMember = "id";
                    cmbVehicle.DisplayMember = "name";
                    cmbVehicle.SelectedIndex = -1;
                }
        }

        private void cmbVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVehicle.Focused)
            {
                LoadVehicleDetial();
            }
        }

        private void LoadVehicleDetial()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT * FROM tbl_vehicle WHERE id = @id", DBClass.CreateParameter("id", cmbVehicle.SelectedValue)))
            {
                if (reader.Read())
                {
                    txtPlateNo.Text = reader["plate_no"].ToString();
                    txtMake.Text = reader["make"].ToString();
                    txtModel.Text = reader["model"].ToString();
                    txtYear.Text = reader["model_year"].ToString();
                    txtMileage.Text = reader["current_mileage"].ToString();
                    txtFuelLevel.Text = reader["fuel_type"].ToString();
                }
            }
        }

        private void lnkNewCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmViewCustomer(0));
        }

        private void linkLabelAddVehicle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmViewVehicle(0));
        }

        private void txtMileage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtYear_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txtYear.Text, out int year))
            {
                if (year < 1500 || year > DateTime.Now.Year + 1)
                {
                    MessageBox.Show("Please enter a valid year.");
                    txtYear.Focus();
                }
            }
        }

        private void txtLaborTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtLaborRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtLaborHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void dgvParts_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (!string.IsNullOrEmpty(defaultTax))
            {
                DataTable dt = ((DataGridViewComboBoxColumn)dgvParts.Columns["ColumnVatP"]).DataSource as DataTable;
                if (dt != null)
                {
                    DataRow[] rows = dt.Select("value = " + defaultTax);
                    if (rows.Length > 0)
                    {
                        // Always assign the correct ID
                        e.Row.Cells["vat"].Value = rows[0]["id"];
                    }
                }
            }
        }

        private void dgvParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvParts.Rows.Count > 1 && dgvParts.CurrentRow.Cells["ColumnDel"].ColumnIndex == e.ColumnIndex)
                {
                    dgvParts.Rows.Remove(dgvParts.CurrentRow);
                }
                if (e.ColumnIndex == dgvParts.Columns["ColumnVatP"].Index)
                {
                    ChkRowValidity(dgvParts.CurrentRow);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        private void dgvParts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var row = dgvParts.Rows[e.RowIndex];
            var columnName = dgvParts.Columns[e.ColumnIndex].Name;
        }

        private void dgvParts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //ColumnPartCode, ColumnDescription, ColumnQty, ColumnPrice, ColumnDiscount, ColumnVAT, ColumnVatP, ColumnCharge, ColumnTotal
            if (dgvParts.Rows.Count > 1)
            {
                var row = dgvParts.Rows[e.RowIndex];
                decimal price = GetDecimalValue(row, "ColumnPrice");
                decimal charge = GetDecimalValue(row, "ColumnCharge");
                decimal qty = GetDecimalValue(row, "ColumnQty");
                decimal discount = GetDecimalValue(row, "ColumnDiscount");

                //row.Cells[""].Value = 
                ChkRowValidity(row);
            }
        }

        private void dgvParts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int colIndex = dgvParts.CurrentCell.ColumnIndex;
            //ColumnPartCode, ColumnDescription, ColumnQty, ColumnPrice, ColumnDiscount, ColumnVAT, ColumnVatP, ColumnCharge, ColumnTotal

            //if (e.Control is TextBox textBoxBase)
            //{
            //    textBoxBase.TextChanged -= ItemName_TextChanged;
            //    textBoxBase.KeyPress -= NumericColumn_KeyPress;
            //}

            //if (colIndex == dgvParts.Columns["name"].Index)
            //{
            //    if (e.Control is TextBox textBox)
            //    {
            //        textBox.TextChanged -= ItemName_TextChanged;
            //        textBox.TextChanged += ItemName_TextChanged;
            //    }
            //}
            //else 
            if (colIndex == dgvParts.Columns["ColumnVAT"].Index)
            {
                if (e.Control is ComboBox comboBox)
                {
                    comboBox.SelectedIndexChanged -= ComboBoxTax_SelectedIndexChanged;
                    comboBox.SelectedIndexChanged += ComboBoxTax_SelectedIndexChanged;
                }
            }
            else if (dgvParts.CurrentCell.OwningColumn.Name == "ColumnQty" ||
                     dgvParts.CurrentCell.OwningColumn.Name == "ColumnPrice" ||
                     dgvParts.CurrentCell.OwningColumn.Name == "ColumnDiscount" ||
                     dgvParts.CurrentCell.OwningColumn.Name == "ColumnCharge")
            {
                if (e.Control is TextBox textBox)
                {
                    textBox.KeyPress -= NumericColumn_KeyPress;
                    textBox.KeyPress += NumericColumn_KeyPress;
                }
            }
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
        private void ComboBoxTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox combo && combo.SelectedItem is DataRowView selectedRow)
            {
                if (dgvParts.CurrentCell == null || dgvParts.CurrentCell.ColumnIndex != dgvParts.Columns["ColumnVatP"].Index)
                    return;

                var row = dgvParts.CurrentRow;
                if (row == null) return;

                string taxId = selectedRow["id"].ToString();
                string taxP = selectedRow["value"].ToString();

                decimal price = GetDecimalValue(row, "ColumnPrice");
                decimal charge = GetDecimalValue(row, "ColumnCharge");
                decimal qty = GetDecimalValue(row, "ColumnQty");
                decimal discount = GetDecimalValue(row, "ColumnDiscount");

                if (price == 0 || qty == 0)
                {
                    row.Cells["ColumnVAT"].Value = row.Cells["ColumnDiscount"].Value = row.Cells["ColumnCharge"].Value = row.Cells["ColumnTotal"].Value = "0";
                }
                else
                {
                    decimal net = (price * qty) - discount;
                    //row.Cells["net_price"].Value = net;
                    row.Cells["ColumnVatP"].Value = Convert.ToInt32(taxId);
                    row.Cells["ColumnVAT"].Value = (net * decimal.Parse(taxP) / 100);
                    row.Cells["ColumnTotal"].Value = net + Convert.ToDecimal(row.Cells["ColumnVAT"].Value) + charge;
                }

                ChkRowValidity(row);
            }
        }

        private void ChkRowValidity(DataGridViewRow row)
        {
            if (row == null) return;

            decimal price = GetDecimalValue(row, "ColumnPrice");
            decimal charge = GetDecimalValue(row, "ColumnCharge");
            decimal qty = GetDecimalValue(row, "ColumnQty");
            decimal discount = GetDecimalValue(row, "ColumnDiscount");

            if (price == 0 || qty == 0)
            {
                row.Cells["ColumnVAT"].Value = "0";
                row.Cells["ColumnTotal"].Value = "0";
                row.Cells["ColumnCharge"].Value = "0";
                return;
            }

            try
            {
                decimal netPrice = (qty * price) - discount;
                //row.Cells["net_price"].Value = netPrice;

                // --- Get VAT value from DataSource by selected VAT ID ---
                string vatId = row.Cells["ColumnVatP"].Value?.ToString() ?? "0";
                string vP = "0";

                DataTable vatTable = ((DataGridViewComboBoxColumn)dgvParts.Columns["ColumnVatP"]).DataSource as DataTable;
                if (vatTable != null)
                {
                    DataRow[] matches = vatTable.Select("id = " + vatId);
                    if (matches.Length > 0)
                    {
                        vP = matches[0]["value"].ToString();
                    }
                }

                decimal vatValue = netPrice * Convert.ToDecimal(vP) / 100;
                row.Cells["ColumnVAT"].Value = vatValue;
                row.Cells["ColumnTotal"].Value = netPrice + vatValue + charge;
            }
            catch (Exception ex)
            {
                MessageBox.Show("VAT calc error: " + ex.Message);
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

        private void txtCustCode_TextChanged(object sender, EventArgs e)
        {
            if (txtCustCode.Focused)
            {
                using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_customer where code =@code",
                DBClass.CreateParameter("code", txtCustCode.Text)))
                    if (reader.Read())
                        cmbCustomer.SelectedValue = int.Parse(reader["id"].ToString());

            }
        }
        private void ShowReport()
        {
            try
            {
                string reportPath = Path.Combine(Application.StartupPath, "CrystalReport", "JobCard.rpt");

                // Load the report file from disk
                ReportDocument cr = new ReportDocument();
                cr.Load(reportPath);

                // Fetch your data
                DataTable companyData = COMPANYINFO();
                DataTable jobInfo = JobInfo();
                DataTable jobLabor = JobLabor();
                DataTable jobParts = JobParts();
                DataTable jobInspection = JobInspection();
                
                // Assign data to subreports by name
                cr.Subreports["Company"].SetDataSource(companyData);
                cr.Subreports["JobInfo"].SetDataSource(jobInfo);
                cr.Subreports["JobLabor"].SetDataSource(jobLabor);
                //cr.Subreports["JobParts"].SetDataSource(jobParts);
                cr.Subreports["JobInspection"].SetDataSource(jobInspection);
                string fileName = "JobCard_" + jId + "_" + cmbCustomer.Text.Trim();
                MasterReportView reportForm = new MasterReportView(cr, fileName);
                reportForm.crReportViewer.ReportSource = cr;
                reportForm.crReportViewer.RefreshReport();
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private DataTable JobInfo()
        {
            return DBClass.ExecuteDataTable(@"SELECT j.id,j.code,c.name customer,v.plate_no plate_no,IFNULL((e1.name),'') advisor,j.job_date,j.expected_delivery,j.mileage,j.fuel_type,j.complaint,j.diagnosis,j.work_required,j.remarks,c.main_phone phone,c.trn FROM tbl_job_card j INNER JOIN tbl_customer c ON c.id = j.customer_id INNER JOIN tbl_vehicle v ON v.id = j.vehicle_id left JOIN tbl_employee e1 ON e1.id = j.advisor_id WHERE j.id = @jId", DBClass.CreateParameter("@jId", jId));
        }
        private DataTable JobLabor()
        {
            return DBClass.ExecuteDataTable(@"SELECT jl.id,jl.labor_name,jl.estimated_hours,jl.actual_hours,jl.hourly_rate,jl.total,jl.`status`,jl.remarks FROM tbl_job_card_labor jl WHERE jl.jobcard_id = @jId", DBClass.CreateParameter("@jId", jId));
        }
        private DataTable JobParts()
        {
            return DBClass.ExecuteDataTable(@"SELECT jp.id,i.name item, jp.qty,jp.issued_qty,jp.returned_qty,jp.unit_price,jp.discount,t.name vatP, jp.vat , jp.charge, jp.total,jp.remarks FROM tbl_job_card_parts jp INNER JOIN tbl_items i ON i.id = jp.item_id INNER JOIN tbl_tax t ON t.id = jp.vatP WHERE jp.jobcard_id = @jId", DBClass.CreateParameter("@jId", jId));
        }
        private DataTable JobInspection()
        {
            return DBClass.ExecuteDataTable(@"SELECT vi.id,vi.engine_oil,vi.brake_oil,vi.coolant,vi.battery,vi.tyres,vi.brake_pads,vi.steering,vi.suspension,vi.lights,vi.horn,vi.wiper,vi.ac,vi.interior,vi.exterior,vi.remarks FROM tbl_vehicle_inspection vi WHERE vi.jobcard_id = @jId", DBClass.CreateParameter("@jId", jId));
        }

        public DataTable COMPANYINFO()
        {
            return DBClass.ExecuteDataTable("SELECT * FROM tbl_company Limit 1");
        }

        private void BtnSalesOrder_Click(object sender, EventArgs e)
        {
            if (jId > 0)
            {
                object objInvId = DBClass.ExecuteScalar("select sales_order_id from tbl_job_card where id = @id", DBClass.CreateParameter("@id", jId));
                if (objInvId != null)
                {
                    if (Convert.ToInt32(objInvId) > 0)
                    {
                        MessageBox.Show("Sales Order Already Saved");
                        return;
                    }
                }
                frmLogin.frmMain.openChildForm(new frmAddSalesOrder(jId, "JobCard"));
            }
        }

        private void BtnQuotation_Click(object sender, EventArgs e)
        {
            if (jId > 0)
            {
                object objInvId = DBClass.ExecuteScalar("select quotation_id from tbl_job_card where id = @id", DBClass.CreateParameter("@id", jId));
                if (objInvId != null)
                {
                    if (Convert.ToInt32(objInvId) > 0)
                    {
                        MessageBox.Show("Quotation Already Saved");
                        return;
                    }
                }
                frmLogin.frmMain.openChildForm(new frmAddQuotation(jId,"JobCard"));
            }
        }
    }
}
