using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using YamyProject.RMS.Class;

namespace YamyProject.UI.CRM.Pages
{
    public partial class frmManDashboard : Form
    {
        public frmManDashboard()
        {
            InitializeComponent();
            guna2DataGridView1.RowPrePaint += guna2DataGridView1_RowPrePaint;

        }


        //public DataTable LOADTOTAL(string id)
        //{
        //    return DBClass.ExecuteDataTable("SELECT COUNT(Stage) FROM `tbl_crmcustomer`", DBClass.CreateParameter("@1", id));

        //}
        //public DataTable loadpaid(string id)
        //{
        //    return DBClass.ExecuteDataTable("SELECT COUNT(Stage) FROM `tbl_crmcustomer` WHERE openlvl =@1  ", DBClass.CreateParameter("@1", id));

        //}
        //public string sst = "";
        //public string sst2 = "";
        //public string sst3 = "";
        //public void ShowTotalCountInLabel(string id)
        //{
        //    // Call the LOADTOTAL method to get the DataTable with the count
        //    DataTable result = LOADTOTAL(id);

        //    // Check if the DataTable contains any rows
        //    if (result.Rows.Count > 0)
        //    {
        //        // Extract the count from the first row and first column (since it's a single value)
        //        int count = Convert.ToInt32(result.Rows[0][0]);

        //        // Set the label text with the count
        //        sst = count.ToString();
        //    }
        //    else
        //    {
        //        // If no result found, show a default message
        //        sst = "0";
        //    }
        //}
        //public void ShowTotalCountInLabel2(string id)
        //{
        //    // Call the LOADTOTAL method to get the DataTable with the count
        //    DataTable result = loadpaid(id);

        //    // Check if the DataTable contains any rows
        //    if (result.Rows.Count > 0)
        //    {
        //        // Extract the count from the first row and first column (since it's a single value)
        //        int count = Convert.ToInt32(result.Rows[0][0]);

        //        // Set the label text with the count
        //        sst = count.ToString();
        //    }
        //    else
        //    {
        //        // If no result found, show a default message
        //        sst = "0";
        //    }
        //}

        private void frmManDashboard_Load(object sender, EventArgs e)
        {
            GetData();
            //ShowTotalCountInLabel("Din in");
            //label2.Text = sst;
            //ShowTotalCountInLabel2("Open");
            //label3.Text = sst;
            //ShowTotalCountInLabel2("Won");
            //label5.Text = sst;
            //ShowTotalCountInLabel2("Lost");
            //label7.Text = sst;
        }

        public void GetData()
        {
            string qry = @"SELECT 
                            tmt.id AS task_id,
                            tmb.batchname,
                            tfa.name,  
                            tmt.StartTime,
                            tmt.EndTime,
                            tmt.Status
                            FROM tbl_manufacturer_task tmt
                            INNER JOIN tbl_fixed_assets tfa ON tmt.MachineID = tfa.id
                            INNER JOIN tbl_manufacturer_batch tmb ON tmt.BatchID = tmb.id
                            WHERE
                            tmb.batchname LIKE '%" + guna2TextBox1.Text + "%' ORDER BY tmt.id DESC";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvSno);
            lb.Items.Add(dgvordertype);
            lb.Items.Add(dgvmachinname);
            lb.Items.Add(dgvStart);
            lb.Items.Add(dgvEnd);
            lb.Items.Add(dgvstatus);
            RMSClass.loadData(qry, guna2DataGridView1, lb);
        }

        private void guna2DataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var grid = sender as DataGridView;
            // غيّر "Status" إلى الاسم الصحيح للعمود في الـ DataGridView
            string statusColumnName = "dgvstatus"; // أو "dgvstatus" أو الاسم الموجود عندك

            if (grid.Rows[e.RowIndex].Cells[statusColumnName].Value != null)
            {
                string status = grid.Rows[e.RowIndex].Cells[statusColumnName].Value.ToString();

                if (status == "Done")
                    grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                else if (status == "Cancel")
                    grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                else if (status == "Progress")
                    grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }
        //private void gunaChart3_Load(object sender, EventArgs e)
        //{
        //            }

        //private void LoadChartData()
        //{
        //    // 1. إعداد الاتصال بقاعدة البيانات
        //    string connectionString = "server=localhost;user=root;password=1234;database=mydb;";
        //    MySqlConnection conn = new MySqlConnection(connectionString);

        //    try
        //    {
        //        conn.Open();

        //        // 2. تنفيذ الاستعلام
        //        string query = "SELECT month, amount FROM sales ORDER BY id";
        //        MySqlCommand cmd = new MySqlCommand(query, conn);
        //        MySqlDataReader reader = cmd.ExecuteReader();

        //        // 3. تجهيز القيم
        //        var months = new List<string>();
        //        var values = new List<double>();

        //        while (reader.Read())
        //        {
        //            months.Add(reader.GetString("month"));
        //            values.Add(reader.GetDouble("amount"));
        //        }

        //        // 4. إعداد الشارت (Guna Chart)
        //        gunaChart1.Datasets.Clear();
        //        var dataset = new Guna.Charts.WinForms.GunaChartDataset();
        //        dataset.Label = "المبيعات";
        //        dataset.Data = values;

        //        gunaChart1.Datasets.Add(dataset);
        //        gunaChart1.Labels = months;

        //        gunaChart1.Update();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
    }
}
