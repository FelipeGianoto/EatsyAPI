using EatsyAPI.Cache;
using EatsyAPI.Domain.Interfaces;
using EatsyAPI.Domain.Repository;
using EatsyAPI.Domain.Repository.Interfaces;
using EatsyAPI.Domain.Services;
using EatsyAPI.Domain.Services.Interfaces;

namespace EatsyAPI.Modules;

public class FoodModule
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IFoodRepository, FoodRepository>();
        services.AddScoped<IFoodService, FoodService>();
        services.AddScoped<IFoodCategoryService, FoodCategoryService>();
        services.AddScoped<IFoodCategoryRepository, FoodCategoryRepository>();
        services.AddScoped<ICacheService, CacheService>();
        services.AddScoped<IAutoMapperService, AutoMapperService>();
    }
}