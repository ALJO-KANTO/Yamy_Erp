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
    public partial class frmEngSettings : Form
    {
        public frmEngSettings()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmEngSettings_Load(object sender, EventArgs e)
        {
            dgvSettings.DataSource = DBClass.ExecuteDataTable(
                "SELECT setting_key, setting_value, description FROM erp_settings ORDER BY setting_key");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSettings.Rows)
            {
                if (row.IsNewRow) continue;

                DBClass.ExecuteNonQuery(
                    @"UPDATE erp_settings SET setting_value=@value WHERE setting_key=@key",
                    DBClass.CreateParameter("@value", row.Cells["setting_value"].Value),
                    DBClass.CreateParameter("@key", row.Cells["setting_key"].Value)
                );
            }

            MessageBox.Show("Settings saved successfully.");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
