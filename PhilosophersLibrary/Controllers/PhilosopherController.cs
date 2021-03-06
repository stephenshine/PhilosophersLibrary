﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhilosophersLibrary.DAL;
using PhilosophersLibrary.Models.Entities;

namespace PhilosophersLibrary.Controllers
{
    public class PhilosopherController : Controller
    {
        private PhilosopherContext db = new PhilosopherContext();

        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "date_desc" : "Date";
            var philosophers = from p in db.Philosopher
                               select p;

            switch (sortOrder)
            {
                case "name_desc":
                    philosophers = philosophers.OrderByDescending(p => p.LastName);
                    break;
                case "Date":
                    philosophers = philosophers.OrderBy(p => p.DateOfBirth);
                    break;
                case "date_desc":
                    philosophers = philosophers.OrderByDescending(p => p.DateOfBirth);
                    break;
                default:
                    philosophers = philosophers.OrderBy(p => p.LastName);
                    break;
            }
            return View(philosophers.ToList());
        }

        // GET: Philosopher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Philosopher philosopher = db.Philosopher.Find(id);
            if (philosopher == null)
            {
                return HttpNotFound();
            }
            return View(philosopher);
        }

        // GET: Philosopher/Create
        public ActionResult Create()
        {
            ViewBag.AreaID = new SelectList(db.Area, "AreaID", "Name");
            ViewBag.NationalityID = new SelectList(db.Nationality, "NationalityID", "Name");
            return View();
        }

        // POST: Philosopher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,DateOfBirth,DateOfDeath,IsAlive,Description,NationalityID,AreaID")] Philosopher philosopher)
        {
            try
            { 
                if (ModelState.IsValid)
                {
                    db.Philosopher.Add(philosopher);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again. If unable to resolve contact the administrator.");
            }

            ViewBag.AreaID = new SelectList(db.Area, "AreaID", "Name", philosopher.AreaID);
            ViewBag.NationalityID = new SelectList(db.Nationality, "NationalityID", "Name", philosopher.NationalityID);
            return View(philosopher);
        }

        // GET: Philosopher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Philosopher philosopher = db.Philosopher.Find(id);
            if (philosopher == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaID = new SelectList(db.Area, "AreaID", "Name", philosopher.AreaID);
            ViewBag.NationalityID = new SelectList(db.Nationality, "NationalityID", "Name", philosopher.NationalityID);
            return View(philosopher);
        }

        // updating edit method to use TryUpdateModel, rather than bind
        // rename method because signatue matches HttpGet method
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var philosopherToUpdate = db.Philosopher.Find(id);
            if (TryUpdateModel(philosopherToUpdate, "",
                new string[]
                {
                    "FirstName", "LastName", "DateOfBirth", "DateOfDeath", "IsAlive", "Description", "NationalityID", "AreaID"
                }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException ex) {
                    ModelState.AddModelError("", "Unable to save changes. Try again. If unable to resolve contact the administrator.");
                }
            }
            ViewBag.AreaID = new SelectList(db.Area, "AreaID", "Name", philosopherToUpdate.AreaID);
            ViewBag.NationalityID = new SelectList(db.Nationality, "NationalityID", "Name", philosopherToUpdate.NationalityID);
            return View(philosopherToUpdate);
        }


        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again. If unable to resolve contact the administrator";
            }
            Philosopher philosopher = db.Philosopher.Find(id);
            if (philosopher == null)
            {
                return HttpNotFound();
            }
            return View(philosopher);
        }

        // POST: Philosopher/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Philosopher philosopher = db.Philosopher.Find(id);
                db.Philosopher.Remove(philosopher);
                db.SaveChanges();
            }
            catch (DataException ex)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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
