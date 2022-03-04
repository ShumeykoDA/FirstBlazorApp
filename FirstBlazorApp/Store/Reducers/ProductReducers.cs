using FirstBlazorApp.Models;
using FirstBlazorApp.Store.Actions;
using Fluxor;

namespace FirstBlazorApp.Store.Reducers;

public static class ProductReducers
{
    [ReducerMethod]
    public static ProductState AddProductReducer(ProductState state, AddProduct action)
    {
        return state with
        {
            Entities = new List<Product>(state.Entities) { action.Payload }
        };
    }
}