using EShopper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace EShopper.Controllers.APi
{
    public class ProductController : ApiController
    {
        private ApplicationDbContext dbContext;
        public ProductController()
        {
            dbContext = new ApplicationDbContext();
        }

        [HttpGet]
        [Route("api/ProductData")]
        public IEnumerable<Product> Get(int pageNumber,int pageSize)
        {
            IEnumerable<Product> products = null;
            products = dbContext.Products
                .Include(p=>p.Category)
                .Where(p => p.ProductId >= (pageNumber - 1)*pageSize+1 
                && p.ProductId<=pageNumber*pageSize);
            return products;
        }

        
    }
}