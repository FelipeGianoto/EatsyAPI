using EatsyAPI.Cache;
using EatsyAPI.Data.Dtos;
using EatsyAPI.Domain.Interfaces;
using EatsyAPI.Domain.Services.Interfaces;
using EatsyAPI.Model;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class FoodController : ControllerBase
{
    private readonly IFoodService _foodService;

    public FoodController(IFoodService foodService, ICacheService cacheService, IAutoMapperService autoMapperService)
    {
        _foodService = foodService;
    }

    [HttpPost]
    public IActionResult SaveFood([FromBody] CreateFoodDto dto)
    {
        var food = _foodService.SaveAndSaveChanges(dto);
        return CreatedAtAction(nameof(GetFoodById), new { Id = food.Id }, dto);
    }

    [HttpGet("{id}")]
    public IActionResult GetFoodById(Guid id)
    {
        var food = _foodService.GetById(id);
        if (food is null)
        {
            return NotFound();
        }
        return Ok(food);
    }

    [HttpGet("favorites")]
    public IActionResult GetFavoritesFood()
    {
        var favorites = _foodService.GetFavorites();
        return Ok(favorites);
    }

    [HttpPut("{id}")]
    public IActionResult EditFood(Guid id, [FromBody] UpdateFoodDto dto)
    {
        var existingFood = _foodService.GetById(id);
        if (existingFood is null)
        {
            return NotFound();
        }
        var updatedFood = _foodService.Update(id, dto);
        return Ok(updatedFood);
    }
}
