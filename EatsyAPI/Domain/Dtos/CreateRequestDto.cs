using EatsyAPI.Enums;

namespace EatsyAPI.Data.Dtos;

public class CreateRequestDto
{
    public RequestStatusEnum Status { get; set; } = RequestStatusEnum.AwaitingEstablishmentConfirmation;

    public virtual ICollection<CreateFoodRequestDto>? FoodRequests { get; set; }
}
