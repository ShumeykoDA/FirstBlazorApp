using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using FirstBlazorApp;
using FirstBlazorApp.Services;
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

await builder.Build().RunAsync();