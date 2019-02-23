using EShopper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShopper.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db;
        public AdminController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult ListProduct()
        {
            var products = db.Products.ToList();
            return View(products);
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}