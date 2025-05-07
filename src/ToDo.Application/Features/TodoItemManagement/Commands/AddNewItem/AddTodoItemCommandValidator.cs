namespace ToDo.Application.Features.TodoItemManagement.Commands.AddNewItem;

public sealed class AddTodoItemCommandValidator : AbstractValidator<AddTodoItemCommand>
{
    public AddTodoItemCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(Message.TITLE_EMPTY);
    }
}
