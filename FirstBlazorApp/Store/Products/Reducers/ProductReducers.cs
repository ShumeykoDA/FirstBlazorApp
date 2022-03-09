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

    [ReducerMethod]
    public static ProductState RandomizeExampleReducer(ProductState state, RandomizeExample action)
    {
        Console.WriteLine("RandomizeExampleReducer...");
        List<string> names = new List<string>()
        {
            "apple", "apricot", "avocado", "banana", "bell pepper", "bilberry", "blackberry", "blackcurrant", "blood orange",
            "blueberry", "boysenberry", "breadfruit", "canary melon", "cantaloupe", "cherimoya", "cherry", "chili pepper",
            "clementine", "cloudberry", "coconut", "cranberry", "cucumber", "currant", "damson", "date", "dragonfruit",
            "durian", "eggplant", "elderberry", "feijoa", "fig", "goji berry", "gooseberry", "grape", "grapefruit", "guava",
            "honeydew", "huckleberry", "jackfruit", "jambul", "jujube", "kiwi fruit", "kumquat", "lemon", "lime", "loquat",
            "lychee", "mandarine", "mango", "mulberry", "nectarine", "nut", "olive", "orange", "papaya", "passionfruit",
            "peach", "pear", "persimmon", "physalis", "pineapple", "plum", "pomegranate", "pomelo", "purple mangosteen",
            "quince", "raisin", "rambutan", "raspberry", "redcurrant", "rock melon", "salal berry", "satsuma", "star fruit",
            "strawberry", "tamarillo", "tangerine", "tomato", "ugli fruit", "watermelon"
        };
        List<Guid> ids = new List<Guid>(state.Ids);
        IDictionary<Guid, Product> entities = new Dictionary<Guid, Product>(state.Entities);
        for (int i = 0; i < 25; i++)
        {
            Guid id = Guid.NewGuid();
            ids.Add(id);
            entities.Add(id, new Product(
                id,
                names[new Random().Next(0, names.Count - 1)],
                (decimal) ((float) new Random().Next(1, 100) / 10),
                (decimal) ((float) new Random().Next(1, 100) / 10)
            ));
        }
        return state with
        {
            Loading = true,
            Entities = entities,
            Ids = ids
        };
    }

    [ReducerMethod]
    public static ProductState RandomizeExampleSuccessReducer(ProductState state, RandomizeExampleSuccess action)
    {
        Console.WriteLine("RandomizeExampleSuccessReducer...");
        return state with
        {
            Loading = false,
        };
    }

    [ReducerMethod]
    public static ProductState RandomizeExampleFailedReducer(ProductState state, RandomizeProductFailed action)
    {
        Console.WriteLine("RandomizeExampleFailedReducer...");
        return state with
        {
            Loading = false,
        };
    }
    
    
    
}