using AutoMapper;
using EatsyAPI.Data.Dtos;

namespace EatsyAPI.Model.Profiles;

public class FoodRequestProfile : Profile
{
    public FoodRequestProfile()
    {
        CreateMap<FoodRequest, ReadFoodRequestDto>();
        CreateMap<CreateFoodRequestDto, FoodRequest>();
    }
}
