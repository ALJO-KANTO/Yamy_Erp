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
    public partial class frmMaterialInspection : Form
    {
        public frmMaterialInspection()
        {
            InitializeComponent();
        }

        private void frmMaterialInspection_Load(object sender, EventArgs e)
        {
            /*Purpose: QA/QC checks received material

                Header

                Inspection No
                Linked GRN
                Warehouse
                QA Officer
                Status

                Grid

                Item
                Received Qty
                Accepted Qty
                Rejected Qty
                Result
                Remarks

                Buttons

                Save
                Accept
                Reject
                Post Result
                Close*/
        }
    }
}
