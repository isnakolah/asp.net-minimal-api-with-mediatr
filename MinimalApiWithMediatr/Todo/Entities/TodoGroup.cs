using MinimalApiWithMediatr.Common.Models;

namespace MinimalApiWithMediatr.Todo.Entities;

public record TodoGroup : BaseEntity
{
    public string Name { get; set; } = default!;

    public ICollection<TodoItem> TodoItems { get; set; } = default!;
}