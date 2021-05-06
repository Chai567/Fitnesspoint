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

        //To check if username already exists.
        public bool UsernameExits(UserModel model)
        {
            bool uniqueUser = true;
            using (var context = new FitnesspointDatabaseEntities())
            {
                UserDetail User = new UserDetail();
                if (context.UserDetails.Any(u => u.Username == model.Username))
                {
                    uniqueUser = false;
                }

            }

            return uniqueUser;
        }

        //To get the details of logged in user.
        public UserModel GetUser(string username)
        {
            using (var context = new FitnesspointDatabaseEntities())
            {
                var result = context.UserDetails.Where(x => x.Username == username)
                                              .Select(x => new UserModel()
                                              {
                                                  UserId = x.UserId,
                                                  Name = x.Name,
                                                  Gender = x.Gender,
                                                  Weight = x.Weight,
                                                  Height = x.Height,
                                                  MedicalCondition = x.MedicalCondition,
                                                  AllergicTo = x.AllergicTo,
                                                  Goal = x.Goal,
                                                  Email = x.Email,
                                                  Contact = (long)x.Contact,
                                                  Role = x.Role
                                              }).FirstOrDefault();

                return result;
            }
        }
    }
}

