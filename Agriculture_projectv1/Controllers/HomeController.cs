using Agriculture_projectv1.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agriculture_projectv1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            if(Request.IsAuthenticated)
                {
                return View("index2");
                }  




            return View("index1");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}