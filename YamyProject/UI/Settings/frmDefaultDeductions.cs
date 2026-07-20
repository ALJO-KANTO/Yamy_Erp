using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class frmDefaultDeductions : Form
    {
        public frmDefaultDeductions()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }
        bool isExist = false;
        private void frmDefaultDeductions_Load(object sender, EventArgs e)
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("Select id, latearrivaldeduction, delaytime from tbl_setting_deduction_config LIMIT 1"))
                if (reader.Read())
                {
                    //txtMissedHours.Text = reader["missedhoursdeduction"].ToString();
                    txtLateArrival.Text = reader["latearrivaldeduction"].ToString();
                    //txtFullDay.Text = reader["fulldaydeduction"].ToString();
                    string time = reader["delaytime"].ToString();
                    int numH = 0, numM = 0, numS = 0;
                    if (TimeSpan.TryParse(time, out TimeSpan ts))
                    {
                        numH = ts.Hours;
                        numM = ts.Minutes;
                        numS = ts.Seconds;
                    }
                    else
                    {
                        numH = 0;
                        numM = 0;
                        numS = 0;
                    }
                    numrH.Value = numH;
                    numrM.Value = numM;
                    numrS.Value = numS;
                    isExist = true;
                }

            txtMissedHours.Enabled = txtFullDay.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMissedHours.Text.Trim() == "")
                txtMissedHours.Text = "0";

            if (txtFullDay.Text.Trim() == "")
                txtFullDay.Text = "0";

            if (txtLateArrival.Text.Trim() == "")
                txtLateArrival.Text = "0";

            // Convert inputs to TimeSpan safely
            TimeSpan missedHours = ParseToTimeSpan(txtMissedHours.Text);
            TimeSpan fullDay = ParseToTimeSpan(txtFullDay.Text);
            decimal lateArrival = Convert.ToDecimal(txtLateArrival.Text);
            TimeSpan delaytime = new TimeSpan(
                Convert.ToInt32(numrH.Value),
                Convert.ToInt32(numrM.Value),
                Convert.ToInt32(numrS.Value)
            );
            string query =
                isExist 
                ?   @"
                    UPDATE tbl_setting_deduction_config 
                    SET 
                        -- missedhoursdeduction = @missedhoursdeduction, 
                        latearrivaldeduction = @latearrivaldeduction, 
                        -- fulldaydeduction = @fulldaydeduction, 
                        delaytime = @delaytime"
                :
                    @"INSERT INTO tbl_setting_deduction_config (latearrivaldeduction, delaytime) Values(@latearrivaldeduction, @delaytime)";
            DBClass.ExecuteNonQuery(query,
                DBClass.CreateParameter("missedhoursdeduction", missedHours),
                DBClass.CreateParameter("latearrivaldeduction", lateArrival),
                DBClass.CreateParameter("fulldaydeduction", fullDay),
                DBClass.CreateParameter("delaytime", delaytime)
            );

            MessageBox.Show("Deductions Updated Successfully.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private TimeSpan ParseToTimeSpan(string input)
        {
            input = input.Trim();

            // Case: "1" => 01:00:00
            if (int.TryParse(input, out int hours))
                return new TimeSpan(hours, 0, 0);

            // Case: "00:30" => 00:30:00
            if (TimeSpan.TryParse(input, out TimeSpan ts))
                return ts;

            return TimeSpan.Zero;
        }
    }
}