using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.Job_Card
{
    public partial class frmViewVehicle : Form
    {
        int vId = 0;
        private EventHandler customerUpdatedHandler;

        public frmViewVehicle(int _id = 0)
        {
            InitializeComponent();
            headerUC1.FormText = "Vehicle";
            LocalizationManager.LocalizeForm(this);
            customerUpdatedHandler = (sender, args) => BindCombos.PopulateCustomers(cmbCustomer);
            this.vId = _id;
        }

        private void frmViewVehicle_Load(object sender, EventArgs e)
        {
            txtCode.Text = GenerateNextJobCode();
            BindCombos.PopulateCustomers(cmbCustomer);

            if (vId != 0)
            {
                BindInvoice();
            }
        }

        private void BindInvoice()
        {
            using(MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_vehicle where id = @id", DBClass.CreateParameter("id", vId)))
            {
                if (reader.Read())
                {
                    txtCode.Text = reader["code"].ToString();
                    cmbCustomer.SelectedValue = reader["customer_id"];
                    txtPlateNo.Text = reader["plate_no"].ToString();
                    txtChassisNo.Text = reader["chassis_no"].ToString();
                    //reader["vin_no VARCHAR(50),
                    txtEngineNo.Text = reader["engine_no"].ToString();
                    txtMake.Text = reader["make"].ToString();
                    txtMake.Text = reader["model"].ToString();
                    txtVariant.Text = reader["variant"].ToString();
                    txtYear.Text = reader["model_year"].ToString();
                    txtColor.Text = reader["color"].ToString();
                    txtTransmission.Text = reader["transmission"].ToString();
                    txtFuelLevel.Text = reader["fuel_type"].ToString();
                    txtMileage.Text = reader["current_mileage"].ToString();
                    //reader["registration_expiry DATE,
                    //reader["insurance_expiry DATE,
                    //reader["warranty_expiry DATE,
                    //reader["notes TEXT,
                    //reader["active INT DEFAULT 1,
                    //reader["created_by INT,
                    //reader["created_date DATE,
                    //reader["state
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPlateNo.Text))
            {
                MessageBox.Show("Plase add Plate No");
                return;
            }
            if (cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show("Fill Customer name");
                return;
            }

            if (vId > 0)
            {
                DBClass.ExecuteNonQuery(@"
                    UPDATE tbl_vehicle
                        SET
                            code = @code,
                            customer_id = @customer_id,
                            plate_no = @plate_no,
                            chassis_no = @chassis_no,
                            vin_no = @vin_no,
                            engine_no = @engine_no,
                            make = @make,
                            model = @model,
                            variant = @variant,
                            model_year = @model_year,
                            color = @color,
                            transmission = @transmission,
                            fuel_type = @fuel_type,
                            current_mileage = @current_mileage,
                            registration_expiry = @registration_expiry,
                            insurance_expiry = @insurance_expiry,
                            warranty_expiry = @warranty_expiry,
                            notes = @notes,
                            active = @active,
                            state = @state
                        WHERE id = @id;",
                    DBClass.CreateParameter("@id", vId),
                    DBClass.CreateParameter("@code", string.IsNullOrEmpty(txtCode.Text) ? "0" : txtCode.Text),
                    DBClass.CreateParameter("@customer_id", cmbCustomer.SelectedValue),
                    DBClass.CreateParameter("@plate_no", txtPlateNo.Text),
                    DBClass.CreateParameter("@chassis_no", txtChassisNo.Text),
                    DBClass.CreateParameter("@vin_no", "0"),
                    DBClass.CreateParameter("@engine_no", txtEngineNo.Text),
                    DBClass.CreateParameter("@make", txtMake.Text),
                    DBClass.CreateParameter("@model", txtModel.Text),
                    DBClass.CreateParameter("@variant", txtVariant.Text),
                    DBClass.CreateParameter("@model_year", string.IsNullOrEmpty(txtYear.Text) ? "0" : txtYear.Text),
                    DBClass.CreateParameter("@color", txtColor.Text),
                    DBClass.CreateParameter("@transmission", txtTransmission.Text),
                    DBClass.CreateParameter("@fuel_type", txtFuelLevel.Text),
                    DBClass.CreateParameter("@current_mileage", string.IsNullOrEmpty(txtMileage.Text) ? "0" : txtMileage.Text),
                    DBClass.CreateParameter("@registration_expiry", DateTime.Now.Date),
                    DBClass.CreateParameter("@insurance_expiry", DateTime.Now.Date),
                    DBClass.CreateParameter("@warranty_expiry", DateTime.Now.Date),
                    DBClass.CreateParameter("@notes", ""),
                    DBClass.CreateParameter("@active", 1),
                    DBClass.CreateParameter("@state", 1)
                );

                MessageBox.Show("Vehicle updated successfully.");
            }
            else
            {
                DBClass.ExecuteNonQuery(@"
                    INSERT INTO tbl_vehicle
                    (
                        code,
                        customer_id,
                        plate_no,
                        chassis_no,
                        vin_no,
                        engine_no,
                        make,
                        model,
                        variant,
                        model_year,
                        color,
                        transmission,
                        fuel_type,
                        current_mileage,
                        registration_expiry,
                        insurance_expiry,
                        warranty_expiry,
                        notes,
                        active,
                        created_by,
                        created_date,
                        state
                    )
                    VALUES
                    (
                        @code,
                        @customer_id,
                        @plate_no,
                        @chassis_no,
                        @vin_no,
                        @engine_no,
                        @make,
                        @model,
                        @variant,
                        @model_year,
                        @color,
                        @transmission,
                        @fuel_type,
                        @current_mileage,
                        @registration_expiry,
                        @insurance_expiry,
                        @warranty_expiry,
                        @notes,
                        @active,
                        @created_by,
                        @created_date,
                        @state
                    )",
                    DBClass.CreateParameter("@code", string.IsNullOrEmpty(txtCode.Text) ? "0" : txtCode.Text),
                    DBClass.CreateParameter("@customer_id", cmbCustomer.SelectedValue),
                    DBClass.CreateParameter("@plate_no", string.IsNullOrEmpty(txtPlateNo.Text) ? "0" : txtPlateNo.Text),
                    DBClass.CreateParameter("@chassis_no", txtChassisNo.Text),
                    DBClass.CreateParameter("@vin_no", "0"),
                    DBClass.CreateParameter("@engine_no", txtEngineNo.Text),
                    DBClass.CreateParameter("@make", txtMake.Text),
                    DBClass.CreateParameter("@model", txtModel.Text),
                    DBClass.CreateParameter("@variant", txtVariant.Text),
                    DBClass.CreateParameter("@model_year", string.IsNullOrEmpty(txtYear.Text) ? "0" : txtYear.Text),
                    DBClass.CreateParameter("@color", txtColor.Text),
                    DBClass.CreateParameter("@transmission", txtTransmission.Text),
                    DBClass.CreateParameter("@fuel_type", txtFuelLevel.Text),
                    DBClass.CreateParameter("@current_mileage", string.IsNullOrEmpty(txtMileage.Text) ? "0" : txtMileage.Text),
                    DBClass.CreateParameter("@registration_expiry", DateTime.Now.Date),
                    DBClass.CreateParameter("@insurance_expiry", DateTime.Now.Date),
                    DBClass.CreateParameter("@warranty_expiry", DateTime.Now.Date),
                    DBClass.CreateParameter("@notes", ""),
                    DBClass.CreateParameter("@active", 1),
                    DBClass.CreateParameter("@created_by", frmLogin.userId),
                    DBClass.CreateParameter("@created_date", DateTime.Now),
                    DBClass.CreateParameter("@state", 1)
                );

                MessageBox.Show("Vehicle saved successfully.");
            }
        }
        private string GenerateNextJobCode()
        {
            string newCode = "V -0001";

            using (var reader = DBClass.ExecuteReader("SELECT MAX(CAST(SUBSTRING(id, 4) AS UNSIGNED)) AS lastCode FROM tbl_vehicle"))
            {
                if (reader.Read() && reader["lastCode"] != DBNull.Value)
                {
                    int code = int.Parse(reader["lastCode"].ToString()) + 1;
                    newCode = "V-" + code.ToString("D4");
                }
            }

            return newCode;
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

        private void txtMileage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkNewCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmViewCustomer(0));
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

        private void frmViewVehicle_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventHub.Customer -= customerUpdatedHandler;
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedValue == null)
            {
                txtCode.Text = "";
                return;
            }
            using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_customer where id = " + cmbCustomer.SelectedValue.ToString()))
                if (reader.Read())
                {
                    txtCode.Text = reader["code"].ToString();
                }
                else
                    txtCode.Text = "";
        }
    }
}
