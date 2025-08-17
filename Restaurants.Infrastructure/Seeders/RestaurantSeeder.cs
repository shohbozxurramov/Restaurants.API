using Bogus;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;
public class RestaurantSeeder(RestaurantsDbContext restaurants) // bu constructor orqali DI orqali RestaurantsDbContext ni olib keladi
    : IRestaurantSeeder // bu interface orqali seeding qilish uchun kerak bo'ladi
{
    public async Task SeedAsync()
    {
        if (await restaurants.Database.CanConnectAsync())
        {
            if (!await restaurants.Restaurants.AnyAsync())
            {
                var result = await RestaurantsDataAsync();
                if (result is null || !result.Any())
                {
                    throw new InvalidOperationException("No restaurant data available for seeding.");
                }
                await restaurants.Restaurants.AddRangeAsync(result);
                await restaurants.SaveChangesAsync();
            }
        }
    }
    private async Task<IEnumerable<Restaurant>> RestaurantsDataAsync()
    {
       Faker<Restaurant> faker = new Faker<Restaurant>()
            .RuleFor(r => r.Name, f => f.Company.CompanyName())
            .RuleFor(r => r.Description, f => f.Lorem.Paragraph())
            .RuleFor(r => r.Category, f => f.Commerce.Categories(1)[0])
            .RuleFor(r => r.HasDelivery, f => f.Random.Bool())
            .RuleFor(r => r.ContactEmail, f => f.Internet.Email())
            .RuleFor(r => r.ContactNumber, f => f.Phone.PhoneNumber())
            .RuleFor(r => r.Address, f => new Address
            {
                City = f.Address.City(),
                Street = f.Address.StreetName(),
                PostalCode = f.Address.ZipCode()
            })
            .RuleFor(r => r.Dishes, f => f.Make(f.Random.Int(1, 5), () => new Dish
            {
                Name = f.Name.JobType(),
                Description = f.Lorem.Sentence(),
                Price = f.Finance.Amount(5, 50)
            }));
        // Bu yerda Faker yordamida 10 ta restaurant yaratamiz
        return faker.Generate(20); // 10 ta restaurant yaratadi
    }
}

