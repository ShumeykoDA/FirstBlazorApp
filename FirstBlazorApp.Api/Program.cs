using Microsoft.EntityFrameworkCore;
using FirstBlazorApp.Data;
using FirstBlazorApp.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure database service
string connectionString = "Server=localhost;Port=5441;User Id=postgres;Password=123456;Database=first-blazor-app-db;";
builder.Services.AddDbContextFactory<FirstBlazorAppDbContext>(opt => opt.UseNpgsql(connectionString));
builder.Services.AddScoped<IFirstBlazorAppApi, FirstBlazorAppServerSideApi>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();