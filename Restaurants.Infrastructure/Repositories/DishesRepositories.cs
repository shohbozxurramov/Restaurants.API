using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;
public class DishesRepositories(RestaurantsDbContext context) 
    : IDishesRepositories
{
    public async Task<IEnumerable<Dish>> GetAllDishesAsync()
    {
        var dishes = await context.Dishes.ToListAsync();
        return dishes;
    }
    public async Task<Dish?> GetDishByIdAsync(int id)
    {
        var dish = await context.Dishes
            .FirstOrDefaultAsync(d => d.Id == id);
        if (dish is null)
        {
            return null;
        }   
        return dish;
    }
}
