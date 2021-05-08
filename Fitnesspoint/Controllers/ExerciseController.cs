using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Fitnesspoint.Models;
using Fitnesspoint.Db;
using Fitnesspoint.Db.DbOperations;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Fitnesspoint.Controllers
{
    public class ExerciseController : Controller
    {
        // GET: Exercise
        public ActionResult Exercise()
        {
            return View();

        }
        public ActionResult FatLoss()
        {
            return View();

        }
        public ActionResult MuscleGain()
        {
            return View();

        }
        public ActionResult ChooseGoal()
        {
            TempData["msg"] = "";

            // Establishing the connection wata database 
            // Connection by server name and database name
            
            string mycon = ConfigurationManager.ConnectionStrings["FitnesspointDatabase"].ConnectionString;
            String myquery = "Select * from exercisedetail";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand(myquery,con);
            //cmd.CommandText = myquery;
            //cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            ExerciseDetails pd1 = new ExerciseDetails();
            List<ExerciseDetails> productlist = new List<ExerciseDetails>();
            // one bye one coulmn is being retrive
            // storing into class object
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ExerciseDetails pd = new ExerciseDetails();
                
                pd.Exerciseid = Convert.ToInt32(ds.Tables[0].Rows[i]["exerciseid"].ToString());
                pd.Exercisetype = ds.Tables[0].Rows[i]["exercisetype"].ToString();
                pd.Exercisefor = ds.Tables[0].Rows[i]["exercisefor"].ToString();
                pd.Totalset = Convert.ToInt32(ds.Tables[0].Rows[i]["totalset"].ToString()); ;
                pd.Rest = ds.Tables[0].Rows[i]["rest"].ToString();
                pd.Focus = ds.Tables[0].Rows[i]["focus"].ToString();
                pd.Equipement = ds.Tables[0].Rows[i]["equipement"].ToString();
                pd.Time = ds.Tables[0].Rows[i]["time"].ToString();
                pd.Exercisename = ds.Tables[0].Rows[i]["exercisename"].ToString();
                
                // a list to receive the data from class object
                productlist.Add(pd);
            }
            // stred all the data
            // closing the connection
            pd1.Productlist = productlist;
            con.Close();
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)Session["buyitems"];
            if (dt1 != null)
            {

                ViewBag.cartnumber = dt1.Rows.Count.ToString();
            }
            else
            {
                ViewBag.cartnumber = "0";
            }
            // returning view of all rceords
            return View(pd1);
        }
    }
}