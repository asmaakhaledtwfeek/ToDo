using Bogus;
using Microsoft.Extensions.Logging;
using ToDo.Application.Abstractions;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

namespace APA.Infrastructure.Seeders;

internal class ToDoItemSeeder : ISeeder
{
    private readonly ILogger<ToDoItemSeeder> _logger;
    private readonly IGenericRepository<TodoItem> _itemRepo;

    public int ExecutionOrder { get; set; } = 1;

    public ToDoItemSeeder(
        ILogger<ToDoItemSeeder> logger,
        IGenericRepository<TodoItem> itemRepo)
    {
        _logger = logger;
        _itemRepo = itemRepo;
    }

    public async Task SeedAsync()
    {
        if (_itemRepo.HasData())
        {
            _logger.LogInformation("Todo Items data already exists. Skipping seeding.");
            return;
        }

        try
        {
            var items = new Faker<TodoItem>()
            .CustomInstantiator(f => new TodoItem(
                title: new Faker().Lorem.Sentence(5),
                description: new Faker().Lorem.Sentence(15),
                isCompleted: f.Random.Bool()
            )).Generate(500);

            await _itemRepo.AddRangeAsync(items);
            await _itemRepo.SaveChangesAsync();

            _logger.LogInformation("Todo Items seeded successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding services.");
            throw;
        }
    }
}
