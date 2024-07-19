using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDDD.Domain.Rentals
{
    public sealed record DateRange
    {
        private DateRange()
        {
        }

        public DateOnly Start { get; init; }
        public DateOnly End { get; init; }

        public int DaysCount => End.DayNumber - Start.DayNumber;

        public static DateRange Create(DateOnly start, DateOnly end)
        {
            if(start >  end)
            {
                throw new ApplicationException("Start date is greater than end date");
            }
            var dateRange = new DateRange()
            {
                Start = start,
                End = end
            };
            return dateRange;
        }
    }
}
