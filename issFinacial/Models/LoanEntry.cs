using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issFinacial.Models
{
    public class LoanEntry
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; } 
        public string fatherName { get; set; }
        public string address { get; set; }
        public string areaName { get; set; }
        public string identityproof { get; set; }
        public string type { get; set; }
        public DateTime? loanDate { get; set; }
        public string billNo { get; set; }
        public string sNo { get; set; }
        public string itemName { get; set; }
        public string itemType { get; set; }
        public string gramValue { get; set; }
        public string queality { get; set; }
        public string grossWeight { get; set; }
        public string netWeight { get; set; }
        public string itemValue { get; set; }
        public string totalGrams { get; set; }
        public string value { get; set; }
        public string principle { get; set; }
        public string intrest { get; set; }
        public string intrestAmount { get; set; }
        public string deducation { get; set; }

    }
}