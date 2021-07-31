using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Agriculture_projectv1.Models;
using System.Text;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Agriculture_projectv1.Controllers
{
    [Authorize]
    public class CrossTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CrossTypes
        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            List<Consulte> consultes = new List<Consulte>();

            if (userManager.IsInRole(user.Id, "Admins"))
            {
                ViewBag.type = "A";//admin

            }
            else
            {
                ViewBag.type = "V";//visitor

            }
            // List<CrossTypeViewModel> modelList =new List<CrossTypeViewModel>();
            var list = db.CrossTypes.ToList();
            //foreach (var item in list)
            //{
            //    CrossTypeViewModel mo = new CrossTypeViewModel();
            //    mo.Name = item.Name;
            //    mo.Notes = item.Notes;
            //    mo.id = item.id;
            //    modelList.Add(mo);
            //}
            return View(list);
        }
        

         public ActionResult CrossComponies(int id)
        {
         CrossType  cr=   db.CrossTypes.Include(c=>c.Componies).Where(c=>c.id==id).FirstOrDefault();
            ViewBag.Componies = new SelectList(db.Companies, "id", "Name");
            return View(cr.Componies.ToList());
        }

        // GET: CrossTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CrossType crossType = db.CrossTypes.Include(cr => cr.Componies).Where(cr => cr.id == id).FirstOrDefault();
            if (crossType == null)
            {
                return HttpNotFound();
            }
            return View(crossType);
        }

        // GET: CrossTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CrossTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( CrossTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                //byte[] Imagedata = new byte[model.ImageFile.ContentLength];
                //model.ImageFile.InputStream.Read(Imagedata, 0, model.ImageFile.ContentLength);

                //CrossType cr = new CrossType() { Name = model.Name, Duration = model.Duration, Pesticidesdates = model.Pesticidesdates, Notes = model.Notes, seasons = model.seasons,Image= Imagedata };
                CrossType crossType = Mapper.Map<CrossTypeViewModel, CrossType>(model);
                if (model.ImageFile != null)
                {
                    byte[] Imagedata = new byte[model.ImageFile.ContentLength];
                    model.ImageFile.InputStream.Read(Imagedata, 0, model.ImageFile.ContentLength);
                    crossType.Image = Imagedata;
                }

                db.CrossTypes.Add(crossType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: CrossTypes/Edit/5
        [Authorize(Roles = "Admins")]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CrossType crossType = db.CrossTypes.Find(id);

            CrossTypeViewModel model = Mapper.Map<CrossType,CrossTypeViewModel>(crossType);
            
            if (crossType == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: CrossTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CrossTypeViewModel model)
        {
          

            if (ModelState.IsValid)
            {
                CrossType crossType = Mapper.Map<CrossTypeViewModel, CrossType>(model);
                if (model.ImageFile != null)
                {
                    byte[] Imagedata = new byte[model.ImageFile.ContentLength];
                    model.ImageFile.InputStream.Read(Imagedata, 0, model.ImageFile.ContentLength);
                    crossType.Image = Imagedata;
                }

                db.Entry(crossType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: CrossTypes/Delete/5
        [Authorize(Roles = "Admins")]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CrossType crossType = db.CrossTypes.Find(id);
            if (crossType == null)
            {
                return HttpNotFound();
            }
            return View(crossType);
        }

        // POST: CrossTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CrossType crossType = db.CrossTypes.Find(id);
            db.CrossTypes.Remove(crossType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public string InsertCropsTypeCompony(string Companyid, string cropsTypeid)
        {

            //try
            //{
                CrossType cr = db.CrossTypes.Find(Convert.ToInt32(cropsTypeid));
                Compony c = db.Companies.Find(Convert.ToInt32(Companyid));
                cr.Componies.Add(c);
                db.SaveChanges();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" <input type='button' class='btndelete btn-danger'  id='btndelete'  value='-' />");
                sb.AppendLine("<input type = 'hidden' value='" + c.id + "' />");
                string x = "<tr> <td> " + c.Name + "</td> <td>" + sb + "</td> </tr>";
                return x;

                //ViewBag.Groups = new SelectList(db.Groups, "id", "Name").ToList(); ;

                //ViewBag.Students = new SelectList(db.Students.Include(ss => ss.user), "id", "user.Name").ToList(); ;
                //Perant perR = db.Perants.Include(p => p.Children).Where(p => p.Id.ToString() == perantid).FirstOrDefault();
                //return View("PerantChildren", per.Children.ToList());
            //}
            //catch (Exception e)
            //{

            //    return "-1";//RedirectToAction("PerantChildren", new { id = perantid });
            //}
        }

        public string DeleteCropsTypeCompany(string Companyid, string cropsTypeid)
        {
            try
            {
            CrossType cr=    db.CrossTypes.Find(Convert.ToInt32(cropsTypeid));
              Compony  c=  db.Companies.Find(Convert.ToInt32(Companyid));
               cr.Componies.Remove(c);
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
