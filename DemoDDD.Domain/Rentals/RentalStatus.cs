using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDDD.Domain.Rentals
{
    public enum RentalStatus
    {
        Reserved = 1,
        Confirmed,
        Rejected,
        Canceled,
        Completed
    }
}
