using FluentValidation;
using Mediator;

namespace IdentityProvider.Api.Features.Users;

public static class CreateUser
{
    public record Command(string Name, string Email) : IRequest<Response>;

    public record Response(Guid Id, string Name, string Email);

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email must be a valid email address");
        }
    }

    public class Handler : IRequestHandler<Command, Response>
    {
        public ValueTask<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            // This is sample data - in a real application, you would save to a database
            var userId = Guid.NewGuid();
            
            return ValueTask.FromResult(new Response(userId, request.Name, request.Email));
        }
    }
}
