using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
namespace Restaurants.Application.Restaurants;
public interface IRestaurantsService
{
    Task <IEnumerable<ReadRestaurantsDto>> GetAllRestaurantsAsync();
    Task<ReadRestaurantsDto?> GetRestaurantByIdAsync(int id);

}
