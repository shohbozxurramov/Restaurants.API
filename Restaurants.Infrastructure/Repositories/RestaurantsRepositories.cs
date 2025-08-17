using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

public class RestaurantsRepositories(RestaurantsDbContext context, ILogger<RestaurantsRepositories> logger) 
    : IRestaurantsRepositories
{
    public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
    {
        logger.LogInformation("Getting all Restaurants .");
        var restaurants = await context.Restaurants.Include(d=>d.Dishes).ToListAsync();
        return restaurants;
    }

    public Task<Restaurant?> GetRestaurantByIdAsync(int id)
    {
        var restaurant = context.Restaurants
            .Include(d => d.Dishes)
            .FirstOrDefaultAsync(r => r.Id == id);
        if (restaurant is null)
            {
            logger.LogWarning("Restaurant with id {Id} not found.", id);
            return Task.FromResult<Restaurant?>(null);
        }
        logger.LogInformation("Restaurant with id {Id} found.", id);
        return restaurant;
    }
}
