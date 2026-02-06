using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.Common
{
    public partial class frmEngApprovalLog : Form
    {
        public frmEngApprovalLog()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngApprovalLog_Load(object sender, EventArgs e)
        {
            cmbModule.SelectedIndexChanged += (s, e2) => LoadLog();
        }
        private void LoadLog()
        {
            if (cmbModule.SelectedIndex == -1) return;

            string table = "";

            switch (cmbModule.Text)
            {
                case "Design":
                    table = "eng_design_approval_log";
                    break;
                case "Proposal":
                    table = "crm_proposal_approval_log";
                    break;
                case "Contract":
                    table = "crm_contract_approval_log";
                    break;
                default:
                    table = "";
                    break;
            }

            if (string.IsNullOrEmpty(table)) return;

            dgvApprovals.DataSource = DBClass.ExecuteDataTable(
                $"SELECT * FROM {table} ORDER BY approval_date DESC"
            );
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
