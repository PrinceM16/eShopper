using EShopper.ContextClass;
using EShopper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace EShopper.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        private ApplicationDbContext dbContext;
        public ShoppingCartController()
        {
            dbContext = new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Cart()
        {
            string userid = User.Identity.GetUserId();
            var cartList = dbContext.ShoppingCarts.Include(c => c.Product).Where(c => c.UserId == userid).ToList();
            int count = cartList.Count();
            Session["CartCount"] = count;
            return View(cartList);
        }
        [Authorize]
        public ActionResult AddCart(int id, int cartQuantity, int size, int color)
        {
            string userid = User.Identity.GetUserId();
            var cartItem = dbContext.ShoppingCarts.SingleOrDefault(c => c.ProductId == id && c.UserId == userid);
            if (cartItem == null)
            {
                cartItem = new ShoppingCart()
                {
                    ProductId = id,
                    UserId = User.Identity.GetUserId(),
                    Quantity = cartQuantity,
                    Size = ((SizeEnum)size).ToString(),
                    Color = ((ColorEnum)color).ToString(),
                    DateCreated = DateTime.Now
                };
                dbContext.ShoppingCarts.Add(cartItem);
            }
            else
            {
                cartItem.Size = ((SizeEnum)size).ToString();
                cartItem.Color = ((ColorEnum)color).ToString();
                cartItem.Quantity += cartQuantity;
            }

            dbContext.SaveChanges();
            return RedirectToAction("Cart");

        }
        public void DeleteCartItemById(int id)
        {
            var cartItem = dbContext.ShoppingCarts.SingleOrDefault(c => c.CartId == id);
            dbContext.ShoppingCarts.Remove(cartItem);
            dbContext.SaveChanges();
        }
        public void MinusQuantity(int id)
        {
            var cartItem = dbContext.ShoppingCarts.SingleOrDefault(c => c.CartId == id);
            cartItem.Quantity -= 1;
            dbContext.SaveChanges();
        }
        public void PlusQuantity(int id)
        {
            var cartItem = dbContext.ShoppingCarts.SingleOrDefault(c => c.CartId == id);
            cartItem.Quantity += 1;
            dbContext.SaveChanges();
        }
        public ActionResult Checkout()
        {
            string userid = User.Identity.GetUserId();
            var cartList = dbContext.ShoppingCarts.Where(c => c.UserId == userid).ToList();
            dbContext.ShoppingCarts.RemoveRange(cartList);
            dbContext.SaveChanges();
            return RedirectToAction("Cart");
        }
        public void UpdateCartCountSession()
        {
            string userid = User.Identity.GetUserId();
            var cartList = dbContext.ShoppingCarts.Include(c => c.Product).Where(c => c.UserId == userid).ToList();
            if (Session["CartCount"] != null)
            {
                Session["CartCount"] = cartList.Count();
            }
        }
    }
}