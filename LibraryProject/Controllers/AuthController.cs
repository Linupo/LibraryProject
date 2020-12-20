using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.DataAccess;
using LibraryProject.Models;

namespace LibraryProject.Controllers
{
    public class AuthController : Controller
    {


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                string sql = @"INSERT INTO Users (FirstName, LastName, PersonalCode, Email, Password, IsActive, Birthday)
                               VALUES (@FirstName, @LastName, @PersonalCode, @Email, @Password, 1, @Birthday);";
                SqlDataAccess.SaveData(sql, model);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}