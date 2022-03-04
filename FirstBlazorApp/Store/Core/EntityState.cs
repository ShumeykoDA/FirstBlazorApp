
using FirstBlazorApp.Store.Interfaces;
using Fluxor;

namespace FirstBlazorApp.Store.States;

public abstract record EntityState<TKey, TEntity> where TKey : notnull
{
    public IDictionary<TKey, TEntity> Entities { get; init; }
    
    public IEnumerable<TKey> Ids { get; init; }

    protected abstract TKey GetKey(TEntity entity);

    protected EntityState(IDictionary<TKey, TEntity> entities)
    {
        Entities = entities;
        Ids = entities.Keys;
    }

    protected EntityState(IEnumerable<TEntity> collection)
    {
        IEnumerable<TEntity> enumerable = collection.ToList();
        Ids = enumerable.Select(GetKey);
        Entities = enumerable.ToDictionary(GetKey);
    }
}
