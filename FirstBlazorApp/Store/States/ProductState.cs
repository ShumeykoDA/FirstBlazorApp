using FirstBlazorApp.Models;
using Fluxor;

namespace FirstBlazorApp.Store;

public record ProductState
{
    public IDictionary<Guid, Product> Entities { get; init; }
    
}

public class ProductFeatureState : Feature<ProductState>
{
    public override string GetName() => nameof(ProductFeatureState);

    protected override ProductState GetInitialState()
    {
        return new ProductState()
        {
            Entities = new Dictionary<Guid, Product>()
        };
    }
}