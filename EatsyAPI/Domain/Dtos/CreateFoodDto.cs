﻿namespace EatsyAPI.Data.Dtos;

public class CreateFoodDto
{
    public double Price { get; set; }

    public string Name { get; set; }  = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string PhotoLink { get; set; }  = string.Empty;

    public bool IsFavorite { get; set; }

    public Guid FoodCategoryId { get; set; }

}