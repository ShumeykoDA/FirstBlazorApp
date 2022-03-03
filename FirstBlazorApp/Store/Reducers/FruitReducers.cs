using FirstBlazorApp.Models;
using FirstBlazorApp.Store.Actions;
using Fluxor;

namespace FirstBlazorApp.Store.Reducers;

public static class FruitReducers
{
    [ReducerMethod]
    public static FruitState CreateFruitReducer(FruitState state, CreateFruit action)
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