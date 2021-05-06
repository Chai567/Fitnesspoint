using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitnesspoint.Models;
namespace Fitnesspoint.Db.DbOperations
{
    public class DietPlanDAOImpl
    {
        //saveDietPlan() saves DietPlan in the database
        public DietPlan SaveDietPlan(DietPlanModel dietPlan)
        {
            //open a connection to a database FitnesspointDatabase
            using (var context = new FitnesspointDatabaseEntities())
            {
                //Creating DietPlan object and assigning data using DietPlanModel class
                DietPlan dietPlan1 = new DietPlan()
                {
                    Slots = dietPlan.Slots,
                    FoodType = dietPlan.FoodType,
                    FatRatio = dietPlan.FatRatio,
                    CarbsRatio = dietPlan.CarbsRatio,
                    ProteinRatio = dietPlan.ProteinRatio,
                    TotalCalorie = dietPlan.FatRatio + dietPlan.CarbsRatio + dietPlan.ProteinRatio,
                    UserId = dietPlan.UserId

                };


                //add dietPlan1 to the database DietPlan using model DietPlan
                context.DietPlans.Add(dietPlan1);
                //save the changes to the database
                context.SaveChanges();

                return dietPlan1;
            }

        }

        //findAllDietPlan() returns the list of DietPlanModel Objects
        public List<DietPlanModel> FindAllDietPlan()
        {
            //open a connection to a database FitnesspointDatabase
            using (var context = new FitnesspointDatabaseEntities())
            {
                //retrieving dietPlan from the database DietPlan using model DietPlanModel in the list form
                var res = context.DietPlans.Select(x => new DietPlanModel()
                {
                    DietId = x.DietId,
                    Slots = x.Slots,
                    FoodType = x.FoodType,
                    FatRatio = x.FatRatio,
                    CarbsRatio = x.CarbsRatio,
                    ProteinRatio = x.ProteinRatio,
                    TotalCalorie = x.TotalCalorie,
                    UserId = x.UserId

                }).ToList();


                return res;
            }



        }

        //findDietPlan() returns the DietPlans based on DietId
        public DietPlanModel FindDietPlan(int diet_id)
        {
            //open a connection to a database FitnesspointDatabase
            using (var context = new FitnesspointDatabaseEntities())
            {
                //retrieving dietPlan from the database DietPlan
                //using model DietPlanModel based on DietId

                var res = context.DietPlans
                    .Where(x => x.DietId == diet_id)
                    .Select(x => new DietPlanModel()
                    {
                        DietId = x.DietId,
                        Slots = x.Slots,
                        FoodType = x.FoodType,
                        FatRatio = x.FatRatio,
                        CarbsRatio = x.CarbsRatio,
                        ProteinRatio = x.ProteinRatio,
                        TotalCalorie = x.TotalCalorie,
                        UserId = x.UserId
                    }).FirstOrDefault();


                return res;
            }


        }


        //User Diet Plan

        public List<DietPlanModel> FindUserDietPlan(int user_id)
        {
            //open a connection to a database FitnesspointDatabase
            using (var context = new FitnesspointDatabaseEntities())
            {
                //retrieving dietPlan from the database DietPlan
                //using model DietPlanModel based on UserId

                var res = context.DietPlans
                    .Where(x => x.UserId == user_id)
                    .Select(x => new DietPlanModel()
                    {
                        DietId = x.DietId,
                        Slots = x.Slots,
                        FoodType = x.FoodType,
                        FatRatio = x.FatRatio,
                        CarbsRatio = x.CarbsRatio,
                        ProteinRatio = x.ProteinRatio,
                        TotalCalorie = x.TotalCalorie,
                        UserId = x.UserId
                    }).ToList();


                return res;
            }


        }

        //updateDietPlan() update the DietPlans based on DietId and DietPlanModel
        public bool UpdateDietPlan(int diet_id, DietPlanModel dietPlan)
        {
            //open a connection to a database FitnesspointDatabase
            using (var context = new FitnesspointDatabaseEntities())
            {
                //retrieving dietPlan from the database DietPlan based on DietId
                var dietPlan1 = context.DietPlans.FirstOrDefault(x => x.DietId == diet_id);
                //replace the data in the database with DietPlanModel data based on DietId
                if (dietPlan1 != null)
                {
                    dietPlan1.Slots = dietPlan.Slots;
                    dietPlan1.FoodType = dietPlan.FoodType;
                    dietPlan1.FatRatio = dietPlan.FatRatio;
                    dietPlan1.CarbsRatio = dietPlan.CarbsRatio;
                    dietPlan1.ProteinRatio = dietPlan.ProteinRatio;
                    dietPlan1.TotalCalorie = dietPlan1.FatRatio + dietPlan1.CarbsRatio + dietPlan1.ProteinRatio;
                    dietPlan1.UserId = dietPlan.UserId;

                }
                //save the changes to the database
                context.SaveChanges();
                //returns true if data is updated
                return true;
            }
        }

        //deleteDietPlan() deletes the DietPlans based on DietId and DietPlanModel
        public bool DeleteDietPlan(int diet_id)
        {
            //open a connection to a database FitnesspointDatabase
            using (var context = new FitnesspointDatabaseEntities())
            {
                //retrieving dietPlan from the database DietPlan based on DietId
                var dietPlan1 = context.DietPlans.FirstOrDefault(x => x.DietId == diet_id);
                if (dietPlan1 != null)
                {
                    //delete the data if it is present in the database
                    context.DietPlans.Remove(dietPlan1);
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
