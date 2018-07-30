using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetPaw.Models;
using System.Drawing.Imaging;
using PetPaw.Filter;

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

        [RoleFilter]
        public ActionResult AddPet()
        {
            return View();
        }

        [RoleFilter]
        [HttpPost]
        public JsonResult AddPetPicture()
        {
            user us = Session["user"] as user;
            string path = Server.MapPath("~/Content/Market/");
            HttpFileCollectionBase files = Request.Files;
            string fileName="";
            for (int i = 0; i < files.Count; i++)
            {
                fileName = Helper.GetHashAndRandom32.Random32();
                HttpPostedFileBase file = files[i];

                using (Image image = Image.FromStream(file.InputStream))
                {
                    image.Save(path + fileName + ".png", ImageFormat.Png);
                }

                _db.Markets.Add(new Market
                {
                    Picture = fileName,
                    UserID = us.ID,
                    Description = "11",
                    Age = 11,
                    Breed = "11",
                    ContactPerson = "11",
                    Currency = "11",
                    Gender = "11",
                    Location = "11",
                    PhoneNumber = "11",
                    Price = 11,
                    Title = "11",
                    Type = "11",
                });
                _db.SaveChanges();
            }
            return Json(_db.Markets.FirstOrDefault(x=>x.Picture==fileName)?.ID);
        }

        [RoleFilter]
        public ActionResult AddPetInfo(Market marketItem)
        {
            var product = _db.Markets.FirstOrDefault(x => x.ID == marketItem.ID);
            product.Description = marketItem.Description;
            product.Age = marketItem.Age;
            product.Breed = marketItem.Breed;
            product.ContactPerson = marketItem.ContactPerson;
            product.Currency = marketItem.Currency;
            product.Gender = marketItem.Gender;
            product.Location = marketItem.Location;
            product.PhoneNumber = marketItem.PhoneNumber;
            product.Price = marketItem.Price;
            product.Title = marketItem.Title;
            product.Type = marketItem.Type;
            _db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}