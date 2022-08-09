using MinimalApiWithMediatr.Todo.Commands.DTOs;

namespace MinimalApiWithMediatr.Todo.Commands.CreateTodo;

[Command(Routes.Todo.Create)]
public record CreateTodoItemCommand([FromBody] TodoItemCreateDTO TodoItemCreateDTO) : IHttpRequest;

public class CreateTodoItemCommandHandler : IHttpRequestHandler<CreateTodoItemCommand>
{
    public async Task<IResult> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Results.Empty);
    }
}
