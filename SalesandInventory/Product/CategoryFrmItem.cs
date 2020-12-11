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
    public partial class CategoryFrmItem : Form
    {
        private Categorys _category = new Categorys();
        private Loggers lg = new Loggers();
        private AuditLogs a = new AuditLogs();
        public int Id { get; set; }
        public CategoryFrmItem()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblcatid.Text != "")
                {
                   
                    UpdateRecord();
                }
                else
                {
                    Insert();
                }
                MessageBox.Show("Record has been saved.");
            }
            catch (Exception ex)
            {
                a.logModule = "Category Entry";
                a.logError = ex.ToString();
                a.DateCreated = DateTime.Now;
                lg.InsertLog(a);
                MessageBox.Show("No Record created data must be wrong please try again.");
            }
            this.Close();
        }
        private void Insert()
        {
            Category r = new Category();
            r.categoryname = txtname.Text;
            _category.Create(r);
        }

        private void UpdateRecord()
        {
            int id = Convert.ToInt32(lblcatid.Text);
            Category r = new Category();
            r.categoryname = txtname.Text;
            r.category_id = id;
            _category.Update(r);
        }
        private void CategoryFrmItem_Load(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                lblcatid.Text = Id.ToString();
            }
            else
            {
                lblcatid.Text = string.Empty;
            }

            if (lblcatid.Text != string.Empty)
            {
                int id = Convert.ToInt32(lblcatid.Text);
                loadCategory(id);
            }
        }

        private void loadCategory(int id)
        {
            Category dts = _category.SelectById(id);
            txtname.Text = dts.categoryname;
            lblcatid.Text = dts.category_id.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
