using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamyProject.UI.Project_Management.ProjectWBS;

namespace YamyProject.UI.Project_Management
{
    public partial class frmWBSMaster : Form
    {
        public frmWBSMaster()
        {
            InitializeComponent();
            headerUC1.FormText = this.Text;
        }

        private void frmWBSMaster_Load(object sender, EventArgs e)
        {
            //WBS code, WBS name, parent WBS, level
            /*-- WBS hierarchy (links planning → activities properly)
                CREATE TABLE IF NOT EXISTS `tbl_project_wbs` (
                  `id`           INT NOT NULL AUTO_INCREMENT,
                  `project_id`   INT NOT NULL DEFAULT 0,
                  `parent_wbs_id`INT NOT NULL DEFAULT 0,   -- 0 = root level
                  `code`         VARCHAR(50)  NOT NULL DEFAULT '',
                  `name`         VARCHAR(300) NOT NULL DEFAULT '',
                  `wbs_level`    INT NOT NULL DEFAULT 1,
                  `description`  VARCHAR(500) DEFAULT '',
                  `is_active`    TINYINT(1)   NOT NULL DEFAULT 1,
                  `created_by`   INT NOT NULL DEFAULT 0,
                  `created_at`   DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP,
                  PRIMARY KEY (`id`),
                  UNIQUE KEY `uq_wbs_code` (`project_id`, `code`)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
            */
            loadData();
        }

        private void loadData()
        {
            string query = @"select p.name Project,wbs.parent_wbs_id id,wbs.code Code,wbs.name Name,wbs.wbs_level Level,wbs.description Description from tbl_project_wbs wbs INNER JOIN tbl_projects p ON p.id = wbs.project_id";

            dgView.DataSource = DBClass.ExecuteDataTable(query);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmLogin.frmMain.openChildForm(new frmProjectWBS());
        }

        private void dgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgView.Rows.Count == 0) return;

            if (int.Parse(dgView.SelectedRows[0].Cells["id"].ToString()) > 0)
            {
                frmLogin.frmMain.openChildForm(new frmProjectWBS(int.Parse(dgView.SelectedRows[0].Cells["id"].ToString())));
            }
        }
    }
}
