using DemoDDD.Application.Abstractions.Messaging;

namespace DemoDDD.Application.Rentals.ReserveRent
{
    public sealed record ReserveRentCommand(
        Guid VehicleId,
        Guid UserId,
        DateOnly StartDate,
        DateOnly EndDate
    ) : ICommand<Guid>;
}
