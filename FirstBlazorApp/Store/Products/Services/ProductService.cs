using FirstBlazorApp.Models;
using FirstBlazorApp.Store.Products.Actions;
using FirstBlazorApp.Store.Products.States;
using Fluxor;

namespace FirstBlazorApp.Store.Products.Services;

public class ProductService
{
    private IDispatcher Dispatcher { get; init; }
    private IState<ProductState> State { get; init; }

    public IEnumerable<Product> Products => State.Value.Entities.Values; 
        // State.Value.Ids.Select(id => State.Value.Entities[id]);
    public bool Creating => State.Value.Creating;
    public bool Loading => State.Value.Loading;
    public bool Updating => State.Value.Updating;
    public bool Deleting => State.Value.Deleting;

    public ProductService(
        IDispatcher dispatcher,
        IState<ProductState> state
    )
    {
        Dispatcher = dispatcher;
        State = state;
    }

    public void CreateProduct(Product product)
    {
        Dispatcher.Dispatch(new CreateProduct(product));
    }

    public void DeleteProduct(Product product)
    {
        Dispatcher.Dispatch(new DeleteProduct(product));
    }
}