using FirstBlazorApp.Data.Interfaces;
using FirstBlazorApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstBlazorApp.Data;

public class FirstBlazorAppServerSideApi: IFirstBlazorAppApi
{
    private IDbContextFactory<FirstBlazorAppDbContext> Factory;

    public FirstBlazorAppServerSideApi(IDbContextFactory<FirstBlazorAppDbContext> factory)
    {
        Factory = factory;
    }

    public async Task DeleteEntity(IEntity entity)
    {
        await using var ctx = await Factory.CreateDbContextAsync();
        ctx.Remove(entity);
        await ctx.SaveChangesAsync();
    }
    
    // Products API
    public async Task<Int64> GetProductCountAsync()
    {
        await using var context = await Factory.CreateDbContextAsync();
        return await context.Products.CountAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsAsync(Int64 count, Int64 from = 0)
    {
        await using var context = await Factory.CreateDbContextAsync();
        return await context.Products
            .OrderBy(p => p.Name)
            .Skip((int) from)
            .Take((int) count)
            .ToListAsync<Product>();
    }

    public async Task<Product?> GetProductAsync(Guid id)
    {
        await using var ctx = await Factory.CreateDbContextAsync();
        return await ctx.Products
            .Include(p => p.Tags)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product> SaveProductAsync(Product product)
    {
        await using var context = await Factory.CreateDbContextAsync();
        context.Products.Update(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task DeleteProductAsync(Product product)
    {
        await DeleteEntity(product);
    }
    
    // Tags API
    public async Task<Int64> GetTagCountAsync()
    {
        await using var context = await Factory.CreateDbContextAsync();
        return await context.Tags.CountAsync();
    }

    public async Task<IEnumerable<Tag>> GetTagsAsync(Int64 count, Int64 from = 0)
    {
        await using var ctx = await Factory.CreateDbContextAsync();
        return await ctx.Tags
            .Include(t => t.Products)
            .Skip((int) from)
            .Take((int) count)
            .ToListAsync();
    }

    public async Task<Tag?> GetTagAsync(Guid id)
    {
        await using var ctx = await Factory.CreateDbContextAsync();
        return await ctx.Tags
            .Include(t => t.Products)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Tag> SaveTagAsync(Tag tag)
    {
        await using var ctx = await Factory.CreateDbContextAsync();
        ctx.Tags.Update(tag);
        await ctx.SaveChangesAsync();
        return tag;
    }

    public async Task DeleteTag(Tag tag)
    {
        await DeleteEntity(tag);
    }
    
    // Counterparties API
    public async Task<Int64> GetCounterpartyCountAsync()
    {
        await using var ctx = await Factory.CreateDbContextAsync();
        return await ctx.Counterparties.CountAsync();
    }

    public async Task<IEnumerable<Counterparty>> GetCounterparties(Int64 count, Int64 from = 0)
    {
        await using var ctx = await Factory.CreateDbContextAsync();
        return await ctx.Counterparties
            .Skip((int) from)
            .Take((int) count)
            .ToListAsync();
    }

    public async Task<Counterparty?> GetCounterparty(Guid id)
    {
        await using var ctx = await Factory.CreateDbContextAsync();
        return await ctx.Counterparties
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Counterparty> SaveCounterpartyAsync(Counterparty counterparty)
    {
        await using var ctx = await Factory.CreateDbContextAsync();
        ctx.Counterparties.Update(counterparty);
        await ctx.SaveChangesAsync();
        return counterparty;
    }

    public async Task DeleteCounterparty(Counterparty counterparty)
    {
        await DeleteEntity(counterparty);
    }
}