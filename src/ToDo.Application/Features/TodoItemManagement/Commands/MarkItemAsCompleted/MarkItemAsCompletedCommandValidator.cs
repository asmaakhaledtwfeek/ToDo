namespace ToDo.Application.Features.TodoItemManagement.Commands.MarkItemAsCompleted;

internal sealed class MarkItemAsCompletedCommandValidator : AbstractValidator<MarkItemAsCompletedCommand>
{
    public MarkItemAsCompletedCommandValidator(IGenericRepository<TodoItem> itemRepo)
    {
        RuleFor(x => x.Id)
            .NotNull()
            .EntityExist(itemRepo);
    }
}
