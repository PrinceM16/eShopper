using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopper.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public int Stock { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public byte CategoryId { get; set; }
    }
}