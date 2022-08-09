using FluentValidation;
using MinimalApiWithMediatr.Todo.Commands.DTOs;

namespace MinimalApiWithMediatr.Todo.Commands.CreateTodo;

public class CreateTodoCommandValidator : AbstractValidator<CreateTodoItemCommand>
{
    public CreateTodoCommandValidator()
    {
        RuleFor(x => x.TodoItemCreateDTO)
            .SetValidator(new TodoItemCreateDTOValidator());
    }
}

public class TodoItemCreateDTOValidator : AbstractValidator<TodoItemCreateDTO>
{
    public TodoItemCreateDTOValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Todo title is required");
    }
}