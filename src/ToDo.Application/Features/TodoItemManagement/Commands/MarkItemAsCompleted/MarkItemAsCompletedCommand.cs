namespace ToDo.Application.Features.TodoItemManagement.Commands.MarkItemAsCompleted;

public sealed record MarkItemAsCompletedCommand : ICommand
{
    public int Id { get; init; }
}
