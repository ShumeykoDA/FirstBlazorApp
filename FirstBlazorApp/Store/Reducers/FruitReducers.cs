using FirstBlazorApp.Models;
using FirstBlazorApp.Store.Actions;
using Fluxor;

namespace FirstBlazorApp.Store.Reducers;

public static class FruitReducers
{
    [ReducerMethod]
    public static FruitState AddFruitReducer(FruitState state, AddFruit action)
    {
        return state with
        {
            Entities = new Dictionary<Guid, Fruit>(state.Entities)
            {
                {action.Payload.Id, action.Payload}
            }
        };
    }
}