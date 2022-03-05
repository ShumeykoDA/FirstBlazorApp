using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using FirstBlazorApp;
using FirstBlazorApp.Services;
using FirstBlazorApp.Store.Fruits.Services;
using FirstBlazorApp.Store.Products.Services;
using Fluxor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<DateTimeService>();
builder.Services.AddSingleton<WeatherForecastService>();

// Add Fluxor
builder.Services.AddFluxor(config =>
{
    config.ScanAssemblies(typeof(Program).Assembly)
          .UseReduxDevTools();
});

builder.Services.AddScoped<FruitService>();
builder.Services.AddScoped<ProductService>();

await builder.Build().RunAsync();