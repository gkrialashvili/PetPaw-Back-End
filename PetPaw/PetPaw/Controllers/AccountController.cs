using PetPaw.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetPaw.Filter;

namespace PetPaw.Controllers
{
    public class AccountController : Controller
    {
        [RoleFilter]
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [RoleFilter]
        [HttpPost]
        public ActionResult Registration(Register userModel)
        {

            if (ModelState.IsValid)
            {
                using (var db = new PetPawEntities())
                {
                    TimeSpan t = DateTime.Now - userModel.Birthdate;
                    DateTime zeroTime = new DateTime(1, 1, 1);
                    int years = (zeroTime + t).Year - 1;
                    if (db.users.Any(x => x.Email == userModel.Email))
                    {
                        return Content("მითითებული მეილით უკვე დარეგისტრირებულია მომხმარებელი");
                    }
                    user user = new user
                    {
                        Email = userModel.Email,
                        firstName = userModel.FirstName,
                        lastName = userModel.LastName,
                        Password = Helper.GetHashAndRandom32.MD5Hash(userModel.Password),
                        Date = DateTime.Now,
                        resetPassword = Helper.GetHashAndRandom32.Random32(),
                        Sex = userModel.Gender == 1 ? "male" : "keso",
                        Age = years,
                        profilePicture = Helper.GetHashAndRandom32.Random32(),
                        phoneNumber = userModel.phoneNumber,
                        Role = 50
                    };
                    db.users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {
                return View(userModel);
            }
        }

        [RoleFilter]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [RoleFilter]
        [HttpPost]
        public JsonResult Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return Json(1);
            }

            using (var db = new PetPawEntities())
            {
                try
                {
                    if (!db.users.Any(x => x.Email == email))
                    {
                        return Json(2);
                    }

                    if (db.users.FirstOrDefault(x => x.Email == email).Password ==
                        Helper.GetHashAndRandom32.MD5Hash(password))
                    {
                        Session["user"] = db.users.FirstOrDefault(x => x.Email == email);
                        return Json(0);
                    }
                    return Json(3);
                }
                catch
                {
                    return Json(4);
                }

            }
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}