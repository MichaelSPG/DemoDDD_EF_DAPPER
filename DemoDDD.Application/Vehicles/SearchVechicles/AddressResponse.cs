using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDDD.Application.Vehicles.SearchVechicles
{
    public sealed class AddressResponse
    {
        public string? Country { get; init; }
        public string? State { get; init; }
        public string? Province { get; init; }
        public string? City { get; init; }
        public string? Street { get; init; }
    }
}
