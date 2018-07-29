using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetPaw.Filter;
using PetPaw.Models;

namespace PetPaw.Controllers
{
    public class AdminController : Controller
    {
        PetPawEntities _db = new PetPawEntities();

        // GET: Admin
        [AdminFilter]
        public ActionResult Index()
        {
            var users = _db.users.ToList();
            return View(users);
        }
    }
}