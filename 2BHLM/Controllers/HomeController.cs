using _2BHLM.Models;
using QLST.Models.MarketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace _2BHLM.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext applicationDbContext;


        public HomeController()
        {
            applicationDbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View(applicationDbContext.DetailProducts.ToList());
        }

        public  ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailProduct detailProduct = applicationDbContext.DetailProducts.Find(id);
            if (detailProduct == null)
            {
                return HttpNotFound();
            }

            return View(detailProduct);

        }
       
        
    }
}