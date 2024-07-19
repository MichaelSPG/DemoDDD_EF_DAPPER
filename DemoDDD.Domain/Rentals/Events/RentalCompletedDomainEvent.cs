using DemoDDD.Domain.Abstractions;

namespace DemoDDD.Domain.Rentals.Events
{
    public sealed record RentalCompletedDomainEvent(Guid RentId) : IDomainEvent
    {
    }
}