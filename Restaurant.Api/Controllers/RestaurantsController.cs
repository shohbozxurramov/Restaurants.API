using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.API.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadRestaurantsDto>>> GetAllRestaurantsAsync()
        {
            var restaurants = await restaurantsService.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadRestaurantsDto?>> GetRestaurantByIdAsync([FromRoute]int id)
        {
            var restaurant = await restaurantsService.GetRestaurantByIdAsync(id);
            if (restaurant is null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }
    }
}
