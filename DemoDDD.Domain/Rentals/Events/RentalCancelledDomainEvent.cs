using DemoDDD.Domain.Abstractions;

namespace DemoDDD.Domain.Rentals
{
    public sealed record RentalCancelledDomainEvent(Guid RentId) : IDomainEvent
    {
    }
}