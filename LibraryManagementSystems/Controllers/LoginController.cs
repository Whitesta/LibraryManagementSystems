using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystems.Models.Entity;
using System.Web.Security;

namespace LibraryManagementSystems.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();
        // GET: Login
       [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Users users)
        {
            var informations = db.Users.FirstOrDefault(x => x.Mail == users.Mail && x.Password == users.Password);
            if (informations != null)
            {
                FormsAuthentication.SetAuthCookie(informations.Mail, false);
                Session["Email"] = informations.Mail.ToString();
              // TempData["id"] = informations.Id.ToString();
                TempData["FirstName"] = informations.FirstName.ToString();
                TempData["LastName"] = informations.LastName.ToString();
                //TempData["UserName"] = informations.UserName.ToString();
                //TempData["Password"] = informations.Password.ToString();   
                //TempData["School"] = informations.School.ToString();
                return RedirectToAction("Index", "MyPanel");
            }
            else
            {
                return View();
            }
            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}