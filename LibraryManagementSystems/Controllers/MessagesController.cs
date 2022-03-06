using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystems.Models.Entity;

namespace LibraryManagementSystems.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Messages
        LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();
        public ActionResult Index()
        {
            var mail = (string)Session["Email"].ToString();
            var list = db.Messages.Where(x=>x.Receiver==mail.ToString()).ToList();
            return View(list);
        }

        public ActionResult Outgoing()
        {
            var mail = (string)Session["Email"].ToString();
            var list = db.Messages.Where(x => x.Sender == mail.ToString()).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult NewMessages()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessages(Messages messages)
        {
            var email= (string)Session["Email"].ToString();
            messages.Sender = email.ToString();
            messages.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Messages.Add(messages);
            db.SaveChanges();
            return View();
        }

        public PartialViewResult Partial1()
        {
            var email = (string)Session["Email"].ToString();
            var messageInCount = db.Messages.Where(x => x.Receiver == email).Count();
            var messageOutCount = db.Messages.Where(x => x.Sender == email).Count();
            ViewBag.MessageInCount = messageInCount;
            ViewBag.MessageOutCount = messageOutCount;
            return PartialView();
        }
    }
}
