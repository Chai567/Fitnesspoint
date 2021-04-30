using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitnesspoint.Models;
namespace Fitnesspoint.Db.DbOperations
{
    public class NutritionPlanDAOImpl
    {
        //savePlan() saves NutritionPlan in the database
        public NutritionPlan savePlan(NutritionPlanModel nutritionPlan)
        {
            //open a connection to a database FitnesspointDatabase
            using (var context = new FitnesspointDatabaseEntities())
            {
                //Creating NutritionPlan object and assigning data using NutritionPlanModel class
                NutritionPlan nutritionPlan1 = new NutritionPlan()
                {
                    Name = nutritionPlan.Name,
                    PlanDescription = nutritionPlan.PlanDescription,
                    Created_At = DateTime.UtcNow,
                    Updated_At = DateTime.UtcNow,
                    Price = nutritionPlan.Price,

                };


                //add nutritionPlan to the database NutritionPlan using model NutritionPlan
                context.NutritionPlans.Add(nutritionPlan1);
                //save the changes to the database
                context.SaveChanges();

                return nutritionPlan1;
            }

        }

        //findAllNutritionPlan() returns the list of NutritionPlanModel Objects
        public List<NutritionPlanModel> findAllNutritionPlan()
        {
            //open a connection to a database FitnesspointDatabase
            using (var context = new FitnesspointDatabaseEntities())
            {
                //retrieving nutritionPlan from the database NutritionPlan using model NutritionPlanModel in the list form
                var res = context.NutritionPlans.Select(x => new NutritionPlanModel()
                {
                    NutriPlanId = x.NutriPlanId,
                    Name = x.Name,
                    PlanDescription = x.PlanDescription,
                    Created_At = x.Created_At,
                    Updated_At = x.Updated_At,
                    Price = x.Price,

                }).ToList();


                return res;
            }



        }

        //findNutritionPlan() returns the NutritionPlans based on NutriPlanId
        public NutritionPlanModel findNutritionPlan(int plan_id)
        {
            //open a connection to a database FitnesspointDatabase
            using (var context = new FitnesspointDatabaseEntities())
            {
                //retrieving nutritionPlan from the database NutritionPlan
                //using model NutritionPlanModel based on NutriPlanId

                var res = context.NutritionPlans
                    .Where(x => x.NutriPlanId == plan_id)
                    .Select(x => new NutritionPlanModel()
                    {
                        NutriPlanId = x.NutriPlanId,
                        Name = x.Name,
                        PlanDescription = x.PlanDescription,
                        Created_At = x.Created_At,
                        Updated_At = x.Updated_At,
                        Price = x.Price,

                    }).FirstOrDefault();


                return res;
            }


        }

        //updateNutritionPlan() update the NutritionPlans based on NutriPlanId and NutritionPlanModel
        public bool updateNutritionPlan(int plan_id, NutritionPlanModel nutritionPlan)
        {
            //open a connection to a database FitnesspointDatabase
            using (var context = new FitnesspointDatabaseEntities())
            {
                //retrieving nutritionPlan from the database NutritionPlan based on NutriPlanId
                var nutritionPlan1 = context.NutritionPlans.FirstOrDefault(x => x.NutriPlanId == plan_id);
                //replace the data in the database with NutritionPlanModel data based on NutriPlanId
                if (nutritionPlan1 != null)
                {
                    nutritionPlan1.Name = nutritionPlan.Name;
                    nutritionPlan1.PlanDescription = nutritionPlan.PlanDescription;
                    nutritionPlan1.Updated_At = DateTime.UtcNow;
                    nutritionPlan1.Price = nutritionPlan.Price;

                }
                //save the changes to the database
                context.SaveChanges();
                //returns true if data is updated
                return true;
            }
        }

        //deleteNutritionPlan() deletes the NutritionPlans based on NutriPlanId and NutritionPlanModel
        public bool deleteNutritionPlan(int plan_id, NutritionPlanModel nutritionPlan)
        {
            //open a connection to a database FitnesspointDatabase
            using (var context = new FitnesspointDatabaseEntities())
            {
                //retrieving nutritionPlan from the database NutritionPlan based on NutriPlanId
                var nutritionPlan1 = context.NutritionPlans.FirstOrDefault(x => x.NutriPlanId == plan_id);
                if (nutritionPlan1 != null)
                {
                    //delete the data if it is present in the database
                    context.NutritionPlans.Remove(nutritionPlan1);
                    //save the changes to the database
                    context.SaveChanges();
                    //returns true if data is deleted
                    return true;

                }
                //returns false if data is not deleted
                return false;
            }
        }


    }
}
