using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystems.Models.Entity;

namespace LibraryManagementSystems.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();
        public ActionResult Index()
        {
            var list = db.Admin.ToList();
            return View(list);
        }
        public ActionResult Index2()
        {
            var list = db.Admin.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            db.Admin.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var admin = db.Admin.Find(id);
            db.Admin.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var admin = db.Admin.Find(id);
            return View("UpdateAdmin", admin);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin p)
        {
            var admin = db.Admin.Find(p.Id);
            admin.UserMail = p.UserMail;
            admin.Authority = p.Authority;
            admin.Password = p.Password;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}