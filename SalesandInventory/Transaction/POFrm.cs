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

namespace SalesandInventory.Transaction
{
    public partial class POFrm : Form
    {

        private Categorys _category = new Categorys();
        private Measures _measures = new Measures();
        private Products _product = new Products();
        private Purchase _pr = new Purchase();

        private PurchaseRequest po = new PurchaseRequest();
        private PurchaseItem pi = new PurchaseItem();
        public int cusid;

        ListViewItem itm;
        public POFrm()
        {
            InitializeComponent();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
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
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (ProdListV.SelectedItems.Count == 1)
            {
                int index = ProdListV.SelectedItems[0].Index;
                string rprice = ProdListV.SelectedItems[0].SubItems[8].Text;
                lbltotalamounts.Text = Subtraction(lbltotalamounts.Text, rprice).ToString();
                ProdListV.Items.RemoveAt(index);
            }
        }
        int x = 1;
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
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                //saving orders
                createPO();
                createItemPO();
                MessageBox.Show("Purchase Order has been created");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
        private void createPO()
        {
            po.poRef = lbltxnid.Text;
            po.Createdby = 0;
            po.DateCreated = DateTime.Now;
            po.isCompleted = false;
            po.status = "To Do";
            po.TotalAmount = Convert.ToDouble(lbltotalamounts.Text);
            _pr.Create(po);
        }
        private void createItemPO()
        {
            int POid = _pr.GetPOId(lbltxnid.Text);
            for (int i = 0; i < ProdListV.Items.Count; i++)
            {
                pi.po_id = POid;
                pi.product_id = Convert.ToInt32(ProdListV.Items[i].SubItems[9].Text);
                pi.QTY = Convert.ToInt16(ProdListV.Items[i].SubItems[7].Text);
                pi.Measurement = ProdListV.Items[i].SubItems[6].Text;
                pi.Purchaseprice = Convert.ToDouble(ProdListV.Items[i].SubItems[5].Text);
                pi.isCheckedIn = false;
                _pr.CreateItem(pi);
            }
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

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //TODO Void Order
            if (MessageBox.Show("Item will be cancelled", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int POid = _pr.GetPOId(lbltxnid.Text);

                if (POid.ToString() == "")
                {
                    this.Close();
                }
                else
                {
                    _pr.PurchaseRequest_Update_status(POid,false,"Cancelled");
                }
            }
        }
        private void POFrm_Load(object sender, EventArgs e)
        {
            loadProduct();
            lbltxnid.Text = DateTime.Now.ToString("PO-0MddyyHmmss");
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
                    lblprice.Text = "0.00";
                }
            }
            else
            {
                lblprice.Text = "0.00";
                lblmeasure.Text = "";
                lbltotalprice.Text = "0.00";
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

        private void lblprice_TextChanged(object sender, EventArgs e)
        {
            double total = 0.0;
            if (lblprice.Text != string.Empty)
            {
                total = Convert.ToDouble(lblprice.Text) * Convert.ToDouble(txtqty.Text);
                lbltotalprice.Text = total.ToString();
            }
            else
            {
                lbltotalprice.Text = "0.00";
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
