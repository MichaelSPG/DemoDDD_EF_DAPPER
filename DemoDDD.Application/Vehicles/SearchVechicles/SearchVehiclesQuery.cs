using DemoDDD.Application.Abstractions.Messaging;
using DemoDDD.Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDDD.Application.Vehicles.SearchVechicles
{
    public sealed record SearchVehiclesQuery(
        DateOnly startDate,
        DateOnly endDate
    )
        : IQuery<IReadOnlyList<VehicleResponse>>;
}
