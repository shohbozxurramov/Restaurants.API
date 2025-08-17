using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;
public interface IDishesRepositories
{
    Task<IEnumerable<Dish>> GetAllDishesAsync();
    Task<Dish?> GetDishByIdAsync(int id);
}
