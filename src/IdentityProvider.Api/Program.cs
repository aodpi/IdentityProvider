using FluentValidation;
using IdentityProvider.Api.Common.Behaviors;
using IdentityProvider.Api.Common.Middleware;
using IdentityProvider.Api.Features.Users;

var builder = WebApplication.CreateBuilder(args);

// Disable developer exception page to use our custom middleware
builder.WebHost.ConfigureKestrel(options =>
{
    options.AddServerHeader = false;
});

// Add services to the container.
builder.Services.AddOpenApi();

// Add MediatR with automatic handler registration
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

// Add FluentValidation
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

var app = builder.Build();

// Add exception handling middleware first
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Map feature endpoints
var apiGroup = app.MapGroup("/api");

apiGroup.MapGroup("/users")
    .MapUserEndpoints()
    .WithTags("Users");

app.Run();
