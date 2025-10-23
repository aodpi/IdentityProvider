# IdentityProvider

Identity provider using OpenIddict, built with .NET 9.0 and Vertical Slice Architecture.

## Overview

This is a base .NET Web API application structured using the **Vertical Slice Architecture** pattern, with ready-to-use API endpoints. The application is designed to be extended into a full-featured identity provider using OpenIddict.

## Getting Started

### Prerequisites

- .NET 9.0 SDK or later

### Running the Application

```bash
# Build the solution
dotnet build

# Run the API
dotnet run --project src/IdentityProvider.Api
```

The API will be available at `http://localhost:5271`.

## Project Structure

- `src/IdentityProvider.Api/` - Main Web API project with vertical slice architecture
- `README.md` - This file
- `LICENSE` - License information

## Documentation

See [src/IdentityProvider.Api/README.md](src/IdentityProvider.Api/README.md) for detailed documentation on the architecture, features, and how to extend the application.

## Features

- ✅ Vertical Slice Architecture
- ✅ Mediator for CQRS pattern (source-generated)
- ✅ FluentValidation for request validation
- ✅ OpenAPI documentation
- ✅ Global exception handling
- ✅ Sample user management endpoints
- ✅ Minimal APIs with route groups

## Next Steps

- [ ] Integrate OpenIddict for OAuth 2.0 and OpenID Connect
- [ ] Add database support (Entity Framework Core)
- [ ] Implement user authentication
- [ ] Add JWT token generation
- [ ] Create registration and login flows

## License

See [LICENSE](LICENSE) for more information.

