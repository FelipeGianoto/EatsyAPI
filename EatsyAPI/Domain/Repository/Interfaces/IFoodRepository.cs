using EatsyAPI.Model;

namespace EatsyAPI.Domain.Repository;

public interface IFoodRepository
{
    Food? GetById(Guid id);
    List<Food> List();
    void Save(Food food);
    void SaveAndSaveChanges(Food food);
    void Update(Food food);
    void UpdateAndSaveChanges(Food food);
    void Delete(Food food);
    
}