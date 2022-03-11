using FirstBlazorApp.Store.Products.Actions;
using Fluxor;

namespace FirstBlazorApp.Store.Products.Effects;

public class ProductEffects
{
    private HttpClient Client { get; init; }
    public ProductEffects(
        HttpClient httpClient
    )
    {
        Client = httpClient;
    }
    
    [EffectMethod]
    public async Task WhenCreateProduct(CreateProduct action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new CreateProductSuccess());
    }

    [EffectMethod]
    public async Task WhenDeleteProduct(DeleteProduct action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new DeleteProductSuccess(action.Payload));
    }

    [EffectMethod]
    public async Task WhenRandomizeExample(RandomizeExample action, IDispatcher dispatcher)
    {
        Console.WriteLine("WhenRandomizeExample...");
        dispatcher.Dispatch(new RandomizeExampleSuccess());
    }

}