using FirstBlazorApp.Models;

namespace FirstBlazorApp.Store;

public record FruitState: EntityState<Guid, Fruit>
{
    public FruitState(IDictionary<Guid, Fruit> entities, Func<Fruit, Guid>? getKey) : base(entities, getKey)
    {
    }

    public FruitState(IEnumerable<KeyValuePair<Guid, Fruit>> collection, Func<Fruit, Guid>? getKey, IDictionary<Guid, Fruit> entities) : base(collection, getKey, entities)
    {
    }
}

public class FruitFeature : EntityFeatureState<Guid, Fruit>
{
    public override string GetName() => "fruits-app";

    protected override EntityState<Guid, Fruit> GetInitialState()
    {
        return new FruitState(new Dictionary<Guid, Fruit>(), (Fruit f) => f.Id);
    }
}