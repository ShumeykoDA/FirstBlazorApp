using FirstBlazorApp.Data.Models;

namespace FirstBlazorApp.Data.Interfaces;

public interface IFirstBlazorAppApi
{
    // Products API
    Task<Int64> GetProductCountAsync();
    Task<IEnumerable<Product>> GetProductsAsync(Int64 count, Int64 from = 0);
    Task<Product?> GetProductAsync(Guid id);
    Task<Product> SaveProductAsync(Product product);
    Task DeleteProductAsync(Product product);
    
    // Tags API
    Task<Int64> GetTagCountAsync();
    Task<IEnumerable<Tag>> GetTagsAsync(Int64 count, Int64 from = 0);
    Task<Tag?> GetTagAsync(Guid id);
    Task<Tag> SaveTagAsync(Tag tag);
    Task DeleteTag(Tag tag);
    
    // Counterparties API
    Task<Int64> GetCounterpartyCountAsync();
    Task<IEnumerable<Counterparty>> GetCounterparties(Int64 count, Int64 from = 0);
    Task<Counterparty?> GetCounterparty(Guid id);
    Task<Counterparty> SaveCounterpartyAsync(Counterparty counterparty);
    Task DeleteCounterparty(Counterparty counterparty);

    Task DeleteEntity(IEntity entity);
}