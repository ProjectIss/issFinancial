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

namespace issFinacial.Controllers
{
    public class AccountGroupingsController : Controller
    {
        private issModel db = new issModel();

        // GET: AccountGroupings
        public async Task<ActionResult> Index()
        {
            return View(await db.AccountGroupings.ToListAsync());
        }

        // GET: AccountGroupings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroup accountGrouping = await db.AccountGroupings.FindAsync(id);
            if (accountGrouping == null)
            {
                return HttpNotFound();
            }
            return View(accountGrouping);
        }

        // GET: AccountGroupings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountGroupings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,accountGroup,parentGroup")] AccountGroup accountGrouping)
        {
            if (ModelState.IsValid)
            {
                db.AccountGroupings.Add(accountGrouping);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(accountGrouping);
        }

        // GET: AccountGroupings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroup accountGrouping = await db.AccountGroupings.FindAsync(id);
            if (accountGrouping == null)
            {
                return HttpNotFound();
            }
            return View(accountGrouping);
        }

        // POST: AccountGroupings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,accountGroup,parentGroup")] AccountGroup accountGrouping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountGrouping).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(accountGrouping);
        }

        // GET: AccountGroupings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroup accountGrouping = await db.AccountGroupings.FindAsync(id);
            if (accountGrouping == null)
            {
                return HttpNotFound();
            }
            return View(accountGrouping);
        }

        // POST: AccountGroupings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AccountGroup accountGrouping = await db.AccountGroupings.FindAsync(id);
            db.AccountGroupings.Remove(accountGrouping);
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
