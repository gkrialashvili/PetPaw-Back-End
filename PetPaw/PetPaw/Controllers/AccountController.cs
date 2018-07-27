using PetPaw.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetPaw.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Register userModel)
        {

            if (ModelState.IsValid){
                using (var db = new PetPawEntities1())
                {
                    user user = new user
                    {
                        Email = userModel.Email,
                        firstName = userModel.FirstName,
                        lastName = userModel.LastName,
                        Password = userModel.Password,
                        Date = DateTime.Now,
                        resetPassword = "",
                        Sex = userModel.Gender == 1 ? "male" : "keso",
                        Age = 20,
                        profilePicture = ""
                    };
                    db.users.Add(user);
                    db.SaveChanges();
                }
                Redirect("/Home");
                return null;
            }
            else
            {
                return View(userModel);
            }
        }
        public ActionResult Login ()
        {
            return View();
        }
    }
}