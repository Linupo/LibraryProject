using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LibraryProject.DataAccess;
using LibraryProject.Models;

namespace LibraryProject.Controllers
{
    public class VacationController : Controller
    {
        private readonly LibraryDB db = new LibraryDB();

        public ActionResult Delete(int id)
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            return View();
        }

      

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

       

        public ActionResult Index()
        {
            return View(db.Vacations.ToList());
        }




        public ActionResult ViewRequestsToLeave()
        {
            return View(db.Vacations.ToList());
        }

        public ActionResult EditWorkerForm()
        {
            return View();
        }

       

       

    }
}
