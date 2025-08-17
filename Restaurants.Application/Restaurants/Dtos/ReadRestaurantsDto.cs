using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos;
public class ReadRestaurantsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public bool HasDelivery { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public List<ReadDishDto?> Dishes { get; set; } = [];

    public static ReadRestaurantsDto FromEntity(Restaurant restaurant)
    {
        var resultDtos = new ReadRestaurantsDto
        {
            Id = restaurant.Id,
            Name = restaurant.Name,
            Description = restaurant.Description,
            Category = restaurant.Category,
            HasDelivery = restaurant.HasDelivery,
            City = restaurant.Address!.City,
            Street = restaurant.Address.Street,
            PostalCode = restaurant.Address.PostalCode,
            Dishes = restaurant.Dishes
            .Select(ReadDishDto.FromEntity)
            .ToList()
        };
        return resultDtos;
    }
}
