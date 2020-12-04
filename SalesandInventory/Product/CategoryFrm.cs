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
    public partial class CategoryFrm : Form
    {
        private Categorys _category = new Categorys();
        private Loggers lg = new Loggers();
        private AuditLogs a = new AuditLogs();
        public CategoryFrm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Product.CategoryFrmItem nform = new Product.CategoryFrmItem();
            nform.ShowDialog();
            loadInformation();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.ProdListV.SelectedItems.Count > 0)
            {
                Product.CategoryFrmItem nform = new Product.CategoryFrmItem();
                nform.Id = Convert.ToInt32(this.ProdListV.SelectedItems[0].Text);
                nform.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select item first.");
            }
        }

        private void CategoryFrm_Load(object sender, EventArgs e)
        {
            loadInformation();
        }

        private void loadInformation()
        {

            ProdListV.Items.Clear();
            ListViewItem itm;
            var its = _category.SelectAll();
            foreach (Category pr in its)
            {
                itm = new ListViewItem();
                itm.Text = pr.category_id.ToString();
                itm.SubItems.Add(pr.categoryname);
                this.ProdListV.Items.Add(itm);
            }
        }
    }
}
