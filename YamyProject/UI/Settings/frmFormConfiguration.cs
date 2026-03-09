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

namespace YamyProject.UI.Settings
{
    public partial class frmFormConfiguration : Form
    {
        private int selectedId = 0;

        public frmFormConfiguration()
        {
            InitializeComponent();
            headerUC1.FormText = "Form Configuration";
        }

        private void frmFormConfiguration_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = DBClass.ExecuteDataTable("SELECT * FROM tbl_form_configuration");
            if(dt !=null)
                dgvForms.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DBClass.ExecuteNonQuery("INSERT INTO tbl_form_configuration (form_name, affect_stock, affect_account) VALUES (@name,@stock,@account)",
            DBClass.CreateParameter("@name", txtFormName.Text),
            DBClass.CreateParameter("@stock", chkStock.Checked ? 1 : 0),
            DBClass.CreateParameter("@account", chkAccount.Checked ? 1 : 0));

            LoadData();
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == 0) return;
            DBClass.ExecuteNonQuery("UPDATE tbl_form_configuration SET form_name=@name, affect_stock=@stock, affect_account=@account WHERE id=@id", 
                DBClass.CreateParameter("@id", selectedId),
                DBClass.CreateParameter("@name", txtFormName.Text),
                DBClass.CreateParameter("@stock", chkStock.Checked ? 1 : 0),
                DBClass.CreateParameter("@account", chkAccount.Checked ? 1 : 0));
            
            LoadData();
            ClearInputs();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == 0) return;
            //if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    DBClass.ExecuteNonQuery("DELETE FROM tbl_form_configuration WHERE id=@id", 
            //        DBClass.CreateParameter("@id", selectedId));
            //    LoadData();
            //    ClearInputs();
            //}
        }

        private void dgvForms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            selectedId = Convert.ToInt32(dgvForms.Rows[e.RowIndex].Cells["id"].Value);
            txtFormName.Text = dgvForms.Rows[e.RowIndex].Cells["form_name"].Value.ToString();
            chkStock.Checked = Convert.ToBoolean(dgvForms.Rows[e.RowIndex].Cells["affect_stock"].Value);
            chkAccount.Checked = Convert.ToBoolean(dgvForms.Rows[e.RowIndex].Cells["affect_account"].Value);
        }

        private void ClearInputs()
        {
            txtFormName.Clear();
            chkStock.Checked = false;
            chkAccount.Checked = false;
            selectedId = 0;
        }
    }
}
