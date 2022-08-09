using AutoMapper;
using MinimalApiWithMediatr.Common.Models;

namespace MinimalApiWithMediatr.Common.Mappings;

public interface IMapFrom<in T> where T : BaseEntity
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}

public interface IMapTo<out T> where T : BaseEntity
{
    void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));
}

public abstract class MapTo<T> where T : class
{
    public T MapToEntity(IMapper mapper)
    {
        return mapper.Map<T>(this);
    }
}