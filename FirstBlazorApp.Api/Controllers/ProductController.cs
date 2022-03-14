using FirstBlazorApp.Data;
using FirstBlazorApp.Data.Interfaces;
using FirstBlazorApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstBlazorApp.Api.Controllers;

[ApiController]
[Route("products")]
public class ProductController : ControllerBase
{

    private readonly ILogger<ProductController> _logger;
    private readonly IFirstBlazorAppApi _serverApi;

    public ProductController(
        ILogger<ProductController> logger,
        IFirstBlazorAppApi serverApi
    )
    {
        _logger = logger;
        _serverApi = serverApi;
    }
    
    [HttpGet()]
    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _serverApi.GetProductsAsync(100);
    }

    [HttpGet("{id}")]
    public async Task<Product> GetProduct(Guid id)
    {
        return await _serverApi.GetProductAsync(id);
    }

    [HttpPost()]
    public async Task<Product> CreateProduct([FromBody] Product product)
    {
        return await _serverApi.SaveProductAsync(product);
    }

    [HttpPut()]
    public async Task<Product> UpdateProduct([FromBody] Product product)
    {
        return await _serverApi.SaveProductAsync(product);
    }

    [HttpDelete("{id}")]
    public async Task<Product> DeleteProduct(Guid id)
    {
        Product product = await _serverApi.GetProductAsync(id);
        if (product != null)
        {
            await _serverApi.DeleteProductAsync(product);
        }
        return product;
    }
}