//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLibrary
{
    using System;
    
    public partial class trn_transactionsales_product_details_select_Result
    {
        public int sales_detail_id { get; set; }
        public string productcode { get; set; }
        public Nullable<int> sales_id { get; set; }
        public Nullable<int> product_id { get; set; }
        public Nullable<double> RetailPrice { get; set; }
        public Nullable<int> QTY { get; set; }
        public Nullable<double> TotalAmount { get; set; }
        public Nullable<bool> isCheckedout { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
    }
}