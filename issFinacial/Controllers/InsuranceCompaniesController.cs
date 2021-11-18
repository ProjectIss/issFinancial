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
    public class InsuranceCompaniesController : Controller
    {
        private issModel db = new issModel();

        // GET: InsuranceCompanies
        public async Task<ActionResult> Index()
        {
            return View(await db.InsuranceCompanies.ToListAsync());
        }

        // GET: InsuranceCompanies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsuranceCompany insuranceCompany = await db.InsuranceCompanies.FindAsync(id);
            if (insuranceCompany == null)
            {
                return HttpNotFound();
            }
            return View(insuranceCompany);
        }

        // GET: InsuranceCompanies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InsuranceCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name")] InsuranceCompany insuranceCompany)
        {
            if (ModelState.IsValid)
            {
                db.InsuranceCompanies.Add(insuranceCompany);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(insuranceCompany);
        }

        // GET: InsuranceCompanies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsuranceCompany insuranceCompany = await db.InsuranceCompanies.FindAsync(id);
            if (insuranceCompany == null)
            {
                return HttpNotFound();
            }
            return View(insuranceCompany);
        }

        // POST: InsuranceCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name")] InsuranceCompany insuranceCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuranceCompany).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(insuranceCompany);
        }

        // GET: InsuranceCompanies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsuranceCompany insuranceCompany = await db.InsuranceCompanies.FindAsync(id);
            if (insuranceCompany == null)
            {
                return HttpNotFound();
            }
            return View(insuranceCompany);
        }

        // POST: InsuranceCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            InsuranceCompany insuranceCompany = await db.InsuranceCompanies.FindAsync(id);
            db.InsuranceCompanies.Remove(insuranceCompany);
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
