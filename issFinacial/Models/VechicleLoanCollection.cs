using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issFinacial.Models
{
    public class VechicleLoanCollection
    {
        public int Id { get; set; }
        public DateTime? CollectionDate { get; set; }
        public string PaymentType { get; set; }
        public int vehicleLoanId { get; set; }
        public virtual VehicleLoanEntry vehicleLoan { get; set; }
       
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string VehicleName { get; set; }
        public string VechicleNumber { get; set; }
        public string VehicleMake { get; set; }
        public string NumberOfInstallments { get; set; }
        public string SelectDueNumber { get; set; }
        public DateTime? DueDate { get; set; }
        public float PrincipleAmount { get; set; }
        public float IntrestAmount { get; set; }
        public float DueAmount { get; set; }
        public float TotalAmount { get; set; }
        public DateTime? LateDays { get; set; }
        public float LateDaysAmount { get; set; }
        public string Penalty { get; set; }
        public float Discount { get; set; }
        public float NetAmount { get; set; }
    }
}