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
    public partial class OrderListsFRM : Form
    {

        private Sales _trn = new Sales();
        private ReportClass rclass = new ReportClass();
        private int isPrint = 0;
        public string userid;
        public string position;
        public OrderListsFRM()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Transaction.OrderFrm frm = new Transaction.OrderFrm();
            frm.MdiParent = MdiParent;
            frm.Show();
            loadinformation();
        }

        private void OrderListsFRM_Load(object sender, EventArgs e)
        {
            loadinformation();
        }
        private void loadinformation()
        {
            ProdListV.Items.Clear();
            List<Transactions> trx = _trn.SelectAll().ToList();
            ListViewItem itm;
            foreach (Transactions ci in trx)
            {
               
                itm = new ListViewItem();
                itm.Text = ci.sales_id.ToString();
                itm.SubItems.Add(ci.referenceNo);
                itm.SubItems.Add(ci.TotalAmount.ToString());
                itm.SubItems.Add(ci.Discounted.ToString());
                itm.SubItems.Add(ci.GrandTotal.ToString());
                itm.SubItems.Add(ci.AmountPaid.ToString());
                itm.SubItems.Add(ci.PayBalance.ToString());
                itm.SubItems.Add(ci.status);
                string paystatus;
                if (ci.isPaid == true)
                {
                    paystatus = "Paid";
                }
                else
                {
                    paystatus = "Unpaid";
                }
                itm.SubItems.Add(paystatus);
                itm.SubItems.Add(ci.TransactionType);
                itm.SubItems.Add(ci.DateCreated.ToString());
                ProdListV.Items.Add(itm);
            }
            isPrint = 1;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Transaction.ReleaseFrm frm = new Transaction.ReleaseFrm();
            frm.MdiParent = MdiParent;
            if (ProdListV.SelectedItems.Count == 1)
            {
                int index = Convert.ToInt32(ProdListV.SelectedItems[0].Text);
                frm.OrderId = index;
            }
            else
            {
                frm.OrderId = 0;
            }
            frm.isView = false;
            frm.Show();
            loadinformation();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (ProdListV.SelectedItems.Count == 1)
            {
                if (ProdListV.SelectedItems[0].SubItems[8].Text != "Paid")
                {
                    string refno = string.Empty;
                    Transaction.ReceiptConfirmFrm rc = new ReceiptConfirmFrm();
                    rc.MdiParent = MdiParent;
                    rc.orderId = ProdListV.SelectedItems[0].Text;
                    refno = ProdListV.SelectedItems[0].SubItems[1].Text;
                    rc.sdate = ProdListV.SelectedItems[0].SubItems[10].Text;
                    rc.totalamount = ProdListV.SelectedItems[0].SubItems[2].Text;
                    rc.discount = ProdListV.SelectedItems[0].SubItems[3].Text;
                    rc.gtotal = ProdListV.SelectedItems[0].SubItems[4].Text;
                    Transactions txn = _trn.SelectByRef(refno);
                    rc.txn = txn;
                    rc.Show();
                }
                else
                {
                    MessageBox.Show("Cannot edit paid transaction.");
                }
            }
            else
            {
                MessageBox.Show("Please select an Item");
            }
            loadinformation();

        }
   
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //TODO Void Order
            if (MessageBox.Show("Item will be cancelled", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ProdListV.SelectedItems.Count == 1)
                {
                    //check if item is already paid and status is completed
                    if (ProdListV.SelectedItems[0].SubItems[8].Text == "Paid")
                    {
                        MessageBox.Show("Cannot cancel paid transaction.");
                    }
                    else
                    {
                        CancelOrder();
                    }
                }
            }
            loadinformation();
        }
        private void CancelOrder()
        {
            if (ProdListV.SelectedItems.Count == 1)
            {
                Transactions txn = new Transactions();
                txn.sales_id = Convert.ToInt16(ProdListV.SelectedItems[0].Text);
                txn.status = "Cancelled";
                txn.isVoided = false;
                txn.processed_by = "";
                _trn.CancelOrder(txn);
            }
        }
        private void sbtnGen_Click(object sender, EventArgs e)
        {
            search();
        }
        private void search()
        {
            Transactions req = new Transactions();
            ProdListV.Items.Clear();
            string orderid = string.Empty;
            string status = string.Empty;
            string datefrom = string.Empty;
            string dateto = string.Empty;

            if (txtOrderid.Text != string.Empty)
            {
                orderid = txtOrderid.Text;
                req.sales_id = Convert.ToInt16(orderid);
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
                req.DateCreated = Convert.ToDateTime(datefrom);
                req.dateUpdated = Convert.ToDateTime(dateto);
            }
            List<Transactions> trx = _trn.Search(req).ToList();
            ListViewItem itm;
            foreach (Transactions ci in trx)
            {

                itm = new ListViewItem();
                itm.Text = ci.sales_id.ToString();
                itm.SubItems.Add(ci.referenceNo);
                itm.SubItems.Add(ci.TotalAmount.ToString());
                itm.SubItems.Add(ci.Discounted.ToString());
                itm.SubItems.Add(ci.GrandTotal.ToString());
                itm.SubItems.Add(ci.AmountPaid.ToString());
                itm.SubItems.Add(ci.PayBalance.ToString());
                itm.SubItems.Add(ci.status);
                string paystatus;
                if (ci.isPaid == true)
                {
                    paystatus = "Paid";
                }
                else
                {
                    paystatus = "Unpaid";
                }
                itm.SubItems.Add(paystatus);
                itm.SubItems.Add(ci.TransactionType);
                itm.SubItems.Add(ci.DateCreated.ToString());
                ProdListV.Items.Add(itm);
            }
            isPrint = 2;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            List<Transactions> trx = new List<Transactions>();
            if (isPrint == 1)
            {
                trx = _trn.SelectAll().ToList();
            }
            else if (isPrint == 2) {

                Transactions req = new Transactions();
                string orderid = string.Empty;
                string status = string.Empty;
                string datefrom = string.Empty;
                string dateto = string.Empty;

                if (txtOrderid.Text != string.Empty)
                {
                    orderid = txtOrderid.Text;
                    req.sales_id = Convert.ToInt16(orderid);
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
                    req.DateCreated = Convert.ToDateTime(datefrom);
                    req.dateUpdated = Convert.ToDateTime(dateto);
                }
               trx = _trn.Search(req).ToList();
            }

            Report.TransactionFrm frm = new Report.TransactionFrm();
            frm.trx = trx;
            frm.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Transaction.ReleaseFrm frm = new Transaction.ReleaseFrm();
            frm.MdiParent = MdiParent;
            if (ProdListV.SelectedItems.Count == 1)
            {
                int index = Convert.ToInt32(ProdListV.SelectedItems[0].Text);
                frm.OrderId = index;
            }
            else
            {
                frm.OrderId = 0;
            }
            frm.isView = true;
            frm.Show();
            loadinformation();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Report.PrintReceipt frm = new Report.PrintReceipt();
            frm.MdiParent = MdiParent;
            if (ProdListV.SelectedItems.Count == 1)
            {
                int index = Convert.ToInt32(ProdListV.SelectedItems[0].Text);
                List<DeliveryReceipt> trxn = new List<DeliveryReceipt>();
                trxn = rclass.CustomerReceipt(index);
                frm.trx = trxn;
                frm.isOldTemplate = false;
                frm.Show();
            }
        }

        private void AccessApplication()
        {
            if (position == "Admin")
            {
              
            }
            if (position == "Cashier")
            {
              
            }
            if (position == "Warehouse")
            {
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton5.Visible = false;
                toolStripButton3.Visible = false;   
            }
            if (position == "Super Admin")
            {
              
            }
        }
    }
}
