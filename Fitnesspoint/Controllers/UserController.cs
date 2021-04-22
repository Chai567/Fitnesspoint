using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fitnesspoint.Db;
using Fitnesspoint.Models;
using Fitnesspoint.Db.DbOperations;

namespace Fitnesspoint.Controllers
{
    public class UserController : Controller
    {

        private FitnesspointDatabaseEntities db = new FitnesspointDatabaseEntities();
        WeightLogDAOImpl x=new WeightLogDAOImpl();
        
        
        //User Welcome Page with All Details of Logged in user
        [Authorize]
        public ActionResult Welcome()
        {
            string displaying = (string)Session["Username"];
            string conn = ConfigurationManager.ConnectionStrings["FitnesspointDatabase"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(conn);
            string query = @"select UserId,Name,Gender,DOB,Weight,Height,MedicalCondition,AllergicTo,Email,Contact,Goal from [dbo].[UserDetails] where Username='" + displaying + "'";
            sqlconn.Open();

            SqlCommand sqlcomm = new SqlCommand(query, sqlconn);
            sqlcomm.Parameters.AddWithValue("Username", Session["Username"].ToString());
            SqlDataReader sdr = sqlcomm.ExecuteReader();

            if (sdr.Read())
            {
                string Id = sdr["UserId"].ToString();
                string N = sdr["Name"].ToString();
                string G = sdr["Gender"].ToString();
                string D = sdr["DOB"].ToString();
                string W = sdr["Weight"].ToString();
                string H = sdr["Height"].ToString();
                string M = sdr["MedicalCondition"].ToString();
                string A = sdr["AllergicTo"].ToString();
                string Goal = sdr["Goal"].ToString();
                string E = sdr["Email"].ToString();
                string C = sdr["Contact"].ToString();

                ViewData["Name"] = N;
                ViewData["Gender"] = G;
                ViewData["DOB"] = D;
                ViewData["Weight"] = W;
                ViewData["Height"] = H;
                ViewData["MedicalCondition"] = M;
                ViewData["AllergicTo"] = A;
                ViewData["Email"] = E;
                ViewData["Goal"] = Goal;
                ViewData["Contact"] = C;
                
                Session["Id"] = Id;

                
                

            }
            sqlconn.Close();

            return View();
        }


        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetails.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Gender,DOB,Weight,Height,MedicalCondition,AllergicTo,Email,Goal")] UserDetail userDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetail).State = EntityState.Modified;
                var v=db.SaveChanges();
                return RedirectToAction("Welcome");
            }
            return View(userDetail);
        }
    }
}