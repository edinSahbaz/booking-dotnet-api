using Booking.Domain.Abstractions;

namespace Booking.Domain.Bookings.Events;

public record BookingCancelledDomainEvent(Guid BookingId) : IDomainEvent;