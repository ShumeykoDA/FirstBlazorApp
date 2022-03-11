using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Fluxor;
using Radzen;
using FirstBlazorApp;
using FirstBlazorApp.Services;
using FirstBlazorApp.Store.Products.Services;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<Application>("#application");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});

// Configure Services
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<DateTimeService>();
builder.Services.AddFluxor(config =>
{
    config.ScanAssemblies(typeof(Program).Assembly)
        .UseReduxDevTools();
});
builder.Services.AddScoped<ProductService>();

// Build
WebAssemblyHost application = builder.Build();
await application.RunAsync();