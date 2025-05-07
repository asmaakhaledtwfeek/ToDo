using MediatR;

namespace ToDo.Application.Features.TodoItemManagement.Commands.DeleteItem;

public sealed record DeleteTodoItemCommand : IRequest<Result>
{
    public int Id { get; set; }
}