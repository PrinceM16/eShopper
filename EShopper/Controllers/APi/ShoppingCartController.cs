using EShopper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EShopper.Controllers.APi
{
    [RoutePrefix("api/shoppingCart")]
    public class ShoppingCartController : ApiController
    {
        private ApplicationDbContext dbContext;
        public ShoppingCartController()
        {
            dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        [Authorize]
        [Route("MinusQuantity")]
        public IHttpActionResult MinusQuantity(int id)
        {
            var cartItem = dbContext.ShoppingCarts.SingleOrDefault(c => c.CartId == id);
            cartItem.Quantity -= 1;
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Authorize]
        [Route("PlusQuantity")]
        public IHttpActionResult PlusQuantity(int id)
        {
            var cartItem = dbContext.ShoppingCarts.SingleOrDefault(c => c.CartId == id);
            cartItem.Quantity += 1;
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Authorize]
        [Route("DeleteCartItemById")]
        public IHttpActionResult DeleteCartItemById(int id)
        {
            var cartItem = dbContext.ShoppingCarts.SingleOrDefault(c => c.CartId == id);
            dbContext.ShoppingCarts.Remove(cartItem);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
