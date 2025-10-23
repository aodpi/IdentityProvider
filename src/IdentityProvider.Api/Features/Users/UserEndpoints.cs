using Mediator;

namespace IdentityProvider.Api.Features.Users;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (IMediator mediator) =>
        {
            var result = await mediator.Send(new GetUsers.Query());
            return Results.Ok(result);
        })
        .WithName("GetUsers")
        .WithSummary("Get all users")
        .WithDescription("Retrieves a list of all users");

        group.MapGet("/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetUserById.Query(id));
            return result is not null ? Results.Ok(result) : Results.NotFound();
        })
        .WithName("GetUserById")
        .WithSummary("Get user by ID")
        .WithDescription("Retrieves a specific user by their ID");

        group.MapPost("/", async (CreateUser.Command command, IMediator mediator) =>
        {
            var result = await mediator.Send(command);
            return Results.Created($"/api/users/{result.Id}", result);
        })
        .WithName("CreateUser")
        .WithSummary("Create a new user")
        .WithDescription("Creates a new user with the provided information");

        return group;
    }
}
