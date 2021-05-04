using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fitnesspoint.Controllers
{
    public class HomeController : Controller
    {
        //The very first page of Application
        //Here will be some content available and also there will be links to signup and sign in.
        public ActionResult Index()
        {
            return View();
        }

        
        
        //This provides details about what actually is the website.
        //It mentions also what are the featues of the website and what it does.
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //This page gives contact details.
        //In case user has some query with orders or anything it can reach out to customer support.

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //Here is some additional content that is being provided on the home page.
        //The purpose of these content is to motivate users towards healthy leaving.
        //Making users aware about their body and tips on handling allergies if any.
        //This content is authorized.So in order to access it user needs to have an account and user must be logged in.

        [Authorize]
        public ActionResult BodyType()
        {
            return View();
        }
        [Authorize]
        public ActionResult WorkOutIdeas()
        {
            return View();
        }
        [Authorize]
        public ActionResult AllergiesAndIntolerances()
        {
            return View();
        }
        
    }
}