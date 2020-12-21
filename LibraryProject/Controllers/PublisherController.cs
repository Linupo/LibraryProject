using LibraryProject.DataAccess;
using LibraryProject.Models;
using System.Linq;
using System.Web.Mvc;

namespace LibraryProject.Controllers
{
    public class PublisherController : Controller
    {
        private readonly LibraryDB db = new LibraryDB();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Publishers.Add(publisher);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Index()
        {
            return View(db.Publishers.ToList());
        }
    }
}
