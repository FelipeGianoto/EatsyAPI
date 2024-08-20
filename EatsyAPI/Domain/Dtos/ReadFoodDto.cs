using Newtonsoft.Json;

namespace EatsyAPI.Data.Dtos;

public class ReadFoodDto
{
    public Guid Id { get; set; }

    public double Price { get; set; }
   
    public string Name { get; set; }  = string.Empty;

    public string Description { get; set; }  = string.Empty;

    public string PhotoLink { get; set; }  = string.Empty;

    public bool IsFavorite { get; set; }

    [JsonIgnore]
    public Guid FoodCategoryId { get; set; }

    [JsonIgnore]
    public virtual ReadFoodCategorysDto FoodCategory { get; set; } 
}
