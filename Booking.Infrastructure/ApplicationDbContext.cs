using Booking.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }
}