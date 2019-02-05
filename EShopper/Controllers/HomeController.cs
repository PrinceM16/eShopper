using EShopper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace EShopper.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext dbContext;
        public HomeController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();    
        }
        public ActionResult Index()
        {
            var products=dbContext.Products.Include(p=>p.Category).ToList();
            return View(products);
        }
        public ActionResult Shop()
        {
            var products = dbContext.Products.Include(p => p.Category).ToList();
            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}