using Booking.Domain.Abstractions;

namespace Booking.Domain.Bookings.Events;

public record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;