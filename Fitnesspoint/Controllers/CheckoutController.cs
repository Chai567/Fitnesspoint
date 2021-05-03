﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fitnesspoint.Db;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Fitnesspoint.Controllers
{
    public class CheckoutController : Controller
    {
        private FitnesspointDatabaseEntities db = new FitnesspointDatabaseEntities();
        // GET: Checkout
        [Authorize]
        public ActionResult Index(int User_id, int Plan_id, string Plan_name, int Amount, long Contact, string Name)
        {
            ViewData["Plan_id"] = Plan_id;
            ViewData["Plan_name"] = Plan_name;
            ViewData["Amount"] = Amount;

            ViewData["Contact"] = Contact;
            ViewData["User_id"] = User_id;
            ViewData["Name"] = Name;
            return View();
        }

        [Authorize]
        public ActionResult ProceedToPay(int User_id, int Plan_id, string Plan_name, int Amount, long Contact)
        {
            ViewData["Plan_id"] = Plan_id;
            ViewData["Plan_name"] = Plan_name;
            ViewData["Amount"] = Amount;

            ViewData["Contact"] = Contact;
            ViewData["User_id"] = User_id;
            

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult FinalPay()
        {
            int User_id = Convert.ToInt32(Request.Params["User_id"]);
            int Plan_id = Convert.ToInt32(Request.Params["Plan_id"]);
            string Plan_name = Request.Params["Plan_name"].ToString();
            int Amount = Convert.ToInt32(Request.Params["Amount"]);
            TempData["Plan_id"] = Plan_id;
            TempData["Plan_name"] = Plan_name;
            TempData["Amount"] = Amount;
            TempData["User_id"] = User_id;
            
            return(RedirectToAction("Paid","Checkout"));
 
        }

        [Authorize]
        public ActionResult Paid()
        {
            using(var context = new FitnesspointDatabaseEntities())
            {
                PaymentTbl Pay = new PaymentTbl()
                {
                    User_id =(int)TempData["User_id"],
                    Plan_id=(int)TempData["Plan_id"],
                    Plan_name=TempData["Plan_name"].ToString(),
                    Amount=(int)TempData["Amount"]
                };
                context.PaymentTbls.Add(Pay);
                context.SaveChanges();
                int Order_id= Pay.Order_id;
                Session["orderid"] = Order_id;
            }
            return View();
        }


        

    }
}