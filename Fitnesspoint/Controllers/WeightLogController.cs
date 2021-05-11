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
        readonly WeightLogDAOImpl impl = new WeightLogDAOImpl();
        
        // GET: WeightLog/AddWeightLog
        public ActionResult AddWeightLog()
        {
           
            return View();
        }

        // POST: WeightLog/AddWeightLog
        [HttpPost]
        public ActionResult AddWeightLog(WeightLogModel weightLog)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //save data in the database 
                impl.SaveWeight(weightLog);
                //shows message to user if data is inserted
                ViewBag.Message = "Weight Inserted successfully";
                //deletes the data from model
                ModelState.Clear();
                

            }
            return View();

        }

        
        
        // GET: WeightLog/ShowAllWeightLog
        [HttpGet]
        public ActionResult ShowAllWeightLog()
        {
            //fetch data from all weightlogs present in the database 
            var result = impl.FindAllWeight();
            //pass the fetched data to View
            return View(result);
        }

        // GET: WeightLog/UpdateWeightLog/weight_id
        public ActionResult UpdateWeightLog(int weight_id)
        {
            //fetch data from weight log having weight_id equals to WeightId present in the database 
            var weightLog = impl.FindWeight(weight_id);
            //pass the fetched data to View
            return View(weightLog);

        }

        // POST: WeightLog/UpdateWeightLog/weight_id
        [HttpPost]
        public ActionResult UpdateWeightLog(WeightLogModel weightLog)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //update data in the database based on WeightId 
                impl.UpdateWeight(weightLog.WeightId, weightLog);
                //redirect to WeightLog/ShowAllWeightLog
                return RedirectToAction("ShowAllWeightLog", new { user_id=Session["Id"]});

            }
            return View();

        }


        // GET: WeightLog/RemoveWeightLog/weight_id
        public ActionResult RemoveWeightLog(int weight_id)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                //delete data in the database based on WeightId 
                impl.DeleteWeight(weight_id);
                //redirect to WeightLog/ShowAllWeightLog
                return RedirectToAction("ShowAllWeightLog", new { user_id = Session["Id"] });
            }
            return View();


        }


    }
}