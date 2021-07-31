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
    public class SoilTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SoilTypes
        public ActionResult Index()
        {
            return View(db.SoilTypes.ToList());
        }

        // GET: SoilTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoilType soilType = db.SoilTypes.Find(id);
            if (soilType == null)
            {
                return HttpNotFound();
            }
            return View(soilType);
        }

        // GET: SoilTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SoilTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name")] SoilType soilType)
        {
            if (ModelState.IsValid)
            {
                db.SoilTypes.Add(soilType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(soilType);
        }

        // GET: SoilTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoilType soilType = db.SoilTypes.Find(id);
            if (soilType == null)
            {
                return HttpNotFound();
            }
            return View(soilType);
        }

        // POST: SoilTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name")] SoilType soilType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soilType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(soilType);
        }

        // GET: SoilTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoilType soilType = db.SoilTypes.Find(id);
            if (soilType == null)
            {

                return HttpNotFound();
            }
            return View(soilType);
        }

        // POST: SoilTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SoilType soilType = db.SoilTypes.Find(id);
            if (soilType.Consultes.Count<=0)
            {
                db.SoilTypes.Remove(soilType);
                db.SaveChanges();
            }
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
