using MinimalApiWithMediatr.Data;
using MinimalApiWithMediatr.Todo.Commands.DTOs;
using MinimalApiWithMediatr.Todo.Entities;

namespace MinimalApiWithMediatr.Todo.Commands.CreateTodo;

[Command(Routes.Todo.Create)]
public record CreateTodoItemCommand([FromBody] TodoItemCreateDTO CreateItemDTO) : IHttpRequest;

public class CreateTodoItemCommandHandler : IHttpRequestHandler<CreateTodoItemCommand>
{
    private readonly ApplicationDbContext _context;

    public CreateTodoItemCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IResult> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var (title, description, groupId) = request.CreateItemDTO;

        var todoItem = new TodoItem
        {
            Title = title,
            Description = description,
            Group = await _context.TodoGroups.FindAsync(groupId)
        };

        _context.TodoItems.Add(todoItem);

        await _context.SaveChangesAsync(cancellationToken);
        
        return Results.Empty;
    }
}
