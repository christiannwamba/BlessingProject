using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PayrollProject.Models;

namespace PayrollProject.Controllers
{
    public class SalaryController : Controller
    {
        private PayrollContext db = new PayrollContext();

        // GET: /Salary/
        public ActionResult Index()
        {
            return View(db.SalaryGrades.ToList());
        }

        // GET: /Salary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryGrade salarygrade = db.SalaryGrades.Find(id);
            if (salarygrade == null)
            {
                return HttpNotFound();
            }
            return View(salarygrade);
        }

        // GET: /Salary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Salary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SalaryGradeID,Salary,Grade")] SalaryGrade salarygrade)
        {
            if (ModelState.IsValid)
            {
                db.SalaryGrades.Add(salarygrade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salarygrade);
        }

        // GET: /Salary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryGrade salarygrade = db.SalaryGrades.Find(id);
            if (salarygrade == null)
            {
                return HttpNotFound();
            }
            return View(salarygrade);
        }

        // POST: /Salary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SalaryGradeID,Salary,Grade")] SalaryGrade salarygrade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salarygrade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salarygrade);
        }

        // GET: /Salary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryGrade salarygrade = db.SalaryGrades.Find(id);
            if (salarygrade == null)
            {
                return HttpNotFound();
            }
            return View(salarygrade);
        }

        // POST: /Salary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalaryGrade salarygrade = db.SalaryGrades.Find(id);
            db.SalaryGrades.Remove(salarygrade);
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
