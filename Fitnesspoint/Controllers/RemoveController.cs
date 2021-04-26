using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Fitnesspoint.Controllers
{
    public class RemoveController : Controller
    {
        // GET: Remove
        public ActionResult Index(string sno)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                int sr;
                int sr1;
                sr1 = Convert.ToInt32(sno);
                sr = Convert.ToInt32(dt.Rows[i]["sno"].ToString());


                if (sr == sr1)
                {
                    dt.Rows[i].Delete();
                    dt.AcceptChanges();
                    TempData["msg"] = "Selected Exercise Has Been Removed";
                    //Label1.Text = "Item Has Been Deleted From Shopping Cart";
                    break;

                }
            }

            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                dt.Rows[i - 1]["sno"] = i;
                dt.AcceptChanges();
            }

            Session["buyitems"] = dt;
            return RedirectToAction("Index", "ShowCart");
        }
    }
}