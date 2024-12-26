using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Interfaces;
using ProjectAPI.Models;
using ProjectAPI.Repository;
using ProjectAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Database Context Configuration
builder.Services.AddDbContext<RepositoryPatternContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMvc();

// Dependence Injection
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => 
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI");
});

app.UseHttpsRedirection();

// Minimal API
app.MapGet("/Product/{id}", ([FromRoute] int id, [FromServices] IRepository<Product> product) =>
{
    ProductService service = new(product);

    return Results.Ok(service.GetProductById(id));
});

app.MapPost("/Product", ([FromBody] Product model, [FromServices] IRepository<Product> product) =>
{
    ProductService service = new(product);
    service.AddProduct(model);

    return Results.Created($"/products/{model.Id}", model.Id);
});

app.Run();
