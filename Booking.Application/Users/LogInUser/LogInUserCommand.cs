using Booking.Application.Abstractions.Messaging;

namespace Booking.Application.Users.LogInUser;

public sealed record LogInUserCommand(string Email, string Password)
    : ICommand<AccessTokenResponse>;