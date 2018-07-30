using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetPaw.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Veterinarian()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Market()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult VetDetailed()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contacts()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}