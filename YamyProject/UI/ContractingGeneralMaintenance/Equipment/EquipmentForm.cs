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

namespace YamyProject.UI.ContractingGeneralMaintenance.Equipment
{
    public partial class EquipmentForm : Form
    {
        int equipmentId;
        public EquipmentForm(int equipmentId = 0)
        {
            InitializeComponent();
            this.equipmentId = equipmentId;
        }

        private void EquipmentForm_Load(object sender, EventArgs e)
        {
            if (equipmentId > 0)
            {
                LoadEquipmentDetails();
            }
        }

        private void LoadEquipmentDetails()
        {
            using (MySqlDataReader reader = DBClass.ExecuteReader("SELECT equipment_id, name, category, status, allocated_to, purchase_date, cost, depreciation FROM tbl_equipment WHERE equipment_id = @id", DBClass.CreateParameter("@id", equipmentId)))
            {
                if (reader.Read())
                {
                    txtName.Text = reader["name"].ToString();
                    txtCategory.Text = reader["category"].ToString();
                    //txtStatus.Text = reader["status"].ToString();
                    dtPurchase.Value = Convert.ToDateTime(reader["purchase_date"]);
                    txtCost.Text = Convert.ToDecimal(reader["cost"]).ToString("N2");
                    //numDepreciation.Value = Convert.ToDecimal(reader["depreciation"]);
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!validateForm()) return;

            if (equipmentId > 0)
            {
                // Update existing equipment
                DBClass.ExecuteNonQuery("UPDATE tbl_equipment SET name=@name, category=@category, purchase_date=@purchase_date, cost=@cost WHERE equipment_id=@id",
                    DBClass.CreateParameter("@name", txtName.Text),
                    DBClass.CreateParameter("@category", txtCategory.Text),
                    //DBClass.CreateParameter("@status", "Available"),
                    DBClass.CreateParameter("@purchase_date", dtPurchase.Value),
                    DBClass.CreateParameter("@cost", txtCost.Text),
                    DBClass.CreateParameter("@id", equipmentId));

                MessageBox.Show("Equipment Item saved successfully.");
            }
            else
            {
                // Insert new equipment
                DBClass.ExecuteNonQuery("INSERT INTO tbl_equipment (name, category, status, purchase_date, cost, depreciation) VALUES (@name, @category, @status, @purchase_date, @cost, @depreciation)",
                    DBClass.CreateParameter("@name", txtName.Text),
                    DBClass.CreateParameter("@category", txtCategory.Text),
                    DBClass.CreateParameter("@status", "Available"),
                    DBClass.CreateParameter("@purchase_date", dtPurchase.Value.Date),
                    DBClass.CreateParameter("@cost", txtCost.Text),
                    DBClass.CreateParameter("@depreciation", 0));

                MessageBox.Show("Equipment Item updated successfully.");
            }
        }

        private bool validateForm()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Name can't be empty");
                return false;
            }
            if (string.IsNullOrEmpty(txtCategory.Text))
            {
                MessageBox.Show("Category can't be empty");
                return false;
            }
            if (string.IsNullOrEmpty(txtCost.Text))
            {
                MessageBox.Show("Cost can't be empty");
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
