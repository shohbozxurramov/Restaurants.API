using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<RestaurantsDbContext>(options=>options.UseSqlServer(connectionString));
        services.AddScoped<IRestaurantSeeder,RestaurantSeeder>();
        services.AddScoped<IRestaurantsRepositories, RestaurantsRepositories>();
        services.AddScoped<IDishesRepositories, DishesRepositories>();
    }
}
