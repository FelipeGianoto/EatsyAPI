using EatsyAPI.Cache;
using EatsyAPI.Data.Dtos;
using EatsyAPI.Domain.Services;
using EatsyAPI.Domain.Services.Interfaces;
using EatsyAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EatsyAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FoodCategoryController : ControllerBase
{
    private readonly IFoodCategoryService _foodCategoryService;

    public FoodCategoryController(IFoodCategoryService foodCategoryService)
    {
        _foodCategoryService = foodCategoryService;
    }

    [HttpPost]
    public IActionResult SaveFoodCategory([FromBody] CreateFoodCategoryDto dto)
    {
        FoodCategory foodCategory = _foodCategoryService.SaveAndSaveChanges(dto);
        return CreatedAtAction(nameof(GetFoodCategoryById), new { Id = foodCategory.Id }, dto);
    }

    [HttpGet]
    public IActionResult GetAllFoodCategories()
    {
        var categories = _foodCategoryService.List();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public IActionResult GetFoodCategoryById(Guid id)
    {
        ReadFoodCategorysDto? foodCategory = _foodCategoryService.GetById(id);
        if (foodCategory != null)
        {
            return Ok(foodCategory);
        }
        return NotFound();
    }
}
