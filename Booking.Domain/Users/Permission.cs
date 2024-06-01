namespace Booking.Domain.Users;

public sealed class Permission
{
    public static readonly Permission UsersRead = new(1, "users:read");
    
    public Permission(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; init; }
    
    public string Name { get; init; }

    public ICollection<User> Users { get; init; } = new List<User>();

    public ICollection<Permission> Permissions { get; init; } = new List<Permission>();
}