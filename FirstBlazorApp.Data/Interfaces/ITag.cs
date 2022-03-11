namespace FirstBlazorApp.Data.Interfaces;

public interface ITag
{
    Guid Id { get; set; }
    string Name { get; set; }
    
    ICollection<IProduct> Products { get; set; } 
}