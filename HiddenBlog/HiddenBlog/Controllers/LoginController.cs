﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HiddenBlog.Context;
using HiddenBlog.Models;

namespace HiddenBlog.Controllers
{
    public class LoginController : Controller
    {
        //16.08.30
        private UserContext db = new UserContext();

        //16.08.30
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //16.08.30
        [HttpPost]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                var ChkUser = db.Users.Find(user.ID);
                if (ChkUser != null && ChkUser.Password == user.Password)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "There is no account.";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        //16.08.30
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        //16.08.30
        [HttpPost]
        public ActionResult SignUp([Bind(Include = "ID,Name,Password,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                var ChkUser = db.Users.Find(user.ID);
                if (ChkUser == null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.Error = "The existence of the account.";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
