using FirstBlazorApp.Store.Actions;
using Fluxor;

namespace FirstBlazorApp.Store.Effects;

public class ProductEffects
{
    [EffectMethod(typeof(CreateProduct))]
    public static Task? WhenCreateProduct(IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new CreateProductSuccess());
        return null;
    }

}