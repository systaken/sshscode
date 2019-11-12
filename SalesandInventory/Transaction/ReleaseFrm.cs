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
    public partial class ReleaseFrm : Form
    {

        private SalesDetail td = new SalesDetail();
        private Sales s = new Sales();
        private ReleaseRepositories _release = new ReleaseRepositories();
        public bool isView = false;
     
        public int OrderId = 0;
        public ReleaseFrm()
        {
            InitializeComponent();
        }
     
        private void LoadProducts()
        {
            int Salesid = Convert.ToInt32(txtorderid.Text);
            List<TransactionDetails> txd = new List<TransactionDetails>();
            txd = td.SelectbySalesId(Salesid);
            ProdListV.Items.Clear();
            ListViewItem itm;
            foreach (TransactionDetails t in txd)
            {
                itm = new ListViewItem();
                itm.Text = t.sales_detail_id.ToString();
                itm.SubItems.Add(t.productcode);
                itm.SubItems.Add(t.ProductName);
                itm.SubItems.Add(t.QTY.ToString()); ;
                ProdListV.Items.Add(itm);
            }
        }

        private void ReleaseFrm_Load(object sender, EventArgs e)
        {
            if(OrderId > 0)
            {
                txtorderid.Text = OrderId.ToString();
                LoadProducts();
                loadReleasedLists();
                if (isView == true)
                {
                    txtbarcode.Enabled = false;
                    ProdListV.Enabled = false;
                    PListView.Enabled = false;
                    button1.Enabled = true;
                }
                else
                {
                    txtbarcode.Enabled = true;
                    ProdListV.Enabled = true;
                    PListView.Enabled = true;
                    button1.Enabled = false;
                }
            }
        }

       
        private void txtorderid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(txtorderid.Text != string.Empty && txtorderid.Text != "0")
                {
                    LoadProducts();
                    loadReleasedLists();
                }
            }
        }
        private void loadReleasedLists()
        {
            int salesid = Convert.ToInt32(txtorderid.Text);
            List<Releases> txd = new List<Releases>();
            txd = _release.ItemList(salesid);
            PListView.Items.Clear();
            ListViewItem itm;
            foreach (Releases t in txd)
            {
                itm = new ListViewItem();
                itm.Text = t.sales_detail_id.ToString();
                itm.SubItems.Add(t.productcode);
                itm.SubItems.Add(t.ProductName);
                itm.SubItems.Add(t.releaseQTY.Value.ToString()); ;
                PListView.Items.Add(itm);
            }
        }
        private void ScanBarcode()
        {
            if (txtbarcode.Text != string.Empty)
            {
                int orderid = Convert.ToInt16(txtorderid.Text);
                ProductReleases pr = new ProductReleases();
                pr = _release.ProductReleaseFind(orderid, txtbarcode.Text);
                if (pr != null)
                {
                    lblPcode.Text = pr.productcode;
                    lblPid.Text = pr.product_id.ToString();
                    lblPname.Text = pr.ProductName;
                    txtqty.Text = pr.QTY.ToString();
                    if (_release.isItemExists(orderid, pr.sales_detail_id) == false)
                    {
                        ReleaseItem(pr);
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
            LoadProducts();
        }
        private void ReleaseItem(ProductReleases pr)
        {
            bool result = _release.ProductRelease(pr.sales_detail_id, pr.product_id.Value, pr.QTY.Value, true);
            if (result == true)
            {
                int qtys = Convert.ToInt16(txtqty.Text);
                _release.ReleaseItemInsert(pr.sales_detail_id, pr.sales_id.Value, qtys);
                loadReleasedLists();
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
        }
        private void PListView_DoubleClick(object sender, EventArgs e)
        {
            if (this.PListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Item will be removed", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int salesdetailid = Convert.ToInt16(PListView.SelectedItems[0].Text);
                    _release.removedItem(salesdetailid);
                    _release.ReleaseRemoved(salesdetailid);
                }
            }
            loadReleasedLists();
            LoadProducts();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int salesid = Convert.ToInt16(txtorderid.Text);
            if (_release.isAllRelease(salesid, false) == true)
            {
                //update to complete
                if (_release.CompleteRelease(salesid, 0) == true)
                {
                    s.CompleteSales(salesid, "Completed", "");
                    MessageBox.Show("Transactions are complete");
                }
            }
            else
            {
                MessageBox.Show("There still items not yet released cannot complete the transactions");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (OrderId > 0)
            {
                txtorderid.Text = OrderId.ToString();
            }
            else
            {
                OrderId = Convert.ToInt16(txtorderid.Text);
            }
            List<ProductReleases> trx = new List<ProductReleases>();
            trx = _release.ProductReleaseSelect(OrderId).ToList();
            Report.RelasedFrm frm = new Report.RelasedFrm();
            frm.trx = trx;
            frm.Show();
        }
    }
}
