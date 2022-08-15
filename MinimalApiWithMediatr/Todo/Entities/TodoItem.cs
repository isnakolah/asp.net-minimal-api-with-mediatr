using MinimalApiWithMediatr.Common.Models;

namespace MinimalApiWithMediatr.Todo.Entities;

[Entity]
public record TodoItem : BaseEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }

    public TodoGroup? Group { get; set; }
}
