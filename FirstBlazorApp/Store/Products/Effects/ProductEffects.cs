using FirstBlazorApp.Store.Actions;
using FirstBlazorApp.Store.Products.Actions;
using Fluxor;

namespace FirstBlazorApp.Store.Products.Effects;

public class ProductEffects
{
    [EffectMethod(typeof(CreateProduct))]
    public static Task? WhenCreateProduct(IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new CreateProductSuccess());
        return null;
    }

}