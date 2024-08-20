using EatsyAPI.Data.Dtos;
using EatsyAPI.Model;

namespace EatsyAPI.Domain.Services.Interfaces
{
    public interface IAutoMapperService
    {
        List<TDestination> MapToDto<TSource, TDestination>(List<TSource> list);
    }
}
