namespace ToDo.Application.Features.TodoItemManagement.Queries.GetItems;

public sealed record GetItemsQuery : IPaginateQuery<GetItemsQueryResponse>
{
    public int PageIndex { get; init; } = 1;
    public int PageSize { get; init; } = 20;
    public string? Search { get; init; }
    public bool? IsPending { get; init; }
    public bool? IsCompleted { get; init; }
}
