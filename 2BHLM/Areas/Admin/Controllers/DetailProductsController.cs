using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLST.Models.MarketEntities;
using _2BHLM.Models;

namespace _2BHLM.Areas.Admin.Controllers
{
    [Authorize]
    public class DetailProductsController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/DetailProducts
        public ActionResult Index()
        {
            return View(db.DetailProducts.ToList());
        }

        // GET: Admin/DetailProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailProduct detailProduct = db.DetailProducts.Find(id);
            if (detailProduct == null)
            {
                return HttpNotFound();
            }
            return View(detailProduct);
        }

        // GET: Admin/DetailProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DetailProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "No,Madein,Title,Description,NutriousInfo,ProducedTime,ExpiredDate")] DetailProduct detailProduct)
        {
            if (ModelState.IsValid)
            {
                db.DetailProducts.Add(detailProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(detailProduct);
        }

        // GET: Admin/DetailProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailProduct detailProduct = db.DetailProducts.Find(id);
            if (detailProduct == null)
            {
                return HttpNotFound();
            }
            return View(detailProduct);
        }

        // POST: Admin/DetailProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "No,Madein,Title,Description,NutriousInfo,ProducedTime,ExpiredDate")] DetailProduct detailProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detailProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detailProduct);
        }

        // GET: Admin/DetailProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailProduct detailProduct = db.DetailProducts.Find(id);
            if (detailProduct == null)
            {
                return HttpNotFound();
            }
            return View(detailProduct);
        }

        // POST: Admin/DetailProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetailProduct detailProduct = db.DetailProducts.Find(id);
            db.DetailProducts.Remove(detailProduct);
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
