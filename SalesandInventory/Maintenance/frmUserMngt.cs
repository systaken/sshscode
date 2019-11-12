using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using Inventory.business.Configs;
using Inventory.business.Security;
using Inventory.business.Model;
namespace Maintenance
{
    public partial class frmUserMngt : Form
    {
        User lg =  new User();
        public frmUserMngt()
        {
            InitializeComponent();
        }

        private void frmUserMngt_Load(object sender, EventArgs e)
        {
            loadUsers();
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            frmaddUser aduser = new frmaddUser();
            aduser.ShowDialog();
            loadUsers();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.MemListsV.SelectedItems.Count > 0)
            {
                //delete
                int id = Convert.ToInt32(this.MemListsV.SelectedItems[0].Text);
                if (lg.Delete(id) == true)
                {
                    MessageBox.Show("Record has been deleted.","Confirmation");
                    loadUsers();
                }
                else
                {
                    MessageBox.Show(lg._err.ToString(),"Warning"); 
                }
            }
            else
            {
                MessageBox.Show("There is no item selected.", "Warning");
            }
        }

        private void loadUsers()
        {
            List<UsersRole> dt = new List<UsersRole>();
            ListViewItem itm;
            MemListsV.Items.Clear();
            string isActive;
            dt = lg.LoadUsers();
           
            foreach (UsersRole drow in dt)
            {
                itm = new ListViewItem();
                itm.Text = drow.userid.ToString();
                itm.SubItems.Add(drow.username.ToString());
                itm.SubItems.Add(drow.Fullname.ToString());
                if (drow.isActive.ToString() == "1")
                { 
                    isActive = "Active";
                }
                else
                {
                    isActive = "In-Active";
                }
                itm.SubItems.Add(isActive);
                itm.SubItems.Add(drow.position.ToString());

                this.MemListsV.Items.Add(itm);
            }
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            loadUsers();
        }
    }
}
