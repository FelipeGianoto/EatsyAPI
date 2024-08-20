using AutoMapper;
using EatsyAPI.Data.Dtos;

namespace EatsyAPI.Model.Profiles;

public class FoodCategorysProfile : Profile
{
    public FoodCategorysProfile()
    {
        CreateMap<FoodCategory, ReadFoodCategorysDto>().ForMember(foodCategoryDto => foodCategoryDto.Foods, opt => opt.MapFrom(foodCategory => foodCategory.Foods));
        CreateMap<CreateFoodCategoryDto, FoodCategory>();
    }
}
