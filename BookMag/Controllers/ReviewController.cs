using BookMag.Models;
using System.Linq;
using System.Web.Mvc;

namespace BookMag.Controllers
{
    public class ReviewController : Controller
    {

        BookContext db = new BookContext();

        public ActionResult Create(int BookId, string Name)
        {
            if (db.Books.All(x => x.Id != BookId))
                return HttpNotFound();
            var reviews = new BookReview() { BookId = BookId, Name = Name };
            return View(reviews);
        }

        [HttpPost]
        public ActionResult Create(BookReview reviews)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(reviews);
                db.SaveChanges();
                return RedirectToAction("DetailsBook", "Home", new { id = reviews.BookId });
            }
            else
            {
                ModelState.AddModelError("Create", "Something wrong!");
            }
            return View(reviews);
        }

        [HttpPost]
        public void AddReport(int reviewId, string reason)
        {
            var review = db.Reviews.FirstOrDefault(x => x.Id == reviewId);
            if (review == null)
            {
                Response.StatusCode = 404;
                return;
            }

            review.IsOffensive = true;
            review.ReportReason = reason;
            db.SaveChanges();
        }

        [HttpPost]
        public int AddLike(int reviewId)
        {
            var review = db.Reviews.FirstOrDefault(x => x.Id == reviewId);
            if (review == null)
            {
                Response.StatusCode = 404;
                return -1;
            }

            ++review.Likes;
            db.SaveChanges();

            return review.Likes;
        }
    }
}

