
namespace ToDo.Application.Features.TodoItemManagement.Queries.GetItems;

internal class GetItemsQueryHandler : IPaginateQueryHandler<GetItemsQuery, GetItemsQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<TodoItem> _itemRepo;

    public GetItemsQueryHandler(IMapper mapper, IGenericRepository<TodoItem> itemRepo)
    {
        _mapper = mapper;
        _itemRepo = itemRepo;
    }

    public async Task<Pagination<GetItemsQueryResponse>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetItemsQuerySpecification(request);
        (var data, var count) = _itemRepo.GetWithSpec(spec);

        var response = _mapper.Map<IReadOnlyList<GetItemsQueryResponse>>(data);

        var result = new Pagination<GetItemsQueryResponse>(request.PageIndex, request.PageSize, count, response);

        return result;
    }
}
