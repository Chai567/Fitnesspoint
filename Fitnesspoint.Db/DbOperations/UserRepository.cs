using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitnesspoint.Models;
using Fitnesspoint.Db;
namespace Fitnesspoint.Db.DbOperations
{
    public class UserRepository
    {

        //REGISTERING A USER
        public int AddUser(UserModel model)
        {
            using (var context = new FitnesspointDatabaseEntities())
            {
                UserDetail user = new UserDetail()
                {
                    Name = model.Name,
                    Gender = model.Gender,
                    DOB = model.DOB,
                    Weight = model.Weight,
                    Height = model.Height,
                    MedicalCondition = model.MedicalCondition,
                    AllergicTo = model.AllergicTo,
                    Goal = model.Goal,
                    Contact = model.Contact,
                    Email = model.Email,
                    Username = model.Username,
                    Password = model.Password,
                    Role = model.Role

                };
                context.UserDetails.Add(user);
                context.SaveChanges();

                return user.UserId;


            }


        }
    }
}

