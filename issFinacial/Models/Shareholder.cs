using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issFinacial.Models
{
    public class Shareholder
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phoneNo { get; set; }
        public DateTime? date { get; set; }
        public string amount { get; set; }
    }
}