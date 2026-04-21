using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YamyProject.UI.Project_Management
{
    public partial class frmWorkOrder : Form
    {
        public frmWorkOrder()
        {
            InitializeComponent();
        }

        private void frmWorkOrder_Load(object sender, EventArgs e)
        {
            /*Purpose: release field work

            Header

            Work Order No
            Date
            Project
            Site
            WBS
            Zone
            Activity
            Planned Start
            Planned End
            Status

            Grid

            Task / activity lines
            Qty target
            Crew
            Material requirement reference
            Remarks*/
        }
    }
}
