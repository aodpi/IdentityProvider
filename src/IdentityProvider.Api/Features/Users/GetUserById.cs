using MediatR;

namespace IdentityProvider.Api.Features.Users;

public static class GetUserById
{
    public record Query(Guid Id) : IRequest<Response?>;

    public record Response(Guid Id, string Name, string Email);

    public class Handler : IRequestHandler<Query, Response?>
    {
        public Task<Response?> Handle(Query request, CancellationToken cancellationToken)
        {
            // This is sample data - in a real application, you would fetch from a database
            // Return matching sample users for testing
            var sampleUsers = new Dictionary<Guid, Response>
            {
                { Guid.Parse("550e8400-e29b-41d4-a716-446655440000"), new Response(Guid.Parse("550e8400-e29b-41d4-a716-446655440000"), "John Doe", "john.doe@example.com") },
                { Guid.Parse("6ba7b810-9dad-11d1-80b4-00c04fd430c8"), new Response(Guid.Parse("6ba7b810-9dad-11d1-80b4-00c04fd430c8"), "Jane Smith", "jane.smith@example.com") },
                { Guid.Parse("7c9e6679-7425-40de-944b-e07fc1f90ae7"), new Response(Guid.Parse("7c9e6679-7425-40de-944b-e07fc1f90ae7"), "Bob Johnson", "bob.johnson@example.com") }
            };

            return Task.FromResult(sampleUsers.GetValueOrDefault(request.Id));
        }
    }
}
