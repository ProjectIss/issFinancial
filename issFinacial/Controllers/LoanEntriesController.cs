using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using issFinacial.Custom;
using System.Web.Mvc;
using issFinacial.Models;

namespace issFinacial.Controllers
{
    [CustomAuthorize(Roles = "Admin,Manager")]
    public class LoanEntriesController : Controller
    {
        private issModel db = new issModel();

        // GET: LoanEntries
        public async Task<ActionResult> Index()
        {
            return View(await db.LoanEntries.ToListAsync());
        }

        // GET: LoanEntries/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanEntry loanEntry = await db.LoanEntries.FindAsync(id);
            if (loanEntry == null)
            {
                return HttpNotFound();
            }
            return View(loanEntry);
        }

        // GET: LoanEntries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,code,name,f" +
            "atherName,address,areaName,identityproof,loanDate,billNo,sNo,itemName,itemType,gramValue,queality,grossWeight,netWeight,itemValue,totalGrams,value,principle,intrest,intrestAmount,deducation")] LoanEntry loanEntry)
        {
            if (ModelState.IsValid)
            {
                db.LoanEntries.Add(loanEntry);
                await db.SaveChangesAsync();
                int le = !string.IsNullOrEmpty(loanEntry.principle) ? Convert.ToInt32(loanEntry.principle) : 0;

                for (int i = 1; i < le; i++)
                {
                    Installment objInstall = new Installment();
                    objInstall.loanAmount = loanEntry.itemValue;
                    objInstall.loanNumber = 1.ToString();
                    objInstall.numberofDue = i.ToString();
                    objInstall.dueStatus = "Pending";
                    objInstall.firstDueDate = DateTime.Now.AddDays(28).ToString();
                    db.Installments.Add(objInstall);

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loanEntry);
        }

        // GET: LoanEntries/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanEntry loanEntry = await db.LoanEntries.FindAsync(id);
            if (loanEntry == null)
            {
                return HttpNotFound();
            }
            return View(loanEntry);
        }

        // POST: LoanEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,code,name,fatherName,address,areaName,identityproof,loanDate,billNo,sNo,itemName,itemType,gramValue,queality,grossWeight,netWeight,itemValue,totalGrams,value,principle,intrest,intrestAmount,deducation")] LoanEntry loanEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loanEntry).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(loanEntry);
        }

        // GET: LoanEntries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanEntry loanEntry = await db.LoanEntries.FindAsync(id);
            if (loanEntry == null)
            {
                return HttpNotFound();
            }
            return View(loanEntry);
        }

        // POST: LoanEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LoanEntry loanEntry = await db.LoanEntries.FindAsync(id);
            db.LoanEntries.Remove(loanEntry);
            await db.SaveChangesAsync();
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
