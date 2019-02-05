using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShopper.Models
{
    public class ShoppingCart
    {
        [Key]
        public int CartId { get; set; }
        public DateTime DateCreated { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
    }
}