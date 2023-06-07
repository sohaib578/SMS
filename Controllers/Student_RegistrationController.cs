using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMS.Models;

namespace SMS.Controllers
{
    public class Student_RegistrationController : Controller
    {
        private ManagementSystemEntities1 db = new ManagementSystemEntities1();

        // GET: Student_Registration
        public ActionResult Index()
        {
            var student_Registration = db.Student_Registration.Include(s => s.Batch).Include(s => s.Course);
            return View(student_Registration.ToList());
        }

        // GET: Student_Registration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Registration student_Registration = db.Student_Registration.Find(id);
            if (student_Registration == null)
            {
                return HttpNotFound();
            }
            return View(student_Registration);
        }

        // GET: Student_Registration/Create
        public ActionResult Create()
        {
            ViewBag.Batch_id = new SelectList(db.Batches, "Id", "Batch1");
            ViewBag.Course_id = new SelectList(db.Courses, "Id", "CourseName");
            return View();
        }

        // POST: Student_Registration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,TeleNo,CreateDate,DeleteDate,IsActive,Course_id,Batch_id")] Student_Registration student_Registration)
        {
            if (ModelState.IsValid)
            {
                db.Student_Registration.Add(student_Registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Batch_id = new SelectList(db.Batches, "Id", "Batch1", student_Registration.Batch_id);
            ViewBag.Course_id = new SelectList(db.Courses, "Id", "CourseName", student_Registration.Course_id);
            return View(student_Registration);
        }

        // GET: Student_Registration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Registration student_Registration = db.Student_Registration.Find(id);
            if (student_Registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.Batch_id = new SelectList(db.Batches, "Id", "Batch1", student_Registration.Batch_id);
            ViewBag.Course_id = new SelectList(db.Courses, "Id", "CourseName", student_Registration.Course_id);
            return View(student_Registration);
        }

        // POST: Student_Registration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,TeleNo,CreateDate,DeleteDate,IsActive,Course_id,Batch_id")] Student_Registration student_Registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Batch_id = new SelectList(db.Batches, "Id", "Batch1", student_Registration.Batch_id);
            ViewBag.Course_id = new SelectList(db.Courses, "Id", "CourseName", student_Registration.Course_id);
            return View(student_Registration);
        }

        // GET: Student_Registration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Registration student_Registration = db.Student_Registration.Find(id);
            if (student_Registration == null)
            {
                return HttpNotFound();
            }
            return View(student_Registration);
        }

        // POST: Student_Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Registration student_Registration = db.Student_Registration.Find(id);
            db.Student_Registration.Remove(student_Registration);
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
