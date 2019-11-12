using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.business.Model
{
    public class UsersRole
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string Fullname { get; set; }
        public string position{ get; set; }
    }
}
