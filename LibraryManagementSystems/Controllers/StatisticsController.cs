using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystems.Models.Entity;

namespace LibraryManagementSystems.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();
        public ActionResult Index()
        {
            var value = db.Users.Count();
            var value1 = db.Books.Count();
            var value2 = db.Books.Where(x => x.Status == false).Count();
            var value3 = db.Authors.Count();
            ViewBag.Carry = value;
            ViewBag.Carry1 = value1;
            ViewBag.Carry2 = value2;
            ViewBag.Carry3 = value3;
            return View();
        }

        public ActionResult Weather()
        {
            return View();
        }

        public ActionResult WeatherCard()
        {
            return View();
        }
        public ActionResult Galery()
        {
            return View();
        }
        public ActionResult UploadPicture(HttpPostedFileBase chooseFile)
        {
            if (chooseFile.ContentLength > 0)
            {
                string file = Path.Combine(Server.MapPath("~/web2/Pictures about library/BookCases/"),
                    Path.GetFileName(chooseFile.FileName));
                chooseFile.SaveAs(file);
            }
            return RedirectToAction("Galery");
        }
        public ActionResult LinqCards()
        {
            var value = db.Books.Count();
            var value1 = db.Users.Count();
            var value2 = db.Authors.Count();
            var value3 = db.Books.Where(x => x.Status == false).Count();
            var value4 = db.Categories.Count();
            var value5 = db.AuthorWithMostBooks1().FirstOrDefault();
            var value6 = db.Books.GroupBy(x => x.Publisher).OrderByDescending(z => z.Count()).
              Select(y => new { y.Key }).FirstOrDefault();
            var value7 = db.BestBook1().FirstOrDefault();
            var value8 = db.BestEmployee1().FirstOrDefault();
            var value9 = db.MostActiveMember1().FirstOrDefault();
            var value10 = db.Activities.Where(x => x.ReturnedDate == DateTime.Today).Count();
            ViewBag.Carry = value;
            ViewBag.Carry1 = value1;
            ViewBag.Carry2 = value2;
            ViewBag.Carry3 = value3;
            ViewBag.Carry4 = value4;
            ViewBag.Carry5 = value5;
            ViewBag.Carry6 = value6;
            ViewBag.Carry7 = value7;
            ViewBag.Carry8 = value8;
            ViewBag.Carry9 = value9;
            ViewBag.Carry10 = value10;
            return View();
        }
    }
}