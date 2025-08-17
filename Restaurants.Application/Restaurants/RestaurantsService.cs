using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
namespace Restaurants.Application.Restaurants;
public class RestaurantsService(IRestaurantsRepositories repositories, ILogger<RestaurantsService> logger):
    IRestaurantsService // bu class interface ni amalga oshiradi
{
    public async Task<IEnumerable<ReadRestaurantsDto>> GetAllRestaurantsAsync()
    {
        logger.LogInformation("Getting all Restaurants from service.");
        var restaurants = await repositories.GetAllRestaurantsAsync();
        var restaurantDtos = restaurants.Select(ReadRestaurantsDto.FromEntity);
        
        return restaurantDtos;
    }

    public async Task<ReadRestaurantsDto?> GetRestaurantByIdAsync(int id)
    {
        var restaurant = await repositories.GetRestaurantByIdAsync(id);
        if (restaurant is null)
        {
            logger.LogWarning("Restaurant with id {Id} not found.", id);
            return null;
        }
        var restaurantDto = ReadRestaurantsDto.FromEntity(restaurant);
        
        logger.LogInformation("Restaurant with id {Id} found.", id);
        return restaurantDto;
    }
}
