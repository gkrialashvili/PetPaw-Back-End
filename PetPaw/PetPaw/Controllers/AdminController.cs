using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetPaw.Filter;

namespace PetPaw.Controllers
{
    public class AdminController : Controller
    {

        // GET: Admin
        [AdminFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}