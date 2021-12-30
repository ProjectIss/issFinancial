using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using issFinacial.Models;

namespace issFinacial.Controllers
{
    public class ReportController : Controller
    {
        private issModel db = new issModel();
        // GET: Report
        public ActionResult InstallmentSchedule()
        {
            List<SelectListItem> supplier = new List<SelectListItem>();
            foreach (var item in db.VehicleLoanEntries.ToList())
            {
                supplier.Add(new SelectListItem { Text = item.id.ToString(), Value = item.id.ToString() });

            }
            ViewBag.customer = supplier; 

            List<SelectListItem> phoneNo = new List<SelectListItem>();
            foreach (var item in db.VehicleLoanEntries.ToList())
            {
                phoneNo.Add(new SelectListItem { Text = item.phoneNo, Value = item.phoneNo });

            }
            ViewBag.customers = phoneNo;
            return View();
        }
        [HttpPost]
        public JsonResult getloandetail(int? Id, string phoneNumbers)
        {
            try
            {
                if (phoneNumbers != null )
                {
                    var loanDetail = db.VehicleLoanEntries.Where(x => x.id == Id).FirstOrDefault();
                    var installment = db.Installments.Where(x => x.phoneNumbers == Id.ToString()).ToList();
                    var result = new { loanDetail, installment };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else if(Id != null)
                {
                    var loanDetail = db.VehicleLoanEntries.Where(x => x.id == Id).FirstOrDefault();
                    var installment = db.Installments.Where(x => x.loanNumber == Id).ToList();
                    var result = new { loanDetail, installment };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                return Json( JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);

            }
        }


    }
}