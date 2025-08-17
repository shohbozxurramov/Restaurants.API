using Restaurants.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Restaurants.Infrastructure.Seeders;
using Restaurants.Application.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplication(); // bu yerda Application qatlamini qo'shamiz
builder.Services.AddInfrastructureServices(builder.Configuration);// bu yerda Infrastructure qatlamini qo'shamiz
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var scope = app.Services.CreateScope(); // bu yerda scope yaratamiz, bu DI orqali service larni olish uchun kerak bo'ladi
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>(); // bu yerda DI orqali IRestaurantSeeder ni olib kelamiz
await seeder.SeedAsync(); // bu yerda seeding qilish uchun IRestaurantSeeder ni chaqiramiz

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
