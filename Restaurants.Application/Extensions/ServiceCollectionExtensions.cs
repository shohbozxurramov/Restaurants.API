﻿using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Dishes;
using Restaurants.Application.Restaurants;

namespace Restaurants.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRestaurantsService, RestaurantsService>(); 
        // IRestaurantsService interfeysini amalga oshiruvchi RestaurantsService ni DI ga qo'shamiz
        services.AddScoped<IDishesService, DishesService>();

    }
}
