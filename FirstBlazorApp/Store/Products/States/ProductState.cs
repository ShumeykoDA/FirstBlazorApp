using FirstBlazorApp.Models;
using FirstBlazorApp.Store.Interfaces;
using FirstBlazorApp.Store.States;
using Fluxor;

namespace FirstBlazorApp.Store.Products.States;

public record ProductState: EntityState<Guid, Product>, ICrudState
{
    public bool Creating { get; init; }
    public bool Updating { get; init; }
    public bool Loading { get; init; }
    public bool Deleting { get; init; }
    protected override Guid GetKey(Product entity) => entity.Id; 

    public ProductState(IDictionary<Guid, Product> entities) : base(entities)
    {
    }

    public ProductState(IEnumerable<Product> collection) : base(collection)
    {
    }
}

public class ProductFeatureState : Feature<ProductState>
{
    public override string GetName() => "products-app";

    protected override ProductState GetInitialState()
    {
        return new ProductState(new Dictionary<Guid, Product>());
    }
}