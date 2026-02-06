using DocumentFormat.OpenXml.Office.Word;
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

namespace YamyProject.UI.ContractingGeneralMaintenance.Maintenance
{
    public partial class MaintenanceRequestForm : Form
    {
        int requestId = 0;
        public MaintenanceRequestForm(int _requestId = 0)
        {
            InitializeComponent();
            this.requestId = _requestId;
        }

        private void MaintenanceRequestForm_Load(object sender, EventArgs e)
        {
            BindCombos.LoadAllLevel4Account(cmbAsset);
            DataTable dtTechnician = DBClass.ExecuteDataTable("SELECT distinct technician FROM tbl_maintenance_requests");
            cmbTechnician.DataSource = dtTechnician;
            cmbTechnician.DisplayMember = "technician";
            cmbTechnician.ValueMember = "technician";
            if(dtTechnician.Rows.Count > 0) 
                cmbTechnician.SelectedIndex = 0;

            if (requestId > 0)
            {
                LoadRequestData();
            }
        }

        private void LoadRequestData()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT * FROM tbl_maintenance_requests WHERE request_id = @id", DBClass.CreateParameter("@id", requestId)))
            {
                if (reader.Read())
                {
                    cmbAsset.SelectedValue = reader["asset_id"];
                    cmbType.Text = reader["maintenance_type"].ToString();
                    cmbPriority.Text = reader["priority"].ToString();
                    cmbTechnician.Text = reader["technician"].ToString();
                    txtCost.Text = reader["estimated_cost"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            if (requestId > 0)
            {
                string query = @"
                    UPDATE tbl_maintenance_requests
                    SET asset_id = @asset,
                        maintenance_type = @type,
                        priority = @priority,
                        technician = @tech,
                        estimated_cost = @cost
                    WHERE request_id = @id";

                    DBClass.ExecuteNonQuery(query,
                    DBClass.CreateParameter("@asset", cmbAsset.SelectedValue),
                    DBClass.CreateParameter("@type", cmbType.Text),
                    DBClass.CreateParameter("@priority", cmbPriority.Text),
                    DBClass.CreateParameter("@tech", cmbTechnician.Text),
                    DBClass.CreateParameter("@cost", decimal.Parse(txtCost.Text)),
                    DBClass.CreateParameter("@id", requestId)
                    );

                MessageBox.Show("Maintenance request updated successfully.", "Success");
            }
            else
            {
                string query = @"
                    INSERT INTO tbl_maintenance_requests
                    (asset_id, maintenance_type, priority, technician, estimated_cost)
                    VALUES
                    (@asset, @type, @priority, @tech, @cost)";

                DBClass.ExecuteNonQuery(query,
                    DBClass.CreateParameter("@asset", cmbAsset.SelectedValue),
                    DBClass.CreateParameter("@type", cmbType.Text),
                    DBClass.CreateParameter("@priority", cmbPriority.Text),
                    DBClass.CreateParameter("@tech", cmbTechnician.Text),
                    DBClass.CreateParameter("@cost", decimal.Parse(txtCost.Text))
                    );

                MessageBox.Show("Maintenance request saved successfully.", "Success");
            }
        }

        private bool ValidateForm()
        {
            if (cmbAsset.SelectedValue == null)
            {
                MessageBox.Show("Asset is required.");
                return false;
            }
            if (cmbType.SelectedIndex == -1)
            {
                MessageBox.Show("Select maintenance type.");
                return false;
            }
            if (cmbPriority.SelectedIndex == -1)
            {
                MessageBox.Show("Select priority.");
                return false;
            }
            if (!decimal.TryParse(txtCost.Text, out _))
            {
                MessageBox.Show("Invalid cost value.");
                return false;
            }
            return true;
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
