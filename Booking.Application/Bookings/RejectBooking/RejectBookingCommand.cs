using Booking.Application.Abstractions.Messaging;

namespace Booking.Application.Bookings.RejectBooking;

public sealed record RejectBookingCommand(Guid BookingId) : ICommand;