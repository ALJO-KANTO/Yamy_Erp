using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using YamyProject.DAL;
using YamyProject.Localization;

namespace YamyProject
{
    public partial class frmViewSalesList : Form
    {

        public int SelectedSalesId { get; private set; }
        private int id,RefId;

        public frmViewSalesList( int id=0,int _RefId=0)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);

            this.id = id;
            this.RefId = _RefId;
            headerUC1.FormText = this.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //
            this.Close();
        }

        private void dgvItems_DoubleClick(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                SelectedSalesId = Convert.ToInt32(dgvItems.SelectedRows[0].Cells["id"].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void frmViewSalesList_Load(object sender, EventArgs e)
        {
            AppTheme.DefaultFont(dgvItems);
            if (RefId != 0)
            {
                DataTable  dt = DBClass.ExecuteDataTable("select id ,invoice_id inv, date, net amount from tbl_sales WHERE customer_id = @cId AND id NOT IN (select sales_ref_id from tbl_sales_return)",
                      DBClass.CreateParameter("cId", RefId));
                dgvItems.DataSource = dt;
                dgvItems.Columns["date"].HeaderText = "Date";
                dgvItems.Columns["amount"].HeaderText = "Amount";
                dgvItems.Columns["id"].Visible = false;
                dgvItems.Columns["date"].ReadOnly = dgvItems.Columns["amount"].ReadOnly = dgvItems.Columns["inv"].ReadOnly = true;
            }
        }
    }
}
