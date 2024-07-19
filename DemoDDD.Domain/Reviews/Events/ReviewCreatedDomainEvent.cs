using DemoDDD.Domain.Abstractions;

namespace DemoDDD.Domain.Reviews.Events
{
    public sealed record ReviewCreatedDomainEvent(Guid rentId) : IDomainEvent
    {
    }
}