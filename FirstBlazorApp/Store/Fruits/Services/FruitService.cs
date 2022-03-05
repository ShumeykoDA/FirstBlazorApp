using FirstBlazorApp.Models;
using FirstBlazorApp.Store.Actions;
using FirstBlazorApp.Store.States;
using Fluxor;

namespace FirstBlazorApp.Store.Fruits.Services;

public class FruitService
{
    private IDispatcher Dispatcher { get; init; }
    private IState<FruitState> State { get; init; }
    
    /*** Selectors ***/
    public IEnumerable<Fruit> Fruits => State.Value.Ids.Select(id => State.Value.Entities[id]);
    public bool Creating => State.Value.Creating;
    public bool Updating => State.Value.Updating;
    public bool Deleting => State.Value.Deleting;
    public bool Loading => State.Value.Loading;
    
    public FruitService(
        IState<FruitState> state,
        IDispatcher dispatcher
    )
    {
        Dispatcher = dispatcher;
        State = state;

    }

    public void AddFruit(Fruit fruit)
    {
        Dispatcher?.Dispatch(new AddFruit(fruit));
    }
}