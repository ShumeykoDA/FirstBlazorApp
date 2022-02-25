﻿namespace FirstBlazorApp.Models;

public class Counterparty
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }

    public Counterparty(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}