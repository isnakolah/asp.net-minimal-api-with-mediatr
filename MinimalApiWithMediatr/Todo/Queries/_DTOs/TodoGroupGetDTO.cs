using AutoMapper;
using MinimalApiWithMediatr.Todo.Entities;

namespace MinimalApiWithMediatr.Todo.Queries.DTOs;

public record TodoGroupGetDTO : IMapFrom<TodoGroup>
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TodoGroup, TodoGroupGetDTO>();
    }
}