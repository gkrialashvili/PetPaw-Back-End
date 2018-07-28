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
                using (var db = new PetPawEntities())
                {
                    TimeSpan t = DateTime.Now - userModel.Birthdate;
                    DateTime zeroTime = new DateTime(1, 1, 1);
                    int years = (zeroTime + t).Year - 1;
                    user user = new user
                    {
                        Email = userModel.Email,
                        firstName = userModel.FirstName,
                        lastName = userModel.LastName,
                        Password = userModel.Password,
                        Date = DateTime.Now,
                        resetPassword = Helper.GetHashAndRandom32.Random32(),
                        Sex = userModel.Gender == 1 ? "male" : "keso",
                        Age = years,
                        profilePicture = Helper.GetHashAndRandom32.Random32(),
                        phoneNumber = userModel.phoneNumber
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