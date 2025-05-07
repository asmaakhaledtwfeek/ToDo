namespace ToDo.Application.Features.TodoItemManagement.Queries.GetItems;

public class GetItemsQueryResponse
{
    public int Id { get; set; }
    public string Title { get; init; }
    public string? Description { get; init; }
    public bool IsCompleted { get; init; }
    public DateTime CreatedOnUtc { get; init; }
    public DateTime? ModifiedOnUtc { get; init; }
}
