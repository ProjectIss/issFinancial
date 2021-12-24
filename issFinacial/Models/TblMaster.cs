using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issFinacial.Models
{
    public class TblMaster
    {
        public int id { get; set; } //vechicle loan entry-loan numberID
        public DateTime EntryDate { get; set; } //vechicle loan entry--loan Entry date
        public string PaymentType { get; set; } //vechicle loan collection--payment type
        public int AccountID { get; set; } // loan account id
        public int GroupID { get; set; }   //loans under the group
        public string Description { get; set; }  //vechicle loan entry--customer name
        public int Expenses { get; set; }  //vechicle loan entry--loan amount
        public int Income { get; set; }  //0
        public string UGroup { get; set; } // Account group--parent group
        public string Type { get; set; }  //loan
        public string FinancialYear { get; set; } //2020-2021
        public string CompanyName { get; set; }  //Insurance Company-companyname
        public string User { get; set; } //which user
        public DateTime? EntryTime { get; set; }
        public DateTime? DeleteTime { get; set; }
    }
}