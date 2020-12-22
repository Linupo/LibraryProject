using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LibraryProject.DataAccess;
using LibraryProject.Models;

namespace LibraryProject.Controllers
{
    public class OfferController : Controller
    {
        private readonly LibraryDB db = new LibraryDB();

        public ActionResult Create()
        {
            PopulateOfferDropdowns();
            return View();
        }

        public ActionResult Accept(int id)
        {
            db.Offers.Find(id).Status = db.Statuses.Find(2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            db.Offers.Remove(db.Offers.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
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
            var offers = from o in db.Offers select o;
            if (Auth.GetRole() == (int)Auth.Roles.Publisher)
            {
                int id = Auth.GetUserId();
                offers = offers.Where(o => o.PublisherId == id);
            }
            return View(offers.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Offer offer)
        {
            if (ModelState.IsValid)
            {
                offer.PublisherId = Auth.GetUserId();
                offer.StatusId = 1;
                offer.StartDate = DateTime.Now;
                db.Offers.Add(offer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateOfferDropdowns(offer);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Offer offer)
        {
            if (ModelState.IsValid)
            {
                var old = db.Offers.Find(offer.OfferId);
                old.Price = offer.Price;
                old.Amount = offer.Amount;
                old.EndDate = offer.EndDate;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        private void PopulateOfferDropdowns(object selectedOffer = null)
        {
            var libraryQuery = from l in db.Libraries select l;
            ViewBag.LibraryId = new SelectList(libraryQuery, "LibraryId", "Name", selectedOffer);

            var bookQuery = from b in db.Books select b;
            ViewBag.BookId = new SelectList(bookQuery, "BookId", "ISBN", selectedOffer);
        }
    }
}
