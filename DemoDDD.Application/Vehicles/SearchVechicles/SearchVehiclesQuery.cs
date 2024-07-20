using DemoDDD.Application.Abstractions.Messaging;

namespace DemoDDD.Application.Vehicles.SearchVechicles
{
    public sealed record SearchVehiclesQuery(
        DateOnly startDate,
        DateOnly endDate
    )
        : IQuery<IReadOnlyList<VehicleResponse>>;
}
