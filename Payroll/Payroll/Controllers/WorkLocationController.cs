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
    public class WorkLocationController : Controller
    {
        private PayrollContext db = new PayrollContext();

        // GET: /WorkLocation/
        public ActionResult Index()
        {
            var worklocations = db.WorkLocations.Include(w => w.Employee).Include(w => w.Work);
            return View(worklocations.ToList());
        }

        // GET: /WorkLocation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkLocation worklocation = db.WorkLocations.Find(id);
            if (worklocation == null)
            {
                return HttpNotFound();
            }
            return View(worklocation);
        }

        // GET: /WorkLocation/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName");
            ViewBag.WorkID = new SelectList(db.Works, "WorkId", "WorkId");
            return View();
        }

        // POST: /WorkLocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="LocationID,Location,WorkID,EmployeeID")] WorkLocation worklocation)
        {
            if (ModelState.IsValid)
            {
                db.WorkLocations.Add(worklocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", worklocation.EmployeeID);
            ViewBag.WorkID = new SelectList(db.Works, "WorkId", "WorkId", worklocation.WorkID);
            return View(worklocation);
        }

        // GET: /WorkLocation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkLocation worklocation = db.WorkLocations.Find(id);
            if (worklocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", worklocation.EmployeeID);
            ViewBag.WorkID = new SelectList(db.Works, "WorkId", "WorkId", worklocation.WorkID);
            return View(worklocation);
        }

        // POST: /WorkLocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="LocationID,Location,WorkID,EmployeeID")] WorkLocation worklocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worklocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", worklocation.EmployeeID);
            ViewBag.WorkID = new SelectList(db.Works, "WorkId", "WorkId", worklocation.WorkID);
            return View(worklocation);
        }

        // GET: /WorkLocation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkLocation worklocation = db.WorkLocations.Find(id);
            if (worklocation == null)
            {
                return HttpNotFound();
            }
            return View(worklocation);
        }

        // POST: /WorkLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkLocation worklocation = db.WorkLocations.Find(id);
            db.WorkLocations.Remove(worklocation);
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
