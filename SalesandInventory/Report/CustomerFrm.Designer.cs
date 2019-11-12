namespace SalesandInventory.Report
{
    partial class CustomerFrm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sbtnGen = new System.Windows.Forms.Button();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sbtnGen);
            this.splitContainer1.Panel1.Controls.Add(this.dtto);
            this.splitContainer1.Panel1.Controls.Add(this.dtfrom);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(1139, 735);
            this.splitContainer1.SplitterDistance = 130;
            this.splitContainer1.TabIndex = 1;
            // 
            // sbtnGen
            // 
            this.sbtnGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbtnGen.Location = new System.Drawing.Point(258, 88);
            this.sbtnGen.Name = "sbtnGen";
            this.sbtnGen.Size = new System.Drawing.Size(128, 37);
            this.sbtnGen.TabIndex = 11;
            this.sbtnGen.Text = "Generate";
            this.sbtnGen.UseVisualStyleBackColor = true;
            this.sbtnGen.Click += new System.EventHandler(this.sbtnGen_Click);
            // 
            // dtto
            // 
            this.dtto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtto.Location = new System.Drawing.Point(402, 56);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(128, 26);
            this.dtto.TabIndex = 10;
            // 
            // dtfrom
            // 
            this.dtfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfrom.Location = new System.Drawing.Point(258, 56);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(128, 26);
            this.dtfrom.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(94, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date Created";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "ReportViewer";
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // CustomerFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 735);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CustomerFrm";
            this.Text = "Customer Report";
            this.Load += new System.EventHandler(this.CustomerFrm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button sbtnGen;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private System.Windows.Forms.Label label3;
 
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}