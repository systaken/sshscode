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
using Inventory.business.Logs;

namespace SalesandInventory.Product
{
    public partial class SupplierListFrm : Form
    {
        private Suppliers _supplier = new Suppliers();
        private Loggers lg = new Loggers();
        private AuditLogs a = new AuditLogs();
        public SupplierListFrm()
        {
            InitializeComponent();
        }

        private void SupplierListFrm_Load(object sender, EventArgs e)
        {
            loadInformation();
        }
        private void loadInformation()
        {
            ProdListV.Refresh();
            ProdListV.Items.Clear();
            ListViewItem itm;
            var its = _supplier.SelectAll();
            foreach (supplier pr in its)
            {
                itm = new ListViewItem();
                itm.Text = pr.supplier_id.ToString();
                itm.SubItems.Add(pr.Supplier_name);
                itm.SubItems.Add(pr.Supplier_address);
                itm.SubItems.Add(pr.Supplier_contact);
                this.ProdListV.Items.Add(itm);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Record will be removed", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(this.ProdListV.SelectedItems[0].Text);
                _supplier.Delete(id);
                MessageBox.Show("Record has been deleted.");
            }
            else
            {
                MessageBox.Show("Please select item first.");
            }
            loadInformation();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.ProdListV.SelectedItems.Count > 0)
            {
                Product.SupplierFrm nform = new Product.SupplierFrm();
                nform.Id = Convert.ToInt32(this.ProdListV.SelectedItems[0].Text);
                nform.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select item first.");
            }
            loadInformation();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            loadInformation();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Product.SupplierFrm nform = new Product.SupplierFrm();
            nform.ShowDialog();
            loadInformation();
        }
    }
}
