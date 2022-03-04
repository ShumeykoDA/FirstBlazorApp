using FirstBlazorApp.Models;
using FirstBlazorApp.Store.Interfaces;
using Fluxor;

namespace FirstBlazorApp.Store.States;

public record FruitState: EntityState<Guid, Fruit>, ICrudState
{
    public bool Creating { get; init; }
    public bool Updating { get; init; }
    public bool Loading { get; init; }
    public bool Deleting { get; init; }
    protected override Guid GetKey(Fruit entity) => entity.Id;

    public FruitState(IDictionary<Guid, Fruit> entities) : base(entities)
    {
    }

    public FruitState(IEnumerable<Fruit> collection) : base(collection)
    {
    }
}

public class FruitFeatureState : Feature<FruitState>
{
    public override string GetName() => "fruits-app";

    protected override FruitState GetInitialState()
    {
        return new FruitState(new Dictionary<Guid, Fruit>());
    }
}