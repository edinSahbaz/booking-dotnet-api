using Booking.Domain.Abstractions;

namespace Booking.Domain.Users.Events;

public record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;