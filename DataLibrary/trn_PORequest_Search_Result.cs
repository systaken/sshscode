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
    
    public partial class trn_PORequest_Search_Result
    {
        public int po_id { get; set; }
        public string poRef { get; set; }
        public Nullable<double> TotalAmount { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> Createdby { get; set; }
        public Nullable<bool> isCompleted { get; set; }
        public string status { get; set; }
    }
}
