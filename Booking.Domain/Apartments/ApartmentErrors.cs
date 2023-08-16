using Booking.Domain.Abstractions;

namespace Booking.Domain.Apartments;

public static class ApartmentErrors
{
    public static Error NotFound = new(
        "Property.Found",
        "The property with the specified identifier was not found");
}