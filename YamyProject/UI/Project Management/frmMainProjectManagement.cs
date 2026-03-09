using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;
using YamyProject.Localization;
using YamyProject.UI.ContractingGeneralMaintenance.CRM;
using YamyProject.UI.ContractingGeneralMaintenance.Equipment;
using YamyProject.UI.ContractingGeneralMaintenance.FinanceBilling;
using YamyProject.UI.ContractingGeneralMaintenance.HRPayroll;
using YamyProject.UI.ContractingGeneralMaintenance.Inventory;
using YamyProject.UI.ContractingGeneralMaintenance.JobOrders;
using YamyProject.UI.ContractingGeneralMaintenance.KPIDashboard;
using YamyProject.UI.ContractingGeneralMaintenance.Labor;
using YamyProject.UI.ContractingGeneralMaintenance.Maintenance;
using YamyProject.UI.ContractingGeneralMaintenance.Procurement;
using YamyProject.UI.ContractingGeneralMaintenance.ProjectManagement;
namespace YamyProject.UI.Manufacturing
{
    public partial class frmMainProjectManagement : Form
    {
        public frmMainProjectManagement()
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
        }

        private void frmMainProjectManagement_Load(object sender, EventArgs e)
        {
            //
        }

        private void ModuleButton_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;

            if (btn == null) return;

            ResetModuleButtons();
            // Highlight selected button
            btn.FillColor = System.Drawing.Color.LightBlue;

            panelMain.Controls.Clear();

            Form module = null;

            switch (btn.Text)
            {
                case "Project Management":
                    module = new ProjectManagementControl();
                    break;
                case "Maintenance":
                    module = new MaintenanceControl();
                    break;
                case "Job/Work Orders":
                    module = new JobOrdersControl();
                    break;
                case "Inventory":
                    module = new InventoryControl();
                    break;
                case "Procurement":
                    module = new ProcurementControl();
                    break;
                case "Equipment":
                    module = new EquipmentControl();
                    break;
                case "Labor":
                    module = new LaborControl();
                    break;
                case "HR && Payroll":
                    module = new HRPayrollControl();
                    break;
                case "Finance && Billing":
                    module = new FinanceControl();
                    break;
                case "CRM":
                    module = new CRMControl();
                    break;
                case "KPI Dashboard":
                    module = new KPIControl();
                    break;
            }

            if (module != null)
            {
                module.Dock = DockStyle.Fill;
                openChildForm(module);
            }
        }
        private void ResetModuleButtons()
        {
            foreach (Control ctrl in panelSidebar.Controls)
            {
                if (ctrl is Guna2Button b)
                {
                    b.FillColor = System.Drawing.Color.SteelBlue; // default color
                }
            }
        }

        public void openChildForm(Form childForm)
        {
            // Check if form of same type already exists
            foreach (Control control in panelMain.Controls)
            {
                if (control is Form existingForm && control.GetType() == childForm.GetType())
                {
                    existingForm.BringToFront();
                    return; // Don't open a new instance
                }
            }

            // Configure the child form
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
