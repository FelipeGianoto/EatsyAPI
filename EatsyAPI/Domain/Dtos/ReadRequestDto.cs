using EatsyAPI.Enums;

namespace EatsyAPI.Data.Dtos;

public class ReadRequestDto
{
    public Guid Id { get; set; }

    public RequestStatusEnum Status { get; set; } = RequestStatusEnum.AwaitingEstablishmentConfirmation;

    public virtual ICollection<ReadFoodRequestDto>? FoodRequests { get; set; }
}
