using MinimalApiWithMediatr.Common.Models;

namespace MinimalApiWithMediatr.Todo.Entities;

[Entity(IsTemporal = true)]
public record TodoGroup : BaseEntity
{
    public required string Name { get; set; }

    public ICollection<TodoItem> TodoItems { get; set; } = default!;
}