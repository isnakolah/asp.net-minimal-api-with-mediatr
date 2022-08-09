namespace MinimalApiWithMediatr.Todo.Commands.DTOs;

public record TodoItemCreateDTO
{
    public string Title { get; init; }
};