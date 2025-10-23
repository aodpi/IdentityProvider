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
            if (request.Id == Guid.Empty)
            {
                return Task.FromResult<Response?>(null);
            }

            // Simulate finding a user
            return Task.FromResult<Response?>(
                new Response(request.Id, "Sample User", "sample.user@example.com")
            );
        }
    }
}
