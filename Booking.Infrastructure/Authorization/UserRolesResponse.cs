using Booking.Domain.Users;

namespace Booking.Infrastructure.Authorization;

public sealed class UserRolesResponse
{
    public Guid Id { get; init; }
    
    public List<Role> Roles { get; init; } = new();
}