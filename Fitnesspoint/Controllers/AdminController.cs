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
        private FitnesspointDatabaseEntities db = new FitnesspointDatabaseEntities();

        //First Page visible after Valid Admin Login
        public ActionResult Adminview()
        {
            
            return View();
        }
        
        // GET: Admin
        public ActionResult Index()
        {
            return View(db.UserDetails.ToList());
        }

        // GET: Admin/Details/5
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

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Name,Gender,DOB,Weight,Height,MedicalCondition,AllergicTo,Email,Username,Password,Role,Diet_Plan_id,Goal,Contact")] UserDetail userDetail)
        {
            if (ModelState.IsValid)
            {
                db.UserDetails.Add(userDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDetail);
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDetail userDetail = db.UserDetails.Find(id);
            db.UserDetails.Remove(userDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
