using Booking.Application.Abstractions.Messaging;
using Booking.Application.Apartments.Common;

namespace Booking.Application.Apartments.SearchApartments;

public sealed record SearchApartmentsQuery(
    DateOnly StartDate,
    DateOnly EndDate) : IQuery<IReadOnlyList<ApartmentResponse>>;