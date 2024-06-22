using Booking.Application.Abstractions.Data;
using Booking.Application.Abstractions.Messaging;
using Booking.Application.Apartments.Common;
using Booking.Domain.Abstractions;
using Booking.Domain.Apartments;
using Booking.Domain.Bookings;
using Dapper;

namespace Booking.Application.Apartments.GetApartment;

internal sealed class GetApartmentQueryQueryHandler 
    : IQueryHandler<GetApartmentQuery, ApartmentResponse>
{
    private static readonly int[] ActiveBookingStatuses =
    {
        (int)BookingStatus.Reserved,
        (int)BookingStatus.Confirmed,
        (int)BookingStatus.Completed
    };
    
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetApartmentQueryQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<ApartmentResponse>> Handle(GetApartmentQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
                           SELECT
                               a.id AS Id,
                               a.name AS Name,
                               a.description AS Description,
                               a.price_amount AS Price,
                               a.price_currency AS Currency,
                               a.address_country AS Country,
                               a.address_state AS State,
                               a.address_zip_code AS ZipCode,
                               a.address_city AS City,
                               a.address_street AS Street
                           FROM apartments AS a
                           WHERE a.Id = @ApartmentId
                           """;
        
        var apartments = await connection.QueryAsync<ApartmentResponse, AddressResponse, ApartmentResponse>(
            sql,
            (apartment, address) =>
            {
                apartment.Address = address;

                return apartment;
            },
            new
            {
                request.ApartmentId
            },
            splitOn: "Country"
        );

        var apartment = apartments.FirstOrDefault();
        
        if (apartment is null)
        {
            return Result.Failure<ApartmentResponse>(ApartmentErrors.NotFound);
        }

        return apartment;
    }
}