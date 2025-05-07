using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;
using ToDo.Persistence.Constants;

namespace ToDo.Persistence.Configurations;

internal sealed class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.ToTable(TableNames.TodoItems);

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
                .HasMaxLength(500)
                .IsRequired();

        builder.Property(t => t.Description)
                .HasMaxLength(1000)
                .IsRequired(false);


        builder.Property(t => t.IsCompleted)
                .HasDefaultValue(false)
                .IsRequired();

        builder.Property(a => a.CreatedOnUtc)
                .IsRequired();

        builder.Property(a => a.ModifiedOnUtc)
                .IsRequired(false);

        builder.HasIndex(n => n.Title);
        builder.HasIndex(n => n.IsCompleted);
        builder.HasIndex(n => n.CreatedOnUtc);
    }
}
