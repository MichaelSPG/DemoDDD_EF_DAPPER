using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDDD.Domain.Abstractions
{
    public interface IDateTimeProvider 
    {
        DateTime CurrentTime { get; }
    }
}
