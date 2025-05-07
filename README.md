# ToDo Application

A simple, clean, and well-documented Todo application built with .NET Core.

## Core Principles

- **Quality over Quantity**: Focused on implementing core features well rather than many features poorly
- **Clean Code**: Easy to read, maintain, and explain
- **Simple Design**: Straightforward implementation without unnecessary complexity
- **Good Documentation**: Clear explanations of decisions and challenges

## Project Structure

The solution is organized into clear, focused layers:
- `ToDo.Domain`: Core business entities
- `ToDo.Application`: Business logic and use cases
- `ToDo.Infrastructure`: External services
- `ToDo.Persistence`: Data access
- `ToDo.API`: REST endpoints
- `ToDo.Presentation`: User interface

## Setup Requirements

- .NET 8.0 SDK
- Visual Studio 2022 or VS Code
- SQL Server

## How to Run

1. Clone the repository
2. Open the solution
3. Update the connection string in `appsettings.json`
4. Run the following commands:
   ```bash
   dotnet restore
   dotnet build
   dotnet run --project src/ToDo.API
   ```

## Key Features

- Create, read, update, and delete Todo items
- Mark items as complete/incomplete
- Filter items by status
- Basic error handling and validation
- Simple and intuitive API endpoints

## API Endpoints

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/api/v1/todo/add-item` | POST | Create a new todo |
| `/api/v1/todo/get-all-items` | GET | Get all todos |
| `/api/v1/todo/get-completed-items` | GET | Get completed todos |
| `/api/v1/todo/get-pending-items` | GET | Get pending todos |
| `/api/v1/todo/complete-item/{id}` | PUT | Mark a todo as complete |

## Implementation Notes

### What Worked Well
- Clean architecture made the code easy to understand and maintain
- Simple API design made it easy to test and use
- Basic error handling covered most common scenarios

### Challenges Faced
1. **Database Design**
   - Initially struggled with entity relationships
   - Solution: Simplified the model to focus on core requirements

2. **Error Handling**
   - Balancing between too much and too little error handling
   - Solution: Focused on common error cases and clear error messages

3. **Code Organization**
   - Keeping the code simple while maintaining good architecture
   - Solution: Regular refactoring and removing unnecessary complexity

## Testing

Run the tests with:
```bash
dotnet test
```

## Future Improvements

- Add more comprehensive error handling
- Implement user authentication
- Add more filtering options
- Improve test coverage

## Author
Asmaa khaled

# Todo List API

## Overview
This project is a simple Todo List Web API implemented using .NET Core, designed to demonstrate best practices in API development while adhering to the Clean Architecture principles. The API supports creating, updating, and retrieving Todo items and is implemented with modern tools and patterns for maintainability and scalability.

---

## Features
1. **Core Features:**
    - Create a new Todo item.
    - Mark a Todo item as completed.
    - Retrieve all Todo items.
    - Retrieve completed Todo items.
    - Retrieve pending (not completed) Todo items.
2. **Additional Features:**
    - **CQRS Pattern:** Clear separation of command and query responsibilities.
    - **FluentValidation:** Used for request validation.
    - **Serilog:** Integrated for structured logging.
    - **EF Core 8:** Utilized with an in-memory database for simplicity.
    - **In-Memory Caching:** Caching for improved performance.
    - **API Versioning:** To support future iterations and backward compatibility.
    - **Scrutor:** For streamlined dependency injection.
    - **Unit Tests:** Comprehensive tests using Moq.
    - **Clean Architecture:** Organized into Domain, Application, Infrastructure, and Presentation layers.
    - **Vertical Slicing:** Features grouped for easy maintainability.
    - **Domain-Driven Design (DDD):** Emphasis on domain entities and rich domain modeling.
    - **Auditable and Soft Deletable Entities:** Tracks creation, modification, and deletion metadata.
    - **Generic Repository and Unit of Work Patterns:** Simplifies data access.
    - **Specification Pattern:** For flexible and reusable query filters.
    - **Result Pattern:** Unified approach to handling results and errors.
    - **Localization:** Error messages support multiple languages.
    - Swagger: API documentation for easier interaction and testing.

---

## API Endpoints

### Version: v1.0

| Endpoint                  | HTTP Method | Description                             |
|---------------------------|-------------|-----------------------------------------|
| `/api/v1/todo/add-item`            | POST        | Create a new Todo item.                |
| `/api/v1/todo/get-all-items`            | GET         | Retrieve all Todo items.               |
| `/api/v1/todo/get-completed-items`            | GET         | Retrieve all completed Todo items.               |
| `/api/v1/todo/get-pending-items`    | GET         | Retrieve all pending Todo items.       |
| `/api/v1/todo/complete-item/{id}` | PUT      | Mark a Todo item as completed.         |

---

## Tech Stack
- **.NET 8**: Latest framework features.
- **Entity Framework Core 8**: Simplified data access.
- **FluentValidation**: Validation for request models.
- **Serilog**: Enhanced logging.
- **Swagger**: Auto-generated API documentation.
- **Moq**: Unit testing with mocked dependencies.

---

## Architecture
- **Domain Layer:** entities.
- **Application Layer:** Handles CQRS, validation, and DTO mappings.
- **Infrastructure Layer:** Implements caching, sedder, and external integrations.
- **Persistence Layer:** Implements data persistence, database tables configurations and migrations.
- **Presentation Layer:** API controllers.
---

## Note
- Just change the connection string at appsettings.json and run the project it will automaticaly create the database and apply the migrations and seed dummy data for test

## Author
Asmaa Khaled



