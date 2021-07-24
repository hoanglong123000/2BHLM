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

    public class DetailReceiptsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/DetailReceipts
        public ActionResult Index()
        {
            return View(db.DetailReceipts.ToList());
        }

        // GET: Admin/DetailReceipts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailReceipt detailReceipt = db.DetailReceipts.Find(id);
            if (detailReceipt == null)
            {
                return HttpNotFound();
            }
            return View(detailReceipt);
        }

        // GET: Admin/DetailReceipts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DetailReceipts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDReceipt,ReceiptDate,ProductAmmount,TotalPrice")] DetailReceipt detailReceipt)
        {
            if (ModelState.IsValid)
            {
                db.DetailReceipts.Add(detailReceipt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(detailReceipt);
        }

        // GET: Admin/DetailReceipts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailReceipt detailReceipt = db.DetailReceipts.Find(id);
            if (detailReceipt == null)
            {
                return HttpNotFound();
            }
            return View(detailReceipt);
        }

        // POST: Admin/DetailReceipts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDReceipt,ReceiptDate,ProductAmmount,TotalPrice")] DetailReceipt detailReceipt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detailReceipt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detailReceipt);
        }

        // GET: Admin/DetailReceipts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailReceipt detailReceipt = db.DetailReceipts.Find(id);
            if (detailReceipt == null)
            {
                return HttpNotFound();
            }
            return View(detailReceipt);
        }

        // POST: Admin/DetailReceipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetailReceipt detailReceipt = db.DetailReceipts.Find(id);
            db.DetailReceipts.Remove(detailReceipt);
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
