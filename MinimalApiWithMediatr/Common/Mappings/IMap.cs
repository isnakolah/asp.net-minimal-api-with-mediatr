using AutoMapper;

namespace MinimalApiWithMediatr.Common.Mappings;

public interface IMapFrom<in T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}

public interface IMapTo<out T>
{
    void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));
}

public abstract record MapTo<T>
{
    public T MapToEntity()
    {
        return Mapper.Instance!.Map<T>(this);
    }
}