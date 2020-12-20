using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.DataAccess;

namespace LibraryProject.Controllers
{
    public class BookController : Controller
    {
        public ActionResult Index()
        {
            string sql = "SELECT * FROM Books";
            List<BookModel> bookList = SqlDataAccess.LoadData<BookModel>(sql);
            return View(bookList);
        }

        public ActionResult Details(int id)
        {
            string sql = string.Format("SELECT * FROM Books WHERE id = {0}", id);
            List<BookModel> bookList = SqlDataAccess.LoadData<BookModel>(sql);
            return View(bookList[0]);
        }

        public ActionResult Delete(int id)
        {
            string sql = string.Format("DELETE FROM Books WHERE id = {0};", id);
            SqlDataAccess.Execute(sql);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            string sql = string.Format("SELECT * FROM Books WHERE id = {0}", id);
            List<BookModel> bookList = SqlDataAccess.LoadData<BookModel>(sql);
            return View(bookList[0]);
        }

        public ActionResult Update(int id)
        {
            string sql = string.Format("SELECT * FROM Books WHERE id = {0}", id);
            List<BookModel> bookList = SqlDataAccess.LoadData<BookModel>(sql);
            return View(bookList[0]);
        }

        public ActionResult Create()
        {
            return View();
        }
        
    }
}
