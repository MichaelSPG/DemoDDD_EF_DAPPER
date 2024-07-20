using DemoDDD.Domain.Abstractions;

namespace DemoDDD.Domain.Users.Events
{
    public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
}
