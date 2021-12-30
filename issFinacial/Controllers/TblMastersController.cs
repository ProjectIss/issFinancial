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
    public class TblMastersController : Controller
    {
        private issModel db = new issModel();

        // GET: TblMasters
        public async Task<ActionResult> Index()
        {
            return View(await db.TblMasters.ToListAsync());
        }

        // GET: TblMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblMaster tblMaster = await db.TblMasters.FindAsync(id);
            if (tblMaster == null)
            {
                return HttpNotFound();
            }
            return View(tblMaster);
        }

        // GET: TblMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TblMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Edate,Paytype,AccID,GroupID,Des,Expenses,Income,UGroup,Type,FYear,CompanyName,User,ETime,DTime")] TblMaster tblMaster)
        {
            if (ModelState.IsValid)
            {
                db.TblMasters.Add(tblMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblMaster);
        }

        // GET: TblMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblMaster tblMaster = await db.TblMasters.FindAsync(id);
            if (tblMaster == null)
            {
                return HttpNotFound();
            }
            return View(tblMaster);
        }

        // POST: TblMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Edate,Paytype,AccID,GroupID,Des,Expenses,Income,UGroup,Type,FYear,CompanyName,User,ETime,DTime")] TblMaster tblMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblMaster);
        }

        // GET: TblMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblMaster tblMaster = await db.TblMasters.FindAsync(id);
            if (tblMaster == null)
            {
                return HttpNotFound();
            }
            return View(tblMaster);
        }

        // POST: TblMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TblMaster tblMaster = await db.TblMasters.FindAsync(id);
            db.TblMasters.Remove(tblMaster);
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
