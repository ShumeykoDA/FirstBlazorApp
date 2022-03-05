using FirstBlazorApp.Store.Actions;
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
    
    [EffectMethod(typeof(CreateProduct))]
    public async Task WhenCreateProduct(IDispatcher dispatcher)
    {
        Console.WriteLine("<Create Product Success>");
        HttpResponseMessage response = await Client?.GetAsync("https://localhost:7258/")!;
        response.EnsureSuccessStatusCode();
        string body = await response.Content.ReadAsStringAsync();
        dispatcher.Dispatch(new CreateProductSuccess());
        Console.WriteLine(body);
        Console.WriteLine("</Create Product Success>");
    }

    [EffectMethod]
    public async Task WhenDeleteProduct(DeleteProduct action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new DeleteProductSuccess(action.Payload));
    }

}