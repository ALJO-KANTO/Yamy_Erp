using DocumentFormat.OpenXml.Office.Word;
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
using YamyProject.DAL;

namespace YamyProject.UI.EngineeringConsultancy.ViewForm.ProjectPhase
{
    public partial class frmProjectPhasesNew : Form
    {
        private int projectId = 0;
        public frmProjectPhasesNew()
        {
            InitializeComponent();
        }
        private void frmProjectPhasesNew_Load(object sender, EventArgs e)
        {
            LoadPhases();
        }
        private void LoadPhases()
        {
            tabPhases.TabPages.Clear();

            string q = @"SELECT * FROM tbl_project_phase_templates 
                     WHERE is_active = 1 
                     ORDER BY phase_no";

            DataTable dt = DBClass.ExecuteDataTable(q);

            foreach (DataRow row in dt.Rows)
            {
                int templateId = Convert.ToInt32(row["template_id"]);
                string phaseName = row["phase_name"].ToString();

                TabPage tab = new TabPage(phaseName);

                DataGridView dgv = CreateTaskGrid(templateId);

                tab.Controls.Add(dgv);
                tabPhases.TabPages.Add(tab);
            }

        }
        private DataGridView CreateTaskGrid(int templateId)
        {
            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.AutoGenerateColumns = false;

            dgv.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "task_template_id",
                DataPropertyName = "task_template_id",
                Visible = false
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "task_name",
                HeaderText = "Task",
                DataPropertyName = "task_name",
                Width = 300
            });

            dgv.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "is_completed",
                HeaderText = "Done",
                DataPropertyName = "is_completed"
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "remarks",
                HeaderText = "Remarks",
                DataPropertyName = "remarks",
                Width = 200
            });

            dgv.DataSource = LoadTasks(templateId);

            return dgv;
        }
        private DataTable LoadTasks(int templateId)
        {
            string q = @"SELECT 
                        t.task_template_id,
                        t.task_name,
                        0 as is_completed,
                        '' as remarks
                     FROM tbl_project_phase_task_templates t
                     WHERE t.template_id = @templateId
                     AND t.is_active = 1
                     ORDER BY t.sort_order";

            DataTable dt = DBClass.ExecuteDataTable(q, DBClass.CreateParameter("@templateId", templateId));

            return dt;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in tabPhases.TabPages)
            {
                DataGridView dgv = (DataGridView)tab.Controls[0];

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    int templateTaskId = Convert.ToInt32(row.Cells["task_template_id"].Value);
                    bool isCompleted = Convert.ToBoolean(row.Cells["is_completed"].Value);
                    string remarks = row.Cells["remarks"].Value?.ToString();

                    string insert = @"INSERT INTO tbl_project_phase_tasks
                                (phase_id, task_template_id, task_name, is_completed, remarks, completed_on)
                                VALUES
                                (1, @tid, @name, @done, @remarks, 
                                 IF(@done=1, NOW(), NULL))";

                    DBClass.ExecuteNonQuery(insert,
                    DBClass.CreateParameter("@tid", templateTaskId),
                    DBClass.CreateParameter("@name", row.Cells["task_name"].Value.ToString()),
                    DBClass.CreateParameter("@done", isCompleted),
                    DBClass.CreateParameter("@remarks", remarks)
                    );

                    // 🔔 Notification
                    if (isCompleted)
                    {
                        NotificationService.Add(projectId, 1, templateTaskId, "Task Completed",
                            $"Task '{row.Cells["task_name"].Value}' completed",
                            "Success");

                        AddLog("TaskCompleted",
                            row.Cells["task_name"].Value.ToString());
                    }
                }
            }

            MessageBox.Show("Saved successfully");
        }
        private void AddLog(string type, string newValue)
        {
            string q = @"INSERT INTO tbl_project_activity_log
                (project_id, activity_type, new_value)
                VALUES (@pid, @type, @val)";

            DBClass.ExecuteNonQuery(q,
            DBClass.CreateParameter("@pid", projectId),
            DBClass.CreateParameter("@type", type),
            DBClass.CreateParameter("@val", newValue));
        }
    }
}
