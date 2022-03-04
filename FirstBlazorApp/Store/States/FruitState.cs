using FirstBlazorApp.Models;
using Fluxor;

namespace FirstBlazorApp.Store;

public record FruitState
{
    public Dictionary<Guid, Fruit> Entities;
}

public class FruitFeatureState : Feature<FruitState>
{
    public override string GetName() => "fruits-app";

    protected override FruitState GetInitialState()
    {
        return new FruitState()
        {
            Entities = new Dictionary<Guid, Fruit>()
        };
    }
}