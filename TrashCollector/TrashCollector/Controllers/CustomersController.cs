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
using Newtonsoft.Json;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers1
        public ActionResult Index()
        {
            var currentUser = User.Identity.GetUserId();
            return View(db.Customer.Where(c => c.ApplicationUserId == currentUser));
        }

        // GET: Customers1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult AccountDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        public string ConvertAddressToGoogleFormat(Customer customer)
        {
            string googleFormatAddress = customer.streetAddress + "," + customer.city + "," + customer.stateAbbreviation + "," + customer.zipCode + ",USA";
            return googleFormatAddress;
        }

        public GeoCode GeoLocate(string address)
        {
            var requestUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={address}&key=AIzaSyCvNx58z28nAtRCUDGJU6xi2qisdrmE1dQ";
            var result = new WebClient().DownloadString(requestUrl);
            GeoCode geocode = JsonConvert.DeserializeObject<GeoCode>(result);
            return geocode;
        }

        // GET: Customers1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerId,firstName,lastName,balance,pickupDay,speicalPickupDate,streetAddress,city,zipCode,ApplicationUserId,AccountSuspensionStartDate,AccountSuspensionEndDate,pickupDateSelected,pickupConfirmed,longitude,latitude,stateAbbreviation")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var currentUser = User.Identity.GetUserId();
                customer.ApplicationUserId = currentUser;
                customer.balance = 0.00;
                customer.specialPickupDate = null;
                customer.AccountSuspensionStartDate = null;
                customer.AccountSuspensionEndDate = null;
                customer.pickupConfirmed = false;
                string addressToConvert = ConvertAddressToGoogleFormat(customer);
                var geoLocate = GeoLocate(addressToConvert);
                customer.longitute = geoLocate.results[0].geometry.location.lng;
                customer.latitude = geoLocate.results[0].geometry.location.lat;
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerId,firstName,lastName,streetAddress,city,zipCode,pickupDay,speicalPickupDate,AccountSuspensionStartDate,AccountSuspensionEndDate,ApplicationUserId,longitute,latitude,stateAbbreviation,balance")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                string addressToConvert = ConvertAddressToGoogleFormat(customer);
                var geoLocate = GeoLocate(addressToConvert);
                customer.longitute = geoLocate.results[0].geometry.location.lng;
                customer.latitude = geoLocate.results[0].geometry.location.lat;
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
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
