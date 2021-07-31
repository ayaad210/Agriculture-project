using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Agriculture_projectv1.Models;

namespace Agriculture_projectv1.Controllers
{
    [Authorize(Roles = "Admins")]

    public class FertilizersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Fertilizers
        public ActionResult Index()
        {
            return View(db.Fertilizers.ToList());
        }

        // GET: Fertilizers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fertilizer fertilizer = db.Fertilizers.Find(id);
            if (fertilizer == null)
            {
                return HttpNotFound();
            }
            return View(fertilizer);
        }

        // GET: Fertilizers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fertilizers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name")] Fertilizer fertilizer)
        {
            if (ModelState.IsValid)
            {
                db.Fertilizers.Add(fertilizer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fertilizer);
        }

        // GET: Fertilizers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fertilizer fertilizer = db.Fertilizers.Find(id);
            if (fertilizer == null)
            {
                return HttpNotFound();
            }
            return View(fertilizer);
        }

        // POST: Fertilizers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name")] Fertilizer fertilizer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fertilizer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fertilizer);
        }

        // GET: Fertilizers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fertilizer fertilizer = db.Fertilizers.Find(id);
            if (fertilizer == null)
            {
                return HttpNotFound();
            }
            return View(fertilizer);
        }

        // POST: Fertilizers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fertilizer fertilizer = db.Fertilizers.Find(id);
            db.Fertilizers.Remove(fertilizer);
            db.SaveChanges();
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
