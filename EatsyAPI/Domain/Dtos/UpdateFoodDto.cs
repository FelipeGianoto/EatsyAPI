namespace EatsyAPI.Data.Dtos;

public class UpdateFoodDto
{
    public double? Price { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? PhotoLink { get; set; }

    public bool? IsFavorite { get; set; }

    public Guid? FoodCategoryId { get; set; }
}