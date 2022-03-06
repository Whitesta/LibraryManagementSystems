using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystems.Models.Entity;

namespace LibraryManagementSystems.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: Authors
        LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();
        public ActionResult Index()
        {
            var list = db.Authors.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Authors authors)
        {
            if (!ModelState.IsValid)
            {
                return View("AddAuthor");
            }
            db.Authors.Add(authors);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAuthor(int id)
        {
            var value = db.Authors.Find(id);
            db.Authors.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AuthorGet(int id)
        {
            var authorGet = db.Authors.Find(id);
            return View("AuthorGet", authorGet);
        }

        public ActionResult UpdateAuthor(Authors authors)
        {
            var result = db.Authors.Find(authors.Id);
            result.AuthorFirstName = authors.AuthorFirstName;
            result.AuthorLastName = authors.AuthorLastName;
            result.Detail = authors.Detail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AuthorBooks(int id)
        {
            var value = db.Books.Where(x => x.AuthorId == id).ToList();
            var author = db.Authors.Where(y => y.Id == id).Select(z => z.AuthorFirstName + " " + z.AuthorLastName).FirstOrDefault();
            ViewBag.Carry = author;
            return View(value);
        }
    }
}