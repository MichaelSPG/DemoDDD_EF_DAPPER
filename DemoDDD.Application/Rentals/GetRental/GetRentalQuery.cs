using DemoDDD.Application.Abstractions.Messaging;
using DemoDDD.Domain.Rentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDDD.Application.Rentals.GetRental
{
    public sealed record GetRentalQuery(Guid RentalId) : IQuery<RentResponse>
    {
    }
}
