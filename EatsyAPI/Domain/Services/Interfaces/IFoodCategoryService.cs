using EatsyAPI.Data.Dtos;
using EatsyAPI.Model;

namespace EatsyAPI.Domain.Services.Interfaces;

public interface IFoodCategoryService
{
    List<ReadFoodCategorysDto> List();
    ReadFoodCategorysDto? GetById(Guid id);
    FoodCategory Save(CreateFoodCategoryDto createFoodCategoryDto);
    FoodCategory SaveAndSaveChanges(CreateFoodCategoryDto createFoodCategoryDto);
    FoodCategory? Update(Guid id, UpdateFoodDto updateFoodDto);
    FoodCategory? UpdateAndSaveChanges(Guid id, UpdateFoodDto updateFoodDto);
    void Delete(Guid id);
}