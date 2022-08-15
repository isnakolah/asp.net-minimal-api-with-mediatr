using AutoMapper;
using MinimalApiWithMediatr.Todo.Entities;

namespace MinimalApiWithMediatr.Todo.Commands.DTOs;

public record TodoItemCreateDTO : MapTo<TodoItem>, IMapTo<TodoItem>
{
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public Guid? GroupId { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TodoItemCreateDTO, TodoItem>();
    }
    
    public void Deconstruct(out string title, out string description, out Guid? groupId)
    {
        (title, description, groupId) = (Title, Description, GroupId);
    }
};