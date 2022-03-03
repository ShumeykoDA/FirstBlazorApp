namespace FirstBlazorApp.Models;

public class Fruit
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Fruit(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}