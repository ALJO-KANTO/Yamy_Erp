using DocumentFormat.OpenXml.Bibliography;
using MySql.Data.MySqlClient;
using Mysqlx.Session;
using System;
using System.Data;

namespace YamyProject.UI.Project_Management
{
    public static class ProjectWorkflowService
    {
        // =========================================================
        // 🔹 1. CREATE FULL WORKFLOW WHEN PROJECT IS CREATED
        // =========================================================
        public static void InitializeProjectWorkflow(int projectId, int userId, int phaseId)
        {
            try
            {
                CreateUsingPhases(projectId, phaseId);
                //CreatePhases(projectId, userId);
                CreateStages(projectId);
                Log(projectId, null, null, "Project Created", null, null, "Workflow initialized", userId);
            }
            catch (Exception ex)
            {
                throw new Exception("Workflow Initialization Failed: " + ex.Message);
            }
        }

        public static void CheckProjectWorkFlowAndUpdate(int projectId, int userId, int phaseId)
        {
            try
            {
                //delete existing workflow and initialize new workflow to reset the workflow to first step if it is not started or to keep the same step if it is already started
                //1st check tbl_eng_project_phases exist
                using (MySqlDataReader reader = DBClass.ExecuteReader("select * from tbl_eng_project_phases where project_id = @projectId", DBClass.CreateParameter("@projectId", projectId)))
                {
                    if (reader.Read())
                    {
                        object objPhaseId = DBClass.ExecuteScalar("select phase_id from tbl_eng_project_phases where project_id = @projectId and status = 'Pending' ", DBClass.CreateParameter("@projectId", projectId));
                        if (objPhaseId != null)
                        {
                            if (objPhaseId.ToString() == "Pending")
                            {
                                //InitializeProjectWorkflow(projectId, userId);
                            }
                        }
                    }
                    else
                    {
                        InitializeProjectWorkflow(projectId, userId, phaseId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static void CreateUsingPhases(int phaseId, int templateId)
        {
            CreateTasks(phaseId, templateId);
        }
        // =========================================================
        // 🔹 2. CREATE PHASES + TASKS
        // =========================================================
        private static void CreatePhasesNew(int projectId, int userId, int phaseId)
        {
            DataTable phases = DBClass.ExecuteDataTable("SELECT * FROM tbl_project_phase_templates ORDER BY sort_order");

            foreach (DataRow phase in phases.Rows)
            {
                int templateId = Convert.ToInt32(phase["template_id"]);
                int phaseNo = Convert.ToInt32(phase["phase_no"]);
                string phaseName = phase["phase_name"].ToString();

                //int phaseId = Convert.ToInt32(DBClass.ExecuteScalar(@"
                //INSERT INTO tbl_eng_project_phases
                //(project_id, template_id, phase_no, phase_name, status, phase_color)
                //VALUES (@projectId, @templateId, @phaseNo, @phaseName, 'Pending', 'Gray');
                //SELECT LAST_INSERT_ID();",
                //    DBClass.CreateParameter("@projectId", projectId),
                //    DBClass.CreateParameter("@templateId", templateId),
                //    DBClass.CreateParameter("@phaseNo", phaseNo),
                //    DBClass.CreateParameter("@phaseName", phaseName)
                //));

                CreateTasks(phaseId, templateId);
            }
        }

        private static void CreateTasks(int phaseId, int templateId)
        {
            DataTable tasks = DBClass.ExecuteDataTable(@"
            SELECT * FROM tbl_project_phase_task_templates 
            WHERE template_id = @templateId
            ORDER BY sort_order",
                DBClass.CreateParameter("@templateId", templateId));

            foreach (DataRow task in tasks.Rows)
            {
                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_project_phase_tasks
                (phase_id, task_template_id, task_name, is_required, sort_order)
                VALUES (@phaseId, @templateId, @taskName, @required, @sort)",
                    DBClass.CreateParameter("@phaseId", phaseId),
                    DBClass.CreateParameter("@templateId", task["task_template_id"]),
                    DBClass.CreateParameter("@taskName", task["task_name"]),
                    DBClass.CreateParameter("@required", task["is_mandatory"]),
                    DBClass.CreateParameter("@sort", task["sort_order"])
                );
            }
        }

        // =========================================================
        // 🔹 3. CREATE PROJECT STAGES
        // =========================================================
        private static void CreateStages(int projectId)
        {
            DataTable stages = DBClass.ExecuteDataTable("SELECT * FROM tbl_project_stage_templates ORDER BY sort_order");

            bool first = true;

            foreach (DataRow stage in stages.Rows)
            {
                DBClass.ExecuteNonQuery(@"
                INSERT INTO tbl_project_stages
                (project_id, stage_no, stage_name, status, is_current)
                VALUES (@projectId, @no, @name, 'Pending', @current)",
                    DBClass.CreateParameter("@projectId", projectId),
                    DBClass.CreateParameter("@no", stage["stage_no"]),
                    DBClass.CreateParameter("@name", stage["stage_name"]),
                    DBClass.CreateParameter("@current", first ? 1 : 0)
                );

                first = false;
            }
        }

        // =========================================================
        // 🔹 4. COMPLETE TASK
        // =========================================================
        public static void CompleteTask(int taskId, int userId)
        {
            DBClass.ExecuteNonQuery(@"
            UPDATE tbl_project_phase_tasks
            SET is_completed = 1,
                completed_on = NOW(),
                completed_by = @userId,
                status = 'Completed'
            WHERE task_id = @taskId",
                DBClass.CreateParameter("@taskId", taskId),
                DBClass.CreateParameter("@userId", userId)
            );

            int phaseId = Convert.ToInt32(DBClass.ExecuteScalar(
                "SELECT phase_id FROM tbl_project_phase_tasks WHERE task_id = @taskId",
                DBClass.CreateParameter("@taskId", taskId)));

            CheckPhaseCompletion(phaseId, userId);
        }

        // =========================================================
        // 🔹 5. CHECK PHASE COMPLETION
        // =========================================================
        private static void CheckPhaseCompletion(int phaseId, int userId)
        {
            int remaining = Convert.ToInt32(DBClass.ExecuteScalar(@"
            SELECT COUNT(*) 
            FROM tbl_project_phase_tasks
            WHERE phase_id = @phaseId
              AND is_required = 1
              AND is_completed = 0",
                DBClass.CreateParameter("@phaseId", phaseId)));

            if (remaining == 0)
            {
                DBClass.ExecuteNonQuery(@"
                UPDATE tbl_eng_project_phases
                SET status = 'Completed',
                    phase_color = 'Green',
                    completed_on = NOW()
                WHERE phase_id = @phaseId",
                    DBClass.CreateParameter("@phaseId", phaseId));

                int projectId = Convert.ToInt32(DBClass.ExecuteScalar(
                    "SELECT project_id FROM tbl_eng_project_phases WHERE phase_id = @phaseId",
                    DBClass.CreateParameter("@phaseId", phaseId)));

                Notify(projectId, phaseId, null, "Phase Completed", "Phase completed successfully");
                MoveToNextStage(projectId);

                Log(projectId, phaseId, null, "Phase Completed", null, "Completed", "Auto completed", userId);
            }
        }

        // =========================================================
        // 🔹 6. MOVE TO NEXT STAGE
        // =========================================================
        private static void MoveToNextStage(int projectId)
        {
            DataTable dt = DBClass.ExecuteDataTable(@"
            SELECT * FROM tbl_project_stages 
            WHERE project_id = @projectId AND is_current = 1",
                DBClass.CreateParameter("@projectId", projectId));

            DataRow current = dt.Rows.Count > 0 ? dt.Rows[0] : null;

            if (current == null) return;

            int currentNo = Convert.ToInt32(current["stage_no"]);

            DBClass.ExecuteNonQuery(@"
            UPDATE tbl_project_stages
            SET is_current = 0,
                status = 'Completed',
                completed_on = NOW()
            WHERE project_id = @projectId AND stage_no = @no",
                DBClass.CreateParameter("@projectId", projectId),
                DBClass.CreateParameter("@no", currentNo));

            DBClass.ExecuteNonQuery(@"
            UPDATE tbl_project_stages
            SET is_current = 1
            WHERE project_id = @projectId AND stage_no = @next",
                DBClass.CreateParameter("@projectId", projectId),
                DBClass.CreateParameter("@next", currentNo + 1));
        }

        // =========================================================
        // 🔹 7. NOTIFICATIONS
        // =========================================================
        public static void Notify(int projectId, int? phaseId, int? taskId, string title, string message)
        {
            DBClass.ExecuteNonQuery(@"
            INSERT INTO tbl_notifications
            (project_id, phase_id, task_id, title, message, notification_type)
            VALUES (@projectId, @phaseId, @taskId, @title, @message, 'System')",
                DBClass.CreateParameter("@projectId", projectId),
                DBClass.CreateParameter("@phaseId", phaseId),
                DBClass.CreateParameter("@taskId", taskId),
                DBClass.CreateParameter("@title", title),
                DBClass.CreateParameter("@message", message)
            );
        }

        // =========================================================
        // 🔹 8. ACTIVITY LOG
        // =========================================================
        public static void Log(int projectId, int? phaseId, int? taskId,
            string activity, string oldVal, string newVal, string remarks, int userId)
        {
            DBClass.ExecuteNonQuery(@"
            INSERT INTO tbl_project_activity_log
            (project_id, phase_id, task_id, activity_type, old_value, new_value, remarks, created_by)
            VALUES (@projectId, @phaseId, @taskId, @activity, @oldVal, @newVal, @remarks, @user)",
                DBClass.CreateParameter("@projectId", projectId),
                DBClass.CreateParameter("@phaseId", phaseId),
                DBClass.CreateParameter("@taskId", taskId),
                DBClass.CreateParameter("@activity", activity),
                DBClass.CreateParameter("@oldVal", oldVal),
                DBClass.CreateParameter("@newVal", newVal),
                DBClass.CreateParameter("@remarks", remarks),
                DBClass.CreateParameter("@user", userId)
            );
        }

        // =========================================================
        // 🔹 9. STALE PROJECT CHECK (1 MONTH)
        // =========================================================
        public static void CheckStaleProjects()
        {
            DBClass.ExecuteNonQuery(@"
            INSERT INTO tbl_notifications (project_id, title, message, notification_type)
            SELECT project_id, 'Project Not Updated', 'No update for 30 days', 'Warning'
            FROM tbl_projects
            WHERE last_progress_update IS NULL
               OR last_progress_update < DATE_SUB(NOW(), INTERVAL 30 DAY)");
        }

        // =========================================================
        // 🔹 10. DELAY CHECK
        // =========================================================
        public static void CheckProjectDelays()
        {
            DBClass.ExecuteNonQuery(@"
            INSERT INTO tbl_notifications (project_id, title, message, notification_type)
            SELECT project_id, 'Project Delayed', 'Execution delay detected', 'Warning'
            FROM tbl_projects
            WHERE CURDATE() > end_date
              AND status <> 'Completed'");
        }
    }
}