using System.Net.Http;
using FirstBlazorApp.Models;

namespace FirstBlazorApp.Services;

public class WeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastService> _logger;

    public WeatherForecastService(ILogger<WeatherForecastService> logger)
    {
        _logger = logger;
    }

    public Task<IEnumerable<WeatherForecast>> GetForecastAsync(DateTime startDate)
    {
        Random rnd = new Random();
        return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rnd.Next(-20, 55),
                Summary = Summaries[rnd.Next(Summaries.Length)]
            })
        );
    }
}