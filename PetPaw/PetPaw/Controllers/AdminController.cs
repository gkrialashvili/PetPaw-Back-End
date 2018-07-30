using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetPaw.Filter;
using PetPaw.Models;
using System.Drawing;


namespace PetPaw.Controllers
{
    [AdminFilter]
    public class AdminController : Controller
    {
        PetPawEntities _db = new PetPawEntities();

        // GET: Admin
        
        public ActionResult Index()
        {
            var users = _db.users.ToList();
            return View(users);
        }


        public ActionResult AddPicture()
        {
            return View();
        }
        [HttpPost]
        public JsonResult UploadPicture(string id)
        {
            try
            {
                user us = Session["user"] as user;
                string path = Server.MapPath("~/Content/Upload/");
                HttpFileCollectionBase files = Request.Files;

                for (int i = 0; i < files.Count; i++)
                {
                    string fileName = Helper.GetHashAndRandom32.Random32();
                    HttpPostedFileBase file = files[i];

                    using (Image image = Image.FromStream(file.InputStream))
                    {
                        image.Save(path + fileName + ".png", ImageFormat.Png);
                    }

                    _db.Sliders.Add(new Slider
                    {
                        Name = fileName,
                        CreateDate = DateTime.Now,
                        IsActive = false,
                        UserID = us.ID,
                        Description = id
                    });
                    _db.SaveChanges();
                }
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
            
        }
    }
}