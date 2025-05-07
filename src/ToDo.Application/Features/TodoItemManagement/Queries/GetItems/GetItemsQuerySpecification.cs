namespace ToDo.Application.Features.TodoItemManagement.Queries.GetItems;

internal class GetItemsQuerySpecification : Specification<TodoItem>
{
    public GetItemsQuerySpecification(GetItemsQuery query)
    {
        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            var searchTerm = query.Search.Trim().ToLower();
            AddCriteria(x => x.Title.Trim().ToLower().Contains(searchTerm));
        }

        if (query.IsPending.HasValue)
            AddCriteria(x => !x.IsCompleted);

        if (query.IsCompleted.HasValue)
            AddCriteria(x => x.IsCompleted);

        ApplyPaging(query.PageSize, query.PageIndex);
    }
}
