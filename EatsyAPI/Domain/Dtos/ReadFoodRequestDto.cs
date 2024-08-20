using Newtonsoft.Json;

namespace EatsyAPI.Data.Dtos;

public class ReadFoodRequestDto
{
    public Guid Id { get; set; }

    public Guid FoodId { get; set; }

    public virtual ReadFoodDto Food { get; set; }

    [JsonIgnore]
    public Guid RequestId { get; set; }

    [JsonIgnore]
    public virtual ReadRequestDto Request { get; set; }

    public int Quantity { get; set; }
}
