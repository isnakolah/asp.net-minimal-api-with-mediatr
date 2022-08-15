using FluentValidation;
using MinimalApiWithMediatr.Todo.Commands.DTOs;
using MinimalApiWithMediatr.Todo.Entities;

namespace MinimalApiWithMediatr.Todo.Commands.CreateTodo;

public class CreateTodoCommandValidator : AbstractValidator<CreateTodoItemCommand>
{
    public CreateTodoCommandValidator(IRepository repository)
    {
        RuleFor(x => x.CreateDTO)
            .SetValidator(new TodoItemCreateDTOValidator(repository));
    }
}

public class TodoItemCreateDTOValidator : AbstractValidator<TodoItemCreateDTO>
{
    public TodoItemCreateDTOValidator(IRepository repository)
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Todo title is required");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Todo description is required");

        RuleFor(x => x.GroupId)
            .MustAsync(async (groupId, _) =>
            {
                if (groupId is null)
                    return true;

                var groupExists = await repository.FindByIdAsync<TodoGroup>(groupId.Value) is not null;

                return groupExists;
            }).WithMessage("Group does not exist");
    }
}