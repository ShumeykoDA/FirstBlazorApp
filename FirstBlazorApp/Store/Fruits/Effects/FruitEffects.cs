using FirstBlazorApp.Store.Actions;
using Fluxor;

namespace FirstBlazorApp.Store.Effects;

public class FruitEffects
{
    public FruitEffects()
    {
        
    }
    
    [EffectMethod]
    public async Task AddFruit(AddFruit action, IDispatcher dispatcher)
    {
        await Task.Delay(500);
        dispatcher.Dispatch(new AddFruitSuccess());
    }
}