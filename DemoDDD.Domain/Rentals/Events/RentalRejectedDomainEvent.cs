using DemoDDD.Domain.Abstractions;

namespace DemoDDD.Domain.Rentals.Events
{
    public sealed record RentalRejectedDomainEvent(Guid rentId) : IDomainEvent
    {
    }
}