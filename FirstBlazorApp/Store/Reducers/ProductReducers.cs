using FirstBlazorApp.Models;
using FirstBlazorApp.Store.Actions;
using FirstBlazorApp.Store.States;
using Fluxor;

namespace FirstBlazorApp.Store.Reducers;

public static class ProductReducers
{
    [ReducerMethod]
    public static ProductState CreateProductReducer(ProductState state, CreateProduct action)
    {
        return state with
        {
            Creating = true,
            Entities = new Dictionary<Guid, Product>(state.Entities) { {action.Payload.Id, action.Payload} }
        };
    }

    [ReducerMethod]
    public static ProductState CreateProductSuccessReducer(ProductState state, CreateProductSuccess action)
    {
        return state with
        {
            Creating = false
        };
    }

    [ReducerMethod]
    public static ProductState CreateProductFailedReducer(ProductState state, CreateProductFailed action)
    {
        return state with
        {
            Creating = false
        };
    }
}