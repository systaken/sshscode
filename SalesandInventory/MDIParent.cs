using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SalesandInventory
{
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;

        public string userid;
        public string position;
        public MDIParent()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Transaction.OrderFrm childForm = new Transaction.OrderFrm();
            childForm.MdiParent = this;
            childForm.Text = "Ordering";
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction.POFrm childForm = new Transaction.POFrm();
            childForm.MdiParent = this;
            childForm.Show();
        }

     
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product.ProductFrm ChildFrm = new Product.ProductFrm();
            ChildFrm.MdiParent = this;
            ChildFrm.Show();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product.ProductListing ChildFrm = new Product.ProductListing();
            ChildFrm.MdiParent = this;
            ChildFrm.Show();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Maintenance.frmUserMngt ChildFrm = new Maintenance.frmUserMngt();
            ChildFrm.MdiParent = this;
            ChildFrm.Show();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction.OrderListsFRM ChildFrm = new Transaction.OrderListsFRM();
            ChildFrm.MdiParent = this;
            ChildFrm.Show();
        }

        private void pOListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction.POListFrm ChildFrm = new Transaction.POListFrm();
            ChildFrm.MdiParent = this;
            ChildFrm.Show();
        }

        private void customersOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.CustomerFrm ChildFrm = new Report.CustomerFrm();
            ChildFrm.MdiParent = this;
            ChildFrm.Show();
        }
        private void checkWriterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.MdiParent = this;
            fm.Show();
        }
        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.SalesReport ChildFrm = new Report.SalesReport();
            ChildFrm.MdiParent = this;
            ChildFrm.Show();
        }

        private void checkedInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.CheckedinReport ChildFrm = new Report.CheckedinReport();
            ChildFrm.MdiParent = this;
            ChildFrm.Show();
        }

        private void releasedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.ReleaseReport ChildFrm = new Report.ReleaseReport();
            ChildFrm.MdiParent = this;
            ChildFrm.Show();
        }

        private void MDIParent_Load(object sender, EventArgs e)
        {
            AccessApplication();
        }

        private void AccessApplication()
        {
            if (position == "Admin")
            {
                editMenu.Visible = true;
                viewMenu.Visible = true;
                toolsMenu.Visible = true;
                userManagementToolStripMenuItem.Visible = true;
                checkWriterToolStripMenuItem.Visible = true;
            }
            if (position == "Cashier")
            {
                fileMenu.Visible = true;
                viewMenu.Visible = true;
                toolsMenu.Visible = false;
                userManagementToolStripMenuItem.Visible = false;
                checkWriterToolStripMenuItem.Visible = false;
            }
            if (position == "Warehouse")
            {
                toolsMenu.Visible = false;
                userManagementToolStripMenuItem.Visible = false;
                checkWriterToolStripMenuItem.Visible = false;
                undoToolStripMenuItem.Visible = false;
                newToolStripMenuItem.Visible = false;
            }
            if (position == "Super Admin")
            {
                editMenu.Visible = true;
                viewMenu.Visible = true;
                toolsMenu.Visible = true;
                userManagementToolStripMenuItem.Visible = true;
                checkWriterToolStripMenuItem.Visible = true;
            }
        }

        private void MDIParent_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product.CategoryFrm ChildFrm = new Product.CategoryFrm();
            ChildFrm.MdiParent = this;
            ChildFrm.Show();
        }
    }
}
