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
    public class AccountLedgersController : Controller
    {
        private issModel db = new issModel();

        // GET: AccountLedgers
        public async Task<ActionResult> Index()
        {
            return View(await db.AccountLedgers.ToListAsync());
        }

        // GET: AccountLedgers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountLedger accountLedger = await db.AccountLedgers.FindAsync(id);
            if (accountLedger == null)
            {
                return HttpNotFound();
            }
            return View(accountLedger);
        }

        // GET: AccountLedgers/Create
        public ActionResult Create()
        {
            ViewBag.accountgroupId = new SelectList(db.AccountGroupings, "id", "name");

            return View();
        }

        // POST: AccountLedgers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,ledger,accountgroupId,openingBalance,type")] AccountLedger accountLedger)
        {
            if (ModelState.IsValid)
            {
                db.AccountLedgers.Add(accountLedger);
                await db.SaveChangesAsync();
                ViewBag.accountgroupId = new SelectList(db.AccountGroupings, "id", "name",accountLedger.accountgroupId);
                return RedirectToAction("Index");
            }

            return View(accountLedger);
        }

        // GET: AccountLedgers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountLedger accountLedger = await db.AccountLedgers.FindAsync(id);
            if (accountLedger == null)
            {
                return HttpNotFound();
            }
            ViewBag.accountgroupId = new SelectList(db.AccountGroupings, "id", "name", accountLedger.accountgroupId);

            return View(accountLedger);
        }

        // POST: AccountLedgers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,ledger,accountgroupId,openingBalance,type")] AccountLedger accountLedger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountLedger).State = EntityState.Modified;
                await db.SaveChangesAsync();
                ViewBag.accountgroupId = new SelectList(db.AccountGroupings, "id", "name", accountLedger.accountgroupId);

                return RedirectToAction("Index");
            }
            return View(accountLedger);
        }

        // GET: AccountLedgers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountLedger accountLedger = await db.AccountLedgers.FindAsync(id);
            if (accountLedger == null)
            {
                return HttpNotFound();
            }
            return View(accountLedger);
        }

        // POST: AccountLedgers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AccountLedger accountLedger = await db.AccountLedgers.FindAsync(id);
            db.AccountLedgers.Remove(accountLedger);
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
