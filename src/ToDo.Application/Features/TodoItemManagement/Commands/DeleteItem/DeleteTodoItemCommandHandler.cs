using ToDo.Domain.Entities;

namespace ToDo.Application.Features.TodoItemManagement.Commands.DeleteItem;

public sealed class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand, Result>
{
    private readonly IGenericRepository<TodoItem> _itemRepo;

    public DeleteTodoItemCommandHandler(IGenericRepository<TodoItem> itemRepo)
    {
        _itemRepo = itemRepo;
    }

    public async Task<Result> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var todoItem = await _itemRepo.GetByIdAsync(request.Id);
        _itemRepo.Delete(todoItem!);
        await _itemRepo.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
} 