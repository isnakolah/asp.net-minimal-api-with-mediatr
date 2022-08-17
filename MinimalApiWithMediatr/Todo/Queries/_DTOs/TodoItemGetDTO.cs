using AutoMapper;
using MinimalApiWithMediatr.Todo.Entities;

namespace MinimalApiWithMediatr.Todo.Queries.DTOs;

public record TodoItemGetDTO : IMapFrom<TodoItem>
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public TodoGroupGetDTO? Group { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TodoItem, TodoItemGetDTO>();
    }
}