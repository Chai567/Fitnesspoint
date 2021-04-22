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
        

        UserRepository Repository = null;


        //CONSTRUCTOR

        public AccountController()
        {
            Repository = new UserRepository();

        }


        // REGISTERATION OF A USER
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

        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            model.Role = "User";

            if (ModelState.IsValid)
            {
                int id = Repository.AddUser(model);
                if (id > 0)
                {
                    ModelState.Clear();

                }
                return RedirectToAction("Login", "Home");
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


        // GET LOGIN VIEW
        public ActionResult Login()
        {

            return View();
        }

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
                    ViewBag.Message = "User";
                    FormsAuthentication.SetAuthCookie(model.Username.ToString(), false);
                    
                    return RedirectToAction("Welcome", "User");
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


        //LOGOUT

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Account");
        }



    }
}