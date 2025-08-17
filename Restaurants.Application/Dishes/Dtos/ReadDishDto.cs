using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.Dtos;
public class ReadDishDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int? KiloCalories { get; set; }

    public static ReadDishDto? FromEntity(Dish? dish)
    {
        var dishDto = new ReadDishDto()
        {
            Id = dish!.Id,
            Name = dish.Name,
            Description = dish.Description,
            Price = dish.Price,
            KiloCalories = dish.KiloCalories,
        };
        return Task.FromResult(dishDto).Result;
    }
}
