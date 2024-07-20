using DemoDDD.Domain.Abstractions;

namespace DemoDDD.Domain.Rentals.Events
{
    public sealed record RentalReservedDomainEvent(Guid RentId) : IDomainEvent
    {
    }
}
