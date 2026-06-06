// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/apis?view=aspnetcore-10.0
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/apis?view=aspnetcore-10.0
builder.Services.AddDbContext<BugContext>(options =>
// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/apis?view=aspnetcore-10.0
    options.UseSqlServer(builder.Configuration.GetConnectionString("BugContext") ?? throw new InvalidOperationException("Connection string 'BugContext' not found.")));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
// builder.Services.AddDbContext<BugController>(opt => opt.UseInMemoryDatabase("BugList"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

