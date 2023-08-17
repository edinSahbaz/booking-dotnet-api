using Booking.Application.Abstractions.Clock;
using Booking.Application.Abstractions.Email;
using Booking.Domain.Abstractions;
using Booking.Domain.Apartments;
using Booking.Domain.Bookings;
using Booking.Domain.Users;
using Booking.Infrastructure.Clock;
using Booking.Infrastructure.Data;
using Booking.Infrastructure.Email;
using Booking.Infrastructure.Repositories;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        
        services.AddTransient<IEmailService, EmailService>();

        var connectionString =
            configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddScoped<IApartmentRepository, ApartmentRepository>();
        
        services.AddScoped<IBookingRepository, BookingRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());        
        
        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        
        return services;
    }
}