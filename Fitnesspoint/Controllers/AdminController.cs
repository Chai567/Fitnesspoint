using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fitnesspoint.Db;

namespace Fitnesspoint.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly FitnesspointDatabaseEntities db = new FitnesspointDatabaseEntities();

        //First Page visible after Valid Admin Login
        //Contains links to various activites that admin can perform.
        public ActionResult Adminview()
        {
            
            return View();
        }
        
        //This page displays the details of all the users of application.
        //By clicking on User Management link in AdminView you will be redirected to this ActionResult.
        public ActionResult Index()
        {
            return View(db.UserDetails.ToList());
        }

        //This allows the admin to see the details of a particular user.
        public ActionResult Details(int? id)
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

        //This allows the admin to edit the details of a particular user.
        //Just in case it is required.
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

        //This is the post method for edit.
        //If changes are done as per the validations then save is hit.
        //And the changes are updated in the table.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Name,Gender,DOB,Weight,Height,MedicalCondition,AllergicTo,Email,Username,Password,Role,Diet_Plan_id,Goal,Contact")] UserDetail userDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userDetail);
        }

        //This a get method for delete.
        //This method is to allow Admin to delete a user.
        //The details of the selected user will be displayed.
        //A button to delete will be given.
        
        public ActionResult DeleteConfirmed(int id)
        {
            UserDetail userDetail = db.UserDetails.Find(id);
            db.UserDetails.Remove(userDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //This method performs all the object cleanup.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
