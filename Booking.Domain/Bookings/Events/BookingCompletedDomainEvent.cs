using Booking.Domain.Abstractions;

namespace Booking.Domain.Bookings.Events;

public record BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;