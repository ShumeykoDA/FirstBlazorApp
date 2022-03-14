namespace FirstBlazorApp.Shared.Dtos;

public class CreateProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Stock { get; set; }
    public string? Unit { get; set; }
    public IEnumerable<string> Tags { get; set; }
}