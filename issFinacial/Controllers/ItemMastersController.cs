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
    public class ItemMastersController : Controller
    {
        private issModel db = new issModel();

        // GET: ItemMasters
        public async Task<ActionResult> Index()
        {
            return View(await db.ItemMasters.ToListAsync());
        }

        // GET: ItemMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemMaster itemMaster = await db.ItemMasters.FindAsync(id);
            if (itemMaster == null)
            {
                return HttpNotFound();
            }
            return View(itemMaster);
        }

        // GET: ItemMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,itemName,itemNameTamil,itemType")] ItemMaster itemMaster)
        {
            if (ModelState.IsValid)
            {
                db.ItemMasters.Add(itemMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(itemMaster);
        }

        // GET: ItemMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemMaster itemMaster = await db.ItemMasters.FindAsync(id);
            if (itemMaster == null)
            {
                return HttpNotFound();
            }
            return View(itemMaster);
        }

        // POST: ItemMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,itemName,itemNameTamil,itemType")] ItemMaster itemMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(itemMaster);
        }

        // GET: ItemMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemMaster itemMaster = await db.ItemMasters.FindAsync(id);
            if (itemMaster == null)
            {
                return HttpNotFound();
            }
            return View(itemMaster);
        }

        // POST: ItemMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ItemMaster itemMaster = await db.ItemMasters.FindAsync(id);
            db.ItemMasters.Remove(itemMaster);
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
