using MinimalApiWithMediatr.Todo.Entities;

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
            .ListAsync<TodoItem>(x => x.Title.Contains(request.Name), cancellationToken);

        return Results.Ok(todos);
    }
}
