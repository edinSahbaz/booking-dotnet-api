using Booking.Application.Abstractions.Messaging;

namespace Booking.Application.Users.GetLoggedInUser;

public sealed record GetLoggedInUserQuery : IQuery<UserResponse>;