using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.business.Model;
using Inventory.business.Transaction;



namespace SalesandInventory.Transaction
{
    public partial class POListFrm : Form
    {
        private Purchase _pr = new Purchase();
        public POListFrm()
        {
            InitializeComponent();
        }
        private void sbtnGen_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void POListFrm_Load(object sender, EventArgs e)
        {
            loadInformation();
        }
        private void loadInformation()
        {
            ProdListV.Items.Clear();
            List<PurchaseRequest> pr = _pr.SelectAll_PO();
            ListViewItem itm;
            foreach (PurchaseRequest ci in pr)
            {
                itm = new ListViewItem();
                itm.Text = ci.po_id.ToString();
                itm.SubItems.Add(ci.DateCreated.ToString());
                itm.SubItems.Add(ci.status);
                itm.SubItems.Add(ci.TotalAmount.ToString());
                ProdListV.Items.Add(itm);
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Transaction.POFrm frm = new Transaction.POFrm();
            frm.MdiParent = MdiParent;
            frm.Show();
            loadInformation();
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (ProdListV.SelectedItems.Count == 1)
            {
                if (ProdListV.SelectedItems[0].SubItems[2].Text != "Completed")
                {
                    Transaction.CheckedInFrm frm = new Transaction.CheckedInFrm();
                    frm.MdiParent = MdiParent;
                    frm.POid = Convert.ToInt16(ProdListV.SelectedItems[0].Text);
                    frm.Show();
                    loadInformation();
                }
                else
                {
                    MessageBox.Show("Cannot edit completed transaction.");
                }
            }
            else
            {
                Transaction.ReleaseFrm frm = new Transaction.ReleaseFrm();
                frm.MdiParent = MdiParent;
                frm.Show();
            }
            loadInformation();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //TODO Void Order
            if (MessageBox.Show("Item will be cancelled", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ProdListV.SelectedItems.Count == 1)
                {
                    //check if item is already paid and status is completed
                    if (ProdListV.SelectedItems[0].SubItems[2].Text == "Completed")
                    {
                        MessageBox.Show("Cannot cancel completed transaction.");
                    }
                    else
                    {
                        CancelOrder();
                    }
                }
            }
            loadInformation();
        }
        private void CancelOrder()
        {
            if (ProdListV.SelectedItems.Count == 1)
            {
                PurchaseRequest txn = new PurchaseRequest();
                txn.po_id = Convert.ToInt16(ProdListV.SelectedItems[0].Text);
                txn.status = "Cancelled";
                txn.isCompleted = false;
                _pr.PurchaseRequest_Update_status(txn.po_id, false, txn.status);
            }
        }


        private void Search()
        {
            PurchaseRequest req = new PurchaseRequest();
            ProdListV.Items.Clear();
            string orderid = string.Empty;
            string status = string.Empty;
            string datefrom = string.Empty;
            string dateto = string.Empty;
            if (txtOrderid.Text != string.Empty)
            {
                orderid = txtOrderid.Text;
                req.po_id = Convert.ToInt16(orderid);
            }
            if (cmbStatus.Text != "")
            {
                if (cmbStatus.SelectedItem.ToString() != "ALL")
                {
                    status = cmbStatus.SelectedItem.ToString();
                    req.status = status;
                }
            }
            if (dtfrom.Text != "")
            {
                datefrom = dtfrom.Value.ToString();
                dateto = dtto.Value.ToString();
            }
            List<PurchaseRequest> trx = _pr.Search(req, Convert.ToDateTime(datefrom), Convert.ToDateTime(dateto)).ToList();
            ListViewItem itm;
            foreach (PurchaseRequest ci in trx)
            {
                itm = new ListViewItem();
                itm.Text = ci.po_id.ToString();
                itm.SubItems.Add(ci.DateCreated.ToString());
                itm.SubItems.Add(ci.status);
                itm.SubItems.Add(ci.TotalAmount.ToString());
                ProdListV.Items.Add(itm);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Transaction.CheckedInFrm frm = new Transaction.CheckedInFrm();
            frm.MdiParent = MdiParent;
            if (ProdListV.SelectedItems.Count == 1)
            {
                int index = Convert.ToInt32(ProdListV.SelectedItems[0].Text);
                frm.POid = index;
            }
            else
            {
                frm.POid = 0;
            }
            frm.isView = true;
            frm.Show();
        }
    }
}
