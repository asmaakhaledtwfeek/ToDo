
namespace ToDo.Application.Features.TodoItemManagement.Commands.AddNewItem;

public class AddTodoItemCommandHandler : ICommandHandler<AddTodoItemCommand>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<TodoItem> _itemRepo;

    public AddTodoItemCommandHandler(IMapper mapper, IGenericRepository<TodoItem> itemRepo)
    {
        _mapper = mapper;
        _itemRepo = itemRepo;
    }
    public async Task<Result> Handle(AddTodoItemCommand request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<TodoItem>(request);

        await _itemRepo.AddAsync(item);
        await _itemRepo.SaveChangesAsync();

        return Result.Success();
    }
}
