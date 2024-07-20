using DemoDDD.Domain.Abstractions;
using DemoDDD.Domain.Users.Events;

namespace DemoDDD.Domain.Users
{
    public sealed class User : Entity
    {
        private User()
        {
        }
        private User(Guid id, Name names, LastName lastName, Email email) 
            : base(id)
        {
            Names = names ?? throw new ArgumentNullException(nameof(names));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        public Name Names { get; private set; }
        public LastName LastName { get; private set; }
        public Email Email{ get; private set; }

        public static User Create( Name name, LastName lastName, Email email)
        {
            var user = new User( Guid.NewGuid(), name, lastName, email);
            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));
            return user;
        }
    }
}
