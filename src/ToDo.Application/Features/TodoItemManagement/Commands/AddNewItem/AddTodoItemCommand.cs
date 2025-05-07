namespace ToDo.Application.Features.TodoItemManagement.Commands.AddNewItem;

public sealed record AddTodoItemCommand : ICommand
{
    public string Title { get; init; } = null!;
    public string? Description { get; init; }
}
