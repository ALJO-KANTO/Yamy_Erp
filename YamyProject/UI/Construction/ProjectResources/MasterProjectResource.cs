using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class MasterProjectResource : Form
    {

        private EventHandler eventHandler;

        public MasterProjectResource()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            eventHandler = (sender, args) => BindInvoices();
            EventHub.ProjectViewResource += eventHandler;
            headerUC1.FormText = this.Text;
        }
        
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmProjectResource(null,0));
        }
        private void MasterProjectSites_Load(object sender, EventArgs e)
        {
            BindCombos.PopulateProjects(cmbProject);
            BindInvoices();
        }
        public void BindInvoices()
        {
            DataTable dt;
            string query = @"SELECT p.id,p.code Code,p.date Date,p.name Name,r.name Role,p.phone Phone,p.`type` Type,p.price_unit `Price Unit`,p.unit_time `Unit Time`,p.max_unit_time `Max Unit Time` from tbl_project_resource p INNER JOIN tbl_project_role r ON p.role = r.id where p.id > 0 ";

            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (cmbProject.Text != "" && !chkProject.Checked)
            {
                query += " and p.type = @type";
                parameters.Add(DBClass.CreateParameter("type", cmbProject.SelectedItem.ToString()));
            }

            dt = DBClass.ExecuteDataTable(query, parameters.ToArray());
            dgView.DataSource = dt;
            dgView.Columns["Name"].MinimumWidth = 200;
            dgView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgView.Columns["id"].Visible = false;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindInvoices();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgView.Rows.Count == 0)
                return;
            frmLogin.frmMain.openChildForm(new frmProjectResource(null,int.Parse(dgView.SelectedRows[0].Cells["id"].Value.ToString())));
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgView.Rows.Count == 0)
                return;

            frmLogin.frmMain.openChildForm(new frmProjectResource(null,int.Parse(dgView.CurrentRow.Cells["id"].Value.ToString())));
        }
        private void dgvCustomer_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void dgvCustomer_Leave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProject.Checked)
                cmbProject.Enabled = false;
            else
                cmbProject.Enabled = true;
            BindInvoices();
        }
        
        private void cmbSalesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindInvoices();
        }
        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            BindInvoices();
        }
    }
}
