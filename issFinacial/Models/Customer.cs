using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace issFinacial.Models
{
    public class Customer
    {
        public int id { get; set; }
        public int Age { get; set; }
        public String FatherName { get; set; }
        public string siNo { get; set; }
        public string customerNameTamil { get; set; }
        public string customerName { get; set; }
        public string customerRelation { get; set; }
        public string customerAddressTamil { get; set; }
        public string customerAddress { get; set; }
        public string permanantAddressTamil { get; set; }
        public string permanantAddress { get; set; }
        public string areaNameTamil { get; set; }
        public int areaNameEnglishId { get; set; }
        public virtual Area areaNameEnglish { get; set; }
        public string contactNo { get; set; }
        public string introduceName { get; set; }
        public string identityProof { get; set; }
        public string identityNumber { get; set; }
        public string customerType { get; set; }
        public string dateofJoin { get; set; }
        public string nomineeName { get; set; }
        public string nomineeAddress { get; set; }
        public string nomineeNumber { get; set; }
        public string starRate { get; set; }
        public string remark { get; set; }
        public string thump { get; set; }
        public string memberImage { get; set; }
        public string itemImage { get; set; }
        public string nomineeImage { get; set; }
        public string memberSignatureImage { get; set; }
        public string nomineeSignatureImage { get; set; }
    }
}