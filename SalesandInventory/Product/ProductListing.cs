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
using System.Data.Objects;

namespace SalesandInventory.Product
{
    public partial class ProductListing : Form
    {

        private product pr;
        private Products _product = new Products();
        private int isPrint = 0;
        private List<product> pidtem = new List<product>();
        public ProductListing()
        {
            InitializeComponent();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            loadInformation();
        }

        private void loadInformation()
        {

            ProdListV.Items.Clear();
            ListViewItem itm;
            List<product> its = _product.SelectAll();
            string isActive;
            foreach(product pr in its)
            { 
                itm = new ListViewItem();
                itm.Text = pr.product_id.ToString();
                itm.SubItems.Add(pr.Barcode);
                itm.SubItems.Add(pr.ProductCode);
                itm.SubItems.Add(pr.ProductName);
                itm.SubItems.Add(pr.ProductDescription);
                itm.SubItems.Add(pr.measurement);
                itm.SubItems.Add(pr.QTY.ToString());
                itm.SubItems.Add(pr.criticalQTY.ToString());
                itm.SubItems.Add(pr.Expirydate.ToString());
                itm.SubItems.Add(pr.supplierprice.ToString());
                itm.SubItems.Add(pr.retailprice.ToString());
                if (pr.isActive == true)
                {

                    isActive = "Active";
                }
                else
                {
                    isActive = "Inactive";
                }
                itm.SubItems.Add(isActive);
                this.ProdListV.Items.Add(itm);
            }
            isPrint = 1;
        }

        private void ProductListing_Load(object sender, EventArgs e)
        {
            loadInformation();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Product.ProductFrm nform = new Product.ProductFrm();
            nform._isEdit = false;
            nform.ShowDialog();
            loadInformation();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.ProdListV.SelectedItems.Count > 0)
            {
                Product.ProductFrm nform = new Product.ProductFrm();
                nform.Id = Convert.ToInt32(this.ProdListV.SelectedItems[0].Text);
                nform._isEdit = true;
                nform.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select item first.");
            }
        }

        private void sbtnGen_Click(object sender, EventArgs e)
        {
            isPrint = 2;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            List<ProductResult> trx = new List<ProductResult>();
            trx = _product.SelectReport();
            Report.StockFrm frm = new Report.StockFrm();
            frm.trx = trx;
            frm.Show();
        }
    }
}
