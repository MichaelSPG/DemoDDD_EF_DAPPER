using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDDD.Domain.Vehicles
{
    public record Address
    (
        string Country,
        string State,
        string Province,
        string City,
        string Street
    );
}
