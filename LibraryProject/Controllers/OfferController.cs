using System.Linq;
using System.Web.Mvc;
using LibraryProject.DataAccess;

namespace LibraryProject.Controllers
{
    public class OfferController : Controller
    {
        private readonly LibraryDB db = new LibraryDB();

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View(db.Offers.Find(id));
        }

        public ActionResult Details(int id)
        {
            return View(db.Offers.Find(id));
        }

        public ActionResult Edit(int id)
        {
            return View(db.Offers.Find(id));
        }

        public ActionResult Index()
        {
            return View(db.Offers.ToList());
        }
    }
}
