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
        DietPlanDAOImpl impl = null;
        
        //Constructor
        public DietPlanController()
        {
            impl = new DietPlanDAOImpl();
        }


        // GET: DietPlan/createDietPlan
        public ActionResult createDietPlan()
        {
            return View();
        }


        // POST: DietPlan/createDietPlan
        [HttpPost]
        public ActionResult createDietPlan(DietPlanModel dietPlan)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //save data in the database 
                impl.saveDietPlan(dietPlan);
                //shows message to user if data is inserted
                ViewBag.Message = "Diet Plan Inserted successfully";
                //deletes the data from model
                ModelState.Clear();
            }


            return View();

        }

        // GET: DietPlan/listAllDietPlans
        [HttpGet]
        public ActionResult listAllDietPlans()
        {
            //fetch data from all diet plans present in the database 
            var result = impl.findAllDietPlan();
            //pass the fetched data to View
            return View(result);
        }


        //GET: DietPlan/listUserDietPlan/user_id
        public ActionResult listUserDietPlan(int user_id)
        {
            //fetch data from diet plan having UserId equals to user_id present in the database 
            var dietPlans = impl.findUserDietPlan(user_id);
            //pass the fetched data to View
            return View(dietPlans);

        }

        //GET: DietPlan/listDietPlan/diet_id
        public ActionResult listDietPlan(int diet_id)
        {
            //fetch data from diet plan having DietId equals to diet_id present in the database 
            var dietPlan = impl.findDietPlan(diet_id);
            //pass the fetched data to View
            return View(dietPlan);

        }

        //GET: DietPlan/showCalorieContent/diet_id
        public ActionResult showCalorieContent(int diet_id)
        {
            //fetch data from diet plan having DietId equals to diet_id present in the database 
            var dietPlan = impl.findDietPlan(diet_id);
            //pass the fetched data to View
            return View(dietPlan);

        }

        // GET: DietPlan/changeDietPlan/diet_id
        public ActionResult changeDietPlan(int diet_id)
        {
            //fetch data from diet plan having DietId equals to diet_id present in the database 
            var dietPlan = impl.findDietPlan(diet_id);
            //pass the fetched data to View
            return View(dietPlan);

        }

        // POST: DietPlan/changeDietPlan/diet_id
        [HttpPost]
        public ActionResult changeDietPlan(DietPlanModel dietPlan)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //update data in the database based on DietId 
                impl.updateDietPlan(dietPlan.DietId, dietPlan);
                //redirect to DietPlan/listUserDietPlan
                return RedirectToAction("listUserDietPlan", new { user_id = Session["Id"] });

            }
            return View();

        }

        // GET: DietPlan/removeDietPlan/diet_id
        public ActionResult removeDietPlan(int diet_id)
        {
            //fetch data from diet plan having DietId equals to diet_id present in the database 
            var dietPlan = impl.findDietPlan(diet_id);
            //pass the fetched data to View
            return View(dietPlan);

        }

        // POST: DietPlan/removeDietPlan/diet_id
        [HttpPost]
        public ActionResult removeDietPlan(DietPlanModel dietPlan)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //delete data in the database based on DietId 
                impl.deleteDietPlan(dietPlan.DietId, dietPlan);
                //redirect to DietPlan/listUserDietPlan
                return RedirectToAction("listUserDietPlan", new { user_id = Session["Id"] });
            }
            return View();



        }
    }
}