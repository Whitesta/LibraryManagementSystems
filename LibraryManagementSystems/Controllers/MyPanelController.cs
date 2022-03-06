using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LibraryManagementSystems.Models.Entity;

namespace LibraryManagementSystems.Controllers
{
    public class MyPanelController : Controller
    {
        LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();
        // GET: MyPanel
      
        [Authorize]
        public ActionResult Index()
        {
            var firstName = (string)TempData["FirstName"];
            var lastName = (string)TempData["LastName"];
            var mail = (string)Session["Email"];
            // var result = db.Users.FirstOrDefault(x => x.Mail == mail);
            var list = db.Annotations.ToList();
            var userFullName = db.Users.Where(x => x.Mail == mail).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
            var userName = db.Users.Where(x => x.Mail == mail).Select(y => y.UserName).FirstOrDefault();
            var phone = db.Users.Where(x => x.Mail == mail).Select(y => y.Telephone).FirstOrDefault();
            var foto = db.Users.Where(x => x.Mail == mail).Select(y => y.Foto).FirstOrDefault();
            var school = db.Users.Where(x => x.Mail == mail).Select(y => y.School).FirstOrDefault();
            var email = db.Users.Where(x => x.Mail == mail).Select(y => y.Mail).FirstOrDefault();
            var id = db.Users.Where(x => x.Mail == mail).Select(y => y.Id).FirstOrDefault();
            var userBookCount = db.Activities.Where(x => x.UserId == id).Count();
            var userMessageCount = db.Messages.Where(x => x.Receiver == mail).Count();
            var annotationCount = db.Annotations.Count();
            ViewBag.FirstName = firstName;
            ViewBag.LastName = lastName;
            ViewBag.UserFullName = userFullName;
            ViewBag.UserName = userName;
            ViewBag.Phone = phone;
            ViewBag.Foto = foto;
            ViewBag.School = school;
            ViewBag.Email = email;
            ViewBag.MessageCount = userMessageCount;
            ViewBag.AnnotationCount = annotationCount;
            ViewBag.UserBookCount = userBookCount;
            return View(list);
        }

        [HttpPost]
        public ActionResult Index2(Users users)
        {
            var user = (string)Session["Email"];
            var member = db.Users.FirstOrDefault(x => x.Mail == user);
            member.Password = users.Password;
            member.FirstName = users.FirstName;
            member.LastName = users.LastName;
            member.UserName = users.UserName;
            member.School = users.School;
            member.Telephone = users.Telephone;
            member.Foto = users.Foto;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MyBooks()
        {
            var user = (string)Session["Email"];
            var id = db.Users.Where(x => x.Mail == user.ToString()).Select(z => z.Id).FirstOrDefault();
            var value = db.Activities.Where(x => x.UserId==id).ToList();
            return View(value);
        }
        public ActionResult Annotations()
        {
            var list = db.Annotations.ToList();
            return View(list);
        }

      

        public PartialViewResult Partial()
        {
            return PartialView();
        }

        public PartialViewResult Partial2()
        {
            var user = (string)Session["Email"];
            var id = db.Users.Where(x => x.Mail == user).Select(y => y.Id).FirstOrDefault();
            var getUser = db.Users.Find(id);
            return PartialView("Partial2",getUser);
        }

    }
}