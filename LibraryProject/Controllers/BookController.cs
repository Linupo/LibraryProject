using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LibraryProject.DataAccess;
using LibraryProject.Models;

namespace LibraryProject.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryDB db = new LibraryDB();

        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        public ActionResult Details(int id)
        {
            return View(db.Books.Find(id));
        }

        public ActionResult Create()
        {
            PopulateBookDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateBookDropdowns(book);
            return View();
        }

        private void PopulateBookDropdowns(object selectedBook = null)
        {
            var libraryQuery = from l in db.Libraries select l;
            ViewBag.LibraryId = new SelectList(libraryQuery, "LibraryId", "Name", selectedBook);

            var publisherQuery = from p in db.Publishers select p;
            ViewBag.PublisherId = new SelectList(publisherQuery, "PublisherId", "Name", selectedBook);

            var authorQuery = from a in db.Authors select a;
            ViewBag.AuthorId = new SelectList(authorQuery, "AuthorId", "FullName", selectedBook);

            var genreQuery = from g in db.Genres select g;
            ViewBag.GenreId = new SelectList(genreQuery, "GenreId", "Name", selectedBook);

            var conditionQuery = from c in db.Conditions select c;
            ViewBag.ConditionId = new SelectList(conditionQuery, "ConditionId", "Name", selectedBook);
        }
    }
}
