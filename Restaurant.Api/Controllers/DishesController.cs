using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.API.Controllers
{
    [Route("api/dishes")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IDishesService _dishesService;
        public DishesController(IDishesService dishesService)
        {
            _dishesService = dishesService;
        }
        [HttpGet]
        [Route("allDishes")]
        public async Task<ActionResult<IEnumerable<ReadDishDto>>> GetAllDishesAsync()
        {
            var dishes = await _dishesService.GetDishesAsync();
            return Ok(dishes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadDishDto?>> GetDishByIdAsync([FromRoute] int id)
        {
            var dish = await _dishesService.GetDishByIdAsync(id);
            if (dish is null)
            {
                return NotFound();
            }
            return Ok(dish);
        }
    }
}
