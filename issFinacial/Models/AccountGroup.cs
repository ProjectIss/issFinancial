using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issFinacial.Models
{
    public class AccountGroup
    {
        public int id { get; set; }
        public string accountGroup { get; set; }
        public string parentGroup { get; set; }
    }
}