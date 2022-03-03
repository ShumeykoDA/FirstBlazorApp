using FirstBlazorApp.Models;
using FirstBlazorApp.Store.Actions;

namespace FirstBlazorApp.Store.Reducers;

public static class ProductReducers
{
    public static ProductState AddProductReducer(ProductState state, AddProduct action)
    {
        return state with
        {
            Product = action.Payload
        };
    }
}