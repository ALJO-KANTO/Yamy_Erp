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

namespace YamyProject.UI.ContractingGeneralMaintenance.CRM
{
    public partial class FollowUpForm : Form
    {
        int id;
        public FollowUpForm(int id = 0)
        {
            InitializeComponent();
            this.id = id;
        }

        private void FollowUpForm_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateCustomers(cmbCustomer);
            cmbCustomer.SelectedIndex = -1;
            if (id > 0)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            using(MySqlDataReader reader = DBClass.ExecuteReader("SELECT source, created_date, assigned_to, status FROM tbl_crm_leads WHERE lead_id = @Id", DBClass.CreateParameter("@Id", id)))
            {
                if (reader.Read())
                {
                    dtpFollowUpDate.Value = Convert.ToDateTime(reader["created_date"]);
                    cmbCustomer.SelectedValue = Convert.ToInt32(reader["assigned_to"]);
                    txtNotes.Text = reader["source"].ToString();
                    //cmbStatus.SelectedItem = reader["status"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (id > 0)
            {
                // Update existing follow-up
                DBClass.ExecuteNonQuery("UPDATE tbl_crm_leads SET created_date = @CreatedDate, assigned_to = @AssignedTo, source = @Source WHERE lead_id = @Id",
                    DBClass.CreateParameter("@CreatedDate", dtpFollowUpDate.Value),
                    DBClass.CreateParameter("@AssignedTo", cmbCustomer.SelectedValue),
                    DBClass.CreateParameter("@Source", txtNotes.Text),
                    DBClass.CreateParameter("@Id", id));

                MessageBox.Show("Follow-up updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Insert new follow-up
                DBClass.ExecuteNonQuery("INSERT INTO tbl_crm_leads (created_date, assigned_to, source, status) VALUES (@CreatedDate, @AssignedTo, @Source, @Status)",
                    DBClass.CreateParameter("@CreatedDate", dtpFollowUpDate.Value),
                    DBClass.CreateParameter("@AssignedTo", cmbCustomer.SelectedValue),
                    DBClass.CreateParameter("@Source", txtNotes.Text),
                    DBClass.CreateParameter("@Status", "Open"));

                MessageBox.Show("Follow-up created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
