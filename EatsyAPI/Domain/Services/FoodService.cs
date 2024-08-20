using AutoMapper;
using EatsyAPI.Cache;
using EatsyAPI.Data.Dtos;
using EatsyAPI.Domain.Interfaces;
using EatsyAPI.Domain.Repository;
using EatsyAPI.Domain.Services.Interfaces;
using EatsyAPI.Model;

namespace EatsyAPI.Domain.Services;

public class FoodService : IFoodService
{
    private readonly IFoodRepository _foodRepository;
    private readonly ICacheService _cacheService;
    private readonly IAutoMapperService _autoMapperService;
    private IMapper _mapper;
    private const string cacheKey = "food";

    public FoodService(
        IFoodRepository foodRepository,
        IMapper mapper,
        ICacheService cacheService, 
        IAutoMapperService autoMapperService)
    {
       _foodRepository =  foodRepository;
       _mapper = mapper;
       _cacheService = cacheService;
       _autoMapperService = autoMapperService;
    }

    public void Delete(Guid id)
    {
        var food = _foodRepository.GetById(id);
        if(food == null) return;
        _cacheService.RemoveData(cacheKey);
        _foodRepository.Delete(food);
    }

    public ReadFoodDto? GetById(Guid id)
    {
        var cacheKeyWithId = $"{cacheKey}_{id}";
        var cachedFood = _cacheService.GetData<ReadFoodDto>(cacheKeyWithId);
        if (cachedFood != null)
        {
            return cachedFood;
        }
        var food = _foodRepository.GetById(id);
        return _mapper.Map<ReadFoodDto>(food);
    }

    public List<ReadFoodDto> List()
    {
        List<Food> foods = _foodRepository.List();
        return _mapper.Map<List<ReadFoodDto>>(foods);
    }

    public Food Save(CreateFoodDto createFoodDto)
    {
        Food food = _mapper.Map<Food>(createFoodDto);
        _foodRepository.Save(food);
        _cacheService.RemoveData(cacheKey);
        return food;
    }

    public Food? Update(Guid id, UpdateFoodDto updateFoodDto)
    {
        var food = _foodRepository.GetById(id); 
        if(food is null) return null;
        _mapper.Map(updateFoodDto, food);
        _foodRepository.Update(food);
        _cacheService.RemoveData(cacheKey);
        return food;
    }

    public Food SaveAndSaveChanges(CreateFoodDto createFoodDto)
    {
        Food food = _mapper.Map<Food>(createFoodDto);
        _foodRepository.SaveAndSaveChanges(food);
        return food;
    }

    public Food? UpdateAndSaveChanges(Guid id, UpdateFoodDto updateFoodDto)
    {
        var food = _foodRepository.GetById(id); 
        if(food is null) return null;
        _mapper.Map(updateFoodDto, food);
        _foodRepository.UpdateAndSaveChanges(food);
        return food;
    }

    public List<ReadFoodDto> GetFavorites()
    {
        var cacheKeyFavorites = $"{cacheKey}_favorites";
        var cachedFavorites = _cacheService.GetData<IEnumerable<ReadFoodDto>>(cacheKeyFavorites);
        if (cachedFavorites != null)
        {
            return cachedFavorites.ToList();
        }
        return List().Where(f => f.IsFavorite).ToList();
    }
}
