using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitnesspoint.Models;
namespace Fitnesspoint.Db.DbOperations
{
    public class WeightLogDAOImpl
    {
        //saveWeight() saves WeightLog in the database
        public WeightLog SaveWeight(WeightLogModel weight)
        {
            //open a connection to a database FitnesspointDatabase
            using (var context = new FitnesspointDatabaseEntities())
            {
                //Creating WieghtLog object and assigning data using WeightLogModel class
                WeightLog weightLog = new WeightLog()
                {
                    Weight = weight.Weight,
                    Created_At = DateTime.UtcNow,
                    Updated_At = DateTime.UtcNow,
                    UserId = weight.UserId
                };

                //add weightLog to the database WeightLog using model WeightLog
                context.WeightLogs.Add(weightLog);
                //save the changes to the database
                context.SaveChanges();

                return weightLog;
            }

        }

        //findAllWeight() returns the list of WeightLogModel Objects
        public List<WeightLogModel> FindAllWeight()
        {
            //open a connection to a database FitnesspointDatabase
            using (var context = new FitnesspointDatabaseEntities())
            {

                //retrieving weightLog from the database WeightLog using model WeightLogModel in the list form
                var res = context.WeightLogs.Select(x => new WeightLogModel()
                {
                    WeightId = x.WeightId,
                    Weight = x.Weight,
                    Created_At = x.Created_At,
                    Updated_At = x.Updated_At,
                    UserId = x.UserId
                }).ToList();

                return res;
            }


        }


        //findWeight() returns the WeightLog based on WeightId
        public WeightLogModel FindWeight(int weight_id)
        {
            //open a connection to a database FitnesspointDatabase
            using (var context = new FitnesspointDatabaseEntities())
            {
                //retrieving weightLog from the database WeightLog
                //using model WeightLogModel based on WeightId

                var res = context.WeightLogs
                    .Where(x => x.WeightId == weight_id)
                    .Select(x => new WeightLogModel()
                    {
                        WeightId = x.WeightId,
                        Weight = x.Weight,
                        Created_At = x.Created_At,
                        Updated_At = x.Updated_At,
                        UserId = x.UserId
                    }).FirstOrDefault();


                return res;
            }


        }




        //USER Weight Log
        //findUserWeight() returns the list of all WeightLog based on UserId
        public List<WeightLogModel> FindUserWeight(int user_id)
        {
            //open a connection to a database FitnesspointDatabase
            using (var context = new FitnesspointDatabaseEntities())
            {
                //retrieving weightLog from the database WeightLog
                //using model WeightLogModel based on UserId

                var res = context.WeightLogs
                    .Where(x => x.UserId == user_id)
                    .Select(x => new WeightLogModel()
                    {
                        WeightId = x.WeightId,
                        Weight = x.Weight,
                        Created_At = x.Created_At,
                        Updated_At = x.Updated_At,
                        UserId = x.UserId
                    }).ToList();


                return res;
            }


        }









        //updateWeight() update the WeightLogs based on WeightId and WeightLogModel
        public bool UpdateWeight(int weight_id, WeightLogModel weight)
        {
            //open a connection to a database FitnesspointDatabase
            using (var context = new FitnesspointDatabaseEntities())
            {
                //retrieving weightLog from the database WeightLog based on WeightId
                var weightLog = context.WeightLogs.FirstOrDefault(x => x.WeightId == weight_id);
                //replace the data in the database with WeightLogModel data based on WeightId
                if (weightLog != null)
                {
                    weightLog.Weight = weight.Weight;
                    weightLog.Updated_At = DateTime.UtcNow;
                    weightLog.UserId = weight.UserId;

                }
                //save the changes to the database
                context.SaveChanges();
                //returns true if data is updated
                return true;
            }
        }

        //deleteWeight() deletes the WeightLogs based on WeightId and WeightLogModel
        public bool DeleteWeight(int weight_id)
        {
            //open a connection to a database FitnesspointDatabase
            using (var context = new FitnesspointDatabaseEntities())
            {
                //retrieving weightLog from the database WeightLog based on WeightId
                var weightLog = context.WeightLogs.FirstOrDefault(x => x.WeightId == weight_id);
                if (weightLog != null)
                {
                    //delete the data if it is present in the database
                    context.WeightLogs.Remove(weightLog);
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
