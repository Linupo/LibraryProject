using System;
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
            bool isCurrentlyReserved = false;
            foreach(var reservation in db.Reservations.ToList())
            {
                if(reservation.StartDate<DateTime.Now && reservation.EndDate>DateTime.Now)
                {
                    foreach(var bookInstance in reservation.Books)
                    {
                        if (bookInstance.BookId == id)
                            isCurrentlyReserved = true;
                    }
                }
            }
            if(!isCurrentlyReserved)
            {
                Reservation res = new Reservation();
                var book = db.Books.Find(id);
                res.Books.Add(book);
                res.StartDate = DateTime.Now;
                res.EndDate = DateTime.Now.AddMonths(1);
                res.UserId = Auth.GetUserId();
                db.Reservations.Add(res);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult ReserveForUser(int id, int userId)
        {
            bool isCurrentlyReserved = false;
            foreach (var reservation in db.Reservations.ToList())
            {
                if (reservation.StartDate < DateTime.Now && reservation.EndDate > DateTime.Now)
                {
                    foreach (var bookInstance in reservation.Books)
                    {
                        if (bookInstance.BookId == id)
                            isCurrentlyReserved = true;
                    }
                }
            }
            if (!isCurrentlyReserved)
            {
                Reservation res = new Reservation();
                var book = db.Books.Find(id);
                res.Books.Add(book);
                res.StartDate = DateTime.Now;
                res.EndDate = DateTime.Now.AddMonths(1);
                res.UserId = userId;
                db.Reservations.Add(res);
                db.SaveChanges();
            }
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
                if(reservation.StartDate<DateTime.Now && reservation.EndDate>DateTime.Now)
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
