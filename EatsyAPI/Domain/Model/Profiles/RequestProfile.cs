using AutoMapper;
using EatsyAPI.Data.Dtos;

namespace EatsyAPI.Model.Profiles;

public class RequestProfile : Profile
{
    public RequestProfile()
    {
        CreateMap<Request, ReadRequestDto>().ForMember(requestDto => requestDto.FoodRequests, opt => opt.MapFrom(request => request.FoodRequests));
        CreateMap<CreateRequestDto, Request>();
    }
}
