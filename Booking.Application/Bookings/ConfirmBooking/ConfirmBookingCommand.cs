using Booking.Application.Abstractions.Messaging;

namespace Booking.Application.Bookings.ConfirmBooking;

public sealed record ConfirmBookingCommand(Guid BookingId) : ICommand;