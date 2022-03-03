
using Fluxor;

namespace FirstBlazorApp.Store;

public record EntityState<TKey, TEntity>
{
    public IDictionary<TKey, TEntity> Entities { get; set; }
    
    protected Func<TEntity, TKey>? GetKey { get; set; }

    public EntityState(IDictionary<TKey, TEntity> entities, Func<TEntity, TKey>? getKey)
    {
        Entities = entities;
        GetKey = getKey;
    }

    public EntityState(IEnumerable<KeyValuePair<TKey, TEntity>> collection, Func<TEntity, TKey>? getKey, IDictionary<TKey, TEntity> entities)
    {
        Entities = entities;
        GetKey = getKey;
    }
}

public abstract class EntityFeatureState<TKey, TEntity> : Feature<EntityState<TKey, TEntity>>
{
    protected override EntityState<TKey, TEntity> GetInitialState()
    {
        return new EntityState<TKey, TEntity>(new Dictionary<TKey, TEntity>(), null);
    }
}