using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EatsyAPI.Model;

namespace EatsyAPI.Domain.Repository.Interfaces;

public interface IFoodCategoryRepository
{
    List<FoodCategory> List();
    FoodCategory? GetById(Guid id);
    void Save(FoodCategory foodCategory);
    void SaveAndSaveChanges(FoodCategory foodCategory);
    void Update(FoodCategory foodCategory);
    void UpdateAndSaveChanges(FoodCategory foodCategory);
    void Delete(FoodCategory foodCategory);
    
}