using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Dishes;
public interface IDishesService
{
    Task<IEnumerable<ReadDishDto>> GetDishesAsync();
    Task<ReadDishDto?> GetDishByIdAsync(int id);

}
