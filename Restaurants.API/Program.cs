using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Extensions;    

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddInfrastructureServices(builder.Configuration); // This extension method registers the DbContext and other infrastructure services

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
