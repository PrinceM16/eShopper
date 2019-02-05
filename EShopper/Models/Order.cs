using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShopper.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public string Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
}