using ToDo.Domain.Primitives;

namespace ToDo.Domain.Entities;

public sealed class TodoItem : AggregateRoot<int>, IAuditableEntity
{
    public string Title { get; private set; } = null!;
    public string? Description { get; private set; }
    public bool IsCompleted { get; private set; } = false;
    public DateTime CreatedOnUtc { get; }
    public DateTime? ModifiedOnUtc { get; }

    public TodoItem() { }
    public TodoItem(string title, string? description, bool isCompleted = false)
    {
        Title = title;
        Description = description;
        IsCompleted = isCompleted;
    }

    public void SetTitle(string title) { Title = title; }
    public void SetDescription(string description) { Description = description; }
    public void MarkAsCompleted() { IsCompleted = true; }
}
