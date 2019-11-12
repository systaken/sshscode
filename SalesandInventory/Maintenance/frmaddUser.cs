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
using Inventory.business.Model;
using Inventory.business.Security;
namespace Maintenance
{
    public partial class frmaddUser : Form
    {

        User lg = new User();
        private UsersRole usr = new UsersRole();
        public frmaddUser()
        {
            InitializeComponent();
        }

        private void frmaddUser_Load(object sender, EventArgs e)
        {
        }
        private void btnSave_Click(object sender, EventArgs e)
        { 
            if(txtpwd.Text == txtrepass.Text)
            {

                usr.username = txtuser.Text;
                usr.password = txtpwd.Text;
                usr.Fullname = txtlname.Text + ", " + txtfname.Text;
                usr.position = comboBox1.SelectedText;
                usr.isActive = true;

                if (lg.addUser(usr) == true)           
                {
                        cleardata();
                        MessageBox.Show("User has been added.","Confirmation"); 
                }
                else
                {
                        MessageBox.Show(lg._err.ToString(),"Failed");
                }
            }
            else
            {
                MessageBox.Show("Password did not match.","Warning"); 
            }
        }
        private void cleardata()
        {
            txtuser.Text = "";
            txtrepass.Text = "";
            txtpwd.Text = "";
            txtlname.Text = "";
            txtfname.Text = "";
        }
    }
}
