﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issFinacial.Models
{
    public class Installment
    {
        public int id { get; set; }
        public string  loanNumber { get; set; }
        public string DueDate { get; set; }
        public string dueStatus { get; set; }
        public string dueAmount{ get; set; }
        public string Intrest { get; set; }
        public string numberofDue { get; set; }

    }
}