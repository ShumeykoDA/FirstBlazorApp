using System.Collections.ObjectModel;
using FirstBlazorApp.Data.Interfaces;
using FirstBlazorApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstBlazorApp.Data;

public class FirstBlazorAppServerSideApi: IFirstBlazorAppApi
{
    private readonly IDbContextFactory<FirstBlazorAppDbContext> _factory;

    public FirstBlazorAppServerSideApi(IDbContextFactory<FirstBlazorAppDbContext> factory)
    {
        _factory = factory;
    }

    public async Task DeleteEntity(IEntity entity)
    {
        await using var ctx = await _factory.CreateDbContextAsync();
        ctx.Remove(entity);
        await ctx.SaveChangesAsync();
    }
    
    // Products API
    public async Task<Int64> GetProductCountAsync()
    {
        await using var context = await _factory.CreateDbContextAsync();
        return await context.Products.CountAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsAsync(Int64 count, Int64 from = 0)
    {
        await using var context = await _factory.CreateDbContextAsync();
        return await context.Products
            .OrderBy(p => p.Name)
            .Skip((int) from)
            .Take((int) count)
            .ToListAsync<Product>();
    }

    public async Task<Product?> GetProductAsync(Guid id)
    {
        await using var ctx = await _factory.CreateDbContextAsync();
        return await ctx.Products
            .Include(p => p.Tags)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product> SaveProductAsync(Product product)
    {
        return (await SaveItem(product)) as Product;
    }

    public async Task DeleteProductAsync(Product product)
    {
        await DeleteEntity(product);
    }
    
    // Tags API
    public async Task<Int64> GetTagCountAsync()
    {
        await using var context = await _factory.CreateDbContextAsync();
        return await context.Tags.CountAsync();
    }

    public async Task<IEnumerable<Tag>> GetTagsAsync(Int64 count, Int64 from = 0)
    {
        await using var ctx = await _factory.CreateDbContextAsync();
        return await ctx.Tags
            .Include(t => t.Products)
            .Skip((int) from)
            .Take((int) count)
            .ToListAsync();
    }

    public async Task<Tag?> GetTagAsync(Guid id)
    {
        await using var ctx = await _factory.CreateDbContextAsync();
        return await ctx.Tags
            .Include(t => t.Products)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Tag> SaveTagAsync(Tag tag)
    {
        return (await SaveItem(tag)) as Tag;
    }

    public async Task DeleteTag(Tag tag)
    {
        await DeleteEntity(tag);
    }
    
    // Counterparties API
    public async Task<Int64> GetCounterpartyCountAsync()
    {
        await using var ctx = await _factory.CreateDbContextAsync();
        return await ctx.Counterparties.CountAsync();
    }

    public async Task<IEnumerable<Counterparty>> GetCounterparties(Int64 count, Int64 from = 0)
    {
        await using var ctx = await _factory.CreateDbContextAsync();
        return await ctx.Counterparties
            .Skip((int) from)
            .Take((int) count)
            .ToListAsync();
    }

    public async Task<Counterparty?> GetCounterparty(Guid id)
    {
        await using var ctx = await _factory.CreateDbContextAsync();
        return await ctx.Counterparties
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Counterparty> SaveCounterpartyAsync(Counterparty counterparty)
    {
        return (await SaveItem(counterparty)) as Counterparty;
    }

    public async Task DeleteCounterparty(Counterparty counterparty)
    {
        await DeleteEntity(counterparty);
    }

    private async Task<IEntity> SaveItem(IEntity item)
    {
        await using FirstBlazorAppDbContext context = await _factory.CreateDbContextAsync();
        if ((item.Id == null) || (item.Id == Guid.Empty))
        {
            context.Add(item);
        }
        else
        {
            if (item is Product)
            {
                bool isNew = false;
                Product product = item as Product;
                Product currentProduct = await
                    context.Products
                        .Include(p => p.Tags)
                        .FirstOrDefaultAsync(p => p.Id == product.Id);
                if (currentProduct == null)
                {
                    currentProduct = new Product(Guid.NewGuid(), "");
                    isNew = true;
                }
                currentProduct.Name = product.Name;
                currentProduct.Price = product.Price;
                currentProduct.Stock = product.Stock;
                currentProduct.Unit = product.Unit;
                IEnumerable<Guid> ids = product.Tags.Select(t => t.Id);
                IList<Tag> tags = context.Tags.Where(t => ids.Contains(t.Id)).ToList();
                currentProduct.Tags = new Collection<Tag>(tags);
                
                if (isNew) context.Add(currentProduct);
                else context.Update(currentProduct);
                
                await context.SaveChangesAsync();
            }
            else
            {
                context.Entry(item).State = EntityState.Modified;
            }
        }
        await context.SaveChangesAsync();
        return item;
    }
}