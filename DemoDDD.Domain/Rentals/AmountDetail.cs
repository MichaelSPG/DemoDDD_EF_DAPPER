using DemoDDD.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDDD.Domain.Rentals
{
    public record AmountDetail( Currency PricePerPeriod,
                                Currency Maintenance,
                                Currency Accesories,
                                Currency Total);
}
