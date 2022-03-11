using System.Collections.ObjectModel;
using FirstBlazorApp.Data.Models;

namespace FirstBlazorApp.Data.Interfaces;

public interface ICounterparty: IEntity
{
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}