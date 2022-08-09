using MinimalApiWithMediatr.Todo.Entities;
using MinimalApiWithMediatr.Todo.Queries.DTOs;

namespace MinimalApiWithMediatr.Todo.Queries.GetTodosQuery;

[Query(Routes.Todo.Get)]
public record GetTodoItemsQuery([FromRoute] string Name, [FromQuery] int Size) : IHttpRequest;

public class GetTodoItemsQueryHandler : IHttpRequestHandler<GetTodoItemsQuery>
{
    private readonly IRepository _repository;

    public GetTodoItemsQueryHandler(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
    {
        var todos = await _repository
            .ListAsync<TodoItem, TodoItemGetDTO>(t => t.Title == request.Name, cancellationToken);

        return Results.Ok(todos);
    }
}
