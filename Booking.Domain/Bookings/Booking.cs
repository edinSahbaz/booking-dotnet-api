using Booking.Domain.Abstractions;
using Booking.Domain.Bookings.Events;
using Booking.Domain.Shared;

namespace Booking.Domain.Bookings;

public sealed class Booking : Entity
{
    public Booking(
        Guid id, 
        Guid apartmentId,
        Guid userId,
        DateRange duration, 
        Money priceForPeriod, 
        Money cleaningFee, 
        Money amenitiesUpCharge, 
        Money totalPrice,
        BookingStatus status,
        DateTime createdOnUtc) 
        : base(id)
    {
        ApartmentId = apartmentId;
        UserId = userId;
        Duration = duration;
        PriceForPeriod = priceForPeriod;
        CleaningFee = cleaningFee;
        AmenitiesUpCharge = amenitiesUpCharge;
        TotalPrice = totalPrice;
        Status = status;
        CreatedOnUtc = createdOnUtc;
    }
    
    public Guid ApartmentId { get; private set; }
    
    public Guid UserId { get; private set; }
    
    public DateRange Duration { get; private set; }
    
    public Money PriceForPeriod { get; private set; }
    
    public Money CleaningFee { get; private set; }
    
    public Money AmenitiesUpCharge { get; private set; }
    
    public Money TotalPrice { get; private set; }
    
    public BookingStatus Status { get; private set; }
    
    public DateTime CreatedOnUtc { get; private set; }

    public DateTime? ConfirmedOnUtc { get; private set; }
    
    public DateTime? RejectedOnUtc { get; private set; }
    
    public DateTime? CompletedOnUtc { get; private set; }
    
    public DateTime? CancelledOnUtc { get; private set; }

    public static Booking Reserve(
            Guid apartmentId,
            Guid userId,
            DateRange duration,
            DateTime utcNow,
            PricingDetails pricingDetails
        )
    {
        var booking = new Booking(
            Guid.NewGuid(),
            apartmentId,
            userId,
            duration,
            pricingDetails.PriceForPeriod,
            pricingDetails.CleaningFee,
            pricingDetails.AmenitiesUpCharge,
            pricingDetails.TotalPrice,
            BookingStatus.Reserved,
            utcNow);

        booking.RaiseDomainEvent(new BookingReservedDomainEvent(booking.Id));
        
        return booking;
    }
}