using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace issFinacial.Models
{
    public class issModel : DbContext
    {
        public issModel() : base("name=issModel")
        { }

        public System.Data.Entity.DbSet<issFinacial.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<issFinacial.Models.ItemMaster> ItemMasters { get; set; }

        public System.Data.Entity.DbSet<issFinacial.Models.GramRate> GramRates { get; set; }

        public System.Data.Entity.DbSet<issFinacial.Models.Vehicle> Vehicles { get; set; }

        public System.Data.Entity.DbSet<issFinacial.Models.Agent> Agents { get; set; }

        public System.Data.Entity.DbSet<issFinacial.Models.Area> Areas { get; set; }
        public System.Data.Entity.DbSet<issFinacial.Models.Installment> Installments { get; set; }

        public System.Data.Entity.DbSet<issFinacial.Models.InsuranceCompany> InsuranceCompanies { get; set; }

        public System.Data.Entity.DbSet<issFinacial.Models.AccountLedger> AccountLedgers { get; set; }

        public System.Data.Entity.DbSet<issFinacial.Models.AccountGrouping> AccountGroupings{ get; set; }
  

        public System.Data.Entity.DbSet<issFinacial.Models.LoanEntry> LoanEntries { get; set; }

        public System.Data.Entity.DbSet<issFinacial.Models.ReceiptEntry> ReceiptEntries { get; set; }

        public System.Data.Entity.DbSet<issFinacial.Models.VoucherEntry> VoucherEntries { get; set; }

        public System.Data.Entity.DbSet<issFinacial.Models.Shareholder> Shareholders { get; set; }

        public System.Data.Entity.DbSet<issFinacial.Models.VehicleLoanEntry> VehicleLoanEntries { get; set; }

        public System.Data.Entity.DbSet<issFinacial.Models.Broker> Brokers { get; set; }
    }
}