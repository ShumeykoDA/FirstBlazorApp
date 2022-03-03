using FirstBlazorApp.Models;
using Fluxor;

namespace FirstBlazorApp.Store;

public record ProductState
{
    public Product Product { get; init; }
    
}

public class ProductFeatureState : Feature<ProductState>
{
    public override string GetName() => "products-app";

    protected override ProductState GetInitialState()
    {
        return new ProductState()
        {
            Product = null
        };
    }
}