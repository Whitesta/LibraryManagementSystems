using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystems.Models.Entity;
using LibraryManagementSystems.Models.Classes;

namespace LibraryManagementSystems.Controllers
{
    [AllowAnonymous]
    public class ShowCaseController : Controller
    {
        // GET: ShowCase
        LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Value1 = db.Books.ToList();
            cs.Value2 = db.About.ToList();
           // var result = db.Books.ToList();
            return View(cs);
        }
    }
}