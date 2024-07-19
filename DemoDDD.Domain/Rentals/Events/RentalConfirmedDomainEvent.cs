using DemoDDD.Domain.Abstractions;

namespace DemoDDD.Domain.Rentals.Events
{
    public sealed record RentalConfirmedDomainEvent(Guid RentId) : IDomainEvent
    {
    }
}