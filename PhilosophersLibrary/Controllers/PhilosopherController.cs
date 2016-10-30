using System;
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

        public ActionResult Index()
        {
            return View(db.Philosopher.ToList());
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

        // GET: Philosopher/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Philosopher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Philosopher philosopher = db.Philosopher.Find(id);
            db.Philosopher.Remove(philosopher);
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
