using System;
using System.Collections.Generic;

namespace issFinacial.Models
{
    public class ReceiptEntry
    {

        public ReceiptEntry()
        {
            AccountLedgers = new HashSet<AccountLedger>();

        }
        public string No { get; set; }
        public DateTime? date { get; set; }
        public string type { get; set; }
        public virtual ICollection<AccountLedger> AccountLedgers { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string amount { get; set; }
        public string description { get; set; }
    }
}