using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HiddenBlog.Context;
using HiddenBlog.Models;
using System.IO;

namespace HiddenBlog.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db = new UserContext();
        private MainBannerContext db2 = new MainBannerContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,Name,Password,Email")] User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Admin", "Home");
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Admin", "Home");
        }

        [HttpGet]
        public ActionResult AdminMainBanner()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminMainBanner(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/UploadImages"), fileName);
                
                MainBanner newBanner = new MainBanner();
                newBanner.Name = fileName;
                newBanner.Path = path;
                db2.MainBanners.Add(newBanner);
                db2.SaveChanges();
               
                file.SaveAs(path);
            }
            return RedirectToAction("AdminMainBanner", "Home");
        }
    }
}
