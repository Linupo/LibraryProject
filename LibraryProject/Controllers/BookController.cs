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
            var libraries = db.Libraries.ToList();
            var publishers = db.Publishers.ToList();
            var authors = db.Authors.ToList();
            var genres = db.Genres.ToList();
            var conditions = db.Conditions.ToList();

            Book book = new Book
            {
                Libraries = libraries,
                Publishers = publishers,
                Authors = authors,
                Genres = genres,
                Conditions = conditions
            };

            return View(book);
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
