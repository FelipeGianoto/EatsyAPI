using EatsyAPI.Model;

namespace EatsyAPI.Data.Dtos;

public class ReadFoodCategorysDto
{
    public Guid Id { get; set; }

    public string Title { get; set; }  = string.Empty;

    public virtual ICollection<ReadFoodDto>? Foods { get; set; }
}
