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
    public class ReceiptEntriesController : Controller
    {
        private issModel db = new issModel();

        // GET: ReceiptEntries
        public async Task<ActionResult> Index()
        {
            return View(await db.ReceiptEntries.ToListAsync());
        }

        // GET: ReceiptEntries/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptEntry receiptEntry = await db.ReceiptEntries.FindAsync(id);
            if (receiptEntry == null)
            {
                return HttpNotFound();
            }
            return View(receiptEntry);
        }

        // GET: ReceiptEntries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReceiptEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,No,date,type,name,amount")] ReceiptEntry receiptEntry)
        {
            if (ModelState.IsValid)
            {
                db.ReceiptEntries.Add(receiptEntry);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(receiptEntry);
        }

        // GET: ReceiptEntries/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptEntry receiptEntry = await db.ReceiptEntries.FindAsync(id);
            if (receiptEntry == null)
            {
                return HttpNotFound();
            }
            return View(receiptEntry);
        }

        // POST: ReceiptEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,No,date,type,name,amount")] ReceiptEntry receiptEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receiptEntry).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(receiptEntry);
        }

        // GET: ReceiptEntries/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptEntry receiptEntry = await db.ReceiptEntries.FindAsync(id);
            if (receiptEntry == null)
            {
                return HttpNotFound();
            }
            return View(receiptEntry);
        }

        // POST: ReceiptEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            ReceiptEntry receiptEntry = await db.ReceiptEntries.FindAsync(id);
            db.ReceiptEntries.Remove(receiptEntry);
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
