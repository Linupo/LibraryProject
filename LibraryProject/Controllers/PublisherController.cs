using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryProject.Controllers
{
    public class PublisherController : Controller
    {
        public static List<PublisherModel> publishers = new List<PublisherModel>()
        {
            new PublisherModel()
            {
                Id = 0,
                Title = "Pegasas",
                Address = "Karaliaus Mindaugo pr. 49, 4333 Kaunas"
            },
           new PublisherModel()
            {
                Id = 1,
                Title = "Obuolys",
                Address = "Maironio g. 6-1, LT-44302 Kaunas"
            },
            new PublisherModel()
            {
                Id = 2,
                Title = "Vaga",
                Address = "Gedimino pr. 50, LT-01110 Vilnius"
            }
        };

        public ActionResult Index()
        {
            return View();
        }
    }
}