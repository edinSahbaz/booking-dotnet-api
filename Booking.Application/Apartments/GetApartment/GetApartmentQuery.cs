using Booking.Application.Abstractions.Messaging;
using Booking.Application.Apartments.Common;

namespace Booking.Application.Apartments.GetApartment;

public sealed record GetApartmentQuery(
    Guid ApartmentId) : IQuery<ApartmentResponse>;