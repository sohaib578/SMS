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
    public class Exam__InfoController : Controller
    {
        private ManagementSystemEntities1 db = new ManagementSystemEntities1();

        // GET: Exam__Info
        public ActionResult Index()
        {
            return View(db.Exam__Info.ToList());
        }

        // GET: Exam__Info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam__Info exam__Info = db.Exam__Info.Find(id);
            if (exam__Info == null)
            {
                return HttpNotFound();
            }
            return View(exam__Info);
        }

        // GET: Exam__Info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exam__Info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Exam_Name,RoomNo,Teacher_Name")] Exam__Info exam__Info)
        {
            if (ModelState.IsValid)
            {
                db.Exam__Info.Add(exam__Info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exam__Info);
        }

        // GET: Exam__Info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam__Info exam__Info = db.Exam__Info.Find(id);
            if (exam__Info == null)
            {
                return HttpNotFound();
            }
            return View(exam__Info);
        }

        // POST: Exam__Info/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Exam_Name,RoomNo,Teacher_Name")] Exam__Info exam__Info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam__Info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exam__Info);
        }

        // GET: Exam__Info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam__Info exam__Info = db.Exam__Info.Find(id);
            if (exam__Info == null)
            {
                return HttpNotFound();
            }
            return View(exam__Info);
        }

        // POST: Exam__Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam__Info exam__Info = db.Exam__Info.Find(id);
            db.Exam__Info.Remove(exam__Info);
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
