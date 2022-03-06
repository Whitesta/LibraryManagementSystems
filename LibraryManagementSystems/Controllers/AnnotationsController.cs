using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystems.Models.Entity;

namespace LibraryManagementSystems.Controllers
{
    public class AnnotationsController : Controller
    {
        // GET: Annotations
        LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();
        public ActionResult Index()
        {
            var list = db.Annotations.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult AddAnnotation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAnnotation(Annotations annotations)
        {
            db.Annotations.Add(annotations);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var value = db.Annotations.Find(id);
            db.Annotations.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AnnotationDetail(Annotations detail)
        {
            var value = db.Annotations.Find(detail.Id);
            return View("AnnotationDetail", value);
        }

        public ActionResult Update(Annotations update)
        {
            var result = db.Annotations.Find(update.Id);
            result.Categories = update.Categories;
            result.Contents = update.Contents;
            result.Date = update.Date;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}