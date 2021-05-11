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
        readonly NutritionPlanDAOImpl impl = new NutritionPlanDAOImpl();
        
        // GET: NutritionPlan/CreateNutritionPlan
        public ActionResult CreateNutritionPlan()
        {
            return View();
        }


        // POST: NutritionPlan/CreateNutritionPlan
        [HttpPost]
        public ActionResult CreateNutritionPlan(NutritionPlanModel nutritionPlan)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //save data in the database 
                impl.SavePlan(nutritionPlan);
                //shows message to user if data is inserted
                ViewBag.Message = "Nutrition Plan Inserted successfully";
                //deletes the data from model
                ModelState.Clear();
            }


            return View();

        }

       
        
        // GET: NutritionPlan/ListAllPlans
        [HttpGet]
        public ActionResult ListAllPlans()
        {
            //fetch data from all nutrition plans present in the database 
            var result = impl.FindAllNutritionPlan();
            //pass the fetched data to View
            return View(result);
        }

       
        
        // GET: NutritionPlan/ListUserAllPlans
        [HttpGet]
        public ActionResult ListUserAllPlans(int User_id, long Contact, string Name)
        {
            Session["User_id"] = User_id;
            Session["Contact"] = Contact;
            Session["Name"] = Name;
            //fetch data from all nutrition plans present in the database 
            var result = impl.FindAllNutritionPlan();
            //pass the fetched data to View
            return View(result);
        }

        // GET: NutritionPlan/ChangePlan/plan_id
        public ActionResult ChangePlan(int plan_id)
        {
            //fetch data from nutrition plan having plan_id equals to NutriPlanId present in the database 
            var nutritionplan = impl.FindNutritionPlan(plan_id);
            //pass the fetched data to View
            return View(nutritionplan);

        }

        // POST: NutritionPlan/ChangePlan/plan_id
        [HttpPost]
        public ActionResult ChangePlan(NutritionPlanModel nutritionPlan)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //update data in the database based on NutriPlanId 
                impl.UpdateNutritionPlan(nutritionPlan.NutriPlanId, nutritionPlan);
                //redirect to NutritionPlan/listAllPlans
                return RedirectToAction("listAllPlans");

            }
            return View();

        }

        // GET: NutritionPlan/RemovePlan/plan_id
        public ActionResult RemovePlan(int plan_id)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //delete data in the database based on NutriPlanId 
                impl.DeleteNutritionPlan(plan_id);
                //redirect to NutritionPlan/listAllPlans
                return RedirectToAction("listAllPlans");
            }
            return View();

        }

        

    }
}