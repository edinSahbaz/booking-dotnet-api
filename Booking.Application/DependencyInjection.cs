using Booking.Application.Abstractions.Behaviours;
using Booking.Domain.Bookings;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            configuration.AddOpenBehavior(typeof(LoggingBehaviour<,>));
        });

        services.AddTransient<PricingService>();
        
        return services;
    }
}