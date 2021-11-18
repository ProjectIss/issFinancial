using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issFinacial.Models
{
    public class AccountLedger
    {
        public int id { get; set; }
        public string ledger { get; set; }
        
        public int accountgroupId { get; set; }
        public virtual AccountGrouping AccountGroup { get; set; }
        public string openingBalance { get; set; }
        public string type { get; set; }
    }
}