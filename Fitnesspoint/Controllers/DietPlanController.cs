using System;
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
        readonly DietPlanDAOImpl impl = new DietPlanDAOImpl();

        // GET: DietPlan/CreateDietPlan
        public ActionResult CreateDietPlan()
        {
            return View();
        }
        // POST: DietPlan/CreateDietPlan
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

        // GET: DietPlan/ListAllDietPlans
        [HttpGet]
        public ActionResult ListAllDietPlans()
        {
            //fetch data from all diet plans present in the database 
            var result = impl.FindAllDietPlan();
            //pass the fetched data to View
            return View(result);
        }

        //GET: DietPlan/ShowCalorieContent/diet_id
        public ActionResult ShowCalorieContent(int diet_id)
        {
            //fetch data from diet plan having diet_id equals to DietId present in the database 
            var dietPlan = impl.FindDietPlan(diet_id);
            //pass the fetched data to View
            return View(dietPlan);

        }

        // GET: DietPlan/ChangeDietPlan/diet_id
        public ActionResult ChangeDietPlan(int diet_id)
        {
            //fetch data from diet plan having diet_id equals to DietId present in the database 
            var dietPlan = impl.FindDietPlan(diet_id);
            //pass the fetched data to View
            return View(dietPlan);

        }

        // POST: DietPlan/ChangeDietPlan/diet_id
        [HttpPost]
        public ActionResult ChangeDietPlan(DietPlanModel dietPlan)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //update data in the database based on DietId 
                impl.UpdateDietPlan(dietPlan.DietId, dietPlan);
                //redirect to DietPlan/ListAllDietPlans
                return RedirectToAction("ListAllDietPlans", new { user_id = Session["Id"] });

            }
            return View();

        }

        // GET: DietPlan/RemoveDietPlan/diet_id
        
        public ActionResult RemoveDietPlan(int diet_id)
        {
            //fetch data from diet plan having diet_id equals to DietId present in the database 
            if (ModelState.IsValid)
            {
                //delete data in the database based on DietId 
                impl.DeleteDietPlan(diet_id);
                //redirect to DietPlan/ListAllDietPlans
                return RedirectToAction("ListAllDietPlans", new { user_id = Session["Id"] });
            }
            return View();

        }
       
    }
}