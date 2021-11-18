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
    public class VoucherEntriesController : Controller
    {
        private issModel db = new issModel();

        // GET: VoucherEntries
        public async Task<ActionResult> Index()
        {
            return View(await db.VoucherEntries.ToListAsync());
        }

        // GET: VoucherEntries/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoucherEntry voucherEntry = await db.VoucherEntries.FindAsync(id);
            if (voucherEntry == null)
            {
                return HttpNotFound();
            }
            return View(voucherEntry);
        }

        // GET: VoucherEntries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VoucherEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,No,name,date,type,description,amount")] VoucherEntry voucherEntry)
        {
            if (ModelState.IsValid)
            {
                db.VoucherEntries.Add(voucherEntry);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(voucherEntry);
        }

        // GET: VoucherEntries/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoucherEntry voucherEntry = await db.VoucherEntries.FindAsync(id);
            if (voucherEntry == null)
            {
                return HttpNotFound();
            }
            return View(voucherEntry);
        }

        // POST: VoucherEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,No,name,date,type,description,amount")] VoucherEntry voucherEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voucherEntry).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(voucherEntry);
        }

        // GET: VoucherEntries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoucherEntry voucherEntry = await db.VoucherEntries.FindAsync(id);
            if (voucherEntry == null)
            {
                return HttpNotFound();
            }
            return View(voucherEntry);
        }

        // POST: VoucherEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VoucherEntry voucherEntry = await db.VoucherEntries.FindAsync(id);
            db.VoucherEntries.Remove(voucherEntry);
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
