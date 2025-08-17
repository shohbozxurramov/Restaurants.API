using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes;
public class DishesService(IDishesRepositories dishesService) 
    : IDishesService
{
    public async Task<IEnumerable<ReadDishDto>> GetDishesAsync()
    {
        var dishes = await dishesService.GetAllDishesAsync();
        var dishesDtos = dishes.Select(ReadDishDto.FromEntity);
        if (dishesDtos is null || !dishesDtos.Any())
        {
           return new List<ReadDishDto>();
        }
        return dishesDtos!;
    }
    public async Task<ReadDishDto?> GetDishByIdAsync(int id)
    {
        var dish = await dishesService.GetDishByIdAsync(id);
        if (dish is null)
        {
            return null;
        }
        var dishDto = ReadDishDto.FromEntity(dish);
        return dishDto;
    }
}
