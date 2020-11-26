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
    public partial class ProductFrm : Form
    {
        //public int Id;
        public bool _isEdit;
        private product pr = new product();
        private Products _product = new Products();
        private Categorys _category = new Categorys();
        private Suppliers _suppliers = new Suppliers();
        private Measures _measures = new Measures();
        public int Id { get; set; }
        public ProductFrm()
        {
            InitializeComponent();
        }

        private void ProductFrm_Load(object sender, EventArgs e)
        {
            loadCategory();
            loadSupplier();
            loadmeasurement();

            if (Id > 0)
            {
                lblprodid.Text = Id.ToString();
            }
            else
            {
                lblprodid.Text = string.Empty;
            }

            if(lblprodid.Text != string.Empty)
            {   
                loadInformation(Convert.ToInt32(lblprodid.Text));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            pr.category_id = Convert.ToInt16(ddcategory.SelectedValue);
            pr.ProductCode = txtcode.Text;
            pr.ProductName = txtname.Text;
            pr.ProductDescription = txtdescription.Text;
            pr.Barcode = txtbarcode.Text;
            pr.measurement = ddmeasure.Text;
            pr.criticalQTY = Convert.ToInt16(txtCritical.Text);
            pr.Expirydate = Convert.ToDateTime(dtExpiry.Text);
            pr.supplier_id = Convert.ToInt16(ddSupplier.SelectedValue);
            pr.supplierprice = Convert.ToDouble(txtSupplier.Text);
            pr.retailprice = Convert.ToDouble(txtprice.Text);
            pr.unitWeight = cmbgrams.SelectedItem.ToString();
            pr.Weight = Convert.ToDouble(txtweight.Text);
            pr.updatedBy = 1;
            pr.isActive = true;
          
            if (_isEdit == false)
            {
                pr.dateCreated = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                var x = _product.Search(pr);
                if (x.Count > 0)
                {
                    MessageBox.Show("Record already exists");
                }
                else
                {
                    _product.Create(pr);
                    MessageBox.Show("Record has been created");
                }
            }
            else
            {
                pr.product_id = Convert.ToInt32(lblprodid.Text);
                _product.Update(pr);
                MessageBox.Show("Record has been updated");
            }
        }

        private void loadCategory()
        {
            var dts = _category.SelectAll();
            ddcategory.DataSource = dts;
            ddcategory.DisplayMember = "categoryname";
            ddcategory.ValueMember = "category_id";
        }

        private void loadSupplier()
        {
            var dt = _suppliers.SelectAll();
            ddSupplier.DataSource = dt;
            ddSupplier.DisplayMember = "Supplier_name";
            ddSupplier.ValueMember = "supplier_id";
        }


        private void loadmeasurement()
        {
            var dtm = _measures.SelectAll();
            ddmeasure.DataSource = dtm;
            ddmeasure.DisplayMember = "measurement";
            ddmeasure.ValueMember = "measure_id";
        }
        private void loadInformation(int id)
        {
            ProductResult pr = _product.SelectById(id);
            ddcategory.SelectedValue = pr.category_id;
            txtcode.Text = pr.ProductCode;
            txtname.Text = pr.ProductName;
            txtdescription.Text = pr.ProductDescription;
            txtbarcode.Text = pr.Barcode;
            ddmeasure.SelectedText = pr.measurement;
            txtQTY.Text = pr.QTY.ToString();
            txtCritical.Text = pr.criticalQTY.ToString();
            dtExpiry.Text = pr.Expirydate.ToString();
            ddSupplier.SelectedValue = pr.supplier_id;
            txtSupplier.Text = pr.supplierprice.ToString();
            txtprice.Text = pr.retailprice.ToString();
            txtweight.Text = pr.Weight.ToString();
            cmbgrams.SelectedItem = pr.unitWeight.ToString();
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
