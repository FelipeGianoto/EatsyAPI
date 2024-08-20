using EatsyAPI.Data;
using EatsyAPI.Domain.Repository.Interfaces;
using EatsyAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EatsyAPI.Domain.Repository;

public class FoodCategoryRepository : IFoodCategoryRepository
{
    private readonly EatsyContext _eatsyContext;

    public FoodCategoryRepository(EatsyContext eatsyContext)
    {
        _eatsyContext = eatsyContext;
    }

    public void Delete(FoodCategory food)
    {
        _eatsyContext.FoodCategorys.Remove(food);
    }

    public FoodCategory? GetById(Guid id)
    {
        return _eatsyContext.FoodCategorys.Find(id);
    }

    public List<FoodCategory> List()
    {
        return _eatsyContext.FoodCategorys
            .Include(fc => fc.Foods)
            .AsNoTracking()
            .ToList();
    }

    public void Save(FoodCategory foodCategory)
    {
        _eatsyContext.FoodCategorys.Add(foodCategory);
    }


    public void SaveAndSaveChanges(FoodCategory foodCategory)
    {
        _eatsyContext.FoodCategorys.Add(foodCategory);
        _eatsyContext.SaveChanges();
    }

    public void Update(FoodCategory foodCategory)
    {
        _eatsyContext.FoodCategorys.Update(foodCategory);
    }


    public void UpdateAndSaveChanges(FoodCategory foodCategory)
    {
        _eatsyContext.FoodCategorys.Update(foodCategory);
        _eatsyContext.SaveChanges();
    }

    public void UpdateAndSaveChanges(Food food)
    {
        throw new NotImplementedException();
    }
}