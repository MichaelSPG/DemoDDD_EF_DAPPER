using DemoDDD.Application.Abstractions.Messaging;

namespace DemoDDD.Application.Rentals.GetRental
{
    public sealed record GetRentalQuery(Guid RentalId) : IQuery<RentResponse>
    {
    }
}
