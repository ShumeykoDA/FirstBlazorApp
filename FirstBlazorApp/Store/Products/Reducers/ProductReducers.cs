using FirstBlazorApp.Models;
using FirstBlazorApp.Store.Actions;
using FirstBlazorApp.Store.Products.Actions;
using FirstBlazorApp.Store.Products.States;
using Fluxor;

namespace FirstBlazorApp.Store.Products.Reducers;

public static class ProductReducers
{
    [ReducerMethod]
    public static ProductState CreateProductReducer(ProductState state, CreateProduct action)
    {
        return state with
        {
            Creating = true,
            Ids = new List<Guid>(state.Entities.Keys) { action.Payload.Id },
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

    [ReducerMethod]
    public static ProductState DeleteProductReducer(ProductState state, DeleteProduct action)
    {
        return state with
        {
            Deleting = true,
            Entities = new Dictionary<Guid, Product>(
                state.Entities.Values.Where(product => product.Id != action.Payload.Id)
                    .Select(product => new KeyValuePair<Guid, Product>(product.Id, product) )
            ),
            Ids = new List<Guid>(state.Ids.Where(id => id != action.Payload.Id))
        };
    }


    [ReducerMethod]
    public static ProductState DeleteProductSuccessReducer(ProductState state, DeleteProductSuccess action)
    {
        return state with
        {
            Deleting = false
        };
    }

    [ReducerMethod]
    public static ProductState DeleteProductFailedReducer(ProductState state, DeleteProductFailed action)
    {
        return state with
        {
            Deleting = false
        };
    }
    
    
    
    
}