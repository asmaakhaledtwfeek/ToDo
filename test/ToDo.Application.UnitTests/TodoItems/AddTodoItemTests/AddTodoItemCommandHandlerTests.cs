using FluentAssertions;
using MapsterMapper;
using Moq;
using ToDo.Application.Features.TodoItemManagement.Commands.AddNewItem;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

public class AddTodoItemCommandHandlerTests
{
    private readonly Mock<IGenericRepository<TodoItem>> _mocktodoItemRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly AddTodoItemCommandHandler _handler;

    public AddTodoItemCommandHandlerTests()
    {
        _mocktodoItemRepository = new Mock<IGenericRepository<TodoItem>>();
        _mockMapper = new Mock<IMapper>();

        _handler = new AddTodoItemCommandHandler(
            _mockMapper.Object,
            _mocktodoItemRepository.Object
        );
    }

    [Fact]
    public async Task Handle_ShouldAddTodoItem_WhenValidCommandIsProvided()
    {
        // Arrange
        var command = new AddTodoItemCommand
        {
            Title = "Test",
            Description = "Test Description"
        };

        var todoItem = new TodoItem();
        _mockMapper.Setup(m => m.Map<TodoItem>(command)).Returns(todoItem);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        _mocktodoItemRepository.Verify(r => r.AddAsync(todoItem, CancellationToken.None), Times.Once);
        _mocktodoItemRepository.Verify(r => r.SaveChangesAsync(CancellationToken.None), Times.Once);
    }
}
