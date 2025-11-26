using Guna.UI2.WinForms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using YamyProject.Localization;
using Orientation = MigraDoc.DocumentObjectModel.Orientation;

namespace YamyProject
{
    public partial class frmSelectTimeSheetReport : Form
    {
        private string type;

        public frmSelectTimeSheetReport(string _type="")
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            type = _type;
            headerUC1.FormText = this.Text;
            dtFrom.Value = DateTime.Now;
            dtTo.Value = DateTime.Now;
        }
        
        private void frmSelectTimeSheetReport_Load(object sender, EventArgs e)
        {
            
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            if (cmbSelectionMethod.Text == "")
                return;

            if (cmbSelectionMethod.Text == "Labour")
            {
                BindCombos.PopulateProjectResourceLabor(cmbCustomer);
            }
            else if (cmbSelectionMethod.Text == "Employee")
            {
                BindCombos.PopulateEmployees(cmbCustomer);
            }
            else if (cmbSelectionMethod.Text == "Subcontractor")
            {
                BindCombos.PopulateVendors(cmbCustomer, false, false, "Subcontractor");
            }
            else
            {
                cmbCustomer.SelectedIndex = -1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
            if (cmbSelectionMethod.Text == "" || cmbSelectionMethod.Text =="Select")
                return;

            frmLogin.frmMain.openChildForm(new frmTimeSheetReport(cmbSelectionMethod.Text, cmbCustomer.SelectedValue.ToString(), dtFrom.Value, dtTo.Value));
        }
    }
}
