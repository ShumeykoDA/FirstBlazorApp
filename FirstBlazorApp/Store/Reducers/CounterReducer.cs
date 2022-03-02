using FirstBlazorApp.Store.Actions;
using Fluxor;

namespace FirstBlazorApp.Store.Reducers;

public static class CounterReducer
{
    [ReducerMethod]
    public static CounterState AddCounterReducer(CounterState state, AddCounter action)
    {
        return state with
        {
            Count = state.Count + 1
        };
    }
}