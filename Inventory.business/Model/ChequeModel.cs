using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.business.Model
{
    public class ChequeModel
    {
        public string PayOrderTo { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string AmountInwords { get; set; }
    }
}
