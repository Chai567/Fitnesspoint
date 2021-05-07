using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fitnesspoint.Db;

namespace Fitnesspoint.Controllers
{
    public class WeightLogController : Controller
    {
        private readonly FitnesspointDatabaseEntities db = new FitnesspointDatabaseEntities();

        // GET: WeightLog/addWeightLog
        public ActionResult AddWeightLog()
        {
           
            return View();
        }

        // POST: WeightLog/addWeightLog
        [HttpPost]
        public ActionResult AddWeightLog(WeightLog weightLog)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                weightLog.Created_At = DateTime.UtcNow;
                weightLog.Updated_At = DateTime.UtcNow;
                //save data in the database 
                db.WeightLogs.Add(weightLog);
                //shows message to user if data is inserted
                ViewBag.Message = "Weight Inserted successfully";
                //deletes the data from model
                ModelState.Clear();
                

            }
            return View();

        }

        
        
        // GET: WeightLog/showAllWeightLog
        [HttpGet]
        public ActionResult ShowAllWeightLog()
        {
            //fetch data from all weightlogs present in the database 
            var result = db.WeightLogs.ToList();
            //pass the fetched data to View
            return View(result);
        }

        // GET: WeightLog/updateWeightLog/weight_id
        public ActionResult UpdateWeightLog(int weight_id)
        {
            //fetch data from weight log having WeightId equals to weight_id present in the database 
            var weightLog = db.WeightLogs.Where(x => x.WeightId == weight_id).SingleOrDefault();
            //pass the fetched data to View
            return View(weightLog);

        }

        // POST: WeightLog/updateWeightLog/weight_id
        [HttpPost]
        public ActionResult UpdateWeightLog(WeightLog weightLog)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                var weightLog1 = db.WeightLogs.Where(x => x.WeightId == weightLog.WeightId).SingleOrDefault();

                if (weightLog1 != null)
                {
                    weightLog1.Weight = weightLog.Weight;
                    weightLog1.Updated_At = DateTime.UtcNow;
                    weightLog1.UserId = weightLog.UserId;
                    db.SaveChanges();
                }
                //redirect to WeightLog/showUserWeightLog
                return RedirectToAction("ShowAllWeightLog", new { user_id=Session["Id"]});

            }
            return View();

        }


        // GET: WeightLog/removeWeightLog/weight_id
        public ActionResult RemoveWeightLog(int weight_id)
        {
            //check if the model state is valid or not
            if (ModelState.IsValid)
            {
                WeightLog weightLog = db.WeightLogs.Find(weight_id);
                db.WeightLogs.Remove(weightLog);
                db.SaveChanges();
                return RedirectToAction("ShowAllWeightLog", new { user_id = Session["Id"] });
            }
            return View();


        }


    }
}