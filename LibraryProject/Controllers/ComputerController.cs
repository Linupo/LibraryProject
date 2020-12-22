using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LibraryProject.DataAccess;
using LibraryProject.Models;

namespace LibraryProject.Controllers
{
    public class ComputerController : Controller
    {
        private readonly LibraryDB db = new LibraryDB();
        // GET: Index
        public ActionResult Index()
        {
            var reservations = db.Reservations.ToList();
            var reservedIds = new List<int>();
            foreach (var reservation in reservations)
            {
                foreach (var computer in reservation.Computers)
                {
                    reservedIds.Add(computer.ComputerId);
                }
            }
            var filteredComputers = new List<Computer>();
            foreach (var computer in db.Computers.ToList())
            {
                if (!reservedIds.Contains(computer.ComputerId))
                    filteredComputers.Add(computer);
            }
            return View(filteredComputers);
        }

        // GET: Reserve
        public ActionResult Reserve(int id)
        {
            Computer computer = db.Computers.Find(id);
            PopulateData(computer);
            return View(computer);
        }

        // POST: Reserve
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reserve(int id, string d)
        {
            Reservation res = new Reservation();
            var computer = db.Computers.Find(id);
            res.Computers.Add(computer);
            res.StartDate = DateTime.Now;
            res.EndDate = DateTime.Now.AddDays(1);
            res.UserId = Auth.GetUserId();
            db.Reservations.Add(res);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            Computer computer = db.Computers.Find(id);
            PopulateData(computer);
            return View(computer);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Computer computer)
        {
            if (ModelState.IsValid)
            {
                var old = db.Computers.Find(computer.ComputerId);
                db.Entry(old).CurrentValues.SetValues(computer);
                db.SaveChanges();
            }
            PopulateData(computer);
            return RedirectToAction("Index");
        }

        // GET: Delete
        public ActionResult Delete(int id)
        {
            Computer computer = db.Computers.Find(id);
            PopulateData(computer);
            return View(computer);
        }

        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, string d)
        {
            var toBeRemoved = db.Computers.Find(id);
            db.Computers.Remove(toBeRemoved);
            db.SaveChanges();
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
        public ActionResult Create(Computer computer)
        {
            if (ModelState.IsValid)
            {
                db.Computers.Add(computer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateData(computer);
            return View();
        }
        private void PopulateData(object selectedBook = null)
        {
            var libraryQuery = from l in db.Libraries select l;
            ViewBag.LibraryId = new SelectList(libraryQuery, "LibraryId", "Name", selectedBook);
        }
    }
}