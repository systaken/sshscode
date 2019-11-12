using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLibrary;
namespace Inventory.business.Model
{
    public class product
    {
        public int product_id { get; set; }
        public Nullable<int> category_id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Barcode { get; set; }
        public string measurement { get; set; }
        public Nullable<double> supplierprice { get; set; }
        public Nullable<double> retailprice { get; set; }
        public Nullable<int> QTY { get; set; }
        public Nullable<bool> isDelete { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<System.DateTime> dateCreated { get; set; }
        public Nullable<int> updatedBy { get; set; }
        public Nullable<System.DateTime> dateUpdated { get; set; }
        public Nullable<int> criticalQTY { get; set; }
        public Nullable<System.DateTime> Expirydate { get; set; }
        public Nullable<int> supplier_id { get; set; }
        public string unitWeight { get; set; }
        public Nullable<double> Weight { get; set; }
    }
}
