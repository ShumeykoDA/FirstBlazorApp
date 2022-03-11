using System.Collections.ObjectModel;
using FirstBlazorApp.Data.Models;

namespace FirstBlazorApp.Data.Interfaces;

public interface IProduct
{
    Guid Id { get; set; }
    string Name { get; set; }
    decimal Price { get; set; }
    decimal Stock { get; set; }
    string Unit { get; set; }
    ICollection<ITag> Tags { get; set; }
}