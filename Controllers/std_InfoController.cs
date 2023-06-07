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
    public class std_InfoController : Controller
    {
        private ManagementSystemEntities1 db = new ManagementSystemEntities1();

        // GET: std_Info
        public ActionResult Index()
        {
            var std_Info = db.std_Info.Include(s => s.Batch).Include(s => s.Course);
            return View(std_Info.ToList());
        }

        // GET: std_Info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            std_Info std_Info = db.std_Info.Find(id);
            if (std_Info == null)
            {
                return HttpNotFound();
            }
            return View(std_Info);
        }

        // GET: std_Info/Create
        public ActionResult Create()
        {
            ViewBag.Batch_id = new SelectList(db.Batches, "Id", "Batch1");
            ViewBag.Course_id = new SelectList(db.Courses, "Id", "CourseName");
            return View();
        }

        // POST: std_Info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Batch_id,Course_id")] std_Info std_Info)
        {
            if (ModelState.IsValid)
            {
                db.std_Info.Add(std_Info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Batch_id = new SelectList(db.Batches, "Id", "Batch1", std_Info.Batch_id);
            ViewBag.Course_id = new SelectList(db.Courses, "Id", "CourseName", std_Info.Course_id);
            return View(std_Info);
        }

        // GET: std_Info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            std_Info std_Info = db.std_Info.Find(id);
            if (std_Info == null)
            {
                return HttpNotFound();
            }
            ViewBag.Batch_id = new SelectList(db.Batches, "Id", "Batch1", std_Info.Batch_id);
            ViewBag.Course_id = new SelectList(db.Courses, "Id", "CourseName", std_Info.Course_id);
            return View(std_Info);
        }

        // POST: std_Info/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Batch_id,Course_id")] std_Info std_Info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(std_Info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Batch_id = new SelectList(db.Batches, "Id", "Batch1", std_Info.Batch_id);
            ViewBag.Course_id = new SelectList(db.Courses, "Id", "CourseName", std_Info.Course_id);
            return View(std_Info);
        }

        // GET: std_Info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            std_Info std_Info = db.std_Info.Find(id);
            if (std_Info == null)
            {
                return HttpNotFound();
            }
            return View(std_Info);
        }

        // POST: std_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            std_Info std_Info = db.std_Info.Find(id);
            db.std_Info.Remove(std_Info);
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
