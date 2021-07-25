using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2BHLM.Models;
using _2BHLM.Models.MarketEntities;

namespace _2BHLM.Controllers
{
    public class StoredCarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StoredCars
        public ActionResult Index()
        {
            return View(db.StoredCars.ToList());
        }

        // GET: StoredCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoredCar storedCar = db.StoredCars.Find(id);
            if (storedCar == null)
            {
                return HttpNotFound();
            }
            return View(storedCar);
        }

        // GET: StoredCars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoredCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idstore,Titleofproduct,AmmountofProduct")] StoredCar storedCar)
        {
            if (ModelState.IsValid)
            {
                db.StoredCars.Add(storedCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storedCar);
        }

        // GET: StoredCars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoredCar storedCar = db.StoredCars.Find(id);
            if (storedCar == null)
            {
                return HttpNotFound();
            }
            return View(storedCar);
        }

        // POST: StoredCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idstore,Titleofproduct,AmmountofProduct")] StoredCar storedCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storedCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storedCar);
        }

        // GET: StoredCars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoredCar storedCar = db.StoredCars.Find(id);
            if (storedCar == null)
            {
                return HttpNotFound();
            }
            return View(storedCar);
        }

        // POST: StoredCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StoredCar storedCar = db.StoredCars.Find(id);
            db.StoredCars.Remove(storedCar);
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
