using MediatR;

namespace IdentityProvider.Api.Features.Users;

public static class GetUsers
{
    public record Query : IRequest<Response>;

    public record Response(List<UserDto> Users);

    public record UserDto(Guid Id, string Name, string Email);

    public class Handler : IRequestHandler<Query, Response>
    {
        public Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            // This is sample data - in a real application, you would fetch from a database
            var users = new List<UserDto>
            {
                new(Guid.NewGuid(), "John Doe", "john.doe@example.com"),
                new(Guid.NewGuid(), "Jane Smith", "jane.smith@example.com"),
                new(Guid.NewGuid(), "Bob Johnson", "bob.johnson@example.com")
            };

            return Task.FromResult(new Response(users));
        }
    }
}
