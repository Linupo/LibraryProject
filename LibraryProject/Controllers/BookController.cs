using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LibraryProject.DataAccess;
using LibraryProject.Models;

namespace LibraryProject.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryDB db = new LibraryDB();

        public ActionResult Index(string sortOrder)
        {
            ViewBag.TitleSortParam = string.IsNullOrEmpty(sortOrder) ? "title" : "title_desc";
            ViewBag.AuthorSortParam = string.IsNullOrEmpty(sortOrder) ? "author" : "author_desc";
            ViewBag.YearSortParam = string.IsNullOrEmpty(sortOrder) ? "year" : "year_desc";

            if (sortOrder != null)
            {
                if (sortOrder.Contains("title"))
                {
                    ViewBag.TitleSortParam = sortOrder.Contains("desc") ? "title" : "title_desc";
                    ViewBag.AuthorSortParam = null;
                    ViewBag.YearSortParam = null;
                }
                else if (sortOrder.Contains("author"))
                {
                    ViewBag.TitleSortParam = null;
                    ViewBag.AuthorSortParam = sortOrder.Contains("desc") ? "author" : "author_desc";
                    ViewBag.YearSortParam = null;
                }
                else if (sortOrder.Contains("year"))
                {
                    ViewBag.TitleSortParam = null;
                    ViewBag.AuthorSortParam = null;
                    ViewBag.YearSortParam = sortOrder.Contains("desc") ? "year" : "year_desc";
                }
            }

            var books = from b in db.Books select b;

            switch (sortOrder)
            {
                case "title":
                    books = books.OrderBy(book => book.Title);
                    break;

                case "title_desc":
                    books = books.OrderByDescending(book => book.Title);
                    break;

                case "author":
                    books = books.OrderBy(book => book.Author.FirstName + book.Author.LastName);
                    break;

                case "author_desc":
                    books = books.OrderByDescending(book => book.Author.FirstName + book.Author.LastName);
                    break;

                case "year":
                    books = books.OrderBy(book => book.YearWritten);
                    break;

                case "year_desc":
                    books = books.OrderByDescending(book => book.YearWritten);
                    break;
            }

            return View(books.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var book = db.Books.Find(id);

            if (book == null)
                return HttpNotFound();

            return View(book);
        }

        public ActionResult Edit(int id)
        {
            return View(db.Books.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                var old = db.Books.Find(book.BookId);
                db.Entry(old).CurrentValues.SetValues(book);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Reserve(int id)
        {
            Reservation res = new Reservation();
            var book = db.Books.Find(id);
            res.Books.Add(book);
            res.StartDate = DateTime.Now;
            res.EndDate = DateTime.Now.AddMonths(1);
            res.UserId = Auth.GetUserId();
            db.Reservations.Add(res);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var toBeRemoved = db.Books.Find(id);
            db.Books.Remove(toBeRemoved);
            db.SaveChanges();
            return RedirectToAction("Index");
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

        public ActionResult FreeBooks()
        {
            var reservations = db.Reservations.ToList();
            var reservedIds = new List<int>();
            foreach (var reservation in reservations)
            {
                foreach (var book in reservation.Books)
                {
                    reservedIds.Add(book.BookId);
                }
            }
            var filteredBooks = new List<Book>();
            foreach (var book in db.Books.ToList())
            {
                if (!reservedIds.Contains(book.BookId))
                    filteredBooks.Add(book);
            }
            return View(filteredBooks);
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
