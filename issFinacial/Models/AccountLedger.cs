using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issFinacial.Models
{
    public class AccountLedger
    {
        public int id { get; set; }
        public string AccountName { get; set; }
        public int accountgroupId { get; set; }
        public virtual AccountGroup AccountGroup { get; set; }
        public string openingBalance { get; set; }
        public string type { get; set; }
        public string GroupName { get; set; }
    }
}