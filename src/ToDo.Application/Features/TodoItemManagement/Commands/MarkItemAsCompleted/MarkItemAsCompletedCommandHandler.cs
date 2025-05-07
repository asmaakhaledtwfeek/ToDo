namespace ToDo.Application.Features.TodoItemManagement.Commands.MarkItemAsCompleted;

internal class MarkItemAsCompletedCommandHandler : ICommandHandler<MarkItemAsCompletedCommand>
{
    private readonly IGenericRepository<TodoItem> _itemRepo;

    public MarkItemAsCompletedCommandHandler(IGenericRepository<TodoItem> itemRepo)
    {
        _itemRepo = itemRepo;
    }
    public async Task<Result> Handle(MarkItemAsCompletedCommand request, CancellationToken cancellationToken)
    {
        var item = await _itemRepo.GetByIdAsync(request.Id);

        item!.MarkAsCompleted();

        _itemRepo.Update(item);
        await _itemRepo.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
