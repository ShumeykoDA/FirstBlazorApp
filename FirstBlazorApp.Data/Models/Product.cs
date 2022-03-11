using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBlazorApp.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
        public string Unit { get; set; }

        public Product(Guid id, string name, decimal price, decimal stock = 0m, string unit = "kg") {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
            Unit = unit;
        }
    }
}