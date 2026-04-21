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
    public partial class frmGoodsReceipt : Form
    {
        public frmGoodsReceipt()
        {
            InitializeComponent();
        }

        private void frmGoodsReceipt_Load(object sender, EventArgs e)
        {
            /*
             * 
                Purpose: Receive material into store (GRN)

                Header

                GRN No
                Date
                Project
                Site
                Warehouse
                Receipt Type
                Supplier
                Reference No
                Status

                Grid

                Item
                Bin
                Qty Received
                Qty Accepted
                Qty Rejected
                Unit Rate
                Batch No
                Expiry
                Remarks

                Buttons

                Save
                Receive
                Send to Inspection
                Post
                Close
                Print
             */
        }
    }
}
