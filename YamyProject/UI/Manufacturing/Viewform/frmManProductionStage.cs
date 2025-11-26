using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Windows.Forms;
using YamyProject.RMS.Class;
using YamyProject.UI.Manufacturing.Models;

namespace YamyProject.UI.Manufacturing.Viewform
{
    public partial class frmManProductionStage : Form
    {
        public int mainid;
        public int activ = 0;
        public frmManProductionStage()
        {
            InitializeComponent();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            RMSClass.blurbackground3(new frmManAddProcessStage());
            GetData();
        }

        private void frmManProductionStage_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                frmManAddProcessStage frm = new frmManAddProcessStage();
                //frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvSno"].Value);
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvId"].Value);
                
                RMSClass.blurbackground3(frm);
                GetData();
            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this batch?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvSno"].Value);
                    string qry1 = "Delete from  tbl_Manufacturing_Steps where id= " + id + "";
                    Hashtable ht = new Hashtable();
                    RMSClass.SQl(qry1, ht);
                    Utilities.LogAudit(frmLogin.userId, "Delete Staff", "Staff", id, "Deleted Staff: " + guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                    MessageBox.Show("Delete Successfully");
                    GetData();
                }
            }
        }

        public void GetData()
        {
            /* 
             * tbl_Manufacturing_Steps (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            code VARCHAR(20) NOT NULL,
                            step_name VARCHAR(100) NOT NULL,
                            description VARCHAR(500),
                            step_order INT NOT NULL,
                            is_completed TINYINT(1) DEFAULT 0,
                            created_by INT,
             *
             */

            string qry = @"SELECT id,code,step_name,description,step_order,is_completed,created_by,created_at from tbl_Manufacturing_Steps;";

            using(MySqlDataReader reader = DBClass.ExecuteReader(qry))
            {
                guna2DataGridView1.Rows.Clear();
                while (reader.Read())
                {
                    int rowIndex = guna2DataGridView1.Rows.Add();
                    DataGridViewRow row = guna2DataGridView1.Rows[rowIndex];
                    row.Cells["dgvSno"].Value = (rowIndex+1).ToString();
                    row.Cells["dgvId"].Value = reader["id"].ToString();
                    row.Cells["dgvcode"].Value = reader["code"].ToString();
                    row.Cells["dgvName"].Value = reader["step_name"].ToString();
                    row.Cells["dgvDescription"].Value = reader["description"].ToString();
                }
                guna2DataGridView1.Columns["dgvId"].Visible = false;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            RMSClass.blurbackground3(new frmManAddProcessStage());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }
    
}
