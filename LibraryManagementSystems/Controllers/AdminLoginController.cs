using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LibraryManagementSystems.Models.Entity;

namespace LibraryManagementSystems.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var inform = db.Admin.FirstOrDefault(x => x.UserMail == admin.UserMail && x.Password == admin.Password);
            if (inform != null)
            {
                FormsAuthentication.SetAuthCookie(inform.UserMail, false);
                Session["UserMail"] = inform.UserMail.ToString();
                return RedirectToAction("Index", "Categories");
            }
            else
            {
            return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}