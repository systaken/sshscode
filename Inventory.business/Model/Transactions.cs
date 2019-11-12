using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.business.Model
{
    public class Transactions
    {
        public int sales_id { get; set; }
        public string referenceNo { get; set; }
        public Nullable<double> TotalAmount { get; set; }
        public Nullable<double> Discounted { get; set; }
        public Nullable<double> GrandTotal { get; set; }
        public Nullable<double> PayBalance { get; set; }
        public string status { get; set; }
        public Nullable<bool> isPaid { get; set; }
        public Nullable<bool> isVoided { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> dateUpdated { get; set; }
        public string processed_by { get; set; }
        public Nullable<double> AmountPaid { get; set; }
        public string TransactionType { get; set; }
        public string payterms { get; set; }
        public Nullable<int> nosofdays { get; set; }
    }
}
