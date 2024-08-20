using EatsyAPI.Data;
using EatsyAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EatsyAPI.Domain.Repository;

public class FoodRepository : IFoodRepository
{
    private readonly EatsyContext _eatsyContext;
    public FoodRepository(EatsyContext eatsyContext)
    {
        _eatsyContext = eatsyContext;
    }

    public void Delete(Food food)
    {
        _eatsyContext.Foods.Remove(food);
    }

    public void DeleteAndSave(Food food)
    {
        Delete(food);
        _eatsyContext.SaveChanges();
    }

    public Food? GetById(Guid id)
    {
        return _eatsyContext.Foods.Find(id);
    }

    public List<Food> List()
    {
        return _eatsyContext.Foods.AsNoTracking().ToList();
    }

    public void Save(Food food)
    {
        _eatsyContext.Foods.Add(food);
    }

    public void SaveAndSaveChanges(Food food)
    {
        Save(food);
        SaveChanges();
    }

    public void Update(Food food)
    {
        _eatsyContext.Foods.Update(food);
    }

    public void UpdateAndSaveChanges(Food food)
    {
        Update(food);
        SaveChanges();
    }

    private void SaveChanges()
    {
        _eatsyContext.SaveChanges();
    }
}