using EatsyAPI.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EatsyAPI.Data.Dtos;

public class CreateFoodRequestDto
{
    public Guid FoodId { get; set; }

    public int Quantity { get; set; }
}
