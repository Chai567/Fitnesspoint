using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fitnesspoint.Models;
using Fitnesspoint.Db;
using Fitnesspoint.Db.DbOperations;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;

namespace Fitnesspoint.Controllers
{
    public class AccountController : Controller
    {
        
        // Getting the view of registeration page.
        //Here two lists of strings are passed for drowpdowns.
        //In the view Gender and Goal are dropdowns.The content of these lists is rendered under gender and goal respectively. 
        //We pass the List objects to view using ViewBag.
        public ActionResult Register()
        {
            var List = new List<string>()
            {
                "Male","Female","Other"
            };
            ViewBag.List = List;

            var List2 = new List<string>()
            {
                "Weight Loss","Muscle Gain","Abs"
            };
            ViewBag.List2 = List2;

            return View();

        }

        //This is a post method for registeration.
        //When user is done filling information as per the validations and hits signup.
        //All the filled in info then will be posted into the Userdetails table.
        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            UserRepository Repository = new UserRepository();

            model.Role = "User";

            bool checkUsername = Repository.UsernameExits(model);
            if (ModelState.IsValid)
            {

                if (checkUsername)
                {
                    int id = Repository.AddUser(model);
                    ViewBag.Message = "You are registered";
                    ModelState.Clear();

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    Session["check"] = checkUsername;
                    ViewBag.Error = "Username is already taken";
                    //ModelState.AddModelError("", "Username is already taken");
                }
            }
            var List = new List<string>()
            {
                "Male","Female","Other"
            };
            ViewBag.List = List;
            var List2 = new List<string>()
            {
                "Weight Loss","Muscle Gain","Abs"
            };
            ViewBag.List2 = List2;

            return View();

        }


        //Getting the view of log in page.
        public ActionResult Login()
        {

            return View();
        }

        //This is the post method of login.User enters the username and password.
        //Then these credentials are matched against entries in Userdetails table.
        //If matched User is redirected to the desired page.
        [HttpPost]
        public ActionResult Login(UserModel model)
        {


            using (var context = new FitnesspointDatabaseEntities())
            {
                bool isvalid = context.UserDetails.Any(x => x.Username == model.Username && x.Password == model.Password && x.Role == "User");

                bool valid = context.UserDetails.Any(x => x.Username == model.Username && x.Password == model.Password && x.Role == "Admin");

                if (isvalid)
                {
                    
                    Session["Username"] = model.Username.ToString();
                   
                    FormsAuthentication.SetAuthCookie(model.Username.ToString(), false);
                    
                    return RedirectToAction("WelcomeUser", "User");
                }
                else
                {
                    if (valid)
                    {

                        FormsAuthentication.SetAuthCookie(model.Username, false);
                        
                        return (RedirectToAction("Adminview", "Admin"));
                    }
                    else
                    {
                        ModelState.AddModelError("", "You entered incorrect username or password");
                    }

                }




            }
            return View();
        }


        //This is the logout method.
        //As soon as user log in into application.
        //User will have a link to log out.
        //if User hits that logout he will be again redirected to login page.

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Account");
        }



    }
}