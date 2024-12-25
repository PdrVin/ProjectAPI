using Microsoft.EntityFrameworkCore;
using ProjectAPI.Interfaces;
using ProjectAPI.Models;
using ProjectAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Database Context Configuration
builder.Services.AddDbContext<RepositoryPatternContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Dependence Injection
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
