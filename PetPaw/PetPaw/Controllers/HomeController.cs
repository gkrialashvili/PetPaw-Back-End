using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetPaw.Models;

namespace PetPaw.Controllers
{
    public class HomeController : Controller
    {
        PetPawEntities _db = new PetPawEntities();
        public ActionResult Index()
        {
            var pictures = _db.Sliders.Where(x => x.IsActive == true);
            return View(pictures);
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

        public ActionResult AddPet()
        {
            return View();
        }
    }
}