using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using issFinacial.Models;
using issFinacial.Custom;

namespace issFinacial.Controllers
{
    [CustomAuthorize(Roles = "Admin,Manager")]
    public class GramRatesController : Controller
    {
        private issModel db = new issModel();

        // GET: GramRates
        public async Task<ActionResult> Index()
        {
            return View(await db.GramRates.ToListAsync());
        }

        // GET: GramRates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GramRate gramRate = await db.GramRates.FindAsync(id);
            if (gramRate == null)
            {
                return HttpNotFound();
            }
            return View(gramRate);
        }

        // GET: GramRates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GramRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,date,gramRate,itemType")] GramRate gramRate)
        {
            if (ModelState.IsValid)
            {
                db.GramRates.Add(gramRate);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(gramRate);
        }

        // GET: GramRates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GramRate gramRate = await db.GramRates.FindAsync(id);
            if (gramRate == null)
            {
                return HttpNotFound();
            }
            return View(gramRate);
        }

        // POST: GramRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,date,gramRate,itemType")] GramRate gramRate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gramRate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gramRate);
        }

        // GET: GramRates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GramRate gramRate = await db.GramRates.FindAsync(id);
            if (gramRate == null)
            {
                return HttpNotFound();
            }
            return View(gramRate);
        }

        // POST: GramRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            GramRate gramRate = await db.GramRates.FindAsync(id);
            db.GramRates.Remove(gramRate);
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
