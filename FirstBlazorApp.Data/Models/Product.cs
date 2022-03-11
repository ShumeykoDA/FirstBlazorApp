using System.Collections.ObjectModel;
using FirstBlazorApp.Data.Interfaces;

namespace FirstBlazorApp.Data.Models
{
    public class Product: IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
        public string Unit { get; set; }
        public Collection<Tag> Tags { get; set; }

        public Product(Guid id, string name) {
            Id = id;
            Name = name;
            Price = 0.00m;
            Stock = 0m;
            Unit = "kg";
            Tags = new Collection<Tag>();
        }
    }
}