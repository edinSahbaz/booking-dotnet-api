using Booking.Application.Abstractions.Messaging;

namespace Booking.Application.Bookings.CompleteBooking;

public record CompleteBookingCommand(Guid BookingId) : ICommand;