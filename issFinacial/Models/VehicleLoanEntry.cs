using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issFinacial.Models
{
    public class VehicleLoanEntry
    {
        public int id { get; set; }
        public int shareHolderId { get; set; }
        public virtual Shareholder shareHoldere { get; set; }
        public int customerId { get; set; }
        public virtual Customer Customer { get; set; }


        public int customerNameId { get; set; }
        public virtual Customer customerName { get; set; }
        public string fatherName { get; set; }
        public string address { get; set; }
        public string phoneNo { get; set; }
        public string age { get; set; }
        public int agentId { get; set; }
        public virtual Agent agent { get; set; }
        public string agentName { get; set; }
        public string conductPerson { get; set; }
        public int brokerId { get; set; }
        public virtual Broker broker { get; set; }
        public int brokerNameId { get; set; }
        public virtual Broker brokerName { get; set; }
        public string brokerAddress { get; set; }
        public string brokerPhoneNo { get; set; }
        public int areaId { get; set; }
        public virtual Area area { get; set; }
        public string areaName { get; set; }
        public string guardianName { get; set; }
        public string guardianAddress { get; set; }
        public string guardianPhoneNo { get; set; }
        public DateTime? dateofAgreement { get; set; }
        public DateTime? dateOfDue { get; set; }
        public string advanceEmi { get; set; }

        public string paymentMode { get; set; }
        public string checkNo { get; set; }
        public string amountOfLoan { get; set; }
        public string rateOfIntrestperentage { get; set; }
        public string numberOfInstallments { get; set; }
        public string amountOfIntrest { get; set; }
        public string totalDueAmount { get; set; }
        public string dueAmount { get; set; }
        public string documentAmount { get; set; }
        public string commisionAmount { get; set; }
        public int InsuranceId { get; set; }
        public virtual InsuranceCompany Insurance { get; set; }
        public string policyNo { get; set; }
        public string policyAmount { get; set; }
        public string premiumAmount { get; set; }
        public DateTime? insuredNo { get; set; }
        public DateTime? insureExpiryOn { get; set; }
        public string policyReceived { get; set; }
        public string vehicleNo { get; set; }
        public string engineNo { get; set; }
        public string chaseNo { get; set; }
        public string registeredAt { get; set; }
        public DateTime? registeredDate { get; set; }
        public string rtoOfficeRefNO { get; set; }
        public DateTime? endosmentOn { get; set; }
        public string documentWith { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicle vehicle { get; set; }
        public string vehicleName { get; set; }
        public string vehicleColor { get; set; }
        public string endosmentDone { get; set; }
        public string duplicateKeyRecd { get; set; }
        public string policyCircle { get; set; }
        public string vehicleType { get; set; }

        public DateTime? taxExpiryDate { get; set; }
        public DateTime? permitExpiryDate { get; set; }

        public DateTime? fcExpiryDate { get; set; }

        public DateTime? insuranceExpityDate { get; set; }
        public int typeOfLoan { get; set; }


    }
}