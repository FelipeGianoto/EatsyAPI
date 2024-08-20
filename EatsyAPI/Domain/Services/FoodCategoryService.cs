using AutoMapper;
using EatsyAPI.Cache;
using EatsyAPI.Data.Dtos;
using EatsyAPI.Domain.Repository.Interfaces;
using EatsyAPI.Domain.Services.Interfaces;
using EatsyAPI.Model;

namespace EatsyAPI.Domain.Services;

public class FoodCategoryService : IFoodCategoryService
{   
    private readonly IFoodCategoryRepository _foodCategoryRepository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;
    private readonly IAutoMapperService _autoMapperService;
    private const string cacheKey = "foodCategory";

    public FoodCategoryService(
        IFoodCategoryRepository foodCategoryRepository, 
        IMapper mapper,
        ICacheService cacheService,
        IAutoMapperService autoMapperService)
    {
        _foodCategoryRepository = foodCategoryRepository;
        _mapper = mapper;
        _cacheService = cacheService;
        _autoMapperService = autoMapperService;
    }

    public void Delete(Guid id)
    {
        FoodCategory? foodCategory = _foodCategoryRepository.GetById(id);
        if(foodCategory is null) return;
        _cacheService.RemoveData(cacheKey);
        _foodCategoryRepository.Delete(foodCategory);
    }

    public ReadFoodCategorysDto? GetById(Guid id)
    {
        FoodCategory? food = _foodCategoryRepository.GetById(id);
        if(food is null) return null;
        return _mapper.Map<ReadFoodCategorysDto>(food); 
    }

    public List<ReadFoodCategorysDto> List()
    {
        var cacheData = _cacheService.GetData<IEnumerable<ReadFoodCategorysDto>>(cacheKey);
        if (cacheData != null)
        {
            return cacheData.ToList();
        }

        var expirationTime = DateTime.Now.AddMinutes(5);
        List<FoodCategory> foodsCategorys = _foodCategoryRepository.List();
        _cacheService.SetData(cacheKey, foodsCategorys, expirationTime);
        return _mapper.Map<List<ReadFoodCategorysDto>>(foodsCategorys);
    }

    public FoodCategory Save(CreateFoodCategoryDto createFoodCategoryDto)
    {
        FoodCategory foodCategory = _mapper.Map<FoodCategory>(createFoodCategoryDto);
        _foodCategoryRepository.Save(foodCategory);
        _cacheService.RemoveData(cacheKey);
        return foodCategory;
    }

    public FoodCategory SaveAndSaveChanges(CreateFoodCategoryDto createFoodCategoryDto)
    {
        FoodCategory foodCategory = _mapper.Map<FoodCategory>(createFoodCategoryDto);
        _foodCategoryRepository.SaveAndSaveChanges(foodCategory);
        _cacheService.RemoveData(cacheKey);
        return foodCategory;
    }

    public FoodCategory? Update(Guid id, UpdateFoodDto updateFoodDto)
    {
        FoodCategory? foodCategory = _foodCategoryRepository.GetById(id);
        if(foodCategory is null) return null;
        _mapper.Map(updateFoodDto, foodCategory);
        _foodCategoryRepository.Update(foodCategory);
        _cacheService.RemoveData(cacheKey);
        return foodCategory;
    }

    public FoodCategory? UpdateAndSaveChanges(Guid id, UpdateFoodDto updateFoodDto)
    {
        FoodCategory? foodCategory = _foodCategoryRepository.GetById(id);
        if(foodCategory is null) return null;
        _mapper.Map(updateFoodDto, foodCategory);
        _foodCategoryRepository.UpdateAndSaveChanges(foodCategory);
        _cacheService.RemoveData(cacheKey);
        return foodCategory;
    }
}