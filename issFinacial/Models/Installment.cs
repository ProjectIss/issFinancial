using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issFinacial.Models
{
    public class Installment
    {
        public int id { get; set; }
        public int  loanNumber { get; set; }
        public string DueDate { get; set; }
        public string dueStatus { get; set; }
        public string dueAmount{ get; set; }
        public string Intrest { get; set; }
        public string numberofDue { get; set; }

        public string totalAmount { get; set; }
        public string loanAmount { get; set; }
        public string phoneNumbers{ get; set; }

    }
}