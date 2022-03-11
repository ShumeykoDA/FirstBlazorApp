using System.Collections.ObjectModel;
using FirstBlazorApp.Data.Interfaces;

namespace FirstBlazorApp.Data.Models;

public class Tag: IEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public Collection<Product> Products { get; set; }

    public Tag(Guid id, string name)
    {
        Id = id;
        Name = name;
        Products = new Collection<Product>();
    }
}