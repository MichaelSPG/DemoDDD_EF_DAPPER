using DemoDDD.Application.Abstractions.Clock;

namespace DemoDDD.Infrastucture.Clock;
public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime CurrentTime => DateTime.UtcNow;
}
