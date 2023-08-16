using Booking.Domain.Abstractions;

namespace Booking.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(Guid ReviewId) : IDomainEvent;