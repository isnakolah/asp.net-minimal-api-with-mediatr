using FluentValidation;

namespace MinimalApiWithMediatr.Todo.Queries.GetTodosQuery;

public class GetTodoItemsQueryValidator : AbstractValidator<GetTodoItemsQuery>
{
    public GetTodoItemsQueryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required");

        RuleFor(x => x.Size)
            .Must(x => x <= 10).WithMessage("Size must be less than or equal to 10");
    }
}