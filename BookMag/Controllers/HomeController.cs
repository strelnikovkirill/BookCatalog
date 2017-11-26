using BookMag.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookMag.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
        private int unitsInPage = 10;

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Users()
        {
            ViewBag.Message = "Users";
            var users = db.Reviews.ToList();
            return View(users);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CreateBook", "Something wrong!");
            }
            return View(book);
        }

        // GET: /Home/
        /*public ActionResult Index()
        {
            return View(db.Books);

        }*/

        public ActionResult DetailsBook(int Id = 1)
        {
            var book = db.Books.FirstOrDefault(x => x.Id == Id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult EditBook(int Id)
        {
            var book = db.Books.FirstOrDefault(x => x.Id == Id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.FirstOrDefault(x => x.Id == book.Id).Update(book);
                db.SaveChanges();
                return RedirectToAction("DetailsBook", "Home", new { id = book.Id });
            }
            else
            {
                ModelState.AddModelError("EditBook", "Something wrong!");
            }
            return View(book);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index(int? id)
        {
            int page = id ?? 0;
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Items", GetItemsPage(page));
            }
            return View(GetItemsPage(page));
        }

        private List<Book> GetItemsPage(int page = 1)
        {
            var itemsToSkip = page * unitsInPage;

            return db.Books.ToList().OrderBy(t => t.Id).Skip(itemsToSkip).
                Take(unitsInPage).ToList();
        }
    }
}