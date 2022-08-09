using MinimalApiWithMediatr.Common.Models;

namespace MinimalApiWithMediatr.Todo.Entities;

public record TodoItem : BaseEntity
{
    public string Title { get; set; } = default!;

    public TodoGroup Group { get; set; } = default!;
}
