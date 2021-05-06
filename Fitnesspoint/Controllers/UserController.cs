using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fitnesspoint.Db;
using Fitnesspoint.Models;
using Fitnesspoint.Db.DbOperations;

namespace Fitnesspoint.Controllers
{
    public class UserController : Controller
    {

        //User Welcome Page with All Details of Logged in user.
        //Different links to content of the website.

        [Authorize]
        public ActionResult WelcomeUser()
        {
            string username = Session["Username"].ToString();
            UserRepository repository = new UserRepository();

            var user = repository.GetUser(username);
            Session["Id"] = user.UserId;
            Session["Name"] = user.Name;
            Session["Contact"] = user.Contact;
            return View(user);
        }
    }
}