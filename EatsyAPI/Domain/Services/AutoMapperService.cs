using AutoMapper;
using EatsyAPI.Data.Dtos;
using EatsyAPI.Domain.Repository.Interfaces;
using EatsyAPI.Domain.Services.Interfaces;
using EatsyAPI.Model;

namespace EatsyAPI.Domain.Services
{
    public class AutoMapperService : IAutoMapperService
    {
        private readonly IMapper _mapper;

        public AutoMapperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<TDestination> MapToDto<TSource, TDestination>(List<TSource> list)
        {
            return _mapper.Map<List<TDestination>>(list);
        }
    }
}
