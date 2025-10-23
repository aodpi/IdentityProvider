using Mediator;

namespace IdentityProvider.Api.Features.Users;

public static class GetUsers
{
    public record Query : IRequest<Response>;

    public record Response(List<UserDto> Users);

    public record UserDto(Guid Id, string Name, string Email);

    public class Handler : IRequestHandler<Query, Response>
    {
        public ValueTask<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            // This is sample data - in a real application, you would fetch from a database
            var users = new List<UserDto>
            {
                new(Guid.Parse("550e8400-e29b-41d4-a716-446655440000"), "John Doe", "john.doe@example.com"),
                new(Guid.Parse("6ba7b810-9dad-11d1-80b4-00c04fd430c8"), "Jane Smith", "jane.smith@example.com"),
                new(Guid.Parse("7c9e6679-7425-40de-944b-e07fc1f90ae7"), "Bob Johnson", "bob.johnson@example.com")
            };

            return ValueTask.FromResult(new Response(users));
        }
    }
}
