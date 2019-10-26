using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM2.Models;
using Rotativa;
using Rotativa.MVC;

namespace CRM2.Controllers
{
    public class Emp_SalaryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Emp_Salary
        public ActionResult Index()
        {
            var emp_Salary = db.emp_Salary.Include(e => e.employee_data);
            return View(emp_Salary.ToList());
        }

        // GET: Emp_Salary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp_Salary emp_Salary = db.emp_Salary.Find(id);
            if (emp_Salary == null)
            {
                return HttpNotFound();
            }
            return View(emp_Salary);
        }

        public ActionResult Print()
        {

            var x = new ActionAsPdf("Index");
            return x;
        }
        // GET: Emp_Salary/Create
        public ActionResult Create()
        {
            ViewBag.Employee_ID = new SelectList(db.employee_data, "ID", "Full_Name");
            return View();
        }

        // POST: Emp_Salary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Vacation,Employee_ID,Month,Year,salary,Wage,Net")] Emp_Salary emp_Salary)
        {
            if (ModelState.IsValid)
            {
                db.emp_Salary.Add(emp_Salary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_ID = new SelectList(db.employee_data, "ID", "Full_Name", emp_Salary.Employee_ID);
            return View(emp_Salary);
        }

        // GET: Emp_Salary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp_Salary emp_Salary = db.emp_Salary.Find(id);
            if (emp_Salary == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_ID = new SelectList(db.employee_data, "ID", "Full_Name", emp_Salary.Employee_ID);
            return View(emp_Salary);
        }

        // POST: Emp_Salary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Vacation,Employee_ID,Month,Year,salary,Wage,Net")] Emp_Salary emp_Salary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp_Salary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_ID = new SelectList(db.employee_data, "ID", "Full_Name", emp_Salary.Employee_ID);
            return View(emp_Salary);
        }

        // GET: Emp_Salary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp_Salary emp_Salary = db.emp_Salary.Find(id);
            if (emp_Salary == null)
            {
                return HttpNotFound();
            }
            return View(emp_Salary);
        }

        // POST: Emp_Salary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emp_Salary emp_Salary = db.emp_Salary.Find(id);
            db.emp_Salary.Remove(emp_Salary);
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
