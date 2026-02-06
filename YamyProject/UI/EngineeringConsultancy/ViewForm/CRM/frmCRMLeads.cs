using DocumentFormat.OpenXml.Office2010.Excel;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;
using YamyProject.Localization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.CRM
{
    public partial class frmCRMLeads : Form
    {
        public frmCRMLeads()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmCRMLeads_Load(object sender, EventArgs e)
        {
            cmbEmployee.DataSource = DBClass.ExecuteDataTable(
                "SELECT id, name FROM tbl_employee");
            cmbEmployee.DisplayMember = "name";
            cmbEmployee.ValueMember = "id";

            LoadLeads();
        }
        private void LoadLeads()
        {
            dgvLeads.DataSource = DBClass.ExecuteDataTable("select l.lead_id, l.Source, l.Created_Date, e.id employee_id, e.name Assigned_To, l.Status from tbl_crm_leads l INNER JOIN tbl_employee e ON l.Assigned_To = e.id");

            dgvLeads.Columns["lead_id"].Visible = false;
            dgvLeads.Columns["employee_id"].Visible = false;
            LocalizationManager.LocalizeDataGridViewHeaders(dgvLeads);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id > 0) // update existing lead
            {
                DBClass.ExecuteNonQuery(
                    @"UPDATE tbl_crm_leads
                      SET source = @source,
                          created_date = @date,
                          assigned_to = @assigned,
                          status = @status
                      WHERE lead_id = @id",
                    DBClass.CreateParameter("@id", id),
                    DBClass.CreateParameter("@source", txtSource.Text),
                    DBClass.CreateParameter("@date", dtCreated.Value.Date),
                    DBClass.CreateParameter("@assigned", cmbEmployee.SelectedValue),
                    DBClass.CreateParameter("@status", cmbStatus.Text)
                );
            }
            else // insert new lead
            {
                DBClass.ExecuteNonQuery(
                    @"INSERT INTO tbl_crm_leads
                        (source, created_date, assigned_to, status)
                      VALUES
                        (@source, @date, @assigned, @status)",
                    DBClass.CreateParameter("@source", txtSource.Text),
                    DBClass.CreateParameter("@date", dtCreated.Value.Date),
                    DBClass.CreateParameter("@assigned", cmbEmployee.SelectedValue),
                    DBClass.CreateParameter("@status", cmbStatus.Text)
                );
            }

            LoadLeads(); // refresh the DataGridView or list
        }
        int id = 0;
        private void dgvLeads_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvLeads.Rows[e.RowIndex];

            if (row == null) return;

            id = int.Parse(row.Cells["lead_id"].Value.ToString());
            txtSource.Text = row.Cells["source"].Value.ToString();
            dtCreated.Value = Convert.ToDateTime(row.Cells["created_date"].Value);
            cmbEmployee.SelectedValue = Convert.ToInt32(row.Cells["employee_id"].Value);
            cmbStatus.SelectedItem = row.Cells["status"].Value.ToString();
        }
    }
}
