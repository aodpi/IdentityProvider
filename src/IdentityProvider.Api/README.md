# IdentityProvider API

A base .NET 9.0 Web API application built using **Vertical Slice Architecture** with API endpoints ready for development.

## Architecture

This project follows the **Vertical Slice Architecture** pattern, where features are organized by business functionality rather than technical layers. Each feature contains all the necessary code (handlers, validators, models, and endpoints) in a single folder.

### Project Structure

```
src/IdentityProvider.Api/
├── Features/                 # All feature slices
│   └── Users/               # User feature slice
│       ├── GetUsers.cs      # Query to get all users
│       ├── GetUserById.cs   # Query to get user by ID
│       ├── CreateUser.cs    # Command to create a user
│       └── UserEndpoints.cs # API endpoint mappings
├── Common/                  # Shared infrastructure
│   ├── Behaviors/          # MediatR pipeline behaviors
│   │   └── ValidationBehavior.cs  # Validation pipeline
│   └── Middleware/         # Custom middleware
│       └── ExceptionHandlingMiddleware.cs  # Global exception handling
├── Program.cs              # Application entry point
└── appsettings.json        # Application configuration
```

## Technologies Used

- **.NET 9.0** - Latest .NET framework
- **ASP.NET Core Minimal APIs** - Lightweight API endpoints
- **Mediator** - Mediator pattern for CQRS (source-generated)
- **FluentValidation** - Request validation
- **OpenAPI** - API documentation

## Features

### Users Feature Slice

The Users feature demonstrates the vertical slice architecture with three endpoints:

- **GET /api/users** - Retrieve all users
- **GET /api/users/{id}** - Retrieve a specific user by ID
- **POST /api/users** - Create a new user (with validation)

## Getting Started

### Prerequisites

- .NET 9.0 SDK or later

### Running the Application

1. Clone the repository
2. Navigate to the project directory
3. Run the application:

```bash
dotnet run --project src/IdentityProvider.Api
```

The API will start on `http://localhost:5271` by default.

### Testing the API

You can test the endpoints using curl:

```bash
# Get all users
curl http://localhost:5271/api/users

# Get user by ID
curl http://localhost:5271/api/users/{guid}

# Create a user
curl -X POST http://localhost:5271/api/users \
  -H "Content-Type: application/json" \
  -d '{"name":"John Doe","email":"john.doe@example.com"}'
```

### OpenAPI Documentation

When running in Development mode, OpenAPI documentation is available at:

```
http://localhost:5271/openapi/v1.json
```

## Adding New Features

To add a new feature slice:

1. Create a new folder under `Features/` (e.g., `Features/Products/`)
2. Add your command/query classes with handlers
3. Add validators if needed
4. Create an endpoints class to map HTTP routes
5. Register endpoints in `Program.cs`

### Example Feature Structure

```csharp
// Features/Products/GetProducts.cs
public static class GetProducts
{
    public record Query : IRequest<Response>;
    public record Response(List<ProductDto> Products);
    public record ProductDto(Guid Id, string Name);
    
    public class Handler : IRequestHandler<Query, Response>
    {
        public Task<Response> Handle(Query request, CancellationToken ct)
        {
            // Implementation
        }
    }
}

// Features/Products/ProductEndpoints.cs
public static class ProductEndpoints
{
    public static RouteGroupBuilder MapProductEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (ISender sender) =>
        {
            var result = await sender.Send(new GetProducts.Query());
            return Results.Ok(result);
        });
        return group;
    }
}

// Register in Program.cs
apiGroup.MapGroup("/products")
    .MapProductEndpoints()
    .WithTags("Products");
```

## Validation

The application uses FluentValidation for request validation. Validators are automatically discovered and registered. Validation errors return a structured JSON response:

```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "Validation Error",
  "status": 400,
  "errors": {
    "Email": ["Email is required"]
  }
}
```

## Error Handling

The application includes global exception handling middleware that:
- Catches validation exceptions and returns 400 Bad Request
- Catches general exceptions and returns 500 Internal Server Error
- Returns consistent error responses in JSON format

## Next Steps

This is a base application ready for extension. Consider adding:

- Database integration (Entity Framework Core, Dapper, etc.)
- Authentication and Authorization (OpenIddict, Identity, JWT)
- Logging and monitoring (Serilog, Application Insights)
- Unit and integration tests
- Docker support
- CI/CD pipelines

## License

See the LICENSE file in the repository root.
