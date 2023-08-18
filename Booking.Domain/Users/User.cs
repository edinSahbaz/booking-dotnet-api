using Booking.Domain.Abstractions;
using Booking.Domain.Users.Events;

namespace Booking.Domain.Users;

public sealed class User : Entity
{
    private User(
        Guid id, FirstName firstName, LastName lastName, Email email) 
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    private User()
    {
    }
    
    public FirstName FirstName { get; private set; }
    
    public LastName LastName { get; private set; }
    
    public Email Email { get; private set; }

    public static User Create(FirstName firstName, LastName lastName, Email email)
    {
        var user = new User(Guid.NewGuid(), firstName, lastName, email);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));
        
        return user;
    }
}