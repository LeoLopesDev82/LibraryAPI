## LibraryAPI

A RESTful API for managing books and categories, built with ASP.NET Core 8.0.
Includes JWT-based authentication and Swagger documentation.

## Features

* Manage books and categories (CRUD operations)
* JWT authentication to protect endpoints
* In-memory mock login for token generation (for testing purposes)
* Swagger documentation for easy API exploration
* Controllers and DTOs fully documented in code using XML comments

## Project Structure

```
Properties/
    launchSettings.json

Controllers/
    AuthController.cs
    BooksController.cs
    CategoriesController.cs

Data/
    LibraryDbContext.cs

Migrations/
    20250804162221_InitialCreate.cs
    LibraryDbContextModelSnapshot.cs

Models/
    Auth/
        JwtSettings.cs

DTOs/
    Auth/
        LoginRequestDto.cs
        LoginResponseDto.cs
    Book/
        BookDto.cs
        CreateBookDto.cs
        UpdateBookDto.cs
    Category/
        CategoryCreateDto.cs
        CategoryDto.cs
        CategoryUpdateDto.cs

Entities/
    Book.cs
    Category.cs

Repositories/
    Implementations/
        BookRepository.cs
        CategoryRepository.cs
    Interfaces/
        IBookRepository.cs
        ICategoryRepository.cs
```

## Getting Started

### Prerequisites

* .NET 8 SDK
* SQL Server

### Setup

1. Clone this repository

2. Navigate into the project folder:

3. Restore dependencies:

4. Update the connection string in `appsettings.json` to match your SQL Server configuration.

5. Apply database migrations:

6. Run the application:

## Authentication

This API uses JWT authentication.
For testing purposes, the `AuthController` contains a mock login endpoint that generates a token if the username and password match predefined values.

In a production environment, authentication should be handled by a dedicated identity service or a central authentication API.

## API Documentation

The API documentation is available via **Swagger** when running in Development mode.
Once the API is running, open the `/swagger` endpoint in your browser to explore all endpoints, view request/response models, and test calls directly.
Controllers and DTOs are fully documented in the source code using XML comments.

## License This project is open source under the MIT License.
