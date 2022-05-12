using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System_with_ADO.NET.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}