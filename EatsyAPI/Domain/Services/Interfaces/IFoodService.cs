using EatsyAPI.Data.Dtos;
using EatsyAPI.Model;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace EatsyAPI.Domain.Interfaces;

public interface IFoodService
{
    ReadFoodDto? GetById(Guid id);
    List<ReadFoodDto> List();
    List<ReadFoodDto> GetFavorites();
    Food Save(CreateFoodDto createFoodDto);
    Food SaveAndSaveChanges(CreateFoodDto createFoodDto);
    Food? Update(Guid id, UpdateFoodDto updateFoodDto);
    Food? UpdateAndSaveChanges(Guid id, UpdateFoodDto updateFoodDto);
    void Delete(Guid id);
}