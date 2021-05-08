using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Fitnesspoint.Controllers
{
    public class AddCartController : Controller
    {
        // GET: AddCart
        public ActionResult AddCart(string exerciseid)
        {
            ViewBag.exerciseid = exerciseid;

            if (this.Request.RequestType != "POST")
            {
                //adding column into datatable
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("sno");
                dt.Columns.Add("exerciseid");
                dt.Columns.Add("exercisetype");
                dt.Columns.Add("exercisefor");
                dt.Columns.Add("totalset");
                dt.Columns.Add("rest");
                dt.Columns.Add("focus");
                dt.Columns.Add("equipement");
                dt.Columns.Add("time");
                dt.Columns.Add("exercisename");


                if (Request.QueryString["exerciseid"] != null)
                {
                    //Adding the data from data base to cart
                    if (Session["Buyitems"] == null)
                    {

                        dr = dt.NewRow();
                        // Establishing the connection wata database 
                        // Connection by server name and database name
                        string mycon = ConfigurationManager.ConnectionStrings["FitnesspointDatabase"].ConnectionString;
                        SqlConnection scon = new SqlConnection(mycon);
                        String myquery = "select * from exercisedetail where exerciseid=" + Request.QueryString["exerciseid"];
                        SqlCommand cmd = new SqlCommand(myquery,scon);
                        
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        // using datarow object records added
                        dr["sno"] = 1;
                        dr["exerciseid"] = ds.Tables[0].Rows[0]["exerciseid"].ToString();
                        dr["exercisetype"] = ds.Tables[0].Rows[0]["exercisetype"].ToString();
                        dr["exercisefor"] = ds.Tables[0].Rows[0]["exercisefor"].ToString();
                        dr["totalset"] = ds.Tables[0].Rows[0]["totalset"].ToString();
                        dr["rest"] = ds.Tables[0].Rows[0]["rest"].ToString();
                        dr["focus"] = ds.Tables[0].Rows[0]["focus"].ToString();
                        dr["equipement"] = ds.Tables[0].Rows[0]["equipement"].ToString();
                        dr["time"] = ds.Tables[0].Rows[0]["time"].ToString();
                        dr["exercisename"] = ds.Tables[0].Rows[0]["exercisename"].ToString();
                        dt.Rows.Add(dr);
                        //GridView1.DataSource = dt;
                        // GridView1.DataBind();
                        Session["buyitems"] = dt;
                    }
                   
                    
                    //if records are already added
                    // adding more record 
                    else
                    {

                        dt = (DataTable)Session["buyitems"];
                        int sr;
                        sr = dt.Rows.Count;

                        dr = dt.NewRow();
                        // Establishing the connection wata database 
                        // Connection by server name and database name
                        string mycon = ConfigurationManager.ConnectionStrings["FitnesspointDatabase"].ConnectionString;
                        SqlConnection scon = new SqlConnection(mycon);
                        String myquery = "select * from exercisedetail where exerciseid=" + Request.QueryString["exerciseid"];
                        SqlCommand cmd = new SqlCommand(myquery,scon);
                        
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        // showing the records in table form
                        // increasing serial number by one
                        dr["sno"] = sr + 1;

                        dr["exerciseid"] = ds.Tables[0].Rows[0]["exerciseid"].ToString();
                        dr["exercisetype"] = ds.Tables[0].Rows[0]["exercisetype"].ToString();
                        dr["exercisefor"] = ds.Tables[0].Rows[0]["exercisefor"].ToString();
                        dr["totalset"] = ds.Tables[0].Rows[0]["totalset"].ToString();
                        dr["rest"] = ds.Tables[0].Rows[0]["rest"].ToString();
                        dr["focus"] = ds.Tables[0].Rows[0]["focus"].ToString();
                        dr["equipement"] = ds.Tables[0].Rows[0]["equipement"].ToString();
                        dr["time"] = ds.Tables[0].Rows[0]["time"].ToString();
                        dr["exercisename"] = ds.Tables[0].Rows[0]["exercisename"].ToString();
                        dt.Rows.Add(dr);
                        // GridView1.DataSource = dt;
                        // GridView1.DataBind();
                        Session["buyitems"] = dt;

                    }
                }
                else
                {
                    dt = (DataTable)Session["buyitems"];
                    // GridView1.DataSource = dt;
                    // GridView1.DataBind();

                }
            }

            return RedirectToAction("Index", "ShowCart");
        }
    }
}