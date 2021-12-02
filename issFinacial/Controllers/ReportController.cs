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
            //supplier.Add(new SelectListItem { Text = "", Value = "0" });
            foreach (var item in db.VehicleLoanEntries.ToList())
            {
                supplier.Add(new SelectListItem { Text = item.id.ToString(), Value = item.id.ToString() });

            }
            ViewBag.customers = supplier;
            return View();
        }
        [HttpPost]
        public JsonResult getloandetail(int? Id)
        {
            try
            {
                var loanDetail = db.VehicleLoanEntries.Where(x => x.id == Id).FirstOrDefault();
                var installment = db.Installments.Where(x => x.loanNumber == Id.ToString()).ToList();
                var result = new { loanDetail, installment };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);

            }
        }


    }
}