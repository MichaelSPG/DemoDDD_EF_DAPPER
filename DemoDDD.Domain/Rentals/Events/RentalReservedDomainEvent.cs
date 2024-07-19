using DemoDDD.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDDD.Domain.Rentals.Events
{
    public sealed record RentalReservedDomainEvent(Guid RentId) : IDomainEvent
    {
    }
}
