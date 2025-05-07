using FluentValidation.TestHelper;
using ToDo.Application.Features.TodoItemManagement.Commands.AddNewItem;
using ToDo.Domain.Resources;

namespace ToDo.Application.UnitTests.TodoItems.AddTodoItemTests;

public class AddTodoItemCommandValidatorTests
{
    private readonly AddTodoItemCommandValidator _validator;

    public AddTodoItemCommandValidatorTests()
    {
        _validator = new AddTodoItemCommandValidator();
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenTitleIsEmpty()
    {
        // Arrange
        var command = new AddTodoItemCommand
        {
            Title = string.Empty,
            Description = "Test Description"
        };

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Title)
            .WithErrorMessage(Message.TITLE_EMPTY);
    }

    [Fact]
    public void Validate_ShouldNotHaveError_WhenTitleIsProvided()
    {
        // Arrange
        var command = new AddTodoItemCommand
        {
            Title = "Test Title",
            Description = "Test Description"
        };

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Title);
    }

    [Fact]
    public void Validate_ShouldNotHaveError_WhenDescriptionIsNullOrEmpty()
    {
        // Arrange
        var commandWithNullDescription = new AddTodoItemCommand
        {
            Title = "Valid Title",
            Description = null
        };

        var commandWithEmptyDescription = new AddTodoItemCommand
        {
            Title = "Valid Title",
            Description = string.Empty
        };

        // Act
        var resultWithNullDescription = _validator.TestValidate(commandWithNullDescription);
        var resultWithEmptyDescription = _validator.TestValidate(commandWithEmptyDescription);

        // Assert
        resultWithNullDescription.ShouldNotHaveValidationErrorFor(x => x.Description);
        resultWithEmptyDescription.ShouldNotHaveValidationErrorFor(x => x.Description);
    }
}
