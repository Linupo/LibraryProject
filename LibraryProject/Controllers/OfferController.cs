using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryProject.Controllers
{
    public class OfferController : Controller
    {
        public static List<OfferModel> offers = new List<OfferModel>()
        {
            new OfferModel()
            {
                Id = 0,
                Publisher = PublisherController.publishers[0],
                Price = 57.49,
                Book = BookController.book1
            },
           new OfferModel()
            {
                Id = 1,
                Publisher = PublisherController.publishers[1],
                Price = 84.23,
                Book = BookController.book2
            },
            new OfferModel()
            {
                Id = 2,
                Publisher = PublisherController.publishers[2],
                Price = 12.87,
                Book = BookController.book3
            }
        };

        public ActionResult Index()
        {
            return View(offers);
        }

        public ActionResult Details(int id)
        {
            return View(offers[id]);
        }
    }
}