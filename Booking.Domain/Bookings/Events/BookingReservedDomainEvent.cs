using Booking.Domain.Abstractions;

namespace Booking.Domain.Bookings.Events;

public record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;