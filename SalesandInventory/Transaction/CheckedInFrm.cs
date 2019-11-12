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
    public partial class CheckedInFrm : Form
    {
        public int POid;
        public bool isView;
        private Purchase _pr = new Purchase();
        public CheckedInFrm()
        {
            InitializeComponent();
        }
        private void CheckedInFrm_Load(object sender, EventArgs e)
        {
            if (POid > 0)
            {
                txtorderid.Text = POid.ToString();
                loadinformation();
                LoadCheckedItem();
            }
            if (isView == true)
            {
                txtbarcode.Enabled = false;
                ProdListV.Enabled = false;
                PListView.Enabled = false;
                button3.Enabled = true;
            }
            else
            {
                txtbarcode.Enabled = true;
                ProdListV.Enabled = true;
                PListView.Enabled = true;
                button3.Enabled = false;
            }
        }
        private void loadinformation()
        {
            List<PurchaseItem> trx = _pr.CheckedInItem_list(POid,false).ToList();
            ProdListV.Items.Clear();
            ListViewItem itm;
            foreach (PurchaseItem ci in trx)
            {
                itm = new ListViewItem();
                itm.Text = ci.po_detail_id.ToString();
                itm.SubItems.Add(ci.ProductCode);
                itm.SubItems.Add(ci.ProductName);
                itm.SubItems.Add(ci.QTY.ToString());
                ProdListV.Items.Add(itm);
            }
        }

        private void LoadCheckedItem()
        {
            List<PurchaseItem> trx = _pr.CheckedInItem_list(POid, true).ToList();
            PListView.Items.Clear();
            ListViewItem itm;
            foreach (PurchaseItem ci in trx)
            {
                itm = new ListViewItem();
                itm.Text = ci.po_detail_id.ToString();
                itm.SubItems.Add(ci.ProductCode);
                itm.SubItems.Add(ci.ProductName);
                itm.SubItems.Add(ci.QTY.ToString());
                PListView.Items.Add(itm);
            }
        }

        private void txtorderid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (txtorderid.Text != string.Empty && txtorderid.Text != "0")
                {
                    loadinformation();
                    LoadCheckedItem();
                }
            }
        }
        private void txtbarcode_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
            {
                if (txtbarcode.Text != string.Empty)
                {
                    ScanBarcode();
                }
            }
            loadinformation();
            LoadCheckedItem();
        }

        private void ScanBarcode()
        {
            if (txtbarcode.Text != string.Empty)
            {
                int orderid = Convert.ToInt16(txtorderid.Text);
                PurchaseItem pr = new PurchaseItem();
                pr = _pr.Purchase_Item_lis_find(orderid, txtbarcode.Text,false);
                if (pr != null)
                {
                    lblPcode.Text = pr.ProductCode;
                    lblPid.Text = pr.product_id.ToString();
                    lblPname.Text = pr.ProductName;
                    txtqty.Text = pr.QTY.ToString();
                    pr.isCheckedIn = true;
                    if (_pr.isItemExists(orderid, Convert.ToInt16(pr.product_id),true) == false)
                    {
                        _pr.UpdateItemStatus(pr);
                    }
                    else
                    {
                        MessageBox.Show("Item already released");
                    }
                }
                else
                {
                    MessageBox.Show("Item not found");
                }
            }
            txtbarcode.Text = string.Empty;
            txtqty.Text = string.Empty;
        }

        private void PListView_DoubleClick(object sender, EventArgs e)
        {
            if (this.PListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Item will be removed", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int orderid = Convert.ToInt16(txtorderid.Text);
                    PurchaseItem pr = new PurchaseItem();
                    pr = _pr.Purchase_Item_lis_find(orderid, txtbarcode.Text, true);
                    pr.isCheckedIn = false;
                    _pr.UpdateItemStatus(pr);
                }
            }
            loadinformation();
            LoadCheckedItem();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int POid = Convert.ToInt16(txtorderid.Text);
            if (_pr.isAllCheckedin(POid, false) == true)
            {
                if(_pr.CompletePO(POid,0) == true)
                {
                    _pr.PurchaseRequest_Update_status(POid, true, "Completed");
                    MessageBox.Show("Transactions are complete");
                }
            }
            else
            {
                MessageBox.Show("There still items not yet Checked In cannot complete the transactions");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (POid > 0)
            {
                txtorderid.Text = POid.ToString();
            }
            else
            {
                POid = Convert.ToInt16(txtorderid.Text);
            }
            List<PurchaseItem> trx = new List<PurchaseItem>();
            trx = _pr.SelectItemListsAll(POid).ToList();
            Report.POReport frm = new Report.POReport();
            frm.dateparams = string.Empty;
            frm.trx = trx;
            frm.Show();
        }
    }
}
