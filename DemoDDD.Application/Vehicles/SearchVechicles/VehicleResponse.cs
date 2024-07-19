using DemoDDD.Domain.Shared;
using DemoDDD.Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDDD.Application.Vehicles.SearchVechicles
{
    public sealed class VehicleResponse
    {
        public Guid Id { get; init; }
        public string? Model { get; init; }
        public string? Vin { get; init; }        
        public decimal Price { get; init; }
        public string? CurencyType { get; init; }

        public AddressResponse? Address { get; set; }
    }
}
