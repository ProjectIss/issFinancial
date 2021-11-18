﻿using System;
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
    public class Brokers1Controller : Controller
    {
        private issModel db = new issModel();

        // GET: Brokers1
        public async Task<ActionResult> Index()
        {
            return View(await db.Brokers.ToListAsync());
        }

        // GET: Brokers1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Broker broker = await db.Brokers.FindAsync(id);
            if (broker == null)
            {
                return HttpNotFound();
            }
            return View(broker);
        }

        // GET: Brokers1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brokers1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name,address,cellNo")] Broker broker)
        {
            if (ModelState.IsValid)
            {
                db.Brokers.Add(broker);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(broker);
        }

        // GET: Brokers1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Broker broker = await db.Brokers.FindAsync(id);
            if (broker == null)
            {
                return HttpNotFound();
            }
            return View(broker);
        }

        // POST: Brokers1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,address,cellNo")] Broker broker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(broker).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(broker);
        }

        // GET: Brokers1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Broker broker = await db.Brokers.FindAsync(id);
            if (broker == null)
            {
                return HttpNotFound();
            }
            return View(broker);
        }

        // POST: Brokers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Broker broker = await db.Brokers.FindAsync(id);
            db.Brokers.Remove(broker);
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
