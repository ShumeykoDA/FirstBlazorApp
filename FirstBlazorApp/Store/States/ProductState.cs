using FirstBlazorApp.Models;
using Fluxor;

namespace FirstBlazorApp.Store;

public record ProductState
{
    public IEnumerable<Product> Entities { get; init; }
    
}

public class ProductFeatureState : Feature<ProductState>
{
    public override string GetName() => "products-app";

    protected override ProductState GetInitialState()
    {
        return new ProductState()
        {
            Entities = new List<Product>()
        };
    }
}