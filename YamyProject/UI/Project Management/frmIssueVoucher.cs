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
    public partial class frmIssueVoucher : Form
    {
        public frmIssueVoucher()
        {
            InitializeComponent();
        }

        private void frmIssueVoucher_Load(object sender, EventArgs e)
        {
            /*Purpose: Issue materials to work front / subcontractor / zone

            Header

            Issue No
            Date
            Warehouse
            Issue Type
            Linked MR
            Issued To
            WBS
            Zone
            Status

            Grid

            Item
            Bin
            Requested Qty
            Available Qty
            Issue Qty
            Returned Qty
            Batch
            Unit Rate
            Activity
            Remarks

            Buttons

            Save
            Approve
            Pick
            Issue
            Post
            Close
            Print*/
        }
    }
}
