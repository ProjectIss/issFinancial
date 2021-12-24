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
            ViewBag.SelectDueNumberId = new SelectList(db.Installments, "id", "numberofDue");

            ViewBag.VehicleLoanId = new SelectList(db.VehicleLoanEntries, "id", "id");
            return View();

        }

        // POST: VechicleLoanCollections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CollectionDate,NumberOfInstallmentsId,SelectDueNumberId,PaymentType,vehicleLoanId,LoanNumber,vehicleNo,Name,Address,PhoneNo,VehicleName,VechicleNumber,VehicleMake,NumberOfInstallments,SelectDueNumber,DueDate,PrincipleAmount,IntrestAmount,TotalAmount,LateDays,LateDaysAmount,Penalty,Discount,NetAmount,DueStatus")] VechicleLoanCollection vechicleLoanCollection)
        {
            if (ModelState.IsValid)
            {                
                db.VechicleLoanCollection.Add(vechicleLoanCollection);
                TblMaster tblMaster = new TblMaster();
                tblMaster.id = vechicleLoanCollection.Id;
                tblMaster.EntryDate = (DateTime)vechicleLoanCollection.CollectionDate;
                tblMaster.PaymentType = vechicleLoanCollection.PaymentType;
                tblMaster.Description = vechicleLoanCollection.Name;
                tblMaster.Expenses = Convert.ToInt32(vechicleLoanCollection.PrincipleAmount);
                tblMaster.Income = Convert.ToInt32(vechicleLoanCollection.NetAmount);
                tblMaster.Type = "Vechicle Loan Collection";
                tblMaster.FinancialYear = "2020-2021";
              
                var installment = db.Installments.Where(x => x.id == vechicleLoanCollection.SelectDueNumberId).FirstOrDefault();
                installment.dueStatus = "Paid";
                db.Entry(installment).State = EntityState.Modified;
                db.TblMasters.Add(tblMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SelectDueNumberId = new SelectList(db.Installments, "id", "numberofDue", vechicleLoanCollection.SelectDueNumberId);
            ViewBag.VehicleLoanId = new SelectList(db.VehicleLoanEntries, "id", "id", vechicleLoanCollection.vehicleLoanId);
            return View(vechicleLoanCollection);
        }
        [HttpPost]
        public JsonResult Name(int NAME)
        {
            if (NAME > 0)
            {

                var resp = (from loan in db.VehicleLoanEntries
                            join installment in db.Installments on loan.id equals installment.loanNumber
                            where loan.id == NAME && installment.dueStatus == "Pending"
                            select new
                            {
                                Id = installment.id,
                                Name = loan.customerName.customerName,
                                Address = loan.address,
                                PhoneNo = loan.phoneNo,
                                VechicleNumber = loan.vehicleNo,
                                NumberOfInstallments = loan.numberOfInstallments,
                                PrincipleAmount = loan.amountOfLoan,
                                IntrestAmount = installment.Intrest,
                                DueAmount = installment.dueAmount,
                                DueDate = installment.DueDate,
                                SelectDueNumberId = installment.id,
                                selectDueNumber = installment.numberofDue

                                //TotalAmount = Convert.ToInt32(loan.amountOfIntrest) + Convert.ToInt32(loan.dueAmount)
                                //let amount = parseInt(loan.amountOfIntrest) + parseInt(loan.dueAmount);
                                //$("#TotaldueAmount").(amount);
                            }).ToList();

                //db.VehicleLoanEntries.Where(x => x.id == NAME).ToList();
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
            ViewBag.SelectDueNumberId = new SelectList(db.Installments, "id", "numberofDue", vechicleLoanCollection.SelectDueNumberId);

            ViewBag.VehicleLoanId = new SelectList(db.VehicleLoanEntries, "id", "id", vechicleLoanCollection.vehicleLoanId);

            return View(vechicleLoanCollection);
        }

        // POST: VechicleLoanCollections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CollectionDate,NumberOfInstallmentsId,SelectDueNumberId,PaymentType,LoanNumber,Name,vehicleLoanId,Address,PhoneNo,VehicleName,VechicleNumber,VehicleMake,NumberOfInstallments,SelectDueNumber,DueDate,PrincipleAmount,IntrestAmount,TotalAmount,LateDays,LateDaysAmount,Penalty,Discount,NetAmount,DueStatus")] VechicleLoanCollection vechicleLoanCollection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vechicleLoanCollection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SelectDueNumberId = new SelectList(db.Installments, "id", "numberofDue", vechicleLoanCollection.SelectDueNumberId);

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
    public class LoanInstallmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string VechicleNumber { get; set; }
        public string NumberOfInstallments { get; set; }
        public string PrincipleAmount { get; set; }
        public string IntrestAmount { get; set; }
        public string DueAmount { get; set; }
        public DateTime? DueDate { get; set; }
        public string SelectDueNumberId { get; set; }


    }
}
