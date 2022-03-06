using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystems.Models.Entity;

namespace LibraryManagementSystems.Controllers
{
    public class TransactionsController : Controller
    {
        // GET: Transactions
        LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();
        public ActionResult Index()
        {
            var value = db.Activities.Where(x => x.ActionResult == true).ToList();
            return View(value);
        }
    }
}