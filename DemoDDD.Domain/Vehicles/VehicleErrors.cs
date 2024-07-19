using DemoDDD.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDDD.Domain.Users
{
    public static class VehicleErrors
    {
        public static Error NotFound = new(
            "Vehicle.NotFound",
            "Vehicle was not found by the specified Id"
            );
    }
}
