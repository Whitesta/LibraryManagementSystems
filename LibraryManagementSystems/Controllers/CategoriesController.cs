using LibraryManagementSystems.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LibraryManagementSystems.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();
        public ActionResult Index()
        {
            var result = db.Categories.Where(x=>x.Status==true).ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Categories c)
        {
            db.Categories.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteCategory(int id)
        {
            var result = db.Categories.Find(id);
            result.Status = false;
           // db.Categories.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var result = db.Categories.Find(id);
            return View("UpdateCategory",result);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Categories c)
        {
            var result = db.Categories.Find(c.Id);
            result.CategoryName = c.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}