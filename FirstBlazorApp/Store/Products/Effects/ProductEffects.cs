using FirstBlazorApp.Store.Actions;
using FirstBlazorApp.Store.Products.Actions;
using Fluxor;

namespace FirstBlazorApp.Store.Products.Effects;

public class ProductEffects
{
    [EffectMethod(typeof(CreateProduct))]
    public async Task WhenCreateProduct(IDispatcher dispatcher)
    {
        await Task.Delay(800);
        dispatcher.Dispatch(new CreateProductSuccess());
    }

}