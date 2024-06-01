using Booking.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Authorization;

internal sealed class AuthorizationService
{
    private readonly ApplicationDbContext _dbContext;

    public AuthorizationService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserRolesResponse> GetRolesForUserAsync(string identityId)
    {
        var roles = await _dbContext.Set<User>()
            .Where(user => user.IdentityId == identityId)
            .Select(user => new UserRolesResponse
            {
                Id = user.Id,
                Roles = user.Roles.ToList(),
            })
            .FirstAsync();

        return roles;
    }

    public async Task<HashSet<string>> GetPermissionsForUserAsync(string identityId)
    {
        var permissions = await _dbContext.Set<User>()
            .Where(user => user.IdentityId == identityId)
            .SelectMany(user => user.Roles.Select(role => role.Permissions))
            .FirstAsync();

        var permissionsSet = permissions.Select(p => p.Name).ToHashSet();

        return permissionsSet;
    }
}