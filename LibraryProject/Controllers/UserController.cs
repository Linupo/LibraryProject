using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.DataAccess;
using LibraryProject.Models;

namespace LibraryProject.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            string sql = @"SELECT * FROM dbo.Users;";
            List<UserModel> users = SqlDataAccess.LoadData<UserModel>(sql);

            return View(users);
        }
    }
}