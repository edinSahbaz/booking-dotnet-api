using Booking.Application.Abstractions.Messaging;

namespace Booking.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(
    string Email,
    string FirstName,
    string LastName,
    string Password) : ICommand<Guid>;