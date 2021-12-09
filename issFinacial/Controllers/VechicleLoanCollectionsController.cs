using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using issFinacial.Models;

namespace issFinacial.Controllers
{
    public class VechicleLoanCollectionsController : Controller
    {
        private issModel db = new issModel();

        // GET: VechicleLoanCollections
        public ActionResult Index()
        {
            return View(db.VechicleLoanCollection.ToList());
        }

        // GET: VechicleLoanCollections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VechicleLoanCollection vechicleLoanCollection = db.VechicleLoanCollection.Find(id);
            if (vechicleLoanCollection == null)
            {
                return HttpNotFound();
            }
            return View(vechicleLoanCollection);
        }

        // GET: VechicleLoanCollections/Create
        public ActionResult Create()
        {
            ViewBag.VehicleLoanId = new SelectList(db.VehicleLoanEntries, "id", "id");
            return View();
        }

        // POST: VechicleLoanCollections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CollectionDate,PaymentType,vehicleLoanId,LoanNumber,vehicleNo,Name,Address,PhoneNo,VehicleName,VechicleNumber,VehicleMake,NumberOfInstallments,SelectDueNumber,DueDate,PrincipleAmount,IntrestAmount,TotalAmount,LateDays,LateDaysAmount,Penalty,Discount,NetAmount")] VechicleLoanCollection vechicleLoanCollection)
        {
            if (ModelState.IsValid)
            {
                db.VechicleLoanCollection.Add(vechicleLoanCollection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleLoanId = new SelectList(db.VehicleLoanEntries, "id", "id", vechicleLoanCollection.vehicleLoanId);
            return View(vechicleLoanCollection);
        }
        [HttpPost]
        public JsonResult Name(int NAME)
        {
            if (NAME > 0)
            {
                var resp = db.VehicleLoanEntries.Where(x => x.id == NAME).ToList();
                return Json(resp, JsonRequestBehavior.AllowGet);
            }
            else return Json("NoData", JsonRequestBehavior.AllowGet);
        }
        // GET: VechicleLoanCollections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VechicleLoanCollection vechicleLoanCollection = db.VechicleLoanCollection.Find(id);
            if (vechicleLoanCollection == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleLoanId = new SelectList(db.VehicleLoanEntries, "id", "id", vechicleLoanCollection.vehicleLoanId);

            return View(vechicleLoanCollection);
        }

        // POST: VechicleLoanCollections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CollectionDate,PaymentType,LoanNumber,Name,vehicleLoanId,Address,PhoneNo,VehicleName,VechicleNumber,VehicleMake,NumberOfInstallments,SelectDueNumber,DueDate,PrincipleAmount,IntrestAmount,TotalAmount,LateDays,LateDaysAmount,Penalty,Discount,NetAmount")] VechicleLoanCollection vechicleLoanCollection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vechicleLoanCollection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleLoanId = new SelectList(db.VehicleLoanEntries, "id", "id", vechicleLoanCollection.vehicleLoanId);

            return View(vechicleLoanCollection);
        }

        // GET: VechicleLoanCollections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VechicleLoanCollection vechicleLoanCollection = db.VechicleLoanCollection.Find(id);
            if (vechicleLoanCollection == null)
            {
                return HttpNotFound();
            }
            return View(vechicleLoanCollection);
        }

        // POST: VechicleLoanCollections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VechicleLoanCollection vechicleLoanCollection = db.VechicleLoanCollection.Find(id);
            db.VechicleLoanCollection.Remove(vechicleLoanCollection);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
