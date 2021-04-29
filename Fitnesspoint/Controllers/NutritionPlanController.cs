using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fitnesspoint.Models;
using Fitnesspoint.Db.DbOperations;

namespace Fitnesspoint.Controllers
{
    public class NutritionPlanController : Controller
    {
        NutritionPlanDAOImpl impl = null;
        
        
        //CONSTRUCTOR
        public NutritionPlanController()
        {
            impl = new NutritionPlanDAOImpl();
        }

        
        // GET: NutritionPlan/createNutritionPlan
        public ActionResult createNutritionPlan()
        {
            return View();
        }


        // POST: NutritionPlan/createNutritionPlan
        [HttpPost]
        public ActionResult createNutritionPlan(NutritionPlanModel nutritionPlan)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //save data in the database 
                impl.savePlan(nutritionPlan);
                //shows message to user if data is inserted
                ViewBag.Message = "Nutrition Plan Inserted successfully";
                //deletes the data from model
                ModelState.Clear();
            }


            return View();

        }

       
        
        // GET: NutritionPlan/listAllPlans
        [HttpGet]
        public ActionResult listAllPlans()
        {
            //fetch data from all nutrition plans present in the database 
            var result = impl.findAllNutritionPlan();
            //pass the fetched data to View
            return View(result);
        }

       
        
        // GET: NutritionPlan/listUserAllPlans
        [HttpGet]
        public ActionResult listUserAllPlans()
        {
            //fetch data from all nutrition plans present in the database 
            var result = impl.findAllNutritionPlan();
            //pass the fetched data to View
            return View(result);
        }

        //GET: NutritionPlan/listPlan/plan_id
        public ActionResult listPlan(int plan_id)
        {
            //fetch data from nutrition plan having NutriPlanId equals to plan_id present in the database 
            var nutritionplan = impl.findNutritionPlan(plan_id);
            //pass the fetched data to View
            return View(nutritionplan);

        }

        // GET: NutritionPlan/changePlan/plan_id
        public ActionResult changePlan(int plan_id)
        {
            //fetch data from nutrition plan having NutriPlanId equals to plan_id present in the database 
            var nutritionplan = impl.findNutritionPlan(plan_id);
            //pass the fetched data to View
            return View(nutritionplan);

        }

        // POST: NutritionPlan/changePlan/plan_id
        [HttpPost]
        public ActionResult changePlan(NutritionPlanModel nutritionPlan)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //update data in the database based on NutriPlanId 
                impl.updateNutritionPlan(nutritionPlan.NutriPlanId, nutritionPlan);
                //redirect to NutritionPlan/listAllPlans
                return RedirectToAction("listAllPlans");

            }
            return View();

        }

        // GET: NutritionPlan/removePlan/plan_id
        public ActionResult removePlan(int plan_id)
        {
            //fetch data from nutrition plan having NutriPlanId equals to plan_id present in the database 
            var nutritionplan = impl.findNutritionPlan(plan_id);
            //pass the fetched data to View
            return View(nutritionplan);

        }

        // POST: NutritionPlan/removePlan/plan_id
        [HttpPost]
        public ActionResult removePlan(NutritionPlanModel nutritionPlan)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //delete data in the database based on NutriPlanId 
                impl.deleteNutritionPlan(nutritionPlan.NutriPlanId, nutritionPlan);
                //redirect to NutritionPlan/listAllPlans
                return RedirectToAction("listAllPlans");
            }
            return View();



        }


    }
}