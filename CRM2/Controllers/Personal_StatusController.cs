using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM2.Models;

namespace CRM2.Controllers
{
    public class Personal_StatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Personal_Status
        public ActionResult Index()
        {
            var personal_status = db.personal_status.Include(p => p.employee_data);
            return View(personal_status.ToList());
        }

        // GET: Personal_Status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Status personal_Status = db.personal_status.Find(id);
            if (personal_Status == null)
            {
                return HttpNotFound();
            }
            return View(personal_Status);
        }

        // GET: Personal_Status/Create
        public ActionResult Create()
        {
            ViewBag.Employee_ID = new SelectList(db.employee_data, "ID", "Full_Name");
            return View();
        }

        // POST: Personal_Status/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Employee_ID,Status,From,To")] Personal_Status personal_Status)
        {
            if (ModelState.IsValid)
            {
                db.personal_status.Add(personal_Status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_ID = new SelectList(db.employee_data, "ID", "Full_Name", personal_Status.Employee_ID);
            return View(personal_Status);
        }

        // GET: Personal_Status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Status personal_Status = db.personal_status.Find(id);
            if (personal_Status == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_ID = new SelectList(db.employee_data, "ID", "Full_Name", personal_Status.Employee_ID);
            return View(personal_Status);
        }

        // POST: Personal_Status/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Employee_ID,Status,From,To")] Personal_Status personal_Status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal_Status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_ID = new SelectList(db.employee_data, "ID", "Full_Name", personal_Status.Employee_ID);
            return View(personal_Status);
        }

        // GET: Personal_Status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Status personal_Status = db.personal_status.Find(id);
            if (personal_Status == null)
            {
                return HttpNotFound();
            }
            return View(personal_Status);
        }

        // POST: Personal_Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personal_Status personal_Status = db.personal_status.Find(id);
            db.personal_status.Remove(personal_Status);
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
