using System.Collections.Generic;
using System.Collections.ObjectModel;
using FirstBlazorApp.Data.Interfaces;

namespace FirstBlazorApp.Data.Models;

public class Counterparty: ICounterparty
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    
    public Counterparty(Guid id, string name)
    {
        Id = id;
        Name = name;
        Email = null;
        Phone = null;
    }
}