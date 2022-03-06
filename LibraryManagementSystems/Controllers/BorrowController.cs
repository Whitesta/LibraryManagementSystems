using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystems.Models.Entity;

namespace LibraryManagementSystems.Controllers
{
    public class BorrowController : Controller
    {

        LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();
        // GET: Borrow
       
        public ActionResult Index()
        {
            var value = db.Activities.Where(x=>x.ActionResult==false).ToList();
            return View(value);
        }

       
        [HttpGet]
        public ActionResult GiveBorrow()
        {
            List<SelectListItem> value1 = (from x in db.Users.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.FirstName + " " + x.LastName,
                                               Value = x.Id.ToString()
                                           }).ToList();
            
            List<SelectListItem> value2 = (from y in db.Books.Where(p=>p.Status==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.BookName,
                                               Value = y.Id.ToString()
                                           }).ToList();

            List<SelectListItem> value3 = (from z in db.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = z.EmployeeFullName,
                                               Value = z.Id.ToString()
                                           }).ToList();

            ViewBag.UserFullName = value1;
            ViewBag.BookName = value2;
            ViewBag.EmployeeFullName = value3;
            return View();
        }

        [HttpPost]
        public ActionResult GiveBorrow(Activities activities)
        {
            var result = db.Users.Where(x => x.Id == activities.Users.Id).FirstOrDefault();
            var result1 = db.Books.Where(y => y.Id == activities.Books.Id).FirstOrDefault();
            var result2 = db.Employees.Where(z => z.Id == activities.Employees.Id).FirstOrDefault();
            activities.Users = result;
            activities.Books = result1;
            activities.Employees = result2;
            db.Activities.Add(activities);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ReturnBook(Activities p)
        {
            var result = db.Activities.Find(p.Id);
            DateTime d1 = DateTime.Parse(result.ReturnDate.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.Carry = d3.TotalDays;
            return View("ReturnBook", result);
        }

        public ActionResult UpdateBorrow(Activities activities)
        {
            var result = db.Activities.Find(activities.Id);
            result.ReturnedDate = activities.ReturnedDate;
            result.ActionResult = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}