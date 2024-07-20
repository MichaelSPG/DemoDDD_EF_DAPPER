namespace DemoDDD.Domain.Abstractions
{
    public interface IDateTimeProvider 
    {
        DateTime CurrentTime { get; }
    }
}
