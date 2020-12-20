﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            LibraryAdmin = 1,
            LibraryWorker = 2,
            LibraryUser = 3
        }
    }

}