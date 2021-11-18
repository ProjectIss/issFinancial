using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issFinacial.Models
{
    public class VoucherEntry
    {
        public VoucherEntry()
        {
            AccountLedgers = new HashSet<AccountLedger>();

        }
        public int id { get; set; }
        public virtual ICollection<AccountLedger> AccountLedgers { get; set; }
        public string No { get; set; }
        public string name { get; set; }
        public DateTime? date { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string amount { get; set; }
      
    }
}