using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using LibraryManagementSystems.Models.Entity;

namespace LibraryManagementSystems.Controllers
{
    public class MembersController : Controller
    {
        // GET: Members
        LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();
        public ActionResult Index(int page=1)
        {
            var list = db.Users.ToList().ToPagedList(page,8);
            return View(list);
        }

        [HttpGet]
        public ActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMember(Users users)
        {
            if (!ModelState.IsValid)
            {
                return View("AddMember");
            }
            db.Users.Add(users);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteMember(int id)
        {
            var value = db.Users.Find(id);
            db.Users.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateMember(int id)
        {
            var value = db.Users.Find(id);
            return View("UpdateMember",value);
        }

        [HttpPost]
        public ActionResult UpdateMember(Users users)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateMember");
            }
            var value = db.Users.Find(users.Id);
            value.FirstName = users.FirstName;
            value.LastName = users.LastName;
            value.Mail = users.Mail;
            value.UserName = users.UserName;
            value.Password = users.Password;
            value.Telephone = users.Telephone;
            value.School = users.School;
            value.Foto = users.Foto;
            value.Penalties = users.Penalties;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MemberBookHistory(int id)
        {
            var bookhistory = db.Activities.Where(x => x.UserId == id).ToList();
            var user = db.Users.Where(y => y.Id == id).Select(z => z.FirstName + " " + z.LastName).FirstOrDefault();
            ViewBag.Carry = user;
            return View(bookhistory);
        }
    }
}