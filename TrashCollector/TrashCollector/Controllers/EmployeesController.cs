using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var currentUser = User.Identity.GetUserId();
            return View(db.Employee.Where(e => e.ApplicationUserId == currentUser));
        }

        // GET: Employees/Details/5
        public ActionResult Details()
        {
            var employeeId = User.Identity.GetUserId();
            var currentEmployee = db.Employee.Where(e => e.ApplicationUserId == employeeId).Single();
            var dayOfWeekToday = DateTime.Now.DayOfWeek.ToString();
            var dateToday = DateTime.Now;
            var customerZipCodeMatch = db.Customer.Where(c => c.zipCode == currentEmployee.zipCode && c.pickupDay == dayOfWeekToday || c.Date == dateToday).ToList();
            var customerSuspensionRemoved = customerZipCodeMatch.Where(c => (c.AccountSuspensionStartDate > dateToday && c.AccountSuspensionEndDate < dateToday)
            || (c.AccountSuspensionEndDate == null && c.AccountSuspensionStartDate == null)).ToList();
            return View(customerSuspensionRemoved);
        }

        // GET: Employees/AllCustomers
        public ActionResult AllCustomers()
        {
            var employeeId = User.Identity.GetUserId();
            var currentEmployee = db.Employee.Where(e => e.ApplicationUserId == employeeId).Single();
            var customerZipCodeMatch = db.Customer.Where(c => c.zipCode == currentEmployee.zipCode).ToList();
            return View(customerZipCodeMatch);
        }
        // GET: Employees/PickupSchedule
        public ActionResult PickupSchedule(string searchString)
        {
            var employeeId = User.Identity.GetUserId();
            var currentEmployee = db.Employee.Where(e => e.ApplicationUserId == employeeId).Single();
            var customerZipAndDayMatch = db.Customer.Where(c => c.zipCode == currentEmployee.zipCode && c.pickupDay == searchString).ToList();
            return View(customerZipAndDayMatch);
        }
        // GET: Employees/ConfirmPickup
        public ActionResult ConfirmPickup(int id)
        {
            var customerToConfirm = db.Customer.FirstOrDefault(c => c.customerId == id);
            return View(customerToConfirm);
        }

        //POST: Employees/ConfirmPickup
       [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult ConfirmPickup([Bind(Include = "customerId,firstName,lastName,balance,pickupDay,pickupDateSelected,Date,streetAddress,city,zipCode,ApplicationUserId,AccountSuspensionStartDate,AccountSuspensionEndDate,pickupDateSelected,pickupConfirmed")]Customer customer)
        {
            try
            {
                double weeklyTrashCharge = 10.00;
                customer.balance += weeklyTrashCharge;
                customer.pickupConfirmed = true;
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }


        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employeeId,zipCode,firstName,lastName,ApplicationUserId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var currentUser = User.Identity.GetUserId();
                employee.ApplicationUserId = currentUser;
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employeeId,firstName,lastName,zipCode,ApplicationUserId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
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
