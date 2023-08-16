using Booking.Domain.Abstractions;

namespace Booking.Domain.Bookings.Events;

public record BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;