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
            return View(db.Philosophers.ToList());
        }

        // Uses route data to locate philosopher in DB based on id parameter
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Philosopher philosopher = db.Philosophers.Find(id);
            if (philosopher == null)
            {
                return HttpNotFound();
            }
            return View(philosopher);
        }

        // GET: Philosopher/Create
        public ActionResult Create()
        {
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "Name");
            ViewBag.NationalityID = new SelectList(db.Nationalities, "NationalityID", "Name");
            return View();
        }

        // POST: Philosopher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhilosopherID,FirstName,LastName,DateOfBirth,DateOfDeath,IsAlive,Description,NationalityID,AreaID")] Philosopher philosopher)
        {
            if (ModelState.IsValid)
            {
                db.Philosophers.Add(philosopher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "Name", philosopher.AreaID);
            ViewBag.NationalityID = new SelectList(db.Nationalities, "NationalityID", "Name", philosopher.NationalityID);
            return View(philosopher);
        }

        // GET: Philosopher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Philosopher philosopher = db.Philosophers.Find(id);
            if (philosopher == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "Name", philosopher.AreaID);
            ViewBag.NationalityID = new SelectList(db.Nationalities, "NationalityID", "Name", philosopher.NationalityID);
            return View(philosopher);
        }

        // POST: Philosopher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhilosopherID,FirstName,LastName,DateOfBirth,DateOfDeath,IsAlive,Description,NationalityID,AreaID")] Philosopher philosopher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(philosopher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "Name", philosopher.AreaID);
            ViewBag.NationalityID = new SelectList(db.Nationalities, "NationalityID", "Name", philosopher.NationalityID);
            return View(philosopher);
        }

        // GET: Philosopher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Philosopher philosopher = db.Philosophers.Find(id);
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
            Philosopher philosopher = db.Philosophers.Find(id);
            db.Philosophers.Remove(philosopher);
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
