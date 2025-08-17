using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;
public interface IRestaurantsRepositories
{
    Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
    Task<Restaurant?> GetRestaurantByIdAsync(int id);

}
