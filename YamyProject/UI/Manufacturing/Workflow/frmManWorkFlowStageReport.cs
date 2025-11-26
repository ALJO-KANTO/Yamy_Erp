using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using YamyProject.Localization;

namespace YamyProject.UI.Manufacturing.Viewform
{
    public partial class frmManWorkFlowStageReport : Form
    {
        public frmManWorkFlowStageReport()
        {
            InitializeComponent();
        }

        string status = "";
        private DataView _dataView;
        private int _currentTaskID;

        private void frmManWorkFlowStageReport_Load(object sender, EventArgs e)
        {
            DataTable dt = DBClass.ExecuteDataTable("select id,batchname name from tbl_manufacturer_batch");
            cmbWorkOrder.ValueMember = "id";
            cmbWorkOrder.DisplayMember = "name";
            cmbWorkOrder.DataSource = dt;

            cmbWorkOrder.Text = "Search By Batch  Name ....";
            cmbWorkOrder.SelectedIndex = -1;

            BindProcesses();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Details();
        }


        public void BindProcesses()
        {
            string query = @"
                                SELECT 
                                    p.id AS 'sn',
                                    b.batchname AS 'Batch Name',
                                    p.Status AS 'Process Status',
                                    p.StartTime,
                                    p.current_stage_id,
                                    A.Name AS 'Machine Name',
                                    b.process_stage
                                FROM tbl_manufacturer_task p
                                LEFT JOIN tbl_manufacturer_batch b ON p.BatchID = b.id
                                LEFT JOIN tbl_fixed_assets A on p.MachineID = A.id
                            ";

            DataTable dt = DBClass.ExecuteDataTable(query);
            _dataView = dt.DefaultView;
            dgvCustomer.DataSource = _dataView;

            dgvCustomer.Columns["sn"].Visible = dgvCustomer.Columns["process_stage"].Visible = dgvCustomer.Columns["current_stage_id"].Visible = false;
            dgvCustomer.Columns["Machine Name"].Visible = dgvCustomer.Columns["StartTime"].Visible = false;
            dgvCustomer.Columns["Batch Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCustomer.Columns["Process Status"].Width = 100;
            // Color rows
            foreach (DataGridViewRow row in dgvCustomer.Rows)
            {
                string processStages = row.Cells["process_stage"].Value.ToString();
                string[] stageList = processStages.Split(',');

                int totalStages = stageList.Length;
                int currentStage = Convert.ToInt32(row.Cells["current_stage_id"].Value);

                // Calculate percentage
                double percent = ((double)currentStage / totalStages) * 100;

                // Show percent
                //row.Cells["Progress"].Value = percent.ToString("0") + "%";

                // Color based on percentage
                if (percent == 0)
                    row.DefaultCellStyle.BackColor = Color.LightGray;            // Not started
                else if (percent > 0 && percent < 100)
                    row.DefaultCellStyle.BackColor = Color.LightYellow;          // In progress
                else if (percent >= 100)
                    row.DefaultCellStyle.BackColor = Color.LightGreen;           // Completed
            }

            LocalizationManager.LocalizeDataGridViewHeaders(dgvCustomer);
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int taskId = Convert.ToInt32(dgvCustomer.Rows[e.RowIndex].Cells["sn"].Value);
                _currentTaskID = taskId;
                LoadStages(taskId);
            }
        }

        private void dgvItems_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            Rectangle headerBounds = new Rectangle(
                e.RowBounds.Left,
                e.RowBounds.Top,
                grid.RowHeadersWidth,
                e.RowBounds.Height);

            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }


        private void LoadStages(int taskId)
        {
            string sql = @"
                                SELECT
                                    s.id,
                                    s.code,
                                    s.step_name AS 'Stage Name',
                                    CASE
                                        WHEN s.id < t.current_stage_id THEN 'Completed'
                                        WHEN s.id = t.current_stage_id THEN 'Current'
                                        ELSE 'Pending'
                                    END AS Status,
                                    s.description
                                FROM tbl_manufacturing_steps s
                                LEFT JOIN tbl_manufacturer_task t 
                                    ON t.id = @TaskID
                                ORDER BY s.id;
                            ";

            DataTable dt = DBClass.ExecuteDataTable(sql,
                new MySqlParameter("@TaskID", taskId));

            dgvItems.DataSource = dt;

            // Color rows
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                string status = row.Cells["Status"].Value.ToString();

                if (status == "Completed")
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                else if (status == "Current")
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                else
                    row.DefaultCellStyle.BackColor = Color.LightGray;

                if (status == "Completed")
                    row.Cells["Status"].Value = "✔ Completed";
                else if (status == "Current")
                    row.Cells["Status"].Value = "➤ Current";
                else
                    row.Cells["Status"].Value = "○ Pending";
            }

            dgvItems.Columns["id"].Visible = false;
            LocalizationManager.LocalizeDataGridViewHeaders(dgvItems);
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int stageId = Convert.ToInt32(dgvItems.Rows[e.RowIndex].Cells["id"].Value);
            string stageName = dgvItems.Rows[e.RowIndex].Cells["Stage Name"].Value.ToString();

            int nextStageId = Convert.ToInt32(dgvItems.Rows[e.RowIndex+1].Cells["id"].Value);
            ShowCompleteStageDialog(stageId, stageName, nextStageId);
        }

        private void ShowCompleteStageDialog(int stageId, string stageName,int nextStageId)
        {
            DialogResult result = MessageBox.Show(
                $"Do you want to mark stage \"{stageName}\" as completed?",
                "Complete Stage",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CompleteStage(stageId, nextStageId);
            }
        }
        private void CompleteStage(int stageId, int nextStageId)
        {
            // next stage = stageId + 1
            //int nextStage = stageId + 1;
            int nextStage = nextStageId;

            string sql = @"
                                UPDATE tbl_manufacturer_task
                                SET current_stage_id = @nextStage
                                WHERE id = @taskId
                            ";

            DBClass.ExecuteNonQuery(sql,
                new MySqlParameter("@nextStage", nextStage),
                new MySqlParameter("@taskId", _currentTaskID));  // store selected task ID globally

            MessageBox.Show("Stage updated successfully!");

            // reload stages to refresh the colors
            LoadStages(_currentTaskID);
        }

    }
}
