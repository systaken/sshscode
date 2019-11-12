namespace SalesandInventory.Transaction
{
    partial class POFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POFrm));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbprod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProdListV = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtqty = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lblprice = new System.Windows.Forms.TextBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblmeasure = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbltotalprice = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbltotalamounts = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbltxnid = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(348, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "QTY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(56, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Measurement";
            // 
            // cmbprod
            // 
            this.cmbprod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbprod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbprod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbprod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbprod.FormattingEnabled = true;
            this.cmbprod.Location = new System.Drawing.Point(193, 28);
            this.cmbprod.Name = "cmbprod";
            this.cmbprod.Size = new System.Drawing.Size(344, 28);
            this.cmbprod.TabIndex = 1;
            this.cmbprod.SelectedIndexChanged += new System.EventHandler(this.cmbprod_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Product Name";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Total Amount";
            this.columnHeader9.Width = 155;
            // 
            // ProdListV
            // 
            this.ProdListV.AllowColumnReorder = true;
            this.ProdListV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.ProdListV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProdListV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdListV.FullRowSelect = true;
            this.ProdListV.GridLines = true;
            this.ProdListV.Location = new System.Drawing.Point(0, 0);
            this.ProdListV.Margin = new System.Windows.Forms.Padding(4);
            this.ProdListV.MultiSelect = false;
            this.ProdListV.Name = "ProdListV";
            this.ProdListV.Size = new System.Drawing.Size(1439, 450);
            this.ProdListV.TabIndex = 2;
            this.ProdListV.TabStop = false;
            this.ProdListV.UseCompatibleStateImageBehavior = false;
            this.ProdListV.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 95;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Barcode";
            this.columnHeader2.Width = 108;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Code";
            this.columnHeader3.Width = 168;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 175;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Description";
            this.columnHeader5.Width = 169;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Price";
            this.columnHeader6.Width = 118;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Measurement";
            this.columnHeader7.Width = 174;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "QTY";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "PID";
            // 
            // txtqty
            // 
            this.txtqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtqty.Location = new System.Drawing.Point(433, 70);
            this.txtqty.Name = "txtqty";
            this.txtqty.Size = new System.Drawing.Size(100, 26);
            this.txtqty.TabIndex = 5;
            this.txtqty.TextChanged += new System.EventHandler(this.txtqty_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ProdListV);
            this.splitContainer1.Size = new System.Drawing.Size(1439, 640);
            this.splitContainer1.SplitterDistance = 186;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lblprice);
            this.splitContainer2.Panel1.Controls.Add(this.btncancel);
            this.splitContainer2.Panel1.Controls.Add(this.btnUpdate);
            this.splitContainer2.Panel1.Controls.Add(this.lblmeasure);
            this.splitContainer2.Panel1.Controls.Add(this.label10);
            this.splitContainer2.Panel1.Controls.Add(this.lbltotalprice);
            this.splitContainer2.Panel1.Controls.Add(this.label9);
            this.splitContainer2.Panel1.Controls.Add(this.txtqty);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.cmbprod);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer2.Panel2.Controls.Add(this.lbltotalamounts);
            this.splitContainer2.Panel2.Controls.Add(this.label12);
            this.splitContainer2.Panel2.Controls.Add(this.lbltxnid);
            this.splitContainer2.Panel2.Controls.Add(this.label11);
            this.splitContainer2.Size = new System.Drawing.Size(1439, 186);
            this.splitContainer2.SplitterDistance = 689;
            this.splitContainer2.TabIndex = 0;
            // 
            // lblprice
            // 
            this.lblprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprice.Location = new System.Drawing.Point(433, 107);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(100, 26);
            this.lblprice.TabIndex = 15;
            this.lblprice.Text = "0.00";
            this.lblprice.TextChanged += new System.EventHandler(this.lblprice_TextChanged);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.Transparent;
            this.btncancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btncancel.BackgroundImage")));
            this.btncancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btncancel.Enabled = false;
            this.btncancel.FlatAppearance.BorderSize = 0;
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Location = new System.Drawing.Point(284, 131);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(36, 34);
            this.btncancel.TabIndex = 14;
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Visible = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(224, 131);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(41, 34);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblmeasure
            // 
            this.lblmeasure.AutoSize = true;
            this.lblmeasure.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmeasure.Location = new System.Drawing.Point(189, 73);
            this.lblmeasure.Name = "lblmeasure";
            this.lblmeasure.Size = new System.Drawing.Size(40, 20);
            this.lblmeasure.TabIndex = 12;
            this.lblmeasure.Text = "0.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(348, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "Price";
            // 
            // lbltotalprice
            // 
            this.lbltotalprice.AutoSize = true;
            this.lbltotalprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalprice.Location = new System.Drawing.Point(433, 145);
            this.lbltotalprice.Name = "lbltotalprice";
            this.lbltotalprice.Size = new System.Drawing.Size(44, 20);
            this.lbltotalprice.TabIndex = 9;
            this.lbltotalprice.Text = "0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(348, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Total";
            // 
            // lbltotalamounts
            // 
            this.lbltotalamounts.AutoSize = true;
            this.lbltotalamounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalamounts.Location = new System.Drawing.Point(213, 59);
            this.lbltotalamounts.Name = "lbltotalamounts";
            this.lbltotalamounts.Size = new System.Drawing.Size(44, 20);
            this.lbltotalamounts.TabIndex = 11;
            this.lbltotalamounts.Text = "0.00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(74, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 20);
            this.label12.TabIndex = 10;
            this.label12.Text = "Total Amount";
            // 
            // lbltxnid
            // 
            this.lbltxnid.AutoSize = true;
            this.lbltxnid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltxnid.Location = new System.Drawing.Point(213, 28);
            this.lbltxnid.Name = "lbltxnid";
            this.lbltxnid.Size = new System.Drawing.Size(40, 20);
            this.lbltxnid.TabIndex = 9;
            this.lbltxnid.Text = "N/A";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(74, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 20);
            this.label11.TabIndex = 8;
            this.label11.Text = "Ref No:";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(99, 24);
            this.toolStripButton4.Text = "Create PO";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(100, 24);
            this.toolStripButton5.Text = "Cancel PO";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(101, 24);
            this.toolStripButton3.Text = "Edit Order";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(95, 24);
            this.toolStripButton6.Text = "Add Item";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(133, 24);
            this.toolStripButton7.Text = " Remove Order";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1439, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // POFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 667);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "POFrm";
            this.Text = "Purchase Order List";
            this.Load += new System.EventHandler(this.POFrm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbprod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ListView ProdListV;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.TextBox txtqty;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblmeasure;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbltotalprice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbltotalamounts;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbltxnid;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TextBox lblprice;
    }
}