using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using FirstBlazorApp.Data.Models;

namespace FirstBlazorApp.Data;

public class FirstBlazorAppDbContext: DbContext
{
    public FirstBlazorAppDbContext(DbContextOptions<FirstBlazorAppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Counterparty> Counterparties { get; set; }
}

public class FirstBlazorAppDbContextFactory : IDesignTimeDbContextFactory<FirstBlazorAppDbContext>
{
    public FirstBlazorAppDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<FirstBlazorAppDbContext>();
        builder.UseNpgsql("Server=localhost;Port=5441;User Id=postgres;Password=123456;Database=first-blazor-app-db;");
        return new FirstBlazorAppDbContext(builder.Options);
    }
}