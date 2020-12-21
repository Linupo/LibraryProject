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

        public ActionResult Delete(int id)
        {
            var toBeRemoved = db.Books.Find(id);
            db.Books.Remove(toBeRemoved);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
