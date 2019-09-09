using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class PickupTrackersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PickupTrackers
        public ActionResult Index()
        {
            var pickupTracker = db.PickupTracker.Include(p => p.Customer).Include(p => p.Employee);
            return View(pickupTracker.ToList());
        }

        // GET: PickupTrackers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupTracker pickupTracker = db.PickupTracker.Find(id);
            if (pickupTracker == null)
            {
                return HttpNotFound();
            }
            return View(pickupTracker);
        }

        // GET: PickupTrackers/Create
        public ActionResult Create()
        {
            ViewBag.customerId = new SelectList(db.Customer, "customerId", "firstName");
            ViewBag.employeeId = new SelectList(db.Employee, "employeeId", "firstName");
            return View();
        }

        // POST: PickupTrackers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pickupId,pickupDate,employeeId,customerId")] PickupTracker pickupTracker)
        {
            if (ModelState.IsValid)
            {
                db.PickupTracker.Add(pickupTracker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerId = new SelectList(db.Customer, "customerId", "firstName", pickupTracker.customerId);
            ViewBag.employeeId = new SelectList(db.Employee, "employeeId", "firstName", pickupTracker.employeeId);
            return View(pickupTracker);
        }

        // GET: PickupTrackers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupTracker pickupTracker = db.PickupTracker.Find(id);
            if (pickupTracker == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerId = new SelectList(db.Customer, "customerId", "firstName", pickupTracker.customerId);
            ViewBag.employeeId = new SelectList(db.Employee, "employeeId", "firstName", pickupTracker.employeeId);
            return View(pickupTracker);
        }

        // POST: PickupTrackers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pickupId,pickupDate,employeeId,customerId")] PickupTracker pickupTracker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pickupTracker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerId = new SelectList(db.Customer, "customerId", "firstName", pickupTracker.customerId);
            ViewBag.employeeId = new SelectList(db.Employee, "employeeId", "firstName", pickupTracker.employeeId);
            return View(pickupTracker);
        }

        // GET: PickupTrackers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupTracker pickupTracker = db.PickupTracker.Find(id);
            if (pickupTracker == null)
            {
                return HttpNotFound();
            }
            return View(pickupTracker);
        }

        // POST: PickupTrackers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PickupTracker pickupTracker = db.PickupTracker.Find(id);
            db.PickupTracker.Remove(pickupTracker);
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
