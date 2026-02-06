using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using YamyProject.Localization;
using YamyProject.UI.CRM.Models;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.CRM
{
    public partial class frmEngClientList : Form
    {
        public frmEngClientList()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmClientList_Load(object sender, EventArgs e)
        {
            LoadClients();
        }

        private void LoadClients()
        {
            dgvClients.DataSource = DBClass.ExecuteDataTable(
                @"SELECT cr.id client_id, cr.leadName client_name,cr.CustName contact_person,c.main_phone phone,c.email, cr.Stage status
                  FROM tbl_customer c
                  INNER JOIN tbl_crmcustomer cr ON c.code = cr.custcode
                  ORDER BY client_name");
            LocalizationManager.LocalizeDataGridViewHeaders(dgvClients);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new frmCRMAddLeads().ShowDialog();
            LoadClients();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count == null || dgvClients.SelectedRows.Count <= 0)
                return;

            DataGridViewRow selectRow = dgvClients.SelectedRows[0];
            using (MySqlDataReader reader = DBClass.ExecuteReader("Select * FROM tbl_customer c INNER JOIN tbl_crmcustomer cr ON c.code = cr.custcode where cr.id=@id", DBClass.CreateParameter("id", selectRow.Cells["client_id"].Value)))
            {
                if (reader.Read())
                {
                    frmCRMAddLeads frm = new frmCRMAddLeads();
                    frm.id = Convert.ToInt32(reader["id"].ToString());
                    frm.cmbCust.Text = Convert.ToString(reader["CustName"].ToString());
                    frm.txtname.Text = Convert.ToString(reader["leadName"].ToString());
                    frm.dtdate.Text = Convert.ToString(reader["Date"].ToString());
                    frm.cmbstage.Text = Convert.ToString(reader["Stage"].ToString());
                    frm.txtamount.Text = Convert.ToString(reader["Amount"].ToString());
                    frm.txtnotes.Text = Convert.ToString(reader["Discription"].ToString());
                    frm.cmbAssig.Text = Convert.ToString(reader["AssigendTo"].ToString());
                    frm.dtcreateat.Text = Convert.ToString(reader["CreateAt"].ToString());
                    frm.ShowDialog();

                    LoadClients();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
