using FirstBlazorApp.Models;
using FirstBlazorApp.Store.Actions;
using FirstBlazorApp.Store.States;
using Fluxor;

namespace FirstBlazorApp.Store.Reducers;

public static class FruitReducers
{
    [ReducerMethod]
    public static FruitState AddFruitReducer(FruitState state, AddFruit action)
    {
        return state with
        {
            Creating = true,
            Entities = new Dictionary<Guid, Fruit>(state.Entities)
            {
                {action.Payload.Id, action.Payload}
            },
            Ids = new List<Guid>(state.Ids) { action.Payload.Id }
        };
    }

    [ReducerMethod]
    public static FruitState AddFruitSuccessReducer(FruitState state, AddFruitSuccess action)
    {
        return state with
        {
            Creating = false
        };
    }


    [ReducerMethod]
    public static FruitState AddFruitFailedReducer(FruitState state, AddFruitFailed action)
    {
        return state with
        {
            Creating = false
        };
    }
}