using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fitnesspoint.Controllers
{
    public class HomeController : Controller
    {
        //First Page of Application
        public ActionResult Index()
        {
            return View();
        }

        //About Web application
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //contact details 
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Methods for displaying Read More stuff on Home page
        public ActionResult BodyType()
        {
            return View();
        }

        public ActionResult WorkOutIdeas()
        {
            return View();
        }
    }
}