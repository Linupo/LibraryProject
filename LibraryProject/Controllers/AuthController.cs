﻿using System;
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
        private readonly LibraryDB db = new LibraryDB();

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Auth.SetRole((int)Auth.Roles.NotLoggedIn);
            Auth.SetUserId(0);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            foreach(var user in db.Users.ToList())
            {
                if(user.Email == email && user.Password == password)
                {
                    Auth.SetUserId(user.UserId);
                    Auth.SetRole((int)Auth.Roles.LibraryUser);
                    break;
                }
            }
            foreach (var user in db.Employees.ToList())
            {
                if (user.Email == email && user.Password == password)
                {
                    Auth.SetRole((int)Auth.Roles.LibraryWorker);
                    break;
                }
            }
            foreach (var user in db.Publishers.ToList())
            {
                if (user.Email == email && user.Password == password)
                {
                    Auth.SetRole((int)Auth.Roles.Publisher);
                    break;
                }
            }
            return RedirectToAction("index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }

    public static class Auth
    {
        //Kaip naudoti autentifikacija:

        //Naudotojo rolės patikrinimas:
        //  if (Auth.GetRole() == (int)Auth.Roles.LibraryAdmin)
        //      { reiskia dabartinis vartotojas yra adminas }

        //Naudotojo rolės pakeitimas
        //  SetRole((int)Auth.Roles.LibraryAdmin);
        //Arba 
        //  SetRole(1)
        //Skaičius 1 paimtas kaip pavyzdys, gali būti naudojami ir kiti skaičiai kurie yra enum'e Roles


        public static void SetUserId(int id)
        {
            HttpContext.Current.Session["LoggedUserId"] = id;
        }

        public static int GetUserId()
        {
            object value = HttpContext.Current.Session["LoggedUserId"];
            return Convert.ToInt32(value);
        }

        public static int GetRole()
        {
            object value = HttpContext.Current.Session["Role"];
            return Convert.ToInt32(value);
        }

        public static void SetRole(int role)
        {
            HttpContext.Current.Session["Role"] = role;
        }

        public enum Roles
        {
            NotLoggedIn = 0,
            LibraryWorker = 1,
            LibraryUser = 2,
            Publisher = 3
        }
    }

}