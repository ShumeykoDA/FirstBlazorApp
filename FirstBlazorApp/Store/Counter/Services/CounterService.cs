using FirstBlazorApp.Store.Actions;
using FirstBlazorApp.Store.Products.States;
using FirstBlazorApp.Store.States;
using Fluxor;

namespace FirstBlazorApp.Store.Counter.Services;

public class CounterService
{
    
    private IState<CounterState> State { get; init; }
    private IDispatcher Dispatcher { get; init; }

    public int Count => State.Value.Count;
    
    public CounterService(
        IState<CounterState> state,
        IDispatcher dispatcher
    )
    {
        Dispatcher = dispatcher;
        State = state;
    }

    public void AddCounter(int increment)
    {
        Dispatcher.Dispatch(new AddCounter(increment));
    }
}