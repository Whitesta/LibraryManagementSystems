using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystems.Models.Entity;

namespace LibraryManagementSystems.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        // GET: Register
        LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();
        [HttpGet]
        public ActionResult IndexRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IndexRegister(Users users)
        {
            if (!ModelState.IsValid)
            {
                return View("IndexRegister");
            }
            db.Users.Add(users);
            db.SaveChanges();
            return View();
        }
    }
}