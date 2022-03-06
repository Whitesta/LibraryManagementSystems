using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystems.Models.Entity;

namespace LibraryManagementSystems.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();
        public ActionResult Index()
        {
            var result = db.Employees.ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEmployee");
            }
            db.Employees.Add(employees);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteEmployee(int id)
        {
            var result = db.Employees.Find(id);
            db.Employees.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {

          
            var result = db.Employees.Find(id);
            return View("UpdateEmployee", result);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateEmployee");
            }
            var result = db.Employees.Find(employees.Id);
            result.EmployeeFullName = employees.EmployeeFullName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}