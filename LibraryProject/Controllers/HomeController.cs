using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var role = Auth.GetRole();
            if (role != (int)Auth.Roles.LibraryUser && role != (int)Auth.Roles.LibraryWorker && role != (int)Auth.Roles.Publisher)
                Auth.SetRole((int)Auth.Roles.NotLoggedIn);
            return View();
        }
    }
}