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
    [Authorize(Roles ="Admins")]
    public class ComponiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Componies
        public ActionResult Index()
        {
            return View(db.Companies.ToList());
        }

        // GET: Componies/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compony compony = db.Companies.Find(id);
            if (compony == null)
            {
                return HttpNotFound();
            }
            return View(compony);
        }

        // GET: Componies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Componies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Address,Link,Notes,Phone")] Compony compony)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(compony);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compony);
        }

        // GET: Componies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compony compony = db.Companies.Find(id);
            if (compony == null)
            {
                return HttpNotFound();
            }
            return View(compony);
        }

        // POST: Componies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Address,Link,Notes,Phone")] Compony compony)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compony).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compony);
        }

        // GET: Componies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compony compony = db.Companies.Find(id);
            if (compony == null)
            {
                return HttpNotFound();
            }
            return View(compony);
        }

        // POST: Componies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compony compony = db.Companies.Find(id);
            db.Companies.Remove(compony);
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
