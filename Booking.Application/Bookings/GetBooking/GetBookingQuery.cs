using Booking.Application.Abstractions.Messaging;

namespace Booking.Application.Bookings.GetBooking;

public record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;