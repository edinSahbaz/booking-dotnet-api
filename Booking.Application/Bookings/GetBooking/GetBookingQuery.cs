using Booking.Application.Abstractions.Caching;

namespace Booking.Application.Bookings.GetBooking;

public record GetBookingQuery(Guid BookingId) : ICachedQuery<BookingResponse>
{
    public string CacheKey => $"bookings-{BookingId}";

    public TimeSpan? Expiration => null;
}