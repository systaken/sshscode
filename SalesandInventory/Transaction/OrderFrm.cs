using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventory.business.Model;
using Inventory.business.Configs;
using Inventory.business.Transaction;
using Inventory.business.Logs;
namespace SalesandInventory.Transaction
{
    public partial class OrderFrm : Form
    {
        private Categorys _category = new Categorys();
        private Measures _measures = new Measures();
        private Products _product = new Products();
        private Sales _trn = new Sales();
        private SalesDetail _trnd = new SalesDetail();
        public int cusid;
        ListViewItem itm;
        private Loggers lg = new Loggers();
        private AuditLogs a = new AuditLogs();
        public OrderFrm()
        {
            InitializeComponent();
        }

        private void OrderFrm_Load(object sender, EventArgs e)
        {
            loadProduct();
            lbltxnid.Text = DateTime.Now.ToString("0MddyyHmmss");

        }

        private void loadinformation(int salesId)
        {

        }

        private void loadProduct()
        {
            List<product> dtp = _product.SelectAll();
            cmbprod.Items.Clear();
            
            cmbprod.DisplayMember = "ProductName";
            cmbprod.ValueMember = "product_id";
            cmbprod.DataSource = dtp;
            cmbprod.SelectedIndex = -1;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Customer.CustomerFrm nform = new Customer.CustomerFrm();
            nform.ShowDialog(this);

            if (nform.Id.ToString() != "0")
            {
                lblcusid.Text = nform.Id.ToString();
                lblname.Text = nform.cusName.ToString();
            }
        }

        private void txtqty_TextChanged(object sender, EventArgs e)
        {
            double total = 0.0;
            if (txtqty.Text != string.Empty)
            {
                total = Convert.ToDouble(lblprice.Text) * Convert.ToDouble(txtqty.Text);
                lbltotalprice.Text = total.ToString();
            }
            else
            {
                lbltotalprice.Text = "0.00";
            }
        }

