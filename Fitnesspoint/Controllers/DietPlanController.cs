﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fitnesspoint.Models;
using Fitnesspoint.Db.DbOperations;
namespace Fitnesspoint.Controllers
{
    public class DietPlanController : Controller
    {
        readonly DietPlanDAOImpl impl = null;
        
        //Constructor
        public DietPlanController()
        {
            impl = new DietPlanDAOImpl();
        }


        // GET: DietPlan/createDietPlan
        public ActionResult CreateDietPlan()
        {
            return View();
        }


        // POST: DietPlan/createDietPlan
        [HttpPost]
        public ActionResult CreateDietPlan(DietPlanModel dietPlan)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //save data in the database 
                impl.SaveDietPlan(dietPlan);
                //shows message to user if data is inserted
                ViewBag.Message = "Diet Plan Inserted successfully";
                //deletes the data from model
                ModelState.Clear();
            }


            return View();

        }

        // GET: DietPlan/listAllDietPlans
        [HttpGet]
        public ActionResult ListAllDietPlans()
        {
            //fetch data from all diet plans present in the database 
            var result = impl.FindAllDietPlan();
            //pass the fetched data to View
            return View(result);
        }


        //GET: DietPlan/listUserDietPlan/user_id
        public ActionResult ListUserDietPlan(int user_id)
        {
            //fetch data from diet plan having UserId equals to user_id present in the database 
            var dietPlans = impl.FindUserDietPlan(user_id);
            //pass the fetched data to View
            return View(dietPlans);

        }

        //GET: DietPlan/listDietPlan/diet_id
        public ActionResult ListDietPlan(int diet_id)
        {
            //fetch data from diet plan having DietId equals to diet_id present in the database 
            var dietPlan = impl.FindDietPlan(diet_id);
            //pass the fetched data to View
            return View(dietPlan);

        }

        //GET: DietPlan/showCalorieContent/diet_id
        public ActionResult ShowCalorieContent(int diet_id)
        {
            //fetch data from diet plan having DietId equals to diet_id present in the database 
            var dietPlan = impl.FindDietPlan(diet_id);
            //pass the fetched data to View
            return View(dietPlan);

        }

        // GET: DietPlan/changeDietPlan/diet_id
        public ActionResult ChangeDietPlan(int diet_id)
        {
            //fetch data from diet plan having DietId equals to diet_id present in the database 
            var dietPlan = impl.FindDietPlan(diet_id);
            //pass the fetched data to View
            return View(dietPlan);

        }

        // POST: DietPlan/changeDietPlan/diet_id
        [HttpPost]
        public ActionResult ChangeDietPlan(DietPlanModel dietPlan)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //update data in the database based on DietId 
                impl.UpdateDietPlan(dietPlan.DietId, dietPlan);
                //redirect to DietPlan/listUserDietPlan
                return RedirectToAction("listUserDietPlan", new { user_id = Session["Id"] });

            }
            return View();

        }

        // GET: DietPlan/removeDietPlan/diet_id
        public ActionResult RemoveDietPlan(int diet_id)
        {
            //fetch data from diet plan having DietId equals to diet_id present in the database 
            var dietPlan = impl.FindDietPlan(diet_id);
            //pass the fetched data to View
            return View(dietPlan);

        }

        // POST: DietPlan/removeDietPlan/diet_id
        [HttpPost]
        public ActionResult RemoveDietPlan(DietPlanModel dietPlan)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //delete data in the database based on DietId 
                impl.DeleteDietPlan(dietPlan.DietId, dietPlan);
                //redirect to DietPlan/listUserDietPlan
                return RedirectToAction("listUserDietPlan", new { user_id = Session["Id"] });
            }
            return View();



        }
    }
}