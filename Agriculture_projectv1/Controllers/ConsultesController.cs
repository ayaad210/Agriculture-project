using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Agriculture_projectv1.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Agriculture_projectv1.Controllers
{
    [Authorize]
    public class ConsultesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Consultes
        public ActionResult Index()
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            List<Consulte> consultes = new List<Consulte>();

            if (userManager.IsInRole(user.Id, "Admins"))//مدرس
            {

                consultes = db.Consultes.Include(c => c.SoilType).ToList();
            }
            else
            {
                 consultes = db.Consultes.Include(c => c.SoilType).Where(c=>c.ApplicationUser.Id==user.Id).ToList();

            }

            return View(consultes);
        }

        // GET: Consultes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulte consulte = db.Consultes.Find(id);
            if (consulte == null)
            {
                return HttpNotFound();
            }
            return View(consulte);
        }

        // GET: Consultes/Create
        public ActionResult Create()
        {
            ViewBag.SoilTypeId = new SelectList(db.SoilTypes, "id", "Name");
            ViewBag.GoverorenatId = new SelectList(db.Governorates, "id", "Name");

            return View();
        }

        // POST: Consultes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ApplicationUserId,SoilTypeId,GoverorenatId,AreaOfSoil,Notes,Response")] Consulte consulte)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                ApplicationUser us= db.Users.Find(user.Id);
                consulte.ApplicationUser = us;
                db.Consultes.Add(consulte);
                db.SaveChanges();
                return Redirect("~/consultes/Edit/"+consulte.Id);
            }


            ViewBag.SoilTypeId = new SelectList(db.SoilTypes, "id", "Name", consulte.SoilTypeId);
            ViewBag.GoverorenatId = new SelectList(db.Governorates, "id", "Name");

            return View(consulte);
        }

        // GET: Consultes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulte consulte = db.Consultes.Include(c => c.ApplicationUser).Where(c => c.Id == id).FirstOrDefault();
            if (consulte == null)
            {
                return HttpNotFound();
            }
            ViewBag.SoilTypeId = new SelectList(db.SoilTypes, "id", "Name", consulte.SoilTypeId);
            ViewBag.GoverorenatId = new SelectList(db.Governorates, "id", "Name", consulte.GoverorenatId);

            return View(consulte);
        }

        // POST: Consultes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ApplicationUserId,SoilTypeId,GoverorenatId,AreaOfSoil,Notes,Response,ApplicationUser.Name,ApplicationUser.Email")] Consulte consulte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consulte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SoilTypeId = new SelectList(db.SoilTypes, "id", "Name", consulte.SoilTypeId);
            ViewBag.GoverorenatId = new SelectList(db.Governorates, "id", "Name", consulte.GoverorenatId);

            return View(consulte);
        }

        // GET: Consultes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulte consulte = db.Consultes.Find(id);
            if (consulte == null)
            {
                return HttpNotFound();
            }
            return View(consulte);
        }

        // POST: Consultes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consulte consulte = db.Consultes.Find(id);
            db.Consultes.Remove(consulte);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ConsultesFert(string id)
        {

            ViewBag.Fertilizers = new SelectList(db.Fertilizers, "id", "Name");
         var model=   db.Consultes.Include(cc => cc.Fertilizers).Where(cc => cc.Id.ToString() == id).FirstOrDefault().Fertilizers.ToList();



            return PartialView(model);

        }
        public string InsertCosulteFert(string Consulteid, string Fertid)
        {

            try
            {
                Consulte c = db.Consultes.Find(Convert.ToInt32(Consulteid));
                Fertilizer f= db.Fertilizers.Find(Convert.ToInt32(Fertid));
                c.Fertilizers.Add(f);
                db.SaveChanges();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" <input type='button' class='btndelete btn-danger'  id='btndelete'  value='-' />");
                sb.AppendLine("<input type = 'hidden' value='" + f.id + "' />");
                string x = "<tr> <td> " + f.Name + "</td> <td>" + sb + "</td> </tr>";
                return x;

                //ViewBag.Groups = new SelectList(db.Groups, "id", "Name").ToList(); ;

                //ViewBag.Students = new SelectList(db.Students.Include(ss => ss.user), "id", "user.Name").ToList(); ;
                //Perant perR = db.Perants.Include(p => p.Children).Where(p => p.Id.ToString() == perantid).FirstOrDefault();
                //return View("PerantChildren", per.Children.ToList());
            }
            catch (Exception)
            {

                return "-1";//RedirectToAction("PerantChildren", new { id = perantid });
            }
        }

        public string Deleteconsultefert(string Consulteid, string Fertid)
        {
            try
            {
                Consulte c = db.Consultes.Find(Convert.ToInt32(Consulteid));
                Fertilizer f = db.Fertilizers.Find(Convert.ToInt32(Fertid));
                c.Fertilizers.Remove(f);
                db.SaveChanges();
                return "1";
            }
            catch (Exception)
            {

                return "-1";

            }

        }



        public ActionResult ConsultesCrops(string id)
        {

            ViewBag.CrossTypes = new SelectList(db.CrossTypes, "id", "Name");
            var model = db.Consultes.Include(cc => cc.CrossTypes).Where(cc => cc.Id.ToString() == id).FirstOrDefault().CrossTypes.ToList();
            return PartialView(model);

        }
        public string InsertCosultecrops(string Consulteid, string cropsid)
        {

            try
            {
                Consulte c = db.Consultes.Find(Convert.ToInt32(Consulteid));
                CrossType t = db.CrossTypes.Find(Convert.ToInt32(cropsid));
                c.CrossTypes.Add(t);
                db.SaveChanges();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" <input type='button' class='btndelete btn-danger'  id='btndelete'  value='-' />");
                sb.AppendLine("<input type = 'hidden' value='" + t.id + "' />");
                string x = "<tr> <td> " + t.Name + "</td> <td>" + sb + "</td> </tr>";
                return x;

                //ViewBag.Groups = new SelectList(db.Groups, "id", "Name").ToList(); ;

                //ViewBag.Students = new SelectList(db.Students.Include(ss => ss.user), "id", "user.Name").ToList(); ;
                //Perant perR = db.Perants.Include(p => p.Children).Where(p => p.Id.ToString() == perantid).FirstOrDefault();
                //return View("PerantChildren", per.Children.ToList());
            }
            catch (Exception)
            {

                return "-1";//RedirectToAction("PerantChildren", new { id = perantid });
            }
        }

        public string Deleteconsultecrops(string Consulteid, string cropsid)
        {
            try
            {
                Consulte c = db.Consultes.Find(Convert.ToInt32(Consulteid));
                CrossType t = db.CrossTypes.Find(Convert.ToInt32(cropsid));
                c.CrossTypes.Remove(t);
                db.SaveChanges();
                return "1";
            }
            catch (Exception)
            {

                return "-1";

            }

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
