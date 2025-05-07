using ToDo.Application.Features.TodoItemManagement.Commands.AddNewItem;
using ToDo.Application.Features.TodoItemManagement.Commands.DeleteItem;
using ToDo.Application.Features.TodoItemManagement.Commands.MarkItemAsCompleted;
using ToDo.Application.Features.TodoItemManagement.Queries.GetItems;
using ToDo.Presentation.ActionFilters;

namespace ToDo.Presentation.Controllers;

[Route("api/v{version:apiVersion}/todo")]
public sealed class ToDoItemController : ApiController
{
    public ToDoItemController(ISender sender) : base(sender)
    {
    }

    [HttpPost("add-item")]
    public async Task<IActionResult> AddItem(AddTodoItemCommand command, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);
        return HandleResult(result);
    }

    [CachedAttribute(30)]
    [HttpGet("get-all-items")]
    public async Task<IActionResult> GetAllItems(string? search, CancellationToken cancellationToken, int pageIndex = 1, int pageSize = 20)
    {
        var query = new GetItemsQuery()
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            Search = search
        };
        var result = await Sender.Send(query, cancellationToken);
        return HandleResult(result);
    }

    [CachedAttribute(30)]
    [HttpGet("get-completed-items")]
    public async Task<IActionResult> GetCompletedItems(string? search, CancellationToken cancellationToken, int pageIndex = 1, int pageSize = 20)
    {
        var query = new GetItemsQuery()
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            Search = search,
            IsCompleted = true
        };
        var result = await Sender.Send(query, cancellationToken);
        return HandleResult(result);
    }

    [CachedAttribute(30)]
    [HttpGet("get-pending-items")]
    public async Task<IActionResult> GetPendingItems(string? search, CancellationToken cancellationToken, int pageIndex = 1, int pageSize = 20)
    {
        var query = new GetItemsQuery()
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            Search = search,
            IsPending = true
        };
        var result = await Sender.Send(query, cancellationToken);
        return HandleResult(result);
    }

    [HttpPut("complete-item")]
    public async Task<IActionResult> CompleteItem([FromQuery] MarkItemAsCompletedCommand command, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);
        return HandleResult(result);
    }

    [HttpDelete("delete-item")]
    public async Task<IActionResult> DeleteItem([FromQuery] int id, CancellationToken cancellationToken)
    {
        var command = new DeleteTodoItemCommand();
        command.Id = id;
        var result = await Sender.Send(command, cancellationToken);
        return HandleResult(result);
    }
}