        private void cmbprod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbprod.SelectedIndex != -1)
            {
                if (cmbprod.Text != string.Empty)
                {
                    string id = cmbprod.SelectedValue.ToString();
                    ProductResult pr = new ProductResult();
                    pr = _product.SelectById(Convert.ToInt16(id));
                    lblmeasure.Text = pr.measurement;
                    lblprice.Text = pr.retailprice.ToString();

                }
            }
            else
            {
                lblprice.Text = "0.00";
                lblmeasure.Text = "";
                lbltotalprice.Text = "0.00";
            }
        }
        int x = 1;
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            ProductResult pr = new ProductResult();
            if (cmbprod.SelectedValue != null)
            {
                string id = cmbprod.SelectedValue.ToString();
                pr = _product.SelectById(Convert.ToInt16(id));
                addItem(pr);
                lbltotalamounts.Text = Addition(lbltotalamounts.Text, lbltotalprice.Text).ToString(); // (Convert.ToDouble(lblgrandtotal.Text) + Convert.ToDouble(lbltotalprice.Text)).ToString();
                cmbprod.SelectedIndex = -1;
                lblmeasure.Text = "";
                lblprice.Text = "0.00";
                lbltotalprice.Text = "0.00";
                txtqty.Text = "";
            }
            else
            {
                MessageBox.Show("Please select a product first.");
            }
        }
        private void addItem(ProductResult pr)
        {
            x = x + 1;
            itm = new ListViewItem();
            itm.Text = x.ToString();
            itm.SubItems.Add(pr.Barcode);
            itm.SubItems.Add(pr.ProductCode);
            itm.SubItems.Add(pr.ProductName);
            itm.SubItems.Add(pr.ProductDescription);
            itm.SubItems.Add(lblprice.Text);
            itm.SubItems.Add(lblmeasure.Text);
            itm.SubItems.Add(txtqty.Text);
            itm.SubItems.Add(lbltotalprice.Text);
            itm.SubItems.Add(cmbprod.SelectedValue.ToString());
            this.ProdListV.Items.Add(itm);
        }
        private void CreateHeader()
        {
                lbldate.Text = DateTime.Now.ToShortDateString();
                Transactions txn = new Transactions();
                txn.CustomerId = Convert.ToInt16(lblcusid.Text);
                txn.DateCreated = DateTime.Now;
                txn.GrandTotal = Convert.ToDouble(lblgrandtotal.Text);
                txn.referenceNo = lbltxnid.Text;
                txn.TotalAmount = Convert.ToDouble(lbltotalamounts.Text);
                txn.Discounted = Convert.ToDouble(txtdiscount.Text);
                txn.status = "Processed";
                txn.TransactionType = cmbType.Text;
                _trn.Create(txn);
        }

        private void CreateOrder()
        {
            Transactions txn = new Transactions();
            txn = _trn.SelectByRef(lbltxnid.Text);
            TransactionDetails txd = new TransactionDetails();
            for (int i = 0; i < ProdListV.Items.Count; i++)
            {
                txd.sales_id = txn.sales_id;
                txd.product_id = Convert.ToInt32(ProdListV.Items[i].SubItems[9].Text);
                txd.productcode = ProdListV.Items[i].SubItems[2].Text;
                txd.QTY = Convert.ToInt16(ProdListV.Items[i].SubItems[7].Text);
                txd.RetailPrice = Convert.ToDouble(ProdListV.Items[i].SubItems[5].Text);
                txd.TotalAmount = Convert.ToDouble(ProdListV.Items[i].SubItems[8].Text);
                txd.isCheckedout = false;
                _trnd.Create(txd);
            }
        }
        private void OrderFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Data will not be saved");
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (ProdListV.SelectedItems.Count == 1)
            {
                //lbleventid.Text = this.MemListsV.SelectedItems[0].Text;
                int index = ProdListV.SelectedItems[0].Index;
                string rprice = ProdListV.SelectedItems[0].SubItems[8].Text;
                lbltotalamounts.Text = Subtraction(lbltotalamounts.Text, rprice).ToString();
                ProdListV.Items.RemoveAt(index);
            }
            else {
                MessageBox.Show("Please select an item/s");
            }
        }
        private double Addition(string itm, string itm2)
        {
            double result = 0.00;
            result = Convert.ToDouble(itm) + Convert.ToDouble(itm2);
            return result;
        }
        private double Subtraction(string itm, string itm2)
        {
            double result = 0.00;
            result = Convert.ToDouble(itm) - Convert.ToDouble(itm2);
            return result;

        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStrip1.Enabled = false;
            btnUpdate.Visible = true;
            btnUpdate.Enabled = true;
            btncancel.Visible = true;
            btncancel.Enabled = true;
            if (ProdListV.SelectedItems.Count == 1)
            {
                int index = ProdListV.SelectedItems[0].Index;
                string rprice = ProdListV.SelectedItems[0].SubItems[8].Text;
                lbltotalamounts.Text = Subtraction(lbltotalamounts.Text, rprice).ToString();
                string pname = ProdListV.SelectedItems[0].SubItems[3].Text;
                cmbprod.Text = pname;
                lblmeasure.Text = ProdListV.SelectedItems[0].SubItems[6].Text;
                txtqty.Text = ProdListV.SelectedItems[0].SubItems[7].Text;
                ProdListV.Items.RemoveAt(index);
            }
            else {
                MessageBox.Show("Please select an item/s");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ProductResult pr = new ProductResult();
            string id = cmbprod.SelectedValue.ToString();
            pr = _product.SelectById(Convert.ToInt16(id));
            addItem(pr);
            lbltotalamounts.Text = Addition(lbltotalamounts.Text, lbltotalprice.Text).ToString(); // (Convert.ToDouble(lblgrandtotal.Text) + Convert.ToDouble(lbltotalprice.Text)).ToString();
            cmbprod.SelectedIndex = -1;
            lblmeasure.Text = "";
            lblprice.Text = "0.00";
            lbltotalprice.Text = "0.00";
            txtqty.Text = "";

            toolStrip1.Enabled = true;
            btnUpdate.Visible = false;
            btnUpdate.Enabled = false;
            btncancel.Visible = false;
            btncancel.Enabled = false;
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            ProductResult pr = new ProductResult();
            string id = cmbprod.SelectedValue.ToString();
            pr = _product.SelectById(Convert.ToInt16(id));
            addItem(pr);
            lbltotalamounts.Text = Addition(lbltotalamounts.Text, lbltotalprice.Text).ToString(); // (Convert.ToDouble(lblgrandtotal.Text) + Convert.ToDouble(lbltotalprice.Text)).ToString();
            cmbprod.SelectedIndex = -1;
            lblmeasure.Text = "";
            lblprice.Text = "0.00";
            lbltotalprice.Text = "0.00";
            txtqty.Text = "";

            toolStrip1.Enabled = true;
            btnUpdate.Visible = false;
            btnUpdate.Enabled = false;
            btncancel.Visible = false;
            btncancel.Enabled = false;
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (lblcusid.Text != string.Empty)
            {
                //saving orders
                CreateHeader();
                CreateOrder();
                ReceiptConfirmFrm frm = new ReceiptConfirmFrm();
                Transactions txn = _trn.SelectByRef(lbltxnid.Text);
                frm.sdate = lbldate.Text;
                frm.orderId = txn.sales_id.ToString();
                frm.totalamount = lbltotalamounts.Text;
                frm.discount = txtdiscount.Text;
                frm.gtotal = lblgrandtotal.Text;
                frm.status = "Processed";
                frm.txn = txn;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please enter or select a customer.");
            }
        }
        private void lbltotalamounts_TextChanged(object sender, EventArgs e)
        {
            lblgrandtotal.Text = (Convert.ToDouble(lbltotalamounts.Text) - Convert.ToDouble(txtdiscount.Text)).ToString();
        }

        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            lblgrandtotal.Text = (Convert.ToDouble(lbltotalamounts.Text) - Convert.ToDouble(txtdiscount.Text)).ToString();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Customer.CustomerListfrm nform = new Customer.CustomerListfrm();
            nform.ShowDialog(this);
            if (nform.Id.ToString() != string.Empty)
            {
                lblcusid.Text = nform.Id.ToString();
                lblname.Text = nform.cusName.ToString();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //TODO Void Order

            try
            {
                if (MessageBox.Show("Item will be cancelled", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CancelOrder();
                }
            }
            catch (Exception ex)
            {

                a.logModule = "Cancel Order : " + lbltxnid.Text;
                a.logError = ex.ToString();
                a.DateCreated = DateTime.Now;
                lg.InsertLog(a);
                MessageBox.Show("Nothing to cancel");
                this.Close();
            }
        }
        private void CancelOrder()
        {
            if (ProdListV.SelectedItems.Count == 1)
            {
                Transactions tx = new Transactions();
                tx = _trn.SelectByRef(lbltxnid.Text);
                Transactions txn = new Transactions();
                txn.sales_id = tx.sales_id;
                txn.status = "Cancelled";
                txn.isVoided = false;
                txn.processed_by = "";
                _trn.CancelOrder(txn);
            }
        }
    }
}
