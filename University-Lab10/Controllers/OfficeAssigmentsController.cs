﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using University_Lab10;
using University_Lab10.Models;

namespace University_Lab10.Controllers
{
    public class OfficeAssigmentsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: OfficeAssigments
        public ActionResult Index()
        {
            var officeAssigments = db.OfficeAssigments.Where(x => x.isActive == true).Include(o => o.Instructor);
            return View(officeAssigments.ToList());
        }

        // GET: OfficeAssigments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeAssigment officeAssigment = db.OfficeAssigments.Find(id);
            if (officeAssigment == null)
            {
                return HttpNotFound();
            }
            return View(officeAssigment);
        }

        // GET: OfficeAssigments/Create
        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(db.Instructors.Where(x=>x.isActive == true), "ID", "LastName");
            return View();
        }

        // POST: OfficeAssigments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstructorID,Location")] OfficeAssigment officeAssigment)
        {
            if (ModelState.IsValid)
            {
                db.OfficeAssigments.Add(officeAssigment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(db.Instructors.Where(x=>x.isActive == true), "ID", "LastName", officeAssigment.InstructorID);
            return View(officeAssigment);
        }

        // GET: OfficeAssigments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeAssigment officeAssigment = db.OfficeAssigments.Find(id);
            if (officeAssigment == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstructorID = new SelectList(db.Instructors.Where(x=>x.isActive == true), "ID", "LastName", officeAssigment.InstructorID);
            return View(officeAssigment);
        }

        // POST: OfficeAssigments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstructorID,Location")] OfficeAssigment officeAssigment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(officeAssigment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstructorID = new SelectList(db.Instructors.Where(x => x.isActive == true), "ID", "LastName", officeAssigment.InstructorID);
            return View(officeAssigment);
        }

        // GET: OfficeAssigments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeAssigment officeAssigment = db.OfficeAssigments.Find(id);
            if (officeAssigment == null)
            {
                return HttpNotFound();
            }
            return View(officeAssigment);
        }

        // POST: OfficeAssigments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfficeAssigment officeAssigment = db.OfficeAssigments.Find(id);
            //db.OfficeAssigments.Remove(officeAssigment);
            officeAssigment.isActive = false;
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
