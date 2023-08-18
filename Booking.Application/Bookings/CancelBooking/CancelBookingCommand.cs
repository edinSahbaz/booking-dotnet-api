using Booking.Application.Abstractions.Messaging;

namespace Booking.Application.Bookings.CancelBooking;

public record CancelBookingCommand(Guid BookingId) : ICommand;