using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM2.Models;

namespace CRM2.Controllers
{
    public class Employee_dataController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employee_data
        public ActionResult Index()
        {
            return View(db.employee_data.ToList());
        }

        // GET: Employee_data/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_data employee_data = db.employee_data.Find(id);
            if (employee_data == null)
            {
                return HttpNotFound();
            }
            return View(employee_data);
        }

        // GET: Employee_data/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee_data/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Employee_data employeeData)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(employeeData.ImageFile.FileName);
                string extension = Path.GetExtension(employeeData.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                employeeData.Image = "~/Content/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                employeeData.ImageFile.SaveAs(fileName);
                db.employee_data.Add(employeeData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Employee_data/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_data employee_data = db.employee_data.Find(id);
            if (employee_data == null)
            {
                return HttpNotFound();
            }
            return View(employee_data);
        }

        // POST: Employee_data/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Insurance_number,Job_Title,Image,Full_Name,Gender,Street,Date_of_birth,Post_number,Landline_Number,Email,Phone_Mobile,Mobile,Nationality,Country_proof_of_personality,Personal_identification_number,Type_of_proof_of_personality,Work_Permit,Social_Security,Bank,Valid_to_date,Address,Identification_Card")] Employee_data employee_data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee_data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee_data);
        }

        // GET: Employee_data/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_data employee_data = db.employee_data.Find(id);
            if (employee_data == null)
            {
                return HttpNotFound();
            }
            return View(employee_data);
        }

        // POST: Employee_data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee_data employee_data = db.employee_data.Find(id);
            db.employee_data.Remove(employee_data);
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
