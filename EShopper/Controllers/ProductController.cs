using EShopper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShopper.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private ApplicationDbContext dbContext;
        public ProductController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }
        public ActionResult ProductDetails(int? id)
        {
            var product = dbContext.Products.Single(p => p.ProductId == id);
            if (product==null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}