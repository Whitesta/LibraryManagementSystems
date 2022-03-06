using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystems.Models.Entity;

namespace LibraryManagementSystems.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();
        public ActionResult Index(string p)
        {
            var books = from b in db.Books select b;
            if (!string.IsNullOrEmpty(p))
            {
                books = books.Where(m => m.BookName.Contains(p));
            }
           // var list = db.Books.ToList();
            return View(books.ToList());
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem> value = (from i in db.Categories.Where(x=>x.Status==true).ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.CategoryName,
                                              Value = i.Id.ToString()
                                          }).ToList();
            ViewBag.Carry = value;

            List<SelectListItem> value2 = (from i in db.Authors.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AuthorFirstName + ' ' + i.AuthorLastName,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.Carry2 = value2;
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Books book)
        {
            var addCategory = db.Categories.Where(c => c.Id == book.Categories.Id).FirstOrDefault();
            var addAuthor = db.Authors.Where(a => a.Id == book.Authors.Id).FirstOrDefault();
            book.Categories = addCategory;
            book.Authors = addAuthor;
            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBook(int id)
        {
            var deleteBook = db.Books.Find(id);
            db.Books.Remove(deleteBook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetBook(int id)
        {
            var result = db.Books.Find(id);
             List<SelectListItem> value = (from i in db.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.CategoryName,
                                              Value = i.Id.ToString()
                                          }).ToList();
            ViewBag.Carry = value;

            List<SelectListItem> value2 = (from i in db.Authors.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AuthorFirstName + ' ' + i.AuthorLastName,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.Carry2 = value2;
            return View("GetBook", result);
        }

        public ActionResult UpdateBook(Books books)
        {
            var result = db.Books.Find(books.Id);
            result.BookName = books.BookName;
            result.Page = books.Page;
            result.PublicationYear = books.PublicationYear;
            result.Publisher = books.Publisher;
            result.BookFoto = books.BookFoto;
            result.Status = true;
            var category = db.Categories.Where(c => c.Id == books.Categories.Id).FirstOrDefault();
            var author = db.Authors.Where(a => a.Id == books.Authors.Id).FirstOrDefault();
            result.AuthorId = author.Id;
            result.CategoryId = category.Id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}