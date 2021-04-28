using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fitnesspoint.Models;
using Fitnesspoint.Db.DbOperations;

namespace Fitnesspoint.Controllers
{
    public class WeightLogController : Controller
    {
        WeightLogDAOImpl impl = null;
        public WeightLogController()
        {
            impl = new WeightLogDAOImpl();
        }

        // GET: WeightLog/addWeightLog
        public ActionResult addWeightLog()
        {
           
            return View();
        }

        // POST: WeightLog/addWeightLog
        [HttpPost]
        public ActionResult addWeightLog(WeightLogModel weightLog)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //save data in the database 
                impl.saveWeight(weightLog);
                //shows message to user if data is inserted
                ViewBag.Message = "Weight Inserted successfully";
                //deletes the data from model
                ModelState.Clear();

            }
            return View();

        }

        // GET: WeightLog/showAllWeightLog
        [HttpGet]
        public ActionResult showAllWeightLog()
        {
            //fetch data from all weightlogs present in the database 
            var result = impl.findAllWeight();
            //pass the fetched data to View
            return View(result);
        }

        // GET: WeightLog/showUserWeightLog/user_id
        public ActionResult showUserWeightLog(int user_id)
        {
            //fetch data from weight log having UserId equals to user_id present in the database 
            var weightLogs = impl.findUserWeight(user_id);
            //pass the fetched data to View
            return View(weightLogs);

        }

        // GET: WeightLog/showWeightLog/weight_id
        public ActionResult showWeightLog(int weight_id)
        {
            //fetch data from weight log having WeightId equals to weight_id present in the database 
            var weightLog = impl.findWeight(weight_id);
            //pass the fetched data to View
            return View(weightLog);

        }

        // GET: WeightLog/updateWeightLog/weight_id
        public ActionResult updateWeightLog(int weight_id)
        {
            //fetch data from weight log having WeightId equals to weight_id present in the database 
            var weightLog = impl.findWeight(weight_id);
            //pass the fetched data to View
            return View(weightLog);

        }

        // POST: WeightLog/updateWeightLog/weight_id
        [HttpPost]
        public ActionResult updateWeightLog(WeightLogModel weightLog)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //update data in the database based on WeightId 
                impl.updateWeight(weightLog.WeightId, weightLog);
                //redirect to WeightLog/showUserWeightLog
                return RedirectToAction("showUserWeightLog",new { user_id=Session["Id"]});

            }
            return View();

        }


        // GET: WeightLog/removeWeightLog/weight_id
        public ActionResult removeWeightLog(int weight_id)
        {
            //fetch data from weight log having WeightId equals to weight_id present in the database 
            var weightLog = impl.findWeight(weight_id);
            //pass the fetched data to View
            return View(weightLog);

        }

        // POST: WeightLog/removeWeightLog/weight_id
        [HttpPost]
        public ActionResult removeWeightLog(WeightLogModel weightLog)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //delete data in the database based on WeightId 
                impl.deleteWeight(weightLog.WeightId, weightLog);
                
                return RedirectToAction("showUserWeightLog", new { user_id = Session["Id"] });
            }
            return View();



        }


    }
}