using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LibraryProject.DataAccess;
using LibraryProject.Models;

namespace LibraryProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly LibraryDB db = new LibraryDB();

        public ActionResult Delete(int id)
        {
            var toBeRemoved = db.Employees.Find(id);
            db.Employees.Remove(toBeRemoved);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(db.Employees.Find(id));
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            Employee employee = db.Employees.Find(id);
            PopulateData(employee);
            return View(employee);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var old = db.Employees.Find(employee.EmployeeId);
                db.Entry(old).CurrentValues.SetValues(employee);
                db.SaveChanges();
            }
            PopulateData(employee);
            return RedirectToAction("Index");
        }

        // GET: Create
        public ActionResult Create()
        {
            PopulateData();
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateData(employee);
            return View();
        }

        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }




        public ActionResult ViewRequestsToLeave()
        {
            return View();
        }

        public ActionResult EditWorkerForm()
        {
            return View();
        }

        public ActionResult ConfirmLeave()
        {
            return View();
        }

        public ActionResult PublisherCreate()
        {
            return View();
        }

        private void PopulateData(object selectedBook = null)
        {
            var libraryQuery = from l in db.Libraries select l;
            ViewBag.LibraryId = new SelectList(libraryQuery, "LibraryId", "Name", selectedBook);
        }

    }
}
