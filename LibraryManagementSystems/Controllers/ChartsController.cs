using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystems.Models;
using LibraryManagementSystems.Models.Classes;

namespace LibraryManagementSystems.Controllers
{
    public class ChartsController : Controller
    {
        // GET: Charts
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeBookResult()
        {
            return Json(Lists());
        }
        public List<Class2> Lists()
        {
            List<Class2> cs = new List<Class2>();
            cs.Add(new Class2()
            {
                Publisher = "Palma",
                BookCount=10
            });
            cs.Add(new Class2()
            {
                Publisher = "Mars",
                BookCount = 8
            });
            cs.Add(new Class2()
            {
                Publisher = "Günesh",
                BookCount = 5
            });
            return cs;
        }
    }
}