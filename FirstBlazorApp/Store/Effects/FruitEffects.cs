using FirstBlazorApp.Store.Actions;
using Fluxor;

namespace FirstBlazorApp.Store.Effects;

public class FruitEffects
{
    public FruitEffects()
    {
        
    }
    
    [EffectMethod(typeof(AddFruit))]
    public async Task AddFruit(IDispatcher dispatcher)
    {
        await Task.Delay(500);
        dispatcher.Dispatch(new AddFruitSuccess());
    }
}