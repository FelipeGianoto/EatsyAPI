using AutoMapper;
using EatsyAPI.Data.Dtos;

namespace EatsyAPI.Model.Profiles;

public class FoodProfile : Profile
{
    public FoodProfile()
    {
        CreateMap<Food, ReadFoodDto>();
        CreateMap<CreateFoodDto, Food>();
    }
}
