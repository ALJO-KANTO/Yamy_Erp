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
using YamyProject.Localization;
using YamyProject.UI.Banking;

namespace YamyProject.UI.Accountant
{
    public partial class frmCustomizeColumns : Form
    {
        int typeId;
        public frmCustomizeColumns(int _typeId)
        {
            InitializeComponent();
            LocalizationManager.LocalizeForm(this);
            this.typeId = _typeId;
        }

        private void frmCustomizeColumns_Load(object sender, EventArgs e)
        {
            if (typeId == 0)
            {

                lstAvailable.Items.AddRange(new object[]
                {
                    "Cleared",
                    "Billable?",
                    "Customer:Job",
                    "Item",
                    "Cost",
                    "Qty"
                });

                lstChosen.Items.AddRange(new object[]
                {
                    "Date",
                    "Number",
                    "Payee",
                    "Account",
                    "Amount",
                    "Memo"
                });
            }
            else if (typeId == 1)
            {
                lstAvailable.Items.AddRange(new object[]
                {
                    "Cleared",
                    "Class",
                    "Payment Method"
                });

                lstChosen.Items.AddRange(new object[]
                {
                    "Date",
                    "Received From",
                    "Account From",
                    "Memo",
                    "Check No.",
                    "Amount"
                });
            }
            else if (typeId == 2)
            {
                lstAvailable.Items.AddRange(new object[]
                {
                    "Ref",
                    "Cleared",
                    "Billable?",
                    "Customer:Job",
                    "Item",
                    "Cost",
                    "Qty"
                });

                lstChosen.Items.AddRange(new object[]
                {
                    "Date",
                    "Payee",
                    "Account",
                    "*Amount",
                    "Memo"
                });
            }
            else if (typeId == 3)
            {
                lstAvailable.Items.AddRange(new object[]
                {
                    "Billable?",
                    "Customer:Job",
                    "Item",
                    "Cost",
                    "Qty"
                });

                lstChosen.Items.AddRange(new object[]
                {
                    "Date",
                    "Ref No.",
                    "Vendor",
                    "Terms",
                    "Bill Due",
                    "Account",
                    "*Amount",
                    "Memo"
                });
            }
            else if (typeId == 4)
            {
                lstAvailable.Items.AddRange(new object[]
                {
                    "Due Date",
                    "Sales Rep",
                    "To Print",
                    "To Be Emailed",
                    "Price Level",
                    "Template",
                    "Online Pay"
                });

                lstChosen.Items.AddRange(new object[]
                {
                    "Date",
                    "Number",
                    "Customer:Job",
                    "Terms",
                    "Item",
                    "Description",
                    "Qty",
                    "Rate",
                    "*Amount",
                    "Total"
                });
            }
            else
            {
                lstAvailable.Items.AddRange(new object[]
                {
                    ""
                });

                lstChosen.Items.AddRange(new object[]
                {
                    ""
                });
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstAvailable.SelectedItem == null) return;

            var item = lstAvailable.SelectedItem;
            lstAvailable.Items.Remove(item);
            lstChosen.Items.Add(item);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstChosen.SelectedItem == null) return;

            var item = lstChosen.SelectedItem;
            lstChosen.Items.Remove(item);
            lstAvailable.Items.Add(item);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            int index = lstChosen.SelectedIndex;
            if (index <= 0) return;

            object item = lstChosen.SelectedItem;
            lstChosen.Items.RemoveAt(index);
            lstChosen.Items.Insert(index - 1, item);
            lstChosen.SelectedIndex = index - 1;
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            int index = lstChosen.SelectedIndex;
            if (index < 0 || index >= lstChosen.Items.Count - 1) return;

            object item = lstChosen.SelectedItem;
            lstChosen.Items.RemoveAt(index);
            lstChosen.Items.Insert(index + 1, item);
            lstChosen.SelectedIndex = index + 1;
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            lstAvailable.Items.Clear();
            lstChosen.Items.Clear();

            if (typeId == 0)
            {

                lstAvailable.Items.AddRange(new object[]
                {
                    "Cleared",
                    "Billable?",
                    "Customer:Job",
                    "Item",
                    "Cost",
                    "Qty"
                });

                lstChosen.Items.AddRange(new object[]
                {
                    "Date",
                    "Number",
                    "Payee",
                    "Account",
                    "Amount",
                    "Memo"
                });
            }
            else if (typeId == 1)
            {
                lstAvailable.Items.AddRange(new object[]
                {
                    "Cleared",
                    "Class",
                    "Payment Method"
                });

                lstChosen.Items.AddRange(new object[]
                {
                    "Date",
                    "Received From",
                    "Account From",
                    "Memo",
                    "Check No.",
                    "Amount"
                });
            }
            else if (typeId == 2)
            {
                lstAvailable.Items.AddRange(new object[]
                {
                    "Ref",
                    "Cleared",
                    "Billable?",
                    "Customer:Job",
                    "Item",
                    "Cost",
                    "Qty"
                });

                lstChosen.Items.AddRange(new object[]
                {
                    "Date",
                    "Payee",
                    "Account",
                    "*Amount",
                    "Memo"
                });
            }
            else if (typeId == 3)
            {
                lstAvailable.Items.AddRange(new object[]
                {
                    "Billable?",
                    "Customer:Job",
                    "Item",
                    "Cost",
                    "Qty"
                });

                lstChosen.Items.AddRange(new object[]
                {
                    "Date",
                    "Ref No.",
                    "Vendor",
                    "Terms",
                    "Bill Due",
                    "Account",
                    "*Amount",
                    "Memo"
                });
            }
            else if (typeId == 4)
            {
                lstAvailable.Items.AddRange(new object[]
                {
                    "Due Date",
                    "Sales Rep",
                    "To Print",
                    "To Be Emailed",
                    "Price Level",
                    "Template",
                    "Online Pay"
                });

                lstChosen.Items.AddRange(new object[]
                {
                    "Date",
                    "Number",
                    "Customer:Job",
                    "Terms",
                    "Item",
                    "Description",
                    "Qty",
                    "Rate",
                    "*Amount",
                    "Total"
                });
            }
            else
            {
                lstAvailable.Items.AddRange(new object[]
                {
                    ""
                });

                lstChosen.Items.AddRange(new object[]
                {
                    ""
                });
            }
        }
        public List<string> SelectedColumns { get; private set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectedColumns = lstChosen.Items.Cast<string>().ToList();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
